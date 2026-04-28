using System;
using System.Data;
using GoodsSales.Infrastructure.DatabaseContexts;
using GoodsSales.Infrastructure.Queries;


const string connectionString =
    "Host=localhost;Port=5430;Database=postgres;Username=postgres;Password=1234";


try
{
    var context = new PostgresLazyContext(connectionString);
    var query = new PostgresProductQuery<IDbConnection>(context);
    var person = query.GetPersonById(1);
    var total = query.GetTotalSales();
    var productCounts = query.GetProductsCount(); 

    Console.WriteLine(person.ToString());
    total.ForEach(x => Console.WriteLine(x.ToString())); 
    productCounts.ForEach(p => Console.WriteLine(p.ToString()));
}
catch (Exception e)
{
    Console.WriteLine($"Исключение: {e.Message} ");
}