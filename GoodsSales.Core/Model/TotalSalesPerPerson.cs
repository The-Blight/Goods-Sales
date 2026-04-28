namespace GoodsSales.Core.Model;

public record TotalSalesPerPerson
{
    public required int SaleId { get; init; }
    public required Person Person { get; init; }
    public decimal TotalPrice { get; init; }
    public int TotalItem { get; init; }


    public override string ToString()
    {
        return $"{Person.ToString()} {TotalPrice} {TotalItem}";
    }
}