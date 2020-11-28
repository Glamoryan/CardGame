using System;
using System.Collections.Generic;

namespace KartOyunu.Entites
{
    public class Test // Oyunun yönetildiği test class'ı
    {
        // Oyuncularmızın property'leri
        public Oyuncu _kullanici { get; set; }
        public Oyuncu _bilgisayar { get; set; }

        // Parametresiz constructor, (Oyuncu bilgileri verilmeden)
        public Test()
        {
            // Test class'ımızın instance'ı alındığında oyunuBaslat() methodu çalışıp oyunu başlatacak
            oyunuBaslat();
        }

        // Parametreli constructor, (Oyuncu bilgileri verilerek)
        public Test(Oyuncu kullanici,Oyuncu bilgisayar)
        {
            // Parametreyle verilen propertiylerimizi set ediyoruz
            _kullanici = kullanici;
            _bilgisayar = bilgisayar;

            // oyunuBaslat methoduyla oyunu başlatıyoruz
            oyunuBaslat();
        }

        // --- Set Edici Methodlar Start ----------------------------------------------------------------------------------
        public void oyunuBaslat() // Oyuncuları set edip, oyunu başlatan method
        {
            if (_kullanici == null || _bilgisayar == null) // Eğer oyuncu propertylerimiz set edilmediyse bu block çalışır
            {
                // Oyuncu propertylerimizi set ediyoruz
                _kullanici = new Kullanici(1, "Kullanıcı", 0); // oyuncuId, oyuncuAdı ve skor
                _bilgisayar = new Bilgisayar(2, "Bilgisayar", 0); // oyuncuId, oyuncuAdı ve skor
            }

            // kartDagitici() 'dan gelen array'i oyuncuların kartListesine atıyoruz (kartDagitici()'dan dönen 0.index kullanıcıDestesi , 1.index bilgisayar destesi)
            List<Sporcu>[] deste16 = kartDagitici();
            _kullanici.kartListesi = deste16[0];
            _bilgisayar.kartListesi = deste16[1];
        }

        public Oyuncu oyunuBitir() // Oyunu bitirmemizi sağlayan method
        {            
            // Kullanıcı ve bilgisayarın skorlarını getter ile alıp değişkene atarız
            int kullaniciSkor = _kullanici.getSkor();
            int bilgisayarSkor = _bilgisayar.getSkor();

            if (kullaniciSkor > bilgisayarSkor) // Eğer kullanıcının skoru bilgisayarınkinden fazlaysa bu block çalışır
                return _kullanici; // Kazanan olarak kullanıcıyı döneriz
            else if (kullaniciSkor < bilgisayarSkor) // Eğer kullanıcının skoru bilgisayarınkinden azsa bu block çalışır
                return _bilgisayar; // Kazanan olarak bilgisayarı döneriz
            else // Eğer skorlar eşitse bu block çalışır
                return null; // Geriye boş değer döndürürüz
        }

        public List<Sporcu> sporcuOlustur() // Sporcuları oluşturan method
        {
            List<Sporcu> sporcular = new List<Sporcu>();
            // Futbolcu isimleri ve takımları constructor ile tanımlandı
            sporcular.Add(new Futbolcu("Cristiano Ronaldo", "Juventus", 95, 80, 90,false));
            sporcular.Add(new Futbolcu("Lionel Messi", "Barcelona", 100, 75, 90, false));
            sporcular.Add(new Futbolcu("Neymar", "Paris Saint-Germain", 85, 80, 95, false));
            sporcular.Add(new Futbolcu("Robert Lewandowski", "Bayern Munih", 80, 70, 75, false));
            sporcular.Add(new Futbolcu("Zlatan Ibrahimovic", "Milan", 70, 75, 80, false));
            sporcular.Add(new Futbolcu("Sergio Ramos", "Real Madrid", 85, 75, 70, false));
            sporcular.Add(new Futbolcu("Luka Modric", "Real Madrid", 85, 85, 80, false));
            sporcular.Add(new Futbolcu("Gareth Bale", "Tottenham", 90, 85, 90, false));

            // Basketbolcu isimleri ve takımları constructor ile tanımlandı - Özellikleri ise settar'ları ile tanımlandı
            sporcular.Add(new Basketbolcu("Lebron James", "Lakers", 85, 80, 95, false));
            sporcular.Add(new Basketbolcu("Stephen Curry", "Goldent State", 85, 95, 90, false));
            sporcular.Add(new Basketbolcu("James Harden", "Houston Rockets", 85, 75, 85, false));
            sporcular.Add(new Basketbolcu("Kawhi Leonard", "Lakers", 85, 85, 85, false));
            sporcular.Add(new Basketbolcu("Yannis Adetokunbo", "Milwaukee", 80, 85, 85, false));
            sporcular.Add(new Basketbolcu("Chris Paul", "Oklahoma", 75, 70, 80, false));
            sporcular.Add(new Basketbolcu("Anthony Davis", "Lakers", 85, 85, 90, false));
            sporcular.Add(new Basketbolcu("Kyrie Irving", "Brooklyn", 90, 85, 89, false));

            // Oluşturulan sporcu listesini geri döndürür
            return sporcular;
        }

        public List<Sporcu>[] kartDagitici()// Oyun başladığında iki tarafada kartları dağıtan method
        {
            List<Sporcu> deste = sporcuOlustur(); // sporcuOlustur() ile 16 kartlık destemizi oluşturuyoruz.

            var random = new Random(); //Rastgele dağıtım için Random class'ının instance'ını alıyoruz

            List<Sporcu> kullaniciDestesi = new List<Sporcu>(); // Kullanıcı destesinin instance'ını alıyoruz.
            List<Sporcu> bilgisayarDestesi = new List<Sporcu>();// Bilgisayar destesinin instance'ını alıyoruz.

            int basketbolcuAdedi = 0, futbolcuAdedi = 0; // Kaç adet eklediğimizi takip etmek için basketbolcu ve futbolcu adedi tanımlıyoruz.

            while (true) // While döngüsüne true vererek sonsuz döngü başlatıyoruz
            {
                int index = random.Next(deste.Count); // Rastgele seçim için 0 ile destenin uzunluğu arasında bir index seçiyoruz
                Sporcu secilenKart = deste[index]; // Index ile desteden bir kart seçiyoruz (Basketbolcu veya futbolcu)               

                // Eğer basketbolcuAdedi 4'ten küçükse ve seçtiğimiz kart basketbolcuysa ve seçilen kart daha önce kullanıcıDestesine eklenmemişse bu block çalışır
                if (secilenKart is Basketbolcu && basketbolcuAdedi < 4)
                {
                    kullaniciDestesi.Add(secilenKart); // Kullanıcı destesine basketbolcu kartını ekliyoruz
                    basketbolcuAdedi += 1; // Basketbolcu adedini 1 arttırıyoruz
                    deste.Remove(secilenKart); // Seçilen kart tekrar seçilmemesi için desteden siliyoruz
                }
                // Eğer seçilen kart futbolcuysa ve futbolcu adedi 4'ten küçükse ve seçilen kart daha önce kullanıcı destesine eklenmemişse bu block çalışır
                else if (secilenKart is Futbolcu && futbolcuAdedi < 4)
                {
                    kullaniciDestesi.Add(secilenKart); // Kullanıcı destesine futbolcu kartını ekliyoruz
                    futbolcuAdedi += 1; // Futbolcu adedini 1 arttırıyoruz
                    deste.Remove(secilenKart); // Seçilen kart tekrar seçilmemesi için desteden siliyoruz
                }
                else // Eğer seçilen kart yukarıdakilerden hiçbirine giremezse kullanıcı destesi tamamlanmıştır. Bu yüzden bu block çalışır
                {
                    bilgisayarDestesi.Add(secilenKart); // Seçilen kartı bilgisayar destesine ekliyoruz
                    deste.Remove(secilenKart); // Seçilen kart tekrar seçilmemesi için desteden siliyoruz
                }

                if ((basketbolcuAdedi == 4 && futbolcuAdedi == 4) && bilgisayarDestesi.Count == 8) // Eğer basketbolcu ve futbolcu adetleri 4'e ulaşmışsa ve bilgisayar desteside tamamlanmışsa bu block çalışır
                    break;// Sonsuz while döngümüzü kırıyoruz
            }

            // Oluşturduğumuz 2 desteyide Array olarak geri döndürüyoruz.
            return new List<Sporcu>[] { kullaniciDestesi, bilgisayarDestesi };
        }

        // Secici methodları start -------->
        public string turSecici(string verilenTur)// Verilen tura göre sıradaki turu döndüren method
        {
            // Eğer bize verilen tur futbolcuysa diğer turu döndürüyoruz (Basketbolcu turu verilirse Futbolcu, Futbolcu turu verilirse Basketbolcu turu döner)
            return verilenTur == "Futbolcu" ? "Basketbolcu" : "Futbolcu";
        }

        public string poziyonSecici(string turSirasi) // Verilen sporcuya göre rastgele pozisyon seçen method
        {
            // Sporcu pozisyonları listelere atandı
            List<string> basketbolcuPozisyonlari = new List<string>
            {
                "İkilik","Üçlük","Serbest Atış"
            };
            List<string> futbolcuPozisyonlari = new List<string>
            {
                "Penaltı","Serbest Vuruş","Kaleciyle Karşı Karşıya"
            };

            // Rastgele seçim için Random class'ının instance'ını tanımlıyoruz
            var random = new Random();

            if (turSirasi == "Basketbolcu")// Eğer hamle sırası basketbolcudaysa bu block çalışacak
            {
                int index = random.Next(basketbolcuPozisyonlari.Count); // Random.Next methodu ile listeden 0 ile listenin uzunluğu arasında(Count) rastgele bir index seçildi
                return basketbolcuPozisyonlari[index]; // Seçilen index'i geri döndürdük
            }
            else // Eğer hamle sırası futbolcudaysa bu block çalışacak
            {
                int index = random.Next(futbolcuPozisyonlari.Count);// Random.Next methodu ile listeden 0 ile listenin uzunluğu arasında(Count) rastgele bir index seçildi
                return futbolcuPozisyonlari[index];// Seçilen index'i geri döndürdük
            }
        }
        
        public void turuKazanan(Oyuncu kazanan) // Turu kazanan oyuncunun skorunu set eden method
        {
            // Eğer kazanan kullanıcıysa, kullanıcının skorunu setter ile set ediyoruz
            if (kazanan is Kullanici)
                _kullanici.setSkor(10);
            else // Eğer kazanan bilgisayarsa, bilgisayarın skorunu setter ile set ediyoruz
                _bilgisayar.setSkor(10);
        }
        // Secici methodları end ----------->
        // --- Set Edici Methodlar End ---------------------------------------------------------------------------------- 
    }
}
