using System;
using System.Collections.Generic;
using System.Drawing;

namespace notebook
{
    public static class ThemeManager
    {
        public static Dictionary<string, (Color Back, Color Fore)> Themes { get; } = new()
        {
            { "Soft Açık", (Color.FromArgb(250,250,245), Color.FromArgb(40,40,40)) },
            { "Pastel Mavi", (Color.FromArgb(235,245,255), Color.FromArgb(25,40,60)) },
            { "Pastel Yeşil", (Color.FromArgb(240,255,245), Color.FromArgb(25,40,30)) },
            { "Krema", (Color.FromArgb(255,250,240), Color.FromArgb(40,35,30)) }
        };
        public static Color ControlBackground { get; internal set; }
        public static Color TextColor { get; internal set; }

        internal static void ApplyTheme(global::Form1 form1)
        {
            throw new NotImplementedException();
        }

        internal static void ApplyTheme(global::NoteEditorForm noteEditorForm)
        {
            throw new NotImplementedException();
        }

        internal static void SetTheme(SoftTheme theme)
        {
            throw new NotImplementedException();
        }
    }
}
