using System.Collections.Generic;
using System.Text;

namespace WPos.Domain
{
    public class CallingCard : TransactionableBase
    {
        public Customer Customer { get; set; }
        public string LocalPhone { get; set; }
        public string CCode { get; set; }
        public string Phone { get; set; }
        public Company Company { get; set; }
        public float Price { get; set; }
        public ICollection<Policy> Policies { get; set; }
        public override float Amount { get => Price; }
        public override string ClientName { get => Customer?.Name; }
        public override string ClientPhone { get => Customer?.Phone; }

        public override bool HasErrors(out string errors)
        {
            var sb = new StringBuilder();
            Customer.NullCheck("Customer", ref sb);
            Company.NullCheck("Company", ref sb);
            Total.NullCheck("Bill amount", ref sb);
            errors = sb.ToString();
            return errors.Length > 0;
        }
    }

    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public override bool HasErrors(out string errors)
        {
            errors = null;
            return false;
        }
    }
}