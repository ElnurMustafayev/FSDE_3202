using Client.Tools;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Messages
{
    public class ChangeActiveViewModelMessage : IMessage
    {
        public ViewModelBase NewActiveViewModel { get; set; }
    }
}
