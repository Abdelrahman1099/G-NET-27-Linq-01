using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
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








            // Assignment 2






            #region 

            // 1. Get top 3 most expensive products

            var top3Expensive = Source.ProductList.OrderByDescending(p => p.UnitPrice).Take(3);

            foreach (var p in top3Expensive)
                Console.WriteLine(p);

            #endregion

            #region 

            // 2. show page 2 of products, with page size = 5

            var page2Products = Source.ProductList.Skip((2 - 1) * 5).Take(5);

            foreach (var p in page2Products)
                Console.WriteLine(p);

            #endregion

            #region 

            // 3. Take products from the list as long as Their UnitPrice is less than $25(list is ordered by price).

            var cheapProducts = Source.ProductList.OrderBy(p => p.UnitPrice).TakeWhile(p => p.UnitPrice < 25);

            foreach (var p in cheapProducts)
                Console.WriteLine(p);

            #endregion

            #region 

            // 4. Check if ALL products in the "Seafood" category are in stock

            var allSeafoodInStock = Source.ProductList.Where(p => p.Category == "Seafood").All(p => p.UnitsInStock > 0);

            foreach (var p in cheapProducts)  
                Console.WriteLine(p);

            #endregion

            #region 

            // 5. Check if the ID list contains 9 int[] ids = { 3, 9, 13, 18 };

            int[] ids = { 3, 9, 13, 18 };

            var containsNine = ids.Contains(9);

            Console.WriteLine(containsNine);

            #endregion

            #region 

            // 6. Group all products by Category and print each group with its product count.

            var categoryGroups = Source.ProductList.GroupBy(p => p.Category).Select(g => new { CategoryName = g.Key, ProductCount = g.Count()});

            foreach (var categoryGroup in categoryGroups)
                Console.WriteLine(categoryGroup);

            #endregion

            #region 

            // 7. Group products by Category and project only product names per group

            var productNamesByCategory = Source.ProductList.GroupBy(p => p.Category, p => p.ProductName);

            foreach (var group in productNamesByCategory)
            {
                Console.WriteLine(group.Key);
                foreach (var name in group)
                {
                    Console.WriteLine(name);
                }
            }

            #endregion

            #region 

            // 8. Find all categories that have MORE THAN 3 products

            var categoriesWithMoreThan3 = Source.ProductList.GroupBy(p => p.Category).Where(g => g.Count() < 3)
                .Select(g => g.Key);

                foreach(var categoryName in categoriesWithMoreThan3)
                Console.WriteLine(categoryName);

            #endregion

            #region 

            // 9. Using QUERY SYNTAX, group customers by Country, and for each group select { Country, Count, TotalOrderValue }.

            var groupCustomers = from c in Source.CustomerList
                         group c by c.Country into g
                         select new
                         {
                             Country = g.Key,
                             count = g.Count(),
                             TotalOrderValue = g.Sum(c => c.Orders.Sum(o => o.Total))
                         };

            foreach (var g in groupCustomers)
                Console.WriteLine($"Country: {g.Country}, Customers: {g.count}, Total Sales: {g.TotalOrderValue}");

            #endregion

            #region 

            // 10. Calculate the total number of units in stock across all products

            var totalUnitsInStock = Source.ProductList.Sum(p => p.UnitsInStock);
            Console.WriteLine(totalUnitsInStock);

            #endregion

            #region 

            // 11. Find the CHEAPEST and MOST EXPENSIVE product prices

            var cheapestPrice = Source.ProductList.MinBy(p => p.UnitPrice);
            Console.WriteLine(cheapestPrice);

            var mostExpensivePrice = Source.ProductList.MaxBy(p => p.UnitPrice);
            Console.WriteLine(mostExpensivePrice);

            #endregion

            #region 

            // 12. Get a distinct list of all product categories

            var distinctCategories = Source.ProductList.Select(p => p.Category).Distinct();

            foreach (var cat in distinctCategories)
                Console.WriteLine(cat);

            #endregion

            #region 

            // 13. find product IDs that are in setA but NOT in setB

            int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
            int[] setB = { 3, 6, 9, 12, 15, 13 };

            var result1 = setA.Except(setB);

            foreach (var num in result1)
                Console.WriteLine(num);

            #endregion

            #region 

            // 14. Find countries that appear in list1 but NOT in list2 (case -insensitive).

                string[] list1 = { "Germany", "France", "UK", "Spain" };
                string[] list2 = { "france", "SPAIN", "Italy" };

            var result2 = list1.Except(list2, StringComparer.OrdinalIgnoreCase);

            foreach (var country in result2)    
                Console.WriteLine(country);

            #endregion

            #region 

            // 15. Build a Dictionary<int, Product> keyed by ProductID. Then retrieve and print the product with ID = 18.

            var productDictionary = Source.ProductList.ToDictionary(p => p.ProductID);

            var product18 = productDictionary[18];
            Console.WriteLine(product18.ProductName);

            #endregion

            #region 

            // 16. Get the first product whose price is greater than $50.

            var expensiveProduct = Source.ProductList.First(p => p.UnitPrice > 50);
            Console.WriteLine(expensiveProduct);

            #endregion

            #region 

            // 17. Try to get the first product with a price > $500. it returns null instead of throwing.

            var product17 = Source.ProductList.FirstOrDefault(p => p.UnitPrice > 500);
            Console.WriteLine(product17);

            #endregion

            #region 

            // 18. Generate a multiplication table row for 7

            var tableRow7 = Enumerable.Range(1, 9).Select(i => $" {7} * {i}  = {7 * i} ");

            foreach (var num in tableRow7)
                Console.WriteLine(num);

            #endregion

            #region 

            // 19. Generate even numbers between 1 and 30.

            var evenNumbers = Enumerable.Range(1, 30).Where(n => n %  2 == 0);

            foreach (var num in evenNumbers)
                Console.WriteLine(num);

            #endregion

            #region 

            // 20. Concatenate the first 3 product names with the first 3 customer company names into a single sequence.

            var first3Products = Source.ProductList.Select(p => p.ProductName).Take(3);
            var first3Customers = Source.CustomerList.Select(C => C.CompanyName).Take(3);

            var combinedSequence = first3Products.Concat(first3Customers);

            foreach (var name in combinedSequence)
                Console.WriteLine(name);

            #endregion

            #region 

            // 21. Pair each product with a customer (by position) and produce a string "ProductName sold to CompanyName".

            var salesPairs = Source.ProductList.Zip(Source.CustomerList, (prod, cust) => new {PName = prod.ProductName, CName = cust.CompanyName });

            foreach (var item in salesPairs)
                Console.WriteLine($"{item.PName} sold to {item.CName}");

            #endregion


        }
    }
}
