using System;
using System.Collections.Generic;
using System.Data;
using GoodsSales.Core.Interfaces;
using GoodsSales.Core.Model;
using GoodsSales.Infrastructure.DatabaseContexts;
using Npgsql;

namespace GoodsSales.Infrastructure.Queries;

public class PostgresProductQuery<TConnection>(IDatabaseContext<NpgsqlConnection> databaseContext)
    where TConnection : IDbConnection
{
    private readonly IDatabaseContext<NpgsqlConnection> _databaseContext = databaseContext;

    public Person? GetPersonById(int id)
    {
        var connection = _databaseContext.CreateConnection();

        connection.Open();
        using var command = new NpgsqlCommand
        (
            """
            SELECT
            p.id,
            p.first_name,
            p.patronymic,
            p.last_name,
            p.date_of_birth
            FROM table_persons as p
            WHERE p.id = @id; 
            """,
            connection
        );

        using var reader = command.ExecuteReader();

        if (!reader.Read()) return null;

        return new Person()
        {
            Id = reader.GetInt32("id"),
            FirstName = reader.GetString("first_name"),
            Patronymic = reader.GetString("patronymic"),
            LastName = reader.GetString("last_name"),
            DateOfBirth = DateOnly.FromDateTime(reader.GetDateTime("date_of_birth"))
        };
    }

    public TotalSalesPerPerson GetTotalSales()
    {
        throw new System.NotImplementedException();
    }

    public IEnumerable<ProductCount> GetProductsCount()
    {
        throw new System.NotImplementedException();
    }
}