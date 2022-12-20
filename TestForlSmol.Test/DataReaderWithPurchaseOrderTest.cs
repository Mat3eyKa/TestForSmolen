using System;
using TestForSmol.DataWork;
using TestForSmol.Models;
using Xunit;
using Assert = Xunit.Assert;

namespace TestForSmol_Test
{
    public class DataReaderWithPurchaseOrderTest
    {
        private static readonly string dsds = AppDomain.CurrentDomain.BaseDirectory;
        [Fact]
        public void CorrectData()
        {
            // arrange 
            string path = dsds[..^35] + "TestFiles\\PurchaseOrder.xml";

            Console.WriteLine(path);
            // act 
            var dataReaderPurchaseOrder = new DataReader<PurchaseOrder>(path);
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
            var dataReaderPurchaseOrder = new DataReader<PurchaseOrder>(bedPath);
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
            var dataReaderPurchaseOrder = new DataReader<PurchaseOrder>(path);
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
            var dataReaderPurchaseOrder = new DataReader<PurchaseOrder>(path);
            var actual = dataReaderPurchaseOrder.ReadDataFromXml();

            // assert 
            Assert.Null(actual);
        }
    }
}
