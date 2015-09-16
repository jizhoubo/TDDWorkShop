﻿using System.Collections.Generic;
using System.Linq;
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
                Books = new List<Book>() { new Book() { BookId = 1 } }
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
                Books = new List<Book>()
                {
                    new Book() { BookId = 1 },
                    new Book() { BookId = 2 }
                }
            };

            target.CalculateFee(basket);

            var expected = 190;
            Assert.AreEqual(expected, basket.Fee);
        }

        [TestMethod]
        public void CalculateFeeTest_Buy_One_Book1_One_Book2_One_Book3_Should_Get_Fee_270()
        {
            PotterShoppingCart target = new PotterShoppingCart();

            var basket = new Basket
            {
                Books = new List<Book>()
                {
                    new Book() { BookId = 1 },
                    new Book() { BookId = 2 },
                    new Book() { BookId = 3 }
                }
            };

            target.CalculateFee(basket);

            var expected = 270;
            Assert.AreEqual(expected, basket.Fee);
        }

        [TestMethod]
        public void CalculateFeeTest_Buy_One_Book1_One_Book2_One_Book3_One_book4_Should_Get_Fee_320()
        {
            PotterShoppingCart target = new PotterShoppingCart();

            var basket = new Basket
            {
                Books = new List<Book>()
                {
                    new Book() { BookId = 1 },
                    new Book() { BookId = 2 },
                    new Book() { BookId = 3 },
                    new Book() { BookId = 4 }
                }
            };

            target.CalculateFee(basket);

            var expected = 320;
            Assert.AreEqual(expected, basket.Fee);
        }

        [TestMethod]
        public void CalculateFeeTest_Buy_One_Book1_One_Book2_One_Book3_One_book4_One_book5_Should_Get_Fee_375()
        {
            PotterShoppingCart target = new PotterShoppingCart();

            var basket = new Basket
            {
                Books = new List<Book>()
                {
                    new Book() { BookId = 1 },
                    new Book() { BookId = 2 },
                    new Book() { BookId = 3 },
                    new Book() { BookId = 4 },
                    new Book() { BookId = 5 }
                }
            };

            target.CalculateFee(basket);

            var expected = 375;
            Assert.AreEqual(expected, basket.Fee);
        }
    }

    public class Basket
    {
        public List<Book> Books { get; set; }
        public decimal Fee { get; set; }
    }

    public class Book
    {
        public int BookId { get; set; }
    }

    public class PotterShoppingCart
    {
        private Dictionary<int, decimal> _DiscountTable = new Dictionary<int, decimal>
        {
            {1, 1m},
            {2, 0.95m},
            {3, 0.9m},
            {4, 0.8m},
            {5, 0.75m}
        };
        public void CalculateFee(Basket basket)
        {
            var booksCount = basket.Books.Count;
            var distinctBooksCount = basket.Books.Select(b => b.BookId).Distinct().Count();

            basket.Fee = 100*booksCount*_DiscountTable[distinctBooksCount];
        }
    }
}