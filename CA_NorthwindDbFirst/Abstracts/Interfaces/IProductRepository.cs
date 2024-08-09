using CA_NorthwindDbFirst.Models;

namespace CA_NorthwindDbFirst.Abstracts.Interfaces
{
    internal interface IProductRepository
    {
        List<Product> FindCustomPriceProducts(int minPrice, int maxPrice);
        //Fiyatı ortalama fiyatın altında olan ürünleri listeleyen metot. (Having kullanımı)
        void FindUnderAvgPrice();
        
    }
}
