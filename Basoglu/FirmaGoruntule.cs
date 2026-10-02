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
    public partial class FirmaGoruntule : Form
    {
        public FirmaGoruntule()
        {
            InitializeComponent();
            FirmaListesiniYukle();
        }


        private void FirmaListesiniYukle()
        {
            string connStr = DbHelper.GetConnectionString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT * FROM Firmalar";

                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvFirmalar.DataSource = dt;
                }
            }
        }
    }
}
