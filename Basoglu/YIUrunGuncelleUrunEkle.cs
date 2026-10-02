using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Basoglu.Helpers;

namespace Basoglu
{
    public partial class YIUrunGuncelleUrunEkle : Form
    {
        private int yapilanIsId;

        public YIUrunGuncelleUrunEkle(int yapilanIsId)
        {
            InitializeComponent();
            
            this.yapilanIsId = yapilanIsId;
        }


       

        private void LoadFormIntoPanel(Form childForm)
        {
            panelUrun.Controls.Clear(); // Öncekini temizle

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill; // Otomatik büyümesin
            int newWidth = (int)(childForm.Width * 1.5);
            int newHeight = (int)(childForm.Height * 1.5);
            this.Size = new Size(newWidth, newHeight);
            this.MinimumSize = new Size(newWidth, newHeight);
            panelUrun.Controls.Add(childForm);

            childForm.Show();
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            string connStr = database.DbHelper.GetConnectionString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    foreach (var urun in YIUrunler.Urunler)
                    {
                        object modelParam = string.IsNullOrWhiteSpace(urun.ModelNumarasi) ? DBNull.Value : (object)urun.ModelNumarasi;
                        object seriParam = string.IsNullOrWhiteSpace(urun.SeriNo) ? DBNull.Value : (object)urun.SeriNo;

                        // ❌ Kontrol: Aynı ürün zaten eklenmiş mi?
                        SqlCommand kontrolCmd = new SqlCommand(
                            @"SELECT COUNT(*) FROM YIUrunler 
                      WHERE Yapilan_is_id = @Yid AND Urun_ismi = @Urun 
                      AND (Model_numarasi = @Model OR (Model_numarasi IS NULL AND @Model IS NULL))
                      AND (Seri_no = @Seri OR (Seri_no IS NULL AND @Seri IS NULL))", conn, trans);

                        kontrolCmd.Parameters.AddWithValue("@Yid", yapilanIsId);
                        kontrolCmd.Parameters.AddWithValue("@Urun", urun.UrunIsmi);
                        kontrolCmd.Parameters.AddWithValue("@Model", modelParam);
                        kontrolCmd.Parameters.AddWithValue("@Seri", seriParam);

                        int varMi = (int)kontrolCmd.ExecuteScalar();
                        if (varMi > 0)
                        {
                            throw new Exception($"Aynı ürün daha önce eklenmiş: {urun.UrunIsmi} - Model: {urun.ModelNumarasi ?? "Yok"} - Seri: {urun.SeriNo ?? "Yok"}");
                        }

                        if (urun.Kaynak)
                        {
                            SqlCommand stokKontrolCmd = new SqlCommand(
                                @"SELECT Miktar FROM Urunler 
                          WHERE Urun_ismi = @isim 
                          AND (Model_numarasi = @model OR (Model_numarasi IS NULL AND @model IS NULL) OR (Model_numarasi = '' AND @model = ''))
                          AND (seri_no = @seri OR (seri_no IS NULL AND @seri IS NULL) OR (seri_no = '' AND @seri = ''))",
                                conn, trans);

                            stokKontrolCmd.Parameters.AddWithValue("@isim", urun.UrunIsmi);
                            stokKontrolCmd.Parameters.AddWithValue("@model", modelParam);
                            stokKontrolCmd.Parameters.AddWithValue("@seri", seriParam);

                            object stokObj = stokKontrolCmd.ExecuteScalar();
                            if (stokObj == null || stokObj == DBNull.Value)
                                throw new Exception($"Stokta böyle bir ürün bulunamadı: {urun.UrunIsmi}");

                            int mevcutStok = Convert.ToInt32(stokObj);
                            if (mevcutStok < urun.Miktar)
                                throw new Exception($"Yetersiz stok: {urun.UrunIsmi} (Mevcut: {mevcutStok}, Gerekli: {urun.Miktar})");

                            SqlCommand stokDusCmd = new SqlCommand(
                                @"UPDATE Urunler 
                          SET Miktar = Miktar - @adet 
                          WHERE Urun_ismi = @isim 
                          AND (Model_numarasi = @model OR (Model_numarasi IS NULL AND @model IS NULL) OR (Model_numarasi = '' AND @model = ''))
                          AND (seri_no = @seri OR (seri_no IS NULL AND @seri IS NULL) OR (seri_no = '' AND @seri = ''))",
                                conn, trans);

                            stokDusCmd.Parameters.AddWithValue("@adet", urun.Miktar);
                            stokDusCmd.Parameters.AddWithValue("@isim", urun.UrunIsmi);
                            stokDusCmd.Parameters.AddWithValue("@model", modelParam);
                            stokDusCmd.Parameters.AddWithValue("@seri", seriParam);
                            stokDusCmd.ExecuteNonQuery();

                            Logger.Log("Stok Güncelleme", "Urunler",
                                $"YapılanIsId: {yapilanIsId} | {urun.UrunIsmi} adlı ürün stoktan düşüldü. Miktar: {urun.Miktar}, Model: {urun.ModelNumarasi ?? "Yok"}, Seri: {urun.SeriNo ?? "Yok"}, Kalan tahmini: {mevcutStok - urun.Miktar}");
                        }

                        SqlCommand urunEkleCmd = new SqlCommand(
                            @"INSERT INTO YIUrunler (Yapilan_is_id, Urun_ismi, Model_numarasi, Seri_no, Miktar, kaynak)
                      VALUES (@Yid, @Urun, @Model, @Seri, @Miktar, @Kaynak)", conn, trans);

                        urunEkleCmd.Parameters.AddWithValue("@Yid", yapilanIsId);
                        urunEkleCmd.Parameters.AddWithValue("@Urun", urun.UrunIsmi);
                        urunEkleCmd.Parameters.AddWithValue("@Model", modelParam);
                        urunEkleCmd.Parameters.AddWithValue("@Seri", seriParam);
                        urunEkleCmd.Parameters.AddWithValue("@Miktar", urun.Miktar);
                        urunEkleCmd.Parameters.AddWithValue("@Kaynak", urun.Kaynak);
                        urunEkleCmd.ExecuteNonQuery();

                        Logger.Log("Ekleme", "YIUrunler",
                            $"YapılanIsId: {yapilanIsId} | Ürün eklendi: {urun.UrunIsmi}, Model: {urun.ModelNumarasi ?? "Yok"}, Seri: {urun.SeriNo ?? "Yok"}, Miktar: {urun.Miktar}, Kaynak: {(urun.Kaynak ? "Stok" : "Harici")}");
                    }

                    trans.Commit();
                    YIUrunler.Temizle();
                    MessageBox.Show("Ürünler başarıyla eklendi.");
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    YIUrunler.Temizle();
                    MessageBox.Show("İşlem iptal edildi: " + ex.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private void checkBoxStoktanEkle_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxStoktanEkle.Checked)
            {
                LoadFormIntoPanel(new YIStoktanUrunEkle());
            }
            else
            {
                LoadFormIntoPanel(new YIUrunEkle());
            }


        }

        private void btnUrunleriGoster_Click(object sender, EventArgs e)
        {
            Form form = new YIUrunleriGoster();
            form.ShowDialog();
        }
    }
}
