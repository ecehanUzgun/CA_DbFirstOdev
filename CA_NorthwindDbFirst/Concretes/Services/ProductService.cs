using CA_NorthwindDbFirst.Abstracts.Interfaces;
using CA_NorthwindDbFirst.Models;
using System.Linq;

namespace CA_NorthwindDbFirst.Concretes.Services
{
    internal class ProductService : IProductRepository
    {
        private readonly NorthwindContext _db;
        public ProductService()
        {
            _db = new NorthwindContext();
        }
        public List<Product> FindCustomPriceProducts(int minPrice, int maxPrice)
        {
            List<Product> products = new List<Product>();
            if(minPrice>0)
            {
                products = _db.Products.Where(x => x.UnitPrice > minPrice && x.UnitPrice < maxPrice).ToList();
                return products;
            }
            return products;
        }

        public void FindUnderAvgPrice()
        {
            //select * from Products where UnitPrice<(select AVG(UnitPrice) from Products)
            #region SubqueryLinqToSQL
            var priceProduct = from p in _db.Products
                               select p.UnitPrice;
            var avgPrice = priceProduct.Average();
            var format = from p in _db.Products
                         where p.UnitPrice < avgPrice
                         select p.ProductName;
            var query = format.ToList();
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
            #endregion
            Console.WriteLine("Count:"+query.Count);


        }

    }
}
