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
    public partial class ServisFirmaMenu : Form
    {
        public ServisFirmaMenu()
        {
            InitializeComponent();


        }

        


        private void btnFirmaEkle_Click(object sender, EventArgs e)
        {
            Form form = new ServisFirma();
            form.ShowDialog();

        }

        private void btnFirmaGüncelle_Click(object sender, EventArgs e)
        {
            Form form = new ServisFirmaGuncelle();
            form.ShowDialog();

        }

        private void btnFirmaGoruntule_Click(object sender, EventArgs e)
        {
            Form form = new ServisFirmaGoruntule();
            form.ShowDialog();

        }
    }
}
