using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerDesktop.Infrastructure.DataTransferObjects
{
    public record class ChatUserData
    {
        public string Name { get; set; }
        public string LastMessage { get; set; }
        public int ID { get; set; }

        public ChatUserData(string name, string lastMessage, int id)
        {
            Name = name;
            LastMessage = lastMessage;
            ID = id;
        }
    }
}
