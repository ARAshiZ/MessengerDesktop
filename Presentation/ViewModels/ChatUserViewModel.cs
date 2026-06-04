using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerDesktop.Presentation.ViewModels
{
    public partial class ChatUserViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _chatUserName = string.Empty;

        [ObservableProperty]
        private int _chatUserId = 0;

        [ObservableProperty]
        private string _lastMessage = string.Empty;

        public ChatUserViewModel(string name, int id, string lastmsg) 
        {
            ChatUserName = name;
            ChatUserId = id;
            LastMessage = lastmsg;
        }
    }
}
