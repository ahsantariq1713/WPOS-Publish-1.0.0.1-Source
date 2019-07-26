namespace WPos.Domain
{
    public interface IStockItem : IItem
    {
        string Serial { get;}
        System.DateTime? Batch { get; }
        float SalePrice { get;}
        float PurchasePrice { get; }
        float Quantity { get; set; }
    }
}