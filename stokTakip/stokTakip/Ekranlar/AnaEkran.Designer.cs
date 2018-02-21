namespace stokTakip
{
    partial class AnaEkran
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.anasayfaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odaIslemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personelIslemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.demirbasIslemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stokTakipIslemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cikisYapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.anasayfaToolStripMenuItem,
            this.demirbasIslemleriToolStripMenuItem,
            this.odaIslemleriToolStripMenuItem,
            this.personelIslemleriToolStripMenuItem,
            this.stokTakipIslemleriToolStripMenuItem,
            this.cikisYapToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1305, 32);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // anasayfaToolStripMenuItem
            // 
            this.anasayfaToolStripMenuItem.Name = "anasayfaToolStripMenuItem";
            this.anasayfaToolStripMenuItem.Size = new System.Drawing.Size(96, 28);
            this.anasayfaToolStripMenuItem.Text = "Anasayfa";
            this.anasayfaToolStripMenuItem.Click += new System.EventHandler(this.anasayfaToolStripMenuItem_Click);
            // 
            // odaIslemleriToolStripMenuItem
            // 
            this.odaIslemleriToolStripMenuItem.Name = "odaIslemleriToolStripMenuItem";
            this.odaIslemleriToolStripMenuItem.Size = new System.Drawing.Size(132, 28);
            this.odaIslemleriToolStripMenuItem.Text = "Oda İşlemleri";
            this.odaIslemleriToolStripMenuItem.Click += new System.EventHandler(this.odaIslemleriToolStripMenuItem_Click);
            // 
            // personelIslemleriToolStripMenuItem
            // 
            this.personelIslemleriToolStripMenuItem.Name = "personelIslemleriToolStripMenuItem";
            this.personelIslemleriToolStripMenuItem.Size = new System.Drawing.Size(168, 28);
            this.personelIslemleriToolStripMenuItem.Text = "Personel İşlemleri";
            this.personelIslemleriToolStripMenuItem.Click += new System.EventHandler(this.personelIslemleriToolStripMenuItem_Click);
            // 
            // demirbasIslemleriToolStripMenuItem
            // 
            this.demirbasIslemleriToolStripMenuItem.Name = "demirbasIslemleriToolStripMenuItem";
            this.demirbasIslemleriToolStripMenuItem.Size = new System.Drawing.Size(173, 28);
            this.demirbasIslemleriToolStripMenuItem.Text = "Demirbaş İşlemleri";
            this.demirbasIslemleriToolStripMenuItem.Click += new System.EventHandler(this.demirbasIslemleriToolStripMenuItem_Click);
            // 
            // stokTakipIslemleriToolStripMenuItem
            // 
            this.stokTakipIslemleriToolStripMenuItem.Name = "stokTakipIslemleriToolStripMenuItem";
            this.stokTakipIslemleriToolStripMenuItem.Size = new System.Drawing.Size(188, 28);
            this.stokTakipIslemleriToolStripMenuItem.Text = "Stok Takip İşlemleri";
            this.stokTakipIslemleriToolStripMenuItem.Click += new System.EventHandler(this.stokTakipIslemleriToolStripMenuItem_Click);
            // 
            // cikisYapToolStripMenuItem
            // 
            this.cikisYapToolStripMenuItem.Name = "cikisYapToolStripMenuItem";
            this.cikisYapToolStripMenuItem.Size = new System.Drawing.Size(92, 28);
            this.cikisYapToolStripMenuItem.Text = "Çıkış Yap";
            this.cikisYapToolStripMenuItem.Click += new System.EventHandler(this.cikisYapToolStripMenuItem_Click);
            // 
            // AnaEkran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1305, 837);
            this.ControlBox = false;
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AnaEkran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ana Ekran";
            this.Load += new System.EventHandler(this.AnaEkran_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem odaIslemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personelIslemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem demirbasIslemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokTakipIslemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cikisYapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anasayfaToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}