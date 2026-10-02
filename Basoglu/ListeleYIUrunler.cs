using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Basoglu
{
    public partial class ListeleYIUrunler : Form
    {
        private int yapilanIsId;
        

        public ListeleYIUrunler(int yapilanIsId)
        {
            InitializeComponent();
            this.yapilanIsId = yapilanIsId;
            this.Load += ListeleYIUrunler_Load;
        }

        private void ListeleYIUrunler_Load(object sender, EventArgs e)
        {
            UrunleriYukle();
        }

        private void UrunleriYukle()
        {
            try
            {
                string connStr = database.DbHelper.GetConnectionString();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string query = @"
                        SELECT 
                            Urun_ismi AS [Ürün Adı], 
                            Model_numarasi AS [Model Numarası], 
                            Seri_no AS [Seri No], 
                            Miktar, 
                            CASE WHEN kaynak = 1 THEN 'Stoktan' ELSE 'Dış Kaynak' END AS [Kaynak mı?]
                        FROM YIUrunler
                        WHERE Yapilan_is_id = @YapilanIsId";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@YapilanIsId", yapilanIsId);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvUrunler.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürünler yüklenirken hata oluştu: " + ex.Message);
            }
        }
    }
}
