using Serilog;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using TestForSmol.DataWork;
using TestForSmol.Models;

namespace TestForSmol
{
    public class Program
    {
        private static readonly string dsds = AppDomain.CurrentDomain.BaseDirectory;
        private static string PathAboutOrder = dsds[..^29] + "TestFiles\\PurchaseOrder.xml";
        private static string PathDeliveredOrders = dsds[..^29] + "TestFiles\\Purchases.xml";
        private static string FolderToSeve = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

        public static async Task Main()
        {
            GetPathsToXmlFiles();
            GetPathsToSave();

            Log.Logger = new LoggerConfiguration().WriteTo.File(FolderToSeve + "\\log.txt").CreateLogger();

            var purchaseOrder = await Task.Run(() => new DataReader<PurchaseOrder>(PathAboutOrder).ReadDataFromXml());
            var allPurchaseOrders = await Task.Run(() => new DataReader<AllPurchaseOrders>(PathDeliveredOrders).ReadDataFromXml());
            var dataSaverPurchaseOrder = new DataSaver<PurchaseOrder>(FolderToSeve);

            if (purchaseOrder is not null && dataSaverPurchaseOrder is not null)
            {
                Console.WriteLine("Start Tasks");
                Task.WaitAll(
                   Task.Run(() => Writer.WriteAboutOrder(purchaseOrder, Writer.OutputMethod.Console, "926-AA")),
                   Task.Run(() => Writer.WriteAboutDeliveredOrders(allPurchaseOrders, Writer.OutputMethod.Console)),
                   Task.Run(() => Writer.WriteAboutOrder(purchaseOrder, Writer.OutputMethod.Log, "926-AA")),
                   Task.Run(() => dataSaverPurchaseOrder.Save(DataUpdater.DateUpdate(purchaseOrder), "PurchaseOrder")));
                Console.WriteLine("End Tasks");
            }
            else
                Console.WriteLine("Файлы пусты");

        }

        private static void GetPathsToXmlFiles()
        {
            Console.WriteLine("Использовать стандартаные файлы для работы? (Да/Нет)");

            if (YesNo())
                return;

            Console.WriteLine("Введите полный путь до файла 'Purchases'");
            PathAboutOrder = Console.ReadLine();
            Console.WriteLine("Введите полный путь до файла 'PurchaseOrder'");
            PathDeliveredOrders = Console.ReadLine();
        }

        private static void GetPathsToSave()
        {
            Console.WriteLine("Сохранить на рабочий стол? (Да/Нет)");

            if (YesNo())
                return;

            Console.WriteLine("Введите полный путь до папки куда хотите сохранять Файлы");
            FolderToSeve = Console.ReadLine();
        }

        private static bool YesNo()
        {
            var yesNoUseDesctopSave = Console.ReadLine().ToLower().Trim();

            if (yesNoUseDesctopSave is not "да" && yesNoUseDesctopSave is not "нет")
                YesNo();

            if (yesNoUseDesctopSave is "да")
                return true;

            return false;
        }
    }
}
