using Project28_PatikafyMüzikPlatformu;

public class Program
{
    public static void Main()
    {
        // Sanatçı listesini oluşturuyoruz. 
        // Bu liste, her sanatçının adı, albüm satışları, çıkış yılı ve müzik türü bilgilerini içerecek.
        List<Sanatci> sanatcilar = new List<Sanatci>
        {
            new Sanatci { Ad = "Sezen Aksu", AlbumSatis = 15, CikisYili = 1975, Tur = "Pop" },
            new Sanatci { Ad = "Sertab Erener", AlbumSatis = 12, CikisYili = 1992, Tur = "Pop" },
            new Sanatci { Ad = "Tarkan", AlbumSatis = 20, CikisYili = 1992, Tur = "Pop" },
            new Sanatci { Ad = "Ajda Pekkan", AlbumSatis = 8, CikisYili = 1963, Tur = "Pop" },
            new Sanatci { Ad = "Barış Manço", AlbumSatis = 5, CikisYili = 1969, Tur = "Rock" },
            new Sanatci { Ad = "MFÖ", AlbumSatis = 9, CikisYili = 1980, Tur = "Pop" },
            new Sanatci { Ad = "Nilüfer", AlbumSatis = 7, CikisYili = 1972, Tur = "Pop" },
            new Sanatci { Ad = "Kenan Doğulu", AlbumSatis = 6, CikisYili = 1993, Tur = "Pop" },
            new Sanatci { Ad = "Teoman", AlbumSatis = 10, CikisYili = 1996, Tur = "Rock" },
            new Sanatci { Ad = "Zeki Müren", AlbumSatis = 10, CikisYili = 1951, Tur = "Klasik Türk Müziği" },
            new Sanatci { Ad = "Ebru Gündeş", AlbumSatis = 11, CikisYili = 1993, Tur = "Pop" },
        };

        // Adı 'S' ile başlayan şarkıcıları filtreliyoruz. 
        // 'Where' metodu, her sanatçının adının 'S' harfiyle başlayıp başlamadığını kontrol eder.
        var sIleBaslayanlar = sanatcilar.Where(s => s.Ad.StartsWith("S")).ToList();
        // Bu şarkıcıları ekrana yazdırıyoruz.
        Console.WriteLine("Adı 'S' ile başlayan şarkıcılar:");
        sIleBaslayanlar.ForEach(s => Console.WriteLine(s.Ad));

        Console.WriteLine("-----------------------------------------------------");

        // Albüm satışları 10 milyonun üzerinde olan şarkıcıları filtreliyoruz.
        // 'Where' metodu, her sanatçının albüm satışlarının 10 milyonu geçtiğini kontrol eder.
        var onMilyonUstundeSatanlar = sanatcilar.Where(s => s.AlbumSatis > 10).ToList();
        // Bu şarkıcıları ekrana yazdırıyoruz.
        Console.WriteLine("\nAlbüm satışları 10 milyonun üzerinde olan şarkıcılar:");
        onMilyonUstundeSatanlar.ForEach(s => Console.WriteLine(s.Ad));

        Console.WriteLine("-----------------------------------------------------");

        // 2000 yılı öncesi çıkış yapmış ve pop müzik yapan şarkıcıları filtreliyoruz.
        // 'Where' metodu, şarkıcının çıkış yılının 2000'den önce ve türünün "Pop" olup olmadığını kontrol eder.
        var eskiPopcular = sanatcilar
            .Where(s => s.CikisYili < 2000 && s.Tur == "Pop")
            .OrderBy(s => s.CikisYili)   // Çıkış yılına göre sıralama
            .ThenBy(s => s.Ad)           // Aynı çıkış yılına sahip sanatçılar alfabetik olarak sıralanır
            .ToList();
        // Bu şarkıcıları ekrana yazdırıyoruz. Çıkış yılı ile birlikte.
        Console.WriteLine("\n2000 yılı öncesi çıkış yapmış ve pop müzik yapan şarkıcılar:");
        eskiPopcular.ForEach(s => Console.WriteLine($"{s.CikisYili}: {s.Ad}"));

        Console.WriteLine("-----------------------------------------------------");

        // En çok albüm satan şarkıcıyı buluyoruz. 
        // 'OrderByDescending' metodu ile albüm satışlarına göre azalan sırada sıralıyoruz.
        // 'First' metodu ile en üstteki yani en çok albüm satan sanatçıyı alıyoruz.
        var enCokSatan = sanatcilar.OrderByDescending(s => s.AlbumSatis).First();
        // En çok albüm satan şarkıcının adı ve satış bilgilerini ekrana yazdırıyoruz.
        Console.WriteLine($"\nEn çok albüm satan şarkıcı: {enCokSatan.Ad} - {enCokSatan.AlbumSatis} milyon");

        Console.WriteLine("-----------------------------------------------------");

        // En yeni çıkış yapan şarkıcıyı buluyoruz. 
        // 'OrderByDescending' ile çıkış yılına göre azalan sırada sıralayıp en son çıkış yapmış şarkıcıyı alıyoruz.
        var enYeniCikisYapan = sanatcilar.OrderByDescending(s => s.CikisYili).First();
        // En eski çıkış yapan şarkıcıyı buluyoruz.
        // 'OrderBy' ile çıkış yılına göre artan sırada sıralayıp en eski çıkış yapan şarkıcıyı alıyoruz.
        var enEskiCikisYapan = sanatcilar.OrderBy(s => s.CikisYili).First();
        // En yeni ve en eski çıkış yapan şarkıcıları ekrana yazdırıyoruz.
        Console.WriteLine($"\nEn yeni çıkış yapan şarkıcı: {enYeniCikisYapan.Ad} - {enYeniCikisYapan.CikisYili}");
        Console.WriteLine($"En eski çıkış yapan şarkıcı: {enEskiCikisYapan.Ad} - {enEskiCikisYapan.CikisYili}");
    }
}