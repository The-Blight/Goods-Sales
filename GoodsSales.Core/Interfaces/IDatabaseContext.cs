using System.Data;

namespace GoodsSales.Core.Interfaces;

public interface IDatabaseContext
{
    IDbConnection CreateConnection();
}