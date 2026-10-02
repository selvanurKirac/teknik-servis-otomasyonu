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
    public partial class GarantiGoruntule : Form
    {
        public GarantiGoruntule()
        {
            InitializeComponent();
            KayitlariListele();
        }
        private void KayitlariListele()
        {
            string connStr = DbHelper.GetConnectionString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM Garanti ORDER BY id DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvGaranti.DataSource = dt;
            }
        }
    }
}
