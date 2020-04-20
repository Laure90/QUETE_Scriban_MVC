using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scriban;
using System.IO;

namespace QUETE_Scriban_MVC
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new ProductContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                List<Product> productsListDB = new List<Product>
                {
                    new Product { Name = "Product1", Price = 9.99 },
                    new Product { Name = "Product2", Price = 19.99 },
                    new Product { Name = "Product3", Price = 29.99 },
                    new Product { Name = "Product4", Price = 39.99 },
                    new Product { Name = "Product5", Price = 49.99 },
                };

                context.AddRange(productsListDB);
                context.SaveChanges();

            }

            List<Product> productList = GetProductsList();

            var html = File.ReadAllText(@"..\..\View\HTMLPage1.html");
            var template = Template.Parse(html);
            var result = template.Render(new { Products = productList });

            ProductController.WriteProduct(result);
        }

        public static List<Product> GetProductsList()
        {
            using(var context = new ProductContext())
            {
                var list = (from p in context.Products
                           select p).ToList();
                return list;
            }
        }
    }
}
