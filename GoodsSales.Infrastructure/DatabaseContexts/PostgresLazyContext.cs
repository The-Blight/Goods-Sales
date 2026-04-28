using System;
using System.Data;
using GoodsSales.Core.Interfaces;
using Npgsql;

namespace GoodsSales.Infrastructure.DatabaseContexts;

public class PostgresLazyContext(string connectionString) : IDatabaseContext<NpgsqlConnection>
{
    private readonly Lazy<PostgresContext> _lazyPostgres = new(() => new PostgresContext(connectionString));

    public NpgsqlConnection CreateConnection() => _lazyPostgres.Value.CreateConnection();
    
}