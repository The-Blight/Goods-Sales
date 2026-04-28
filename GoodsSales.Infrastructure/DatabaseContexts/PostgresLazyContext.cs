using System;
using System.Data;
using GoodsSales.Core.Interfaces;

namespace GoodsSales.Infrastructure.DatabaseContexts;

public class PostgresLazyContext(string connectionString) : IDatabaseContext
{
    private readonly Lazy<PostgresContext> _lazyPostgres = new(() => new PostgresContext(connectionString));

    public IDbConnection CreateConnection() => _lazyPostgres.Value.CreateConnection();
}