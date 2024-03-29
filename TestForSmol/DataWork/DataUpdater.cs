﻿using System;
using System.Globalization;
using TestForSmol.Models;

namespace TestForSmol.DataWork
{
    public static class DataUpdater
    {
        public static PurchaseOrder DateUpdate(PurchaseOrder order)
        {
            if (order is null)
                return order;

            var date = order.EstimatedDeliveryDate;
            order.EstimatedDeliveryDate = Convert.ToDateTime(date).AddDays(2).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

            return order;
        }
    }
}
