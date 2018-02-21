using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using stokTakip.Model.Model1.edmx.Model1.tt;
using stokTakip;

namespace StokkTakipTest
{
    [TestClass]
    public class StokTakipTest
    {

        [TestMethod()]
        public void Baglanti()
        {
            stokTakipdbEntities6 db = new stokTakipdbEntities6();
        }

        [TestMethod()]
        public void Form()
        {
            Giris g = new Giris();
            Assert.IsNotNull(g);           
        }

        [TestMethod()]
        public void GirisYapTest()
        {
            int beklenenDeger = 2;

            string kullaniciAdi = "";
            string sifre = "";
            Giris a = new Giris();
            int sonuc = a.GirisYap(kullaniciAdi, sifre);
            Assert.AreEqual(beklenenDeger, sonuc);            
        }
    }
 }

