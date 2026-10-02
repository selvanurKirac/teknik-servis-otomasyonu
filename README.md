Teknik servis süreçlerini düzenli ve izlenebilir hale getirmek için geliştirilmiş bir C# Windows Forms masaüstü uygulamasıdır. Yapılan işler, cihaz tamirleri, ürün/toner stokları, garanti ve firma bilgileri tek bir arayüzden yönetilir.

### Özellikler

* Kullanıcı girişi ve veritabanı bağlantı ayarları
* Yapılan işlerin kaydı, güncellenmesi ve görüntülenmesi
* Tamire giden cihazların servis firması, alım ve teslim tarihleriyle takibi
* Stoktan veya dış kaynaktan ürün ekleme (stok otomatik güncellenir)
* Toner, garanti ve firma yönetimi
* Arama/filtreleme destekli güncelleme ekranları
* Tüm ekleme, güncelleme ve silme işlemlerinin loglanması
* Anlık saat ve Dolar/Euro kuru gösterimi

### Kullanılan Teknolojiler

* C# / Windows Forms (.NET)
* Microsoft SQL Server
* HttpClient (döviz kurları için)

### Kurulum

1. Projeyi Visual Studio ile açın ve NuGet paketlerini geri yükleyin.
2. SQL Server Management Studio'da `database.sql` dosyasını açıp çalıştırın. Veritabanı ve tablolar otomatik oluşturulur.
3. Veritabanda `Kullanicilar` tablosuna manuel yeni bir kullanıcı girin.
4. Uygulamayı çalıştırıp **Veri Tabanı Ayarlarına Gir** ekranından sunucu ve veritabanı bilgilerini girin, ardından öncesinde manuel oluşturduğunuz kullanıcıyla giriş yapın.
