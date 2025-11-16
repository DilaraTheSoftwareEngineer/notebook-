notebook\NoteStorage.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace notebook
{
    public static class NoteStorage
    {
        private static readonly string FilePath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "notebook", "notes.json");

        public static List<Not> Load()
        {
            try
            {
                if (!File.Exists(FilePath)) return new List<Not>();
                var json = File.ReadAllText(FilePath);
                var opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                return JsonSerializer.Deserialize<List<Not>>(json, opts) ?? new List<Not>();
            }
            catch
            {
                return new List<Not>();
            }
        }

        public static void Save(List<Not> notes)
        {
            try
            {
                var dir = Path.GetDirectoryName(FilePath);
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                var opts = new JsonSerializerOptions { WriteIndented = true };
                var json = JsonSerializer.Serialize(notes, opts);
                File.WriteAllText(FilePath, json);
            }
            catch
            {
                // Basit uygulama: hata gösterme; isterseniz log ekleyin.
            }
        }
    }
}