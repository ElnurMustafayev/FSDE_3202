using Client.Messages;
using Client.Tools;
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
        private readonly IMessenger messenger;

        public RelayCommand ConnectCommand => connectCommand ??= new RelayCommand(
            execute: () =>
            {
                var message = new ChangeActiveViewModelMessage()
                {
                    NewActiveViewModel = App.Container.GetInstance<HomeViewModel>(),
                };

                messenger.Send(message);
            },
            canExecute: () => string.IsNullOrWhiteSpace(this.ClientName) == false
            && ChatId is not null
            );

        public RegistrationViewModel(IMessenger messenger)
        {
            this.messenger = messenger;
        }
    }
}
