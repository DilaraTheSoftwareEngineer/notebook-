using System;
using System.Linq;
using System.Windows.Forms;

namespace notebook
{
    public partial class NoteEditorForm : Form
    {
        private Not editingNote;

        public NoteEditorForm(Not note)
        {
            InitializeComponent();
            editingNote = note ?? new Not();
            // note type combo
            cmbNoteType.Items.AddRange(Enum.GetNames(typeof(NoteType)));
            cmbNoteType.SelectedItem = editingNote.Type.ToString();

            txtTitle.Text = editingNote.Title ?? string.Empty;

            // yükle içerik veya görevler
            if (editingNote.Type == NoteType.Todo)
            {
                ShowTodoEditor();
                PopulateTasks();
            }
            else
            {
                ShowTextEditor();
                try { rtbEdit.Rtf = editingNote.ContentRtf ?? string.Empty; }
                catch { rtbEdit.Text = editingNote.ContentRtf ?? string.Empty; }
            }
        }

        private void cmbNoteType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Enum.TryParse<NoteType>(cmbNoteType.SelectedItem?.ToString(), out var t))
            {
                editingNote.Type = t;
                if (t == NoteType.Todo) ShowTodoEditor(); else ShowTextEditor();
            }
        }

        private void ShowTodoEditor()
        {
            pnlTodoEditor.Visible = true;
            rtbEdit.Visible = false;
        }

        private void ShowTextEditor()
        {
            pnlTodoEditor.Visible = false;
            rtbEdit.Visible = true;
        }

        private void PopulateTasks()
        {
            chkListTasks.Items.Clear();
            foreach (var task in editingNote.Tasks)
            {
                chkListTasks.Items.Add(task.Text, task.IsDone);
            }
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            var txt = txtNewTask.Text.Trim();
            if (string.IsNullOrEmpty(txt)) return;
            chkListTasks.Items.Add(txt, false);
            txtNewTask.Clear();
        }

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            var toRemove = chkListTasks.CheckedItems.Cast<object>().ToList();
            // remove checked items
            for (int i = chkListTasks.Items.Count - 1; i >= 0; i--)
            {
                if (chkListTasks.GetItemChecked(i)) chkListTasks.Items.RemoveAt(i);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // sync back to model
            editingNote.Title = txtTitle.Text.Trim();
            editingNote.Type = Enum.TryParse<NoteType>(cmbNoteType.SelectedItem?.ToString(), out var t) ? t : NoteType.Text;

            if (editingNote.Type == NoteType.Todo)
            {
                editingNote.Tasks = chkListTasks.Items.Cast<object>()
                    .Select((o, i) => new TodoItem { Text = o.ToString() ?? string.Empty, IsDone = chkListTasks.GetItemChecked(i) })
                    .ToList();
                editingNote.ContentRtf = string.Empty;
            }
            else
            {
                editingNote.ContentRtf = rtbEdit.Rtf;
                editingNote.Tasks = new System.Collections.Generic.List<TodoItem>();
            }

            editingNote.ModifiedUtc = DateTime.UtcNow;

            DialogResult = DialogResult.OK;
            Close();
        }

        public Not GetEditedNote() => editingNote;
    }
}