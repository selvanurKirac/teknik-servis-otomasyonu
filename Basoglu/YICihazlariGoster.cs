using System;
using System.Linq;
using System.Windows.Forms;

namespace Basoglu
{
    public partial class YICihazlariGoster : Form
    {
        public YICihazlariGoster()
        {
            InitializeComponent();

            // Grid ayarları
            dgvCihazlar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCihazlar.MultiSelect = false;
            dgvCihazlar.ReadOnly = true;
            dgvCihazlar.AllowUserToAddRows = false;
            dgvCihazlar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvServisler.ReadOnly = true;
            dgvServisler.AllowUserToAddRows = false;
            dgvServisler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Eventler
            dgvCihazlar.SelectionChanged += dgvCihazlar_SelectionChanged;
            dgvCihazlar.CellContentClick += dgvCihazlar_CellContentClick;
            dgvServisler.CellContentClick += dgvServisler_CellContentClick;

            // Başlangıç listesi
            ListeYenile();
        }

        // Cihazları gridde listele
        private void ListeYenile()
        {
            dgvCihazlar.SelectionChanged -= dgvCihazlar_SelectionChanged;

            dgvCihazlar.Columns.Clear();
            dgvCihazlar.DataSource = YICihazlar.Cihazlar
                .Select((cihaz, i) => new
                {
                    No = i + 1,
                    cihaz.Isim,
                    cihaz.Cihaz_model,
                    cihaz.Adet
                })
                .ToList();

            var silBtn = new DataGridViewButtonColumn
            {
                Name = "Sil",
                Text = "Sil",
                UseColumnTextForButtonValue = true,
                Width = 60
            };
            dgvCihazlar.Columns.Add(silBtn);

            if (dgvCihazlar.Rows.Count > 0)
            {
                dgvCihazlar.Rows[0].Selected = true;
                dgvCihazlar_SelectionChanged(null, null);
            }
            else
            {
                dgvServisler.DataSource = null;
            }

            dgvCihazlar.SelectionChanged += dgvCihazlar_SelectionChanged;
        }

        // Seçili cihaza ait servis firmalarını listele
        private void dgvCihazlar_SelectionChanged(object sender, EventArgs e)
        {
            dgvServisler.Columns.Clear();
            dgvServisler.DataSource = null;

            if (dgvCihazlar.SelectedRows.Count == 0) return;
            int idx = dgvCihazlar.SelectedRows[0].Index;
            if (idx < 0 || idx >= YICihazlar.Cihazlar.Count) return;

            Cihaz cihaz = YICihazlar.Cihazlar[idx];
            ListeServisleriYenile(cihaz);
        }

        // Belirli cihazın servis listesini gride yükler
        private void ListeServisleriYenile(Cihaz cihaz)
        {
            dgvServisler.Columns.Clear();
            dgvServisler.DataSource = cihaz.ServisFirmalari
                .Select((firma, i) => new
                {
                    No = i + 1,
                    firma.FirmaIsmi,
                    firma.FirmaTel,
                    firma.FirmaAdres,
                    firma.FirmaEposta,
                    Eklenme = firma.FirmaEklenmeTarihi.ToShortDateString(),
                    Alım = firma.AlimTarihi.ToShortDateString(),
                    Teslim = firma.TeslimTarihi?.ToShortDateString() ?? "-"
                })
                .ToList();

            var silBtn = new DataGridViewButtonColumn
            {
                Name = "Sil",
                Text = "Sil",
                UseColumnTextForButtonValue = true,
                Width = 60
            };
            dgvServisler.Columns.Add(silBtn);
        }

        // Cihaz silme işlemi
        private void dgvCihazlar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != dgvCihazlar.Columns["Sil"].Index || e.RowIndex < 0) return;

            if (e.RowIndex < YICihazlar.Cihazlar.Count)
            {
                YICihazlar.Cihazlar.RemoveAt(e.RowIndex);
                ListeYenile();

                if (dgvCihazlar.Rows.Count > 0)
                {
                    dgvCihazlar.Rows[0].Selected = true;
                    dgvCihazlar_SelectionChanged(null, null);
                }
                else
                {
                    dgvServisler.DataSource = null;
                }
            }
        }

        // Servis firması silme işlemi
        private void dgvServisler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCihazlar.SelectedRows.Count == 0) return;

            int cihazIdx = dgvCihazlar.SelectedRows[0].Index;
            if (cihazIdx < 0 || cihazIdx >= YICihazlar.Cihazlar.Count) return;
            if (e.ColumnIndex != dgvServisler.Columns["Sil"].Index || e.RowIndex < 0) return;

            var cihaz = YICihazlar.Cihazlar[cihazIdx];

            if (e.RowIndex < cihaz.ServisFirmalari.Count)
            {
                cihaz.ServisFirmalari.RemoveAt(e.RowIndex);

                if (cihaz.ServisFirmalari.Count == 0)
                {
                    YICihazlar.Cihazlar.RemoveAt(cihazIdx);
                    MessageBox.Show("Servis firması kalmadığı için cihaz da silindi.");
                    ListeYenile();
                }
                else
                {
                    ListeServisleriYenile(cihaz); // sadece servisleri yenile
                }
            }
        }
    }
}
