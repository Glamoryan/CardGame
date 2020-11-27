using System;

namespace KartOyunu.Entites
{
    // Sporcu Class'ından inheritance almış Basketbolcu class'ı
    public class Basketbolcu : Sporcu
    {
        private int ikilik;
        private int ucluk;
        private int serbestAtis;

        private bool kartKullanilmisMi;

        // Parametresiz constructor
        public Basketbolcu()
        {

        }

        // Parametreli constructor
        public Basketbolcu(string basketbolcuAdi,string basketbolcuTakim,int ikilik,int ucluk,int serbestAtis): base (basketbolcuAdi,basketbolcuTakim) // Java'daki super() methodunun karşılığı base
        {
            setIkilik(ikilik);
            setUcluk(ucluk);
            setSerbestAtis(serbestAtis);
        }

        // Setter'larımız
        public void setIkilik(int ikilik)
        {
            this.ikilik = ikilik;
        }

        public void setUcluk(int ucluk)
        {
            this.ucluk = ucluk;
        }

        public void setSerbestAtis(int serbestAtis)
        {
            this.serbestAtis = serbestAtis;
        }

        public void setKartKullanilmisMi(bool kullanilmisMi)
        {
            this.kartKullanilmisMi = kullanilmisMi;
        }

        // Getter'larımız
        public int getIkilik()
        {
            return ikilik;
        }

        public int getUcluk()
        {
            return ucluk;
        }

        public int getSerbestAtis()
        {
            return serbestAtis;
        }

        public bool getKartKullanilmisMi()
        {
            return kartKullanilmisMi;
        }

        /// <summary>
        /// Sporcu class'ından Override edilmiş method
        /// </summary>
        /// <returns>Basketbolcu puanını döndürür</returns>
        public override int sporcuPuaniGoster()
        {
            throw new NotImplementedException();
        }
    }
}
