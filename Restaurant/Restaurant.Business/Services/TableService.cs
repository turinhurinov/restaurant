using Restaurant.Business.Abstract;
using Restaurant.Data.Abstract;
using Restaurant.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.Business.Services
{

    public class TableService : ITableService
    {

        #region setup

        readonly ITableRepository tableRepository;

        public TableService(ITableRepository tableRepository)
        {
            this.tableRepository = tableRepository;
        } 

        #endregion

        public List<Table> GetAvailableTables(DateTime reservationDate, int numberOfGuests)
        {
            var tables = tableRepository.GetAllTables();
            var availableTables = tables.Where(x => x.Capacity >= numberOfGuests).ToList();
            return availableTables;
        }
    }
}