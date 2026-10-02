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
    public partial class YIStoktanUrunEkle : Form
    {
        private bool yeniUrunModu = false;

        public YIStoktanUrunEkle()
        {
            InitializeComponent();
            TumUrunleriGetir();
        }

        private void TumUrunleriGetir()
        {
            string connStr = database.DbHelper.GetConnectionString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT Urun_ismi, Model_numarasi, seri_no FROM Urunler";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void btnYeniUrun_Click(object sender, EventArgs e)
        {
            yeniUrunModu = true;

            txtUrunIsmi.ReadOnly = false;
            txtModel.ReadOnly = false;
            txtSeriNumarasi.ReadOnly = false;
            txtStok.ReadOnly = false;

            txtUrunIsmi.Clear();
            txtModel.Clear();
            txtSeriNumarasi.Clear();
            txtStok.Clear();

            TumUrunleriGetir();
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            string connStr = database.DbHelper.GetConnectionString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string urun = txtUrunIsmi.Text.Trim();
                string model = txtModel.Text.Trim();
                string seri = txtSeriNumarasi.Text.Trim();

                StringBuilder query = new StringBuilder("SELECT Urun_ismi, Model_numarasi, seri_no FROM Urunler WHERE 1=1");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                if (!string.IsNullOrWhiteSpace(urun))
                {
                    query.Append(" AND Urun_ismi LIKE @Urun_ismi");
                    cmd.Parameters.AddWithValue("@Urun_ismi", "%" + urun + "%");
                }
                if (!string.IsNullOrWhiteSpace(model))
                {
                    query.Append(" AND Model_numarasi LIKE @Model_numarasi");
                    cmd.Parameters.AddWithValue("@Model_numarasi", "%" + model + "%");
                }
                if (!string.IsNullOrWhiteSpace(seri))
                {
                    query.Append(" AND seri_no LIKE @seri_no");
                    cmd.Parameters.AddWithValue("@seri_no", "%" + seri + "%");
                }

                cmd.CommandText = query.ToString();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void btnUrunlereEkle_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtStok.Text.Trim(), out int stok))
            {
                MessageBox.Show("Stok değeri geçerli bir sayı olmalıdır.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUrunIsmi.Text))
            {
                MessageBox.Show("Lütfen ürün ismini girin.");
                return;
            }

            // Eğer stoktan ürün eklenecekse kontrol yap
            if (!yeniUrunModu)
            {
                string connStr = database.DbHelper.GetConnectionString();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    SqlCommand stokCmd = new SqlCommand(@"
                SELECT Miktar FROM Urunler 
                WHERE Urun_ismi = @isim 
                AND (
                    (Model_numarasi = @model) 
                    OR (Model_numarasi IS NULL AND @model IS NULL) 
                    OR (Model_numarasi = '' AND @model = '')
                ) 
                AND (
                    (seri_no = @seri) 
                    OR (seri_no IS NULL AND @seri IS NULL) 
                    OR (seri_no = '' AND @seri = '')
                )", conn);

                    object modelParam = string.IsNullOrWhiteSpace(txtModel.Text) ? DBNull.Value : (object)txtModel.Text.Trim();
                    object seriParam = string.IsNullOrWhiteSpace(txtSeriNumarasi.Text) ? DBNull.Value : (object)txtSeriNumarasi.Text.Trim();

                    stokCmd.Parameters.AddWithValue("@isim", txtUrunIsmi.Text.Trim());
                    stokCmd.Parameters.AddWithValue("@model", modelParam);
                    stokCmd.Parameters.AddWithValue("@seri", seriParam);

                    object mevcutStokObj = stokCmd.ExecuteScalar();

                    if (mevcutStokObj == null || mevcutStokObj == DBNull.Value)
                    {
                        MessageBox.Show("Stokta böyle bir ürün bulunamadı veya miktar bilgisi eksik.");
                        return;
                    }

                    int mevcutStok = Convert.ToInt32(mevcutStokObj);
                    if (stok > mevcutStok)
                    {
                        MessageBox.Show($"Yetersiz stok. Mevcut: {mevcutStok}, İstenen: {stok}");
                        return;
                    }
                }
            }

            // Aynı ürün daha önce eklendiyse uyar
            bool urunZatenVar = YIUrunler.Urunler.Any(u =>
                u.UrunIsmi == txtUrunIsmi.Text.Trim() &&
                u.ModelNumarasi == (string.IsNullOrWhiteSpace(txtModel.Text) ? null : txtModel.Text.Trim()) &&
                u.SeriNo == (string.IsNullOrWhiteSpace(txtSeriNumarasi.Text) ? null : txtSeriNumarasi.Text.Trim())
            );

            if (urunZatenVar)
            {
                MessageBox.Show("Bu ürün zaten eklenmiş.");
                return;
            }

            // Ürünü listeye ekle
            YIUrun yeni = new YIUrun
            {
                UrunIsmi = txtUrunIsmi.Text.Trim(),
                ModelNumarasi = string.IsNullOrWhiteSpace(txtModel.Text) ? null : txtModel.Text.Trim(),
                SeriNo = string.IsNullOrWhiteSpace(txtSeriNumarasi.Text) ? null : txtSeriNumarasi.Text.Trim(),
                Miktar = stok,
                Kaynak = true
            };

            YIUrunler.Ekle(yeni);
            MessageBox.Show("Ürün geçici listeye eklendi.");

            txtUrunIsmi.Clear();
            txtModel.Clear();
            txtSeriNumarasi.Clear();
            txtStok.Clear();

            if (!yeniUrunModu)
            {
                txtUrunIsmi.ReadOnly = true;
                txtModel.ReadOnly = true;
                txtSeriNumarasi.ReadOnly = true;
                TumUrunleriGetir();
            }

            foreach (Form f in Application.OpenForms)
            {
                if (f is YIUrunleriGoster gosterForm)
                {
                    gosterForm.ListeYenile();
                    break;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridView1.Rows[e.RowIndex];

            txtUrunIsmi.Text = row.Cells["Urun_ismi"].Value?.ToString();
            txtModel.Text = row.Cells["Model_numarasi"].Value?.ToString();
            txtSeriNumarasi.Text = row.Cells["seri_no"].Value?.ToString();

            txtUrunIsmi.ReadOnly = true;
            txtModel.ReadOnly = true;
            txtSeriNumarasi.ReadOnly = true;
            txtStok.ReadOnly = false;

            yeniUrunModu = false;
        }
    }
}
