using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WirelessPOS
{
    public class Security
    {
        public  static string GetSHA1(string input)
        {
            byte[] data = Encoding.UTF8.GetBytes(input);
            using (SHA512 shaM = new SHA512Managed())
            {
                byte[] result = shaM.ComputeHash(data);
                return Convert.ToBase64String(result);
            }
        }
    }
}
