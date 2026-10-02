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
    public partial class YapılanIslerGuncelleMenu : Form
    {
        public YapılanIslerGuncelleMenu()
        {
            InitializeComponent();
            dgvYapilanIslerGuncelle.ReadOnly = true;
            dgvYapilanIslerGuncelle.AllowUserToAddRows = false;
            dgvYapilanIslerGuncelle.AllowUserToDeleteRows = false;
            dgvYapilanIslerGuncelle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvYapilanIslerGuncelle.MultiSelect = false;

            VerileriYukle();
           
        }
        private void VerileriYukle()
        {
            try
            {
                string connStr = database.DbHelper.GetConnectionString();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Yapilan_Isler", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvYapilanIslerGuncelle.DataSource = dt;

                    // ID kolonunu gizle
                    if (dgvYapilanIslerGuncelle.Columns.Contains("id"))
                        dgvYapilanIslerGuncelle.Columns["id"].Visible = false;

                    // Kolon başlıklarını ayarla (isteğe bağlı)
                    dgvYapilanIslerGuncelle.Columns["Firma_ismi"].HeaderText = "Firma";
                    dgvYapilanIslerGuncelle.Columns["Servis_turu"].HeaderText = "Servis Türü";
                    dgvYapilanIslerGuncelle.Columns["Aciklama"].HeaderText = "Açıklama";
                    dgvYapilanIslerGuncelle.Columns["Sonuc"].HeaderText = "Sonuç";
                    dgvYapilanIslerGuncelle.Columns["Olusturulma_Tarihi"].HeaderText = "Oluşturulma";
                    dgvYapilanIslerGuncelle.Columns["Degistirilme_Tarihi"].HeaderText = "Değiştirilme";
                    dgvYapilanIslerGuncelle.Columns["Fiyat"].HeaderText = "Fiyat";
                    dgvYapilanIslerGuncelle.Columns["Tarih"].HeaderText = "Tarih";
                    dgvYapilanIslerGuncelle.Dock = DockStyle.Fill;
                    dgvYapilanIslerGuncelle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yüklenirken hata oluştu: " + ex.Message);
            }
        }


        private void dgvYapilanIslerGuncelle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvYapilanIslerGuncelle.Rows[e.RowIndex];

                YapilanIs seciliIs = new YapilanIs
                {
                    Id = Convert.ToInt32(row.Cells["id"].Value),
                    FirmaIsmi = row.Cells["Firma_ismi"].Value.ToString(),
                    ServisTuru = Convert.ToBoolean(row.Cells["Servis_turu"].Value),
                    Aciklama = row.Cells["Aciklama"].Value?.ToString(),
                    Sonuc = Convert.ToBoolean(row.Cells["Sonuc"].Value),
                    OlusturulmaTarihi = row.Cells["Olusturulma_Tarihi"].Value as DateTime?,
                    DegistirilmeTarihi = row.Cells["Degistirilme_Tarihi"].Value as DateTime?,
                    Fiyat = Convert.ToDecimal(row.Cells["Fiyat"].Value),
                    Tarih = Convert.ToDateTime(row.Cells["Tarih"].Value)
                };

                YapilanIslerGuncelle guncelleForm = new YapilanIslerGuncelle(seciliIs);
                guncelleForm.FormClosed += (s, args) => VerileriYukle();

                guncelleForm.ShowDialog();
            }
        }

        
    }
}
