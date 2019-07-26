using System;
using System.Collections.Generic;
using System.Text;

namespace WPos.Domain
{
    public class TradeCode
    {
        public static int GetCode(string trade)
        {
            int code = 0;
            if (nameof(Purchase).ToLabel() == trade) code = 1;
            else if (nameof(Sale).ToLabel() == trade) code = 2;
            else if (nameof(Repair).ToLabel() == trade) code = 3;
            else if (nameof(Layaway).ToLabel() == trade) code = 4;
            else if (nameof(Payment).ToLabel() == trade) code = 5;
            else if (nameof(CallingCard).ToLabel() == trade) code = 6;
            else if (nameof(NewActivation).ToLabel() == trade) code = 7;
            else if (nameof(Unlock).ToLabel() == trade) code = 8;
            else if (nameof(Portin).ToLabel() == trade) code = 9;
            return code;
        }

        public static Type GetType(int code)
        {
            if (code == 1) return typeof(Purchase);
            else if (code == 2) return typeof(Sale);
            else if (code == 3) return typeof(Repair);
            else if (code == 4) return typeof(Layaway);
            else if (code == 5) return typeof(Payment);
            else if (code == 6) return typeof(CallingCard);
            else if (code == 7) return typeof(NewActivation);
            else if (code == 8) return typeof(Unlock);
            else if (code == 9) return typeof(Portin);
            else return null;
        }
    }
}
