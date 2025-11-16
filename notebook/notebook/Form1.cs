using notebook;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public partial class Form1 : Form
{
    private FlowLayoutPanel flowLayoutPanelNotes;

    public ComboBox cmbTemalar { get; private set; }

    public Form1()
    {
        InitializeCustomComponents();
    }

    // Form ilk yüklendiðinde çalýþýr
    private void Form1_Load(object sender, EventArgs e)
    {
        // 1. Tema seçim kutusunu doldur
        cmbTemalar.Items.AddRange(Enum.GetNames(enumType: typeof(SoftTheme)));
        cmbTemalar.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbTemalar.SelectedIndex = 0; // Varsayýlan tema

        // 2. Kayýtlý notlarý dosyadan yükle
        GlobalData.LoadNotes();

        // 3. Notlarý ekranda göster
        RefreshNoteDisplay();

        // 4. Temayý forma uygula (Not panelleri oluþtuktan sonra)
        ThemeManager.ApplyTheme(this);
    }

    // Tema ComboBox'ýnda seçim deðiþtiðinde
    private void cmbTemalar_SelectedIndexChanged(object sender, EventArgs e)
    {
        string themeName = cmbTemalar.SelectedItem.ToString();
        SoftTheme theme = (SoftTheme)Enum.Parse(typeof(SoftTheme), themeName);
        ThemeManager.SetTheme(theme);

        // Temayý bu forma uygula
        ThemeManager.ApplyTheme(this);

        // Not panellerinin de renginin deðiþmesi için listeyi yenile
        RefreshNoteDisplay();
    }

    // "Yeni Not" butonuna týklandýðýnda
    private void btnYeniNot_Click(object sender, EventArgs e)
    {
        // Yeni, boþ bir editör formu aç
        NoteEditorForm editor = new NoteEditorForm();
        var result = editor.ShowDialog();

        // Editör kapandýysa (Kaydet veya Sil'e basýldýysa) listeyi yenile
        if (result == DialogResult.OK)
        {
            RefreshNoteDisplay();
        }
    }

    // NOTLARI GÖSTEREN ANA FONKSÝYON
    public void RefreshNoteDisplay()
    {
        flowLayoutPanelNotes.Controls.Clear(); // Paneli temizle

        foreach (var note in GlobalData.AllNotes)
        {
            // Her not için bir panel oluþtur
            Panel notePanel = new Panel
            {
                Width = 200,
                Height = 100,
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle,
                Tag = note.ID // EN ÖNEMLÝ KISIM: Panele notun ID'sini etiketliyoruz
            };

            // Not Baþlýðý
            Label lblTitle = new Label
            {
                Text = note.Title,
                Font = new Font(this.Font, FontStyle.Bold),
                Dock = DockStyle.Top,
                Tag = note.ID // Týklamayý algýlamak için
            };

            // Not Önizlemesi
            Label lblPreview = new Label
            {
                Dock = DockStyle.Fill,
                Tag = note.ID // Týklamayý algýlamak için
            };

            if (note.Type == NoteType.Text)
            {
                lblPreview.Text = GetPlainTextFromRtf(note.ContentRtf); // RTF'i düz metne çevir
                if (lblPreview.Text.Length > 70)
                    lblPreview.Text = lblPreview.Text.Substring(0, 70) + "...";
            }
            else
            {
                lblPreview.Text = $"{note.Tasks.Count} görev içeriyor.";
            }

            // Týklama olaylarýný ata
            notePanel.Click += NotePanel_Click;
            lblTitle.Click += NotePanel_Click;
            lblPreview.Click += NotePanel_Click;

            // Labellarý panele ekle
            notePanel.Controls.Add(lblPreview);
            notePanel.Controls.Add(lblTitle);

            // Renkleri ayarla (Mevcut temaya göre)
            notePanel.BackColor = ThemeManager.ControlBackground;
            lblTitle.ForeColor = ThemeManager.TextColor;
            lblTitle.BackColor = ThemeManager.ControlBackground;
            lblPreview.ForeColor = ThemeManager.TextColor;
            lblPreview.BackColor = ThemeManager.ControlBackground;

            // Paneli ana forma ekle
            flowLayoutPanelNotes.Controls.Add(notePanel);
        }
    }

    // Bir not paneline týklandýðýnda
    private void NotePanel_Click(object sender, EventArgs e)
    {
        string noteId = ((Control)sender).Tag.ToString();

        // Editör formunu, seçilen notun ID'si ile aç
        NoteEditorForm editor = new NoteEditorForm(noteId);
        var result = editor.ShowDialog();

        // Editör kapandýysa (Kaydet veya Sil'e basýldýysa) listeyi yenile
        if (result == DialogResult.OK)
        {
            RefreshNoteDisplay();
        }
    }

    // RTF'i düz metne çeviren yardýmcý
    private string GetPlainTextFromRtf(string rtfContent)
    {
        if (string.IsNullOrEmpty(rtfContent)) return "";
        using (RichTextBox rtfBox = new RichTextBox())
        {
            try { rtfBox.Rtf = rtfContent; return rtfBox.Text; }
            catch { return ""; }
        }
    }

    // Ekleyin (varsa tekrarlamayýn)
    // private void lstNotes_SelectedIndexChanged(object sender, EventArgs e) { /* çaðýrýlmasý gereken fonksiyonu buraya koyun veya LoadNote(selectedNote) çaðrýn */ }
    //private void btnNew_Click(object sender, EventArgs e) { btnNew_Click(sender, e); } // eðer gerçek implementasyon farklýysa düzeltin
    //private void btnDelete_Click(object sender, EventArgs e) { btnDelete_Click(sender, e); }
   ///private void btnSaveAll_Click(object sender, EventArgs e) { btnSaveAll_Click(sender, e); }
   // private void btnSaveNote_Click(object sender, EventArgs e) { btnSaveNote_Click(sender, e); }
    //private void btnAddTodo_Click(object sender, EventArgs e) { btnAddTodo_Click(sender, e); }
  //  private void btnRemoveTodo_Click(object sender, EventArgs e) { btnRemoveTodo_Click(sender, e); }
    //private void lvTodos_ItemChecked(object sender, ItemCheckedEventArgs e) { lvTodos_ItemChecked(sender, e); }
   // private void btnBold_Click(object sender, EventArgs e) { btnBold_Click(sender, e); }
   // private void btnItalic_Click(object sender, EventArgs e) { btnItalic_Click(sender, e); }
   // private void btnApplyFont_Click(object sender, EventArgs e) { btnApplyFont_Click(sender, e); }
   // private void rtbContent_SelectionChanged(object sender, EventArgs e) { rtbContent_SelectionChanged(sender, e); }

    private void InitializeCustomComponents()
    {
        cmbTemalar = new ComboBox
        {
            Dock = DockStyle.Top,
            DropDownStyle = ComboBoxStyle.DropDownList
        };
        cmbTemalar.SelectedIndexChanged += cmbTemalar_SelectedIndexChanged;
        this.Controls.Add(cmbTemalar);

        flowLayoutPanelNotes = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            AutoScroll = true
        };
        this.Controls.Add(flowLayoutPanelNotes);
    }
    private void btnSaveAll_Click(object sender, EventArgs e)
    {
        // Tüm notlarý kaydetme kodu
    }
}