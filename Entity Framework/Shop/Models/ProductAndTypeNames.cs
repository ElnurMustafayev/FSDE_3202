using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class ProductAndTypeNames
    {
        public ProductAndTypeNames(string productName, string productTypeName)
        {
            this.ProductName = productName;
            this.ProductTypeName = productTypeName;
        }

        public string ProductName { get; set; }
        public string ProductTypeName { get; set; }

        public override string ToString() => $"Product: {(string.IsNullOrWhiteSpace(ProductName) ? "Unknown" : this.ProductName)}, Type: {ProductTypeName}";
    }
}
