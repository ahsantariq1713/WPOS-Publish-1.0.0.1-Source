using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPos.Domain
{
    public class Sale : TransactionableBase 
    {
        public Customer Customer { get; set; }
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

    public class SaleItem : BaseEntity, IStockItem
    {
        public StockItem StockItem { get; set; }

        public float Discount { get; set; }
        public float Amount { get => SalePrice  * Quantity; }

        public string Serial => StockItem?.Serial;

        public DateTime? Batch => StockItem?.Batch;

        public float SalePrice { get; set; }
        public float PurchasePrice => StockItem?.PurchasePrice ?? 0;

        public float Quantity { get; set; }
        public float Stock => StockItem.Quantity;
        public string Code { get => StockItem?.Code; }
        public string Name { get => StockItem?.Name; }
        public string Brand { get => StockItem?.Brand; }
        public string Category { get => StockItem?.Category; }
        public string Unit { get => StockItem?.Unit; }

        public override bool HasErrors(out string errors)
        {
            errors = null;
            return false;
        }
    }
}
