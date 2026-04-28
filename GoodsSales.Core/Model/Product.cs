namespace GoodsSales.Core.Model;

public record Product(
    int Id,
    string Name,
    string Description,
    decimal Price
);