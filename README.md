# PHOTO_BOOM
PhotoBoom - Fotoğraf galerisi özelliğinde bir web sitesi projesidir. (ASP.NET Core MVC - MS-SQL Server)

Projenin Çalıştırılması İçin Gerekenler,

1-) Öncelikle DB dizini altında bulunan "PHOTO_BOOM.sql" ya da "PHOTO_BOOM.bak" dosyalarından birisini kullanarak gerekli veritabanı "PHOTO_BOOM" adıyla lokalinizde çalışan sunucunuzda MS-SQL Server Yönetim Sistemi ile oluşturulur.

2-) Veritabanı oluşturma işlemi başarılı bir şekilde tamamlandıktan sonra "PhotoBoom" dizininde bulunan web projesi hiçbir değişiklik yapmadan çalıştırılır.

3-) "PhotoBoom" web projesi çalıştırılarak web sitesi ana sayfasına erişilir. Buradan "My photos" linkine tıklayarak fotoğrafların bulunduğu sayfaya erişilir.

4-) Fotoğraf galerisinde mevcutta 2 adet fotoğraf bulunmaktadır. Yeni bir fotoğraf eklemek için "Add photo" linkine tıklanır. 

5-) Fotoğraf ekleme sayfasında gerekli alanlar(Title, Tags ve fotoğraf dosyası) doldurularak "Add photo" linkine tıklanır. Bu işlemden sonra sisteme eklediğiniz fotoğraf bilgileri veritabanına kaydolur ve "My photos" ekranında görüntülenir.

6-) Sistemde kayıtlı fotoğraf ayrıntılarını görüntülemek için istenilen bir fotoğrafın üzerine tıklanır. Açılan ekrandan Title, Tags bilgileri ve fotoğrafın büyütülmüş hali görüntülenir.

7-) Fotoğraf detayı ekranından "Delete photo" linkine tıklayarak ekrandaki fotoğrafı sistemden silme işlemi yapılır ve fotoğrafların tamamının listelendiği ekrana yönlendirilir.

8-) Eğer sistemde hiç fotoğraf kalmadı ise "You don’t have any photos yet ;(" mesajı görüntülenir.