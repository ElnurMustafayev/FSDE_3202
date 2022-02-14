using ShopApplication.Services;
using ShopApplication.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopApplication.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private string productTitle;
        public string ProductTitle
        {
            get { return productTitle; }
            set { 
                base.PropertyChangeMethod(ref productTitle, value);
                //MessageBox.Show(text);
                Console.WriteLine(productTitle);
            }
        }

        private CommandBase addProductCommand;
        private readonly IProductService productService;

        public CommandBase AddProductCommand => addProductCommand ??= new CommandBase()
        {
            execute = async () =>
            {

                await this.productService.AddProductAsync(new Models.Product()
                {
                    Title = ProductTitle,
                });
                ProductTitle = string.Empty;
            },
            canExecute = () => true,
        };

        public HomeViewModel(IProductService productService)
        {
            this.productService = productService;
        }
    }
}
