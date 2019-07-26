using System;
using System.Collections.Generic;
using System.Text;

namespace WPos.Domain
{
    public class StockItem : BaseEntity, IStockItem
    {
        public PurchaseItem PurchaseItem { get; set; }

        public string Serial => PurchaseItem?.Serial;

        public DateTime? Batch => PurchaseItem?.Batch;

        public float SalePrice { get; set; }

        public float PurchasePrice => PurchaseItem?.PurchasePrice ?? 0;

        public float Quantity { get; set; }

        public string Code => PurchaseItem?.Code;

        public string Name => PurchaseItem?.Name;

        public string Brand => PurchaseItem?.Brand;

        public string Category => PurchaseItem?.Category;

        public string Unit => PurchaseItem?.Unit;

        public float Value { get=> Quantity * PurchasePrice; }

        public void Sold(float quantity)
        {
            Quantity -= quantity;
        }

        public void Restock(float quantity)
        {
            Quantity += quantity;
        }

        public override bool HasErrors(out string errors)
        {
            errors = null;
            return false;
        }
    }
}
