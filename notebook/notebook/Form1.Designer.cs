namespace notebook
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.lstNotes = new System.Windows.Forms.ListBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cmbTheme = new System.Windows.Forms.ComboBox();
            this.btnSaveAll = new System.Windows.Forms.Button();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnBold = new System.Windows.Forms.ToolStripButton();
            this.btnItalic = new System.Windows.Forms.ToolStripButton();
            this.cmbFonts = new System.Windows.Forms.ToolStripComboBox();
            this.cmbFontSize = new System.Windows.Forms.ToolStripComboBox();
            this.btnApplyFont = new System.Windows.Forms.ToolStripButton();
            this.rtbContent = new System.Windows.Forms.RichTextBox();
            this.groupTodos = new System.Windows.Forms.GroupBox();
            this.lvTodos = new System.Windows.Forms.ListView();
            this.txtTodo = new System.Windows.Forms.TextBox();
            this.btnAddTodo = new System.Windows.Forms.Button();
            this.btnRemoveTodo = new System.Windows.Forms.Button();
            this.btnSaveNote = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.groupTodos.SuspendLayout();
            this.SuspendLayout();

            // splitContainer
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // Panel1
            this.splitContainer.Panel1.Controls.Add(this.lstNotes);
            this.splitContainer.Panel1.Controls.Add(this.btnNew);
            this.splitContainer.Panel1.Controls.Add(this.btnDelete);
            this.splitContainer.Panel1.Controls.Add(this.cmbTheme);
            this.splitContainer.Panel1.Controls.Add(this.btnSaveAll);
            // Panel2
            this.splitContainer.Panel2.Controls.Add(this.txtTitle);
            this.splitContainer.Panel2.Controls.Add(this.toolStrip);
            this.splitContainer.Panel2.Controls.Add(this.rtbContent);
            this.splitContainer.Panel2.Controls.Add(this.groupTodos);
            this.splitContainer.Panel2.Controls.Add(this.btnSaveNote);
            this.splitContainer.Size = new System.Drawing.Size(1000, 600);
            this.splitContainer.SplitterDistance = 280;
            this.splitContainer.TabIndex = 0;

            // lstNotes
            this.lstNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lstNotes.FormattingEnabled = true;
            this.lstNotes.ItemHeight = 15;
            this.lstNotes.Location = new System.Drawing.Point(12, 52);
            this.lstNotes.Name = "lstNotes";
            this.lstNotes.Size = new System.Drawing.Size(256, 484);
            this.lstNotes.TabIndex = 0;
            this.lstNotes.SelectedIndexChanged += new System.EventHandler(this.lstNotes_SelectedIndexChanged);

            // btnNew
            this.btnNew.Location = new System.Drawing.Point(12, 12);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 28);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "Yeni";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);

            // btnDelete
            this.btnDelete.Location = new System.Drawing.Point(93, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 28);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // cmbTheme
            this.cmbTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTheme.FormattingEnabled = true;
            this.cmbTheme.Location = new System.Drawing.Point(12, 540);
            this.cmbTheme.Name = "cmbTheme";
            this.cmbTheme.Size = new System.Drawing.Size(180, 23);
            this.cmbTheme.TabIndex = 4;
            this.cmbTheme.SelectedIndexChanged += new System.EventHandler(this.cmbTheme_SelectedIndexChanged);

            // btnSaveAll
            this.btnSaveAll.Location = new System.Drawing.Point(198, 537);
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(70, 28);
            this.btnSaveAll.TabIndex = 5;
            this.btnSaveAll.Text = "Kaydet";
            this.btnSaveAll.UseVisualStyleBackColor = true;
            this.btnSaveAll.Click += new System.EventHandler(this.btnSaveAll_Click);

            // txtTitle
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTitle.Location = new System.Drawing.Point(12, 12);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.PlaceholderText = "Başlık";
            this.txtTitle.Size = new System.Drawing.Size(684, 29);
            this.txtTitle.TabIndex = 0;

            // toolStrip
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBold,
            this.btnItalic,
            this.cmbFonts,
            this.cmbFontSize,
            this.btnApplyFont});
            this.toolStrip.Location = new System.Drawing.Point(12, 45);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(760, 27);
            this.toolStrip.TabIndex = 1;

            // btnBold
            this.btnBold.CheckOnClick = true;
            this.btnBold.Text = "B";
            this.btnBold.Click += new System.EventHandler(this.btnBold_Click);

            // btnItalic
            this.btnItalic.CheckOnClick = true;
            this.btnItalic.Text = "I";
            this.btnItalic.Click += new System.EventHandler(this.btnItalic_Click);

            // cmbFonts
            this.cmbFonts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFonts.AutoSize = false;
            this.cmbFonts.Width = 200;

            // cmbFontSize
            this.cmbFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFontSize.AutoSize = false;
            this.cmbFontSize.Width = 75;

            // btnApplyFont
            this.btnApplyFont.Text = "Uygula";
            this.btnApplyFont.Click += new System.EventHandler(this.btnApplyFont_Click);

            // rtbContent
            this.rtbContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbContent.Location = new System.Drawing.Point(12, 75);
            this.rtbContent.Name = "rtbContent";
            this.rtbContent.Size = new System.Drawing.Size(760, 330);
            this.rtbContent.TabIndex = 2;
            this.rtbContent.Text = "";
            this.rtbContent.SelectionChanged += new System.EventHandler(this.rtbContent_SelectionChanged);

            // groupTodos
            this.groupTodos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.groupTodos.Controls.Add(this.lvTodos);
            this.groupTodos.Controls.Add(this.txtTodo);
            this.groupTodos.Controls.Add(this.btnAddTodo);
            this.groupTodos.Controls.Add(this.btnRemoveTodo);
            this.groupTodos.Location = new System.Drawing.Point(12, 420);
            this.groupTodos.Name = "groupTodos";
            this.groupTodos.Size = new System.Drawing.Size(760, 130);
            this.groupTodos.TabIndex = 3;
            this.groupTodos.TabStop = false;
            this.groupTodos.Text = "Yapılacaklar";

            // lvTodos
            this.lvTodos.CheckBoxes = true;
            this.lvTodos.Location = new System.Drawing.Point(6, 22);
            this.lvTodos.Name = "lvTodos";
            this.lvTodos.Size = new System.Drawing.Size(548, 98);
            this.lvTodos.TabIndex = 0;
            this.lvTodos.UseCompatibleStateImageBehavior = false;
            this.lvTodos.View = System.Windows.Forms.View.List;
            this.lvTodos.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvTodos_ItemChecked);

            // txtTodo
            this.txtTodo.Location = new System.Drawing.Point(560, 22);
            this.txtTodo.Name = "txtTodo";
            this.txtTodo.PlaceholderText = "Yeni görev";
            this.txtTodo.Size = new System.Drawing.Size(194, 23);
            this.txtTodo.TabIndex = 1;

            // btnAddTodo
            this.btnAddTodo.Location = new System.Drawing.Point(560, 52);
            this.btnAddTodo.Name = "btnAddTodo";
            this.btnAddTodo.Size = new System.Drawing.Size(94, 28);
            this.btnAddTodo.TabIndex = 2;
            this.btnAddTodo.Text = "Ekle";
            this.btnAddTodo.UseVisualStyleBackColor = true;
            this.btnAddTodo.Click += new System.EventHandler(this.btnAddTodo_Click);

            // btnRemoveTodo
            this.btnRemoveTodo.Location = new System.Drawing.Point(660, 52);
            this.btnRemoveTodo.Name = "btnRemoveTodo";
            this.btnRemoveTodo.Size = new System.Drawing.Size(94, 28);
            this.btnRemoveTodo.TabIndex = 3;
            this.btnRemoveTodo.Text = "Sil (seçili)";
            this.btnRemoveTodo.UseVisualStyleBackColor = true;
            this.btnRemoveTodo.Click += new System.EventHandler(this.btnRemoveTodo_Click);

            // btnSaveNote
            this.btnSaveNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveNote.Location = new System.Drawing.Point(677, 12);
            this.btnSaveNote.Name = "btnSaveNote";
            this.btnSaveNote.Size = new System.Drawing.Size(95, 29);
            this.btnSaveNote.TabIndex = 4;
            this.btnSaveNote.Text = "Notu Kaydet";
            this.btnSaveNote.UseVisualStyleBackColor = true;
            this.btnSaveNote.Click += new System.EventHandler(this.btnSaveNote_Click);

            // Form1
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.splitContainer);
            this.Name = "Form1";
            this.Text = "Not Defteri";
            this.Load += new System.EventHandler(this.Form1_Load);

            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.groupTodos.ResumeLayout(false);
            this.groupTodos.PerformLayout();
            this.ResumeLayout(false);
        }

        private void ResumeLayout(bool v)
        {
            throw new NotImplementedException();
        }

        private void SuspendLayout()
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ListBox lstNotes;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cmbTheme;
        private System.Windows.Forms.Button btnSaveAll;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnBold;
        private System.Windows.Forms.ToolStripButton btnItalic;
        private System.Windows.Forms.ToolStripComboBox cmbFonts;
        private System.Windows.Forms.ToolStripComboBox cmbFontSize;
        private System.Windows.Forms.ToolStripButton btnApplyFont;
        private System.Windows.Forms.RichTextBox rtbContent;
        private System.Windows.Forms.GroupBox groupTodos;
        private System.Windows.Forms.ListView lvTodos;
        private System.Windows.Forms.TextBox txtTodo;
        private System.Windows.Forms.Button btnAddTodo;
        private System.Windows.Forms.Button btnRemoveTodo;
        private System.Windows.Forms.Button btnSaveNote;
        private EventHandler Form1_Load;

        public EventHandler btnNew_Click { get; private set; }
        public EventHandler lstNotes_SelectedIndexChanged { get; private set; }
        public EventHandler btnDelete_Click { get; private set; }
        public EventHandler cmbTheme_SelectedIndexChanged { get; private set; }
        public EventHandler btnSaveAll_Click { get; private set; }
        public EventHandler btnBold_Click { get; private set; }
        public EventHandler btnItalic_Click { get; private set; }
        public EventHandler btnApplyFont_Click { get; private set; }
        public EventHandler rtbContent_SelectionChanged { get; private set; }
        public ItemCheckedEventHandler lvTodos_ItemChecked { get; private set; }
        public EventHandler btnAddTodo_Click { get; private set; }
        public EventHandler btnSaveNote_Click { get; private set; }
        public EventHandler btnRemoveTodo_Click { get; private set; }
        public Size ClientSize { get; private set; }
        public string Name { get; private set; }
        public string Text { get; private set; }
        public EventHandler Load { get; private set; }
        public System.Windows.Forms.Control.ControlCollection Controls
        {
            get { return ((System.Windows.Forms.Form)this).Controls; }
        }

        public static implicit operator Form(Form1 v)
        {
            return v ;
        }
    }
}
