using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Basoglu
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnVeriTabani_Click(object sender, EventArgs e)
        {
            VeriTabani form = new VeriTabani();
            form.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string sifre = txtSifre.Text.Trim();

            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connStr = database.DbHelper.GetConnectionString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open(); // bağlantı test

                    // Kullanıcılar tablosuna erişimi test et
                    string query = "SELECT COUNT(*) FROM Kullanicilar WHERE Kullanici_adi = @kadi AND Sifre = @sifre";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@kadi", kullaniciAdi);
                    cmd.Parameters.AddWithValue("@sifre", sifre);

                    int sonuc = (int)cmd.ExecuteScalar();

                    if (sonuc > 0)
                    {
                        KullaniciContext.KullaniciAdi = txtKullaniciAdi.Text.Trim();

                        Helpers.Logger.Log("Giriş", "KullaniciLog", $"Kullanıcı '{kullaniciAdi}' başarılı giriş yaptı.");

                        Form form = new AnaMenu();
                        form.Show();
                        this.Hide();
                      

                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre yanlış! Tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSifre.Clear();
                        txtKullaniciAdi.Focus();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Eğer tabloya erişilemiyorsa (örneğin tablo yoksa), bağlantı var ama yetki yoktur
                if (sqlEx.Message.Contains("Kullanicilar") || sqlEx.Number == 229) // 229: Yetki yok
                {
                    MessageBox.Show("Veritabanına erişildi ancak 'Kullanicilar' tablosuna yetkiniz yok.\nLütfen sistem yöneticinizle iletişime geçin.", "Yetki Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Bağlantı hatası varsa veritabanı ayarlarını aç
                    MessageBox.Show("Veritabanına bağlanılamadı! Bağlantı ayarlarını kontrol edin.\n\n" + sqlEx.Message,
                        "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    VeriTabani ayarFormu = new VeriTabani();
                    ayarFormu.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beklenmedik bir hata oluştu:\n\n" + ex.Message,
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
