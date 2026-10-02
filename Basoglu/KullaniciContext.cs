namespace Basoglu
{
    public static class KullaniciContext
    {
        private static string _kullaniciAdi;
        public static string KullaniciAdi
        {
            get => _kullaniciAdi;
            set
            {
                if (string.IsNullOrWhiteSpace(_kullaniciAdi))
                    _kullaniciAdi = value;
            }
        }
    }
}
