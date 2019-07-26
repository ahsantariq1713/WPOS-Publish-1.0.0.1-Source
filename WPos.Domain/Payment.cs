using System.Collections.Generic;
using System.Text;

namespace WPos.Domain
{
    public class Payment : TransactionableBase
    {
        public Customer Customer { get; set; }
        public string Phone { get; set; }
        public Carrier Carrier { get; set; }
        public Company Company { get; set; }
        public MonthlyPlan MonthlyPlan { get; set; }
        public float Rate { get; set; }
        public bool SendPromoMessage { get; set; }
        public override float Amount { get => Rate; }
        public ICollection<Policy> Policies { get; set; }
        public override string ClientName { get => Customer?.Name; }
        public override string ClientPhone { get => Customer?.Phone; }

        public override bool HasErrors(out string errors)
        {
            var sb = new StringBuilder();
            Company.NullCheck("Company", ref sb);
            Carrier.NullCheck("Carrier", ref sb);
            MonthlyPlan.NullCheck("MonthlyPlan", ref sb);
            Customer.NullCheck("Customer", ref sb);
            Total.NullCheck("Bill amount", ref sb);
            errors = sb.ToString();
            return errors.Length > 0;
        }
    }

    public class MonthlyPlan : BaseEntity
    {
        public string Name { get; set; }
        public override bool HasErrors(out string errors)
        {
            
            errors = null;
            return false;
        }
    }
}