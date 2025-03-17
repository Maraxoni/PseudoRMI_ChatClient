using Microsoft.AspNetCore.Hosting.Server;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml.Linq;

namespace PseudoRMI_ChatClient
{
    class ChatClient
    {
        static void Main(string[] args)
        {
            // Communication method
            BasicHttpBinding httpBinding = new BasicHttpBinding();
            // Defining address
            //System.ServiceModel.EndpointAddress httpEndpoint = new System.ServiceModel.EndpointAddress("http://192.168.50.183:8080/ChatService");
            System.ServiceModel.EndpointAddress httpEndpoint = new System.ServiceModel.EndpointAddress("http://localhost:8080/ChatService");
            // Dynamically creating channels that implement interface
            ChannelFactory<IChatService> myChannelFactory = new ChannelFactory<IChatService>(httpBinding, httpEndpoint);

            IChatService server = myChannelFactory.CreateChannel();

            try
            {
                Console.WriteLine("Enter Your name and press Enter:");
                string name = Console.ReadLine().Trim();
                server.SetClient(name);

                Console.WriteLine("[System] User connected to chat server.");
                string msg;
                while (true)
                {
                    try
                    {
                        msg = Console.ReadLine().Trim();
                        msg = "[" + name + "] " + msg;
                        server.SendMessage(msg);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("[System] Client failed: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[System] Client failed: " + ex.Message);
            }
            finally
            {
                myChannelFactory.Close();
            }
        }
    }
}