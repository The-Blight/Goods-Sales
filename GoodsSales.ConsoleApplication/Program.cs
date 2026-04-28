using System;
using System.Data;
using GoodsSales.Core.Interfaces;
using GoodsSales.Infrastructure.DatabaseContexts;
using GoodsSales.Infrastructure.Queries;
using Npgsql;


const string connectionString =
    "Host=localhost;Port=5430;Database=postgres;Username=postgres;Password=1234";


var context = new PostgresLazyContext(connectionString);
var query = new PostgresProductQuery<IDbConnection>(context);
var person = query.GetPersonById(2); 

Console.WriteLine(person.ToString());

