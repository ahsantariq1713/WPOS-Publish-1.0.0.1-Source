using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPos.Domain
{
    public abstract class TransactionableBase : BaseEntity, ITransactionable
    {
        public string Notes { get; set; }
        public abstract float Amount { get; }
        public float Discount { get; set; }
        public float DiscountAmount { get => Amount * Discount / 100; }
        public float Subtotal { get => Amount - DiscountAmount; }
        public float Tax { get; set; }
        public float TaxAmount { get => Subtotal * Tax / 100; }
        public string Status {
            get
            {
                if (TradeName == nameof(Repair).ToLabel())
                {
                    return (this as Repair).RepairStatus?.Status.ToString();
                }
                else
                {
                    return Due == 0 ? "Closed" : "Pending";
                }

            }
        }
        public ICollection<Transaction> Transactions { get; set; }
        public DateTime Date { get => CreatedAt; }
        public float Total { get => Subtotal + TaxAmount; }
        public float Paid { get => (Transactions?.ToList().FindAll(x => x.TransactionType == TransactionType.Cashin || x.TransactionType == TransactionType.Cashout)?.Sum(x => x.Amount) ?? 0) - Refunded; }
        public float Refunded { get => Transactions?.ToList().FindAll(x => x.TransactionType == TransactionType.Refund)?.Sum(x => x.Amount) ?? 0; }
        public string TradeName { get => GetType().Name.ToLabel(); }
        public string TradeId
        {
            get
            {
                var prefix = Date.Year.ToString() + TradeCode.GetCode(TradeName);
                return Id.ToString().ToUPCA(prefix);
            }
        }
        public float Due { get => Total - Paid; }
        public abstract string ClientName { get; }
        public abstract string ClientPhone { get; }
        public float Refund { get; set; } = 100;
        public float RefundAmount { get => Paid * (Refund == 0 ? 100 : Refund) / 100; }
        public override bool HasErrors(out string errors)
        {
            var sb = new StringBuilder();
            ClientName.NullCheck("Trade Client ", ref sb);
            Total.NullCheck("Bill amount ", ref sb);
            errors = sb.ToString();
            return errors.Length > 0;
        }
    }
}
