using BarcodeStandard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WirelessPOS
{
    public class Validator
    {
       
        public bool ValidateLicense()
        {
            var key = Properties.Settings.Default.Key;
            if (string.IsNullOrWhiteSpace(key))
            {
                Message.Warning("Software is not activated. Purchase a key and activate to continue using the software.");
                return false;
            }
            else
            {
                JAN21 jAN21 = new JAN21();
                if (!jAN21.ValidateKey(key))
                {
                    Message.Warning("Your license key is not valid. Purchase a new key to continue using the software.");

                    return false;
                }
                else
                {
                    return true;
                }
            }


           
        }
    }


   
}
