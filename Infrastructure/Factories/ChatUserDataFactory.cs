using MessengerDesktop.Infrastructure.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerDesktop.Infrastructure.Factories
{
    public static class ChatUserDataFactory
    {
        public static ChatUserData CreateChatUser(string name, string lastMessage, int id)
        {
            return new ChatUserData(name, lastMessage, id);
        }
    }
}
