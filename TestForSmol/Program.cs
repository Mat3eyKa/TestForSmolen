using System;
using System.Threading.Tasks;
using TestForSmol.DataWork;
using TestForSmol.Models;

namespace TestForSmol
{
    public class Program
    {
        private static string PathAboutOrder = @"C:\Users\matbe\Desktop\PurchaseOrder.xml";
        private static string PathDeliveredOrders = @"C:\Users\matbe\Desktop\Purchases.xml";
        private static string FolderToSeve = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

        public static async Task Main()
        {
            var purchaseOrder = await Task.Run(() => new DataRider<PurchaseOrder>(PathAboutOrder).ReadDataFromXml());
            var allPurchaseOrders = await Task.Run(() => new DataRider<AllPurchaseOrders>(PathDeliveredOrders).ReadDataFromXml());
            var dataSaverPurchaseOrder = new DataSaver<PurchaseOrder>(FolderToSeve);

            Writer writer = new();
            DataUpdater dataUpdater = new();

            Console.WriteLine("Start Tasks");
            Task.WaitAll(
               Task.Run(() => writer.WriteAboutOrder(purchaseOrder)),
               Task.Run(() => writer.WriteAboutDeliveredOrders(allPurchaseOrders)),
               Task.Run(() => writer.WriteAboutOrderInLogger(purchaseOrder)),
               Task.Run(() => dataSaverPurchaseOrder.Save(dataUpdater.DateUpdate(purchaseOrder), "PurchaseOrder")));
            Console.WriteLine("End Tasks");
        }

        private static void GetPaths()
        {
            Console.WriteLine("");
        }
    }
}
