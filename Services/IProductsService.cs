using System.Collections.Generic;
using IGS.OnlineMarketplace.Models;

namespace IGS.OnlineMarketplace.Services
{
    public interface IProductsService
    {
        void CreateProduct(Product product);

        IEnumerable<Product> GetAllProducts();

        Product GetProductById(int id);

        void UpdateProduct(Product product);

        void DeleteProduct(Product product);

        bool SaveChanges();
    }
}