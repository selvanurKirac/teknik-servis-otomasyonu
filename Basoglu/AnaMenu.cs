using System;
using System.Net.Http;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace Basoglu
{
    public partial class AnaMenu : Form
    {
        DateTime sistemSaati;
        private System.Windows.Forms.Timer saatTimer;
        private System.Windows.Forms.Timer kurTimer;

        public AnaMenu()
        {
            InitializeComponent();
        }

        private void AnaMenu_Load(object sender, EventArgs e)
        {
            // Sistem saati başlat
            sistemSaati = DateTime.Now;
            lblSaat.Text = sistemSaati.ToString("HH:mm:ss");

            saatTimer = new System.Windows.Forms.Timer();
            saatTimer.Interval = 1000;
            saatTimer.Tick += SaatTimer_Tick;
            saatTimer.Start();

            // Kur bilgilerini ilk kez çek
            _ = UpdateKurlarAsync();

            // Kur güncelleme zamanlayıcısı
            kurTimer = new System.Windows.Forms.Timer();
            kurTimer.Interval = 60000; // 1 dakika
            kurTimer.Tick += async (s, ev) => await UpdateKurlarAsync();
            kurTimer.Start();
        }

        private void SaatTimer_Tick(object sender, EventArgs e)
        {
            sistemSaati = sistemSaati.AddSeconds(1);
            lblSaat.Text = sistemSaati.ToString("HH:mm:ss");
        }

        private async System.Threading.Tasks.Task UpdateKurlarAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    // Gerçek bir tarayıcı gibi User-Agent başlığı ekle
                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36");

                    string html = await client.GetStringAsync("https://dovizborsa.com/");

                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);

                    var usdNode = doc.DocumentNode.SelectSingleNode("/html/body/div/div[2]/div/div[1]/div[1]/div/div[1]/div[1]/div[2]/span[1]");
                    var eurNode = doc.DocumentNode.SelectSingleNode("/html/body/div/div[2]/div/div[1]/div[1]/div/div[1]/div[2]/div[2]/span[1]");

                    string usdText = usdNode?.InnerText.Trim() ?? "USD yok";
                    string eurText = eurNode?.InnerText.Trim() ?? "EUR yok";

                    Invoke(new Action(() =>
                    {
                        lblUsd.Text = usdText;
                        lblEur.Text = eurText;
                    }));
                }
            }
            catch (Exception ex)
            {
                 Invoke(new Action(() =>
                {
                    lblUsd.Text = "HATA: " + ex.Message;
                    lblEur.Text = "HATA: " + ex.Message;
                }));
            }
        }


        private void btnUrunler_Click(object sender, EventArgs e)
        {
            Form form = new Urunler();
            form.ShowDialog();
        }

        

        private void btnServisFirma_Click(object sender, EventArgs e)
        {
            Form form = new ServisFirmaMenu();
            form.ShowDialog();
        }

        private void btnYapilanIsler_Click(object sender, EventArgs e)
        {
            Form form = new YapilanIslerMenu();
            form.ShowDialog();
        }

        private void btnGaranti_Click(object sender, EventArgs e)
        {
            Form form = new GarantiMenu();
            form.ShowDialog();
        }

        private void btnToner_Click(object sender, EventArgs e)
        {
            Form form = new TonerMenu();
            form.ShowDialog();
        }

        private void btnFirma_Click(object sender, EventArgs e)
        {
            Form form = new Firma();
            form.ShowDialog();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
