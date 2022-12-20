using System;
using TestForSmol.DataWork;
using TestForSmol.Models;
using Xunit;

namespace TestForSmol_Test
{
    public class DataReaderWithPurchasesTest
    {
        private static readonly string dsds = AppDomain.CurrentDomain.BaseDirectory;
        [Fact]
        public void CorrectData()
        {
            // arrange 
            string path = dsds[..^35] + "TestFiles\\Purchases.xml";

            Console.WriteLine(path);
            // act 
            var dataReaderPurchaseOrder = new DataReader<AllPurchaseOrders>(path);
            var actual = dataReaderPurchaseOrder.ReadDataFromXml();

            // assert 
            Assert.NotNull(actual);
        }

        [Fact]
        public void EnmptyPathToFile()
        {
            // arrange 
            string bedPath = "";

            // act 
            var dataReaderPurchaseOrder = new DataReader<AllPurchaseOrders>(bedPath);
            var actual = dataReaderPurchaseOrder.ReadDataFromXml();

            // assert 
            Assert.Null(actual);
        }

        [Fact]
        public void BedPathToFile()
        {
            // arrange 
            string path = dsds;

            // act 
            var dataReaderPurchaseOrder = new DataReader<AllPurchaseOrders>(path);
            var actual = dataReaderPurchaseOrder.ReadDataFromXml();

            // assert 
            Assert.Null(actual);
        }

        [Fact]
        public void EmptyFile()
        {
            // arrange 
            string path = dsds[..^35] + "TestFiles\\Empty.xml";

            // act 
            var dataReaderPurchaseOrder = new DataReader<AllPurchaseOrders>(path);
            var actual = dataReaderPurchaseOrder.ReadDataFromXml();

            // assert 
            Assert.Null(actual);
        }
    }
}
