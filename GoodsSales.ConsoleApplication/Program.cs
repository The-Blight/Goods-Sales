using System;
using GoodsSales.Core.Interfaces;
using GoodsSales.Infrastructure.DatabaseContexts;
using GoodsSales.Infrastructure.Queries;


const string connectionString =
    "Host=localhost;Port=5430;Database=postgres;Username=postgres;Password=1234";


IDatabaseContext context = new PostgresLazyContext(connectionString); 
ProductQuery query = new ProductQuery(context);

var person = query.GetPersonById(2);

Console.WriteLine(person.Id);

