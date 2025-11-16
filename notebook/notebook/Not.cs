using System;
using System.Collections.Generic;

namespace notebook
{
    public enum NoteType
    {
        Text,
        Todo
    }

    public class TodoItem
    {
        public string Text { get; set; } = string.Empty;
        public bool IsDone { get; set; }
    }

    public class Not
    {
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; } = "Yeni Not";
        public NoteType Type { get; set; } = NoteType.Text;
        // RTF içeriği
        public string ContentRtf { get; set; } = string.Empty;
        // Görev listesi
        public List<TodoItem> Tasks { get; set; } = new List<TodoItem>();
        public DateTime ModifiedUtc { get; set; } = DateTime.UtcNow;

        public Not()
        {
        }

        public override string ToString() => Title;
    }
}