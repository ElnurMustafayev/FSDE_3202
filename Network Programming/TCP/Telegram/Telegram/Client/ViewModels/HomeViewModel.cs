using Client.Messages;
using Client.Tools;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Client.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly IMessenger messenger;
        private TcpClient Client;
        private StreamReader Reader;
        private StreamWriter Writer;

        private string currentMessage;
        public string CurrentMessage
        {
            get { return currentMessage; }
            set { base.Set(ref currentMessage, value); }
        }

        private string clientName;
        public string ClientName
        {
            get { return clientName; }
            set { base.Set(ref clientName, value); }
        }

        private long chatId;
        public long ChatId
        {
            get { return chatId; }
            set { base.Set(ref chatId, value); }
        }

        public ObservableCollection<Message> Messages { get; set; }

        public HomeViewModel(IMessenger messenger)
        {
            this.messenger = messenger;
            this.Messages = new ObservableCollection<Message>();

            this.messenger.Subscribe<AfterRegistrationMessage>((obj) =>
            {
                if (obj is AfterRegistrationMessage message)
                {
                    this.ChatId = message.ChatId;
                    this.ClientName = message.ClientName;
                    this.Client = message.Client;
                    this.Reader = new StreamReader(this.Client.GetStream());
                    this.Writer = new StreamWriter(this.Client.GetStream());
                }
            });
        }

        private RelayCommand sendMessageCommand;

        public RelayCommand SendMessageCommand => sendMessageCommand ??= new RelayCommand(
            execute: () =>
            {
                Message message = new Message()
                {
                    SenderName = this.ClientName,
                    Content = CurrentMessage,
                    ChatId = this.ChatId
                };

                string JSON = JsonSerializer.Serialize(message);

                this.Writer.WriteLineAsync(JSON);
                this.Writer.Flush();
                this.Messages.Add(message);
                CurrentMessage = string.Empty;
            },
            canExecute: () => true
        );
    }
}
