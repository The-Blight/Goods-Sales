using System.Collections.Generic;
using GoodsSales.Core.Model;

namespace GoodsSales.Core.Interfaces;

public interface IProductQueries
{
    Person? GetPersonById(int id);
    List<TotalSalesPerPerson>? GetTotalSales();
    List<ProductCount>? GetProductsCount();
}