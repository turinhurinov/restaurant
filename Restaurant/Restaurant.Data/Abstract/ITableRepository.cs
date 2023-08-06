using Restaurant.Model;
using System.Collections.Generic;

namespace Restaurant.Data.Repositories.Abstract
{
    public interface ITableRepository
    {
        List<Table> GetAllTables();
    }
}
