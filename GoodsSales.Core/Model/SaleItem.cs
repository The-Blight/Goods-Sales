namespace GoodsSales.Core.Model;

public record SaleItem(
    int SaleId,
    int ProductId,
    decimal PriceAtSale,
    int Quantity
);