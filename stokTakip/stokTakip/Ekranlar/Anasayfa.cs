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

namespace stokTakip.Ekranlar
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }
        stokTakipdbEntities6 db = new stokTakipdbEntities6();

        private void Anasayfa_Load(object sender, EventArgs e)
        {
          Kullanici k = db.Kullanici.FirstOrDefault(x => x.aktifMi == true);
          picboxKullanıcıFotograf.Image = Image.FromFile((Application.StartupPath + "\\resimler\\" + k.Personel.fotograf));
          lblFakülte.Text = k.Personel.Departman.Fakulte.fakulteAdi;
          lblDepartman.Text = k.Personel.Departman.departmanAdi;
          lblAdSoyad.Text = k.Personel.personelAdi + " " + k.Personel.personelSoyadi;
          lblSicilNo.Text = k.Personel.personelSicilNo;
        }

 
    }
}
