using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Basoglu.Helpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Basoglu
{
    public partial class YapilanIsler : Form
    {
        public YapilanIsler()
        {
            InitializeComponent();
            ServisTuruYukle();
            FirmaListesiYukle();
            SonucYukle();
            




        }
        private void ServisTuruYukle()
        {
            cmbServis?.Items.Clear();
            cmbServis?.Items.AddRange(new string[] { "İşyerinde", "Firmada" });
        }

        private void SonucYukle()
        {
            cmbSonuc?.Items.Clear();
            cmbSonuc?.Items.AddRange(new string[] { "Tamamlandı", "Tamamlanmadı" });
        }


        private void FirmaListesiYukle()
        {
            string connStr = database.DbHelper.GetConnectionString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Firma_ismi FROM Firmalar", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cmbFirma.Items.Add(reader.GetString(0));
                }
                reader.Close();
            }
        }

        


        
        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            Form form = new YIUrunEkleMenu();
            form.ShowDialog();
            

        }

        private void btnUrunleriGoster_Click(object sender, EventArgs e)
        {
            Form form = new YIUrunleriGoster();
            form.ShowDialog();


        }

        private void btnCihazEkle_Click(object sender, EventArgs e)
        {
            Form form = new CihazTamir();
            form.ShowDialog();

        }

        private void btnCihazlariGoster_Click(object sender, EventArgs e)
        {
            Form form = new YICihazlariGoster();
            form.ShowDialog();
            
        }

        private void btnGaranti_Click(object sender, EventArgs e)
        {
            Form form = new GarantiMenu();
            form.ShowDialog();
        }

        private void btnToner_Click(object sender, EventArgs e)
        {
            Form form = new TonerMenu();
            form.ShowDialog();
        }

        private void btnIsEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbFirma.Text) ||
                string.IsNullOrWhiteSpace(cmbServis.Text) ||
                string.IsNullOrWhiteSpace(cmbSonuc.Text) ||
                string.IsNullOrWhiteSpace(txtFiyat.Text) ||
                string.IsNullOrWhiteSpace(txtTarih.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            string connStr = database.DbHelper.GetConnectionString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    SqlCommand cmd = new SqlCommand(
                        @"INSERT INTO Yapilan_Isler (Firma_ismi, Servis_turu, Aciklama, Sonuc, Fiyat, Tarih, Olusturulma_Tarihi, Degistirilme_Tarihi) 
                  OUTPUT INSERTED.id 
                  VALUES (@Firma, @ServisTuru, @Aciklama, @Sonuc, @Fiyat, @Tarih, @Now, @Now)", conn, trans);

                    cmd.Parameters.AddWithValue("@Firma", cmbFirma.Text.Trim());
                    cmd.Parameters.AddWithValue("@ServisTuru", cmbServis.SelectedItem.ToString() == "İşyerinde" ? 1 : 0);
                    cmd.Parameters.AddWithValue("@Aciklama", rtbAciklama.Text.Trim());
                    cmd.Parameters.AddWithValue("@Sonuc", cmbSonuc.SelectedItem.ToString() == "Tamamlandı" ? 1 : 0);
                    cmd.Parameters.AddWithValue("@Fiyat", decimal.Parse(txtFiyat.Text.Trim()));
                    cmd.Parameters.AddWithValue("@Tarih", DateTime.Parse(txtTarih.Text.Trim()));
                    cmd.Parameters.AddWithValue("@Now", DateTime.Now);

                    int yapilanIsId = (int)cmd.ExecuteScalar();

                    Logger.Log("Ekleme", "Yapilan_Isler", $"Yeni  {yapilanIsId} id'li  iş oluşturuldu. Firma: {cmbFirma.Text}, Servis Türü: {cmbServis.Text}, Sonuç: {cmbSonuc.Text}, Fiyat: {txtFiyat.Text} ₺, Tarih: {txtTarih.Text}");

                    foreach (var cihaz in YICihazlar.Cihazlar)
                    {
                        SqlCommand cihazCmd = new SqlCommand(
                            @"INSERT INTO YICihaz (Cihaz_ismi, Cihaz_Model, Cihaz_adet) 
                      OUTPUT INSERTED.id 
                      VALUES (@Isim, @CihazModel, @Adet)", conn, trans);

                        cihazCmd.Parameters.AddWithValue("@Isim", cihaz.Isim);
                        cihazCmd.Parameters.AddWithValue("@CihazModel", (object)cihaz.Cihaz_model ?? DBNull.Value);
                        cihazCmd.Parameters.AddWithValue("@Adet", cihaz.Adet);
                        int cihazId = (int)cihazCmd.ExecuteScalar();

                        Logger.Log("Ekleme", "YICihaz", $"{yapilanIsId} id'li  işe yeni bir cihaz eklendi: Cihaz ismi: {cihaz.Isim}, Model: {cihaz.Cihaz_model ?? "Yok"}, Adet: {cihaz.Adet}");

                        foreach (var firma in cihaz.ServisFirmalari)
                        {
                            SqlCommand tamirCmd = new SqlCommand(
                                @"INSERT INTO Cihaz_Tamir (Cihaz_id, Yapilan_is_id, Servis_firma_id, Alim_tarihi, Teslim_tarihi) 
                          VALUES (@CihazId, @YapilanIsId, @ServisFirmaId, @Alim, @Teslim)", conn, trans);

                            tamirCmd.Parameters.AddWithValue("@CihazId", cihazId);
                            tamirCmd.Parameters.AddWithValue("@YapilanIsId", yapilanIsId);
                            tamirCmd.Parameters.AddWithValue("@ServisFirmaId", firma.Id);
                            tamirCmd.Parameters.AddWithValue("@Alim", firma.AlimTarihi);
                            tamirCmd.Parameters.AddWithValue("@Teslim", (object)firma.TeslimTarihi ?? DBNull.Value);
                            tamirCmd.ExecuteNonQuery();

                            Logger.Log("Ekleme", "Cihaz_Tamir", $"{yapilanIsId} id'li  işdeki '{cihaz.Isim}' isimli cihaza yeni bir servis firmasına atandı. Firma ID: {firma.Id}, Servis Firmasının Alım Tarihi: {firma.AlimTarihi:dd.MM.yyyy}, Servis Firmasının Teslim Tarihi: {(firma.TeslimTarihi.HasValue ? firma.TeslimTarihi.Value.ToString("dd.MM.yyyy") : "Yok")}");
                        }
                    }

                    foreach (var urun in YIUrunler.Urunler)
                    {
                        if (urun.Kaynak)
                        {
                            SqlCommand stokKontrolCmd = new SqlCommand(
                                @"SELECT Miktar FROM Urunler 
                          WHERE Urun_ismi = @isim 
                          AND (Model_numarasi = @model OR Model_numarasi IS NULL)
                          AND (seri_no = @seri OR seri_no IS NULL)", conn, trans);

                            stokKontrolCmd.Parameters.AddWithValue("@isim", urun.UrunIsmi);
                            stokKontrolCmd.Parameters.AddWithValue("@model", (object)urun.ModelNumarasi ?? DBNull.Value);
                            stokKontrolCmd.Parameters.AddWithValue("@seri", (object)urun.SeriNo ?? DBNull.Value);

                            int mevcut = Convert.ToInt32(stokKontrolCmd.ExecuteScalar());

                            if (mevcut < urun.Miktar)
                                throw new Exception($"Yetersiz stok: {urun.UrunIsmi} (Mevcut: {mevcut})");

                            SqlCommand stokDusCmd = new SqlCommand(
                                @"UPDATE Urunler SET Miktar = Miktar - @adet 
                          WHERE Urun_ismi = @isim 
                          AND (Model_numarasi = @model OR Model_numarasi IS NULL)
                          AND (seri_no = @seri OR seri_no IS NULL)", conn, trans);

                            stokDusCmd.Parameters.AddWithValue("@adet", urun.Miktar);
                            stokDusCmd.Parameters.AddWithValue("@isim", urun.UrunIsmi);
                            stokDusCmd.Parameters.AddWithValue("@model", (object)urun.ModelNumarasi ?? DBNull.Value);
                            stokDusCmd.Parameters.AddWithValue("@seri", (object)urun.SeriNo ?? DBNull.Value);
                            stokDusCmd.ExecuteNonQuery();

                            Logger.Log("Stok Güncelleme", "Urunler", $"'{yapilanIsId} id'li işde kullanılan {urun.UrunIsmi}' isimli ürününden {urun.Miktar} adet stoktan düşüldü. Model: {urun.ModelNumarasi}, Seri No: {urun.SeriNo}, Kalan tahmini: {mevcut - urun.Miktar}");
                        }

                        SqlCommand urunEkle = new SqlCommand(
                            @"INSERT INTO YIUrunler (Yapilan_is_id, Urun_ismi, Model_numarasi, Seri_no, Miktar, kaynak) 
                      VALUES (@Yid, @Urun, @Model, @Seri, @Miktar, @Kaynak)", conn, trans);

                        urunEkle.Parameters.AddWithValue("@Yid", yapilanIsId);
                        urunEkle.Parameters.AddWithValue("@Urun", urun.UrunIsmi);
                        urunEkle.Parameters.AddWithValue("@Model", (object)urun.ModelNumarasi ?? DBNull.Value);
                        urunEkle.Parameters.AddWithValue("@Seri", (object)urun.SeriNo ?? DBNull.Value);
                        urunEkle.Parameters.AddWithValue("@Miktar", urun.Miktar);
                        urunEkle.Parameters.AddWithValue("@Kaynak", urun.Kaynak);
                        urunEkle.ExecuteNonQuery();

                        Logger.Log("Ekleme", "YIUrunler", $"Yapılan işe  ürün eklendi: {urun.UrunIsmi}, Model: {urun.ModelNumarasi}, Seri: {urun.SeriNo}, Miktar: {urun.Miktar}, Kaynak: {(urun.Kaynak ? "Stok" : "Harici")}");
                    }

                    trans.Commit();
                    MessageBox.Show("Kayıt başarıyla tamamlandı.");
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Hata oluştu ve işlemler iptal edildi.\n\n" + ex.Message);
                }
            }
        }

    }
}
