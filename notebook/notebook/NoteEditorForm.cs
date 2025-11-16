using notebook;
using System;
using System.Drawing;
using System.Linq; // Bu satırı ekleyin
using System.Windows.Forms;

public partial class NoteEditorForm : Form
{
    private Not currentNote; // Tip düzeltildi: NoteEditorForm -> Not
    private bool isNewNote = false;
    private ComboBox cmbNoteType;
    private TextBox txtTitle; // txtTitle alanı eklendi
    private RichTextBox rtfContent;
    private CheckedListBox chkListTasks; // Görevler için CheckedListBox kontrolü
    private TextBox txtNewTask; // txtNewTask kontrolünü tanımlayın

    // Formun üst kısmına ekleyin:
    private Panel pnlTextEditor;
    private Panel pnlTodoEditor;
    private FontDialog fontDialog1 = new FontDialog(); // FontDialog burada tanımlandı

    // YENİ NOT için bu constructor çalışır
    public NoteEditorForm()
    {
        InitializeComponent();
        isNewNote = true;
        currentNote = new Not(); // Boş bir not oluştur
    }

    private void InitializeComponent()
    {
        cmbNoteType = new ComboBox();
        txtTitle = new TextBox(); // txtTitle kontrolünü oluşturun
        rtfContent = new RichTextBox(); // RichTextBox ekleniyor
        chkListTasks = new CheckedListBox();
        txtNewTask = new TextBox(); // txtNewTask kontrolünü oluşturun

        // Yeni panelleri oluşturun
        pnlTextEditor = new Panel();
        pnlTodoEditor = new Panel();

        // pnlTextEditor ayarları
        pnlTextEditor.Location = new Point(10, 40);
        pnlTextEditor.Size = new Size(400, 200);
        pnlTextEditor.Controls.Add(rtfContent);

        // pnlTodoEditor ayarları
        pnlTodoEditor.Location = new Point(10, 250);
        pnlTodoEditor.Size = new Size(400, 150);
        pnlTodoEditor.Controls.Add(chkListTasks);

        txtTitle.Location = new Point(10, 10); // Uygun bir konum belirleyin
        txtTitle.Width = 200; // Genişlik ayarlayın

        // txtNewTask konum ve boyut ayarları
        txtNewTask.Location = new Point(10, 410);
        txtNewTask.Width = 200;
        this.Controls.Add(txtNewTask); // txtNewTask'ı forma ekleyin

        // Kontrolleri forma ekleyin
        this.Controls.Add(cmbNoteType);
        this.Controls.Add(txtTitle); // txtTitle'ı forma ekleyin
        this.Controls.Add(pnlTextEditor);
        this.Controls.Add(pnlTodoEditor); // Forma ekleyin

        // Diğer gerekli ayarlar...
        throw new NotImplementedException();
    }

    // MEVCUT NOT için bu constructor çalışır
    public NoteEditorForm(string noteId)
    {
        InitializeComponent();
        isNewNote = false;

        // ID'ye göre notu GlobalData listesinde bul
        currentNote = GlobalData.AllNotes.FirstOrDefault(n => n.ID == noteId);

        if (currentNote == null)
        {
            MessageBox.Show("Not bulunamadı!");
            this.Close();
        }
    }

    // Editör formu yüklendiğinde
    private void NoteEditorForm_Load(object sender, EventArgs e)
    {
        // 1. Temayı buforma da uygula
        ThemeManager.ApplyTheme(this);

        // 2. Not Tipini ComboBox'a doldur
        cmbNoteType.Items.AddRange(Enum.GetNames(typeof(NoteType)));
        cmbNoteType.DropDownStyle = ComboBoxStyle.DropDownList;

        // 3. Mevcut notun bilgilerini kontrollere yükle
        LoadNoteData();

        // 4. Doğru paneli göster (Text veya ToDo)
        UpdateEditorPanelVisibility();
    }

    // Notun verilerini formdaki kontrollere doldurur
    private void LoadNoteData()
    {
        txtTitle.Text = currentNote.Title;
        cmbNoteType.SelectedItem = currentNote.Type.ToString();

        // Metin notuysa RichTextBox'ı doldur
        if (currentNote.Type == NoteType.Text)
        {
            rtfContent.Rtf = currentNote.ContentRtf;
        }
        // Görev notuysa CheckedListBox'ı doldur
        else
        {
            chkListTasks.Items.Clear();
            foreach (var task in currentNote.Tasks)
            {
                chkListTasks.Items.Add(task.Text, task.IsDone);
            }
        }
    }

    // Not tipi (Text/ToDo) değiştiğinde panelleri gizle/göster
    private void cmbNoteType_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Not türü değiştiğinde yapılacak işlemler buraya eklenebilir.
        // Örneğin, metin notu ve yapılacaklar listesi arasında panel görünürlüğünü değiştirme:
        if (cmbNoteType.SelectedItem != null && cmbNoteType.SelectedItem.ToString() == "Yapılacaklar")
        {
            pnlTodoEditor.Visible = true;
            rtfContent.Visible = false;
        }
        else
        {
            pnlTodoEditor.Visible = false;
            rtfContent.Visible = true;
        }
    }

    private void UpdateEditorPanelVisibility()
    {
        if (cmbNoteType.SelectedItem.ToString() == "Text")
        {
            pnlTextEditor.Visible = true;
            pnlTodoEditor.Visible = false;
        }
        else
        {
            pnlTextEditor.Visible = false;
            pnlTodoEditor.Visible = true;
        }
    }

    // === METİN FORMATLAMA BUTONLARI ===

    private void btnBold_Click(object sender, EventArgs e)
    {
        var currentFont = rtfContent.SelectionFont;
        var newStyle = currentFont.Style ^ FontStyle.Bold;
        rtfContent.SelectionFont = new Font(currentFont, newStyle);
    }

    private void btnItalic_Click(object sender, EventArgs e)
    {
        var currentFont = rtfContent.SelectionFont;
        var newStyle = currentFont.Style ^ FontStyle.Italic;
        rtfContent.SelectionFont = new Font(currentFont, newStyle);
    }

    private void btnFont_Click(object sender, EventArgs e)
    {
        if (fontDialog1.ShowDialog() == DialogResult.OK)
        {
            rtfContent.SelectionFont = fontDialog1.Font;
        }
    }

    // === GÖREV LİSTESİ BUTONLARI ===

    private void btnAddTask_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(txtNewTask.Text))
        {
            chkListTasks.Items.Add(txtNewTask.Text, false);
            txtNewTask.Clear();
        }
    }

    // === KAYDET / İPTAL / SİL ===

    private void btnSave_Click(object sender, EventArgs e)
    {
        // 1. Verileri formdan 'currentNote' nesnesine geri topla
        currentNote.Title = txtTitle.Text;
        currentNote.Type = (NoteType)Enum.Parse(typeof(NoteType), cmbNoteType.SelectedItem.ToString());

        if (currentNote.Type == NoteType.Text)
        {
            currentNote.ContentRtf = rtfContent.Rtf; // Stilleri korumak için RTF olarak kaydet
        }
        else
        {
            // CheckedListBox'taki görevleri 'currentNote.Tasks' listesine kaydet
            currentNote.Tasks.Clear();
            for (int i = 0; i < chkListTasks.Items.Count; i++)
            {
                currentNote.Tasks.Add(new TodoItem
                {
                    Text = chkListTasks.Items[i].ToString(),
                    IsDone = chkListTasks.GetItemChecked(i)
                });
            }
        }

        // 2. Eğer bu yeni bir notsa, ana listeye ekle
        if (isNewNote)
        {
            GlobalData.AllNotes.Add(currentNote);
        }

        // 3. Tüm notları dosyaya kaydet
        GlobalData.SaveNotes();

        // 4. Ana formun listeyi yenilemesi için OK sonucuyla kapat
        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("Bu notu silmek istediğinizden emin misiniz?", "Notu Sil", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            // Eğer yeni not değilse (zaten kayıtlıysa) listeden sil
            if (!isNewNote)
            {
                GlobalData.AllNotes.Remove(currentNote);
                GlobalData.SaveNotes();
            }

            // Ana formun listeyi yenilemesi için OK sonucuyla kapat
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        // Hiçbir şey kaydetme ve ana forma "iptal" bilgisiyle dön
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }
}