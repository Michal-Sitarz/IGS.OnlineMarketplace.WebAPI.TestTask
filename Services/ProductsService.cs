using System;
using System.Collections.Generic;
using System.Linq;
using IGS.OnlineMarketplace.Data;
using IGS.OnlineMarketplace.Models;

namespace IGS.OnlineMarketplace.Services
{
    public class ProductsService : IProductsService
    {
        private ApplicationDbContext _dbContext;

        public ProductsService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateProduct(Product product)
        {
            if(product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            _dbContext.Products.Add(product);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _dbContext.Products.FirstOrDefault( x => x.Id == id);
        }

        public void UpdateProduct(Product product)
        {
            // dbContext handles updates during mapping - see: ProductsController -> UpdateCommand()
            // implement if needed when using different approach/ORM/DB provider
        }

        public void DeleteProduct(Product product)
        {
            if(product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            _dbContext.Products.Remove(product);
        }

        public bool SaveChanges()
        {
            return (_dbContext.SaveChanges() >= 0);
        }

    }
}