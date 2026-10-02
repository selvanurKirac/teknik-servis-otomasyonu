using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static Basoglu.database;

namespace Basoglu
{
    public partial class FirmaEkle : Form
    {
        public FirmaEkle()
        {
            InitializeComponent();
            FirmaListele(); // sayfa ilk açıldığında firmaları listele
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirmaIsmi.Text))
            {
                MessageBox.Show("Firma ismi boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string firmaIsmi = txtFirmaIsmi.Text.Trim();
            string firmaAdres = string.IsNullOrWhiteSpace(txtFirmaAdres.Text) ? null : txtFirmaAdres.Text.Trim();
            string firmaTel = string.IsNullOrWhiteSpace(txtFirmaTel.Text) ? null : txtFirmaTel.Text.Trim();
            string firmaEposta = string.IsNullOrWhiteSpace(txtFirmaEposta.Text) ? null : txtFirmaEposta.Text.Trim();
            DateTime eklenmeTarihi = DateTime.Now;

            string connStr = DbHelper.GetConnectionString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string checkQuery = "SELECT COUNT(*) FROM Firmalar WHERE Firma_ismi = @isim";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@isim", firmaIsmi);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Bu firma zaten kayıtlı. Aynı isme sahip firma eklenemez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string query = @"
            INSERT INTO Firmalar 
            (Firma_ismi, Firma_tel, Firma_adres, Firma_eposta, Firma_eklenme_tarihi) 
            VALUES (@isim, @tel, @adres, @eposta, @tarih)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@isim", firmaIsmi);
                    cmd.Parameters.AddWithValue("@tel", (object)firmaTel ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@adres", (object)firmaAdres ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@eposta", (object)firmaEposta ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@tarih", eklenmeTarihi);

                    cmd.ExecuteNonQuery();
                }

                // ✅ Log ekle
                string detay = $"Firma_ismi: \"{firmaIsmi}\", " +
                               $"Firma_tel: \"{firmaTel ?? "boş"}\", " +
                               $"Firma_adres: \"{firmaAdres ?? "boş"}\", " +
                               $"Firma_eposta: \"{firmaEposta ?? "boş"}\", " +
                               $"Firma_eklenme_tarihi: {eklenmeTarihi:yyyy-MM-dd HH:mm:ss}";

                Helpers.Logger.Log("Ekleme", "Firmalar", detay);
            }

            MessageBox.Show("Firma başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FirmaListele();
            Temizle();
        }


        private void FirmaListele()
        {
            string connStr = DbHelper.GetConnectionString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT id, Firma_ismi, Firma_tel, Firma_adres, Firma_eposta, Firma_eklenme_tarihi FROM Firmalar";

                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvFirma.DataSource = dt;
                }
            }
        }

        private void Temizle()
        {
            txtFirmaIsmi.Text = "";
            txtFirmaAdres.Text = "";
            txtFirmaTel.Text = "";
            txtFirmaEposta.Text = "";
        }
    }
}
