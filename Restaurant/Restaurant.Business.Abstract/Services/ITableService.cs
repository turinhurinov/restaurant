using Restaurant.Model;
using System;
using System.Collections.Generic;

namespace Restaurant.Business.Abstract
{
    public interface ITableService
    {
        List<Table> GetAvailableTables(DateTime reservationDate, int numberOfGuests);
    }
}