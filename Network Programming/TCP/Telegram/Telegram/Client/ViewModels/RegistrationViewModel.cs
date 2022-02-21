using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        private string clientName;

        public string ClientName
        {
            get { return clientName; }
            set { clientName = value; }
        }

        private long? chatId;

        public long? ChatId
        {
            get { return chatId; }
            set { chatId = value; }
        }


        private RelayCommand connectCommand;

        public RelayCommand ConnectCommand => connectCommand ??= new RelayCommand(
            execute: () =>
            {
                //App.Container.GetInstance<MainViewModel>().ActiveViewModel = App.Container.GetInstance<HomeViewModel>();
                // TODO: Connect
            },
            canExecute: () => string.IsNullOrWhiteSpace(this.ClientName) == false
            && ChatId is not null
            );



    }
}
