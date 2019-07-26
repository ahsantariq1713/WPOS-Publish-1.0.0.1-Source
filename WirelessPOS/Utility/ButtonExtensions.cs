using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WirelessPOS.Properties;

namespace WirelessPOS {
   public static  class ButtonExtensions {
        public static bool IsBusy(this Button button) {

            return button.BackColor == Color.White;
        }

        public static void MarkBusy(this Button button, out Image image, out Color color) {
            color = button.BackColor;
            image = button.Image;

            button.BackColor = Color.White;
            button.Image = Resources.wait;

        }

        public static void MarkFree(this Button button,Image image, Color color) {
            button.BackColor = color;
            button.Image = image;
        }
    }
}
