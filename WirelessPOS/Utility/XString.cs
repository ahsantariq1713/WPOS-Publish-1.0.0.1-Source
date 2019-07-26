using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WirelessPOS
{
    public static class XString
    {

        public static string RemovePhoneFormat(this string str)
        {
            return str.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "").Trim();
        }

        public static string ToCurrency(this string str)
        {
            return string.Format("{0:$0,0.00}", float.TryParse(str.ToFloatString(),out float r)?r:0);
        }

        public static string ToCurrency(this float @float)
        {
            return string.Format("{0:$0,0.00}", @float);
        }

        public static string ToFloatString(this string str)
        {
            return str.Replace("$", "").Replace(",", "");
        }
        public static string ToLabel(this string str)
        {
            if (str.Length <= 0) return string.Empty;

            var sb = new StringBuilder();
            str.Replace(str[0], char.ToUpper(str[0]));
            foreach (var c in str)
            {
                if (char.IsUpper(c))
                {
                    sb.Append(" " + c.ToString());
                }
                else
                {
                    sb.Append(c.ToString());
                }
            }

            return sb.ToString().Trim();
        }

        public static bool Equal(string one, string other, bool ignoreCase = true)
        {
            if (string.IsNullOrWhiteSpace(one) || string.IsNullOrWhiteSpace(other)) return false;

            if (ignoreCase) return one.Trim().ToLower() == other.Trim().ToLower();
            else return one.Trim() == other.Trim();
        }

        public static bool Contains(string one, string other, bool ignoreCase = true)
        {
            if (string.IsNullOrWhiteSpace(one) || string.IsNullOrWhiteSpace(other)) return false;

            if (ignoreCase) return one.Trim().ToLower().Contains(other.Trim().ToLower());
            else return one.Trim().Contains(other.Trim());
        }
    }
}
