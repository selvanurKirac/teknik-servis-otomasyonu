using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Basoglu
{
    public partial class DisKaynakUrunGuncelle : Form
    {
        private int urunId;
        private YIUrunleriGuncelleMenu parentForm;

        public DisKaynakUrunGuncelle(int id, YIUrunleriGuncelleMenu parent)
        {
            InitializeComponent();
            urunId = id;
            parentForm = parent;
            UrunBilgileriniGetir();
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
                            txtUrunIsmi.Text = reader["Urun_ismi"].ToString();
                            txtModel.Text = reader["Model_numarasi"]?.ToString();
                            txtSeriNumarasi.Text = reader["Seri_no"]?.ToString();
                            txtStok.Text = reader["Miktar"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }





        private void btnDisKaynakUrunGuncelle_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            string urunIsmi = txtUrunIsmi.Text.Trim();
            string model = txtModel.Text.Trim();
            string seri = txtSeriNumarasi.Text.Trim();

            if (!int.TryParse(txtStok.Text.Trim(), out int miktar) || miktar < 0)
            {
                MessageBox.Show("Geçerli bir miktar girin.");
                this.Enabled = true;
                return;
            }

            if (string.IsNullOrWhiteSpace(urunIsmi))
            {
                MessageBox.Show("Ürün ismi boş olamaz.");
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
                    // 🔍 Eski verileri oku (log için)
                    string eskiIsim = "", eskiModel = "", eskiSeri = "";
                    int eskiMiktar = -1;

                    using (SqlCommand selectCmd = new SqlCommand("SELECT Urun_ismi, Model_numarasi, Seri_no, Miktar FROM YIUrunler WHERE id = @id", conn, trans))
                    {
                        selectCmd.Parameters.AddWithValue("@id", urunId);
                        using (SqlDataReader reader = selectCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                eskiIsim = reader["Urun_ismi"].ToString();
                                eskiModel = reader["Model_numarasi"] == DBNull.Value ? null : reader["Model_numarasi"].ToString();
                                eskiSeri = reader["Seri_no"] == DBNull.Value ? null : reader["Seri_no"].ToString();
                                eskiMiktar = Convert.ToInt32(reader["Miktar"]);
                            }
                        }
                    }

                    if (miktar == 0)
                    {
                        // ❌ Silme işlemi
                        SqlCommand silCmd = new SqlCommand("DELETE FROM YIUrunler WHERE id = @id", conn, trans);
                        silCmd.Parameters.AddWithValue("@id", urunId);
                        silCmd.ExecuteNonQuery();

                        trans.Commit();
                        MessageBox.Show("Ürün silindi.");
                        parentForm.UrunleriYukle();
                        this.Close();

                        // ✅ Log - Silme
                        string detay = $"UrunId: {urunId} | Silinen ürün: \"{eskiIsim}\" Model: \"{eskiModel ?? "boş"}\" Seri: \"{eskiSeri ?? "boş"}\" Miktar: {eskiMiktar}";
                        Helpers.Logger.Log("Silme", "YIUrunler", detay);
                        return;
                    }

                    // 🔧 Güncelleme işlemi
                    SqlCommand guncelleCmd = new SqlCommand(@"
                UPDATE YIUrunler SET 
                    Urun_ismi = @isim,
                    Model_numarasi = @model,
                    Seri_no = @seri,
                    Miktar = @miktar
                WHERE id = @id", conn, trans);

                    guncelleCmd.Parameters.AddWithValue("@isim", urunIsmi);
                    guncelleCmd.Parameters.AddWithValue("@model", string.IsNullOrEmpty(model) ? (object)DBNull.Value : model);
                    guncelleCmd.Parameters.AddWithValue("@seri", string.IsNullOrEmpty(seri) ? (object)DBNull.Value : seri);
                    guncelleCmd.Parameters.AddWithValue("@miktar", miktar);
                    guncelleCmd.Parameters.AddWithValue("@id", urunId);
                    guncelleCmd.ExecuteNonQuery();

                    trans.Commit();
                    MessageBox.Show("Ürün başarıyla güncellendi.");
                    parentForm.UrunleriYukle();
                    this.Close();

                    // ✅ Log - Sadece değişenleri yaz
                    List<string> degisenler = new List<string>();
                    if (eskiIsim != urunIsmi)
                        degisenler.Add($"Urun_ismi: \"{eskiIsim}\" → \"{urunIsmi}\"");
                    if ((eskiModel ?? "boş") != (model ?? "boş"))
                        degisenler.Add($"Model_numarasi: \"{eskiModel ?? "boş"}\" → \"{model ?? "boş"}\"");
                    if ((eskiSeri ?? "boş") != (seri ?? "boş"))
                        degisenler.Add($"Seri_no: \"{eskiSeri ?? "boş"}\" → \"{seri ?? "boş"}\"");
                    if (eskiMiktar != miktar)
                        degisenler.Add($"Miktar: {eskiMiktar} → {miktar}");

                    if (degisenler.Count > 0)
                    {
                        string detay = $"UrunId: {urunId} | " + string.Join(", ", degisenler);
                        Helpers.Logger.Log("Güncelleme", "YIUrunler", detay);
                    }
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                    this.Enabled = true;
                }
            }
        }

        private void lblStok_Click(object sender, EventArgs e)
        {

        }
    }
}
