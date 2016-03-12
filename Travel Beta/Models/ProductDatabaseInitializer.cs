﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Travel_Beta.Models
{
    public class ProductDatabaseInitializer : DropCreateDatabaseIfModelChanges<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            GetCategories().ForEach(c => context.Categories.Add(c));
            GetProducts().ForEach(p => context.Products.Add(p));
        }

        private static List<Category> GetCategories()
        {
            var categories = new List<Category> {
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Size 35"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Size 35.5"
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "36"
                },
                new Category
                {
                    CategoryID = 4,
                    CategoryName = "36.5"
                },
                new Category
                {
                    CategoryID = 5,
                    CategoryName = "37"
                },
                new Category
                {
                    CategoryID = 6,
                    CategoryName = "37.5"
                },
                //
                 new Category
                {
                    CategoryID = 7,
                    CategoryName = "38"
                },
                new Category
                {
                    CategoryID = 8,
                    CategoryName = "38.5"
                },
                new Category
                {
                    CategoryID = 9,
                    CategoryName = "40"
                },
                new Category
                {
                    CategoryID = 10,
                    CategoryName = "40.5"
                },
                new Category
                {
                    CategoryID = 11,
                    CategoryName = "41"
                },
                new Category
                {
                    CategoryID = 12,
                    CategoryName = "42"
                }
            };

            return categories;
        }

        private static List<Product> GetProducts()
        {
            var products = new List<Product> {
                new Product
                {
                    ProductID = 1,
                    ProductName = "Penang Explore 1st class",
                    Description = "Yet to describe" +
                                  "yeah!",
                    ImagePath="penang.png",
                    UnitPrice = 220.00,
                    CategoryID = 1
               },
                new Product
                {
                    ProductID = 2,
                    ProductName = "Penang Explore budget",
                    Description = "Penang Penang penang wow penang",
                    ImagePath="penangB.png",
                    UnitPrice = 150.95,
                     CategoryID = 2
               },
                new Product
                {
                    ProductID = 3,
                    ProductName = "Makala Glory",
                    Description = "you'll see museums, old churches etc...",
                    ImagePath="malaka.png",
                    UnitPrice = 320.99,
                    CategoryID = 1
                },
                new Product
                {
                    ProductID = 4,
                    ProductName = "Malaka on budget",
                    Description = "Cheapest deal to explore melaka",
                    ImagePath="melaka2.png",
                    UnitPrice = 180.95,
                    CategoryID = 2
                },
                new Product
                {
                    ProductID = 5,
                    ProductName = "KL and KLCC 1st class",
                    Description = "You'll get to see from the top of KLCC towers, visit KLCC aquarium and " +
                                  "Visit KLCC pertosains",
                    ImagePath="KLCC1.png",
                    UnitPrice = 380.95,
                    CategoryID = 1
                },
                new Product
                {
                    ProductID = 6,
                    ProductName = "KL on budget",
                    Description = "Yet to describe",
                    ImagePath="KLCC2.png",
                    UnitPrice = 195.00,
                    CategoryID = 2
                }
            };

            return products;
        }
    }
}