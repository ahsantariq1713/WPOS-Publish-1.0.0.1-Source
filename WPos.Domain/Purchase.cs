using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPos.Domain
{
    public class Purchase : TransactionableBase
    {
        public int StockUpdated { get;private set; }
        public bool IsStockUpdateable { get => StockUpdated == 0; }
        public Supplier Supplier { get; set; }
        public ICollection<PurchaseItem> PurchaseItems { get; set; }
        public override float Amount { get => PurchaseItems?.Sum(x => x.Amount)??0; }

        public override string ClientName { get => Supplier?.Name; }
        public override string ClientPhone { get => Supplier?.Phone; }

        public void SetUpdateStockFlag()
        {
            StockUpdated = 1;
        }
    }

    public class PurchaseItem : BaseEntity, IStockItem
    {
        public string Serial { get; set; }
        public DateTime? Batch { get => CreatedAt; }
        public float SalePrice { get; set; }
        public float PurchasePrice { get; set; }
        public float Quantity { get; set; }
        public float Amount { get => PurchasePrice * Quantity; }
        public string Notes { get; set; }

        public Item Item { get; set; }
        public string Code { get => Item?.Code; }
        public string Name { get => Item?.Name; }
        public string Brand  { get => Item?.Brand; }
        public string Category { get => Item?.Category; }
        public string Unit { get => Item?.Unit; }

        public override bool HasErrors(out string errors)
        {
            errors = null;
            return false;
        }
    }

    public class Transaction : BaseEntity
    {
        public DateTime Date { get => CreatedAt; }
        public string TradeId { get; set; }
        public string TrxId { get; set; }
        public float Amount { get; set; }
        public float Cash { get; set; }
        public float Return { get => Cash - Amount; }
        public TransactionType TransactionType { get; set; }
        public Transaction()
        {
            TrxId = DateTime.Now.ToFileTime().ToString();
        }

        public Transaction(TransactionType transactionType) 
        {
            TransactionType = transactionType;
            TrxId = DateTime.Now.ToFileTime().ToString();
        }

        public override bool HasErrors(out string errors)
        {
            errors = null;
            return false;
        }
     
    }

    public enum TransactionType
    {
        Cashin = 0,
        Cashout = 1,
        Refund = 2
    }
    public interface ITransactionable
    {
        string ClientName { get; }
        string ClientPhone { get; }
        ICollection<Transaction> Transactions { get; set; }

        DateTime Date { get; }
        float Total { get; }
        float Paid { get; }
        float Due { get; }
        string TradeId { get; }
        string TradeName { get; }
        string Notes { get; set; }
        float Refunded { get; }
        float RefundAmount { get; }
        float Refund { get; set; }
        string Status { get; }
    }
}
