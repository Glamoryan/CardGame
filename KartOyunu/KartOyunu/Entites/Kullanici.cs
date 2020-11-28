namespace KartOyunu.Entites
{    
    public class Kullanici : Oyuncu // Oyuncu class'ında inheritance alan Kullanici class'ı
    {
        // Parametresiz constructor
        public Kullanici()
        {

        }

        // Parametreli constructor
        public Kullanici(int oyuncuId,string oyuncuAdi,int skor) : base (oyuncuId,oyuncuAdi,skor)
        {

        }
        
        public override Sporcu kartSec(Sporcu sporcu) // Kullanıcının seçtiği kartı geri döndüren method
        {
            return sporcu; // Verilen sporcuyu geri döndürüyoruz
        }

        public override int SkorGoster() // Kullanıcının skorunu geri döndüren method
        {            
            return getSkor(); // Oyuncu class'ımızdaki getSkor() methodunu çağırıp geri döndürüyoruz
        }
    }
}
