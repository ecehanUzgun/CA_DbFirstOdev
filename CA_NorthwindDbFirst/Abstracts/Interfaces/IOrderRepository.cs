using CA_NorthwindDbFirst.Models;

namespace CA_NorthwindDbFirst.Abstracts.Interfaces
{
    internal interface IOrderRepository
    {
        List<Order> GetOrdersByDate (DateTime startDate, DateTime endDate);
        //List<Order> GetOrderCount();

    }
}
