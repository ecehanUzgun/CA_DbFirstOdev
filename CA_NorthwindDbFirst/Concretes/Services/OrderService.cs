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
        //select EmployeeID,CustomerID,COUNT(*) from Orders group by EmployeeID,CustomerID
        public List<Order> GetOrderCount()
        {
            List<Order> orders = _db.Orders.Select(x => new
            {
                x.EmployeeId,
                x.CustomerId,
            }).GroupBy(x => x.EmployeeId);
        }

        public List<Order> GetOrdersByDate(DateTime startDate, DateTime endDate)
        {
            List<Order> orders = _db.Orders.Where(x => x.OrderDate > startDate && x.OrderDate < endDate).OrderByDescending(x => x.OrderDate).ToList();
            return orders;
        }
    }
}
