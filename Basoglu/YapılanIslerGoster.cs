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
    public partial class YapılanIslerGoster : Form
    {
        public YapılanIslerGoster()
        {
            InitializeComponent();
            

            VerileriYukle();
            this.Load += YapilanIslerGoster_Load;

        }

        private void YapilanIslerGoster_Load(object sender, EventArgs e)
        {
            cmbTarihTuru.Items.Clear();
            cmbTarihTuru.Items.Add("Tarih");
            cmbTarihTuru.Items.Add("Olusturulma_Tarihi");
            cmbTarihTuru.Items.Add("Degistirilme_Tarihi");
            cmbTarihTuru.SelectedIndex = 0; // Varsayılan olarak "Tarih"
        }



        private void VerileriYukle()
        {
            try
            {
                string connStr = database.DbHelper.GetConnectionString();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    // En son tarihten geçmişe doğru sırala
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Yapilan_Isler ORDER BY Tarih DESC", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

                    // ID kolonunu gizle
                    if (dataGridView1.Columns.Contains("id"))
                    {
                        dataGridView1.Columns["id"].Visible = false;
                        dataGridView1.Columns["id"].DisplayIndex = 0; // Gizli olsa bile erişilebilir ilk sütun
                    }
                       


                    // Kolon başlıklarını ayarla
                    dataGridView1.Columns["Firma_ismi"].HeaderText = "Firma";
                    dataGridView1.Columns["Servis_turu"].HeaderText = "Servis Türü";
                    dataGridView1.Columns["Aciklama"].HeaderText = "Açıklama";
                    dataGridView1.Columns["Sonuc"].HeaderText = "Sonuç";
                    dataGridView1.Columns["Olusturulma_Tarihi"].HeaderText = "Oluşturulma";
                    dataGridView1.Columns["Degistirilme_Tarihi"].HeaderText = "Değiştirilme";
                    dataGridView1.Columns["Fiyat"].HeaderText = "Fiyat";
                    dataGridView1.Columns["Tarih"].HeaderText = "Tarih";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yüklenirken hata oluştu: " + ex.Message);
            }
        }


        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            string connStr = database.DbHelper.GetConnectionString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // ComboBox'tan seçilen tarih alanı
                string secilenTarihAlan = "Tarih"; // Varsayılan
                if (cmbTarihTuru.SelectedItem != null)
                {
                    secilenTarihAlan = cmbTarihTuru.SelectedItem.ToString();
                }

                // Dinamik sorgu oluştur
                string query = $@"
            SELECT * FROM Yapilan_Isler 
            WHERE {secilenTarihAlan} >= @BaslangicTarihi AND {secilenTarihAlan} <= @BitisTarihi";

                if (!string.IsNullOrWhiteSpace(txtFirma.Text))
                {
                    query += " AND Firma_ismi LIKE @Firma";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BaslangicTarihi", dtpBaslangic.Value.Date);
                    cmd.Parameters.AddWithValue("@BitisTarihi", dtpBitis.Value.Date);

                    if (!string.IsNullOrWhiteSpace(txtFirma.Text))
                    {
                        cmd.Parameters.AddWithValue("@Firma", "%" + txtFirma.Text.Trim() + "%");
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                if (row.Cells["id"].Value != null)
                {
                    int yapilanIsId = Convert.ToInt32(row.Cells["id"].Value);
                    Form frm = new YapilanIsGoster(yapilanIsId);
                    frm.ShowDialog();
                }
            }
        }
    }
}
