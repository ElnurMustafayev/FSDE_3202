using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase activeViewModel;
        public ViewModelBase ActiveViewModel
        {
            get { return activeViewModel; }
            set { base.Set(ref activeViewModel, value); }
        }
    }
}
