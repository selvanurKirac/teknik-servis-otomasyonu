using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Basoglu.Helpers;

namespace Basoglu
{
    public partial class YIGuncelleCihazTamirEkle : Form
    {
        private int yapilanIsId;

        public YIGuncelleCihazTamirEkle(int yapilanIsId)
        {
            InitializeComponent();
            this.yapilanIsId = yapilanIsId;
            LoadFormIntoPanel(new CihazTamir());
        }

        private void LoadFormIntoPanel(Form childForm)
        {
            panel1.Controls.Clear();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel1.Controls.Add(childForm);
            int newWidth = (int)(childForm.Width * 1.5);
            int newHeight = (int)(childForm.Height * 1.5);
            this.Size = new Size(newWidth, newHeight);
            this.MinimumSize = new Size(newWidth, newHeight);
            childForm.Show();

        }


        private void btnCihazTamirEkle_Click(object sender, EventArgs e)
        {
            if (YICihazlar.Cihazlar == null || YICihazlar.Cihazlar.Count == 0)
            {
                MessageBox.Show("Kaydedilecek cihaz bulunamadı.");
                return;
            }

            string connStr = database.DbHelper.GetConnectionString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    var cihazListesi = YICihazlar.Cihazlar.ToList();

                    // Ön kontrol: her cihaz için ayrı ayrı kontrol et, biri bile varsa işlem iptal edilsin
                    foreach (var cihaz in cihazListesi)
                    {
                        SqlCommand kontrolCmd = new SqlCommand(
                            @"SELECT COUNT(*) FROM Cihaz_Tamir 
                      INNER JOIN YICihaz ON YICihaz.id = Cihaz_Tamir.Cihaz_id
                      WHERE YICihaz.Cihaz_ismi = @Isim AND Cihaz_Tamir.Yapilan_is_id = @YapilanIsId", conn, trans);

                        kontrolCmd.Parameters.AddWithValue("@Isim", cihaz.Isim);
                        kontrolCmd.Parameters.AddWithValue("@YapilanIsId", yapilanIsId);

                        int mevcutKayit = (int)kontrolCmd.ExecuteScalar();

                        if (mevcutKayit > 0)
                            throw new Exception($"'{cihaz.Isim}' adlı cihaz bu yapılan iş için zaten kayıtlı.\nTüm işlem iptal edildi.");
                    }

                    int basariliCihazSayisi = 0;

                    foreach (var cihaz in cihazListesi)
                    {
                        SqlCommand cihazCmd = new SqlCommand(
                            @"INSERT INTO YICihaz (Cihaz_ismi, Cihaz_model, Cihaz_adet)
                      OUTPUT INSERTED.id
                      VALUES (@Isim, @CihazModel, @Adet)", conn, trans);

                        cihazCmd.Parameters.AddWithValue("@Isim", cihaz.Isim);
                        cihazCmd.Parameters.AddWithValue("@CihazModel", (object)cihaz.Cihaz_model ?? DBNull.Value);
                        cihazCmd.Parameters.AddWithValue("@Adet", cihaz.Adet);

                        int cihazId = (int)cihazCmd.ExecuteScalar();

                        Logger.Log("Ekleme", "YICihaz",
                            $"YapılanIsId: {yapilanIsId} | Cihaz eklendi: {cihaz.Isim}, Model: {cihaz.Cihaz_model ?? "Yok"}, Adet: {cihaz.Adet}");

                        foreach (var firma in cihaz.ServisFirmalari)
                        {
                            SqlCommand tamirCmd = new SqlCommand(
                                @"INSERT INTO Cihaz_Tamir (Cihaz_id, Yapilan_is_id, Servis_firma_id, Alim_tarihi, Teslim_tarihi)
                          VALUES (@CihazId, @YapilanIsId, @ServisFirmaId, @Alim, @Teslim)", conn, trans);

                            tamirCmd.Parameters.AddWithValue("@CihazId", cihazId);
                            tamirCmd.Parameters.AddWithValue("@YapilanIsId", yapilanIsId);
                            tamirCmd.Parameters.AddWithValue("@ServisFirmaId", firma.Id);
                            tamirCmd.Parameters.AddWithValue("@Alim", firma.AlimTarihi);
                            tamirCmd.Parameters.AddWithValue("@Teslim", (object)firma.TeslimTarihi ?? DBNull.Value);
                            tamirCmd.ExecuteNonQuery();

                            Logger.Log("Ekleme", "Cihaz_Tamir",
                                $"YapılanIsId: {yapilanIsId} | Cihaza servis firması eklendi: Cihaz: {cihaz.Isim}, FirmaId: {firma.Id}, Alım: {firma.AlimTarihi:yyyy-MM-dd}, Teslim: {(firma.TeslimTarihi?.ToString("yyyy-MM-dd") ?? "Yok")}");
                        }

                        basariliCihazSayisi++;
                    }

                    trans.Commit();
                    MessageBox.Show($"{basariliCihazSayisi} cihaz ve servis bilgisi başarıyla kaydedildi.");
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
                finally
                {
                    // Hatalı da olsa başarılı da olsa liste temizlenir
                    YICihazlar.Cihazlar.Clear();
                }
            }
        }

        private void btnCihazlariGoster_Click(object sender, EventArgs e)
        {
            Form form = new YICihazlariGoster();
            form.ShowDialog();
        }

        private void YIGuncelleCihazTamirEkle_Load(object sender, EventArgs e)
        {





        }
    }
}
