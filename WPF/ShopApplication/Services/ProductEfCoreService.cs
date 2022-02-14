using ShopApplication.EntityFramework;
using ShopApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Services
{
    public class ProductEfCoreService : IProductService
    {
        private ShopDbContext context;
        public ProductEfCoreService()
        {
            context = new ShopDbContext();
        }

        public async Task AddProductAsync(Product title)
        {
            await context.Products.AddAsync(title);

            await context.SaveChangesAsync();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return context.Products;
        }
    }
}
