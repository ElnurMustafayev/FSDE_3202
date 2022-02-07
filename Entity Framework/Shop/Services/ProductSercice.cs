using Shop.EntityFramework;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services
{
    public class ProductSercice
    {
        private readonly ShopDataContext context;

        public ProductSercice()
        {
            this.context = new ShopDataContext();
        }

        public IEnumerable<ProductAndTypeNames> GetProductAndTypeNamesWithLambda()
        {
            return context.Products
                .Join(
                    inner: context.ProductTypes,
                    outerKeySelector: p => p.ProductTypeId,
                    innerKeySelector: pt => pt.Id,
                    resultSelector: (p, pt) => new { Product = p, ProductType = pt }
                    )
                .Select(ppt => new ProductAndTypeNames(ppt.Product.Name, ppt.ProductType.Name)
                //new
                //{
                //    ProductName = ppt.Product.Name,
                //    ProductTypeName = ppt.ProductType.Name
                //}
                )
                .ToList();
        }

        public IEnumerable<ProductAndTypeNames> GetProductAndTypeNamesWithLinq()
        {
            return  from p in context.Products
                    join pt in context.ProductTypes on p.ProductTypeId equals pt.Id
                    select new ProductAndTypeNames(p.Name, pt.Name);
        }
    }
}
