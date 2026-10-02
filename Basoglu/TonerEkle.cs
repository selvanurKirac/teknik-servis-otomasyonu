using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Basoglu.database;

namespace Basoglu
{
    public partial class TonerEkle : Form
    {
        public TonerEkle()
        {
            InitializeComponent();
        }

        private void TemizleForm()
        {
            txtFirmaAdi.Clear();
            txtTonerModel.Clear();
            txtAdet.Clear();
            txtAciklama.Clear();
            txtTarih.Clear();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
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

            if (!DateTime.TryParseExact(txtTarih.Text.Trim(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime tarih))
            {
                MessageBox.Show("Lütfen tarihi 'gg.aa.yyyy' formatında giriniz. (Örnek: 19.03.2025)");
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
                string query = @"
            INSERT INTO Toner (Firma_adi, Toner_Model, Adet, Aciklama, Tarih)
            VALUES (@FirmaAdi, @TonerModel, @Adet, @Aciklama, @Tarih)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirmaAdi", firmaAdi);
                    cmd.Parameters.AddWithValue("@TonerModel", tonerModel);
                    cmd.Parameters.AddWithValue("@Adet", (object)adet ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Aciklama", string.IsNullOrWhiteSpace(aciklama) ? (object)DBNull.Value : aciklama);
                    cmd.Parameters.AddWithValue("@Tarih", tarih);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Toner başarıyla eklendi.");
                        TemizleForm();

                        // ✅ Log işlemi
                        string logDetay = $"Firma: \"{firmaAdi}\" | Model: \"{tonerModel}\" | Adet: {(adet.HasValue ? adet.Value.ToString() : "Belirtilmedi")} | Tarih: {tarih:dd.MM.yyyy}";

                        if (!string.IsNullOrWhiteSpace(aciklama))
                            logDetay += $" | Açıklama: \"{aciklama}\"";

                        Helpers.Logger.Log("Ekleme", "Toner", logDetay);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
            }
        }

    }
}
