using KartOyunu.Entites;
using KartOyunu.UserControls.Utilities;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace KartOyunu.UserControls
{
    public partial class anaOyun : UserControl
    {
        // --- Fields Start ---
        public Test test; // Test class'ımızın instance'ını tutacak değişken
        public string suankiTur = "Futbolcu"; // Tur durumunu tutacak değişken (İstenilen turda başlanabilir => Futbolcu veya Basketbolcu)
        public int turSayisi = 1; // Tur sayısını tutacak değişken
        public int berabereSayisi = 0; // Beraberlik sayısını tutan değişken

        public Oyuncu kullanici; // Kullanıcı bilgilerimizi tutan değişken
        public Oyuncu bilgisayar; // Bilgisayar bilgilerimizi tutan değişken

        public Sporcu _bilgisayarOynananSporcu; // O anki turda bilgisayarın oynadığı sporcuyu tutacak değişken 
        public Sporcu _kullaniciOynananSporcu; // O anki turda kullanıcının oynadığı sporcuyu tutacak değişken

        public IKartBase _kullaniciOynananKart; // O anki turda kullanıcının oynadığı kartı tutacak değişken
        public IKartBase _bilgisayarOynananKart; // O anki turda bilgisayarın oynadığı kartı tutacak değişken        

        public Oyuncu kazanan; // O turu kazanan oyuncuyu tutacak değişken
        // --- Fields End ---



        // --- Constructors Start ---
        public anaOyun()
        {
            InitializeComponent(); // Visual Studio kodu form elemanlarını oluşturur

            // Kartların hepsini görebilmek için kartların gösterildiği panele (pnlKartlarim) yatay scrollbar ekliyoruz
            pnlKartlarim.AutoScroll = false;
            pnlKartlarim.VerticalScroll.Enabled = false;
            pnlKartlarim.VerticalScroll.Visible = false;
            pnlKartlarim.VerticalScroll.Minimum = 0;            
            pnlKartlarim.AutoScroll = true;
        }

        public anaOyun(Oyuncu kullanici,Oyuncu bilgisayar)
        {
            InitializeComponent(); // Visual Studio kodu form elemanlarını oluşturur

            // Kartların hepsini görebilmek için kartların gösterildiği panele (pnlKartlarim) yatay scrollbar ekliyoruz
            pnlKartlarim.AutoScroll = false;
            pnlKartlarim.VerticalScroll.Enabled = false;
            pnlKartlarim.VerticalScroll.Visible = false;
            pnlKartlarim.VerticalScroll.Minimum = 0;
            pnlKartlarim.AutoScroll = true;

            // Contructor'da verilen oyuncuları property'lerimize set ediyoruz
            this.kullanici = kullanici;
            this.bilgisayar = bilgisayar;
        }
        // --- Constructors End ---



        // --- Arayüz - Ekrana yazdırma methodları Start ---------------------------------------------------------------------------------------------------------------------
        public void turSayisiniYazdir() // Tur sayısını ekrana yazdıran method
        {
            lblTur.Text = turSayisi.ToString(); // Tur label'ımıza tur sayısını yazdırıyoruz (int olduğu için toString() ile stringe çeviriyoruz)
        }

        public void oyuncuIsimleriniYazdir() // Oyuncu isimlerini ekrana yazdıran method
        {
            // Kullanıcı ve Bilgisayar adlarını test class'ımızdaki Getter'lar ile paneldeki label'lara yazdırıyoruz
            lblBilgisayarAdi.Text = test._bilgisayar.getOyuncuAdi();
            lblKullaniciAdi.Text = test._kullanici.getOyuncuAdi();
        }
        
        public void skorlariYazdir() // Oyuncu skorlarını ekrana yazdıran method
        {
            // Test class'ımızdaki oyuncuların getter'ları ile skorlarını set ediğ ekrana yazdırıyoruz
            btnBilgisayarSkor.Text = test._bilgisayar.getSkor().ToString();
            btnKullaniciSkor.Text = test._kullanici.getSkor().ToString();
        }
        
        public void kazananiYazdir(Oyuncu kazanan) // Kazanan oyuncuyu ekrana yazdırıp, skorunu arttıran method
        {
            if (kazanan is Kullanici) // Eğer bize verilen kazanan kullanıcıysa bu block çalışır
            {
                test.turuKazanan(kazanan as Kullanici); // Test class'ımızdaki turuKazanan() methodu ile kullanıcıyı gönderip, skorunu arttırıyoruz      
                skorlariYazdir(); // Skorları ekrana yazdırıp güncelleyen methodu çağırıyoruz
                MessageBox.Show(test._kullanici.getOyuncuAdi() + " turu kazandı !"); // Kazananın adını getter ile alıp ekrana çıkartıyoruz                   
            }
            else if (kazanan is Bilgisayar) // Eğer bize verilen kazanan bilgisayarsa bu block çalışır
            {
                test.turuKazanan(kazanan as Bilgisayar); // Test class'ımızdaki turuKazanan() methodu ile bilgisayarı gönderip, skorunu arttırıyoruz
                skorlariYazdir(); // Skorları ekrana yazdırıp güncelleyen methodu çağırıyoruz
                MessageBox.Show(test._bilgisayar.getOyuncuAdi() + " turu kazandı !"); // Kazananın adını getter ile alıp ekrana çıkartıyoruz                                
            }
            else // Eğer kazananımız koysa bu block çalışır (kazananiBelirle() methodunda özellikleri aynı olup null döndürdüğümüz zaman)
            {
                MessageBox.Show("Berabere"); // Ekrana berabere yazdırıyoruz    
                btnGec.Visible = true; // Berabere biten turdan sonra tek kart kaldıysa o turu geçmek için "Geç" butonunu görünür yapıyoruz
                lblBilgi.Visible = true; // Bilgi label'ının görünürlüğünü aktifleştiriyoruz

                kullaniciKartGerial(); // Tur berabere bittiği için kullanıcı kartını geri alan methodu çağırıyoruz
                bilgisayarKartGerial(); // Tur berabere bittiği için bilgisayar kartını geri alan methodu çağırıyoruz
                berabereSayisi++; // Berabere sayısını 1 arttırıyoruz

                if(berabereSayisi >= 3) // Eğer 3 kez veya üstü beraberlik olmuşssa bu block çalışır
                {
                    btnBitir.Visible = true; // Oyunu bitrime butonunun görünürlüğünü açarız
                    lblBilgi2.Visible = true; // Bilgi label'ımızın görünürlüğünü açarız
                }
            }
            bilgisayarKartiSil(); // Tur bittikten sonra bilgisayarın oynadığı kartı destesinden silmek için bu methodu çağırıyoruz
            kullaniciKartiSil();            
            sonrakiTuraGec(); // Sonraki tura geçmemizi sağlana methodu çağırıyoruz
        }

        public void suankiTuruYazdir() // Şuanki turu ekrana yazdıran method (Basketbolcu veya Futbolcu turu)
        {
            grbHamle.Text = suankiTur; // Seçilen turu grupbox başlığına yazıyoruz
        }
        // --- Arayüz - Ekrana yazdırma methodları End ------------------------------------------------------------------------------------------------------------------------



        // --- Arkaplan Methodları Start --------------------------------------------------------------------------------------------------------------------------------------
        public void InitGame()// Oyunu varsayılan haline set eder
        {
            // Kart koyulan panelleri temizler
            PanelHelper.panelTemizle(pnlKullaniciKart);
            PanelHelper.panelTemizle(pnlBilgisayarKart);
            
            PanelHelper.panelThumbnailYazdir(pnlBilgisayarKart);// Bilgisayar'ın kart oynadığı panele thumbnail'ımızı getiriyoruz

            suankiTuruYazdir();// Hangi turda olduğumuzu ekrana yazdıran methodu çağırıyoruz 

            kartlariGetir(); // Kullanıcının kartlarını çekip ekrana yazdıran methodu çağırıyoruz
            desteyiKontrolEt(); // Tur durumuna göre (Basketbolcu veya futbolcu) kartları kilityen methodu çağırıyoruz
        }

        public void desteyiKontrolEt() // Tur sırasına göre kartları kilitleyip açan method
        {
            if (suankiTur == "Futbolcu") // Eğer şuanki tur Futbolcuysa bu block çalışır
            {
                foreach (UserControl kart in pnlKartlarim.Controls) // Kartlar panelindeki kartlarımızı (UserControl) foreach ile geziyoruz
                {
                    if (kart is basketbolcuKart) // Eğer gezdiğimiz kart basketbolcuysa bu block çalışır
                        kart.Enabled = false; //(Şuanki tur futbolcu olduğu için basketbolcu kartlarını pasif yapıyorz)
                    else // Eğer gezdiğimiz kart basketbolcuKartı değilse bu block çalışır
                        kart.Enabled = true; // futbolcuKartlarını etkin hale getiriyoruz
                }
            }
            else // Eğer şuanki tur Basketbolcuysa bu block çalışır
            {
                foreach (UserControl kart in pnlKartlarim.Controls) // Kartlar panelindeki kartlarımızı (UserControl) foreach ile geziyoruz
                {
                    if (kart is futbolcuKart) // Eğer gezdiğimiz kart futbolcuysa bu block çalışır
                        kart.Enabled = false; //(Şuanki tur basketbolcu olduğu için futbolcu kartlarını pasif yapıyorz)
                    else // Eğer gezdiğimiz kart futbolcuKart değilse bu block çalışır
                        kart.Enabled = true; // basketbolcuKartlarını etkin hale getiriyoruz
                }
            }
        }
        
        public void kartlariGetir() // Kullanıcının kartlarını getirip ekrana yazdıran method
        {
            int sayac = 0; // Kartların yerlerini kontrol etmek için bir sayaç tanımlıyoruz
            PanelHelper.panelTemizle(pnlKartlarim); // Kartların geleceği paneli temizliyoruz
            foreach (Sporcu kart in test._kullanici.kartListesi) // Test class'ında, Kullanıcı class'ımızı tutan property'deki kartListesini foreach ile geziyoruz. (Bilgisayar kartListesini gezmiyoruz çünkü ekranda göstermeyeceğiz)
            {                
                if (kart is Basketbolcu) // Eğer gezdiğimiz kartın tipi Basketbolcuysa bu block çalışır
                {
                    Basketbolcu kartim = kart as Basketbolcu; // Gezdiğimiz kartı basketbolcu olarak tanıtıp değişkene atıyoruz
                    if (!kartim.getKartKullanilmisMi()) // Eğer kartımız kullanılmamışsa bu block çalışır
                    {
                        // Gezdiğimiz kart basketbolcu olduğu için, basketbolcuKart UserControlünü oluşturuyoruz ve gezdiğimiz kartı(Sporcu tipindeki) Basketbolcu tipi olarak tanıtıp constructor'a veriyoruz
                        basketbolcuKart basketbolcuKart = new basketbolcuKart(kart as Basketbolcu);
                        basketbolcuKart.Left = (sayac * 190); // Burada kartlar iç içe geçmesin diye, kartların solundan sayac * 190 ekleyerek pozisyon veriyoruz. Sayacı 0'dan başlattığımız için ilk kart 0*190 = 0 olacağı için en sola gelir. Sonraki kartlar sayaç arttığı için sağa doğru kayar
                        basketbolcuKart.btnSec.Click += delegate (object s, EventArgs args) { kullaniciKartOyna(kart, basketbolcuKart); }; // Kartımızın butonuna kullaniciKartOyna methodunu ekliyoruz
                        pnlKartlarim.Controls.Add(basketbolcuKart);// Kartlar panelimize oluşturduğumuz basketbolcuKartını ekliyoruz.
                        sayac++; // Sonraki kartlar için aynı pozisyonda iç içe geçmesinler diye sayacı 1 arttırıyoruz
                    }                    
                }
                else // Eğer gezdiğimiz kart Futbolcu tipindeyse bu block çalışır
                {
                    Futbolcu kartim = kart as Futbolcu; // Gezdiğimiz kartı futbolcu olarak tanıtıp değişkene atıyoruz
                    if (!kartim.getKartKullanilmisMi()) // Eğer kartımız kullanılmamışsa bu block çalışır
                    {
                        // Gezdiğimiz kart futbolcu olduğu için, futbolcuKart UserControlünü oluşturuyoruz ve gezdiğimiz kartı(Sporcu tipindeki) Futbolcu tipi olarak tanıtıp constructor'a veriyoruz
                        futbolcuKart futbolcuKart = new futbolcuKart(kart as Futbolcu);
                        futbolcuKart.Left = (sayac * 190);// Burada kartlar iç içe geçmesin diye, kartların solundan sayac * 190 ekleyerek pozisyon veriyoruz. Sayacı 0'dan başlattığımız için ilk kart 0*190 = 0 olacağı için en sola gelir. Sonraki kartlar sayaç arttığı için sağa doğru kayar
                        futbolcuKart.btnSec.Click += delegate (object s, EventArgs args) { kullaniciKartOyna(kart, futbolcuKart); }; // Kartımızın butonuna kullaniciKartOyna methodunu ekliyoruz
                        pnlKartlarim.Controls.Add(futbolcuKart);// Kartlar panelimize oluşturduğumuz basketbolcuKartını ekliyoruz.
                        sayac++;// Sonraki kartlar için aynı pozisyonda iç içe geçmesinler diye sayacı 1 arttırıyoruz
                    }                    
                }
            }
        }
        
        public void bilgisayarKartOyna()// Bilgisayarın kartını görsel olarak oynatan method
        {
            if (suankiTur == "Basketbolcu") // Şuanki tur basketbolcuysa bu block çalışır
            {
                // Bilgisayarın kartSec fonksiyonuna şuanki tur basketbolcu olduğu için basketbolcu instance'ı gönderip çalıştırıyoruz. Dönen sonucu oynanacak sporcuya atıyoruz
                _bilgisayarOynananSporcu = (Basketbolcu)test._bilgisayar.kartSec(new Basketbolcu());
                basketbolcuKart oynanacakKart = new basketbolcuKart((Basketbolcu)_bilgisayarOynananSporcu); // Tur sırası basketbolcu olduğu için basketbolcuKartı instance'ı oluşturup oynanacakSporcuyu contructor'ını veriyoruz
                PanelHelper.panelTemizle(pnlBilgisayarKart); // Bilgisayar'ın kartı koyduğu paneli temizliyoruz
                pnlBilgisayarKart.Controls.Add(oynanacakKart); // Oluşturduğumuz kartı Bilgisayar'ın kart koyduğu panele ekliyoruz
                oynanacakKart.btnSec.Visible = false; // Oynanılan kartın üzerindeki seç butonunu tekrar seçilmesin diye görünürlüğünü kapatıyoruz
                _bilgisayarOynananKart = oynanacakKart; // Bilgisayarın oynadığı kartı başka bir yerde kullanmak için property'mize atıyoruz

                Basketbolcu koyulanKart = _bilgisayarOynananSporcu as Basketbolcu; // Oynanılan kartı (Sporcu) basketbolcu olarak tanıtıp değişkene atıyoruz (Özelliklerine erişmek için)
                koyulanKart.setKartKullanilmisMi(true); // Oynanılan kartın kartKullanilmisMi özelliğini setter ile true'ya set ediyoruz
            }
            else // Şuanki tur futbolcuysa block çalışır
            {
                // Bilgisayarın kartSec fonksiyonuna şuanki tur futbolcu olduğu için futbolcu instance'ı gönderip çalıştırıyoruz. Dönen sonucu oynanacak sporcuya atıyoruz
                _bilgisayarOynananSporcu = (Futbolcu)test._bilgisayar.kartSec(new Futbolcu());
                futbolcuKart oynanacakKart = new futbolcuKart((Futbolcu)_bilgisayarOynananSporcu);// Tur sırası futbolcu olduğu için futbolcuKartı instance'ı oluşturup oynanacakSporcuyu contructor'ını veriyoruz
                PanelHelper.panelTemizle(pnlBilgisayarKart);// Bilgisayar'ın kartı koyduğu paneli temizliyoruz
                pnlBilgisayarKart.Controls.Add(oynanacakKart);// Oluşturduğumuz kartı Bilgisayar'ın kart koyduğu panele ekliyoruz
                oynanacakKart.btnSec.Visible = false; // Oynanılan kartın üzerindeki seç butonunu tekrar seçilmesin diye görünürlüğünü kapatıyoruz
                _bilgisayarOynananKart = oynanacakKart; // Bilgisayarın oynadığı kartı başka bir yerde kullanmak için property'mize atıyoruz

                Futbolcu koyulanKart = _bilgisayarOynananSporcu as Futbolcu; // Oynanılan kartı (Sporcu) futbolcu olarak tanıtıp değişkene atıyoruz (Özelliklerine erişmek için)
                koyulanKart.setKartKullanilmisMi(true); // Oynanılan kartın kartKullanilmisMi özelliğini setter ile true'ya set ediyoruz
            }
        }
        
        public void kullaniciKartOyna(Sporcu secilenKart, IKartBase kartTuru)// Kullanıcının kartını oynatan method
        {
            // Seçilmiş kartın türünü belirleyip atamalarını yapıyoruz.
            futbolcuKart fKart = kartTuru as futbolcuKart;
            basketbolcuKart bKart = kartTuru as basketbolcuKart;

            _kullaniciOynananSporcu = test._kullanici.kartSec(secilenKart); // Kullanıcının kartSec() methoduna seçilen kartımızı gönderip dönen değeri değişkene atıyoruz

            PanelHelper.panelTemizle(pnlKullaniciKart); // Kullanıcının kartını oynadığı paneli temizliyoruz
            if (_kullaniciOynananSporcu is Basketbolcu && kartTuru is basketbolcuKart) //Eğer kartımız basketbolcuysa ve kartTürümüz basketbolcu kartıysa bu block çalışır
            {                
                pnlKullaniciKart.Controls.Add(bKart); // Kullanıcının kart oynadığı panele kartımızı ekliyoruz
                bKart.Left = 0; // BasketbolcuKartımızı yeniden oluşturmadığımız için önceki kartımızdan kalan Left değerini 0'lıyoruz. (Kullanıcı kartınının oynandığı panele tam otursun diye)
                bKart.btnSec.Visible = false; // Oynanılan kart tekrar seçilmesin diye seç butonunu gizliyoruz
                _kullaniciOynananKart = bKart; // Oynanan kartı başka bir yerde kullanmak için property'mize set ediyoruz                

                Basketbolcu koyulanKart = _kullaniciOynananSporcu as Basketbolcu; // Oynanılan kartı (Sporcu) basketbolcu olarak tanıtıp değişkene atıyoruz (Özelliklerine erişmek için)
                koyulanKart.setKartKullanilmisMi(true); // Oynanılan kartın kartKullanilmisMi özelliğini setter ile true'ya set ediyoruz
            }
            else if (_kullaniciOynananSporcu is Futbolcu && kartTuru is futbolcuKart) // Eğer kartımız futbolcuysa ve kartTürümüz futbolcu kartıysa bu block çalışır
            {                
                pnlKullaniciKart.Controls.Add(fKart);// Kullanıcının kart oynadığı panele kartımızı ekliyoruz
                fKart.Left = 0;// FutbolcuKartımızı yeniden oluşturmadığımız için önceki kartımızdan kalan Left değerini 0'lıyoruz. (Kullanıcı kartınının oynandığı yere tam otursun diye)
                fKart.btnSec.Visible = false; // Oynanılan kart tekrar seçilmesin diye seç butonunu gizliyoruz
                _kullaniciOynananKart = fKart; // Oynanan kartı başka bir yerde kullanmak için property'mize set ediyoruz                

                Futbolcu koyulanKart = _kullaniciOynananSporcu as Futbolcu; // Oynanılan kartı (Sporcu) futbolcu olarak tanıtıp değişkene atıyoruz (Özelliklerine erişmek için)
                koyulanKart.setKartKullanilmisMi(true); // Oynanılan kartın kartKullanilmisMi özelliğini setter ile true'ya set ediyoruz
            }

            bilgisayarKartOyna(); // Kartımızı oynadıktan sonra, Bilgisayarda kartını oynasın diye bilgisayarKartOyna() methodunu çağırıyoruz            
            
            switch (pozisyonSec())// Kartı oynadıktan sonra pozisyonSec() methodunu çağırıyoruz
            {
                case "Penaltı": //pozisyonSec() methodundan dönen özellik penaltı ise bu block çalışır
                    kazanan = kazananiBelirle("penaltı"); // Kazananı, kazananiBelirle metoduna özelliğimizi göndererek seçeriz
                    kazananiYazdir(kazanan); // Kazananı, ekrana yazdırmak ve skorunu arttırmak için kazananıYazdir() methoduna göndeririz
                    break; // Bu block'u bitiririz
                case "Serbest Vuruş": //pozisyonSec() methodundan dönen özellik serbest vuruş ise bu block çalışır
                    kazanan = kazananiBelirle("serbest vuruş"); // Kazananı, kazananiBelirle metoduna özelliğimizi göndererek seçeriz
                    kazananiYazdir(kazanan); // Kazananı, ekrana yazdırmak ve skorunu arttırmak için kazananıYazdir() methoduna göndeririz
                    break; // Bu block'u bitiririz
                case "Kaleciyle Karşı Karşıya": //pozisyonSec() methodundan dönen özellik kaleciyle karşı karşıya ise bu block çalışır
                    kazanan = kazananiBelirle("kaleciyle karşı karşıya");// Kazananı, kazananiBelirle metoduna özelliğimizi göndererek seçeriz
                    kazananiYazdir(kazanan);// Kazananı, ekrana yazdırmak ve skorunu arttırmak için kazananıYazdir() methoduna göndeririz
                    break;// Bu block'u bitiririz
                case "İkilik"://pozisyonSec() methodundan dönen özellik ikilik ise bu block çalışır
                    kazanan = kazananiBelirle("ikilik"); // Kazananı, kazananiBelirle metoduna özelliğimizi göndererek seçeriz
                    kazananiYazdir(kazanan);// Kazananı, ekrana yazdırmak ve skorunu arttırmak için kazananıYazdir() methoduna göndeririz
                    break;// Bu block'u bitiririz
                case "Üçlük"://pozisyonSec() methodundan dönen özellik üçlük ise bu block çalışır
                    kazanan = kazananiBelirle("üçlük");// Kazananı, kazananiBelirle metoduna özelliğimizi göndererek seçeriz
                    kazananiYazdir(kazanan);// Kazananı, ekrana yazdırmak ve skorunu arttırmak için kazananıYazdir() methoduna göndeririz
                    break;// Bu block'u bitiririz
                case "Serbest Atış"://pozisyonSec() methodundan dönen özellik serbest atış ise bu block çalışır
                    kazanan = kazananiBelirle("serbest atış"); // Kazananı, kazananiBelirle metoduna özelliğimizi göndererek seçeriz
                    kazananiYazdir(kazanan); // Kazananı, ekrana yazdırmak ve skorunu arttırmak için kazananıYazdir() methoduna göndeririz
                    break;// Bu block'u bitiririz
            }
        }

        public void bilgisayarKartGerial() // Bilgisayarın berabere biten tur sonunda kartını geri almasını sağlayan method
        {
            if (_bilgisayarOynananKart is futbolcuKart) // Önceden set ettiğimiz property'deki kartımız futbolcuKart'ı ise bu method çalışır
            {                
                Futbolcu kullanilmisSporcu = _bilgisayarOynananSporcu as Futbolcu; // Önceden set ettiğimiz property'deki sporcumuzu futbolcu olarak tanıtıp değişkene atıyoruz

                kullanilmisSporcu.setKartKullanilmisMi(false); // Oynanan kartın, KartKullanilmisMi özelliğini setter ile false yapıyoruz. Çünkü tur berabere bitti
            }
            else if (_bilgisayarOynananKart is basketbolcuKart) // Önceden set ettiğimiz property'deki kartımız basketbolcuKart'ı ise bu method çalışır
            {                
                Basketbolcu kullanilmisSporcu = _bilgisayarOynananSporcu as Basketbolcu; // Önceden set ettiğimiz property'deki sporcumuzu basketbolcu olarak tanıtıp değişkene atıyoruz

                kullanilmisSporcu.setKartKullanilmisMi(false); // Önceden set ettiğimiz property'deki kartımız basketbolcuKart'ı ise bu method çalışır
            }
        }

        public void kullaniciKartGerial()  // Kullanıcının berabere biten tur sonunda kartını geri almasını sağlayan method
        {            
            if (_kullaniciOynananKart is futbolcuKart) // Önceden set ettiğimiz property'deki kartımız futbolcuKart'ı ise bu method çalışır
            {
                Futbolcu kullanilmisSporcu = _kullaniciOynananSporcu as Futbolcu; // Önceden set ettiğimiz property'deki sporcumuzu futbolcu olarak tanıtıp değişkene atıyoruz

                kullanilmisSporcu.setKartKullanilmisMi(false); // Oynanan kartın, KartKullanilmisMi özelliğini setter ile false yapıyoruz. Çünkü tur berabere bitti
            }
            else if (_kullaniciOynananKart is basketbolcuKart)// Önceden set ettiğimiz property'deki kartımız basketbolcuKart'ı ise bu method çalışır
            {
                Basketbolcu kullanilmisSporcu = _kullaniciOynananSporcu as Basketbolcu; // Önceden set ettiğimiz property'deki sporcumuzu basketbolcu olarak tanıtıp değişkene atıyoruz

                kullanilmisSporcu.setKartKullanilmisMi(false); // Önceden set ettiğimiz property'deki kartımız basketbolcuKart'ı ise bu method çalışır
            }
        }

        public void bilgisayarKartiSil() // Tur berabere bitmeşse bilgisayar destesinden kartı silen method
        {
            if (_bilgisayarOynananSporcu is Basketbolcu) // Önceden set ettiğimiz property'deki oynanan sporcu basketbolcuysa bu block çalışır
            {
                Basketbolcu kullanilmisKart = _bilgisayarOynananSporcu as Basketbolcu; // Property'mizdeki sporcuyu, basketbolcu olarak tanıtıp değişkene atıyoruz
                if (kullanilmisKart.getKartKullanilmisMi()) // Kartın kullanılmış olup olmadığını anlamak için getter ile kartKullanilmisMi özelliğini çağırıyoruz. Eğer kart kullanılmışsa bu block çalışır
                    test._bilgisayar.kartListesi.Remove(kullanilmisKart); // Kullanılmış kartı bilgisayar destesinden siliyoruz
            }
            else // Eğer oynanan sporcu futbolcuysa bu block çalışır
            {
                Futbolcu kullanilmisKart = _bilgisayarOynananSporcu as Futbolcu;  // Property'mizdeki sporcuyu, futbolcu olarak tanıtıp değişkene atıyoruz
                if (kullanilmisKart.getKartKullanilmisMi()) // Kartın kullanılmış olup olmadığını anlamak için getter ile kartKullanilmisMi özelliğini çağırıyoruz. Eğer kart kullanılmışsa bu block çalışır
                    test._bilgisayar.kartListesi.Remove(kullanilmisKart); // Kullanılmış kartı bilgisayar destesinden siliyoruz
            }
        }

        public void kullaniciKartiSil() // Tur berabere bitmeşse kullanıcı destesinden kartı silen method
        {
            if (_kullaniciOynananSporcu is Basketbolcu) // Önceden set ettiğimiz property'deki oynanan sporcu basketbolcuysa bu block çalışır
            {
                Basketbolcu kullanilmisKart = _kullaniciOynananSporcu as Basketbolcu;  // Property'mizdeki sporcuyu, basketbolcu olarak tanıtıp değişkene atıyoruz
                if (kullanilmisKart.getKartKullanilmisMi()) // Kartın kullanılmış olup olmadığını anlamak için getter ile kartKullanilmisMi özelliğini çağırıyoruz. Eğer kart kullanılmışsa bu block çalışır
                    test._kullanici.kartListesi.Remove(kullanilmisKart); // Kullanılmış kartı kullanıcı destesinden siliyoruz
            }
            else // Eğer oynanan sporcu futbolcuysa bu block çalışır
            {
                Futbolcu kullanilmisKart = _kullaniciOynananSporcu as Futbolcu; // Property'mizdeki sporcuyu, futbolcu olarak tanıtıp değişkene atıyoruz
                if (kullanilmisKart.getKartKullanilmisMi()) // Kartın kullanılmış olup olmadığını anlamak için getter ile kartKullanilmisMi özelliğini çağırıyoruz. Eğer kart kullanılmışsa bu block çalışır
                    test._kullanici.kartListesi.Remove(kullanilmisKart); // Kullanılmış kartı kullanıcı destesinden siliyoruz
            }
        }
        
        public Oyuncu kazananiBelirle(string ozellik)// Kazanan oyuncuyu belirleyip geri döndüren method
        {
            if (suankiTur == "Futbolcu") // Eğer şuanki tur futbolcu turuysa bu block çalışır
            {
                // Oynanılan kartları (Sporcu türündeki) futbolcu türünde tanıtıp değişkenlere atıyoruz
                Futbolcu kullaniciKazanan = _kullaniciOynananSporcu as Futbolcu;
                Futbolcu bilgisayarKazanan = _bilgisayarOynananSporcu as Futbolcu;

                if (ozellik == "penaltı") // Eğer bize verilen özellik penaltı ise bu block çalışır
                {
                    // Kullanıcı ve Bilgisayarın futbolcu özellikleri sporcuPuaniGoster methodu ile set ediyoruz
                    int kOzellikPuani = kullaniciKazanan.sporcuPuaniGoster(ozellik);
                    int bOzellikPuani = bilgisayarKazanan.sporcuPuaniGoster(ozellik);

                    if (kOzellikPuani > bOzellikPuani)//Eğer kullanıcının kartındaki penaltı özelliği bilgisayarın kartındaki penaltı özelliğinden daha büyükse bu block çalışır
                        return test._kullanici;// Kullanıcının kartının özelliği daha büyük olduğu için kazanan kullanıcı olur ve geri döndürürüz
                    else if (kOzellikPuani < bOzellikPuani)//Eğer kullanıcının kartındaki penaltı özelliği bilgisayarın kartındaki penaltı özelliğinden daha küçükse bu block çalışır
                        return test._bilgisayar;// Kullanıcının kartının özelliği daha küçük olduğu için kazanan bilgisayar olur ve geri döndürürüz
                    else // Eğer özellikler eşit ise bu block çalışır
                        return null; // Kimse kazanamadığı için boş değer döndürürüz
                }
                else if (ozellik == "serbest vuruş")// Eğer bize verilen özellik serbest vuruş ise bu block çalışır
                {
                    // Kullanıcı ve Bilgisayarın futbolcu özellikleri sporcuPuaniGoster methodu ile set ediyoruz
                    int kOzellikPuani = kullaniciKazanan.sporcuPuaniGoster(ozellik);
                    int bOzellikPuani = bilgisayarKazanan.sporcuPuaniGoster(ozellik);

                    if (kOzellikPuani > bOzellikPuani)//Eğer kullanıcının kartındaki penaltı özelliği bilgisayarın kartındaki penaltı özelliğinden daha büyükse bu block çalışır
                        return test._kullanici;// Kullanıcının kartının özelliği daha büyük olduğu için kazanan kullanıcı olur ve geri döndürürüz
                    else if (kOzellikPuani < bOzellikPuani)//Eğer kullanıcının kartındaki penaltı özelliği bilgisayarın kartındaki penaltı özelliğinden daha küçükse bu block çalışır
                        return test._bilgisayar;// Kullanıcının kartının özelliği daha küçük olduğu için kazanan bilgisayar olur ve geri döndürürüz
                    else // Eğer özellikler eşit ise bu block çalışır
                        return null; // Kimse kazanamadığı için boş değer döndürürüz
                }
                else // Eğer bize verilen özellik kaleciyle karşı karşıyaysa bu block çalışır
                {
                    // Kullanıcı ve Bilgisayarın futbolcu özellikleri sporcuPuaniGoster methodu ile set ediyoruz
                    int kOzellikPuani = kullaniciKazanan.sporcuPuaniGoster(ozellik);
                    int bOzellikPuani = bilgisayarKazanan.sporcuPuaniGoster(ozellik);

                    if (kOzellikPuani > bOzellikPuani)//Eğer kullanıcının kartındaki penaltı özelliği bilgisayarın kartındaki penaltı özelliğinden daha büyükse bu block çalışır
                        return test._kullanici;// Kullanıcının kartının özelliği daha büyük olduğu için kazanan kullanıcı olur ve geri döndürürüz
                    else if (kOzellikPuani < bOzellikPuani)//Eğer kullanıcının kartındaki penaltı özelliği bilgisayarın kartındaki penaltı özelliğinden daha küçükse bu block çalışır
                        return test._bilgisayar;// Kullanıcının kartının özelliği daha küçük olduğu için kazanan bilgisayar olur ve geri döndürürüz
                    else // Eğer özellikler eşit ise bu block çalışır
                        return null; // Kimse kazanamadığı için boş değer döndürürüz
                }
            }
            else // Eğer şuanki tur basketbolcu turuysa bu block çalışır
            {
                // Oynanılan kartları (Sporcu türündeki) basketbolcu türünde tanıtıp değişkenlere atıyoruz
                Basketbolcu kullaniciKazanan = _kullaniciOynananSporcu as Basketbolcu;
                Basketbolcu bilgisayarKazanan = _bilgisayarOynananSporcu as Basketbolcu;

                if (ozellik == "ikilik")// Eğer bize verilen özellik ikilik ise bu block çalışır
                {
                    // Kullanıcı ve Bilgisayarın futbolcu özellikleri sporcuPuaniGoster methodu ile set ediyoruz
                    int kOzellikPuani = kullaniciKazanan.sporcuPuaniGoster(ozellik);
                    int bOzellikPuani = bilgisayarKazanan.sporcuPuaniGoster(ozellik);

                    if (kOzellikPuani > bOzellikPuani)//Eğer kullanıcının kartındaki penaltı özelliği bilgisayarın kartındaki penaltı özelliğinden daha büyükse bu block çalışır
                        return test._kullanici;// Kullanıcının kartının özelliği daha büyük olduğu için kazanan kullanıcı olur ve geri döndürürüz
                    else if (kOzellikPuani < bOzellikPuani)//Eğer kullanıcının kartındaki penaltı özelliği bilgisayarın kartındaki penaltı özelliğinden daha küçükse bu block çalışır
                        return test._bilgisayar;// Kullanıcının kartının özelliği daha küçük olduğu için kazanan bilgisayar olur ve geri döndürürüz
                    else // Eğer özellikler eşit ise bu block çalışır
                        return null; // Kimse kazanamadığı için boş değer döndürürüz
                }
                else if (ozellik == "üçlük")// Eğer bize verilen özellik üçlük ise bu block çalışır
                {
                    // Kullanıcı ve Bilgisayarın futbolcu özellikleri sporcuPuaniGoster methodu ile set ediyoruz
                    int kOzellikPuani = kullaniciKazanan.sporcuPuaniGoster(ozellik);
                    int bOzellikPuani = bilgisayarKazanan.sporcuPuaniGoster(ozellik);

                    if (kOzellikPuani > bOzellikPuani)//Eğer kullanıcının kartındaki penaltı özelliği bilgisayarın kartındaki penaltı özelliğinden daha büyükse bu block çalışır
                        return test._kullanici;// Kullanıcının kartının özelliği daha büyük olduğu için kazanan kullanıcı olur ve geri döndürürüz
                    else if (kOzellikPuani < bOzellikPuani)//Eğer kullanıcının kartındaki penaltı özelliği bilgisayarın kartındaki penaltı özelliğinden daha küçükse bu block çalışır
                        return test._bilgisayar;// Kullanıcının kartının özelliği daha küçük olduğu için kazanan bilgisayar olur ve geri döndürürüz
                    else // Eğer özellikler eşit ise bu block çalışır
                        return null; // Kimse kazanamadığı için boş değer döndürürüz
                }
                else
                {
                    // Kullanıcı ve Bilgisayarın futbolcu özellikleri sporcuPuaniGoster methodu ile set ediyoruz
                    int kOzellikPuani = kullaniciKazanan.sporcuPuaniGoster(ozellik);
                    int bOzellikPuani = bilgisayarKazanan.sporcuPuaniGoster(ozellik);

                    if (kOzellikPuani > bOzellikPuani)//Eğer kullanıcının kartındaki penaltı özelliği bilgisayarın kartındaki penaltı özelliğinden daha büyükse bu block çalışır
                        return test._kullanici;// Kullanıcının kartının özelliği daha büyük olduğu için kazanan kullanıcı olur ve geri döndürürüz
                    else if (kOzellikPuani < bOzellikPuani)//Eğer kullanıcının kartındaki penaltı özelliği bilgisayarın kartındaki penaltı özelliğinden daha küçükse bu block çalışır
                        return test._bilgisayar;// Kullanıcının kartının özelliği daha küçük olduğu için kazanan bilgisayar olur ve geri döndürürüz
                    else // Eğer özellikler eşit ise bu block çalışır
                        return null; // Kimse kazanamadığı için boş değer döndürürüz
                }
            }
        }
        
        public string pozisyonSec()// Şuanki tura göre (Basketbolcu veya Futbolcu turu) özellik seçip ekrana yazdıran method
        {
            string secilenOzellik = test.poziyonSecici(suankiTur); // Test class'ımızdaki pozisyonSecici() methodumuzu çağırıp değişkene atıyoruz
            lblOzellik.Text = secilenOzellik; // Seçilen özelliği label'ımıza yazdırıyoruz
            return secilenOzellik; // Seçilen özelliği geri döndürüyoruz
        }

        public bool oyunBittiMi() // Oyunun bitip bitmediğini kontrol eden method
        {
            if (test._kullanici.kartListesi.Count == 0 && test._bilgisayar.kartListesi.Count == 0) // Eğer iki oyuncunun elindede kart kalmadıysa bu block çalışır
            {
                Oyuncu oyunuKazanan = test.oyunuBitir(); // Test class'ındaki oyunu bitir methodundan dönen oyuncuyu değişkene aktarıyoruz
                if (oyunuKazanan != null) // Eğer kazanan oyuncu boş değilse bu block çalışır
                {                    
                    MessageBox.Show(oyunuKazanan.getOyuncuAdi() + " oyuncusu oyunu " + oyunuKazanan.getSkor() + " skoru ile bitirdi");// Ekrana oyuncunun adını ve skorunu yazdırırız
                    return true; // Geriye true döndürürüz, yani oyun bitti
                }
                else // Eğer kazanan oyuncu boş dönmüşse bu block çalışır (Berabere bittiyse)
                {
                    MessageBox.Show("Oyun berabere bitti"); // Ekrana oyun berabere bitti yazdırırız
                    return true; // Geriye true döndürürüz, yani oyun bitti
                }
            }
            return false;// Eğer oyuncuların elinde kart varsa geriye false döndürürüz, yani oyun bitmedi
        }

        public void sonrakiTuraGec() // Sonraki tura geçmemizi sağlayan method
        {
            if (oyunBittiMi()) // Eğer oyunBittiMi() methodundan true döndüyse yani oyun bittiyse bu block çalışır
            {
                Dispose(); //AnaOyun controlünün içindeki tüm elemanları sileriz
                PanelHelper.panelTemizle(PanelHelper.mainPanel); // Ana formumuzda bulunan mainPanelin içini temizleriz
                PanelHelper.mainPanel.Controls.Add(new anaMenu()); // mainPanelin içine yeni bir anaMenu instance'ı oluşturup ekleriz
            }
            else // Eğer oyunBittiMi() methodundan false döndüyse yani oyun bitmediyse bu block çalışır
            {
                suankiTur = test.turSecici(suankiTur);// Tur secici ile sonraki turu seçiyoruz ve property'mize atıyoruz
                turSayisi += 1; // Tur sayısını 1 arttırıyoruz            

                InitGame(); // Oyunu yeni tura uygun yeniden set etmesi için bu methodu çağırıyoruz            

                turSayisiniYazdir(); // Tur sayısını ekrana yazdırması için bu methodu çağırıyoruz
            }            
        }
        // --- Arkaplan Methodları End --------------------------------------------------------------------------------------------------------------------------------------



        // --- Eventler (Olaylar) Start -------------------------------------------------------------------------------------------------------------------------------------        
        private void anaOyun_Load(object sender, EventArgs e)// Anaoyun controlümüz yüklendiğinde çalışacak event
        {
            if (kullanici == null || bilgisayar == null) // Eğer kullanıcı veya bilgisayar oyuncularının bilgileri verilmemişse bu block çalışır
                test = new Test();// Test Class'ımızın instance'ını alıyoruz         
            else // Eğer kullanıcı veya bilgisayar oyuncularının bilgileri verilmişse bu block çalışır
                test = new Test(kullanici, bilgisayar); ;// Test Class'ımızın instance'ını oyuncuları göndererek alıyoruz  

            InitGame(); // Yeni tur için oyunu set eden methodu çağırıyoruz         

            oyuncuIsimleriniYazdir(); // Oyuncu isimlerini ekrana yazdıran methodu çağırıyoruz
        }

        private void btnGec_Click(object sender, EventArgs e) // Sonraki tura geç butonuna tıklandığında çalışacak event
        {
            sonrakiTuraGec(); // Sonraki tura geçmek için bu methodu çağırıyoruz
        }

        private void btnBitir_Click(object sender, EventArgs e) // Çıkmaz durumunda oyunu bitiren butonun eventi
        {
            Oyuncu oyunuKazanan = test.oyunuBitir(); // Test class'ımızdaki oyunuBitir() methodunu çağırıp kazananı değişkene atarız
            if (oyunuKazanan != null) // Eğer kazanan boş gelmemişse bu block çalışır
            {
                MessageBox.Show(oyunuKazanan.getOyuncuAdi() + " oyuncusu oyunu " + oyunuKazanan.getSkor() + " skoru ile bitirdi");// Kazananı skor ve adı ile birlikte ekrana yazarız                
            }
            else // Eğer kazanan boş dönmüşse (Berabere bitmişse) bu block çalışır
            {
                MessageBox.Show("Oyun berabere bitti"); // Ekrana oyun berabere bitti yazdırırız                 
            }
            Dispose(); //AnaOyun controlünün içindeki tüm elemanları sileriz
            PanelHelper.panelTemizle(PanelHelper.mainPanel); // Ana formumuzda bulunan mainPanelin içini temizleriz
            PanelHelper.mainPanel.Controls.Add(new anaMenu()); // mainPanelin içine yeni bir anaMenu instance'ı oluşturup ekleriz
        }
        // --- Eventler (Olaylar) End -------------------------------------------------------------------------------------------------------------------------------------        
    }
}
