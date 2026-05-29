using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerDesktop.Core.Models
{
    public class MessageModel
    {
        public int Id {  get; set; } 
        public string Message { get; set; } 

        public int ChatUserID { get; set; }
        public ChatUserModel ChatUser { get; set; }
    }
}
