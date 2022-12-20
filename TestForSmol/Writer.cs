using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using TestForSmol.Models;

namespace TestForSmol
{
    public class Writer
    {
        public static void WriteAboutDeliveredOrders(AllPurchaseOrders deliveredOrders, OutputMethod outputMethod)
        {
            if (deliveredOrders is null)
                return;
            // слишком тяжело
            var items = new List<Item>();
            deliveredOrders.PurchaseOrders.ForEach(x => items.AddRange(x.Items));

            var grouped = items.GroupBy(x => x.ProductName);

            foreach (var group in grouped)
            {
                if (outputMethod is OutputMethod.Log)
                    Log.Information($"{group.Key} - {group.Sum(x => x.Quantity)}шт.");
                if (outputMethod is OutputMethod.Console)
                    Console.WriteLine($"{group.Key} - {group.Sum(x => x.Quantity)}шт.");
            }
        }

        public static void WriteAboutOrder(PurchaseOrder order, OutputMethod outputMethod, string partNumber)
        {
            if (order is null)
                return;

            var name = order.OrderAddress.Name;
            var deliveriDate = order.EstimatedDeliveryDate;
            var count = order.Items.Where(x => x.PartNumber == partNumber).Sum(x => x.Quantity);
            var price = order.Items.Sum(x => x.Price);

            if (outputMethod is OutputMethod.Log)
            {
                Log.Information($"Имя заказчика: {name}\n" +
                              $"День недели ориентировочной даты доставки: {deliveriDate}\n" +
                              $"Количество единиц товара, у которого PartNumber = {partNumber}: {count}\n" +
                              $"Стоимость заказа: {price}");
                Console.WriteLine("Логгирован");
            }

            if (outputMethod is OutputMethod.Console)
                Console.WriteLine($"Имя заказчика: {name}\n" +
                                  $"День недели ориентировочной даты доставки: {deliveriDate}\n" +
                                  $"Количество единиц товара, у которого PartNumber = {partNumber}: {count}\n" +
                                  $"Стоимость заказа: {price}");

        }

        public enum OutputMethod
        {
            Console,
            Log
        }
    }
}

