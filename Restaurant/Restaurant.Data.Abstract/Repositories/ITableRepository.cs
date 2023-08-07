using Restaurant.Model;
using System.Collections.Generic;

namespace Restaurant.Data.Abstract
{
    public interface ITableRepository
    {
        List<Table> GetAllTables();
    }
}
