using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace notebook
{
    // Basit global yardımcı: tekil kullanım gerekiyorsa; aksi halde NoteStorage.cs yeterlidir.
    public static class GlobalData
    {
        public static List<Not> AllNotes { get; set; } = new List<Not>();

        private static readonly string noteFilePath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "notebook", "notes.json");

        public static void SaveNotes()
        {
            try
            {
                var dir = Path.GetDirectoryName(noteFilePath);
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

                var opts = new JsonSerializerOptions { WriteIndented = true };
                var json = JsonSerializer.Serialize(AllNotes, opts);
                File.WriteAllText(noteFilePath, json);
            }
            catch
            {
                // hata loglama isterseniz buraya ekleyin
            }
        }

        public static void LoadNotes()
        {
            try
            {
                if (!File.Exists(noteFilePath)) return;
                var json = File.ReadAllText(noteFilePath);
                var opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var loaded = JsonSerializer.Deserialize<List<Not>>(json, opts);
                if (loaded != null) AllNotes = loaded;
            }
            catch
            {
                // hata loglama isterseniz buraya ekleyin
            }
        }
    }
}