using KartOyunu.Entites;
using System.Windows.Forms;

namespace KartOyunu.UserControls
{
    public partial class basketbolcuKart : UserControl, IKartBase // Bu userControlün kart olduğunu anlayabilmemiz için IKartBase imzası
    {
        // --- Constructors Start -------------------
        public basketbolcuKart()
        {
            InitializeComponent();
        }
        
        public basketbolcuKart(Basketbolcu basketbolcuKart)// Parametreli constructor'ımız
        {            
            InitializeComponent(); // Kartımızdaki (UserControl) elemanlarımızı(label,button,vs.) set eden Visual Studio methodu

            // Basketbolcu olarak bize tanıtılan Sporcu class'ımızdan gelen verileri label'lara yazdırıyoruz
            lblSporBaslik.Text = "Basketbolcu"; // Label'a basketbolcu kartı olduğu için el ile yazabiliriz
            lblSporcuAdi.Text = basketbolcuKart.getSporcuIsim(); // Sporcu adını getter ile çekip label'a yazdırıyoruz
            lblIkilik.Text = basketbolcuKart.getIkilik().ToString(); // Basketçi ikiliğini getter ile çekip label'a yazdırıyoruz
            lblUcluk.Text = basketbolcuKart.getUcluk().ToString(); // Basketçi üçlüğünü getter ile çekip label'a yazdırıyoruz
            lblSerbestAtis.Text = basketbolcuKart.getSerbestAtis().ToString(); // Basketçi serbest atışını getter ile çekip label'a yazdırıyoruz
        }
        // --- Constructors End -------------------
    }
}
