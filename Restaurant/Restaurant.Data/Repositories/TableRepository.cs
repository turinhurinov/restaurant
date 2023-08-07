using Restaurant.Data.Abstract;
using Restaurant.Model;
using System.Collections.Generic;

namespace Restaurant.Data.Repositories
{
    public class TableRepository : ITableRepository
    {
        public List<Table> GetAllTables()
        {
            return new List<Table> { 
                new Table { Number = 1, Capacity = 4 },
                new Table { Number = 2, Capacity = 4 },
                new Table { Number = 3, Capacity = 2 },
                new Table { Number = 4, Capacity = 2 }
            };
        }
    }
}
