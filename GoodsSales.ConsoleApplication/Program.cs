using System;
using System.Data;
using System.Text;
using GoodsSales.ConsoleApplication;
using GoodsSales.Infrastructure.DatabaseContexts;
using GoodsSales.Infrastructure.Queries;


const string connectionString =
    "Host=localhost;Port=5430;Database=postgres;Username=postgres;Password=1234";
Console.OutputEncoding = Encoding.UTF8;


var view = new ConsoleView();
var context = new PostgresLazyContext(connectionString);
var query = new PostgresProductQuery<IDbConnection>(context);
var controller = new Controller(query, view); 

controller.Run();