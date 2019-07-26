using System;
using System.Collections.Generic;
using System.Text;

namespace WPos.Domain
{
   public static  class Extensions
    {
        public static string ToUPCA(this string id,string prefix)
        {
            var sb = new StringBuilder();
            sb.Append(0);
            sb.Append(prefix);
            for (int i = 0; i < 5 - id.Length; i++)
            {
                sb.Append("0");
            }
            sb.Append(id);
            return sb.ToString();
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

        public static bool IsNull(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

        public static bool IsNull(this float obj)
        {
            return obj == 0;
        }


        public static void NullCheck(this string str, string parameterName,ref StringBuilder sb)
        {
            if (str.IsNull()) sb.AppendLine(parameterName + " is required.");
        }

        public static void NullCheck(this object obj, string parameterName, ref StringBuilder sb)
        {
            if (obj.IsNull()) sb.AppendLine(parameterName + " is required.");
        }

        public static void NullCheck(this float obj, string parameterName, ref StringBuilder sb)
        {
            if (obj.IsNull()) sb.AppendLine(parameterName + " cannot be zero.");
        }

    }
}
