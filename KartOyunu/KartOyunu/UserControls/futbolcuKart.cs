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
using KartOyunu.UserControls.Utilities;

namespace KartOyunu.UserControls
{
    public partial class futbolcuKart : UserControl , IKartBase
    {        
        public futbolcuKart()
        {
            InitializeComponent();
        }

        // Parametreli constructor'ımız
        public futbolcuKart(Futbolcu futbolcuKart)
        {
            // kartımızdaki (UserControl) elemanlarımızı(label,button,vs.) set eden method
            InitializeComponent();            

            // Futbolcu olarak bize tanıtılan Sporcu class'ımızdan gelen verileri label'lara yazdırıyoruz
            lblSporBaslik.Text = "Futbolcu"; // Label'a futbolcu kartı olduğu için el ile yazabiliriz
            lblSporcuAdi.Text = futbolcuKart.getSporcuIsim(); // Sporcu adını getter ile çekip label'a yazdırıyoruz
            lblPenalti.Text = futbolcuKart.getPenalti().ToString(); // Futbolcu penaltısını getter ile çekip label'a yazdırıyoruz
            lblSerbestVurus.Text = futbolcuKart.getSerbestVurus().ToString(); // Futbolcu serbest vuruşunu getter ile çekip label'a yazdırıyoruz
            lblKarsiKarsiya.Text = futbolcuKart.getKaleciKarsiKarsiya().ToString(); // Futbolcu kaleciyle karşı karşıya özelliğini getter ile çekip label'a yazdırıyoruz
        }        
    }
}
