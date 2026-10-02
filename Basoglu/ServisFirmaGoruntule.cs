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
    public partial class ServisFirmaGoruntule : Form
    {
        public ServisFirmaGoruntule()
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
                string query = "SELECT * FROM Servis_Firma";

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
