using System.Collections.Generic;
using System.Text;

namespace WPos.Domain
{
    public class Unlock : TransactionableBase
    {
        public Customer Customer { get; set; }
        public Device Device { get; set; }
        public string IMEI { get; set; }
        public float Charges { get; set; }
        public override float Amount { get => Charges; }
        public ICollection<Policy> Policies { get; set; }
        public override string ClientName { get => Customer?.Name; }
        public override string ClientPhone { get => Customer?.Phone; }

        public override bool HasErrors(out string errors)
        {
            var sb = new StringBuilder();
            Customer.NullCheck("Customer", ref sb);
            Device.NullCheck("Device", ref sb);
            Total.NullCheck("Bill amount", ref sb);
            errors = sb.ToString();
            return errors.Length > 0;
        }
    }
}