using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPos.Domain
{
    public class Repair : TransactionableBase
    {
        public Customer Customer { get; set; }
        public RepairStatus RepairStatus { get; set; }
        public Device RepairDevice { get; set; }
        public string IMEI { get; set; }
        public string Serial { get; set; }
        public string Password { get; set; }
        public string Pattern { get; set; }
        public bool IsPhoneCamOn { get; set; }
        public bool IsPhysicalDamadge { get; set; }
        public bool IsWaterDamadge { get; set; }
        public bool WithCharger { get; set; }
        public bool WithMemoryCard { get; set; }
        public DateTime DueDate { get; set; }
        public ICollection<Policy> Policies { get; set; }
        public override string ClientName { get => Customer?.Name; }
        public override string ClientPhone { get => Customer?.Phone; }
        public float DignosisFee { get; set; }
        public float RepairFee { get; set; }
        public ICollection<SaleItem> SaleItems { get; set; }
        public override float Amount
        {
            get
            {
                var sale = SaleItems?.Sum(x => x.Amount) ?? 0;
                return sale + DignosisFee + RepairFee;
            }
        }

        public override bool HasErrors(out string errors)
        {
            var sb = new StringBuilder();
            Customer.NullCheck("Customer", ref sb);
            RepairDevice.NullCheck("Repair Device", ref sb);
            RepairStatus.NullCheck("Repair Status", ref sb);
           // Total.NullCheck("Bill amount", ref sb);
            errors = sb.ToString();
            return errors.Length > 0;
        }
    }

    public class RepairStatus : BaseEntity
    {
        public string Status { get; set; }
        public override bool HasErrors(out string errors)
        {
            errors = null;
            return false;

        }
    }

    public class Device : BaseEntity
    {
        public string Name { get; set; }
        public override bool HasErrors(out string errors)
        {
            errors = null;
            return false;
        }
    }
}