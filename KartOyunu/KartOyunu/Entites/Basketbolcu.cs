namespace KartOyunu.Entites
{
    public class Basketbolcu : Sporcu // Sporcu Class'ından inheritance almış Basketbolcu class'ı
    {
        // --- Fields Start ------------------------------------------
        private int ikilik;
        private int ucluk;
        private int serbestAtis;
        private bool kartKullanilmisMi;
        // --- Fields End --------------------------------------------
        
        public Basketbolcu()// Parametresiz constructor
        {
            // Boş instance
        }

        // Parametreli constructor
        public Basketbolcu(string basketbolcuAdi,string basketbolcuTakim,int ikilik,int ucluk,int serbestAtis,bool kullanilmisMi): base (basketbolcuAdi,basketbolcuTakim) // Java'daki super() methodunun karşılığı base
        {
            // Setter'larımızı çağırıp özelliklerimizi set ediyoruz
            setIkilik(ikilik);
            setUcluk(ucluk);
            setSerbestAtis(serbestAtis);
            setKartKullanilmisMi(kullanilmisMi);
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
        
        public override int sporcuPuaniGoster(string ozellik) // Basketbolcu için sporcu puanlarını döndüren method
        {
            if (ozellik == "ikilik") // Eğer özellik ikilik ise bu block çalışır
                return getIkilik(); // Getter ile ikilik ozelliğini geri döndürürüz
            else if (ozellik == "üçlük") // Eğer özellik üçlük ise bu block çalışır
                return getUcluk();// Getter ile üçlük ozelliğini geri döndürürüz
            else // Eğer özellik serbest atış ise bu block çalışır
                return getSerbestAtis(); // Getter ile serbest atış ozelliğini geri döndürürüz
        }
    }
}
