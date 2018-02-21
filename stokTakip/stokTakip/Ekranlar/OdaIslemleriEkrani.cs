using iTextSharp.text;
using iTextSharp.text.pdf;
using stokTakip.Ekranlar;
using stokTakip.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace stokTakip
{
    public partial class OdaIslemleriEkrani : Form
    {
        public OdaIslemleriEkrani()
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

        public void departmanBul(ComboBox departman,ComboBox fakulte)//combobox'dan seçilen fakültenin departmanları departman combobox da gösterilir.
        {
            departman.SelectedItem = null; //fakülte her değiştiğinde tekrar departmanlar listeleneceği için seçili departman null olur.
            departman.SelectedText = string.Empty;//seçili eleman null olduğu için text de empty olur.
            departman.Items.Clear();//departman combobox'ı temizle
            if (fakulte.SelectedItem!=null)//seçili bir fakülte varsa
            {
                foreach (Departman d in db.Departman.Where(x => x.Fakulte == db.Fakulte.FirstOrDefault(y => y.fakulteAdi == fakulte.SelectedItem.ToString())))
                {
                    departman.Items.Add(d.departmanAdi);//seçilen fakültedeki departmanlar combobox'a çekilir.
                }
            }
        }

        public int OdaBul(ComboBox oda,ComboBox departman)//seçili departmandaki odaların getirilmesi
        {
            oda.SelectedItem = null;//departman seçimi her değiştiğinde seçili oda null olur ve oda bilgileri tekrar gelir.
            oda.SelectedText = string.Empty;
            oda.Items.Clear();

            if (departman.SelectedItem != null)
            {
                Departman d = db.Departman.FirstOrDefault(x => x.departmanAdi == departman.SelectedItem.ToString());
                foreach (Oda o in db.Oda.Where(x => x.departmanId == d.departmanId))
                {
                    oda.Items.Add(o.odaNumarasi);
                }
                return d.departmanId;
            }
            else
                return -1;
        }

        public void DepartmandakiPersonelleriBul(ComboBox personel,int departmanId)
        {
            if(departmanId!=-1)
            {
                personel.SelectedItem = null;//departman her değiştiğinde personel bilgileri tekrar gelir
                personel.SelectedText = string.Empty;
                personel.Items.Clear();
                foreach (Personel p in db.Personel.Where(x => x.departmanId == departmanId))
                {
                    personel.Items.Add(p.personelAdi + " " + p.personelSoyadi + " " + p.personelSicilNo);
                }
                if(personel.Items.Count==0)
                    error.SetError(personel, "Henüz seçilen departmana personel atanmamış.");
                else
                    error.SetError(personel, "");
            }
        }
        private void OdaIslemleriEkrani_Load(object sender, EventArgs e)
        {
            Kullanici k = db.Kullanici.FirstOrDefault(x => x.aktifMi == true);
            if (k!=null)
            {
                btnOturumdakiKullanici.Text = "Oturumdaki Kullanıcı:" + k.Personel.personelAdi + " " + k.Personel.personelSoyadi;
                if(k.Yetki==0)
                {
                    tabOdaIslemleri.TabPages.Remove(tbpOdaEkle);
                    foreach (Fakulte f in db.Fakulte.Where(x => x.fakulteAdi == k.Personel.Departman.Fakulte.fakulteAdi))
                    {
                        cbOdaEkleFakulte.Items.Add(f.fakulteAdi);
                        cbOdaDemirbasFakulte.Items.Add(f.fakulteAdi);
                        cbOdaSorumluEkleFakulte.Items.Add(f.fakulteAdi);
                        cbOdaDemirbasCikarFakulte.Items.Add(f.fakulteAdi);
                        cbOdaDemirbasListFakulte.Items.Add(f.fakulteAdi);
                        cbOdaSorumluGuncelleFakulte.Items.Add(f.fakulteAdi);
                    }
                }
                else
                {
                    foreach (Fakulte f in db.Fakulte.ToList())
                    {
                        cbOdaEkleFakulte.Items.Add(f.fakulteAdi);
                        cbOdaDemirbasFakulte.Items.Add(f.fakulteAdi);
                        cbOdaSorumluEkleFakulte.Items.Add(f.fakulteAdi);
                        cbOdaDemirbasCikarFakulte.Items.Add(f.fakulteAdi);
                        cbOdaDemirbasListFakulte.Items.Add(f.fakulteAdi);
                        cbOdaSorumluGuncelleFakulte.Items.Add(f.fakulteAdi);
                    }
                }
           
          }

            foreach (DemirbasTur dt in db.DemirbasTur.ToList())
            {
                cbOdaDemirbasEkleTur.Items.Add(dt.demirbasTuruAdi);
            }
        }

        //--ODA EKLE EKRANI-- 
        private void cbOdaEkleFakulte_SelectedIndexChanged(object sender, EventArgs e)//Oda Ekle sekmesindeki fakülte combobaxdan fakülte seçildiğinde departmanların gelmesi sağlanır.
        {
            departmanBul(cbOdaEkleDepartman, cbOdaEkleFakulte);
        }

        private void btnOdaEkle_Click(object sender, EventArgs e)
        {
            if(cbOdaEkleFakulte.SelectedItem!=null && cbOdaEkleDepartman.SelectedItem!=null && txtOdaKat.Text!="" && txtOdaNumarasi.Text!="")//boş alan olup olmadığının kontrolü 
            {
                if (IsNumeric(txtOdaKat.Text) && IsNumeric(txtOdaNumarasi.Text))//Kat ve oda numarası numeric değer olmalı
                {
                    //oda bilgileri kullanıcıdan alınır veritabanına kaydedilir.
                    if (db.Oda.Any(x => x.odaNumarasi == txtOdaNumarasi.Text && x.Departman.Fakulte.fakulteAdi == cbOdaEkleFakulte.SelectedItem.ToString()))//oda daha önceden eklenmişse tekrar eklenmez
                        MessageBox.Show("Bu oda daha önce eklenmiş lütfen yeni oda ekleyiniz.");
                    else
                    {
                        Oda oda = new Oda();
                        oda.odaKat = Convert.ToInt32(txtOdaKat.Text);
                        oda.odaNumarasi = txtOdaNumarasi.Text;
                        oda.Departman = db.Departman.FirstOrDefault(x => x.departmanAdi == cbOdaEkleDepartman.SelectedItem.ToString());//odanın departman bilgisine seçilen departman eklenir.
                        db.Oda.Add(oda);
                        db.SaveChanges();
                        MessageBox.Show("Oda başarılı bir şekilde eklendi.");
                        cbOdaEkleFakulte.SelectedItem = null;
                        cbOdaEkleFakulte.SelectedText = string.Empty;
                        cbOdaEkleDepartman.SelectedItem = null;
                        cbOdaEkleDepartman.SelectedText = string.Empty;
                        txtOdaKat.Text = "";
                        txtOdaNumarasi.Text = "";
                    }                
                }
                else//kat ve oda numarası numeric değilse
                    MessageBox.Show("Oda kat ve oda numarası sayısal olmalıdır.");        
            }
             else//boş alan varsa
             MessageBox.Show("Lütfen boş alan bırakmayınız.");
        }
        //--ODA EKLE EKRANI-- 


        //--ODAYA DEMİRBAŞ  EKLE EKRANI-- 
        private void cbOdaDemirbasFakulte_SelectedIndexChanged(object sender, EventArgs e)//Seçilen fakülteye göre departmanların gelmesi
        {
             departmanBul(cbOdaDemirbasDepartman, cbOdaDemirbasFakulte);            
        }

        private void cbOdaDemirbasDepartman_SelectedIndexChanged(object sender, EventArgs e)//Seçilen departmana göre o departmandaki odaların gelmesi
        {
          OdaBul(cbDemirbasEklenecekOda, cbOdaDemirbasDepartman);//departmandaki odalar listelenir                   
        }

        private void cbOdaDemirbasEkleTur_SelectedIndexChanged(object sender, EventArgs e)//odaya atanacak demirbaşların seçimi için seçilen demirbaş türüne göre demirbaşların gelmesi
        {
            if(cbOdaDemirbasEkleTur.SelectedItem!=null)
            {
                cbOdayaEklenecekDemirbas.SelectedItem = null;//demirbaş tür seçimi her değiştiğinde seçili demirbaş null olur ve demirbaş bilgileri tekrar gelir.
                cbOdayaEklenecekDemirbas.SelectedText = string.Empty;
                cbOdayaEklenecekDemirbas.Items.Clear();
                foreach (Demirbas d in db.Demirbas.Where(x => x.DemirbasTur.demirbasTuruAdi == cbOdaDemirbasEkleTur.SelectedItem.ToString()))
                {
                    cbOdayaEklenecekDemirbas.Items.Add(d.demirbasAdi.Trim() + " " + d.marka.Trim() + " " + d.model.Trim());//seçilen demirbaş türündeki demirbaşların gelmesi
                }
            }        
        }

        private void cbDemirbasEklenecekOda_SelectedIndexChanged(object sender, EventArgs e)//demirbaşın atanacağı oda her değiştiğinde o odanın sorumlusunun olup olmadığının kontrolü
        {
            if (cbDemirbasEklenecekOda.SelectedItem!=null)
            {
                Oda o = db.Oda.FirstOrDefault(x => x.odaNumarasi == cbDemirbasEklenecekOda.SelectedItem.ToString() && x.Departman.departmanAdi== cbOdaDemirbasDepartman.SelectedItem.ToString());
                if (o.Personel == null)//odanın sorumlusu yoksa demirbaş eklemeye izin verilmez
                {
                    cbOdaDemirbasEkleTur.Enabled = false;
                    cbOdayaEklenecekDemirbas.Enabled = false;
                    txtOdaDemirbasAdet.Enabled = false;
                    MessageBox.Show("Oda sorumlusu atamadan odaya demirbaş ekleyemezsiniz.Lütfen Oda Sorumlusu Ekle Sekmesine gidiniz.");
                }
                else
                {
                    cbOdaDemirbasEkleTur.Enabled = true;
                    cbOdayaEklenecekDemirbas.Enabled = true;
                    txtOdaDemirbasAdet.Enabled = true;
                }
            }        
        }

        private void cbOdayaEklenecekDemirbas_SelectedIndexChanged(object sender, EventArgs e)//Odaya atanacak demirbaş her değiştiğinde o demirbaşın stoktaki adeti gösterilir
        {
            if (cbOdayaEklenecekDemirbas.SelectedItem!= null)
            {
                Stok s = db.Stok.FirstOrDefault(x => x.Demirbas.demirbasAdi.Trim() + " " + x.Demirbas.marka.Trim() + " " + x.Demirbas.model.Trim() == cbOdayaEklenecekDemirbas.SelectedItem.ToString().Trim());
                lblStokAdet.Text = "En fazla " + s.stokAdet + " adet demirbaş atayabilirsiniz.";
                lblStokAdet.Visible = true;
            }
       
        }

        private void btnOdayaDemirbasEkle_Click(object sender, EventArgs e)
        {
            OdaDemirbasAtama ata;
            if(cbOdaDemirbasFakulte.SelectedItem!=null && cbOdaDemirbasDepartman.SelectedItem!=null && cbDemirbasEklenecekOda.SelectedItem!=null && cbOdaDemirbasEkleTur.SelectedItem!=null && cbOdayaEklenecekDemirbas.SelectedItem!=null && txtOdaDemirbasAdet.Text!="")//boş alan olup olmadığının kontrolü 
            {
                if (IsNumeric(txtOdaDemirbasAdet.Text))//odaya atanacak demirbaş adeti numericse
                {
                    Demirbas d = db.Demirbas.FirstOrDefault(x => x.demirbasAdi.Trim() + " " + x.marka.Trim() + " " + x.model.Trim() == cbOdayaEklenecekDemirbas.SelectedItem.ToString().Trim());     
                    Stok s = db.Stok.FirstOrDefault(x => x.demirbasId == d.demirbasId);
                    if (Convert.ToInt32(txtOdaDemirbasAdet.Text) <= s.stokAdet)//odaya atanmak istenen adet stoktaki adetten azsa
                    {
                        Oda o = db.Oda.FirstOrDefault(x => x.odaNumarasi == cbDemirbasEklenecekOda.SelectedItem.ToString().Trim() && x.Departman.departmanAdi== cbOdaDemirbasDepartman.SelectedItem.ToString());//demirbaşın ekleneceği oda bulunur.
                        ata = db.OdaDemirbasAtama.FirstOrDefault(x => x.demirbasId == d.demirbasId && x.odaId == o.odaId);
                        if (ata == null)//Bu demirbaş daha önce bu odaya atanmamışsa
                        {
                            ata = new OdaDemirbasAtama();
                            ata.Demirbas = d;//Odaya demirbaş atanır.
                            string fakulteId = db.Fakulte.FirstOrDefault(x => x.fakulteAdi == cbOdaDemirbasFakulte.SelectedItem.ToString()).fakulteId.ToString(), //demirbaş kodunu oluşturmak için fakülte bilgisi alınır.
                                departmanId = db.Departman.FirstOrDefault(x => x.departmanAdi == cbOdaDemirbasDepartman.SelectedItem.ToString()).departmanId.ToString(), //demirbaş kodunu oluşturmak için departman bilgisi alınır.
                                TurId = db.DemirbasTur.FirstOrDefault(x => x.demirbasTuruAdi == cbOdaDemirbasEkleTur.SelectedItem.ToString()).demirbasTuruId.ToString(),//demirbaş kodunu oluşturmak için demirbaş tür bilgisi alınır.
                                demirbasId = d.demirbasId.ToString();
                            if (fakulteId.Length == 1)//tek basamaklı fakulteId departmanId demirbasTurId demirbasId değerlerin önüne sıfır eklenir.
                                fakulteId = "0" + fakulteId;
                            if (departmanId.Length == 1)
                                departmanId = "0" + departmanId;
                            if (TurId.Length == 1)
                                TurId = "0" + TurId;
                            if (d.demirbasId.ToString().Length == 1)
                                demirbasId = "0" + demirbasId;

                            ata.demirbasKodu = fakulteId + "." + departmanId + "." + TurId + "." + demirbasId;//demirbaş odaya atandığı anda demirbaş kodu oluşturulur.
                            ata.Oda = o;
                            ata.adet = Convert.ToInt32(txtOdaDemirbasAdet.Text);
                            db.OdaDemirbasAtama.Add(ata);//atama işlemi OdaDemirbasAtama tablosuna kaydedilir.
                            s.stokAdet -= Convert.ToInt32(txtOdaDemirbasAdet.Text);//Atanan demirbaş adeti o kadar o demirbaşın stok adetinden düşülür.
                            MessageBox.Show("Demirbaş odaya başarıyla eklendi.");
                        }
                        else//bu demirbaş daha önce bu odaya atanmışsa sadece odadaki adeti artırılır ve eklenen adet kadar demirbaşın stok adetinden düşülür.
                        {                   
                                ata.adet += Convert.ToInt32(txtOdaDemirbasAdet.Text);
                                s.stokAdet -= Convert.ToInt32(txtOdaDemirbasAdet.Text);
                        }
                        //inputların temizlenmesi
                        cbOdaDemirbasFakulte.SelectedItem = null;
                        cbOdaDemirbasFakulte.SelectedText = string.Empty;
                        cbOdaDemirbasDepartman.SelectedItem = null;
                        cbOdaDemirbasDepartman.SelectedText = string.Empty;
                        cbDemirbasEklenecekOda.SelectedItem = null;
                        cbDemirbasEklenecekOda.SelectedText = string.Empty;
                        cbOdaDemirbasEkleTur.SelectedItem = null;
                        cbOdaDemirbasEkleTur.SelectedText = string.Empty;
                        cbOdayaEklenecekDemirbas.SelectedItem = null;
                        cbOdayaEklenecekDemirbas.Text = string.Empty;
                        txtOdaDemirbasAdet.Text = "";
                        lblStokAdet.Text = "";
                    }
                    else//odaya atanmak istenen adet stoktaki adetten fazlaysa
                        MessageBox.Show("Stokta yeteri kadar ürün yok!");
                    db.SaveChanges();
                }
                else//odaya atanacak demirbaş adeti numeric değilse
                    MessageBox.Show("adet alanı sayısal olmalıdır.");              
            }
            else//boş alan varsa
               MessageBox.Show("Lütfen boş alan bırakmayınız.");
        }

        //--ODAYA DEMİRBAŞ EKLE EKRANI-- 


        //--ODA SORUMLUSU EKLE EKRANI-- 
        private void cbOdaSorumluEkleFakulte_SelectedIndexChanged(object sender, EventArgs e)//fakülte seçimi her değiştiğinde departmanlar gelir
        {
            departmanBul(cbOdaSorumleEkleDepartman, cbOdaSorumluEkleFakulte);
        }

        private void cbOdaSorumleEkleDepartman_SelectedIndexChanged(object sender, EventArgs e)//departman seçimi her dğeiştiğinde o departmandaki odalar ve personeller gelir
        {
            int departmanId = OdaBul(cbOdaSorumluEkleOda, cbOdaSorumleEkleDepartman);
            DepartmandakiPersonelleriBul(cbOdaSorumluEkleSorumlu, departmanId);            
        }

        private void btnOdaSorumlusuEkle_Click(object sender, EventArgs e)
        {
            if(cbOdaSorumluEkleFakulte.SelectedItem!=null && cbOdaSorumleEkleDepartman.SelectedItem!=null && cbOdaSorumluEkleOda.SelectedItem!=null && cbOdaSorumluEkleSorumlu.SelectedItem!=null)//alanların boş olup olmadığının kontrolü
            {
                Oda o = db.Oda.FirstOrDefault(x => x.odaNumarasi == cbOdaSorumluEkleOda.SelectedItem.ToString() && x.Departman.departmanAdi== cbOdaSorumleEkleDepartman.SelectedItem.ToString());//Oda sorumlusu eklenecek oda bulunur.
                if (o.Personel == null)//odaya daha önce personel atanmamışsa personel odaya atanır.
                {
                    o.Personel = db.Personel.FirstOrDefault(x => x.personelAdi + " " + x.personelSoyadi + " " + x.personelSicilNo == cbOdaSorumluEkleSorumlu.SelectedItem.ToString());
                    db.SaveChanges();
                    MessageBox.Show("Oda sorumlusu başarıyla eklendi");
                    cbOdaSorumluEkleFakulte.SelectedItem = null;
                    cbOdaSorumluEkleFakulte.SelectedText = string.Empty;
                    cbOdaSorumleEkleDepartman.SelectedItem = null;
                    cbOdaSorumleEkleDepartman.SelectedText = string.Empty;
                    cbOdaSorumluEkleOda.SelectedItem = null;
                    cbOdaSorumluEkleOda.SelectedText = string.Empty;
                    cbOdaSorumluEkleSorumlu.SelectedItem = null;
                    cbOdaSorumluEkleSorumlu.SelectedText = string.Empty;
                }
                else//odaya daha önce personel atanmışsa
                    MessageBox.Show("Bu odanın zaten sorumlusu var sorumluyu güncellemek istiyorsanız lütfen oda sorumlusunu güncelle ekranınına gidiniz.");
            }
            else
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
        }
        //--ODA SORUMLUSU EKLE EKRANI--



        //--ODADAN DEMİRBAŞ ÇIKAR EKRANI--
        private void cbOdaDemirbasCikarFakulte_SelectedIndexChanged(object sender, EventArgs e)//fakülte seçimi her değiştiğinde departman bilgisinin tekrar gelmesi
        {
           departmanBul(cbOdaDemirbasCikarDepartman, cbOdaDemirbasCikarFakulte);           
        }

        private void cbOdaDemirbasCikarDepartman_SelectedIndexChanged(object sender, EventArgs e)//departman seçimi her değiştiğinde oda bilgilerinin tekrar gelmesi
        {
          OdaBul(cbOdaDemirbasCikarOdaNumarasi, cbOdaDemirbasCikarDepartman);
        }

        private void cbOdaDemirbasCikarOdaNumarasi_SelectedIndexChanged(object sender, EventArgs e)//Oda seçimi her değiştiğinde o odaya atanmış demirbaşların gelmesi
        {
            cbOdaDemirbasCikarDemirbas.SelectedItem = null;
            cbOdaDemirbasCikarDemirbas.SelectedText = string.Empty;
            if (cbOdaDemirbasCikarOdaNumarasi.SelectedItem!=null)
            {
                cbOdaDemirbasCikarDemirbas.Items.Clear();
                foreach (OdaDemirbasAtama ata in db.OdaDemirbasAtama.Where(x => x.Oda.odaNumarasi == cbOdaDemirbasCikarOdaNumarasi.SelectedItem.ToString() && x.Oda.Departman.departmanAdi == cbOdaDemirbasCikarDepartman.SelectedItem.ToString()))
                {
                    if (ata.adet > 0)//odada adeti sıfırdan büyük olan demirbaşların gelmesi
                       cbOdaDemirbasCikarDemirbas.Items.Add(ata.Demirbas.demirbasAdi.Trim() + " " + ata.Demirbas.marka.Trim() + " " + ata.Demirbas.model);
                }
                if (cbOdaDemirbasCikarDemirbas.Items.Count==0)
                    error.SetError(cbOdaDemirbasCikarDemirbas,"Henüz odaya demirbaş eklenmemiş.");
                error.SetError(cbOdaDemirbasCikarDemirbas, "");
            }  
        }

        private void cbOdaDemirbasCikarDemirbas_SelectedIndexChanged(object sender, EventArgs e)//Odadan çıkarılacak demirbaş her değiştirildiğinde o demirbaşın odadaki miktarına göre en fazla çıkarılabilecek adetin belirlenmesi
        {
            if(cbOdaDemirbasCikarDemirbas.SelectedItem!=null)
            {            
                OdaDemirbasAtama ata = db.OdaDemirbasAtama.FirstOrDefault(x => x.Demirbas.demirbasAdi.Trim() + " " + x.Demirbas.marka.Trim() + " " + x.Demirbas.model.Trim() == cbOdaDemirbasCikarDemirbas.SelectedItem.ToString().Trim() && x.Oda.odaNumarasi == cbOdaDemirbasCikarOdaNumarasi.SelectedItem.ToString());
                lblOdaDemirbasCikarAdet.Text = "En fazla " + ata.adet + " adet demirbaş çıkarabilirsiniz.";
                lblOdaDemirbasCikarAdet.Visible = true;
            }
         
        }
        private void btnOdadanDemirbasCikar_Click(object sender, EventArgs e)
        {
            if(cbOdaDemirbasCikarFakulte.SelectedItem!=null && cbOdaDemirbasCikarDepartman.SelectedItem!=null && cbOdaDemirbasCikarOdaNumarasi.SelectedItem!=null && cbOdaDemirbasCikarDemirbas.SelectedItem!=null && txtOdaDemirbasCikarAdet.Text!="")//boş alan olup olmadığının kontrolü 
            {
                if (IsNumeric(txtOdaDemirbasCikarAdet.Text))//Odadan çıkarılacak demirbaş adeti numeric olmalı
                {
                    Demirbas d = db.Demirbas.FirstOrDefault(x => x.demirbasAdi.Trim() + " " + x.marka.Trim() + " " + x.model.Trim() == cbOdaDemirbasCikarDemirbas.SelectedItem.ToString().Trim());//odadan çıkarılacak demirbaşın belirlenmesi
                    OdaDemirbasAtama ata = db.OdaDemirbasAtama.FirstOrDefault(x => x.demirbasId == d.demirbasId && x.Oda.odaNumarasi== cbOdaDemirbasCikarOdaNumarasi.SelectedItem.ToString() && x.Oda.Departman.departmanAdi== cbOdaDemirbasCikarDepartman.SelectedItem.ToString());
                    if (Convert.ToInt32(txtOdaDemirbasCikarAdet.Text) <= ata.adet)//odadan çıkarılacak demirbaş adeti odadaki demirbaş adetinden küçük yada eşit olmalı
                    {
                        ata.adet -= Convert.ToInt32(txtOdaDemirbasCikarAdet.Text);//adet kadar odadaki demirbaş adetinden düşülür.
                        Stok s = db.Stok.FirstOrDefault(x => x.demirbasId == d.demirbasId);
                        s.stokAdet += Convert.ToInt32(txtOdaDemirbasCikarAdet.Text);//adet kadar o demirbaşın stok adetine eklenir
                        db.SaveChanges();
                        MessageBox.Show("Odadan demirbaşı başarıyla çıkardınız.");
                        cbOdaDemirbasCikarFakulte.SelectedItem = null;
                        cbOdaDemirbasCikarFakulte.SelectedText = string.Empty;
                        cbOdaDemirbasCikarDepartman.SelectedItem = null;
                        cbOdaDemirbasCikarDepartman.SelectedText = string.Empty;
                        cbOdaDemirbasCikarOdaNumarasi.SelectedItem = null;
                        cbOdaDemirbasCikarOdaNumarasi.SelectedText = string.Empty;
                        cbOdaDemirbasCikarDemirbas.SelectedItem = null;
                        cbOdaDemirbasCikarDemirbas.SelectedText = string.Empty;
                        txtOdaDemirbasCikarAdet.Text = "";
                        lblOdaDemirbasCikarAdet.Text = "";
                    }
                    else//odadan çıkarılacak demirbaş adeti o demirbaşın odadaki adetinden daha büyükse
                     MessageBox.Show("Seçtiğiniz demirbaştan odada toplam " + ata.adet + " adet vardır daha küçük bir sayı giriniz");
                }
                else//adet alanı numeric değilse 
                    MessageBox.Show("adet alanı sayısal olmalıdır.");  
            }
            else//boş alan varsa
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
        }

        //--ODADAN DEMİRBAŞ ÇIKAR EKRANI--


        //--ODADAKİ DEMİRBAŞ LİSTESİ EKRANI--
        private void cbOdaDemirbasListFakulte_SelectedIndexChanged(object sender, EventArgs e)//fakülte seçimi her değiştiğinde departmanların getirilmesi
        {
            departmanBul(cbOdaDemirbasListDepartman, cbOdaDemirbasListFakulte);
        }

       
        private void cbOdaDemirbasListDepartman_SelectedIndexChanged(object sender, EventArgs e)//departman seçimi her değiştiğinde odaların getirilmesi
        {
           OdaBul(cbOdaDemirbasListNumarasi, cbOdaDemirbasListDepartman);
        }

        private void cbOdaDemirbasListNumarasi_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvOdaDemirbasListe.DataSource = null;

        }

        private void btnOdaDemirbasListele_Click(object sender, EventArgs e)
        {
            if(cbOdaDemirbasListFakulte.SelectedItem!=null && cbOdaDemirbasListDepartman.SelectedItem!=null && cbOdaDemirbasListNumarasi.SelectedItem!=null)//boş alan olup olmadığının kontrolü 
            {
                List<localDemirbas> demirbaslar = new List<localDemirbas>();
              
                foreach (OdaDemirbasAtama ata in db.OdaDemirbasAtama.Where(x => x.Oda.odaNumarasi== cbOdaDemirbasListNumarasi.SelectedItem.ToString() && x.Oda.Departman.departmanAdi== cbOdaDemirbasListDepartman.SelectedItem.ToString()))
                {
                    localDemirbas ld = new localDemirbas();
                    if (ata.adet > 0)//seçilen odadaki demirbaşın adeti sıfırdan büyükse demirbaş bilgilerini listeye ekle(o odada olan demirbaşlar)
                    {
                        ld.siraNumarasi =ata.Demirbas.demirbasId;
                        ld.demirbasKodu = ata.demirbasKodu;
                        ld.demirbasAdi = ata.Demirbas.demirbasAdi;
                        ld.marka = ata.Demirbas.marka;
                        ld.model = ata.Demirbas.model;
                        ld.demirbasAdeti = ata.adet;
                        demirbaslar.Add(ld);
                    }
                }
                if(demirbaslar.Count!=0)
                {
                    dgvOdaDemirbasListe.DataSource = demirbaslar;//datagridview de listenin gösterilmesi
                    dgvOdaDemirbasListe.Columns[0].HeaderText = "Sıra Numarası";
                    dgvOdaDemirbasListe.Columns[1].HeaderText = "Demirbaş Kodu";
                    dgvOdaDemirbasListe.Columns[2].HeaderText = "Demirbaş Adı";
                    dgvOdaDemirbasListe.Columns[3].HeaderText = "Marka";
                    dgvOdaDemirbasListe.Columns[4].HeaderText = "Model";
                    dgvOdaDemirbasListe.Columns[6].HeaderText = "Adet";
                    dgvOdaDemirbasListe.Columns[5].Visible = false;
                    dgvOdaDemirbasListe.Columns[7].Visible = false;
                    dgvOdaDemirbasListe.Columns[8].Visible = false;
                    dgvOdaDemirbasListe.Columns[9].Visible = false;
                    this.dgvOdaDemirbasListe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    btnPdf.Visible = true;
                }
                else
                    MessageBox.Show("Odaya henüz demirbaş eklenmemiş.");

            }
            else//boş alan varsa 
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            //Odadaki demirbaş listesi pdf olarak oluşturulur.
            if (dgvOdaDemirbasListe.DataSource != null)
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF File|*.pdf", ValidateNames = true })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4.Rotate());
                        try
                        {
                            if (cbOdaDemirbasListNumarasi.SelectedItem != null)
                            {
                                Oda o = db.Oda.FirstOrDefault(x => x.odaNumarasi == cbOdaDemirbasListNumarasi.SelectedItem.ToString() && x.Departman.departmanAdi==cbOdaDemirbasListDepartman.SelectedItem.ToString());

                                string Tahoma = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "Tahoma.TTF");
                                BaseFont bf = BaseFont.CreateFont(Tahoma, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

                                PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                                doc.Open();
                                doc.Add(new Paragraph("ODA DEMİRBAŞ LİSTESİ", new iTextSharp.text.Font(bf)));//döküman başlığı oluşturulur
                                doc.Add(new Paragraph("Oda Sorumlusu:" + o.Personel.personelAdi + " " + o.Personel.personelSoyadi, new iTextSharp.text.Font(bf)));//Dökümana oda sorumlusu eklenir

                                PdfPTable pdfTablosu = new PdfPTable(6);//oda demirbaş tablosu oluşturulur.
                                pdfTablosu.PaddingTop = 5000;
                                pdfTablosu.DefaultCell.Padding = 3;
                                pdfTablosu.WidthPercentage = 100;
                                pdfTablosu.HorizontalAlignment = Element.ALIGN_CENTER;
                                pdfTablosu.DefaultCell.BorderWidth = 1;
                                pdfTablosu.PaddingTop = 500;

                                foreach (DataGridViewColumn sutun in dgvOdaDemirbasListe.Columns)
                                {
                                    if (sutun.Index != 5 && sutun.Index != 7 && sutun.Index != 8 && sutun.Index != 9)
                                    {
                                        PdfPCell pdfHucresi = new PdfPCell(new Phrase(sutun.HeaderText, new iTextSharp.text.Font(bf)));//sutun başlıkları belirlenir.
                                        pdfTablosu.AddCell(pdfHucresi);
                                    }

                                }
                                foreach (DataGridViewRow satir in dgvOdaDemirbasListe.Rows)
                                {
                                    foreach (DataGridViewCell cell in satir.Cells)
                                    {
                                        if (cell.ColumnIndex != 5 && cell.ColumnIndex != 7 && cell.ColumnIndex != 8 && cell.ColumnIndex != 9)
                                            pdfTablosu.AddCell(new Phrase(cell.Value.ToString(), new iTextSharp.text.Font(bf)));//hücre değerleri belirlenir
                                    }
                                }
                                doc.Add(pdfTablosu);//pdf dökümanına tablo eklenir.
                            }
                            else
                                MessageBox.Show("Oda numarası boş olamaz.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            doc.Close();
                        }
                    }
                }
            }
        
        
        }
        //--ODADAKİ DEMİRBAŞ LİSTESİ EKRANI--

        //--ODA SORUMLUSU GÜNCELLE--
        private void cbOdaSorumluGuncelleFakulte_SelectedIndexChanged(object sender, EventArgs e)
        {
            departmanBul(cbOdaSorumluGuncelleDepartman, cbOdaSorumluGuncelleFakulte);
        }

        private void cbOdaSorumluGuncelleDepartman_SelectedIndexChanged(object sender, EventArgs e)//departman seçimi her değiştiğinde departmandaki odalar ve personeller getirilir.
        {
            int departmanId = OdaBul(cbOdaSorumluGuncelleOdaNumarasi, cbOdaSorumluGuncelleDepartman);
            DepartmandakiPersonelleriBul(cbOdaSorumluGuncelleYeniSorumlu, departmanId);      
        }

        private void cbOdaSorumluGuncelleOdaNumarasi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbOdaSorumluGuncelleOdaNumarasi.SelectedItem!=null)
            {
                Oda o = db.Oda.FirstOrDefault(x => x.odaNumarasi == cbOdaSorumluGuncelleOdaNumarasi.SelectedItem.ToString() && x.Departman.departmanAdi== cbOdaSorumluGuncelleDepartman.SelectedItem.ToString());
                if (o.Personel == null)//odaya personel eklenmemişse
                {
                    MessageBox.Show("Odaya henüz personel eklenmemiş.Lütfen odaya personel atayınız.");
                    txtOdaSorumluGuncelleMevcutSorumlu.Enabled = false;
                    cbOdaSorumluGuncelleYeniSorumlu.Enabled = false;
                }
                else//odaya daha önceden personel eklenmişse adı soyadı textbox'a yazdırılır.
                {
                    Personel p = db.Personel.FirstOrDefault(x => x.personelId == o.personelId);
                    txtOdaSorumluGuncelleMevcutSorumlu.Text = p.personelAdi + " " + p.personelSoyadi;
                    txtOdaSorumluGuncelleMevcutSorumlu.Enabled = false;
                    cbOdaSorumluGuncelleYeniSorumlu.Enabled = true;
                }
            }
           
            
        }

        private void btnOdaSorumluGuncelle_Click(object sender, EventArgs e)
        {
            if(cbOdaSorumluGuncelleFakulte.SelectedItem!=null && cbOdaSorumluGuncelleDepartman.SelectedItem!=null && cbOdaSorumluGuncelleOdaNumarasi.SelectedItem!=null && txtOdaSorumluGuncelleMevcutSorumlu.Text!="" && cbOdaSorumluGuncelleYeniSorumlu.SelectedItem!=null)//boş alan olup olmadığının kontrolü
            {
                Oda o = db.Oda.FirstOrDefault(x => x.odaNumarasi == cbOdaSorumluGuncelleOdaNumarasi.SelectedItem.ToString() && x.Departman.departmanAdi== cbOdaSorumluGuncelleDepartman.SelectedItem.ToString());//Oda sorumlusu güncellenecek oda bulunur.
                o.Personel = db.Personel.FirstOrDefault(x => x.personelAdi.Trim() + " " + x.personelSoyadi.Trim() + " " + x.personelSicilNo.Trim() == cbOdaSorumluGuncelleYeniSorumlu.SelectedItem.ToString().Trim());//oda sorumlusu güncellendi
                db.SaveChanges();
                MessageBox.Show("Oda sorumlusu başarı ile güncellendi.");
                cbOdaSorumluGuncelleFakulte.SelectedItem = null;
                cbOdaSorumluGuncelleFakulte.SelectedText = string.Empty;
                cbOdaSorumluGuncelleDepartman.SelectedItem = null;
                cbOdaSorumluGuncelleDepartman.SelectedText = string.Empty;
                cbOdaSorumluGuncelleOdaNumarasi.SelectedItem = null;
                cbOdaSorumluGuncelleOdaNumarasi.SelectedText = string.Empty;
                txtOdaSorumluGuncelleMevcutSorumlu.Text = "";
                cbOdaSorumluGuncelleYeniSorumlu.SelectedItem = null;
                cbOdaSorumluGuncelleYeniSorumlu.SelectedText = string.Empty;

            }
            else//boş alan varsa 
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
        }

    }
        //--ODA SORUMLUSU GÜNCELLE
}

