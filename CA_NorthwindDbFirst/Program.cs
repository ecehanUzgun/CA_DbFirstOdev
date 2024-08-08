using CA_NorthwindDbFirst.Concretes.Services;
using CA_NorthwindDbFirst.Models;

namespace CA_NorthwindDbFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region ProductService
            //ProductService productService = new ProductService();
            //var products = productService.FindCustomPriceProducts(10, 30);
            //if (products.Count > 0)
            //{
            //    foreach (var p in products)
            //    {
            //        Console.WriteLine(p.ProductName + " " + p.UnitPrice);
            //    }
            //    Console.WriteLine("*******************");
            //}; 
            #endregion

           
            #region OrderService
            //OrderService orderService = new OrderService();
            //DateTime userStartDate = new DateTime(1996, 01, 01);
            //DateTime userEndDate = new DateTime(1996, 12, 31);
            //List<Order> orders = orderService.GetOrdersByDate(userStartDate, userEndDate);
            //foreach (var order in orders)
            //{
            //    Console.WriteLine(order.OrderDate);
            //}
            //Console.WriteLine("*******************");
            //Console.WriteLine($"Between {userStartDate} and {userEndDate}  Total:{orders.Count}"); 
            #endregion

            //Employee Service
            EmployeeService employeeService = new EmployeeService();
            employeeService.GetEmployeeAge();


        }
    }
}
