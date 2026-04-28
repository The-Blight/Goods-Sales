using System;
using System.Data;
using GoodsSales.Core.Interfaces;
using Npgsql;

namespace GoodsSales.Infrastructure.DatabaseContexts;

public class PostgresContext : IDatabaseContext
{
    private readonly string _connectionString;

    public PostgresContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection CreateConnection() => new NpgsqlConnection(_connectionString);
    
}