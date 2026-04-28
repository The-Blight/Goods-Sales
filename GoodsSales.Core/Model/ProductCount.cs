namespace GoodsSales.Core.Model;

public record ProductCount
{
    public required string Name { get; init; }
    public required int QuantityInStock { get; init; }


    public override string ToString()
    {
        return $"{Name} {QuantityInStock}"; 
    }
}