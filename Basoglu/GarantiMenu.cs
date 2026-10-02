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
    public partial class GarantiMenu : Form
    {
        public GarantiMenu()
        {
            InitializeComponent();
        }

      
        private void btnGarantiGoruntule_Click(object sender, EventArgs e)
        {
            Form form = new GarantiGoruntule();
            form.ShowDialog();

        }

        private void btnGarantiEkle_Click(object sender, EventArgs e)
        {
            Form form = new GarantiEkle();
            form.ShowDialog();

        }

        private void btnGarantiGuncelle_Click(object sender, EventArgs e)
        {
            Form form = new GarantiGuncelle();
            form.ShowDialog();


        }

    }
}
