namespace GoodsSales.Core.Model;

public record TotalSalesPerPerson(
    Person Person,
    decimal TotalPrice,
    int TotalItem
);