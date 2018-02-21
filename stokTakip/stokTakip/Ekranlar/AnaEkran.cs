using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using stokTakip.Ekranlar;
using stokTakip.Model;

namespace stokTakip
{
    public partial class AnaEkran : Form
    {
        public AnaEkran()
        {
            InitializeComponent();
        }
        stokTakipdbEntities6 db = new stokTakipdbEntities6();

        void YavruForm(Form Yavru)
        {
            bool durum = false;
            foreach (Form eleman in this.MdiChildren)
            {
                if (eleman.Text == Yavru.Text)
                {
                    durum = true;
                    eleman.Activate();
                }

            }

            if (durum == false)
            {
                Yavru.MdiParent = this;
                Yavru.Show();
            }
        }


        private void AnaEkran_Load(object sender, EventArgs e)
        {      
            Anasayfa a = new Anasayfa();
            YavruForm(a);
            
        }

        private void odaIslemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OdaIslemleriEkrani oie = new OdaIslemleriEkrani();
            YavruForm(oie);
        }

        private void personelIslemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonelIslemleriEkrani pie = new PersonelIslemleriEkrani();
            YavruForm(pie);
        }

        private void demirbasIslemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DemirbasIslemleriEkrani die = new DemirbasIslemleriEkrani();
            YavruForm(die);
        }

        private void stokTakipIslemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StokDemirbasIslemleriEkrani sdie = new StokDemirbasIslemleriEkrani();
            YavruForm(sdie);
        }

        private void anasayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Anasayfa a = new Anasayfa();
            YavruForm(a);
        }

        private void cikisYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult cevap =MessageBox.Show("Çıkış yapmak istiyor musunuz?", "", MessageBoxButtons.YesNoCancel);
            if (cevap == DialogResult.Yes)
            {
                Kullanici k = db.Kullanici.FirstOrDefault(x => x.aktifMi == true);
                k.aktifMi = false;
                db.SaveChanges();
                Application.Exit();
            }
        }
    }
}
