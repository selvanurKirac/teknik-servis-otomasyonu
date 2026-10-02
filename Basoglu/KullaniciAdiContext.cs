public static class KullaniciContext
{
    private static string _kullaniciAdi;

    public static string KullaniciAdi
    {
        get => _kullaniciAdi;
        set
        {
            if (string.IsNullOrWhiteSpace(_kullaniciAdi)) // sadece bir kez atanabilir
                _kullaniciAdi = value;
        }
    }
}
