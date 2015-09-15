using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PotterShoppingCart.Tests
{
    [TestClass]
    public class PotterShoppingCartTests
    {
        [TestMethod]
        public void CalculateFeeTest_Buy_One_Book1_Should_Get_Fee_100()
        {
            PotterShoppingCart target = new PotterShoppingCart();

            var basket = new Basket
            {
                Book1 = 1,
                Book2 = 0,
                Book3 = 0,
                Book4 = 0,
                Book5 = 0,
            };

            target.CalculateFee(basket);

            var expected = 100;
            Assert.AreEqual(expected, basket.Fee);
        }

        [TestMethod]
        public void CalculateFeeTest_Buy_One_Book1_One_Book2_Should_Get_Fee_190()
        {
            PotterShoppingCart target = new PotterShoppingCart();

            var basket = new Basket
            {
                Book1 = 1,
                Book2 = 1,
                Book3 = 0,
                Book4 = 0,
                Book5 = 0,
            };

            target.CalculateFee(basket);

            var expected = 190;
            Assert.AreEqual(expected, basket.Fee);
        }
    }

    public class Basket
    {
        public int Book1 { get; set; }
        public int Book2 { get; set; }
        public int Book3 { get; set; }
        public int Book4 { get; set; }
        public int Book5 { get; set; }
        public int Fee { get; set; }
    }

    public class PotterShoppingCart
    {
        public void CalculateFee(Basket basket)
        {
            basket.Fee = 100;
        }
    }
}
