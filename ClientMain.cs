using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace PseudoRMI_ChatClient
{
    class ChatClient
    {
        static void Main(string[] args)
        {
            // Communication method
            BasicHttpBinding httpBinding = new BasicHttpBinding();
            // Defining address
            //System.ServiceModel.EndpointAddress httpEndpoint = new System.ServiceModel.EndpointAddress("http://192.168.50.183:8080/DatabaseService");
            System.ServiceModel.EndpointAddress httpEndpoint = new System.ServiceModel.EndpointAddress("http://localhost:8080/DatabaseService");
            // Dynamically creating channels that implement interface
            ChannelFactory<IChatService> myChannelFactory = new ChannelFactory<IChatService>(httpBinding, httpEndpoint);

            IChatService wcfClient1 = myChannelFactory.CreateChannel();

            while (true)
            {
                Console.WriteLine("Enter product name, '1' to list all products or 'exit' to quit:");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                    break;

                try
                {
                    if (input.ToLower() == "1")
                    {
                        
                    }
                    else
                    {
                        
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            myChannelFactory.Close();
        }
    }
}