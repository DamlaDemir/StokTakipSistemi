namespace stokTakip.Ekranlar
{
    partial class PersonelIslemleriEkrani
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonelIslemleriEkrani));
            this.tbpPersonelDemirbasListesi = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPersonelDepartman = new System.Windows.Forms.TextBox();
            this.cbPersonelDemirbasListesiOdaNumarasi = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dgvPersonelDemirbasListesi = new System.Windows.Forms.DataGridView();
            this.btnPersonelDemirbasListele = new System.Windows.Forms.Button();
            this.cbDemirbasListelenecekPersonel = new System.Windows.Forms.ComboBox();
            this.lblDemirbasListelenecekPersonel = new System.Windows.Forms.Label();
            this.tabPersonel = new System.Windows.Forms.TabControl();
            this.tbpPersonelEkle = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbPersonelYetki = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.picboxFotograf = new System.Windows.Forms.PictureBox();
            this.btnFotografEkle = new System.Windows.Forms.Button();
            this.personelEkleFotograf = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbPersonelEkleDepartman = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbPersonelEkleFakulte = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPersonelEkleSoyadi = new System.Windows.Forms.TextBox();
            this.txtPersonelEkleAdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPersonelEkle = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnOturumdakiKullanici = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tbpPersonelDemirbasListesi.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonelDemirbasListesi)).BeginInit();
            this.tabPersonel.SuspendLayout();
            this.tbpPersonelEkle.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxFotograf)).BeginInit();
            this.SuspendLayout();
            // 
            // tbpPersonelDemirbasListesi
            // 
            this.tbpPersonelDemirbasListesi.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbpPersonelDemirbasListesi.Controls.Add(this.panel1);
            this.tbpPersonelDemirbasListesi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbpPersonelDemirbasListesi.ImageIndex = 0;
            this.tbpPersonelDemirbasListesi.Location = new System.Drawing.Point(4, 64);
            this.tbpPersonelDemirbasListesi.Name = "tbpPersonelDemirbasListesi";
            this.tbpPersonelDemirbasListesi.Padding = new System.Windows.Forms.Padding(3);
            this.tbpPersonelDemirbasListesi.Size = new System.Drawing.Size(1273, 668);
            this.tbpPersonelDemirbasListesi.TabIndex = 0;
            this.tbpPersonelDemirbasListesi.Text = "Personel Üzerindeki Demirbaş Listesi";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtPersonelDepartman);
            this.panel1.Controls.Add(this.cbPersonelDemirbasListesiOdaNumarasi);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.dgvPersonelDemirbasListesi);
            this.panel1.Controls.Add(this.btnPersonelDemirbasListele);
            this.panel1.Controls.Add(this.cbDemirbasListelenecekPersonel);
            this.panel1.Controls.Add(this.lblDemirbasListelenecekPersonel);
            this.panel1.Location = new System.Drawing.Point(27, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1202, 584);
            this.panel1.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(426, 57);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(186, 25);
            this.label9.TabIndex = 91;
            this.label9.Text = "Personel Departmanı:";
            // 
            // txtPersonelDepartman
            // 
            this.txtPersonelDepartman.Enabled = false;
            this.txtPersonelDepartman.Location = new System.Drawing.Point(678, 57);
            this.txtPersonelDepartman.Name = "txtPersonelDepartman";
            this.txtPersonelDepartman.Size = new System.Drawing.Size(281, 28);
            this.txtPersonelDepartman.TabIndex = 90;
            // 
            // cbPersonelDemirbasListesiOdaNumarasi
            // 
            this.cbPersonelDemirbasListesiOdaNumarasi.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbPersonelDemirbasListesiOdaNumarasi.FormattingEnabled = true;
            this.cbPersonelDemirbasListesiOdaNumarasi.Location = new System.Drawing.Point(678, 9);
            this.cbPersonelDemirbasListesiOdaNumarasi.Margin = new System.Windows.Forms.Padding(4);
            this.cbPersonelDemirbasListesiOdaNumarasi.Name = "cbPersonelDemirbasListesiOdaNumarasi";
            this.cbPersonelDemirbasListesiOdaNumarasi.Size = new System.Drawing.Size(281, 30);
            this.cbPersonelDemirbasListesiOdaNumarasi.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.Location = new System.Drawing.Point(426, 14);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(244, 25);
            this.label12.TabIndex = 89;
            this.label12.Text = "Personel Üzerindeki Odalar:";
            // 
            // dgvPersonelDemirbasListesi
            // 
            this.dgvPersonelDemirbasListesi.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvPersonelDemirbasListesi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonelDemirbasListesi.Location = new System.Drawing.Point(52, 102);
            this.dgvPersonelDemirbasListesi.Name = "dgvPersonelDemirbasListesi";
            this.dgvPersonelDemirbasListesi.RowTemplate.Height = 24;
            this.dgvPersonelDemirbasListesi.Size = new System.Drawing.Size(1063, 424);
            this.dgvPersonelDemirbasListesi.TabIndex = 88;
            // 
            // btnPersonelDemirbasListele
            // 
            this.btnPersonelDemirbasListele.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPersonelDemirbasListele.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnPersonelDemirbasListele.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPersonelDemirbasListele.ImageKey = "cynfembujjrodkcxjgok.png";
            this.btnPersonelDemirbasListele.Location = new System.Drawing.Point(982, 5);
            this.btnPersonelDemirbasListele.Margin = new System.Windows.Forms.Padding(4);
            this.btnPersonelDemirbasListele.Name = "btnPersonelDemirbasListele";
            this.btnPersonelDemirbasListele.Size = new System.Drawing.Size(202, 34);
            this.btnPersonelDemirbasListele.TabIndex = 3;
            this.btnPersonelDemirbasListele.Text = "LİSTELE";
            this.btnPersonelDemirbasListele.UseVisualStyleBackColor = false;
            this.btnPersonelDemirbasListele.Click += new System.EventHandler(this.btnPersonelDemirbasListele_Click);
            // 
            // cbDemirbasListelenecekPersonel
            // 
            this.cbDemirbasListelenecekPersonel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbDemirbasListelenecekPersonel.FormattingEnabled = true;
            this.cbDemirbasListelenecekPersonel.Location = new System.Drawing.Point(129, 9);
            this.cbDemirbasListelenecekPersonel.Margin = new System.Windows.Forms.Padding(4);
            this.cbDemirbasListelenecekPersonel.Name = "cbDemirbasListelenecekPersonel";
            this.cbDemirbasListelenecekPersonel.Size = new System.Drawing.Size(269, 30);
            this.cbDemirbasListelenecekPersonel.TabIndex = 1;
            this.cbDemirbasListelenecekPersonel.SelectedIndexChanged += new System.EventHandler(this.cbDemirbasListelenecekPersonel_SelectedIndexChanged);
            // 
            // lblDemirbasListelenecekPersonel
            // 
            this.lblDemirbasListelenecekPersonel.AutoSize = true;
            this.lblDemirbasListelenecekPersonel.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDemirbasListelenecekPersonel.Location = new System.Drawing.Point(16, 12);
            this.lblDemirbasListelenecekPersonel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDemirbasListelenecekPersonel.Name = "lblDemirbasListelenecekPersonel";
            this.lblDemirbasListelenecekPersonel.Size = new System.Drawing.Size(87, 25);
            this.lblDemirbasListelenecekPersonel.TabIndex = 85;
            this.lblDemirbasListelenecekPersonel.Text = "Personel:";
            // 
            // tabPersonel
            // 
            this.tabPersonel.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabPersonel.Controls.Add(this.tbpPersonelEkle);
            this.tabPersonel.Controls.Add(this.tbpPersonelDemirbasListesi);
            this.tabPersonel.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabPersonel.ImageList = this.ımageList1;
            this.tabPersonel.ItemSize = new System.Drawing.Size(100, 60);
            this.tabPersonel.Location = new System.Drawing.Point(12, 57);
            this.tabPersonel.Name = "tabPersonel";
            this.tabPersonel.SelectedIndex = 0;
            this.tabPersonel.Size = new System.Drawing.Size(1281, 736);
            this.tabPersonel.TabIndex = 79;
            this.tabPersonel.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabPersonel_Selected);
            // 
            // tbpPersonelEkle
            // 
            this.tbpPersonelEkle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbpPersonelEkle.Controls.Add(this.panel2);
            this.tbpPersonelEkle.ImageIndex = 1;
            this.tbpPersonelEkle.Location = new System.Drawing.Point(4, 64);
            this.tbpPersonelEkle.Name = "tbpPersonelEkle";
            this.tbpPersonelEkle.Padding = new System.Windows.Forms.Padding(3);
            this.tbpPersonelEkle.Size = new System.Drawing.Size(1273, 668);
            this.tbpPersonelEkle.TabIndex = 1;
            this.tbpPersonelEkle.Text = "Personel Ekle";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cbPersonelYetki);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtSifre);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtKullaniciAdi);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.picboxFotograf);
            this.panel2.Controls.Add(this.btnFotografEkle);
            this.panel2.Controls.Add(this.personelEkleFotograf);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cbPersonelEkleDepartman);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cbPersonelEkleFakulte);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtPersonelEkleSoyadi);
            this.panel2.Controls.Add(this.txtPersonelEkleAdi);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnPersonelEkle);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(30, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1202, 584);
            this.panel2.TabIndex = 2;
            // 
            // cbPersonelYetki
            // 
            this.cbPersonelYetki.FormattingEnabled = true;
            this.cbPersonelYetki.Items.AddRange(new object[] {
            "Admin",
            "Normal"});
            this.cbPersonelYetki.Location = new System.Drawing.Point(224, 456);
            this.cbPersonelYetki.Name = "cbPersonelYetki";
            this.cbPersonelYetki.Size = new System.Drawing.Size(341, 28);
            this.cbPersonelYetki.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(54, 456);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 25);
            this.label8.TabIndex = 104;
            this.label8.Text = "Yetki:";
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(224, 397);
            this.txtSifre.MaxLength = 6;
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(341, 28);
            this.txtSifre.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(54, 398);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 25);
            this.label7.TabIndex = 102;
            this.label7.Text = "Şifre:";
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Location = new System.Drawing.Point(224, 344);
            this.txtKullaniciAdi.MaxLength = 20;
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(341, 28);
            this.txtKullaniciAdi.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(54, 345);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 25);
            this.label6.TabIndex = 100;
            this.label6.Text = "Kullanıcı Adı:";
            // 
            // picboxFotograf
            // 
            this.picboxFotograf.Location = new System.Drawing.Point(671, 33);
            this.picboxFotograf.Name = "picboxFotograf";
            this.picboxFotograf.Size = new System.Drawing.Size(409, 250);
            this.picboxFotograf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxFotograf.TabIndex = 99;
            this.picboxFotograf.TabStop = false;
            // 
            // btnFotografEkle
            // 
            this.btnFotografEkle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnFotografEkle.Font = new System.Drawing.Font("Comic Sans MS", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFotografEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFotografEkle.ImageKey = "cynfembujjrodkcxjgok.png";
            this.btnFotografEkle.Location = new System.Drawing.Point(591, 284);
            this.btnFotografEkle.Margin = new System.Windows.Forms.Padding(4);
            this.btnFotografEkle.Name = "btnFotografEkle";
            this.btnFotografEkle.Size = new System.Drawing.Size(39, 30);
            this.btnFotografEkle.TabIndex = 6;
            this.btnFotografEkle.Text = "...";
            this.btnFotografEkle.UseVisualStyleBackColor = false;
            this.btnFotografEkle.Click += new System.EventHandler(this.btnFotografEkle_Click);
            // 
            // personelEkleFotograf
            // 
            this.personelEkleFotograf.Enabled = false;
            this.personelEkleFotograf.Location = new System.Drawing.Point(224, 286);
            this.personelEkleFotograf.Name = "personelEkleFotograf";
            this.personelEkleFotograf.Size = new System.Drawing.Size(341, 28);
            this.personelEkleFotograf.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(54, 289);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 25);
            this.label5.TabIndex = 96;
            this.label5.Text = "Fotoğraf:";
            // 
            // cbPersonelEkleDepartman
            // 
            this.cbPersonelEkleDepartman.FormattingEnabled = true;
            this.cbPersonelEkleDepartman.Location = new System.Drawing.Point(224, 217);
            this.cbPersonelEkleDepartman.Name = "cbPersonelEkleDepartman";
            this.cbPersonelEkleDepartman.Size = new System.Drawing.Size(341, 28);
            this.cbPersonelEkleDepartman.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(54, 217);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 25);
            this.label4.TabIndex = 94;
            this.label4.Text = "Departman";
            // 
            // cbPersonelEkleFakulte
            // 
            this.cbPersonelEkleFakulte.FormattingEnabled = true;
            this.cbPersonelEkleFakulte.Location = new System.Drawing.Point(224, 149);
            this.cbPersonelEkleFakulte.Name = "cbPersonelEkleFakulte";
            this.cbPersonelEkleFakulte.Size = new System.Drawing.Size(341, 28);
            this.cbPersonelEkleFakulte.TabIndex = 3;
            this.cbPersonelEkleFakulte.SelectedIndexChanged += new System.EventHandler(this.cbPersonelEkleFakulte_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(54, 149);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 25);
            this.label3.TabIndex = 92;
            this.label3.Text = "Fakülte:";
            // 
            // txtPersonelEkleSoyadi
            // 
            this.txtPersonelEkleSoyadi.Location = new System.Drawing.Point(224, 91);
            this.txtPersonelEkleSoyadi.MaxLength = 25;
            this.txtPersonelEkleSoyadi.Name = "txtPersonelEkleSoyadi";
            this.txtPersonelEkleSoyadi.Size = new System.Drawing.Size(341, 28);
            this.txtPersonelEkleSoyadi.TabIndex = 2;
            this.txtPersonelEkleSoyadi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPersonelEkleSoyadi_KeyPress);
            // 
            // txtPersonelEkleAdi
            // 
            this.txtPersonelEkleAdi.Location = new System.Drawing.Point(224, 33);
            this.txtPersonelEkleAdi.MaxLength = 25;
            this.txtPersonelEkleAdi.Name = "txtPersonelEkleAdi";
            this.txtPersonelEkleAdi.Size = new System.Drawing.Size(341, 28);
            this.txtPersonelEkleAdi.TabIndex = 1;
            this.txtPersonelEkleAdi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPersonelEkleAdi_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(54, 92);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 25);
            this.label1.TabIndex = 89;
            this.label1.Text = "Personel Soyadi:";
            // 
            // btnPersonelEkle
            // 
            this.btnPersonelEkle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPersonelEkle.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnPersonelEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPersonelEkle.ImageKey = "cynfembujjrodkcxjgok.png";
            this.btnPersonelEkle.Location = new System.Drawing.Point(224, 509);
            this.btnPersonelEkle.Margin = new System.Windows.Forms.Padding(4);
            this.btnPersonelEkle.Name = "btnPersonelEkle";
            this.btnPersonelEkle.Size = new System.Drawing.Size(341, 34);
            this.btnPersonelEkle.TabIndex = 10;
            this.btnPersonelEkle.Text = "PERSONEL EKLE";
            this.btnPersonelEkle.UseVisualStyleBackColor = false;
            this.btnPersonelEkle.Click += new System.EventHandler(this.btnPersonelEkle_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(54, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 25);
            this.label2.TabIndex = 85;
            this.label2.Text = "Personel Adı:";
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "clipboard-list-flat.png");
            this.ımageList1.Images.SetKeyName(1, "add_user_group-512.png");
            // 
            // btnOturumdakiKullanici
            // 
            this.btnOturumdakiKullanici.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnOturumdakiKullanici.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOturumdakiKullanici.Location = new System.Drawing.Point(12, 12);
            this.btnOturumdakiKullanici.Name = "btnOturumdakiKullanici";
            this.btnOturumdakiKullanici.Size = new System.Drawing.Size(1281, 39);
            this.btnOturumdakiKullanici.TabIndex = 80;
            this.btnOturumdakiKullanici.Text = "Oturumdaki Kullanıcı:Damla Demir";
            this.btnOturumdakiKullanici.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOturumdakiKullanici.UseVisualStyleBackColor = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // PersonelIslemleriEkrani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1305, 837);
            this.ControlBox = false;
            this.Controls.Add(this.btnOturumdakiKullanici);
            this.Controls.Add(this.tabPersonel);
            this.Name = "PersonelIslemleriEkrani";
            this.Text = "Personel İşlemleri";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PersonelIslemleriEkrani_Load);
            this.tbpPersonelDemirbasListesi.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonelDemirbasListesi)).EndInit();
            this.tabPersonel.ResumeLayout(false);
            this.tbpPersonelEkle.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxFotograf)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tbpPersonelDemirbasListesi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabPersonel;
        private System.Windows.Forms.Button btnPersonelDemirbasListele;
        private System.Windows.Forms.ComboBox cbDemirbasListelenecekPersonel;
        private System.Windows.Forms.Label lblDemirbasListelenecekPersonel;
        private System.Windows.Forms.Button btnOturumdakiKullanici;
        private System.Windows.Forms.DataGridView dgvPersonelDemirbasListesi;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.ComboBox cbPersonelDemirbasListesiOdaNumarasi;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabPage tbpPersonelEkle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picboxFotograf;
        private System.Windows.Forms.Button btnFotografEkle;
        private System.Windows.Forms.TextBox personelEkleFotograf;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbPersonelEkleDepartman;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbPersonelEkleFakulte;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPersonelEkleSoyadi;
        private System.Windows.Forms.TextBox txtPersonelEkleAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPersonelEkle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cbPersonelYetki;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPersonelDepartman;
    }
}