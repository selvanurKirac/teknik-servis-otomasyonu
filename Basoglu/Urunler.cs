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
    public partial class Urunler : Form
    {
        public Urunler()
        {
            InitializeComponent();


        }


        


        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            Form form = new UrunEkle();
            form.ShowDialog();
        }

        private void btnStokEkle_Click(object sender, EventArgs e)
        {
            Form form = new UrunGuncelle();
            form.ShowDialog();

        }

        private void btnUrunGoruntule_Click(object sender, EventArgs e)
        {
            Form form = new UrunleriGoruntule();
            form.ShowDialog();

        }
    }
}
