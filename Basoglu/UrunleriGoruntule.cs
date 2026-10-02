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
    public partial class UrunleriGoruntule : Form
    {
        public UrunleriGoruntule()
        {
            InitializeComponent();
            ListeleUrunler();
            
        }
        private void ListeleUrunler()
        {
            string connStr = database.DbHelper.GetConnectionString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT * FROM Urunler";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvUrunler.DataSource = dt;
            }


        }

    }
}
