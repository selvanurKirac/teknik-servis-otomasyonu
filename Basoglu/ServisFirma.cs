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

namespace Basoglu
{
    public partial class ServisFirma : Form
    {
        public ServisFirma()
        {
            InitializeComponent();
            FirmaListele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirmaIsmi.Text))
            {
                MessageBox.Show("Firma ismi boş olamaz.");
                return;
            }

            try
            {
                string firmaIsmi = txtFirmaIsmi.Text.Trim();
                string firmaTel = txtFirmaTel.Text.Trim();
                string firmaAdres = txtFirmaAdres.Text.Trim();
                string firmaEposta = txtFirmaEposta.Text.Trim();
                DateTime eklenmeTarihi = DateTime.Now;

                string connStr = database.DbHelper.GetConnectionString();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string query = @"INSERT INTO Servis_Firma 
                            (Firma_ismi, Firma_tel, Firma_adres, Firma_eposta, Firma_eklenme_tarihi)
                             VALUES (@isim, @tel, @adres, @eposta, @tarih)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@isim", firmaIsmi);
                        cmd.Parameters.AddWithValue("@tel", firmaTel);
                        cmd.Parameters.AddWithValue("@adres", firmaAdres);
                        cmd.Parameters.AddWithValue("@eposta", firmaEposta);
                        cmd.Parameters.AddWithValue("@tarih", eklenmeTarihi);

                        cmd.ExecuteNonQuery();
                    }
                }

                // ✅ Loglama
                string detay = $"Firma_ismi: \"{firmaIsmi}\", " +
                               $"Firma_tel: \"{firmaTel}\", " +
                               $"Firma_adres: \"{firmaAdres}\", " +
                               $"Firma_eposta: \"{firmaEposta}\", " +
                               $"Firma_eklenme_tarihi: {eklenmeTarihi:yyyy-MM-dd HH:mm:ss}";

                Helpers.Logger.Log("Ekleme", "Servis_Firma", detay);

                MessageBox.Show("Firma başarıyla eklendi.");
                FirmaListele();
                Temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt sırasında hata: " + ex.Message);
            }
        }

        private void FirmaListele()
        {
            try
            {
                string connStr = database.DbHelper.GetConnectionString();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT id, Firma_ismi, Firma_tel, Firma_adres, Firma_eposta, Firma_eklenme_tarihi FROM Servis_Firma";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvFirma.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler listelenemedi: " + ex.Message);
            }
        }
        private void Temizle()
        {
            txtFirmaIsmi.Text = "";
            txtFirmaTel.Text = "";
            txtFirmaAdres.Text = "";
            txtFirmaEposta.Text = "";
        }

       
    }
}
