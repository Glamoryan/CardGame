using System.Drawing;
using System.Windows.Forms;

namespace KartOyunu.UserControls.Utilities
{    
    public static class PanelHelper // Panellerimizi kontrol etmemize yardımcı olan static class
    {
        public static Panel mainPanel { get; set; } // Ana panelimizi tutan static değişken

        private static string isaret = "?"; // Bilgisayarın oynadığı kartı gizlemek için koyacağımız işaret
       
        public static void panelTemizle(Panel panel) // Verilen panelin içeriğini temizleyen method
        {
            panel.Controls.Clear(); // Verilen paneldeki controllerin hepsini temizliyoruz
        }
        
        public static void panelThumbnailYazdir(Panel panel) // Bilgisayarın kart koyduğu panele işaretimizi yazdıran method
        {
            Label isaretimiz = new Label(); // İşaretimizi yazdıracağımız label'ı oluşturuyoruz
            isaretimiz.Text = isaret; // Label'a işaretimizi yazdırıyoruz
            isaretimiz.Font = new Font("Arial", 14, FontStyle.Bold); // Label'ımzın font ayarlarını veriyoruz
            panel.Controls.Add(isaretimiz); // Bize verilen panele label'ımızı ekliyoruz
            isaretimiz.Location = new Point(90, 79); // Label'ımızın pozisyonunu, panelin ortasına denk gelecek şekilde ayarlıyoruz
        }
    }
}
