using Grpc.Net.Client;
using GrpcService;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GrpcConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
            // The port number(5001) must match the port of the gRPC server.
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = "GreeterClient" });
            Console.WriteLine("Greeting: " + reply.Message);
            
            var channel2 = GrpcChannel.ForAddress("http://localhost:8099");

            var client2 = new Reciever.RecieverClient(channel2);
            var currentMessage = "";
            while (true)
            {
                var response2 = await client2.ShowSubtitleAsync(new Subtitle { Message = "test" });

                if (currentMessage != response2.Message)
                {
                    Console.WriteLine(response2.Message);
                    currentMessage = response2.Message;
                }
                Task.Delay(1000).Wait();
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
