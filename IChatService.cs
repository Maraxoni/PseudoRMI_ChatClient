using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PseudoRMI_ChatClient
{
    [ServiceContract(CallbackContract = typeof(IChatCallback))]
    public interface IChatService
    {
        [OperationContract]
        void SendMessage(string message);

        [OperationContract]
        void Subscribe();

        [OperationContract]
        void Unsubscribe();
    }

    public interface IChatCallback
    {
        [OperationContract]
        void ReceiveMessage(string message);
    }
}
