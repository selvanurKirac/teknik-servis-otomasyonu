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
    public partial class YapilanIsGoster : Form
    {
        private int yapilanIsId;
        public YapilanIsGoster(int yapilanIsId)
        {
            InitializeComponent();
            this.yapilanIsId = yapilanIsId;
            this.Load += YapilanIsGoster_Load;

        }
        private void YapilanIsGoster_Load(object sender, EventArgs e)
        {
            YapilanIsBilgileriniGetir();
            foreach (Control control in tableLayoutPanel2.Controls)
            {
                if (control is TextBox textBox)
                    textBox.ReadOnly = true;
                else if (control is RichTextBox richText)
                    richText.ReadOnly = true;
                else if (control is ComboBox comboBox)
                    comboBox.Enabled = false;
            }

        }
        private void YapilanIsBilgileriniGetir()
        {
            string connStr = database.DbHelper.GetConnectionString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
                    SELECT 
                        Firma_ismi, 
                        Servis_turu, 
                        Aciklama, 
                        Sonuc, 
                        Fiyat, 
                        Tarih
                    FROM Yapilan_Isler
                    WHERE id = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", yapilanIsId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    cmbFirma.Text = reader["Firma_ismi"].ToString();

                    // Servis_turu: 1 → İşyerinde, 0 → Firmada
                    bool servisTuru = Convert.ToBoolean(reader["Servis_turu"]);
                    cmbServis.Text = servisTuru ? "İşyerinde" : "Firmada";

                    rtbAciklama.Text = reader["Aciklama"].ToString();

                    // Sonuc: 1 → Tamamlandı, 0 → Tamamlanmadı
                    bool sonuc = Convert.ToBoolean(reader["Sonuc"]);
                    cmbSonuc.Text = sonuc ? "Tamamlandı" : "Tamamlanmadı";

                    txtFiyat.Text = reader["Fiyat"].ToString();
                    txtTarih.Text = Convert.ToDateTime(reader["Tarih"]).ToShortDateString();
                }
                reader.Close();

            }
        }
        private void btnTamirCihaz_Click(object sender, EventArgs e)
        {
            Form form = new ListeleYICihazlar(yapilanIsId);
            form.ShowDialog();
        }

        private void btnUrunler_Click(object sender, EventArgs e)
        {
            Form form = new ListeleYIUrunler(yapilanIsId);
            form.ShowDialog();

        }

        private void btnToner_Click(object sender, EventArgs e)
        {
            Form form = new TonerMenu();
            form.ShowDialog();
        }

        private void btnGaranti_Click(object sender, EventArgs e)
        {
            Form form = new GarantiMenu();
            form.ShowDialog();

        }
    }
}
