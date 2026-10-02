using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Basoglu
{
    public partial class UrunGuncelle : Form
    {
        private int? seciliUrunId = null;

        public UrunGuncelle()
        {
            InitializeComponent();


            dgvUrunler.AutoGenerateColumns = true;
            dgvUrunler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            cmbUrunIsmi.SelectedIndexChanged += cmbUrunIsmi_SelectedIndexChanged;
            cmbModel.SelectedIndexChanged += cmbModel_SelectedIndexChanged;

            UrunleriListele();
            UrunIsimleriniYukle();
            ModelNumaralariniYukle();
        }

        

        


        private void UrunleriListele()
        {
            string connStr = database.DbHelper.GetConnectionString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string Urun_ismi = string.IsNullOrWhiteSpace(cmbUrunIsmi.Text) ? null : cmbUrunIsmi.Text.Trim();
                string Model_numarasi = string.IsNullOrWhiteSpace(cmbModel.Text) ? null : cmbModel.Text.Trim();
                string seri_no = string.IsNullOrWhiteSpace(txtSeriNo.Text) ? null : txtSeriNo.Text.Trim();

                int? Miktar = null;
                if (!string.IsNullOrWhiteSpace(txtMiktar.Text) && int.TryParse(txtMiktar.Text, out int parsedMiktar))
                    Miktar = parsedMiktar;

                StringBuilder query = new StringBuilder("SELECT id, Urun_ismi, Model_numarasi, Miktar, seri_no FROM Urunler WHERE 1=1");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                if (!string.IsNullOrWhiteSpace(Urun_ismi))
                {
                    query.Append(" AND Urun_ismi LIKE @Urun_ismi");
                    cmd.Parameters.AddWithValue("@Urun_ismi", "%" + Urun_ismi + "%");
                }

                if (!string.IsNullOrWhiteSpace(Model_numarasi))
                {
                    query.Append(" AND Model_numarasi LIKE @Model_numarasi");
                    cmd.Parameters.AddWithValue("@Model_numarasi", "%" + Model_numarasi + "%");
                }

                if (!string.IsNullOrWhiteSpace(seri_no))
                {
                    query.Append(" AND seri_no LIKE @seri_no");
                    cmd.Parameters.AddWithValue("@seri_no", "%" + seri_no + "%");
                }

                if (Miktar.HasValue)
                {
                    query.Append(" AND Miktar = @Miktar");
                    cmd.Parameters.AddWithValue("@Miktar", Miktar.Value);
                }

                cmd.CommandText = query.ToString();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvUrunler.DataSource = dt;
                dgvUrunler.AutoResizeColumns();

                if (dgvUrunler.Columns.Contains("id"))
                    dgvUrunler.Columns["id"].Visible = false;

                seciliUrunId = null;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Hiç kayıt bulunamadı.", "Boş Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void UrunIsimleriniYukle()
        {
            string connStr = database.DbHelper.GetConnectionString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT DISTINCT Urun_ismi FROM Urunler WHERE Urun_ismi IS NOT NULL", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                cmbUrunIsmi.Items.Clear();
                cmbUrunIsmi.Items.Add("");

                while (reader.Read())
                    cmbUrunIsmi.Items.Add(reader.GetString(0));
            }
        }

        private void ModelNumaralariniYukle()
        {
            string connStr = database.DbHelper.GetConnectionString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT DISTINCT Model_numarasi FROM Urunler WHERE Model_numarasi IS NOT NULL", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                cmbModel.Items.Clear();
                cmbModel.Items.Add("");

                while (reader.Read())
                    cmbModel.Items.Add(reader.GetString(0));
            }
        }

        private void ModelYukleUrunIsmineGore(string Urun_ismi)
        {
            string connStr = database.DbHelper.GetConnectionString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT DISTINCT Model_numarasi FROM Urunler WHERE Urun_ismi = @Urun_ismi AND Model_numarasi IS NOT NULL", conn);
                cmd.Parameters.AddWithValue("@Urun_ismi", Urun_ismi);
                SqlDataReader reader = cmd.ExecuteReader();

                cmbModel.Items.Clear();
                cmbModel.Items.Add("");

                while (reader.Read())
                    cmbModel.Items.Add(reader.GetString(0));
            }
        }

        private void UrunYukleModeleGore(string Model_numarasi)
        {
            string connStr = database.DbHelper.GetConnectionString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT DISTINCT Urun_ismi FROM Urunler WHERE Model_numarasi = @Model_numarasi AND Urun_ismi IS NOT NULL", conn);
                cmd.Parameters.AddWithValue("@Model_numarasi", Model_numarasi);
                SqlDataReader reader = cmd.ExecuteReader();

                cmbUrunIsmi.Items.Clear();
                cmbUrunIsmi.Items.Add("");

                while (reader.Read())
                    cmbUrunIsmi.Items.Add(reader.GetString(0));
            }
        }

        private void cmbUrunIsmi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cmbUrunIsmi.Text))
                ModelYukleUrunIsmineGore(cmbUrunIsmi.Text);
        }

        private void cmbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cmbModel.Text))
                UrunYukleModeleGore(cmbModel.Text);
        }

        

        
        private void btnAra_Click(object sender, EventArgs e)
        {
            UrunleriListele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (seciliUrunId == null)
            {
                MessageBox.Show("Lütfen güncellemek için bir ürün seçin.");
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbUrunIsmi.Text))
            {
                MessageBox.Show("Urun_ismi boş bırakılamaz.");
                return;
            }

            int? miktar = null;
            if (!string.IsNullOrWhiteSpace(txtMiktar.Text))
            {
                if (int.TryParse(txtMiktar.Text, out int parsed))
                    miktar = parsed;
                else
                {
                    MessageBox.Show("Miktar sayısal olmalıdır.");
                    return;
                }
            }

            string connStr = database.DbHelper.GetConnectionString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Eski verileri al
                SqlCommand selectCmd = new SqlCommand("SELECT * FROM Urunler WHERE id = @id", conn);
                selectCmd.Parameters.AddWithValue("@id", seciliUrunId.Value);
                SqlDataReader reader = selectCmd.ExecuteReader();

                string eskiUrun = "", eskiModel = "", eskiSeri = "";
                int? eskiMiktar = null;

                if (reader.Read())
                {
                    eskiUrun = reader["Urun_ismi"]?.ToString();
                    eskiModel = reader["Model_numarasi"]?.ToString();
                    eskiSeri = reader["seri_no"]?.ToString();
                    eskiMiktar = reader["Miktar"] != DBNull.Value ? Convert.ToInt32(reader["Miktar"]) : (int?)null;
                }
                reader.Close();

                // Yeni değerler
                string yeniUrun = cmbUrunIsmi.Text.Trim();
                string yeniModel = string.IsNullOrWhiteSpace(cmbModel.Text) ? null : cmbModel.Text.Trim();
                string yeniSeri = string.IsNullOrWhiteSpace(txtSeriNo.Text) ? null : txtSeriNo.Text.Trim();

                // Normalize karşılaştırmalar
                string normEskiUrun = (eskiUrun ?? "").Trim();
                string normYeniUrun = (yeniUrun ?? "").Trim();

                string normEskiModel = (eskiModel ?? "").Trim();
                string normYeniModel = (yeniModel ?? "").Trim();

                string normEskiSeri = (eskiSeri ?? "").Trim();
                string normYeniSeri = (yeniSeri ?? "").Trim();

                // Değişen alanları topla
                List<string> degisiklikler = new List<string>();

                if (normEskiUrun != normYeniUrun)
                    degisiklikler.Add($"Urun_ismi: \"{eskiUrun}\" → \"{yeniUrun}\"");

                if (normEskiModel != normYeniModel)
                    degisiklikler.Add($"Model_numarasi: \"{eskiModel}\" → \"{yeniModel}\"");

                if (normEskiSeri != normYeniSeri)
                    degisiklikler.Add($"Seri_no: \"{eskiSeri}\" → \"{yeniSeri}\"");

                if (eskiMiktar != miktar)
                    degisiklikler.Add($"Miktar: {eskiMiktar} → {miktar}");

                if (degisiklikler.Count == 0)
                {
                    MessageBox.Show("Hiçbir değişiklik yapılmadı.");
                    return;
                }

                // Güncelleme işlemi
                SqlCommand updateCmd = new SqlCommand(@"
            UPDATE Urunler SET
                Urun_ismi = @Urun_ismi,
                Model_numarasi = @Model_numarasi,
                Miktar = @Miktar,
                seri_no = @seri_no
            WHERE id = @id", conn);

                updateCmd.Parameters.AddWithValue("@Urun_ismi", yeniUrun);
                updateCmd.Parameters.AddWithValue("@Model_numarasi", (object)yeniModel ?? DBNull.Value);
                updateCmd.Parameters.AddWithValue("@Miktar", (object)miktar ?? DBNull.Value);
                updateCmd.Parameters.AddWithValue("@seri_no", (object)yeniSeri ?? DBNull.Value);
                updateCmd.Parameters.AddWithValue("@id", seciliUrunId.Value);

                updateCmd.ExecuteNonQuery();

                // Log işlemi
                string detay = $"ID: {seciliUrunId} | " + string.Join(", ", degisiklikler) +
                               $" | Kullanıcı: {KullaniciContext.KullaniciAdi} | Tarih: {DateTime.Now:dd.MM.yyyy HH:mm}";
                Helpers.Logger.Log("Güncelleme", "Urunler", detay);

                MessageBox.Show("Ürün başarıyla güncellendi.");
                UrunleriListele();
            }
        }



        private void dgvUrunler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUrunler.Rows[e.RowIndex];
                seciliUrunId = Convert.ToInt32(row.Cells["id"].Value);

                cmbUrunIsmi.Text = row.Cells["Urun_ismi"].Value?.ToString() ?? "";
                cmbModel.Text = row.Cells["Model_numarasi"].Value?.ToString() ?? "";
                txtMiktar.Text = row.Cells["Miktar"].Value?.ToString() ?? "";
                txtSeriNo.Text = row.Cells["seri_no"].Value?.ToString() ?? "";
            }
        
    }
    }
}
