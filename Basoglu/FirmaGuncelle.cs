using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static Basoglu.database;

namespace Basoglu
{
    public partial class FirmaGuncelle : Form
    {
        private int? seciliFirmaId = null;

        public FirmaGuncelle()
        {
            InitializeComponent();
            FirmaIsimleriniYukle();
            FirmaListele();
            dvgFirma.SelectionChanged += dvgFirma_SelectionChanged;
        }

        private void FirmaIsimleriniYukle()
        {
            cmbFirma.Items.Clear();
            string connStr = DbHelper.GetConnectionString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT DISTINCT Firma_ismi FROM Firmalar";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbFirma.Items.Add(reader["Firma_ismi"].ToString());
                    }
                }
            }
        }

        private void FirmaListele()
        {
            string connStr = DbHelper.GetConnectionString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT * FROM Firmalar WHERE 1=1";

                if (!string.IsNullOrWhiteSpace(cmbFirma.Text))
                    query += " AND Firma_ismi LIKE @isim";
                if (!string.IsNullOrWhiteSpace(txtFirmaTel.Text))
                    query += " AND Firma_tel LIKE @tel";
                if (!string.IsNullOrWhiteSpace(txtFirmaAdres.Text))
                    query += " AND Firma_adres LIKE @adres";
                if (!string.IsNullOrWhiteSpace(txtFirmaEposta.Text))
                    query += " AND Firma_eposta LIKE @eposta";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrWhiteSpace(cmbFirma.Text))
                        cmd.Parameters.AddWithValue("@isim", "%" + cmbFirma.Text + "%");
                    if (!string.IsNullOrWhiteSpace(txtFirmaTel.Text))
                        cmd.Parameters.AddWithValue("@tel", "%" + txtFirmaTel.Text + "%");
                    if (!string.IsNullOrWhiteSpace(txtFirmaAdres.Text))
                        cmd.Parameters.AddWithValue("@adres", "%" + txtFirmaAdres.Text + "%");
                    if (!string.IsNullOrWhiteSpace(txtFirmaEposta.Text))
                        cmd.Parameters.AddWithValue("@eposta", "%" + txtFirmaEposta.Text + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dvgFirma.DataSource = dt;
                }
            }

            seciliFirmaId = null; // her aramada önceki seçim sıfırlanır
            Temizle();
        }

        private void dvgFirma_SelectionChanged(object sender, EventArgs e)
        {
            if (dvgFirma.SelectedRows.Count == 0) return;

            DataGridViewRow row = dvgFirma.SelectedRows[0];

            // ID null kontrolü
            if (row.Cells["id"].Value == DBNull.Value || row.Cells["id"].Value == null)
            {
                seciliFirmaId = null;
                Temizle();
                return;
            }

            seciliFirmaId = Convert.ToInt32(row.Cells["id"].Value);

            cmbFirma.Text = row.Cells["Firma_ismi"].Value?.ToString();
            txtFirmaTel.Text = row.Cells["Firma_tel"].Value?.ToString();
            txtFirmaAdres.Text = row.Cells["Firma_adres"].Value?.ToString();
            txtFirmaEposta.Text = row.Cells["Firma_eposta"].Value?.ToString();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            FirmaListele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (seciliFirmaId == null)
            {
                MessageBox.Show("Lütfen önce bir firma seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string yeniIsim = cmbFirma.Text.Trim();
            string yeniTel = txtFirmaTel.Text.Trim();
            string yeniAdres = txtFirmaAdres.Text.Trim();
            string yeniEposta = txtFirmaEposta.Text.Trim();

            string connStr = DbHelper.GetConnectionString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // 🔍 Eski verileri al
                string eskiIsim = "", eskiTel = "", eskiAdres = "", eskiEposta = "";
                using (SqlCommand getCmd = new SqlCommand("SELECT Firma_ismi, Firma_tel, Firma_adres, Firma_eposta FROM Firmalar WHERE id = @id", conn))
                {
                    getCmd.Parameters.AddWithValue("@id", seciliFirmaId.Value);
                    using (SqlDataReader reader = getCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            eskiIsim = reader["Firma_ismi"]?.ToString() ?? "";
                            eskiTel = reader["Firma_tel"]?.ToString() ?? "";
                            eskiAdres = reader["Firma_adres"]?.ToString() ?? "";
                            eskiEposta = reader["Firma_eposta"]?.ToString() ?? "";
                        }
                    }
                }

                // 🔍 Değişenleri karşılaştır
                List<string> degisenler = new List<string>();
                if (eskiIsim != yeniIsim)
                    degisenler.Add($"Firma_ismi: \"{eskiIsim}\" → \"{yeniIsim}\"");
                if (eskiTel != yeniTel)
                    degisenler.Add($"Firma_tel: \"{eskiTel}\" → \"{yeniTel}\"");
                if (eskiAdres != yeniAdres)
                    degisenler.Add($"Firma_adres: \"{eskiAdres}\" → \"{yeniAdres}\"");
                if (eskiEposta != yeniEposta)
                    degisenler.Add($"Firma_eposta: \"{eskiEposta}\" → \"{yeniEposta}\"");

                // Güncelleme sorgusu
                string query = @"UPDATE Firmalar SET 
                            Firma_ismi = @isim,
                            Firma_tel = @tel,
                            Firma_adres = @adres,
                            Firma_eposta = @eposta
                        WHERE id = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@isim", yeniIsim);
                    cmd.Parameters.AddWithValue("@tel", yeniTel);
                    cmd.Parameters.AddWithValue("@adres", yeniAdres);
                    cmd.Parameters.AddWithValue("@eposta", yeniEposta);
                    cmd.Parameters.AddWithValue("@id", seciliFirmaId.Value);
                    cmd.ExecuteNonQuery();
                }

                // ✅ Sadece değişen alanlar varsa logla
                if (degisenler.Count > 0)
                {
                    string detay = $"FirmaId: {seciliFirmaId.Value} | " + string.Join(", ", degisenler);
                    Helpers.Logger.Log("Güncelleme", "Firmalar", detay);
                }

                MessageBox.Show("Firma bilgileri güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FirmaIsimleriniYukle();
                FirmaListele();
            }
        }


        private void Temizle()
        {
            cmbFirma.Text = "";
            txtFirmaTel.Text = "";
            txtFirmaAdres.Text = "";
            txtFirmaEposta.Text = "";
        }

    }
}
