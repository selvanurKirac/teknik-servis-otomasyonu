using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Basoglu
{
    public partial class CihazTamirGuncelle : Form
    {
        private int cihazId;
        private CihazTamirGuncelleMenu parentForm;

        public CihazTamirGuncelle(int cihazId, CihazTamirGuncelleMenu parent)
        {
            InitializeComponent();
            this.cihazId = cihazId;
            this.parentForm = parent;

            CihazVerileriniYukle();
        }

        private void CihazVerileriniYukle()
        {
            try
            {
                string connStr = database.DbHelper.GetConnectionString();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM YICihaz WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", cihazId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtCihazIsmi.Text = reader["Cihaz_ismi"].ToString();
                            txtCihazModel.Text = reader["Cihaz_model"]?.ToString();
                            txtCihazAdet.Text = reader["Cihaz_adet"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yüklenemedi: " + ex.Message);
            }
        }

        private void btnCihazGuncelle_Click(object sender, EventArgs e)
        {
            string isim = txtCihazIsmi.Text.Trim();
            string cihazModel = string.IsNullOrWhiteSpace(txtCihazModel.Text) ? null : txtCihazModel.Text.Trim();

            if (string.IsNullOrWhiteSpace(isim))
            {
                MessageBox.Show("Cihaz ismi boş olamaz.");
                return;
            }

            if (!int.TryParse(txtCihazAdet.Text.Trim(), out int adet) || adet <= 0)
            {
                MessageBox.Show("Cihaz adedi geçerli bir sayı olmalıdır.");
                return;
            }

            try
            {
                string connStr = database.DbHelper.GetConnectionString();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    // 🔍 Önceki değerleri al
                    string eskiIsim = "";
                    string eskiModel = "";
                    int eskiAdet = 0;

                    using (SqlCommand getCmd = new SqlCommand("SELECT Cihaz_ismi, Cihaz_Model, Cihaz_adet FROM YICihaz WHERE id = @id", conn))
                    {
                        getCmd.Parameters.AddWithValue("@id", cihazId);
                        using (SqlDataReader reader = getCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                eskiIsim = reader["Cihaz_ismi"].ToString();
                                eskiModel = reader["Cihaz_Model"] != DBNull.Value ? reader["Cihaz_Model"].ToString() : null;
                                eskiAdet = Convert.ToInt32(reader["Cihaz_adet"]);
                            }
                        }
                    }

                    // 🔧 Güncelleme sorgusu
                    SqlCommand cmd = new SqlCommand(@"
                UPDATE YICihaz 
                SET Cihaz_ismi = @isim, 
                    Cihaz_Model = @CihazModel, 
                    Cihaz_adet = @adet 
                WHERE id = @id", conn);

                    cmd.Parameters.AddWithValue("@isim", isim);
                    cmd.Parameters.AddWithValue("@CihazModel", (object)cihazModel ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@adet", adet);
                    cmd.Parameters.AddWithValue("@id", cihazId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cihaz başarıyla güncellendi.");

                    // 🔐 Değişenleri logla
                    List<string> degisenler = new List<string>();
                    if (eskiIsim != isim)
                        degisenler.Add($"Cihaz_ismi: \"{eskiIsim}\" → \"{isim}\"");
                    if ((eskiModel ?? "boş") != (cihazModel ?? "boş"))
                        degisenler.Add($"Cihaz_Model: \"{eskiModel ?? "boş"}\" → \"{cihazModel ?? "boş"}\"");
                    if (eskiAdet != adet)
                        degisenler.Add($"Cihaz_adet: {eskiAdet} → {adet}");

                    if (degisenler.Count > 0)
                    {
                        string detay = $"CihazId: {cihazId} | " + string.Join(", ", degisenler);
                        Basoglu.Helpers.Logger.Log("Güncelleme", "YICihaz", detay);
                    }

                    // Grid yenile
                    parentForm?.CihazlariYukle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme başarısız: " + ex.Message);
            }
        }

        
    }
}
