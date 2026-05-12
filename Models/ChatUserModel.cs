using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerDesktop.Models
{
    public class ChatUserModel 
    {
        public UserModel User { get; set; }
        public ObservableCollection<string> Messages { get; set; }
        public string LastMessage { get; set; }
    }
}
