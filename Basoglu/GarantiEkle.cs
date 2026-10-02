using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Basoglu.database;

namespace Basoglu
{
    public partial class GarantiEkle : Form
    {
        public GarantiEkle()
        {
            InitializeComponent();
        }


        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string urunIsmi = txtUrunIsmi.Text.Trim();
            string seriNo = string.IsNullOrWhiteSpace(txtSeriNo.Text) ? null : txtSeriNo.Text.Trim();
            string firmaIsmi = string.IsNullOrWhiteSpace(txtFirma.Text) ? null : txtFirma.Text.Trim();
            string kargoIsmi = string.IsNullOrWhiteSpace(txtKargo.Text) ? null : txtKargo.Text.Trim();
            string aliciMarka = string.IsNullOrWhiteSpace(txtAlanMarka.Text) ? null : txtAlanMarka.Text.Trim();
            string kargoNo = string.IsNullOrWhiteSpace(txtTakipNo.Text) ? null : txtTakipNo.Text.Trim();

            DateTime? gonderilmeTarihi = null;
            if (!string.IsNullOrWhiteSpace(txtGonderilmeTarihi.Text))
            {
                if (DateTime.TryParseExact(txtGonderilmeTarihi.Text.Trim(), "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime gonderilme))
                {
                    gonderilmeTarihi = gonderilme;
                }
                else
                {
                    MessageBox.Show("Geçerli bir gönderilme tarihi giriniz (örn. 19.03.2025).");
                    return;
                }
            }

            DateTime? alisTarihi = null;
            if (!string.IsNullOrWhiteSpace(txtAlisTarihi.Text))
            {
                if (DateTime.TryParseExact(txtAlisTarihi.Text.Trim(), "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime alis))
                {
                    alisTarihi = alis;
                }
                else
                {
                    MessageBox.Show("Geçerli bir alış tarihi giriniz (örn. 19.03.2025).");
                    return;
                }
            }

            decimal? ucret = null;
            if (!string.IsNullOrWhiteSpace(txtUcret.Text))
            {
                if (decimal.TryParse(txtUcret.Text.Trim(), out decimal parsedUcret))
                {
                    ucret = parsedUcret;
                }
                else
                {
                    MessageBox.Show("Geçerli bir ücret giriniz (örn. 100.50).");
                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(urunIsmi))
            {
                MessageBox.Show("Ürün ismi boş bırakılamaz.");
                return;
            }

            string connStr = DbHelper.GetConnectionString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
        INSERT INTO Garanti 
        (Urun_ismi, Seri_no, Firma_ismi, Alici_marka, Kargo_ismi, Kargo_no, Gonderilme_tarihi, Alis_Tarihi, Ucret)
        VALUES 
        (@Urun_ismi, @Seri_no, @Firma_ismi, @Alici_marka, @Kargo_ismi, @Kargo_no, @Gonderilme_tarihi, @Alis_Tarihi, @Ucret)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Urun_ismi", urunIsmi);
                    cmd.Parameters.AddWithValue("@Seri_no", (object)seriNo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Firma_ismi", (object)firmaIsmi ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Alici_marka", (object)aliciMarka ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Kargo_ismi", (object)kargoIsmi ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Kargo_no", (object)kargoNo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Gonderilme_tarihi", (object)gonderilmeTarihi ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Alis_Tarihi", (object)alisTarihi ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ucret", ucret.HasValue ? ucret.Value : 0);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Kayıt başarıyla eklendi.");

                        // ✅ Log yaz
                        string detay = $"Urun_ismi: \"{urunIsmi}\", " +
                                       $"Seri_no: \"{seriNo ?? "boş"}\", Firma_ismi: \"{firmaIsmi ?? "boş"}\", " +
                                       $"Alici_marka: \"{aliciMarka ?? "boş"}\", Kargo_ismi: \"{kargoIsmi ?? "boş"}\", " +
                                       $"Kargo_no: \"{kargoNo ?? "boş"}\", " +
                                       $"Gonderilme_tarihi: {(gonderilmeTarihi?.ToString("yyyy-MM-dd") ?? "boş")}, " +
                                       $"Alis_Tarihi: {(alisTarihi?.ToString("yyyy-MM-dd") ?? "boş")}, " +
                                       $"Ucret: {(ucret.HasValue ? ucret.Value.ToString("F2") : "0")}";

                        Helpers.Logger.Log("Ekleme", "Garanti", detay);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata oluştu: " + ex.Message);
                    }
                }
            }
        }


    }
}
