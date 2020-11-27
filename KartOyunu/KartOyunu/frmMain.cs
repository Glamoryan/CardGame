using KartOyunu.UserControls;
using KartOyunu.UserControls.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KartOyunu
{
    // Oyunun çalışacağı Main Formu
    public partial class frmMain : Form
    {
        public anaMenu _mainmenuControl;        

        public frmMain()
        {
            InitializeComponent();            
        }        

        //Formun load sonrası çalışacak methodu
        private void frmMain_Load(object sender, EventArgs e)
        {
            anamenuyuGetir(); // form yüklendikten sonra anamenüyü çağırıyoruz
        }

        /// <summary>
        /// Anamenü instance'ı oluşturup panele ekler
        /// </summary>
        public void anamenuyuGetir()
        {
            if (_mainmenuControl == null)
            {
                _mainmenuControl = new anaMenu();
                PanelHelper.panelTemizle(pnlMain);
                pnlMain.Controls.Add(_mainmenuControl);
            }
        }
    }
}
