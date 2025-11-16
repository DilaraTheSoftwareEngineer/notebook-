notebook\NoteEditorForm.Designer.cs
namespace notebook
{
    partial class NoteEditorForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.RichTextBox rtbEdit;
        private System.Windows.Forms.ComboBox cmbNoteType;
        private System.Windows.Forms.Panel pnlTodoEditor;
        private System.Windows.Forms.CheckedListBox chkListTasks;
        private System.Windows.Forms.TextBox txtNewTask;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Button btnRemoveTask;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.rtbEdit = new System.Windows.Forms.RichTextBox();
            this.cmbNoteType = new System.Windows.Forms.ComboBox();
            this.pnlTodoEditor = new System.Windows.Forms.Panel();
            this.chkListTasks = new System.Windows.Forms.CheckedListBox();
            this.txtNewTask = new System.Windows.Forms.TextBox();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.btnRemoveTask = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtTitle = new System.Windows.Forms.TextBox();

            this.SuspendLayout();
            // txtTitle
            this.txtTitle.Location = new System.Drawing.Point(12, 12);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(560, 23);
            this.txtTitle.PlaceholderText = "Baþlýk";
            // cmbNoteType
            this.cmbNoteType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNoteType.Location = new System.Drawing.Point(580, 12);
            this.cmbNoteType.Name = "cmbNoteType";
            this.cmbNoteType.Size = new System.Drawing.Size(120, 23);
            this.cmbNoteType.SelectedIndexChanged += new System.EventHandler(this.cmbNoteType_SelectedIndexChanged);
            // rtbEdit
            this.rtbEdit.Location = new System.Drawing.Point(12, 44);
            this.rtbEdit.Name = "rtbEdit";
            this.rtbEdit.Size = new System.Drawing.Size(560, 360);
            this.rtbEdit.TabIndex = 0;
            this.rtbEdit.Text = "";
            // pnlTodoEditor
            this.pnlTodoEditor.Location = new System.Drawing.Point(12, 44);
            this.pnlTodoEditor.Name = "pnlTodoEditor";
            this.pnlTodoEditor.Size = new System.Drawing.Size(560, 360);
            // chkListTasks
            this.chkListTasks.Location = new System.Drawing.Point(0, 0);
            this.chkListTasks.Name = "chkListTasks";
            this.chkListTasks.Size = new System.Drawing.Size(360, 340);
            this.chkListTasks.CheckOnClick = true;
            // txtNewTask
            this.txtNewTask.Location = new System.Drawing.Point(366, 0);
            this.txtNewTask.Name = "txtNewTask";
            this.txtNewTask.Size = new System.Drawing.Size(180, 23);
            this.txtNewTask.PlaceholderText = "Yeni görev";
            // btnAddTask
            this.btnAddTask.Location = new System.Drawing.Point(366, 28);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(85, 26);
            this.btnAddTask.Text = "Ekle";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // btnRemoveTask
            this.btnRemoveTask.Location = new System.Drawing.Point(461, 28);
            this.btnRemoveTask.Name = "btnRemoveTask";
            this.btnRemoveTask.Size = new System.Drawing.Size(85, 26);
            this.btnRemoveTask.Text = "Sil (seçili)";
            this.btnRemoveTask.UseVisualStyleBackColor = true;
            this.btnRemoveTask.Click += new System.EventHandler(this.btnRemoveTask_Click);
            // add controls to pnlTodoEditor
            this.pnlTodoEditor.Controls.Add(this.chkListTasks);
            this.pnlTodoEditor.Controls.Add(this.txtNewTask);
            this.pnlTodoEditor.Controls.Add(this.btnAddTask);
            this.pnlTodoEditor.Controls.Add(this.btnRemoveTask);
            // btnSave
            this.btnSave.Location = new System.Drawing.Point(497, 410);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // NoteEditorForm
            this.ClientSize = new System.Drawing.Size(712, 450);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.cmbNoteType);
            this.Controls.Add(this.rtbEdit);
            this.Controls.Add(this.pnlTodoEditor);
            this.Controls.Add(this.btnSave);
            this.Name = "NoteEditorForm";
            this.Text = "Not Düzenle";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
    }
}