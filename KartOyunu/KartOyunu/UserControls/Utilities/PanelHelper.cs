using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KartOyunu.UserControls.Utilities
{
    // Panellerimizi kontrol eden Class
    public static class PanelHelper
    {
        private static string isaret = "?";

        /// <summary>
        /// Panel içindeki tüm kontrolleri temizler
        /// </summary>
        /// <param name="panel">Temizlenmek istenen panel</param>
        public static void panelTemizle(Panel panel)
        {
            panel.Controls.Clear();
        }

        /// <summary>
        /// Verilen panelin ortasına set edilmiş string'imizi label'a atıyarak set eder.
        /// </summary>
        /// <param name="panel">Thumnail yazdırılmak istenen panel</param>
        public static void panelThumbnailYazdir(Panel panel)
        {
            Label isaretimiz = new Label();
            isaretimiz.Text = isaret;
            isaretimiz.Font = new Font("Arial", 14, FontStyle.Bold);
            panel.Controls.Add(isaretimiz);
            isaretimiz.Location = new Point(90, 79);
        }
    }
}
