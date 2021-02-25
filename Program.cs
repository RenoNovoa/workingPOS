using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace workingPOS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Our Store!");

            DisplayProducts();
            Console.WriteLine();
            Shopping.shopping();
            Shopping.ContinueAddingProducts();



            Console.ReadKey();
        }

        private static void DisplayProducts()
        {
            var products = TextFile.GetAllProducts();

            int counter = 0;

            foreach (var product in products)
            {
                //if (product.Category == "Electronics")
                //{
               
                    //Console.WriteLine($"{ product.Category }");
                    Console.WriteLine($"{counter}. { product.Category }, { product.Name }, { product.Description }, { product.PriceOfItems }");
                counter ++;
                //}
            }
        }

        public class Shopping
        {
            //public decimal Total { get; set; }
            public static List<Product> ShoppingCart { get; set; } = new List<Product>();

            public static  void shopping()
            {
                Console.WriteLine("Please Select a  product from the list, to add to your shoping cart" +
                  "Enter number of the product");
                var userSelection = Console.ReadLine();

                Console.WriteLine("\nHow many items do you need today buddy?");
                var userAmountSelection = Console.ReadLine();

                //var userSelection = Console.ReadLine();
            }

            public static bool ContinueAddingProducts()
            {
                bool keepLooping;
                
                do
                {
                    Console.WriteLine("\nWould you like to Add More Items? (y/n)");
                    var userInput = Console.ReadLine();
                    if (userInput.Equals("Y", StringComparison.Ordinal) || userInput.Equals("yes", StringComparison.Ordinal))
                    {
                        keepLooping = false;
                        return true;
                    }
                    else if (userInput.Equals("N", StringComparison.Ordinal) || userInput.Equals("no", StringComparison.Ordinal))
                    {
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid Response ");
                        keepLooping = true;
                    }

                } while (keepLooping);
                return false;
            }
            public static void GenerateReceiptForUser()
            {

            }

                //public static List<Product> GetUserItems()
                //{
                //    return ShoppingCart;
                //}

            //AddToShoppingCart
        }
        }
    public class TextFile
    {
        public static readonly string filePath = @"C:\PosApp\Products.txt";

        public static List<string> GetItems(string filePath)
        {
            List<string> output = new List<string>();

            List<string> storeItems = File.ReadAllLines(filePath).ToList();
          

            return storeItems;
        }

        public static List<Product> GetAllProducts()
        {
            List<Product> output = new List<Product>();

            List<string> storeItems = TextFile.GetItems(filePath);

            foreach (var merch in storeItems)
            {
                if (string.IsNullOrWhiteSpace(merch))
                {
                    continue;
                }
                string[] item = merch.Split(',');
                Product products = new Product();

                products.Name = item[0];
                products.Category = item[1];
                products.Description = item[2];
                decimal.TryParse(item[3], out decimal PriceOfItems);
                products.PriceOfItems = PriceOfItems;


                output.Add(products);
            };
            return output;
        }
    }


    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal PriceOfItems { get; set; }
    }  
        
}
 //
//check if there is an empty space
//foreach (var item in storeItems)
//{
//    if(!string.IsNullOrWhiteSpace(item))
//    {
//        output.Add(item);
//    }
//}
