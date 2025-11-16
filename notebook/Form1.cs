using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace notebook
{
    public partial class Form1 : Form
    {
        private BindingList<Not> notes = new();
        private Not? selectedNote = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Font list doldurma
            foreach (var f in FontFamily.Families.OrderBy(f => f.Name))
                cmbFonts.Items.Add(f.Name);
            if (cmbFonts.Items.Count > 0) cmbFonts.SelectedItem = "Segoe UI";

            cmbFontSize.Items.AddRange(new object[] { "8", "9", "10", "11", "12", "14", "16", "18", "20", "24", "28" });
            if (cmbFontSize.Items.Count > 0) cmbFontSize.SelectedItem = "12";

            // Temalar
            foreach (var k in ThemeManager.Themes.Keys) cmbTheme.Items.Add(k);
            if (cmbTheme.Items.Count > 0) cmbTheme.SelectedIndex = 0;

            // Notlarý yükle
            var loaded = NoteStorage.Load();
            foreach (var n in loaded) notes.Add(n);
            lstNotes.DataSource = notes;
            lstNotes.DisplayMember = nameof(Not.Title);

            if (notes.Count > 0) lstNotes.SelectedIndex = 0;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var n = new Not { Title = "Baþlýksýz Not", RtfContent = string.Empty };
            notes.Add(n);
            lstNotes.SelectedItem = n;
            SaveAll();
        }

        private void lstNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstNotes.SelectedItem is Not n) LoadNote(n);
        }

        private void LoadNote(Not n)
        {
            selectedNote = n;
            txtTitle.Text = n.Title ?? string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(n.RtfContent))
                    rtbContent.Rtf = n.RtfContent;
                else
                    rtbContent.Clear();
            }
            catch
            {
                rtbContent.Text = n.RtfContent ?? string.Empty;
            }

            lvTodos.Items.Clear();
            if (n.Todos != null)
            {
                foreach (var t in n.Todos)
                {
                    var itm = new ListViewItem(t.Text) { Checked = t.IsDone };
                    lvTodos.Items.Add(itm);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstNotes.SelectedItem is Not n)
            {
                var idx = lstNotes.SelectedIndex;
                notes.Remove(n);
                SaveAll();
                if (notes.Count > 0)
                    lstNotes.SelectedIndex = Math.Max(0, idx - 1);
                else
                {
                    selectedNote = null;
                    txtTitle.Clear();
                    rtbContent.Clear();
                    lvTodos.Items.Clear();
                }
            }
        }

        private void btnSaveNote_Click(object sender, EventArgs e)
        {
            if (selectedNote == null) return;

            selectedNote.Title = string.IsNullOrWhiteSpace(txtTitle.Text) ? "Baþlýksýz Not" : txtTitle.Text;
            selectedNote.RtfContent = rtbContent.Rtf;
            selectedNote.ModifiedUtc = DateTime.UtcNow;

            selectedNote.Todos = lvTodos.Items
                .Cast<ListViewItem>()
                .Select(i => new TodoItem { Text = i.Text, IsDone = i.Checked })
                .ToList();

            var idx = notes.IndexOf(selectedNote);
            if (idx >= 0) notes.ResetItem(idx);

            SaveAll();
        }

        private void btnSaveAll_Click(object sender, EventArgs e) => SaveAll();

        private void SaveAll()
        {
            NoteStorage.Save(notes.ToList());
        }

        private void btnAddTodo_Click(object sender, EventArgs e)
        {
            var text = txtTodo.Text.Trim();
            if (string.IsNullOrEmpty(text) || selectedNote == null) return;
            var itm = new ListViewItem(text) { Checked = false };
            lvTodos.Items.Add(itm);
            txtTodo.Clear();

            selectedNote.Todos.Add(new TodoItem { Text = text, IsDone = false });
            selectedNote.ModifiedUtc = DateTime.UtcNow;
            SaveAll();
        }

        private void btnRemoveTodo_Click(object sender, EventArgs e)
        {
            if (selectedNote == null) return;
            var toRemove = lvTodos.SelectedIndices.Cast<int>().OrderByDescending(i => i).ToList();
            foreach (var i in toRemove) lvTodos.Items.RemoveAt(i);

            selectedNote.Todos = lvTodos.Items.Cast<ListViewItem>()
                .Select(i => new TodoItem { Text = i.Text, IsDone = i.Checked })
                .ToList();

            SaveAll();
        }

        private void lvTodos_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (selectedNote == null) return;
            selectedNote.Todos = lvTodos.Items.Cast<ListViewItem>()
                .Select(i => new TodoItem { Text = i.Text, IsDone = i.Checked })
                .ToList();
            selectedNote.ModifiedUtc = DateTime.UtcNow;
            SaveAll();
        }

        private void cmbTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            var key = cmbTheme.SelectedItem?.ToString();
            if (key == null || !ThemeManager.Themes.ContainsKey(key)) return;
            var (back, fore) = ThemeManager.Themes[key];

            this.BackColor = back;
            this.ForeColor = fore;

            foreach (Control c in this.Controls) UpdateControlThemeRecursive(c, back, fore);
        }

        private void UpdateControlThemeRecursive(Control c, Color back, Color fore)
        {
            if (c is ListView || c is ListBox || c is TextBox || c is RichTextBox)
            {
                c.BackColor = Color.White;
                c.ForeColor = Color.Black;
            }
            else
            {
                c.BackColor = back;
                c.ForeColor = fore;
            }

            foreach (Control child in c.Controls) UpdateControlThemeRecursive(child, back, fore);
        }

        private void btnApplyFont_Click(object sender, EventArgs e)
        {
            var fontName = cmbFonts.SelectedItem?.ToString();
            var sizeText = cmbFontSize.SelectedItem?.ToString();
            if (fontName == null || sizeText == null) return;
            if (!float.TryParse(sizeText, out float size)) return;

            if (rtbContent.SelectionLength > 0)
                rtbContent.SelectionFont = new Font(fontName, size);
            else
                rtbContent.Font = new Font(fontName, size);
        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            ToggleSelectionFontStyle(FontStyle.Bold, btnBold.Checked);
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            ToggleSelectionFontStyle(FontStyle.Italic, btnItalic.Checked);
        }

        private void ToggleSelectionFontStyle(FontStyle style, bool set)
        {
            var selStart = rtbContent.SelectionStart;
            var selLen = rtbContent.SelectionLength;
            if (selLen == 0)
            {
                var f = rtbContent.Font;
                var newStyle = set ? f.Style | style : f.Style & ~style;
                rtbContent.Font = new Font(f.FontFamily, f.Size, newStyle);
                return;
            }

            var current = rtbContent.SelectionFont ?? rtbContent.Font;
            var finalStyle = set ? (current.Style | style) : (current.Style & ~style);
            rtbContent.SelectionFont = new Font(current.FontFamily, current.Size, finalStyle);
            rtbContent.Select(selStart, selLen);
        }

        private void rtbContent_SelectionChanged(object sender, EventArgs e)
        {
            var f = rtbContent.SelectionFont ?? rtbContent.Font;
            btnBold.Checked = f.Bold;
            btnItalic.Checked = f.Italic;
        }
    }
}