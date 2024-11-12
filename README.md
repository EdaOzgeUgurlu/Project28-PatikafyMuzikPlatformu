# Project28_PatikafyMüzikPlatformu

## Proje Özeti
Bu proje, C# ile yazılmış basit bir konsol uygulamasıdır. Sanatçıların albüm satışları, çıkış yılları ve müzik türleri gibi bilgilerini içeren bir müzik platformunu simüle eder. Kod, belirli kriterlere göre sanatçıları filtreler, sıralar ve belirli bilgileri ekrana yazdırır. Uygulama ayrıca en yüksek albüm satışına sahip sanatçıyı, en yeni ve en eski sanatçıları listeleyerek gösterir.

## Gereksinimler
- **C# Geliştirme Ortamı**: Visual Studio veya Visual Studio Code gibi bir IDE'ye sahip olunması gerekmektedir.
- **.NET SDK**: Bu uygulama .NET çerçevesini hedeflemektedir, bu yüzden bilgisayarınızda .NET SDK yüklü olmalıdır.

## Dosyalar
- **Program.cs**: Tüm filtreleme ve sanatçı verilerini görüntüleme mantığının bulunduğu ana kod dosyası.
- **Sanatci.cs**: Sanatçıların ad, albüm satışları, çıkış yılı ve tür bilgilerini içeren `Sanatci` sınıf yapısını tanımlar.

## Yapı
Uygulamanın ana mantığı `Program.cs` içinde olup, sanatçıların verileri aşağıdaki işlemlerle yönetilir:
1. Sanatçı verilerinden oluşan bir liste tanımlanır.
2. Filtreleme, sıralama ve görüntüleme işlemleri gerçekleştirilir.

## Kod Fonksiyonları

### Sanatçı Listesi
Program, sanatçıların bilgilerini içeren bir `List<Sanatci>` oluşturarak başlar. Her sanatçı:
- **Ad**: Sanatçının adı,
- **AlbumSatis**: Albüm satış miktarı (milyon cinsinden),
- **CikisYili**: Çıkış yılı,
- **Tur**: Müzik türü özelliklerine sahiptir.

Örnek:
```csharp
List<Sanatci> sanatcilar = new List<Sanatci>
{
    new Sanatci { Ad = "Sezen Aksu", AlbumSatis = 15, CikisYili = 1975, Tur = "Pop" },
    // Diğer sanatçılar...
};
```

### Sanatçı Listesi Üzerinde Yapılan İşlemler

1. **Sanatçı Adına Göre Filtreleme**:
   - Sanatçı adının "S" harfi ile başlayanlarını filtreleyip ekrana yazdırır.

   ```csharp
   var sIleBaslayanlar = sanatcilar.Where(s => s.Ad.StartsWith("S")).ToList();
   Console.WriteLine("Adı 'S' ile başlayan şarkıcılar:");
   sIleBaslayanlar.ForEach(s => Console.WriteLine(s.Ad));
   ```

2. **Albüm Satışına Göre Filtreleme**:
   - Albüm satışları 10 milyonu aşan sanatçıları bulur ve listeleyerek ekrana yazdırır.

   ```csharp
   var onMilyonUstundeSatanlar = sanatcilar.Where(s => s.AlbumSatis > 10).ToList();
   Console.WriteLine("\nAlbüm satışları 10 milyonun üzerinde olan şarkıcılar:");
   onMilyonUstundeSatanlar.ForEach(s => Console.WriteLine(s.Ad));
   ```

3. **2000 Öncesi Çıkış Yapmış Pop Sanatçıları Bulma ve Sıralama**:
   - 2000 yılı öncesi çıkış yapmış ve "Pop" müzik türünde olan sanatçıları bulur, çıkış yılına göre sıralar.

   ```csharp
   var eskiPopcular = sanatcilar
       .Where(s => s.CikisYili < 2000 && s.Tur == "Pop")
       .OrderBy(s => s.CikisYili)
       .ThenBy(s => s.Ad)
       .ToList();
   Console.WriteLine("\n2000 yılı öncesi çıkış yapmış ve pop müzik yapan şarkıcılar:");
   eskiPopcular.ForEach(s => Console.WriteLine($"{s.CikisYili}: {s.Ad}"));
   ```

4. **En Çok Albüm Satan Sanatçıyı Bulma**:
   - Albüm satışlarına göre en çok satan sanatçıyı bulur ve ekrana yazdırır.

   ```csharp
   var enCokSatan = sanatcilar.OrderByDescending(s => s.AlbumSatis).First();
   Console.WriteLine($"\nEn çok albüm satan şarkıcı: {enCokSatan.Ad} - {enCokSatan.AlbumSatis} milyon");
   ```

5. **En Yeni ve En Eski Çıkış Yapan Sanatçıyı Bulma**:
   - Çıkış yılına göre en yeni ve en eski sanatçıları bulur ve bilgilerini ekrana yazdırır.

   ```csharp
   var enYeniCikisYapan = sanatcilar.OrderByDescending(s => s.CikisYili).First();
   var enEskiCikisYapan = sanatcilar.OrderBy(s => s.CikisYili).First();
   Console.WriteLine($"\nEn yeni çıkış yapan şarkıcı: {enYeniCikisYapan.Ad} - {enYeniCikisYapan.CikisYili}");
   Console.WriteLine($"En eski çıkış yapan şarkıcı: {enEskiCikisYapan.Ad} - {enEskiCikisYapan.CikisYili}");
   ```

## Projeyi Çalıştırma
1. Projeyi Visual Studio veya uyumlu bir C# düzenleyicisi ile açın.
2. **Build Solution** seçeneği ile projeyi derleyin.
3. **F5** tuşuna basarak veya **Start Debugging** seçeneğini seçerek projeyi çalıştırın.

Konsol çıktısında:
- "S" harfi ile başlayan sanatçılar,
- Albüm satışları 10 milyonu aşan sanatçılar,
- 2000 yılı öncesi çıkış yapmış pop sanatçılar,
- En çok albüm satan sanatçı,
- En yeni ve en eski çıkış yapan sanatçılar görüntülenecektir.

## Gelecek Geliştirmeler
- **Tür Bazlı Filtreleme**: Diğer müzik türleri veya alt türlere göre filtreleme seçeneği eklenebilir.
- **Kullanıcı Girişi**: Kullanıcının belirli filtre veya sıralama kriterlerini girebilmesi sağlanabilir.
- **Sanatçı Verilerini Genişletme**: Milliyet veya ödüller gibi sanatçılar hakkında daha fazla bilgi eklenebilir.
