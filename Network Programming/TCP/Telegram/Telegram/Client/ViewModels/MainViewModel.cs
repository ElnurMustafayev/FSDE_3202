using Client.Messages;
using Client.Tools;
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
        private readonly IMessenger messenger;

        public ViewModelBase ActiveViewModel
        {
            get { return activeViewModel; }
            set { base.Set(ref activeViewModel, value); }
        }

        public MainViewModel(IMessenger messenger)
        {
            this.messenger = messenger;

            this.messenger.Subscribe<ChangeActiveViewModelMessage>((obj) =>
            {
                if (obj is ChangeActiveViewModelMessage message)
                {
                    this.ActiveViewModel = message.NewActiveViewModel;
                }
            });
        }
    }
}
