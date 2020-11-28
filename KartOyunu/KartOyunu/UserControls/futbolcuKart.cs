using KartOyunu.Entites;
using System.Windows.Forms;

namespace KartOyunu.UserControls
{
    public partial class futbolcuKart : UserControl , IKartBase // Bu userControlün kart olduğunu anlayabilmemiz için IKartBase imzası
    {        
        // --- Constructors Start -------------------
        public futbolcuKart()
        {
            InitializeComponent();
        }
        
        public futbolcuKart(Futbolcu futbolcuKart)// Parametreli constructor'ımız
        {            
            InitializeComponent();// Kartımızdaki (UserControl) elemanlarımızı(label,button,vs.) set eden Visual Studio methodu

            // Futbolcu olarak bize tanıtılan Sporcu class'ımızdan gelen verileri label'lara yazdırıyoruz
            lblSporBaslik.Text = "Futbolcu"; // Label'a futbolcu kartı olduğu için el ile yazabiliriz
            lblSporcuAdi.Text = futbolcuKart.getSporcuIsim(); // Sporcu adını getter ile çekip label'a yazdırıyoruz
            lblPenalti.Text = futbolcuKart.getPenalti().ToString(); // Futbolcu penaltısını getter ile çekip label'a yazdırıyoruz
            lblSerbestVurus.Text = futbolcuKart.getSerbestVurus().ToString(); // Futbolcu serbest vuruşunu getter ile çekip label'a yazdırıyoruz
            lblKarsiKarsiya.Text = futbolcuKart.getKaleciKarsiKarsiya().ToString(); // Futbolcu kaleciyle karşı karşıya özelliğini getter ile çekip label'a yazdırıyoruz
        }
        // --- Constructors End -------------------        
    }
}
