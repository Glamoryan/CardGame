using KartOyunu.Entites;
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

        Kullanici kullanicimiz;
        Bilgisayar bilgisayar;
        // --- Fieds End ---------------------


        // --- Constructors Start --------------------------
        public anaMenu()
        {
            InitializeComponent();// UserControl elemanlarımızı oluşturan Visual Studio methodu            
        }
        // --- Constructors End ----------------------------



        // --- Methodlar Start -----------------------------
        public void oyunEkraniniGetir() // anaOyun instance'ını set edip, panele ekleyen method
        {
            if (_anaOyun == null) // Eğer anaOyun değişkenimiz boşsa bu block çalışır
            {
                if (kullanciyiAl() != null && bilgisayariAl() != null) //Eğer kullaniciyiAl ve bilgisayarıAl methodlarımız boş değer döndürmemişse bu block çalışır
                    _anaOyun = new anaOyun(kullanicimiz, bilgisayar); // Ana oyun class'ımızı, oyuncularımızı göndererek oluşturuyoruz ve değişkene atıyoruz
                else
                    _anaOyun = new anaOyun(); // anaOyunun yeni instance'ını oluşturup değişkene atıyoruz  

                PanelHelper.panelTemizle(anaPanel); // AnaPaneli temizleyen method                                   
                anaPanel.Controls.Add(_anaOyun); // AnaPanel'e oluşturduğumuz anaOyun UserControl'ünü ekliyoruz                
            }
        }

        public Oyuncu kullanciyiAl() // Kullanıcı bilgilerini set eden method
        {
            if (tbxKullaniciAdi.Text != "") // Eğer kullanıcı adı girilmişse bu block çalışır
            {
                kullanicimiz = new Kullanici(); // Kullanıcı instance'ı oluşturup değişkene atıyoruz

                // Kullanıcımızın bilgilerini setter ile set ediyoruz
                kullanicimiz.setOyuncuId(1); 
                kullanicimiz.setOyuncuAdi(tbxKullaniciAdi.Text);
                kullanicimiz.setSkor(0);
                
                return kullanicimiz; //Kullanıcımızı dönüyoruz
            }
            return null; // Eğer kullanıcı adı girilmemişse boş dönüyoruz
        }

        public Oyuncu bilgisayariAl() // Bilgisayar bilgilerini set eden method
        {
            if(tbxBilgisayarAdi.Text != "") // Eğer bilgisayar adı girilmişse bu block çalışır
            {
                bilgisayar = new Bilgisayar(); // Bilgisayar instance'ı oluşturup değişkene atıyoruz

                // Bilgisayarımızın bilgilerini setter ile set ediyoruz
                bilgisayar.setOyuncuId(2);
                bilgisayar.setOyuncuAdi(tbxBilgisayarAdi.Text);
                bilgisayar.setSkor(0);

                return bilgisayar; // Bilgisayarımızı dönüyoruz
            }
            return null; //// Eğer bilgisayar adı girilmemişse boş dönüyoruz
        }            
        // --- Methodlar End-----------------------------



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
            oyunEkraniniGetir(); // Oyun ekranını getir methodunu çağırıyoruz
        }
        // --- Events (Olaylar) Start -----------------------------
    }
}
