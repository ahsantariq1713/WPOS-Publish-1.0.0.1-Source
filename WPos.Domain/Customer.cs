using System;
using System.Collections.Generic;
using System.Text;

namespace WPos.Domain
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public float SendPromoMessage { get; set; }
        public ICollection<Sale> Sales { get; set; }
        public ICollection<Repair> Repairs { get; set; }
        public ICollection<Unlock> Unlocks { get; set; }
        public ICollection<Layaway> Layaway { get; set; }
        public ICollection<CallingCard> CallingCards { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Portin> Portins { get; set; }
        public ICollection<NewActivation> NewActivations { get; set; }

        public float Spending { get; }
        public float Paid { get; set; }

        public override bool HasErrors(out string errors)
        {
            var sb = new StringBuilder();
            Phone.NullCheck("Phone", ref sb);
            errors = sb.ToString();
            return errors.Length > 0;
        }
    }
}
