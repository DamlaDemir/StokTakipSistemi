using stokTakip.Ekranlar;
using stokTakip.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stokTakip
{
    public partial class StokDemirbasIslemleriEkrani : Form
    {
        public StokDemirbasIslemleriEkrani()
        {
            InitializeComponent();
        }

        stokTakipdbEntities6 db = new stokTakipdbEntities6();
        public bool IsNumeric(string text)
        {
            bool sayiMi = true;
            foreach (char chr in text)
            {
                if (!Char.IsNumber(chr))
                    sayiMi = false;
            }
            return sayiMi;
        }

        private void btnStokDemirbasListele_Click(object sender, EventArgs e)
        {
            List<localDemirbas> demirbaslar = new List<localDemirbas>();

            foreach (Stok s in db.Stok.ToList())
            {
                localDemirbas ld = new localDemirbas();
                ld.demirbasAdi = s.Demirbas.demirbasAdi;
                ld.marka = s.Demirbas.marka;
                ld.model = s.Demirbas.model;
                ld.demirbasTuru = s.Demirbas.DemirbasTur.demirbasTuruAdi;
                ld.demirbasAdeti = s.stokAdet;
                demirbaslar.Add(ld);
            }
            dgvStokDemirbasListele.DataSource = demirbaslar;
            dgvStokDemirbasListele.Columns[0].Visible = false;
            dgvStokDemirbasListele.Columns[1].Visible = false;
            dgvStokDemirbasListele.Columns[7].Visible = false;
            dgvStokDemirbasListele.Columns[8].Visible = false;
            dgvStokDemirbasListele.Columns[9].Visible = false;
            dgvStokDemirbasListele.Columns[2].HeaderText = "Demirbaş Adı";
            dgvStokDemirbasListele.Columns[3].HeaderText = "Marka";
            dgvStokDemirbasListele.Columns[4].HeaderText = "Model";
            dgvStokDemirbasListele.Columns[6].HeaderText = "Demirbaş Türü";
            dgvStokDemirbasListele.Columns[6].HeaderText = "Stok Adeti";
            this.dgvStokDemirbasListele.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

       
        private void StokDemirbasIslemleriEkrani_Load(object sender, EventArgs e)
        {
            Kullanici k = db.Kullanici.FirstOrDefault(x => x.aktifMi == true);
            if (k != null)
            {
                btnOturumdakiKullanici.Text = "Oturumdaki Kullanıcı:" + k.Personel.personelAdi + " " + k.Personel.personelSoyadi;
            }
        }
    }
}
