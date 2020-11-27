using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartOyunu.Entites
{
    // Oyuncu class'ında inheritance alan Kullanici class'ı
    public class Kullanici : Oyuncu
    {
        // Parametresiz constructor
        public Kullanici()
        {

        }

        // Parametreli constructor
        public Kullanici(int oyuncuId,string oyuncuAdi,int skor) : base (oyuncuId,oyuncuAdi,skor)
        {

        }

        /// <summary>
        /// Kullanıcının kart seçme methodu
        /// </summary>
        /// <param name="sporcuSirasi">Oynaması sırası hangi sporcudaysa o verilir</param>
        /// <returns>Seçilen kart(Sporcu) döndürür</returns>
        public override Sporcu kartSec(Sporcu sporcu) // istediği kart sec
        {
            return sporcu;
        }

        public override int SkorGoster()
        {
            // Oyuncu class'ımızdaki getSkor() methodu
            return getSkor();
        }
    }
}
