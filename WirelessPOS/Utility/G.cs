using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WirelessPOS
{
    public static class G
    {
       public static int W(int percent)
        {
            int width = int.TryParse(Properties.Settings.Default.ReceiptWidth, out int r) ? r : 100;
            width -= 10;
            return (int)(width * percent / 100);
        }

        public static string UDotted()
        {
            int width = int.TryParse(Properties.Settings.Default.ReceiptWidth, out int r) ? r : 100;
            width -= 10;
            var sb = new StringBuilder();
            for (int i = 0; i < width; i++)
            {
                sb.Append("-");
            }
            return sb.ToString();
        }

        public static string ULine()
        {
            int width = int.TryParse(Properties.Settings.Default.ReceiptWidth, out int r) ? r : 100;
            width -= 10;
            var sb = new StringBuilder();
            for (int i = 0; i < width; i++)
            {
                sb.Append("_");
            }
            return sb.ToString();
        }

        public static string RULine()
        {
            int width = int.TryParse(Properties.Settings.Default.ReportWidth, out int r) ? r : 100;
            width -= 10;
            var sb = new StringBuilder();
            for (int i = 0; i < width; i++)
            {
                sb.Append("_");
            }
            return sb.ToString();
        }

        public static int RW(int percent)
        {
            int width = int.TryParse(Properties.Settings.Default.ReportWidth, out int r) ? r : 100;
            width -= 10;
            return (int)(width * percent / 100);
        }

        public static string RUDotted()
        {
            int width = int.TryParse(Properties.Settings.Default.ReportWidth, out int r) ? r : 100;
            width -= 10;
            var sb = new StringBuilder();
            for (int i = 0; i < width; i++)
            {
                sb.Append("-");
            }
            return sb.ToString();
        }
    }
}
