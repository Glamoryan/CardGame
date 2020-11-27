using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KartOyunu.Entites;

namespace KartOyunu.UserControls
{
    public partial class basketbolcuKart : UserControl, IKartBase
    {
        public basketbolcuKart()
        {
            InitializeComponent();
        }

        // Parametreli constructor'ımız
        public basketbolcuKart(Basketbolcu basketbolcuKart)
        {
            // kartımızdaki (UserControl) elemanlarımızı(label,button,vs.) set eden method
            InitializeComponent();

            // Basketbolcu olarak bize tanıtılan Sporcu class'ımızdan gelen verileri label'lara yazdırıyoruz
            lblSporBaslik.Text = "Basketbolcu"; // Label'a basketbolcu kartı olduğu için el ile yazabiliriz
            lblSporcuAdi.Text = basketbolcuKart.getSporcuIsim(); // Sporcu adını getter ile çekip label'a yazdırıyoruz
            lblIkilik.Text = basketbolcuKart.getIkilik().ToString(); // Basketçi ikiliğini getter ile çekip label'a yazdırıyoruz
            lblUcluk.Text = basketbolcuKart.getUcluk().ToString(); // Basketçi üçlüğünü getter ile çekip label'a yazdırıyoruz
            lblSerbestAtis.Text = basketbolcuKart.getSerbestAtis().ToString(); // Basketçi serbest atışını getter ile çekip label'a yazdırıyoruz
        }
    }
}
