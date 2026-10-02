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
    public partial class Firma : Form
    {
        public Firma()
        {
            InitializeComponent();
            LoadFormIntoPanel(new FirmaGoruntule());
              
        }

        private void LoadFormIntoPanel(Form childForm)
        {
            panelFirma.Controls.Clear(); // Öncekini temizle

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill; // Otomatik büyümesin

            // Formun boyutuna göre paneli ayarla
            panelFirma.Size = childForm.Size;

            childForm.Location = new Point(0, 0); // Sol üstten başlasın
            int newWidth = (int)(childForm.Width * 1.5);
            int newHeight = (int)(childForm.Height * 1.5);
            this.Size = new Size(newWidth, newHeight);
            this.MinimumSize = new Size(newWidth, newHeight);
            panelFirma.Controls.Add(childForm);
            childForm.Show();
        }


        private void btnFirmaEkle_Click(object sender, EventArgs e)
        {
            
            LoadFormIntoPanel(new FirmaEkle());


        }

        private void btnFirmaGüncelle_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new FirmaGuncelle());

        }

        private void btnFirmaGoruntule_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new FirmaGoruntule());

        }
    }
}
