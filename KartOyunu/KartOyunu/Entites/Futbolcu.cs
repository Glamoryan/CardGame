using System;

namespace KartOyunu.Entites
{
    public class Futbolcu : Sporcu // Sporcu Class'ından inheritance almış Futbolcu class'ı
    {
        // --- Fields Start ----------------------------------
        private int penalti;
        private int serbestVurus;
        private int kaleciKarsiKarsiya;
        private bool kartKullanilmisMi;
        // --- Fields End ----------------------------------
        
        public Futbolcu()// Parametresiz constructor
        {
            // Boş instance
        }

        // Parametreli constructor
        public Futbolcu(string futbolcuAdi,string futbolcuTakim,int penalti,int serbestVurus,int karsiKarsiya,bool kullanilmisMi) : base (futbolcuAdi,futbolcuTakim) // Java'daki super() methodunun karşılığı base
        {
            // Setter'larımız ile özelliklerimizi set ettik
            setPenalti(penalti);
            setSerbestVurus(serbestVurus);
            setKaleciKarsiKarsiya(karsiKarsiya);
            setKartKullanilmisMi(kullanilmisMi);
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
       
        public override int sporcuPuaniGoster(string ozellikIsmi) // Futbolcu için sporcu özelliklerini döndüren method
        {
            if (ozellikIsmi == "penaltı") // Eğer özellik penaltı ise bu block çalışır
                return getPenalti(); // Getter ile özelliği döneriz
            else if (ozellikIsmi == "serbest vuruş") // Eğer özellik serbest vuruş ise bu block çalışır
                return getSerbestVurus(); // Getter ile özelliği döneriz
            else// Eğer özellik kalecikarsikarsiya ise bu block çalışır
                return getKaleciKarsiKarsiya(); // Getter ile özelliği döneriz
        }

    }
}
