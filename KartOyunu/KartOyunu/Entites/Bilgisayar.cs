using System;

namespace KartOyunu.Entites
{
    // Oyuncu class'ından inheritance alan Bilgisayar class'ı
    public class Bilgisayar : Oyuncu
    {
        // Parametresiz contructor
        public Bilgisayar()
        {

        }

        // Parametreli constructor
        public Bilgisayar(int oyuncuId,string oyuncuAdi,int skor) : base (oyuncuId,oyuncuAdi,skor) // Java'daki super() methodunun karşılığı base
        {

        }

        /// <summary>
        /// Bilgisayar için random kart seçip oynama methodu
        /// </summary>
        /// <param name="sporcu">Hamle sırası Basketbolcu damı yoksa Futbolcuda mı</param>
        /// <returns></returns>
        public override Sporcu kartSec(Sporcu sporcuSirasi)
        {            
            var random = new Random();// Rastgele seçim için random class'ından instance oluşturduk
            int index = random.Next(kartListesi.Count); // 0 ile kartListesi uzunluğu arasında bir index seçtik

            if (sporcuSirasi is Basketbolcu) // Eğer sporcu sırası basketbolcudaysa bu block çalışacak
            {                                                               
                Sporcu secilenKart = kartListesi[index]; // Oluşturduğumuz rastgele indexten bir kart seçiyoruz (Basketbolcu yada Futbolcu)
                if (secilenKart is Basketbolcu) // Eğer seçtiğimiz kart basketbolcuysa bu block çalışır
                {                    
                    return secilenKart; // Seçtiğimiz kartı geri döndürürüz
                }                
                else // Eğer seçilen kart basketbolcu değilse bu block çalışır (Çünkü sporcu sırası basketbolcularda)
                {
                    foreach (Sporcu kart in kartListesi) // Kart listesini foreach ile geziyoruz
                    {
                        if (kart is Basketbolcu) // Eğer gezdiğimiz kart basketbolcuysa bu block çalışır
                        {
                            secilenKart = kart; // Bulduğumuz kartı seçiyoruz
                            break; // Doğru kartı bulduğumuz için foreach döngüsünü burada kırıyoruz 
                        }                        
                        else // Eğer seçilen kart yine basketbolcu değilse bu block çalışır
                            continue; // Bu döngüsünü atlayıp, sıradaki döngüye geçiyoruz
                    }
                    return secilenKart; // Döngü kırıldıktan sonra seçtiğimiz kartı geri döndürüyoruz
                }                
            }
            else // Eğer sporcu sırası Futbolcudaysa bu block çalışır
            {
                Sporcu secilenKart = kartListesi[index]; // Seçilen index ile kart seçiyoruz (Basketbolcu veya Futbolcu)
                if (secilenKart is Futbolcu)// Eğer seçilen kart futbolcuysa bu block çalışır
                    return secilenKart; // Seçilen kartı geri döndürüyoruz
                else //Eğer seçilen kart basketbolcuysa bu block çalışır
                {
                    foreach (Sporcu kart in kartListesi) // Kartlistesini foreach ile geziyoruz
                    {
                        if (kart is Futbolcu) // Eğer gezdiğimiz kart futbolcuysa bu block çalışır
                        {
                            secilenKart = kart; // Gezdiğimiz kartı seçip değişkene atıyoruz
                            break; // Bu foreach döngüsünü kırıyoruz
                        }                        
                        else // Eğer seçilen kart tekrar basketbolcuysa bu block çalışır
                            continue; // Bu döngüyü atlayıp, diğerine geçiyoruz 
                    }
                    return secilenKart; // Seçilen kartı geri döndürüyoruz
                }
            }
        }

        public override int SkorGoster()
        {
            // Oyuncu class'ımızdaki getSkor() methodu
            return getSkor();
        }
    }
}
