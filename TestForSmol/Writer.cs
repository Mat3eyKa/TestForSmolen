using log4net;
using System;
using System.Linq;
using System.Reflection;
using TestForSmol.Models;

namespace TestForSmol
{
    public class Writer
    {
        // ToDo: определить чтоб ILog записывал файл на рабочий стол 
        // ToDo: Объединить метод WriteAboutOrder с методом WriteAboutOrderInLogger в один 

        private readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void WriteAboutOrder(PurchaseOrder order, string partNumber = "926-AA")
        {
            if (order != null)
            {
                var name = order.OrderAddress.Name;
                var deliveriDate = order.EstimatedDeliveryDate;
                var count = order.Items.Where(x => x.PartNumber == partNumber).Sum(x => x.Quantity);
                var price = order.Items.Sum(x => x.Price);
                Console.WriteLine($" Имя заказчика: {name}\n" +
                                  $" день недели ориентировочной даты доставки: {deliveriDate}\n" +
                                  $" количество единиц товара, у которого PartNumber=\"926-AA\": {count}\n" +
                                  $" стоимость заказа: {price}");
            }
        }

        public void WriteAboutDeliveredOrders(AllPurchaseOrders deliveredOrders)
        {
            // ToDo: нужно сгуппировать по имени элемента и вывестри сумму элементов с этим именем 
            if (deliveredOrders != null)
                foreach (var item in deliveredOrders.PurchaseOrders)
                    foreach (var prod in item.Items)
                        Console.WriteLine($" {prod.ProductName}-{prod.Quantity}шт.");
        }

        public void WriteAboutOrderInLogger(PurchaseOrder order, string partNumber = "926-AA")
        {
            if (order != null)
            {
                var name = order.OrderAddress.Name;
                var deliveriDate = order.EstimatedDeliveryDate;
                var count = order.Items.Where(x => x.PartNumber == partNumber).Sum(x => x.Quantity);
                var price = order.Items.Sum(x => x.Price);
                Log.Info($" Имя заказчика: {name}\n" +
                                  $" день недели ориентировочной даты доставки: {deliveriDate}\n" +
                                  $" количество единиц товара, у которого PartNumber=\"926-AA\": {count}\n" +
                                  $" стоимость заказа: {price}");
            }
        }
    } 
}

