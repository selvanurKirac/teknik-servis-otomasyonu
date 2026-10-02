using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Basoglu
{
    public partial class CihazServisFirmaGuncelle : Form
    {
        private int cihazTamirId;
        private CihazTamirGuncelleMenu parent;

        public CihazServisFirmaGuncelle(int cihazTamirId, CihazTamirGuncelleMenu parentMenu)
        {
            InitializeComponent();
            this.cihazTamirId = cihazTamirId;
            this.parent = parentMenu;

            VerileriYukle();
        }

        private void VerileriYukle()
        {
            try
            {
                string connStr = database.DbHelper.GetConnectionString();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT Alim_tarihi, Teslim_tarihi FROM Cihaz_Tamir WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", cihazTamirId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtAlimTarihi.Text = Convert.ToDateTime(reader["Alim_tarihi"]).ToString("yyyy-MM-dd");
                            if (reader["Teslim_tarihi"] != DBNull.Value)
                                txtTeslimTarihi.Text = Convert.ToDateTime(reader["Teslim_tarihi"]).ToString("yyyy-MM-dd");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yüklenemedi: " + ex.Message);
            }
        }

        private void btnCihazServisFirmaGuncelle_Click(object sender, EventArgs e)
        {
            if (!DateTime.TryParse(txtAlimTarihi.Text.Trim(), out DateTime alimTarihi))
            {
                MessageBox.Show("Geçerli bir alım tarihi giriniz.");
                return;
            }

            DateTime? teslimTarihi = null;
            if (DateTime.TryParse(txtTeslimTarihi.Text.Trim(), out DateTime parsedTeslim))
                teslimTarihi = parsedTeslim;

            try
            {
                string connStr = database.DbHelper.GetConnectionString();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    // Eski değerleri al
                    DateTime oncekiAlim = DateTime.MinValue;
                    DateTime? oncekiTeslim = null;
                    using (SqlCommand getCmd = new SqlCommand("SELECT Alim_tarihi, Teslim_tarihi FROM Cihaz_Tamir WHERE id = @id", conn))
                    {
                        getCmd.Parameters.AddWithValue("@id", cihazTamirId);
                        using (SqlDataReader reader = getCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                oncekiAlim = Convert.ToDateTime(reader["Alim_tarihi"]);
                                if (reader["Teslim_tarihi"] != DBNull.Value)
                                    oncekiTeslim = Convert.ToDateTime(reader["Teslim_tarihi"]);
                            }
                        }
                    }

                    // Güncelleme sorgusu
                    SqlCommand cmd = new SqlCommand(@"
                UPDATE Cihaz_Tamir 
                SET Alim_tarihi = @alim, 
                    Teslim_tarihi = @teslim 
                WHERE id = @id", conn);

                    cmd.Parameters.AddWithValue("@alim", alimTarihi);
                    cmd.Parameters.AddWithValue("@teslim", (object)teslimTarihi ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@id", cihazTamirId);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Güncelleme başarıyla tamamlandı.");

                    // 🔍 Değişen alanları kontrol et ve sadece onları logla
                    List<string> degisenler = new List<string>();
                    if (oncekiAlim != alimTarihi)
                        degisenler.Add($"Alım_tarihi: {oncekiAlim:yyyy-MM-dd} → {alimTarihi:yyyy-MM-dd}");

                    if ((oncekiTeslim?.ToString("yyyy-MM-dd") ?? "boş") != (teslimTarihi?.ToString("yyyy-MM-dd") ?? "boş"))
                        degisenler.Add($"Teslim_tarihi: {(oncekiTeslim?.ToString("yyyy-MM-dd") ?? "boş")} → {(teslimTarihi?.ToString("yyyy-MM-dd") ?? "boş")}");

                    if (degisenler.Count > 0)
                    {
                        string detay = $" CihazTamirId: {cihazTamirId} | " + string.Join(", ", degisenler);
                        Helpers.Logger.Log("Güncelleme", "Cihaz_Tamir", detay);
                    }

                    // Grid yenile
                    int cihazId = GetCihazId(cihazTamirId);
                    if (cihazId > 0)
                        parent?.ServisFirmalariGetir(cihazId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme hatası: " + ex.Message);
            }
        }


        private int GetCihazId(int cihazTamirId)
        {
            try
            {
                string connStr = database.DbHelper.GetConnectionString();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT Cihaz_id FROM Cihaz_Tamir WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", cihazTamirId);
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
            catch
            {
                return -1;
            }
        }
    }
}
