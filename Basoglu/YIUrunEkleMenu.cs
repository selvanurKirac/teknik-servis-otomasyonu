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
    public partial class YIUrunEkleMenu : Form
    {

        public YIUrunEkleMenu()
        {
            InitializeComponent();
         
        }

        private void checkBoxStoktanEkle_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxStoktanEkle.Checked)
            {
                LoadFormIntoPanel(new YIStoktanUrunEkle());
            }
            else {
                LoadFormIntoPanel(new YIUrunEkle());
            }


            }

        private void LoadFormIntoPanel(Form childForm)
        {
            panelUrun.Controls.Clear();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill; // ÖNEMLİ
            panelUrun.AutoScroll = true; // Eğer içeriği kaydırmak istersen
            panelUrun.Controls.Add(childForm);
            int newWidth = (int)(childForm.Width * 1.5);
            int newHeight = (int)(childForm.Height * 1.5);
            this.Size = new Size(newWidth, newHeight);
            this.MinimumSize = new Size(newWidth, newHeight);

            childForm.Show();
        }

        
    }
}
