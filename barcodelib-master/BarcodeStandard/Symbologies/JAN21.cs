using System;
using System.Collections.Generic;
using System.Text;

namespace BarcodeStandard
{
    public class JAN21
    {
        Random asdfca12a4f = new Random();

        public bool ValidateKey(string asdf42)
        {
            var jaaa54 = asdf42.Substring(0, 4);
            var afia9890 = asdf42;
            var sjfd5656 = TYasdfw78(jaaa54);
            return afia9890 == sjfd5656;
        }

        private string TYasdfw78(string aWAf254)
        {
            var asdf4er783 = jasdfu3445(aWAf254);
            var asdf154 = adffg54(aWAf254, asdf4er783);
            var asdfc2 = was5f4(asdf4er783, asdf154);
            var aecasdf = adre8w745(asdf4er783, asdf154, asdfc2);
            return aWAf254 + "-" + asdf4er783 + "-" + asdf154 + "-" + asdfc2 + "-" + aecasdf;
        }

        private string jasdfu3445(string WErifa45)
        {
            var asdf4er783 = (int.Parse(WErifa45[0].ToString()) * int.Parse(WErifa45[3].ToString())).ToString();
            var aecasdf = (int.Parse(WErifa45[0].ToString()) + int.Parse(WErifa45[1].ToString())).ToString();
            var asdfc2 = (int.Parse(WErifa45[1].ToString()) * int.Parse(WErifa45[2].ToString())).ToString();
            var aecasADF14 = (int.Parse(WErifa45[2].ToString()) + int.Parse(WErifa45[3].ToString())).ToString();
            return asdf4er783[asdf4er783.Length - 1].ToString() + aecasdf[aecasdf.Length - 1].ToString() + asdfc2[asdfc2.Length - 1].ToString() + aecasADF14[aecasADF14.Length - 1].ToString();
        }

        private string adffg54(string WErifa45, string TYAdf212)
        {
            var asdf4er783 = (int.Parse(WErifa45[3].ToString()) + int.Parse(TYAdf212[3].ToString())).ToString();
            var asdf154 = (int.Parse(WErifa45[0].ToString()) * int.Parse(TYAdf212[0].ToString())).ToString();
            var asdfc2 = (int.Parse(WErifa45[1].ToString()) * int.Parse(TYAdf212[2].ToString())).ToString();
            var aecasdf = (int.Parse(WErifa45[2].ToString()) + int.Parse(TYAdf212[1].ToString())).ToString();
            return asdf4er783[asdf4er783.Length - 1].ToString() + asdf154[asdf154.Length - 1].ToString() + asdfc2[asdfc2.Length - 1].ToString() + aecasdf[aecasdf.Length - 1].ToString();
        }

        private string was5f4(string WErifa45, string TYAdf212)
        {
            var asdf4er783 = (int.Parse(WErifa45[3].ToString()) + int.Parse(TYAdf212[3].ToString())).ToString();
            var asdfc2 = (int.Parse(WErifa45[3].ToString()) + int.Parse(TYAdf212[1].ToString())).ToString();
            var aecasdf = (int.Parse(WErifa45[1].ToString()) + int.Parse(TYAdf212[2].ToString())).ToString();
            var asdf154 = (int.Parse(WErifa45[2].ToString()) * int.Parse(TYAdf212[2].ToString())).ToString();
            return asdf4er783[asdf4er783.Length - 1].ToString() + asdfc2[asdfc2.Length - 1].ToString() + aecasdf[aecasdf.Length - 1].ToString() + asdf154[asdf154.Length - 1].ToString();
        }

        private string adre8w745(string WErifa45, string TYAdf212, string asdrWEa4545)
        {
            var asdf4er783 = (int.Parse(WErifa45[3].ToString()) + int.Parse(TYAdf212[3].ToString()) * int.Parse(asdrWEa4545[1].ToString())).ToString();
            var asdf154 = (int.Parse(WErifa45[3].ToString()) + int.Parse(TYAdf212[1].ToString()) * int.Parse(asdrWEa4545[1].ToString())).ToString();
            var aecasdf = (int.Parse(WErifa45[1].ToString()) + int.Parse(TYAdf212[2].ToString()) + int.Parse(asdrWEa4545[0].ToString())).ToString();
            var asdfc2 = (int.Parse(WErifa45[2].ToString()) * int.Parse(TYAdf212[2].ToString()) + int.Parse(asdrWEa4545[3].ToString())).ToString();
            return asdf4er783[asdf4er783.Length - 1].ToString() + asdf154[asdf154.Length - 1].ToString() + aecasdf[aecasdf.Length - 1].ToString() + asdfc2[asdfc2.Length - 1].ToString();
        }
    }
}
