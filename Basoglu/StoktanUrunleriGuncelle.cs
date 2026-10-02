using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Basoglu
{
    public partial class StoktanUrunleriGuncelle : Form
    {
        private int urunId;
        private int eskiMiktar;
        private string urunIsmi, model, seri;
        private YIUrunleriGuncelleMenu parentForm;


        public StoktanUrunleriGuncelle(int id, YIUrunleriGuncelleMenu parentForm)
        {
            InitializeComponent();
            urunId = id;
            UrunBilgileriniGetir();
            this.parentForm = parentForm;
        }

        private void btnStoktanUrunGuncelle_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            if (!int.TryParse(txtStok.Text.Trim(), out int yeniMiktar) || yeniMiktar < 0)
            {
                MessageBox.Show("Geçerli bir miktar girin.");
                this.Enabled = true;
                return;
            }

            string connStr = database.DbHelper.GetConnectionString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    // Eski miktarı al
                    SqlCommand eskiCmd = new SqlCommand("SELECT Miktar FROM YIUrunler WHERE id = @id", conn, trans);
                    eskiCmd.Parameters.AddWithValue("@id", urunId);
                    int eskiMiktar = Convert.ToInt32(eskiCmd.ExecuteScalar());

                    // Mevcut stok miktarını al
                    SqlCommand stokCmd = new SqlCommand(@"
                SELECT Miktar FROM Urunler 
                WHERE Urun_ismi = @isim AND 
                      (Model_numarasi = @model OR (Model_numarasi IS NULL AND @model IS NULL)) AND 
                      (Seri_no = @seri OR (Seri_no IS NULL AND @seri IS NULL))", conn, trans);

                    stokCmd.Parameters.AddWithValue("@isim", urunIsmi);
                    stokCmd.Parameters.AddWithValue("@model", string.IsNullOrEmpty(model) ? (object)DBNull.Value : model);
                    stokCmd.Parameters.AddWithValue("@seri", string.IsNullOrEmpty(seri) ? (object)DBNull.Value : seri);

                    int mevcutStok = Convert.ToInt32(stokCmd.ExecuteScalar());
                    int maxVerilebilecek = mevcutStok + eskiMiktar;

                    // Sıfırsa sil
                    if (yeniMiktar == 0)
                    {
                        SqlCommand silCmd = new SqlCommand("DELETE FROM YIUrunler WHERE id = @id", conn, trans);
                        silCmd.Parameters.AddWithValue("@id", urunId);
                        silCmd.ExecuteNonQuery();

                        SqlCommand iadeCmd = new SqlCommand(@"
                    UPDATE Urunler 
                    SET Miktar = Miktar + @iade 
                    WHERE Urun_ismi = @isim AND 
                          (Model_numarasi = @model OR (Model_numarasi IS NULL AND @model IS NULL)) AND 
                          (Seri_no = @seri OR (Seri_no IS NULL AND @seri IS NULL))", conn, trans);

                        iadeCmd.Parameters.AddWithValue("@iade", eskiMiktar);
                        iadeCmd.Parameters.AddWithValue("@isim", urunIsmi);
                        iadeCmd.Parameters.AddWithValue("@model", string.IsNullOrEmpty(model) ? (object)DBNull.Value : model);
                        iadeCmd.Parameters.AddWithValue("@seri", string.IsNullOrEmpty(seri) ? (object)DBNull.Value : seri);
                        iadeCmd.ExecuteNonQuery();

                        trans.Commit();

                        string detay = $"UrunId: {urunId} | Urun: \"{urunIsmi}\" Model: \"{(model ?? "boş")}\" Seri: \"{(seri ?? "boş")}\" silindi. İade edilen miktar: {eskiMiktar}";
                        Helpers.Logger.Log("Silme", "YIUrunler", detay);

                        MessageBox.Show("Miktar sıfır olduğu için ürün silindi. Stok güncellendi.");
                        parentForm.UrunleriYukle();
                        this.Enabled = true;
                        return;
                    }

                    if (yeniMiktar > maxVerilebilecek)
                    {
                        trans.Rollback();
                        MessageBox.Show($"Stokta bu kadar ürün yok. En fazla verilebilecek miktar: {maxVerilebilecek}");
                        this.Enabled = true;
                        return;
                    }

                    int fark = yeniMiktar - eskiMiktar;

                    if (fark != 0)
                    {
                        SqlCommand stokUpdateCmd = new SqlCommand(@"
                    UPDATE Urunler 
                    SET Miktar = Miktar - @fark 
                    WHERE Urun_ismi = @isim AND 
                          (Model_numarasi = @model OR (Model_numarasi IS NULL AND @model IS NULL)) AND 
                          (Seri_no = @seri OR (Seri_no IS NULL AND @seri IS NULL))", conn, trans);

                        stokUpdateCmd.Parameters.AddWithValue("@fark", fark);
                        stokUpdateCmd.Parameters.AddWithValue("@isim", urunIsmi);
                        stokUpdateCmd.Parameters.AddWithValue("@model", string.IsNullOrEmpty(model) ? (object)DBNull.Value : model);
                        stokUpdateCmd.Parameters.AddWithValue("@seri", string.IsNullOrEmpty(seri) ? (object)DBNull.Value : seri);
                        stokUpdateCmd.ExecuteNonQuery();
                    }

                    SqlCommand guncelleCmd = new SqlCommand("UPDATE YIUrunler SET Miktar = @miktar WHERE id = @id", conn, trans);
                    guncelleCmd.Parameters.AddWithValue("@miktar", yeniMiktar);
                    guncelleCmd.Parameters.AddWithValue("@id", urunId);
                    guncelleCmd.ExecuteNonQuery();

                    trans.Commit();

                    if (fark != 0)
                    {
                        string detay = $"UrunId: {urunId} | Urun: \"{urunIsmi}\" Model: \"{(model ?? "boş")}\" Seri: \"{(seri ?? "boş")}\" Miktar: {eskiMiktar} → {yeniMiktar} | Stok farkı: {fark}";
                        Helpers.Logger.Log("Güncelleme", "YIUrunler", detay);
                    }

                    parentForm.UrunleriYukle();
                    MessageBox.Show("Ürün miktarı başarıyla güncellendi.");
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    parentForm.UrunleriYukle();
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }

                this.Enabled = true;
            }
        }




        private void UrunBilgileriniGetir()
        {
            try
            {
                string connStr = database.DbHelper.GetConnectionString();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM YIUrunler WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", urunId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            eskiMiktar = Convert.ToInt32(reader["Miktar"]);
                            urunIsmi = reader["Urun_ismi"].ToString();
                            model = reader["Model_numarasi"]?.ToString();
                            seri = reader["Seri_no"]?.ToString();

                            txtStok.Text = eskiMiktar.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        
    }
}
