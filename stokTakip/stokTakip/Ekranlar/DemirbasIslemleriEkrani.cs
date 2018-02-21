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
    public partial class DemirbasIslemleriEkrani : Form
    {
        public DemirbasIslemleriEkrani()
        {
            InitializeComponent();
        }
        stokTakipdbEntities6 db = new stokTakipdbEntities6();
        bool turMu = false, adMi = false, fiyatMi = false, tarihMi = false, adetMi = false;


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
        private void DemirbasIslemleriEkrani_Load(object sender, EventArgs e)
        {
            Kullanici k = db.Kullanici.FirstOrDefault(x => x.aktifMi == true);
            if (k != null)
            {
                btnOturumdakiKullanici.Text = "Oturumdaki Kullanıcı:" + k.Personel.personelAdi + " " + k.Personel.personelSoyadi;
                if (k.Yetki == 0)
                {
                    tabDemirbas.TabPages.Remove(tbpDemirbasEkle);
                    tabDemirbas.TabPages.Remove(tbpDemirbasGuncelle);
                    tabDemirbas.TabPages.Remove(tbpDemirbasListele);
                }
            }
            foreach (DemirbasTur dt in db.DemirbasTur.ToList())
            {
                cbDemirbasTuru.Items.Add(dt.demirbasTuruAdi);
                cbDemirbasGuncelleTur.Items.Add(dt.demirbasTuruAdi);
            }
        }

        //--DEMİRBAŞ EKLE EKRANI
        private void btnDemirbasEkle_Click(object sender, EventArgs e)//kullanıcıdan demirbaş bilgileri alınır hem stoğa hemde demirbas tablosuna kaydedilir.
        {
            Demirbas d;
            if (cbDemirbasTuru.SelectedItem != null && txtDemirbasAdi.Text != "" && txtDemirbasEkleMarka.Text != "" && txtDemirbasModel.Text != "" && txtDemirbasEkleFiyat.Text != "" && txtDemirbasEkleAdet.Text != "")// boş alan olup olmadığının kontrolü
            {
                d = db.Demirbas.FirstOrDefault(x => x.demirbasAdi == txtDemirbasAdi.Text && x.marka == txtDemirbasEkleMarka.Text && x.model == txtDemirbasModel.Text);//eklenecek demirbaş daha önceden demirbaş tablosuna kaydedildiyse
                if (d != null)
                {
                    MessageBox.Show("Demirbaş daha önceden eklenmiş demirbaşı güncellemek için demirbaş işlemleri ekranına gidiniz.");
                }
                else
                {
                    //daha önceden eklenmediyse yeni bir demirbaş kaydı oluşturulur.
                    d = new Demirbas();
                    d.demirbasAdi = txtDemirbasAdi.Text.ToLower().Trim();
                    d.DemirbasTur = db.DemirbasTur.FirstOrDefault(x => x.demirbasTuruAdi == cbDemirbasTuru.SelectedItem.ToString());
                    d.fiyat = Convert.ToDecimal(txtDemirbasEkleFiyat.Text);
                    d.adet = Convert.ToInt32(txtDemirbasEkleAdet.Text);
                    d.alımTarihi = Convert.ToDateTime(dtpDemirbasAlimTarihi.Value);
                    d.model = txtDemirbasModel.Text.ToLower().Trim();
                    d.marka = txtDemirbasEkleMarka.Text.ToLower().Trim();
                    db.Demirbas.Add(d);
                    db.SaveChanges();

                    Stok s = new Stok();//eklenen demirbaş aynı zamanda stok tablosunada kaydedilir.
                    s.Demirbas = d;
                    s.stokAdet = d.adet;
                    db.Stok.Add(s);
                    db.SaveChanges();
                    MessageBox.Show("Demirbaş başarıyla eklendi.");
                }
                txtDemirbasAdi.Text = "";
                cbDemirbasTuru.SelectedItem = null;
                cbDemirbasTuru.SelectedText = string.Empty;
                txtDemirbasEkleFiyat.Text = " ";
                txtDemirbasEkleAdet.Text = " ";
                txtDemirbasModel.Text = " ";
                txtDemirbasEkleMarka.Text = " ";
            }
            else//boş alan kaldıysa
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
            }
        }

        private void txtDemirbasAdi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }
        private void txtDemirbasEkleFiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtDemirbasEkleAdet_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
        //--DEMİRBAŞ EKLE EKRANI



        //--DEMİRBAŞ GÜNCELLE EKRANI
        private void txtDemirbasGuncelleModel_Leave(object sender, EventArgs e)
        {
            if (txtDemirbasGuncelleAd.Text != "" && txtDemirbasGuncelleMarka.Text != "" && txtDemirbasGuncelleModel.Text!="")
            {
                Demirbas d = db.Demirbas.FirstOrDefault(x => x.demirbasAdi == txtDemirbasGuncelleAd.Text.ToLower().Trim() && x.marka == txtDemirbasGuncelleMarka.Text.ToLower().Trim() && x.model == txtDemirbasGuncelleModel.Text.ToLower().Trim());
                if (d != null)//demirbaş daha önceden eklendiyse güncelleme işlemi yapılır.
                {
                    cbDemirbasGuncelleTur.SelectedItem = d.DemirbasTur.demirbasTuruAdi;
                    txtDemirbasGuncelleFiyat.Text = d.fiyat.ToString();
                    dtpDemirbasGuncelleAlimTarihi.Value = d.alımTarihi;
                    txtDemirbasGuncelleAdet.Text = d.adet.ToString();
                }
                else//demirbaş daha önceden eklenmediyse
                    MessageBox.Show("Böyle bir demirbaş bulunamadı.Henüz demirbaş eklenmediyse lütfen satın alma işlemleri ekranına gidiniz.");
     
            }
        }

        private void btnDemirbasGuncelle_Click(object sender, EventArgs e)
        {
            if(txtDemirbasGuncelleAd.Text!="" && txtDemirbasGuncelleMarka.Text!="" && txtDemirbasGuncelleModel.Text!="" && cbDemirbasGuncelleTur.SelectedItem!=null && txtDemirbasGuncelleFiyat.Text!="" && txtDemirbasGuncelleAdet.Text!="")
            {
                if (IsNumeric(txtDemirbasGuncelleFiyat.Text) && IsNumeric(txtDemirbasGuncelleAdet.Text))//fiyat ve adet alanları sayısalsa
                {
                    Demirbas d = db.Demirbas.FirstOrDefault(x => x.demirbasAdi == txtDemirbasGuncelleAd.Text.ToLower().Trim() && x.marka == txtDemirbasGuncelleMarka.Text.ToLower().Trim() && x.model == txtDemirbasGuncelleModel.Text.ToLower().Trim());//güncellenecek demirbaş bulunur.
                    if (d != null)//demirbaş daha önceden  eklenmişse demirbaş bilgileri güncellenir
                    {
                        d.demirbasAdi = txtDemirbasGuncelleAd.Text.ToLower().Trim();
                        d.marka = txtDemirbasGuncelleMarka.Text.ToLower().Trim();
                        d.model = txtDemirbasGuncelleMarka.Text.ToLower().Trim();
                        d.DemirbasTur = db.DemirbasTur.FirstOrDefault(x => x.demirbasTuruAdi == cbDemirbasGuncelleTur.SelectedItem.ToString());
                        d.fiyat = Convert.ToDecimal(txtDemirbasGuncelleFiyat.Text);
                        d.alımTarihi = dtpDemirbasGuncelleAlimTarihi.Value;
                        d.adet = Convert.ToInt32(txtDemirbasGuncelleAdet.Text);
                        db.SaveChanges();
                        MessageBox.Show("Demirbaş başarıyla güncellendi.");
                        txtDemirbasGuncelleAd.Text = "";
                        txtDemirbasGuncelleMarka.Text = "";
                        txtDemirbasGuncelleModel.Text = "";
                        txtDemirbasGuncelleFiyat.Text = "";
                        txtDemirbasGuncelleAdet.Text = "";
                        cbDemirbasGuncelleTur.SelectedItem = null;
                        cbDemirbasGuncelleTur.SelectedText = string.Empty;
                    }
                    else//daha önceden eklenmemişse
                        MessageBox.Show("Böyle bir demirbaş bulunamadı.Henüz demirbaş eklenmediyse lütfen satın alma işlemleri ekranına gidiniz.");
                }
                else
                    MessageBox.Show("Fiyat ve adet alanları sayısal olmalıdır.");            
            }
            else
                MessageBox.Show("Lütfen boş alan bırakmayınız.");
        }
        //--DEMİRBAŞ GÜNCELLE EKRANI


        //--DEMİRBAŞ LİSTELE EKRANI
        private void btnDemirbasListele_Click(object sender, EventArgs e)
        {
            List<localDemirbas> demirbaslar = new List<localDemirbas>();
            foreach (Demirbas d in db.Demirbas.ToList())
            {
                localDemirbas ld = new localDemirbas();
                ld.demirbasAdi = d.demirbasAdi;
                ld.marka = d.marka;
                ld.model = d.model;
                ld.demirbasTuru = d.DemirbasTur.demirbasTuruAdi;
                ld.alimTarihi = d.alımTarihi;
                ld.demirbasFiyati = d.fiyat;
                ld.demirbasAdeti = d.adet;
                demirbaslar.Add(ld);
            }
            dgvDemirbasListele.DataSource = demirbaslar;
            dgvDemirbasListele.Columns[0].Visible = false;
            dgvDemirbasListele.Columns[1].Visible = false;
            dgvDemirbasListele.Columns[7].Visible = false;
            this.dgvDemirbasListele.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

 
        //--DEMİRBAŞ LİSTELE EKRANI

        //--DEMİRBAŞ ARA EKRANI--
        public void DemirbasListele(Demirbas d, List<localDemirbas> demirbaslar,int stokAdet)
        {
            localDemirbas ld = new localDemirbas();
            ld.siraNumarasi = d.demirbasId;
            ld.demirbasAdi = d.demirbasAdi;
            ld.marka = d.marka;
            ld.model = d.model;
            ld.demirbasTuru = d.DemirbasTur.demirbasTuruAdi;
            ld.demirbasAdeti = d.adet;
            ld.demirbasStokAdeti = stokAdet;
            ld.demirbasFiyati = d.fiyat;
            ld.alimTarihi = d.alımTarihi;
            demirbaslar.Add(ld);
        }

        private void cbAramaKriteri_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbDemirbasAraAdi.SelectedItem = null;
            cbDemirbasAraAdi.SelectedText = string.Empty;
            cbDemirbasAraAdi.Items.Clear();

            if (cbAramaKriteri.SelectedItem != null)
            {
                if (cbAramaKriteri.SelectedIndex== 0)//arama kriteri adsa
                {
                    adMi = true;
                    turMu = false;
                    fiyatMi = false;
                    tarihMi = false;
                    adetMi = false;
                    //ad marka model inputları açılır.
                    lblAramaBilgi.Text = "Ad:";
                    lblAramaBilgi.Visible = true;
                    cbDemirbasAraAdi.Visible = true;
                    lblDemirbasAraMarka.Visible = true;
                    cbDemirbasAraMarka.Visible = true;
                    cbDemirbasAraTur.Visible = false;
                    dtpDemirbasAraAlimTarihi.Visible = false;
                    lblMin.Visible = false;
                    lblMax.Visible = false;
                    txtDemirbasAraMinFiyat.Visible = false;
                    txtDemirbasAraMaxFiyat.Visible = false;
                    lblCizgi.Visible = false;
                    txtDemirbasAraMinAdet.Visible = false;
                    txtDemirbasAraMaxAdet.Visible = false;


                    foreach (string d in db.Demirbas.ToList().Select(x => x.demirbasAdi).Distinct())//Demirbaşlardan aynı isme sahip olanları bir kez getirir.
                    {
                        cbDemirbasAraAdi.Items.Add(d);
                    }

                }
                else if (cbAramaKriteri.SelectedIndex== 1)//arama kriteri türse
                {
                    cbDemirbasAraTur.Items.Clear();
                    turMu = true;
                    adMi = false;
                    fiyatMi = false;
                    tarihMi = false;
                    adetMi = false;
                    //tür inputu açılır.
                    lblAramaBilgi.Text = "Tür:";
                    cbDemirbasAraTur.Visible = true;
                    cbDemirbasAraAdi.Visible = false;
                    lblDemirbasAraMarka.Visible = false;
                    cbDemirbasAraMarka.Visible = false;
                    lblMin.Visible = false;
                    lblMax.Visible = false;
                    txtDemirbasAraMinFiyat.Visible = false;
                    txtDemirbasAraMaxFiyat.Visible = false;
                    lblCizgi.Visible = false;
                    txtDemirbasAraMinAdet.Visible = false;
                    txtDemirbasAraMaxAdet.Visible = false;
                    dtpDemirbasAraAlimTarihi.Visible = false;
                    
                    foreach (DemirbasTur dt in db.DemirbasTur.ToList())//Demirbaş türleri çekilir.
                    {
                        cbDemirbasAraTur.Items.Add(dt.demirbasTuruAdi);
                    }
                }
                else if (cbAramaKriteri.SelectedIndex==2)//arama kriteri fiyatsa
                {
                    turMu = false;
                    adMi = false;
                    fiyatMi = true;
                    tarihMi = false;
                    adetMi = false;

                    //fiyat inputları açılır.
                    lblMin.Text = "Min TL:";
                    lblMin.Visible = true;
                    lblMax.Text = "Max TL";
                    lblMax.Visible = true;
                    txtDemirbasAraMinFiyat.Visible = true;
                    lblCizgi.Visible = true;
                    txtDemirbasAraMaxFiyat.Visible = true;
                    cbDemirbasAraAdi.Visible = false;
                    cbDemirbasAraTur.Visible = false;
                    lblAramaBilgi.Visible = false;
                    lblDemirbasAraMarka.Visible = false;
                    cbDemirbasAraMarka.Visible = false;
                    txtDemirbasAraMinAdet.Visible = false;
                    txtDemirbasAraMaxAdet.Visible = false;
                    dtpDemirbasAraAlimTarihi.Visible = false;
                }

                else if (cbAramaKriteri.SelectedIndex == 3)//arama kriteri alım tarihiyse
                {
                    turMu = false;
                    adMi = false;
                    fiyatMi = false;
                    tarihMi = true;
                    adetMi = false;
                    
                    //tarih inputları açılır.
                    lblAramaBilgi.Text = "Alım Tarihi:";
                    lblAramaBilgi.Visible = true;
                    cbDemirbasAraAdi.Visible = false;
                    lblDemirbasAraMarka.Visible = false;
                    cbDemirbasAraMarka.Visible = false;
                    cbDemirbasAraTur.Visible = false;
                    lblMin.Visible = false;
                    lblMax.Visible = false;
                    txtDemirbasAraMinFiyat.Visible = false;
                    txtDemirbasAraMaxFiyat.Visible = false;
                    lblCizgi.Visible = false;
                    dtpDemirbasAraAlimTarihi.Visible = true;
                    txtDemirbasAraMinAdet.Visible = false;
                    txtDemirbasAraMaxAdet.Visible = false;

                }

                else if(cbAramaKriteri.SelectedIndex ==4)//arama kriteri adetse
                {
                    turMu = false;
                    adMi = false;
                    fiyatMi = false;
                    tarihMi = false;
                    adetMi = true;

                    //adet inputları açılır.
                    lblMin.Text = "Min Adet:";
                    lblMin.Visible = true;
                    lblMax.Text = "Max Adet:";
                    lblMax.Visible = true;
                    lblCizgi.Visible = true;
                    txtDemirbasAraMinAdet.Visible = true;
                    txtDemirbasAraMaxAdet.Visible = true;
                    txtDemirbasAraMinFiyat.Visible = false;
                    txtDemirbasAraMaxFiyat.Visible = false;
                    lblAramaBilgi.Visible = false;
                    lblDemirbasAraMarka.Visible = false;
                    cbDemirbasAraMarka.Visible = false;
                    cbDemirbasAraAdi.Visible = false;
                    cbDemirbasAraTur.Visible = false;                  
                    dtpDemirbasAraAlimTarihi.Visible = false;
                }

            }
        }

        private void cbDemirbasAraAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbDemirbasAraAdi.SelectedItem!=null)
            {
                cbDemirbasAraMarka.Items.Clear();
                cbDemirbasAraMarka.SelectedItem = null;
                cbDemirbasAraMarka.Text = string.Empty;

                foreach (var m in db.Demirbas.Where(x => x.demirbasAdi == cbDemirbasAraAdi.SelectedItem.ToString()).Select(x => x.marka).Distinct())//Seçilen demirbaş adına göre o demirbaş adına ait olan markaları aynı marka birden fazla gelmicek şekilde getirilir.
                {
                    cbDemirbasAraMarka.Items.Add(m);
                }
            }
           
        }

        private void btnKritereGoreAra_Click(object sender, EventArgs e)
        {
            if (cbAramaKriteri.SelectedItem != null)
            {
                Stok s;

                List<localDemirbas> demirbaslar = new List<localDemirbas>();

                if (adMi)//demirbaş adına göre arama yapılacaksa
                {      
                    if(cbDemirbasAraAdi.SelectedItem != null)
                    {
                        if (cbDemirbasAraMarka.SelectedItem == null)//sadece adına göre arama yapılcaksa 
                        {
                            foreach (Demirbas d in db.Demirbas.Where(x => x.demirbasAdi == cbDemirbasAraAdi.SelectedItem.ToString()))//seçilen ada göre demirbaşlar getirilir.
                            {
                                s = db.Stok.FirstOrDefault(x => x.demirbasId == d.demirbasId);
                                DemirbasListele(d, demirbaslar, s.stokAdet);
                            }
                        }
                        else//adı ve markasına göre arama yapılcaksa 
                        {
                            foreach (Demirbas d in db.Demirbas.Where(x => x.demirbasAdi == cbDemirbasAraAdi.SelectedItem.ToString() && x.marka == cbDemirbasAraMarka.SelectedItem.ToString()))//seçilen ada ve markaya göre demirbaşlar getirilir.
                            {
                                s = db.Stok.FirstOrDefault(x => x.demirbasId == d.demirbasId);
                                DemirbasListele(d, demirbaslar, s.stokAdet);
                            }
                        }
                    }
                    else
                        MessageBox.Show("Lütfen demirbaş adını seçiniz.");
                }
    


                if (turMu)//demirbaş türüne göre arama yapılacaksa
                {    
                    if(cbDemirbasAraTur.SelectedItem != null)
                    {

                        foreach (Demirbas d in db.Demirbas.Where(x => x.DemirbasTur.demirbasTuruAdi == cbDemirbasAraTur.SelectedItem.ToString()))//seçilen türe göre demirbaşlar getirilir.
                        {
                            s = db.Stok.FirstOrDefault(x => x.demirbasId == d.demirbasId);
                            DemirbasListele(d, demirbaslar, s.stokAdet);
                        }
                    }
                    else
                        MessageBox.Show("Lütfen demirbaş türünü seçiniz.");
                }
              

                if (fiyatMi)//demirbaş fiyatına göre arama yapılacaksa
                {  
                    if(txtDemirbasAraMinFiyat.Text != "" && txtDemirbasAraMaxFiyat.Text != "")
                    {
                        decimal fiyatMax = Convert.ToDecimal(txtDemirbasAraMaxFiyat.Text);
                        decimal fiyatMin = Convert.ToDecimal(txtDemirbasAraMinFiyat.Text);
                        if (fiyatMax > fiyatMin)
                        {
                            foreach (Demirbas d in db.Demirbas.Where(x => x.fiyat <= fiyatMax && x.fiyat >= fiyatMin))
                            {
                                s = db.Stok.FirstOrDefault(x => x.demirbasId == d.demirbasId);
                                DemirbasListele(d, demirbaslar, s.stokAdet);
                            }
                        }
                        else if (fiyatMax == fiyatMin)
                        {
                            MessageBox.Show("Max ve Min fiyat eşit olamaz!");
                        }
                        else
                        {
                            MessageBox.Show("Minumum fiyat maximum fiyatdan büyük olamaz!");
                        }
                    }
                    else
                        MessageBox.Show("Lütfen fiyat alanlarını doldurunuz.");
                }


                if (tarihMi)//demirbaş alım tarihine göre arama yapılacaksa
                {
                    foreach (Demirbas d in db.Demirbas.Where(x => x.alımTarihi.Year == dtpDemirbasAraAlimTarihi.Value.Year && x.alımTarihi.Month == dtpDemirbasAraAlimTarihi.Value.Month && x.alımTarihi.Day == dtpDemirbasAraAlimTarihi.Value.Day))
                    {
                        s = db.Stok.FirstOrDefault(x => x.demirbasId == d.demirbasId);
                        DemirbasListele(d, demirbaslar, s.stokAdet);
                    }
                }

                if (adetMi)//demirbaş adetine göre arama yapılacaksa
                { 
                    if(txtDemirbasAraMinAdet.Text != "" && txtDemirbasAraMaxAdet.Text != "")
                    {
                        if (IsNumeric(txtDemirbasAraMinAdet.Text) && IsNumeric(txtDemirbasAraMaxAdet.Text))
                        {
                            int minAdet = Convert.ToInt32(txtDemirbasAraMinAdet.Text);
                            int maxAdet = Convert.ToInt32(txtDemirbasAraMaxAdet.Text);
                            if (maxAdet > minAdet)
                            {
                                foreach (Demirbas d in db.Demirbas.Where(x => x.adet <= maxAdet && x.adet >= minAdet))
                                {
                                    s = db.Stok.FirstOrDefault(x => x.demirbasId == d.demirbasId);
                                    DemirbasListele(d, demirbaslar, s.stokAdet);
                                }
                            }
                            else if (maxAdet == minAdet)
                            {
                                MessageBox.Show("Max ve Min adet eşit olamaz!");
                            }
                            else
                            {
                                MessageBox.Show("Minumum adet maximum adetten büyük olamaz!");
                            }
                        }
                        else
                            MessageBox.Show("Adet alanları sayısal olmalıdır.");
                    }
                    else
                        MessageBox.Show("Lütfen adet alanlarını doldurunuz.");
                }
           

                dgvDemirbasAra.DataSource = demirbaslar;
                dgvDemirbasAra.Columns[1].Visible = false;
                dgvDemirbasAra.Columns[0].HeaderText = "Sıra Numarası";
                dgvDemirbasAra.Columns[2].HeaderText = "Demirbaş Adı";
                dgvDemirbasAra.Columns[3].HeaderText = "Marka";
                dgvDemirbasAra.Columns[4].HeaderText = "Model";
                dgvDemirbasAra.Columns[5].HeaderText = "Tür";
                dgvDemirbasAra.Columns[6].HeaderText = "Adet";
                dgvDemirbasAra.Columns[7].HeaderText = "Stok Adeti";
                dgvDemirbasAra.Columns[8].HeaderText = "Fiyatı";
                dgvDemirbasAra.Columns[9].HeaderText = "Alım Tarihi";

                this.dgvDemirbasAra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                cbDemirbasAraTur.SelectedItem = null;
                cbDemirbasAraTur.SelectedText = string.Empty;
                cbDemirbasAraAdi.SelectedItem = null;
                cbDemirbasAraAdi.SelectedText = string.Empty;
                cbDemirbasAraMarka.SelectedItem = null;
                cbDemirbasAraMarka.SelectedText = string.Empty;
                txtDemirbasAraMinAdet.Text = "";
                txtDemirbasAraMaxAdet.Text = "";
            }
            else
                MessageBox.Show("Lütfen arama kriterini seçiniz.");  
        }
        //--DEMİRBAŞ ARA EKRANI--

    }
}
