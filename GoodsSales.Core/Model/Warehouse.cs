namespace GoodsSales.Core.Model;

public record Warehouse(
    int Id,
    int ProductId,
    int QuantityInStock
);