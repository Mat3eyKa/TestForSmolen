using System;
using System.Globalization;
using TestForSmol.DataWork;
using TestForSmol.Models;
using Xunit;

namespace TestForSmol_Test
{
    public class DataUpdaterTest
    {
        [Fact]
        public void DateUpdaterTest()
        {
            // arrange 
            var purchaseOrderTests = new PurchaseOrder();
            var expected = purchaseOrderTests;
            expected.EstimatedDeliveryDate = DateTime.MinValue.AddDays(2).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

            // act 
            var actual = DataUpdater.DateUpdate(purchaseOrderTests);

            // assert 
            Assert.Same(expected, actual);
        }

        [Fact]
        public void WithData()
        {
            // arrange 
            var purchaseOrderTests = new PurchaseOrder
            {
                EstimatedDeliveryDate = "2002-05-26",
            };
            var expected = purchaseOrderTests;
            expected.EstimatedDeliveryDate = "2002-05-28";

            // act 
            var actual = DataUpdater.DateUpdate(purchaseOrderTests);

            // assert 
            Assert.Same(expected, actual);
        }

        [Fact]
        public void WithNull()
        {
            // arrange 
            PurchaseOrder purchaseOrderTests = null;

            // act 
            var actual = DataUpdater.DateUpdate(purchaseOrderTests);

            // assert 
            Assert.Null(actual);
        }
    }
}
