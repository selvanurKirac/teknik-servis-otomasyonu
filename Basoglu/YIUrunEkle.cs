using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basoglu
{
    public partial class YIUrunEkle : Form
    {
        public YIUrunEkle()
        {
            InitializeComponent();
        }

        private void btnUrunlereEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUrunIsmi.Text))
            {
                MessageBox.Show("Ürün ismi boş bırakılamaz.");
                return;
            }

            if (!int.TryParse(txtStok.Text.Trim(), out int stok))
            {
                MessageBox.Show("Stok değeri geçerli bir sayı olmalıdır.");
                return;
            }

            YIUrun yeniUrun = new YIUrun
            {
                UrunIsmi = txtUrunIsmi.Text.Trim(),
                ModelNumarasi = string.IsNullOrWhiteSpace(txtModel.Text) ? null : txtModel.Text.Trim(),
                SeriNo = string.IsNullOrWhiteSpace(txtSeriNumarasi.Text) ? null : txtSeriNumarasi.Text.Trim(),
                Miktar = stok,
                Kaynak = false // dışardan geldiği için false
            };

            YIUrunler.Ekle(yeniUrun);
            MessageBox.Show("Yeni ürün listeye eklendi.");

            foreach (Form f in Application.OpenForms)
            {
                if (f is YIUrunleriGoster gosterForm)
                {
                    gosterForm.ListeYenile();
                    break;
                }
            }

            txtUrunIsmi.Clear();
            txtModel.Clear();
            txtSeriNumarasi.Clear();
            txtStok.Clear();

        }
    }
}
