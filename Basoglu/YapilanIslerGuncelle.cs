using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Basoglu.Helpers;

namespace Basoglu
{
    public partial class YapilanIslerGuncelle : Form
    {
        private YapilanIs secilenIs;

        public YapilanIslerGuncelle(YapilanIs yapilanIs)
        {
            InitializeComponent();
            secilenIs = yapilanIs;

            // ComboBox içerikleri tanımlanıyor
            cmbServis.Items.Clear();
            cmbServis.Items.Add("Firmada");      // index 0 → false
            cmbServis.Items.Add("İşyerinde");  // index 1 → true

            cmbSonuc.Items.Clear();
            cmbSonuc.Items.Add("Tamamlanmadı");   // index 0 → false
            cmbSonuc.Items.Add("Tamamlandı");    // index 1 → true

            this.Load += YapilanIslerGuncelle_Load;
        }

        private void YapilanIslerGuncelle_Load(object sender, EventArgs e)
        {
            cmbFirma.Text = secilenIs.FirmaIsmi;
            cmbServis.SelectedIndex = secilenIs.ServisTuru ? 1 : 0;
            cmbSonuc.SelectedIndex = secilenIs.Sonuc ? 1 : 0;
            rtbAciklama.Text = secilenIs.Aciklama;
            txtFiyat.Text = secilenIs.Fiyat.ToString();
            txtTarih.Text = secilenIs.Tarih.ToString("yyyy-MM-dd");
        }


        private void btnUrunleriGuncelle_Click(object sender, EventArgs e)
        {
            Form form = new YIUrunleriGuncelleMenu(secilenIs.Id);
            form.ShowDialog();
            

        }

        private void btnTamirEdilenleriGüncelle_Click(object sender, EventArgs e)
        {
            Form form = new CihazTamirGuncelleMenu(secilenIs.Id);
            form.ShowDialog();
            
        }

        private void btnYapilanIsGuncelle_Click(object sender, EventArgs e)
        {
            string firma = cmbFirma.Text.Trim();
            string fiyatStr = txtFiyat.Text.Trim();
            string tarihStr = txtTarih.Text.Trim();
            string aciklama = rtbAciklama.Text.Trim();

            if (string.IsNullOrWhiteSpace(firma) ||
                cmbServis.SelectedIndex == -1 ||
                cmbSonuc.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(fiyatStr) ||
                string.IsNullOrWhiteSpace(tarihStr))
            {
                MessageBox.Show("Lütfen tüm zorunlu alanları doldurun.");
                return;
            }

            if (!decimal.TryParse(fiyatStr, out decimal fiyat))
            {
                MessageBox.Show("Fiyat geçerli bir sayı olmalıdır.");
                return;
            }

            if (!DateTime.TryParse(tarihStr, out DateTime tarih))
            {
                MessageBox.Show("Tarih geçerli bir tarih formatında olmalıdır.");
                return;
            }

            bool servisTuru = cmbServis.SelectedIndex == 1;
            bool sonuc = cmbSonuc.SelectedIndex == 1;

            // 🔍 Değişen alanları tespit et
            List<string> degisiklikler = new List<string>();

            if (firma != secilenIs.FirmaIsmi)
                degisiklikler.Add($"Firma: {secilenIs.FirmaIsmi} → {firma}");

            if (servisTuru != secilenIs.ServisTuru)
                degisiklikler.Add($"Servis Türü: {(secilenIs.ServisTuru ? "İşyerinde" : "Firmada")} → {(servisTuru ? "İşyerinde" : "Firmada")}");

            if (sonuc != secilenIs.Sonuc)
                degisiklikler.Add($"Sonuç: {(secilenIs.Sonuc ? "Tamamlandı" : "Tamamlanmadı")} → {(sonuc ? "Tamamlandı" : "Tamamlanmadı")}");

            if (fiyat != secilenIs.Fiyat)
                degisiklikler.Add($"Fiyat: {secilenIs.Fiyat} ₺ → {fiyat} ₺");

            if (tarih != secilenIs.Tarih)
                degisiklikler.Add($"Tarih: {secilenIs.Tarih:dd.MM.yyyy} → {tarih:dd.MM.yyyy}");

            if (aciklama != secilenIs.Aciklama)
                degisiklikler.Add($"Açıklama: '{secilenIs.Aciklama}' → '{aciklama}'");

            if (degisiklikler.Count == 0)
            {
                MessageBox.Show("Herhangi bir değişiklik yapılmadı.");
                return;
            }

            try
            {
                string connStr = database.DbHelper.GetConnectionString();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"
                UPDATE Yapilan_Isler
                SET Firma_ismi = @firma,
                    Servis_turu = @servisTuru,
                    Aciklama = @aciklama,
                    Sonuc = @sonuc,
                    Fiyat = @fiyat,
                    Tarih = @tarih,
                    Degistirilme_Tarihi = GETDATE()
                WHERE id = @id", conn);

                    cmd.Parameters.AddWithValue("@firma", firma);
                    cmd.Parameters.AddWithValue("@servisTuru", servisTuru);
                    cmd.Parameters.AddWithValue("@aciklama", aciklama);
                    cmd.Parameters.AddWithValue("@sonuc", sonuc);
                    cmd.Parameters.AddWithValue("@fiyat", fiyat);
                    cmd.Parameters.AddWithValue("@tarih", tarih);
                    cmd.Parameters.AddWithValue("@id", secilenIs.Id);

                    cmd.ExecuteNonQuery();
                }

                string degisimMetni = string.Join(", ", degisiklikler);
                Logger.Log("Güncelleme", "Yapilan_Isler", $"Yapılan İş ID: {secilenIs.Id} güncellendi. Değişiklikler: {degisimMetni}");

                MessageBox.Show("Güncelleme başarılı.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }


       

        private void btnYIGuncelleUrunEkle_Click(object sender, EventArgs e)
        {
            Form form = new YIUrunGuncelleUrunEkle(secilenIs.Id); 
            form.ShowDialog();
            
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new YIGuncelleCihazTamirEkle(secilenIs.Id);
            
            form.ShowDialog();

            
        }

        

        private void btnToner_Click(object sender, EventArgs e)
        {
            Form form = new TonerMenu();
            form.ShowDialog();

        }

        private void btnGaranti_Click(object sender, EventArgs e)
        {
            Form form = new GarantiMenu();
            form.ShowDialog();

        }
    }
}
