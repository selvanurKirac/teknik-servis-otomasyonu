using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Basoglu
{
    public partial class CihazTamir : Form
    {
        public List<YIServisFirma> servisFirmalariTemp = new List<YIServisFirma>();

        public CihazTamir()
        {
            InitializeComponent();
            FirmaIsimleriYukle();
            ServisFirmalariYukle();

        }
        


        private void FirmaIsimleriYukle()
        {
            cmbFirmaIsmi.Items.Clear();

            string connStr = database.DbHelper.GetConnectionString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT Firma_ismi FROM Servis_Firma WHERE Firma_ismi IS NOT NULL", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cmbFirmaIsmi.Items.Add(reader["Firma_ismi"].ToString());
                }
            }
        }

        private void ServisFirmalariYukle()
        {
            string connStr = database.DbHelper.GetConnectionString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Servis_Firma", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvServisFirmalar.DataSource = dt;
            }
        }

       

      

        private void dgvServisFirmalar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvServisFirmalar.Rows[e.RowIndex].Selected = true;
            }
        }

        private void btnServisFirmalaraEkle_Click(object sender, EventArgs e)
        {
            if (dgvServisFirmalar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir servis firması seçin.");
                return;
            }

            if (!DateTime.TryParse(textBox1.Text.Trim(), out DateTime alimTarihi))
            {
                MessageBox.Show("Alım tarihi geçerli bir tarih olmalıdır.");
                return;
            }

            DateTime? teslimTarihi = null;
            if (DateTime.TryParse(textBox2.Text.Trim(), out DateTime parsedTeslim))
            {
                teslimTarihi = parsedTeslim;
            }

            var row = dgvServisFirmalar.SelectedRows[0];
            int firmaId = Convert.ToInt32(row.Cells["id"].Value);

            if (servisFirmalariTemp.Any(f => f.Id == firmaId))
            {
                MessageBox.Show("Bu servis firması zaten eklendi.");
                return;
            }

            var firma = new YIServisFirma
            {
                Id = firmaId,
                FirmaIsmi = row.Cells["Firma_ismi"].Value?.ToString(),
                FirmaTel = row.Cells["Firma_tel"].Value?.ToString(),
                FirmaAdres = row.Cells["Firma_adres"].Value?.ToString(),
                FirmaEposta = row.Cells["Firma_eposta"].Value?.ToString(),
                FirmaEklenmeTarihi = Convert.ToDateTime(row.Cells["Firma_eklenme_tarihi"].Value),
                AlimTarihi = alimTarihi,
                TeslimTarihi = teslimTarihi
            };

            servisFirmalariTemp.Add(firma);

            MessageBox.Show("Servis firması başarıyla eklendi.");
            // Girdileri temizle
            cmbFirmaIsmi.SelectedIndex = -1;
            txtTelefon.Clear();
            txtAdres.Clear();
            txtEposta.Clear();
            txtEklenmeTarihi.Clear();
            textBox1.Clear(); // Alım tarihi
            textBox2.Clear(); // Teslim tarihi


        }

        private void btnCihazlaraEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCihazIsmi.Text))
            {
                MessageBox.Show("Cihaz ismi boş olamaz.");
                return;
            }

            if (!int.TryParse(txtCihazAdet.Text.Trim(), out int adet))
            {
                MessageBox.Show("Cihaz adedi geçerli bir sayı olmalıdır.");
                return;
            }

            if (servisFirmalariTemp.Count == 0)
            {
                MessageBox.Show("En az bir servis firması seçilmelidir.");
                return;
            }

            YICihazlar.Cihazlar.Add(new Cihaz
            {
                Isim = txtCihazIsmi.Text.Trim(),
                Adet = adet,
                Cihaz_model = string.IsNullOrWhiteSpace(txtCihaz_model.Text) ? null : txtCihaz_model.Text.Trim(),
                ServisFirmalari = new List<YIServisFirma>(servisFirmalariTemp)
            });

            // Temizle
            servisFirmalariTemp.Clear();
            txtCihazIsmi.Clear();
            txtCihaz_model.Clear();
            txtCihazAdet.Clear();
            textBox1.Clear();
            textBox2.Clear();
            cmbFirmaIsmi.SelectedIndex = -1;
            txtTelefon.Clear();
            txtAdres.Clear();
            txtEposta.Clear();
            txtEklenmeTarihi.Clear();

            MessageBox.Show("Cihaz başarıyla eklendi.");

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbFirmaIsmi.Text) &&
                string.IsNullOrWhiteSpace(txtTelefon.Text) &&
                string.IsNullOrWhiteSpace(txtAdres.Text) &&
                string.IsNullOrWhiteSpace(txtEposta.Text) &&
                string.IsNullOrWhiteSpace(txtEklenmeTarihi.Text))
            {
                MessageBox.Show("En az bir filtre girmelisiniz.");
                return;
            }

            List<string> kosullar = new List<string>();
            List<SqlParameter> parametreler = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(cmbFirmaIsmi.Text))
            {
                kosullar.Add("Firma_ismi LIKE @firma");
                parametreler.Add(new SqlParameter("@firma", "%" + cmbFirmaIsmi.Text.Trim() + "%"));
            }

            if (!string.IsNullOrWhiteSpace(txtTelefon.Text))
            {
                kosullar.Add("Firma_tel LIKE @tel");
                parametreler.Add(new SqlParameter("@tel", "%" + txtTelefon.Text.Trim() + "%"));
            }

            if (!string.IsNullOrWhiteSpace(txtAdres.Text))
            {
                kosullar.Add("Firma_adres LIKE @adres");
                parametreler.Add(new SqlParameter("@adres", "%" + txtAdres.Text.Trim() + "%"));
            }

            if (!string.IsNullOrWhiteSpace(txtEposta.Text))
            {
                kosullar.Add("Firma_eposta LIKE @eposta");
                parametreler.Add(new SqlParameter("@eposta", "%" + txtEposta.Text.Trim() + "%"));
            }

            if (!string.IsNullOrWhiteSpace(txtEklenmeTarihi.Text))
            {
                kosullar.Add("CONVERT(NVARCHAR, Firma_eklenme_tarihi, 104) LIKE @tarih");
                parametreler.Add(new SqlParameter("@tarih", "%" + txtEklenmeTarihi.Text.Trim() + "%"));
            }

            string whereClause = kosullar.Count > 0 ? "WHERE " + string.Join(" AND ", kosullar) : "";
            string query = "SELECT * FROM Servis_Firma " + whereClause;

            string connStr = database.DbHelper.GetConnectionString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddRange(parametreler.ToArray());

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvServisFirmalar.DataSource = dt;
            }

        }

        private void dgvServisFirmalar_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvServisFirmalar.SelectedRows.Count > 0)
            {
                var row = dgvServisFirmalar.SelectedRows[0];
                cmbFirmaIsmi.Text = row.Cells["Firma_ismi"].Value?.ToString();
                txtTelefon.Text = row.Cells["Firma_tel"].Value?.ToString();
                txtAdres.Text = row.Cells["Firma_adres"].Value?.ToString();
                txtEposta.Text = row.Cells["Firma_eposta"].Value?.ToString();
                txtEklenmeTarihi.Text = Convert.ToDateTime(row.Cells["Firma_eklenme_tarihi"].Value).ToString("dd.MM.yyyy");
            }
        }
    }
}
