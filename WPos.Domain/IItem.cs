namespace WPos.Domain
{
    public interface IItem
    {
        string Code { get;}
        string Name { get; }
        string Brand { get; }
        string Category { get; }
        string Unit { get; }
    }
}