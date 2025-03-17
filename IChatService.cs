using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PseudoRMI_ChatClient
{
    [ServiceContract]
    public interface IChatService
    {
        [OperationContract]
        void SendMessage(string message);

        [OperationContract]
        void SetClient(string clientName);
    }
}
