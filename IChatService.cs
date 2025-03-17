using System.ServiceModel;

namespace PseudoRMI_ChatClient
{
    [ServiceContract]
    public interface IChatService
    {
        [OperationContract]
        void SendMessage(string message);

        [OperationContract]
        void SetClient(IChatService client);

        [OperationContract]
        void SetName(string name);

        [OperationContract]
        IChatService GetClient();

        [OperationContract]
        string GetName();

        [OperationContract]
        void ReceiveMessage(string message);
    }
}
