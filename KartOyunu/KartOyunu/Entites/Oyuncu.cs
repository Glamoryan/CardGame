using System.Collections.Generic;

namespace KartOyunu.Entites
{
    public abstract class Oyuncu // Oyuncu Abstract Class'ı
    {
        // --- Fields Start -----------------------
        private int _oyuncuID;
        private string _oyuncuAdi;
        private int _skor;

        public List<Sporcu> kartListesi { get; set; } // Kart listesini tutan property

        // --- Fields Start -----------------------        
        
        public Oyuncu() // Parametresiz constructor
        {

        }

        // Parametreli constructor
        public Oyuncu(int oyuncuId,string oyuncuAdi,int skor)
        {
            setOyuncuId(oyuncuId);
            setOyuncuAdi(oyuncuAdi);
            setSkor(skor);
        }

        // Setter'larımız
        public void setOyuncuId(int oyuncuId)
        {
            _oyuncuID = oyuncuId;
        }

        public void setOyuncuAdi(string oyuncuAdi)
        {
            _oyuncuAdi = oyuncuAdi;
        }

        public void setSkor(int skor)
        {
            _skor += skor;
        }

        // Getter'larımız
        public int getId()
        {
            return _oyuncuID;
        }

        public string getOyuncuAdi()
        {
            return _oyuncuAdi;
        }

        public int getSkor()
        {
            return _skor;
        }

        // Override edilecek abstract metodlarımız
        public abstract int SkorGoster();
        public abstract Sporcu kartSec(Sporcu sporcu);

    }
}
