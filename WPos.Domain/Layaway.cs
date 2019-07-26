using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPos.Domain
{
    public class Layaway : TransactionableBase
    {
        public Customer Customer { get; set; }
        public int DaysToHold { get; set; }
        public int DaysLeft  { get => DaysToHold -  (int)(DateTime.Now - Date).TotalDays ; }
        public ICollection<Policy> Policies { get; set; }
        public ICollection<SaleItem> SaleItems { get; set; }
        public override float Amount { get => SaleItems?.Sum(x => x.Amount) ?? 0; }
        public override string ClientName { get => Customer?.Name; }
        public override string ClientPhone { get => Customer?.Phone; }

        public override bool HasErrors(out string errors)
        {
            var sb = new StringBuilder();
            Customer.NullCheck("Customer", ref sb);
            Total.NullCheck("Bill amount", ref sb);
            errors = sb.ToString();
            return errors.Length > 0;
        }

    }
}