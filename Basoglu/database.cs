using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace Basoglu
{
    internal class database
    {
        public static class DbHelper
        {
            public static string GetConnectionString()
            {
                string iniPath = Application.StartupPath + "\\settings.ini";
                IniFile ini = new IniFile(iniPath);

                string server = ini.Read("Database", "Server");
                string db = ini.Read("Database", "Name");
                string user = ini.Read("Database", "User");
                string password = ini.Read("Database", "Password");

                return $"Server={server};Database={db};User Id={user};Password={password};";
            }
        }

    }
}
