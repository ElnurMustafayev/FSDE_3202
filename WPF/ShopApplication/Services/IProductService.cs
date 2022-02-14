using ShopApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Services
{
    public interface IProductService
    {
        Task AddProductAsync(Product title);

        IEnumerable<Product> GetAllProducts();
    }
}
