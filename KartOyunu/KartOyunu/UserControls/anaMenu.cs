using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KartOyunu.UserControls.Utilities;

namespace KartOyunu.UserControls
{
    // Sadece anamenüyü içeren UserControl Class'ı
    public partial class anaMenu : UserControl
    {
        public anaOyun _anaOyun;
        private Panel anaPanel;
        public anaMenu()
        {
            InitializeComponent();            
        }

        // Anamenü load methodu
        private void anaMenu_Load(object sender, EventArgs e)
        {
            anaPanel = this.Parent as Panel;  // Bu userControl'ün içinde bulunduğu paneli (pnlMain) "this" ile panel olarak seçtip atadık
        }

        // Çıkış butonu tıklanma methodu
        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit(); //Uygulamadan çıkış
        }

        // Başlat butonu tıklanma methodu
        private void btnBaslat_Click(object sender, EventArgs e)
        {                        
            if(_anaOyun == null)
            {
                PanelHelper.panelTemizle(anaPanel); 
                _anaOyun = new anaOyun();
                anaPanel.Controls.Add(_anaOyun);
            }
        }        
    }
}
