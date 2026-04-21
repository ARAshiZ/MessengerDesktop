using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerDesktop.Models
{
    public class ChatUserModel 
    {
        public UserModel User { get; set; }
        public string LastMessage { get; set; }
    }
}
