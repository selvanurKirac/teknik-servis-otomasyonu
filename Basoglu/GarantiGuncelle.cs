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
    public partial class GarantiGuncelle : Form
    {
        private int secilenGarantiId = -1; // Seçilen garanti kaydının ID'si
        public GarantiGuncelle()
        {
            InitializeComponent();
            KayitlariListele();
        }

        

        private void KayitlariListele()
        {
            string connStr = DbHelper.GetConnectionString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM Garanti ORDER BY id DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
       

      
        
        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string urunIsmi = txtUrunIsmi.Text.Trim();
            string seriNo = txtSeriNo.Text.Trim();
            string firmaIsmi = txtFirma.Text.Trim();
            string kargoIsmi = txtKargo.Text.Trim();
            string aliciMarka = txtAlanMarka.Text.Trim();
            string kargoNo = txtTakipNo.Text.Trim();
            string gonderilmeTarihi = txtGonderilmeTarihi.Text.Trim();
            string alisTarihi = txtAlisTarihi.Text.Trim();
            string ucret = txtUcret.Text.Trim();

            string connStr = DbHelper.GetConnectionString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                StringBuilder query = new StringBuilder("SELECT * FROM Garanti WHERE 1=1");

                List<SqlParameter> parameters = new List<SqlParameter>();

                if (!string.IsNullOrWhiteSpace(urunIsmi))
                {
                    query.Append(" AND Urun_ismi LIKE @urunIsmi");
                    parameters.Add(new SqlParameter("@urunIsmi", "%" + urunIsmi + "%"));
                }

                if (!string.IsNullOrWhiteSpace(seriNo))
                {
                    query.Append(" AND Seri_no LIKE @seriNo");
                    parameters.Add(new SqlParameter("@seriNo", "%" + seriNo + "%"));
                }

                if (!string.IsNullOrWhiteSpace(firmaIsmi))
                {
                    query.Append(" AND Firma_ismi LIKE @firmaIsmi");
                    parameters.Add(new SqlParameter("@firmaIsmi", "%" + firmaIsmi + "%"));
                }

                if (!string.IsNullOrWhiteSpace(kargoIsmi))
                {
                    query.Append(" AND Kargo_ismi LIKE @kargoIsmi");
                    parameters.Add(new SqlParameter("@kargoIsmi", "%" + kargoIsmi + "%"));
                }

                if (!string.IsNullOrWhiteSpace(aliciMarka))
                {
                    query.Append(" AND Alici_marka LIKE @aliciMarka");
                    parameters.Add(new SqlParameter("@aliciMarka", "%" + aliciMarka + "%"));
                }

                if (!string.IsNullOrWhiteSpace(kargoNo))
                {
                    query.Append(" AND Kargo_no LIKE @kargoNo");
                    parameters.Add(new SqlParameter("@kargoNo", "%" + kargoNo + "%"));
                }

                if (!string.IsNullOrWhiteSpace(gonderilmeTarihi))
                {
                    query.Append(" AND CONVERT(varchar, Gonderilme_tarihi, 23) = @gonderilmeTarihi");
                    parameters.Add(new SqlParameter("@gonderilmeTarihi", gonderilmeTarihi));
                }

                if (!string.IsNullOrWhiteSpace(alisTarihi))
                {
                    query.Append(" AND CONVERT(varchar, Alis_Tarihi, 23) = @alisTarihi");
                    parameters.Add(new SqlParameter("@alisTarihi", alisTarihi));
                }

                if (!string.IsNullOrWhiteSpace(ucret))
                {
                    query.Append(" AND CAST(Ucret AS varchar) LIKE @ucret");
                    parameters.Add(new SqlParameter("@ucret", "%" + ucret + "%"));
                }

                SqlDataAdapter da = new SqlDataAdapter(query.ToString(), conn);
                foreach (var p in parameters)
                {
                    da.SelectCommand.Parameters.Add(p);
                }

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }

        }

        private void btnGuncelle_Click_1(object sender, EventArgs e)
        {
            if (secilenGarantiId == -1)
            {
                MessageBox.Show("Lütfen güncellenecek bir kayıt seçin.");
                return;
            }

            string urunIsmi = txtUrunIsmi.Text.Trim();
            if (string.IsNullOrWhiteSpace(urunIsmi))
            {
                MessageBox.Show("Ürün ismi boş olamaz.");
                return;
            }

            string seriNo = string.IsNullOrWhiteSpace(txtSeriNo.Text) ? null : txtSeriNo.Text.Trim();
            string firmaIsmi = string.IsNullOrWhiteSpace(txtFirma.Text) ? null : txtFirma.Text.Trim();
            string kargoIsmi = string.IsNullOrWhiteSpace(txtKargo.Text) ? null : txtKargo.Text.Trim();
            string aliciMarka = string.IsNullOrWhiteSpace(txtAlanMarka.Text) ? null : txtAlanMarka.Text.Trim();
            string kargoNo = string.IsNullOrWhiteSpace(txtTakipNo.Text) ? null : txtTakipNo.Text.Trim();

            DateTime? gonderilmeTarihi = null;
            if (!string.IsNullOrWhiteSpace(txtGonderilmeTarihi.Text))
            {
                if (!DateTime.TryParseExact(txtGonderilmeTarihi.Text.Trim(), "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime gonderilme))
                {
                    MessageBox.Show("Geçerli bir gönderilme tarihi giriniz. (örn. 19.03.2025)");
                    return;
                }
                gonderilmeTarihi = gonderilme;
            }

            DateTime? alisTarihi = null;
            if (!string.IsNullOrWhiteSpace(txtAlisTarihi.Text))
            {
                if (!DateTime.TryParseExact(txtAlisTarihi.Text.Trim(), "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime alis))
                {
                    MessageBox.Show("Geçerli bir alış tarihi giriniz. (örn. 19.03.2025)");
                    return;
                }
                alisTarihi = alis;
            }

            decimal? ucret = null;
            if (!string.IsNullOrWhiteSpace(txtUcret.Text))
            {
                if (!decimal.TryParse(txtUcret.Text.Trim(), out decimal parsedUcret))
                {
                    MessageBox.Show("Geçerli bir ücret giriniz. (örn. 100.50)");
                    return;
                }
                ucret = parsedUcret;
            }

            string connStr = DbHelper.GetConnectionString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // 🔍 Eski verileri getir
                string eskiUrun = "", eskiSeri = "", eskiFirma = "", eskiKargo = "", eskiAlici = "", eskiKargoNo = "";
                DateTime? eskiGonderilme = null, eskiAlis = null;
                decimal? eskiUcret = null;

                using (SqlCommand getCmd = new SqlCommand("SELECT * FROM Garanti WHERE id = @id", conn))
                {
                    getCmd.Parameters.AddWithValue("@id", secilenGarantiId);
                    using (SqlDataReader reader = getCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            eskiUrun = reader["Urun_ismi"]?.ToString();
                            eskiSeri = reader["Seri_no"] as string;
                            eskiFirma = reader["Firma_ismi"] as string;
                            eskiKargo = reader["Kargo_ismi"] as string;
                            eskiAlici = reader["Alici_marka"] as string;
                            eskiKargoNo = reader["Kargo_no"] as string;
                            eskiGonderilme = reader["Gonderilme_tarihi"] as DateTime?;
                            eskiAlis = reader["Alis_Tarihi"] as DateTime?;
                            eskiUcret = reader["Ucret"] != DBNull.Value ? (decimal?)reader["Ucret"] : null;
                        }
                    }
                }

                // 🔍 Değişiklikleri topla
                List<string> degisenler = new List<string>();
                if (eskiUrun != urunIsmi)
                    degisenler.Add($"Urun_ismi: \"{eskiUrun}\" → \"{urunIsmi}\"");
                if ((eskiSeri ?? "boş") != (seriNo ?? "boş"))
                    degisenler.Add($"Seri_no: \"{eskiSeri ?? "boş"}\" → \"{seriNo ?? "boş"}\"");
                if ((eskiFirma ?? "boş") != (firmaIsmi ?? "boş"))
                    degisenler.Add($"Firma_ismi: \"{eskiFirma ?? "boş"}\" → \"{firmaIsmi ?? "boş"}\"");
                if ((eskiKargo ?? "boş") != (kargoIsmi ?? "boş"))
                    degisenler.Add($"Kargo_ismi: \"{eskiKargo ?? "boş"}\" → \"{kargoIsmi ?? "boş"}\"");
                if ((eskiAlici ?? "boş") != (aliciMarka ?? "boş"))
                    degisenler.Add($"Alici_marka: \"{eskiAlici ?? "boş"}\" → \"{aliciMarka ?? "boş"}\"");
                if ((eskiKargoNo ?? "boş") != (kargoNo ?? "boş"))
                    degisenler.Add($"Kargo_no: \"{eskiKargoNo ?? "boş"}\" → \"{kargoNo ?? "boş"}\"");
                if ((eskiGonderilme?.ToString("yyyy-MM-dd") ?? "boş") != (gonderilmeTarihi?.ToString("yyyy-MM-dd") ?? "boş"))
                    degisenler.Add($"Gonderilme_tarihi: {eskiGonderilme?.ToString("yyyy-MM-dd") ?? "boş"} → {gonderilmeTarihi?.ToString("yyyy-MM-dd") ?? "boş"}");
                if ((eskiAlis?.ToString("yyyy-MM-dd") ?? "boş") != (alisTarihi?.ToString("yyyy-MM-dd") ?? "boş"))
                    degisenler.Add($"Alis_Tarihi: {eskiAlis?.ToString("yyyy-MM-dd") ?? "boş"} → {alisTarihi?.ToString("yyyy-MM-dd") ?? "boş"}");
                if (eskiUcret != ucret)
                    degisenler.Add($"Ucret: {eskiUcret?.ToString("F2") ?? "0"} → {ucret?.ToString("F2") ?? "0"}");

                // Güncelleme sorgusu
                string query = @"
        UPDATE Garanti SET
            Urun_ismi = @Urun_ismi,
            Seri_no = @Seri_no,
            Firma_ismi = @Firma_ismi,
            Alici_marka = @Alici_marka,
            Kargo_ismi = @Kargo_ismi,
            Kargo_no = @Kargo_no,
            Gonderilme_tarihi = @Gonderilme_tarihi,
            Alis_Tarihi = @Alis_Tarihi,
            Ucret = @Ucret
        WHERE id = @ID";

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
                    cmd.Parameters.AddWithValue("@ID", secilenGarantiId);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        if (degisenler.Count > 0)
                        {
                            string detay = $"GarantiId: {secilenGarantiId} | " + string.Join(", ", degisenler);
                            Helpers.Logger.Log("Güncelleme", "Garanti", detay);
                        }

                        MessageBox.Show("Güncelleme başarılı.");
                        KayitlariListele();
                    }
                    else
                    {
                        MessageBox.Show("Kayıt bulunamadı.");
                    }
                }
            }
        }


        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                secilenGarantiId = Convert.ToInt32(row.Cells["ID"].Value);

                txtUrunIsmi.Text = row.Cells["Urun_ismi"].Value?.ToString();
                txtSeriNo.Text = row.Cells["Seri_no"].Value?.ToString();
                txtFirma.Text = row.Cells["Firma_ismi"].Value?.ToString();
                txtKargo.Text = row.Cells["Kargo_ismi"].Value?.ToString();
                txtAlanMarka.Text = row.Cells["Alici_marka"].Value?.ToString();
                txtTakipNo.Text = row.Cells["Kargo_no"].Value?.ToString();
                txtGonderilmeTarihi.Text = row.Cells["Gonderilme_tarihi"].Value?.ToString();
                txtAlisTarihi.Text = row.Cells["Alis_Tarihi"].Value?.ToString();
                txtUcret.Text = row.Cells["Ucret"].Value?.ToString();
            }

        }
    }
}
