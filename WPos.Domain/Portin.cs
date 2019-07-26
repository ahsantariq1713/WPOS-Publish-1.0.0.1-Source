using System.Collections.Generic;
using System.Text;

namespace WPos.Domain
{
    public class Portin : TransactionableBase
    {
        public Customer Customer { get; set; }
        public Carrier FromCarrier { get; set; }
        public Carrier ToCarrier { get; set; }
        public string SimCardNumber { get; set; }
        public string IMEI { get; set; }
        public string Phone { get; set; }
        public string CCACCNumber { get; set; }
        public string CCPaasword { get; set; }
        public string SSN { get; set; }
        public AirTimePlan AirTime { get; set; }
        public float Rate { get; set; }
        public bool SendPromoMessage { get; set; }
        public ICollection<Policy> Policies { get; set; }
        public override float Amount { get =>  Rate; }
        public override string ClientName { get => Customer?.Name; }
        public override string ClientPhone { get => Customer?.Phone; }

        public override bool HasErrors(out string errors)
        {
            var sb = new StringBuilder();
            Customer.NullCheck("Customer", ref sb);
            FromCarrier.NullCheck("From Carrier", ref sb);
            ToCarrier.NullCheck("From Carrier", ref sb);
            AirTime.NullCheck("Air Time Plan", ref sb);
            FromCarrier.NullCheck("From Carrier", ref sb);
            Total.NullCheck("Bill amount", ref sb);
            errors = sb.ToString();
            return errors.Length > 0;
        }
    }
}