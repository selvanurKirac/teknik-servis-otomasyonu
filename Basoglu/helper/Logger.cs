using System;
using System.Data.SqlClient;

namespace Basoglu.Helpers
{
    public static class Logger
    {
        public static void Log(string islemTipi, string tabloAdi, string detay)
        {
            try
            {
                string kullaniciAdi = KullaniciContext.KullaniciAdi;
                string connStr = database.DbHelper.GetConnectionString();

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        @"INSERT INTO KullaniciLog 
                      (KullaniciAdi, IslemTipi, TabloAdi, Detay, IslemTarihi) 
                      VALUES (@kullaniciAdi, @islemTipi, @tabloAdi, @detay, GETDATE())", conn);

                    cmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                    cmd.Parameters.AddWithValue("@islemTipi", islemTipi);
                    cmd.Parameters.AddWithValue("@tabloAdi", tabloAdi);
                    cmd.Parameters.AddWithValue("@detay", detay);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("log_error.txt", $"{DateTime.Now}: Loglama hatası - {ex.Message}\n"); } }}}




