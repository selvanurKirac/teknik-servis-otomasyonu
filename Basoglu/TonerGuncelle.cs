using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static Basoglu.database;

namespace Basoglu
{
    public partial class TonerGuncelle : Form
    {
        private int secilenTonerId = -1;

        public TonerGuncelle()
        {
            InitializeComponent();
            ListeleTonerler();
            dgvToner.CellDoubleClick += dgvToner_CellDoubleClick;
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

        private void dgvToner_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvToner.Rows[e.RowIndex];
                secilenTonerId = Convert.ToInt32(row.Cells["id"].Value);

                txtFirmaAdi.Text = row.Cells["Firma_adi"].Value?.ToString();
                txtTonerModel.Text = row.Cells["Toner_Model"].Value?.ToString();
                txtAdet.Text = row.Cells["Adet"].Value?.ToString();
                txtAciklama.Text = row.Cells["Aciklama"].Value?.ToString();
                txtTarih.Text = row.Cells["Tarih"].Value?.ToString();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (secilenTonerId == -1)
            {
                MessageBox.Show("Lütfen güncellenecek bir toner kaydını gridden seçin.");
                return;
            }

            string firmaAdi = txtFirmaAdi.Text.Trim();
            string tonerModel = txtTonerModel.Text.Trim();
            string aciklama = txtAciklama.Text.Trim();

            if (string.IsNullOrWhiteSpace(firmaAdi))
            {
                MessageBox.Show("Firma adı boş bırakılamaz.");
                return;
            }

            if (string.IsNullOrWhiteSpace(tonerModel))
            {
                MessageBox.Show("Toner modeli boş bırakılamaz.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTarih.Text))
            {
                MessageBox.Show("Tarih boş bırakılamaz.");
                return;
            }

            if (!DateTime.TryParseExact(txtTarih.Text.Trim(), "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime tarih))
            {
                MessageBox.Show("Lütfen tarihi 'gg.aa.yyyy' formatında giriniz. (Örn. 19.03.2025)");
                return;
            }

            int? adet = null;
            if (!string.IsNullOrWhiteSpace(txtAdet.Text))
            {
                if (int.TryParse(txtAdet.Text.Trim(), out int parsedAdet))
                {
                    adet = parsedAdet;
                }
                else
                {
                    MessageBox.Show("Adet sayısal bir değer olmalıdır.");
                    return;
                }
            }

            string connStr = DbHelper.GetConnectionString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Önce eski değerleri al
                SqlCommand selectCmd = new SqlCommand("SELECT * FROM Toner WHERE id = @id", conn);
                selectCmd.Parameters.AddWithValue("@id", secilenTonerId);
                SqlDataReader reader = selectCmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Kayıt bulunamadı.");
                    return;
                }

                string eskiFirma = reader["Firma_adi"].ToString();
                string eskiModel = reader["Toner_Model"].ToString();
                int? eskiAdet = reader["Adet"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["Adet"]);
                string eskiAciklama = reader["Aciklama"]?.ToString() ?? "";
                DateTime eskiTarih = Convert.ToDateTime(reader["Tarih"]);
                reader.Close();

                // Güncelleme sorgusu
                string query = @"
            UPDATE Toner SET
                Firma_adi = @FirmaAdi,
                Toner_Model = @TonerModel,
                Adet = @Adet,
                Aciklama = @Aciklama,
                Tarih = @Tarih
            WHERE id = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirmaAdi", firmaAdi);
                    cmd.Parameters.AddWithValue("@TonerModel", tonerModel);
                    cmd.Parameters.AddWithValue("@Adet", (object)adet ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Aciklama", string.IsNullOrWhiteSpace(aciklama) ? (object)DBNull.Value : aciklama);
                    cmd.Parameters.AddWithValue("@Tarih", tarih);
                    cmd.Parameters.AddWithValue("@ID", secilenTonerId);

                    try
                    {
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            // 🔍 Değişen alanları logla
                            List<string> degisiklikler = new List<string>();
                            if (firmaAdi != eskiFirma)
                                degisiklikler.Add($"Firma_adi: \"{eskiFirma}\" → \"{firmaAdi}\"");
                            if (tonerModel != eskiModel)
                                degisiklikler.Add($"Toner_Model: \"{eskiModel}\" → \"{tonerModel}\"");
                            if (adet != eskiAdet)
                                degisiklikler.Add($"Adet: \"{eskiAdet}\" → \"{adet}\"");
                            if (aciklama != eskiAciklama)
                                degisiklikler.Add($"Aciklama: \"{eskiAciklama}\" → \"{aciklama}\"");
                            if (tarih != eskiTarih)
                                degisiklikler.Add($"Tarih: \"{eskiTarih:dd.MM.yyyy}\" → \"{tarih:dd.MM.yyyy}\"");

                            if (degisiklikler.Any())
                            {
                                string detay = $"ID: {secilenTonerId} | {string.Join(" | ", degisiklikler)} | Kullanıcı: {KullaniciContext.KullaniciAdi} | Tarih: {DateTime.Now:dd.MM.yyyy HH:mm}";
                                Helpers.Logger.Log("Güncelleme", "Toner", detay);
                            }

                            MessageBox.Show("Güncelleme başarılı.");
                            ListeleTonerler();
                        }
                        else
                        {
                            MessageBox.Show("Güncelleme başarısız.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            string firmaAdi = txtFirmaAdi.Text.Trim();
            string tonerModel = txtTonerModel.Text.Trim();
            string adet = txtAdet.Text.Trim();
            string aciklama = txtAciklama.Text.Trim();
            string tarih = txtTarih.Text.Trim();

            StringBuilder query = new StringBuilder("SELECT * FROM Toner WHERE 1=1");
            var parameters = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(firmaAdi))
            {
                query.Append(" AND Firma_adi LIKE @firma");
                parameters.Add(new SqlParameter("@firma", "%" + firmaAdi + "%"));
            }
            if (!string.IsNullOrWhiteSpace(tonerModel))
            {
                query.Append(" AND Toner_Model LIKE @model");
                parameters.Add(new SqlParameter("@model", "%" + tonerModel + "%"));
            }
            if (!string.IsNullOrWhiteSpace(adet))
            {
                query.Append(" AND Adet = @adet");
                if (int.TryParse(adet, out int parsedAdet))
                    parameters.Add(new SqlParameter("@adet", parsedAdet));
            }
            if (!string.IsNullOrWhiteSpace(aciklama))
            {
                query.Append(" AND Aciklama LIKE @aciklama");
                parameters.Add(new SqlParameter("@aciklama", "%" + aciklama + "%"));
            }
            if (!string.IsNullOrWhiteSpace(tarih))
            {
                query.Append(" AND CONVERT(varchar, Tarih, 23) = @tarih");
                parameters.Add(new SqlParameter("@tarih", tarih));
            }

            string connStr = DbHelper.GetConnectionString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(query.ToString(), conn);
                foreach (var p in parameters)
                {
                    da.SelectCommand.Parameters.Add(p);
                }

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvToner.DataSource = dt;
            }
        }
    }
}
