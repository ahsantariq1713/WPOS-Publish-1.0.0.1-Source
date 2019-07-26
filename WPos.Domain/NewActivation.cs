using System.Collections.Generic;
using System.Text;

namespace WPos.Domain
{
    public class NewActivation : TransactionableBase
    {
        public Customer Customer { get; set; }
        public string FullName { get; set; }
        public string SimCardNumber { get; set; }
        public string IMEI { get; set; }
        public string Phone { get; set; }
        public Carrier Carrier { get; set; }
        public AirTimePlan AirTime { get; set; }
        public float Rate { get; set; }
        public bool SendPromoMessage { get; set; }
        public ICollection<Policy> Policies { get; set; }
        public override float Amount { get => Rate; }
        public override string ClientName { get => Customer?.Name; }
        public override string ClientPhone { get => Customer?.Phone; }

        public override bool HasErrors(out string errors)
        {
            var sb = new StringBuilder();
            Customer.NullCheck("Customer", ref sb);
            Carrier.NullCheck("Carrier", ref sb);
            AirTime.NullCheck("Air Time Plan", ref sb);
            Total.NullCheck("Bill amount", ref sb);
            errors = sb.ToString();
            return errors.Length > 0;
        }
    }

    public class AirTimePlan : BaseEntity
    {

        public string Name { get; set; }

        public override bool HasErrors(out string errors)
        {
            errors = null;
            return false;
        }
    }

    public class Carrier : BaseEntity
    {
        public string Name { get; set; }
        public override bool HasErrors(out string errors)
        {
            errors = null;
            return false;
        }
    }
}