using System;
using System.Globalization;
using TestForSmol.Models;

namespace TestForSmol.DataWork
{
    public class DataUpdater
    {
        public PurchaseOrder DateUpdate(PurchaseOrder order)
        {
            if (order != null)
            {
                var date = order.EstimatedDeliveryDate;
                order.EstimatedDeliveryDate = Convert.ToDateTime(date).AddDays(2).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
            return order;
        }
    }
}
