using System.Data;

namespace GoodsSales.Core.Interfaces;

public interface IDatabaseContext<out TConnection>
{
    TConnection CreateConnection();
}