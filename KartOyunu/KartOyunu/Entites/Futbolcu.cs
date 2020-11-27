using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartOyunu.Entites
{
    // Sporcu Class'ından inheritance almış Futbolcu class'ı
    public class Futbolcu : Sporcu
    {
        private int penalti;
        private int serbestVurus;
        private int kaleciKarsiKarsiya;

        private bool kartKullanilmisMi;

        // Parametresiz constructor
        public Futbolcu()
        {

        }

        // Parametreli constructor
        public Futbolcu(string futbolcuAdi,string futbolcuTakim,int penalti,int serbestVurus,int karsiKarsiya) : base (futbolcuAdi,futbolcuTakim) // Java'daki super() methodunun karşılığı base
        {
            // Setter'larımız ile özelliklerimizi set ettik
            setPenalti(penalti);
            setSerbestVurus(serbestVurus);
            setKaleciKarsiKarsiya(karsiKarsiya);
        }

        // Setter'larımız
        public void setPenalti(int penalti)
        {
            this.penalti = penalti;
        }

        public void setSerbestVurus(int serbestVurus)
        {
            this.serbestVurus = serbestVurus;
        }

        public void setKaleciKarsiKarsiya(int karsiKarsiya)
        {
            this.kaleciKarsiKarsiya = karsiKarsiya;
        }

        public void setKartKullanilmisMi(bool kullanilmisMi)
        {
            this.kartKullanilmisMi = kullanilmisMi;
        }

        // Getter'larımız
        public int getPenalti()
        {
            return penalti;
        }

        public int getSerbestVurus()
        {
            return serbestVurus;
        }

        public int getKaleciKarsiKarsiya()
        {
            return kaleciKarsiKarsiya;
        }

        public bool getKartKullanilmisMi()
        {
            return kartKullanilmisMi;
        }

        /// <summary>
        /// Sporcu class'ından Override edilmiş method
        /// </summary>
        /// <returns>Futbolcu puanını döndürür</returns>
        public override int sporcuPuaniGoster()
        {
            throw new NotImplementedException();
        }

    }
}
