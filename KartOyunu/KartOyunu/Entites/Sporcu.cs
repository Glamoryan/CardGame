using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartOyunu.Entites
{
    // Sporcu Class'ı
    public abstract class Sporcu
    {
        private string _sporcuIsim;
        private string _sporcuTakim;
        

        // Parametresiz constructor
        public Sporcu()
        {

        }

        // Parametreli constructor
        public Sporcu(string sporcuIsim,string sporcutakim)
        {
            // Inheritance uygulanmış class'dan gelen özellikleri setter'lar ile atadık
            setSporcuIsim(sporcuIsim);
            setSporcuTakim(sporcutakim);
        }

        // Setter'larımız
        public void setSporcuIsim(string isim)
        {
            _sporcuIsim = isim;
        }

        public void setSporcuTakim(string takimIsmi)
        {
            _sporcuTakim = takimIsmi;
        }

        // Getter'larımız
        public string getSporcuIsim()
        {
            return _sporcuIsim;
        }

        public string getSporcuTakim()
        {
            return _sporcuTakim;
        }

        // Sporcu puanlarını dönen methodumuz
        public abstract int sporcuPuaniGoster();
    }
}
