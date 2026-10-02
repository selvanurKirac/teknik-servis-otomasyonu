using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basoglu
{
    public partial class YapilanIslerMenu : Form
    {
        public YapilanIslerMenu()
        {
            InitializeComponent();



        }

        private void btnYapilanIslerEkle_Click(object sender, EventArgs e)
        {
            Form form = new YapilanIsler();
            form.ShowDialog(); 
        }

        private void btnYapılanIsleriGuncelle_Click(object sender, EventArgs e)
        {
            Form form = new YapılanIslerGuncelleMenu();
            form.ShowDialog();

        }

     


        

        private void btnYapilanIsleriGoster_Click(object sender, EventArgs e)
        {
            Form form = new YapılanIslerGoster();
            form.ShowDialog();

        }
    }
}
