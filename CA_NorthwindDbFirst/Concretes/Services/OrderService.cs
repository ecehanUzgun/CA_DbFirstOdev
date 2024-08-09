using CA_NorthwindDbFirst.Abstracts.Interfaces;
using CA_NorthwindDbFirst.Models;

namespace CA_NorthwindDbFirst.Concretes.Services
{
    internal class OrderService : IOrderRepository
    {
        private readonly NorthwindContext _db;
        public OrderService()
        {
            _db = new NorthwindContext();
        }

        //Hangi personel hangi müşteriye kaç adet satış yapmıştır? Listeleyen metot. (Group by kullanımı) 
        public void GetOrderCount()
        {
            //select EmployeeID,CustomerID,COUNT(*) from Orders group by EmployeeID,CustomerID
            #region Linq to SQL 
            //var format = from o in _db.Orders
            //             group o by new { o.EmployeeId, o.CustomerId }
            //                 into g
            //             select new
            //             {
            //                 Employee = g.Key.EmployeeId,
            //                 Customer = g.Key.CustomerId,
            //                 Count = g.Count()
            //             };

            //foreach (var item in format.ToList())
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(format.ToList().Count()); 
            #endregion

            #region Linq to Entity
            var query = _db.Orders.GroupBy(x => new
            {
                x.EmployeeId,
                x.CustomerId
            }).Select(x => new
            {
                Employee = x.Key.EmployeeId,
                Customer = x.Key.CustomerId,
                Count = x.Count()
            });
            foreach (var item in query.ToList())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(query.ToList().Count()); 
            #endregion

        }

        public List<Order> GetOrdersByDate(DateTime startDate, DateTime endDate)
        {
            List<Order> orders = _db.Orders.Where(x => x.OrderDate > startDate && x.OrderDate < endDate).OrderByDescending(x => x.OrderDate).ToList();
            return orders;
        }
    }
}
