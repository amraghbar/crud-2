using ConsoleApp1.Data;
using ConsoleApp1.Models;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppLicationDbContext db = new AppLicationDbContext();

            Product p = new Product() { Name = "Product 1", price = 10 };
            Product p2 = new Product() { Name = "Product 2", price = 2000 };
            Product p3= new Product() { Name = "Product 3", price = 133 };
            Product p4= new Product() { Name = "Product 4", price = 109 };
            db.Products.Add(p);
            db.Products.Add(p2);
            db.Products.Add(p3);
            db.Products.Add(p4);
            Console.WriteLine("Done Add");
            db.SaveChanges();
            Order O= new Order() { Address = "123 Main St" };
            Order O2 = new Order() { Address = "342 Main St" };
            Order O3 = new Order() { Address = "6543 Main St" };
            Order O4= new Order() { Address = "839 Main St" };
            db.Orders.Add(O);
            db.Orders.Add(O2);
            db.Orders.Add(O3);
            db.Orders.Add(O4);
            Console.WriteLine("Done Add 2");
            db.SaveChanges();

            var products = db.Products.ToList();
            var orders = db.Orders.ToList();

            Console.WriteLine("All Products:");
            foreach (var product in products)
            {
                Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.price}");
            }

            Console.WriteLine("All Orders:");
            foreach (var order in orders)
            {
                Console.WriteLine($"Id: {order.Id}, Address: {order.Address}, CreatedAt: {order.CreatedAt}");
            }
            Console.WriteLine("--");

            var produ = db.Products.FirstOrDefault(p => p.Id == 1);
           
                produ.Name = "Updated Product Name";
                db.SaveChanges();
  
            var ord = db.Orders.FirstOrDefault(o => o.Id == 1);
            
                ord.CreatedAt = DateTime.Now;
                db.SaveChanges();
            Console.WriteLine("0------0");
            var product1 = db.Products.FirstOrDefault(p => p.Id == 2);
           
                db.Products.Remove(product1);
                db.SaveChanges();
            

            // Remove order with id 3
            var order1 = db.Orders.FirstOrDefault(o => o.Id == 3);
           
                db.Orders.Remove(order1);
                db.SaveChanges();
            

        }


    }
    }
