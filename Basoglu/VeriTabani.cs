using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Basoglu
{
    public partial class VeriTabani : Form
    {
        public VeriTabani()
        {
            InitializeComponent();
        }

        private void btnVeritabanıGüncelle_Click(object sender, EventArgs e)
        {
            string iniPath = Application.StartupPath + "\\settings.ini";
            IniFile ini = new IniFile(iniPath);

            ini.Write("Database", "Server", txtServer.Text);
            ini.Write("Database", "Name", txtDatabase.Text);
            ini.Write("Database", "User", txt_Kullanici_Adi.Text);
            ini.Write("Database", "Password", txtSifre.Text);

            MessageBox.Show("Bağlantı ayarları kaydedildi.");

        }

        private void btnVeriTabaniTest_Click(object sender, EventArgs e)
        {
            string connectionString = Basoglu.database.DbHelper.GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Veritabanına başarılı bir şekilde bağlanıldı!", "Bağlantı Testi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bağlantı başarısız: " + ex.Message, "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }



    public class IniFile
    {
        public string Path;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
            string key, string def, StringBuilder retVal,
            int size, string filePath);

        public IniFile(string path)
        {
            this.Path = path;
        }

        public void Write(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, this.Path);
        }

        public string Read(string section, string key)
        {
            StringBuilder temp = new StringBuilder(255);
            GetPrivateProfileString(section, key, "", temp, 255, this.Path);
            return temp.ToString();
        }
    }

}
