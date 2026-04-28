using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Pipelines;
using System.Linq;
using GoodsSales.Core.Interfaces;
using GoodsSales.Core.Model;
using GoodsSales.Infrastructure.DatabaseContexts;
using Npgsql;

namespace GoodsSales.Infrastructure.Queries;

public class PostgresProductQuery<TConnection>(IDatabaseContext<NpgsqlConnection> databaseContext) : IProductQueries
    where TConnection : IDbConnection
{
    private readonly IDatabaseContext<NpgsqlConnection> _databaseContext = databaseContext;

    public Person? GetPersonById(int id)
    {
        using var connection = _databaseContext.CreateConnection();
        connection.Open();

        const string sql =
            """
            SELECT
            p.id,
            p.first_name,
            p.patronymic,
            p.last_name,
            p.date_of_birth,
            p.is_deleted
            FROM table_persons as p
            WHERE p.id = @id; 
            """;

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("id", id);

        using var reader = command.ExecuteReader();

        if (!reader.Read()) return null;

        return MapToPerson(reader);
    }

    public List<TotalSalesPerPerson>? GetTotalSales()
    {
        using var connection = _databaseContext.CreateConnection();
        connection.Open();

        const string sql = """
                           SELECT
                               p.id,
                               p.first_name,
                               p.patronymic,
                               p.last_name,
                               p.date_of_birth,
                               p.is_deleted,
                               v.sale_id,
                               v.total_item,
                               v.total_price
                               
                           FROM table_persons as p
                           JOIN view_total_sales_per_person as v ON 
                           p.first_name = v.first_name AND
                           p.patronymic IS NOT  DISTINCT FROM v.patronymic AND
                           p.last_name = v.last_name
                           """;

        using var command = new NpgsqlCommand(sql, connection);
        using var reader = command.ExecuteReader();

        List<TotalSalesPerPerson>? totalSalesPerPersons = [];

        while (reader.Read())
        {
            var totalSale = MapToTotalSalesPerPerson(reader);
            totalSalesPerPersons.Add(totalSale);
        }


        return totalSalesPerPersons;
    }

    public List<ProductCount>? GetProductsCount()
    {
        using var connection = _databaseContext.CreateConnection();
        connection.Open();

        const string sql = """
                           SELECT 
                               view_product_counts.name,
                               view_product_counts.quantity_in_stock
                           FROM view_product_counts
                           """;

        using var command = new NpgsqlCommand(sql, connection);
        var reader = command.ExecuteReader();

        List<ProductCount> productCounts = [];

        while (reader.Read())
        {
            var productCount = MapToProductCount(reader);

            productCounts.Add(productCount);
        }

        return productCounts;
    }


    private static Person MapToPerson(NpgsqlDataReader reader)
    {
        return new Person
        {
            Id = reader.GetInt32(reader.GetOrdinal("id")),
            FirstName = reader.GetString(reader.GetOrdinal("first_name")),
            Patronymic = reader.IsDBNull(reader.GetOrdinal("patronymic"))
                ? null
                : reader.GetString(reader.GetOrdinal("patronymic")),
            LastName = reader.GetString(reader.GetOrdinal("last_name")),
            DateOfBirth = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("date_of_birth"))),
            IsDeleted = reader.GetBoolean(reader.GetOrdinal("is_deleted"))
        };
    }

    private static TotalSalesPerPerson MapToTotalSalesPerPerson(NpgsqlDataReader reader)
    {
        return new TotalSalesPerPerson
        {
            SaleId = reader.GetInt32(reader.GetOrdinal("sale_id")),
            Person = MapToPerson(reader),
            TotalItem = reader.GetInt32(reader.GetOrdinal("total_item")),
            TotalPrice = reader.GetInt64(reader.GetOrdinal("total_price"))
        };
    }


    private static ProductCount MapToProductCount(NpgsqlDataReader reader)
    {
        return new ProductCount
        {
            Name = reader.GetString(reader.GetOrdinal("name")),
            QuantityInStock = reader.GetInt32(reader.GetOrdinal("quantity_in_stock"))
        };
    }
}