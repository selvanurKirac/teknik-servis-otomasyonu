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
    public partial class UrunEkle : Form
    {
        public UrunEkle()
        {
            InitializeComponent();
            UrunleriListele();
        }

        private void YukleVeri()
        {
            try
            {
                string connStr = DbHelper.GetConnectionString();

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Urunler", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["ID"].Visible = false;
                    dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yüklenemedi: " + ex.Message);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUrunIsmi.Text))
            {
                MessageBox.Show("Ürün ismi boş bırakılamaz.");
                return;
            }

            string urunIsmi = txtUrunIsmi.Text.Trim();
            string model = string.IsNullOrWhiteSpace(txtModel.Text) ? null : txtModel.Text.Trim();
            string seriNo = string.IsNullOrWhiteSpace(txtSeriNumarasi.Text) ? null : txtSeriNumarasi.Text.Trim();

            int miktar = 0;
            if (!string.IsNullOrWhiteSpace(txtStok.Text))
            {
                if (int.TryParse(txtStok.Text, out int parsedMiktar))
                    miktar = parsedMiktar;
                else
                {
                    MessageBox.Show("Miktar sayısal olmalıdır.");
                    return;
                }
            }

            string connStr = DbHelper.GetConnectionString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string kontrolQuery = @"
        SELECT COUNT(*) FROM Urunler 
        WHERE Urun_ismi = @urun 
          AND ISNULL(Model_numarasi, '') = ISNULL(@model, '') 
          AND ISNULL(seri_no, '') = ISNULL(@seri, '') 
          AND ISNULL(Miktar, -1) = ISNULL(@miktar, -1)";

                using (SqlCommand cmdKontrol = new SqlCommand(kontrolQuery, conn))
                {
                    cmdKontrol.Parameters.AddWithValue("@urun", urunIsmi);
                    cmdKontrol.Parameters.AddWithValue("@model", (object)model ?? DBNull.Value);
                    cmdKontrol.Parameters.AddWithValue("@seri", (object)seriNo ?? DBNull.Value);
                    cmdKontrol.Parameters.AddWithValue("@miktar", miktar);

                    int count = (int)cmdKontrol.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Bu özelliklerde bir ürün zaten kayıtlı.");
                        return;
                    }
                }

                string insertQuery = @"
        INSERT INTO Urunler (Urun_ismi, Model_numarasi, Miktar, seri_no)
        VALUES (@urun, @model, @miktar, @seri)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@urun", urunIsmi);
                    cmd.Parameters.AddWithValue("@model", (object)model ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@miktar", miktar);
                    cmd.Parameters.AddWithValue("@seri", (object)seriNo ?? DBNull.Value);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ürün başarıyla eklendi.");

                    // 🔍 Log kaydı oluştur
                    string logDetay = $"Ürün eklendi → İsim: \"{urunIsmi}\", Model: \"{model}\", Seri No: \"{seriNo}\", Miktar: {miktar} | Kullanıcı: {KullaniciContext.KullaniciAdi} | Tarih: {DateTime.Now:dd.MM.yyyy HH:mm}";
                    Helpers.Logger.Log("Ekleme", "Urunler", logDetay);

                    UrunleriListele();

                    txtUrunIsmi.Clear();
                    txtModel.Clear();
                    txtStok.Clear();
                    txtSeriNumarasi.Clear();
                }
            }
        }


        private void UrunleriListele()
        {
            string connStr = DbHelper.GetConnectionString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT id, Urun_ismi, Model_numarasi, Miktar, seri_no FROM Urunler";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        
    }
}
