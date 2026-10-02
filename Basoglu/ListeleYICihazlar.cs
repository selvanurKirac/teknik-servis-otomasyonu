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
    public partial class ListeleYICihazlar : Form
    {
        private int yapilanIsId;
        public ListeleYICihazlar(int yapilanIsId)
        {
            InitializeComponent();
            this.yapilanIsId = yapilanIsId;
            CihazlariYukle();
        }

        private void CihazlariYukle()
        {
            string connStr = database.DbHelper.GetConnectionString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
                    SELECT DISTINCT yc.id AS CihazId, yc.Cihaz_ismi, yc.Cihaz_model, yc.Cihaz_adet
                    FROM YICihaz yc
                    INNER JOIN Cihaz_Tamir ct ON yc.id = ct.Cihaz_id
                    WHERE ct.Yapilan_is_id = @YapilanIsId";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@YapilanIsId", yapilanIsId);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCihazlar.DataSource = dt;
            }
        }

      
        private void ServisleriYukle(int cihazId)
        {
            try
            {
                string connStr = database.DbHelper.GetConnectionString();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string query = @"
                SELECT 
                    sf.Firma_ismi AS [Firma Adı], 
                    ct.Alim_tarihi AS [Alım Tarihi], 
                    ct.Teslim_tarihi AS [Teslim Tarihi]
                FROM Cihaz_Tamir ct
                INNER JOIN Servis_Firma sf ON ct.Servis_firma_id = sf.id
                WHERE ct.Cihaz_id = @CihazId AND ct.Yapilan_is_id = @YapilanIsId";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CihazId", cihazId);
                    cmd.Parameters.AddWithValue("@YapilanIsId", yapilanIsId);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvServisler.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Servisler yüklenirken hata oluştu: " + ex.Message);
            }
        }

        private void dgvCihazlar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCihazlar.CurrentRow != null && dgvCihazlar.CurrentRow.Cells["CihazId"].Value != null)
            {
                int cihazId = Convert.ToInt32(dgvCihazlar.CurrentRow.Cells["CihazId"].Value);
                ServisleriYukle(cihazId);
            }

        }
    }
}
