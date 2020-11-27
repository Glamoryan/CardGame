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
    public partial class anaOyun : UserControl
    {
        public Test test;
        public string suankiTur = "Futbolcu";
        public int turSayisi = 1;

        public Sporcu _bilgisayarOynananSporcu;
        public Sporcu _kullaniciOynananSporcu;

        public Oyuncu kazanan;

        public anaOyun()
        {
            InitializeComponent();

            // Kartların hepsini görebilmek için kartların gösterildiği panele (pnlKartlarim) yatay scrollbar ekliyoruz
            pnlKartlarim.AutoScroll = false;
            pnlKartlarim.VerticalScroll.Enabled = false;
            pnlKartlarim.VerticalScroll.Visible = false;
            pnlKartlarim.VerticalScroll.Maximum = 0;
            pnlKartlarim.AutoScroll = true;
        }

        public void InitGame()
        {
            PanelHelper.panelTemizle(pnlKullaniciKart);
            PanelHelper.panelTemizle(pnlBilgisayarKart);

            // Bilgisayar'ın kart oynadığı panele thumbnail'ımızı getiriyoruz
            PanelHelper.panelThumbnailYazdir(pnlBilgisayarKart);                       

            suankiTuruYazdir();            
        }

        public void turSayisiniYazdir()
        {
            lblTur.Text = turSayisi.ToString();
        }

        public void kartlariKontrolEt()
        {
            if (suankiTur == "Futbolcu") // Eğer şuanki tur Futbolcuysa bu block çalışır
            {
                foreach (UserControl kart in pnlKartlarim.Controls) // Kartlar panelindeki kartlarımızı (UserControl) foreach ile geziyoruz
                {
                    if (kart is basketbolcuKart) // Eğer gezdiğimiz kart basketbolcuysa bu block çalışır
                        kart.Enabled = false; //(Şuanki tur futbolcu olduğu için basketbolcu kartlarını pasif yapıyorz)
                    else
                        kart.Enabled = true;
                }
            }
            else // Eğer şuanki tur Basketbolcuysa bu block çalışır
            {
                foreach (UserControl kart in pnlKartlarim.Controls) // Kartlar panelindeki kartlarımızı (UserControl) foreach ile geziyoruz
                {
                    if (kart is futbolcuKart) // Eğer gezdiğimiz kart futbolcuysa bu block çalışır
                        kart.Enabled = false; //(Şuanki tur basketbolcu olduğu için futbolcu kartlarını pasif yapıyorz)
                    else
                        kart.Enabled = true;
                }
            }
        }

        public void oyuncuIsimleriniYazdir()
        {
            // Kullanıcı ve Bilgisayar adlarını test class'ımızdaki Getter'lar ile paneldeki label'lara yazdırıyoruz
            lblBilgisayarAdi.Text = test._bilgisayar.getOyuncuAdi();
            lblKullaniciAdi.Text = test._kullanici.getOyuncuAdi();
        }

        public void kartlariGetir()
        {
            int sayac = 0; // Kartların yerlerini kontrol etmek için bir sayaç tanımlıyoruz

            foreach (Sporcu kart in test._kullanici.kartListesi) // Test class'ında, Kullanıcı class'ımızı tutan property'deki kartListesini foreach ile geziyoruz. (Bilgisayar kartListesini gezmiyoruz çünkü ekranda göstermeyeceğiz)
            {
                if (kart is Basketbolcu) // Eğer gezdiğimiz kartın tipi Basketbolcuysa bu block çalışır
                {
                    // Gezdiğimiz kart basketbolcu olduğu için, basketbolcuKart UserControlünü oluşturuyoruz ve gezdiğimiz kartı(Sporcu tipindeki) Basketbolcu tipi olarak tanıtıp constructor'a veriyoruz
                    basketbolcuKart basketbolcuKart = new basketbolcuKart(kart as Basketbolcu);
                    basketbolcuKart.Left = (sayac * 190); // Burada kartlar iç içe geçmesin diye, kartların solundan sayac * 190 ekleyerek pozisyon veriyoruz. Sayacı 0'dan başlattığımız için ilk kart 0*190 = 0 olacağı için en sola gelir. Sonraki kartlar sayaç arttığı için sağa doğru kayar
                    basketbolcuKart.btnSec.Click += delegate (object s, EventArgs args) { kullaniciKartOyna(kart, basketbolcuKart); };
                    pnlKartlarim.Controls.Add(basketbolcuKart);// Kartlar panelimize oluşturduğumuz basketbolcuKartını ekliyoruz.
                    sayac++; // Sonraki kartlar için aynı pozisyonda iç içe geçmesinler diye sayacı 1 arttırıyoruz
                }
                else // Eğer gezdiğimiz kart Futbolcu tipindeyse bu block çalışır
                {
                    // Gezdiğimiz kart futbolcu olduğu için, futbolcuKart UserControlünü oluşturuyoruz ve gezdiğimiz kartı(Sporcu tipindeki) Futbolcu tipi olarak tanıtıp constructor'a veriyoruz
                    futbolcuKart futbolcuKart = new futbolcuKart(kart as Futbolcu);
                    futbolcuKart.Left = (sayac * 190);// Burada kartlar iç içe geçmesin diye, kartların solundan sayac * 190 ekleyerek pozisyon veriyoruz. Sayacı 0'dan başlattığımız için ilk kart 0*190 = 0 olacağı için en sola gelir. Sonraki kartlar sayaç arttığı için sağa doğru kayar
                    futbolcuKart.btnSec.Click += delegate (object s, EventArgs args) { kullaniciKartOyna(kart, futbolcuKart); };
                    pnlKartlarim.Controls.Add(futbolcuKart);// Kartlar panelimize oluşturduğumuz basketbolcuKartını ekliyoruz.
                    sayac++;// Sonraki kartlar için aynı pozisyonda iç içe geçmesinler diye sayacı 1 arttırıyoruz
                }
            }
        }

        // Anaoyun controlümüz load olunca çalışacak method
        private void anaOyun_Load(object sender, EventArgs e)
        {
            // Test Class'ımızın instance'ını alıyoruz
            test = new Test();

            InitGame();
            kartlariGetir();
            kartlariKontrolEt();
            oyuncuIsimleriniYazdir();
        }       
        
        // Oyuncu skorlarını ekrana yazdıran method
        public void skorlariYazdir()
        {
            // Test class'ımızdaki oyuncuların getter'ları ile skorlarını set ediğ ekrana yazdırıyoruz
            btnBilgisayarSkor.Text = test._bilgisayar.getSkor().ToString();
            btnKullaniciSkor.Text = test._kullanici.getSkor().ToString();
        }

        // Bilgisayarın kartını görsel olarak oynatan method
        public void bilgisayarKartOyna()
        {
            if (suankiTur == "Basketbolcu") // Şuanki tur basketbolcuysa bu block çalışır
            {
                // Bilgisayarın kartSec fonksiyonuna şuanki tur basketbolcu olduğu için basketbolcu instance'ı gönderip çalıştırıyoruz. Dönen sonucu oynanacak sporcuya atıyoruz
                _bilgisayarOynananSporcu = (Basketbolcu)test._bilgisayar.kartSec(new Basketbolcu());
                basketbolcuKart oynanacakKart = new basketbolcuKart((Basketbolcu)_bilgisayarOynananSporcu); // Tur sırası basketbolcu olduğu için basketbolcuKartı instance'ı oluşturup oynanacakSporcuyu contructor'ını veriyoruz
                PanelHelper.panelTemizle(pnlBilgisayarKart); // Bilgisayar'ın kartı koyduğu paneli temizliyoruz
                pnlBilgisayarKart.Controls.Add(oynanacakKart); // Oluşturduğumuz kartı Bilgisayar'ın kart koyduğu panele ekliyoruz
                oynanacakKart.btnSec.Visible = false;
            }
            else // Şuanki tur futbolcuysa block çalışır
            {
                // Bilgisayarın kartSec fonksiyonuna şuanki tur futbolcu olduğu için futbolcu instance'ı gönderip çalıştırıyoruz. Dönen sonucu oynanacak sporcuya atıyoruz
                _bilgisayarOynananSporcu = (Futbolcu)test._bilgisayar.kartSec(new Futbolcu());
                futbolcuKart oynanacakKart = new futbolcuKart((Futbolcu)_bilgisayarOynananSporcu);// Tur sırası futbolcu olduğu için futbolcuKartı instance'ı oluşturup oynanacakSporcuyu contructor'ını veriyoruz
                PanelHelper.panelTemizle(pnlBilgisayarKart);// Bilgisayar'ın kartı koyduğu paneli temizliyoruz
                pnlBilgisayarKart.Controls.Add(oynanacakKart);// Oluşturduğumuz kartı Bilgisayar'ın kart koyduğu panele ekliyoruz
                oynanacakKart.btnSec.Visible = false;
            }
        }

        // Kazanan oyuncuyu ekrana yazdırıp, skorunu arttıran method
        public void kazananiYazdir(Oyuncu kazanan)
        {
            if (kazanan is Kullanici) // Eğer bize verilen kazanan kullanıcıysa bu block çalışır
            {
                test.turuKazanan(kazanan as Kullanici); // Test class'ımızdaki turuKazanan() methodu ile kullanıcıyı gönderip, skorunu arttırıyoruz
                MessageBox.Show(test._kullanici.getOyuncuAdi() + " turu kazandı !"); // Kazananın adını getter ile alıp ekrana çıkartıyoruz                                
            }
            else if (kazanan is Bilgisayar) // Eğer bize verilen kazanan bilgisayarsa bu block çalışır
            {
                test.turuKazanan(kazanan as Bilgisayar); // Test class'ımızdaki turuKazanan() methodu ile bilgisayarı gönderip, skorunu arttırıyoruz
                MessageBox.Show(test._bilgisayar.getOyuncuAdi() + " turu kazandı !"); // Kazananın adını getter ile alıp ekrana çıkartıyoruz                                
            }
            else // Eğer kazananımız koysa bu block çalışır (kazananiBelirle() methodunda özellikleri aynı olup null döndürdüğümüz zaman)
            {
                MessageBox.Show("Berabere"); // Ekrana berabere yazdırıyoruz                
            }
            skorlariYazdir();
            sonrakiTuraGec();
        }

        // Kullanıcının kartını görsel olarak oynatan method
        public void kullaniciKartOyna(Sporcu secilenKart,IKartBase kartTuru)
        {            
            // Seçilmiş kartın türünü belirleyip atamalarını yapıyoruz.
            futbolcuKart fKart = kartTuru as futbolcuKart;
            basketbolcuKart bKart = kartTuru as basketbolcuKart;

            _kullaniciOynananSporcu = test._kullanici.kartSec(secilenKart); // Kullanıcının kartSec() methoduna seçilen kartımızı gönderip dönen değeri değişkene atıyoruz
            
            PanelHelper.panelTemizle(pnlKullaniciKart); // Kullanıcının kartını oynadığı paneli temizliyoruz
            if (_kullaniciOynananSporcu is Basketbolcu && kartTuru is basketbolcuKart) //Eğer kartımız basketbolcuysa ve kartTürümüz basketbolcu kartıysa bu block çalışır
            {                
                pnlKullaniciKart.Controls.Add(bKart); // Kullanıcının kart oynadığı panele kartımızı ekliyoruz
                bKart.Left = 0; // BasketbolcuKartımızı yeniden oluşturmadığımız için önceki kartımızdan kalan Left değerini 0'lıyoruz. (Kullanıcı kartınının oynandığı yere tam otursun diye)
                bKart.btnSec.Visible = false;
            }
            else if (_kullaniciOynananSporcu is Futbolcu && kartTuru is futbolcuKart) // Eğer kartımız futbolcuysa ve kartTürümüz futbolcu kartıysa bu block çalışır
            {                
                pnlKullaniciKart.Controls.Add(fKart);// Kullanıcının kart oynadığı panele kartımızı ekliyoruz
                fKart.Left = 0;// FutbolcuKartımızı yeniden oluşturmadığımız için önceki kartımızdan kalan Left değerini 0'lıyoruz. (Kullanıcı kartınının oynandığı yere tam otursun diye)
                fKart.btnSec.Visible = false;
            }

            bilgisayarKartOyna(); // Kartımızı oynadıktan sonra, Bilgisayarda kartını oynasın diye bilgisayarKartOyna() methodunu çağırıyoruz            

            // Kartı oynadıktan sonra pozisyonSec() methodunu çağırıyoruz
            switch (pozisyonSec())
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

        // Kazanan oyuncuyu belirleyip geri döndüren method
        public Oyuncu kazananiBelirle(string ozellik)
        {            
            if (suankiTur == "Futbolcu") // Eğer şuanki tur futbolcu turuysa bu block çalışır
            {
                // Oynanılan kartları (Sporcu türündeki) futbolcu türünde tanıtıp değişkenlere atıyoruz
                Futbolcu kullaniciKazanan = _kullaniciOynananSporcu as Futbolcu;
                Futbolcu bilgisayarKazanan = _bilgisayarOynananSporcu as Futbolcu;                

                if (ozellik == "penaltı") // Eğer bize verilen özellik penaltı ise bu block çalışır
                {                    
                    if (kullaniciKazanan.getPenalti() > bilgisayarKazanan.getPenalti())//Eğer kullanıcının kartındaki penaltı özelliği bilgisayarın kartındaki penaltı özelliğinden daha büyükse bu block çalışır
                        return test._kullanici;// Kullanıcının kartının özelliği daha büyük olduğu için kazanan kullanıcı olur ve geri döndürürüz
                    else if (kullaniciKazanan.getPenalti() < bilgisayarKazanan.getPenalti())//Eğer kullanıcının kartındaki penaltı özelliği bilgisayarın kartındaki penaltı özelliğinden daha küçükse bu block çalışır
                        return test._bilgisayar;// Kullanıcının kartının özelliği daha küçük olduğu için kazanan bilgisayar olur ve geri döndürürüz
                    else // Eğer özellikler eşit ise bu block çalışır
                        return null; // Kimse kazanamadığı için boş değer döndürürüz
                }
                else if (ozellik == "serbest vuruş")// Eğer bize verilen özellik serbest vuruş ise bu block çalışır
                {
                    if (kullaniciKazanan.getSerbestVurus() > bilgisayarKazanan.getSerbestVurus())//Eğer kullanıcının kartındaki serbest vuruş özelliği bilgisayarın kartındaki serbest vuruş özelliğinden daha büyükse bu block çalışır
                        return test._kullanici;// Kullanıcının kartının özelliği daha büyük olduğu için kazanan kullanıcı olur ve geri döndürürüz
                    else if (kullaniciKazanan.getSerbestVurus() < bilgisayarKazanan.getSerbestVurus())//Eğer kullanıcının kartındaki serbest vuruş özelliği bilgisayarın kartındaki serbest vuruş özelliğinden daha küçükse bu block çalışır
                        return test._bilgisayar;// Kullanıcının kartının özelliği daha küçük olduğu için kazanan bilgisayar olur ve geri döndürürüz
                    else // Eğer özellikler eşit ise bu block çalışır
                        return null;// Kimse kazanamadığı için boş değer döndürürüz
                }
                else // Eğer bize verilen özellik kaleciyle karşı karşıyaysa bu block çalışır
                {
                    if (kullaniciKazanan.getKaleciKarsiKarsiya() > bilgisayarKazanan.getKaleciKarsiKarsiya())//Eğer kullanıcının kartındaki kaleciKarsiKarsiya özelliği bilgisayarın kartındaki kaleciKarsiKarsiya özelliğinden daha büyükse bu block çalışır
                        return test._kullanici;// Kullanıcının kartının özelliği daha büyük olduğu için kazanan kullanıcı olur ve geri döndürürüz
                    else if (kullaniciKazanan.getKaleciKarsiKarsiya() < bilgisayarKazanan.getKaleciKarsiKarsiya())//Eğer kullanıcının kartındaki kaleciKarsiKarsiya özelliği bilgisayarın kartındaki kaleciKarsiKarsiya özelliğinden daha küçükse bu block çalışır
                        return test._bilgisayar;// Kullanıcının kartının özelliği daha küçük olduğu için kazanan bilgisayar olur ve geri döndürürüz
                    else // Eğer özellikler eşit ise bu block çalışır
                        return null;// Kimse kazanamadığı için boş değer döndürürüz
                }
            }
            else // Eğer şuanki tur basketbolcu turuysa bu block çalışır
            {
                // Oynanılan kartları (Sporcu türündeki) basketbolcu türünde tanıtıp değişkenlere atıyoruz
                Basketbolcu kullaniciKazanan = _kullaniciOynananSporcu as Basketbolcu;
                Basketbolcu bilgisayarKazanan = _bilgisayarOynananSporcu as Basketbolcu;

                if (ozellik == "ikilik")// Eğer bize verilen özellik ikilik ise bu block çalışır
                {
                    if (kullaniciKazanan.getIkilik() > bilgisayarKazanan.getIkilik())//Eğer kullanıcının kartındaki ikilik özelliği bilgisayarın kartındaki ikilik özelliğinden daha büyükse bu block çalışır
                        return test._kullanici;// Kullanıcının kartının özelliği daha büyük olduğu için kazanan kullanıcı olur ve geri döndürürüz
                    else if (kullaniciKazanan.getIkilik() < bilgisayarKazanan.getIkilik())//Eğer kullanıcının kartındaki ikilik özelliği bilgisayarın kartındaki ikilik özelliğinden daha küçükse bu block çalışır
                        return test._bilgisayar;// Kullanıcının kartının özelliği daha küçük olduğu için kazanan bilgisayar olur ve geri döndürürüz
                    else// Eğer özellikler eşit ise bu block çalışır
                        return null;// Kimse kazanamadığı için boş değer döndürürüz
                }
                else if (ozellik == "üçlük")// Eğer bize verilen özellik üçlük ise bu block çalışır
                {
                    if (kullaniciKazanan.getUcluk() > bilgisayarKazanan.getUcluk())//Eğer kullanıcının kartındaki üçlük özelliği bilgisayarın kartındaki üçlük özelliğinden daha büyükse bu block çalışır
                        return test._kullanici;// Kullanıcının kartının özelliği daha büyük olduğu için kazanan kullanıcı olur ve geri döndürürüz
                    else if (kullaniciKazanan.getUcluk() < bilgisayarKazanan.getUcluk())//Eğer kullanıcının kartındaki üçlük özelliği bilgisayarın kartındaki üçlük özelliğinden daha küçükse bu block çalışır
                        return test._bilgisayar;// Kullanıcının kartının özelliği daha küçük olduğu için kazanan bilgisayar olur ve geri döndürürüz
                    else// Eğer özellikler eşit ise bu block çalışır
                        return null;// Kimse kazanamadığı için boş değer döndürürüz
                }
                else
                {
                    if (kullaniciKazanan.getSerbestAtis() > bilgisayarKazanan.getSerbestAtis())//Eğer kullanıcının kartındaki serbest atış özelliği bilgisayarın kartındaki serbest atış özelliğinden daha büyükse bu block çalışır
                        return test._kullanici;// Kullanıcının kartının özelliği daha büyük olduğu için kazanan kullanıcı olur ve geri döndürürüz
                    else if (kullaniciKazanan.getSerbestAtis() < bilgisayarKazanan.getSerbestAtis())//Eğer kullanıcının kartındaki serbest atış özelliği bilgisayarın kartındaki serbest atış özelliğinden daha küçükse bu block çalışır
                        return test._bilgisayar;// Kullanıcının kartının özelliği daha küçük olduğu için kazanan bilgisayar olur ve geri döndürürüz
                    else// Eğer özellikler eşit ise bu block çalışır
                        return null;// Kimse kazanamadığı için boş değer döndürürüz
                }
            }
        }

        // Şuanki tura göre (Basketbolcu veya Futbolcu turu) özellik seçip ekrana yazdıran method
        public string pozisyonSec()
        {
            string secilenOzellik = test.poziyonSecici(suankiTur); // Test class'ımızdaki pozisyonSecici() methodumuzu çağırıp değişkene atıyoruz
            lblOzellik.Text = secilenOzellik; // Seçilen özelliği label'ımıza yazdırıyoruz
            return secilenOzellik; // Seçilen özelliği geri döndürüyoruz
        }

        public void sonrakiTuraGec()
        {
            // Tur secici ile sonraki turu seçiyoruz
            suankiTur = test.turSecici(suankiTur);
            turSayisi += 1;

            InitGame();
            kartlariKontrolEt();
            turSayisiniYazdir();
        }

        public void suankiTuruYazdir()
        {
            grbHamle.Text = suankiTur; // Seçilen turu grupbox başlığına yazıyoruz
        }        
    }
}
