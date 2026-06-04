using MessengerDesktop.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerDesktop.Infrastructure.Factories
{
    public static class ChatUserViewModelFactory
    {
        public static ChatUserViewModel CreateChatUser(string name, int id, string lastMessage)
        {
            return new ChatUserViewModel(name, id, lastMessage);
        }
    }
}
