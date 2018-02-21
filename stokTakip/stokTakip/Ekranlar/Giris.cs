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
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        stokTakipdbEntities6 db = new stokTakipdbEntities6();
        public bool IsNumeric(string text)//inputların sayı olup olmadığının kontrolü
        {
            bool sayiMi = true;
            foreach (char chr in text)
            {
                if (!Char.IsNumber(chr))
                    sayiMi = false;
            }
            return sayiMi;
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if(GirisYap(txtKullaniciAdi.Text, txtParola.Text)==1)
            this.Hide();
          
        }

        public int GirisYap(string kullaniciAdi,string sifre)
        {            
            try
            {
                if (kullaniciAdi != "" && sifre != "")//kullanıcı adı ve parolanın dolu olup olmadığının kontrolü
                {
                    if (IsNumeric(kullaniciAdi))//kullanıcı adı sayısal olamaz.
                        MessageBox.Show("Kullanıcı adı sayısal olamaz.");
                    else
                    {
                        Kullanici k = db.Kullanici.FirstOrDefault(x => x.kullaniciAdi == kullaniciAdi && x.sifre == sifre);//kullanıcıAdı ve paraloya göre kullanıcı bulunur.
                        if (k != null)
                        {
                            k.aktifMi = true;//kullanıcının sisteme girdiğini belirtmek için aktif mi özelliği true yapılır.
                            db.SaveChanges();
                            AnaEkran ae = new AnaEkran();
                            ae.Show();
                            txtKullaniciAdi.Text = "";
                            txtParola.Text = "";
                            return 1;
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı adı veya şifre hatalı.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return 0;
                        }                    
                    }

                }
                else
                    MessageBox.Show("Lütfen kullanıcı adınızı ve şifrenizi giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 2;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen Bir Hata Oluştu!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 3;
            }
        }
    }
}
