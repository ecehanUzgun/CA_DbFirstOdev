using CA_NorthwindDbFirst.Abstracts.Interfaces;
using CA_NorthwindDbFirst.Models;

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

        public List<Product> FindUnderAvgPrice()
        {
            throw new NotImplementedException();
        }

    }
}
