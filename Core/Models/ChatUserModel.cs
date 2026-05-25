using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerDesktop.Core.Models
{
    public class ChatUserModel 
    {
        public UserModel User { get; set; }
        public ObservableCollection<MessageModel> Messages { get; set; }
        public MessageModel LastMessage { get; set; }
        public void AddMessage(MessageModel msg)
        {
            Messages.Add(msg);
        }
    }
}
