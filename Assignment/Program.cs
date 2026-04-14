using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Reflection;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            #region 

            // 1. Get all products from the "Seafood" category. Print each product's name and price.

            var seafoodProducts = Source.ProductList.Where(p => p.Category == "Seafood");

            foreach (var product in seafoodProducts)
                Console.WriteLine($"Product: {product.ProductName}, Price: {product.UnitPrice:C}");


            #endregion

            #region 

            // 2. Get a list of only the product names from ProductList. Print each name.

            var productNames = Source.ProductList.Select(p => p.ProductName);

            foreach (var product in productNames)
                Console.WriteLine(product);

            #endregion

            #region 

            // 3. Sort all products by UnitPrice (ascending). Print each product's name and price.

            var sortedProducts = Source.ProductList.OrderBy(p => p.UnitPrice);

            foreach (var Product in sortedProducts)
                Console.WriteLine($"Name: {Product.ProductName}, Price: {Product.UnitPrice:C}");

            #endregion

            #region 

            // 4. Get all products where UnitPrice is between 10 and 30

            var filteredProducts = from p in Source.ProductList
                                   where p.UnitPrice >= 10 && p.UnitPrice <= 30
                                   select p;

            foreach (var product in filteredProducts)
                Console.WriteLine(product);

            #endregion

            #region 

            // 5. Get all products that are in stock (UnitsInStock > 0) and belong to the "Condiments" category.

            var inStockCondiments = Source.ProductList.Where(p => p.UnitsInStock > 0 && p.Category == "Condiments");

            foreach (var product in inStockCondiments)
                Console.WriteLine(product);

            #endregion

            #region 

            // 6. Create a new anonymous type with three properties:

            // ● Name → the product name
            // ● Price → the unit price
            // ● StockStatus → a string: "Available" if UnitsInStock > 0, otherwise "Out of Stock"
            // ● Print the result.

            var anonymousProduct = Source.ProductList.Select(p => new
            {
                Name = p.ProductName,
                Price = p.UnitPrice,
                StockStatus = p.UnitPrice > 0 ? "Available" : "Out of Stock"
            });

            #endregion

            #region 

            // 7. Print each product's name along with its position (1-based) in the list. Expected format: 1.Chai, 2.Chang, etc.

            var productsWithIndex = Source.ProductList.Select((p, index) => $"{index + 1}. {p.ProductName}");

            foreach (var product in anonymousProduct)
                Console.WriteLine(product);

            #endregion

            #region 

            // 8. Sort ProductList by Category ascending, then within each category, sort by UnitPrice descending.

            var sortedProductsList = Source.ProductList.OrderBy(p => p.Category)
                .ThenByDescending(p => p.UnitPrice);

            foreach (var product in sortedProductsList)
                Console.WriteLine(product);

            #endregion

            #region 

            // 9. Get all products from the "Beverages" category, sorted by UnitsInStock descending. Print name and stock.

            var beverages = from p in Source.ProductList
                            where p.Category == "Beverages"
                            orderby p.UnitsInStock descending
                            select p;

            foreach (var product in beverages)
                Console.WriteLine($"Product: {product.ProductName}, Stock: {product.UnitsInStock}");

            #endregion

            #region 

            // 10. Using QUERY SYNTAX with a compound from clause, listall orders placed in 1997 or later showing CustomerID and OrderDate.

            var ordersQuery = from c in Source.CustomerList
                              from o in c.Orders
                              where o.OrderDate.Year >= 1997
                              select new
                              {
                                  c.CustomerID,
                                  o.OrderDate
                              };

            foreach (var order in ordersQuery)
                Console.WriteLine(order);

            #endregion

            #region 

            // 11. Show position number alongside ProductName

            var productPositions = Source.ProductList.Select((p, index) => new
            {
                Position = index + 1,
                p.ProductName
            });

            foreach (var product in productPositions)
                Console.WriteLine(product);

            #endregion

            #region 

            // 12. Sort first by-word length and then by a case -insensitive sort of the words in an array.

            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedWords = Arr.OrderBy(w => w.Length)
                .ThenBy(w => w, StringComparer.OrdinalIgnoreCase);

            foreach (var word in sortedWords)
                Console.WriteLine(word);

            #endregion

            #region 

            // 13. Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.

            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var result = from d in digits
                         where d[1] == 'i'
                         select d.Reverse();

            foreach (var digit in result)
                Console.WriteLine(digit);

            #endregion 
        }
    }
}
