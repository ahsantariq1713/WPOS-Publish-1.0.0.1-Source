using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WirelessPOS
{
    public class Global
    {
        private static Form waitWin = null;

        public static void ShowWait(string message, Form owner = null)
        {
            waitWin = new WaitWin(message);
            if (owner != null)
            {
                waitWin.Show(owner);
            }
            else waitWin.Show();
        } 

        public static void HideWait()
        {
            waitWin?.Close();
            waitWin = null;
        }
    }
}
