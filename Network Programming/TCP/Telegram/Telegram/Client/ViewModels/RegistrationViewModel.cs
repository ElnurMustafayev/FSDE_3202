using Client.Messages;
using Client.Tools;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        private TcpClient client;

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
            execute: async () =>
            {
                IPAddress ip = IPAddress.Parse("127.0.0.1");
                await this.client.ConnectAsync(ip, 8080);

                var changeActive = new ChangeActiveViewModelMessage()
                {
                    NewActiveViewModel = App.Container.GetInstance<HomeViewModel>(),
                };

                var sendClient = new AfterRegistrationMessage()
                {
                    Client = this.client,
                    ClientName = this.ClientName,
                    ChatId = (long)this.ChatId
                };

                messenger.Send(changeActive);
                messenger.Send(sendClient);
            },
            canExecute: () => string.IsNullOrWhiteSpace(this.ClientName) == false
            && ChatId is not null
            );

        public RegistrationViewModel(IMessenger messenger)
        {
            this.messenger = messenger;

            this.client = new TcpClient();
        }
    }
}
