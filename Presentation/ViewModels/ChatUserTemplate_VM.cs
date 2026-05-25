using CommunityToolkit.Mvvm.ComponentModel;
using MessengerDesktop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerDesktop.Presentation.ViewModels
{
    public partial class ChatUserTemplate_VM : ObservableObject
    {
        [ObservableProperty]
        private string _name = string.Empty;

        [ObservableProperty]
        private string _lastMessage = string.Empty;

        public ChatUserTemplate_VM() 
        {

        }
    }
}
