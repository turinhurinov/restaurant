using Restaurant.Business.Services.Abstract;
using Restaurant.Data.Repositories.Abstract;
using Restaurant.Model;
using System;
using System.Collections.Generic;

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
            //TODO: Rezervasyona uygun tabloları süz
            //TODO: En uygunluk sırasına göre listele
            //TODO: Uygun tablo listesini döndür.
            return new List<Table>();
        }
    }
}