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
    public partial class TonerGoruntule : Form
    {
        public TonerGoruntule()
        {
            InitializeComponent();
            ListeleTonerler();
        }

        private void ListeleTonerler()
        {
            string connStr = DbHelper.GetConnectionString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Toner ORDER BY id DESC", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvToner.DataSource = dt;
            }
        }
    }
}
