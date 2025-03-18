using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace ChatClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:8080/chatHub")
                .Build();

            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Console.WriteLine($"[{user}]: {message}");
            });

            await connection.StartAsync();
            Console.WriteLine("Connected to server");

            Console.Write("Enter Username: ");
            string user = Console.ReadLine();
            Console.WriteLine($"User [{user}] logged.");
            Console.WriteLine($"You can start messaging :)");

            while (true)
            {
                string message = Console.ReadLine();

                await connection.InvokeAsync("SendMessage", user, message);
            }
        }
    }
}