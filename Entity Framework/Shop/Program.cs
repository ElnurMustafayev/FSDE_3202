using Shop.EntityFramework;
using Shop.Models;
using Shop.Services;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            // dotnet tool uninstall --global dotnet-ef
            // dotnet tool install --global dotnet-ef

            // Microsoft.EntityFrameworkCore.SqlServer
            // Microsoft.EntityFrameworkCore.Design

            // dotnet ef migrations add "Init"
            // dotnet ef database update

            var service = new ProductSercice();
            var result = service.GetProductAndTypeNamesWithLinq();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
