using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoRMI_ChatClient
{
    public class ChatCallbackHandler : IChatCallback
    {
        public void ReceiveMessage(string message)
        {
            Console.WriteLine("New message received: " + message);
        }
    }
}
