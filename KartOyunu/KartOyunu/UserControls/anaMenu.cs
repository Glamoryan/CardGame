using KartOyunu.UserControls.Utilities;
using System;
using System.Windows.Forms;

namespace KartOyunu.UserControls
{
    public partial class anaMenu : UserControl // Sadece anamenüyü içeren UserControl
    {
        // --- Fieds Start ---------------------
        public anaOyun _anaOyun; // AnaOyun instance'ımızı tutan değişken
        private Panel anaPanel; // AnaPanel panelimizi tutan değişken
        // --- Fieds End ---------------------


        // --- Constructors Start --------------------------
        public anaMenu()
        {
            InitializeComponent();// UserControl elemanlarımızı oluşturan Visual Studio methodu            
        }
        // --- Constructors End ----------------------------

        // --- Events (Olaylar) Start -----------------------------        
        private void anaMenu_Load(object sender, EventArgs e) // UserControlümüz ilk yüklendiğinde çalışacak event
        {
            anaPanel = this.Parent as Panel;  // Bu userControl'ün içinde bulunduğu paneli (pnlMain) "this" ile panel olarak seçtip atadık
        }
        
        private void btnCikis_Click(object sender, EventArgs e)// Çıkış butonuna tıklandığında çalışacak event
        {
            Application.Exit(); //Uygulamadan çıkış
        }
        
        private void btnBaslat_Click(object sender, EventArgs e) // Başlat butonuna tıklandığında çalışacak event
        {                        
            if(_anaOyun == null) // Eğer anaOyun değişkenimiz boşsa bu block çalışır
            {
                PanelHelper.panelTemizle(anaPanel); // AnaPaneli temizleyen method
                _anaOyun = new anaOyun(); // anaOyunun yeni instance'ını oluşturup değişkene atıyoruz
                anaPanel.Controls.Add(_anaOyun); // AnaPanel'e oluşturduğumuz anaOyun UserControl'ünü ekliyoruz                
            }
        }
        // --- Events (Olaylar) Start -----------------------------
    }
}
