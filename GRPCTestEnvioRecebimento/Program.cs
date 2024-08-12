using Grpc.Net.Client;
using Proto.Greet;

namespace GRPCTestSendReceive
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Iniciando GRPC Test SendReceive");
            Console.WriteLine("Realizando um Request");

            // Create a gRPC channel and client
            GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:5000");
            Greeter.GreeterClient client = new Greeter.GreeterClient(channel);


            for (int cont = 0; cont <= 99999; cont++)
            {
                var request = new HelloRequest { Name = "World" };

                // Call the SayHello method
                var reply = await client.SayHelloAsync(request);

                // Display the reply message in the console
                Console.WriteLine($"Response {cont}: {reply.Message}");
            }

        }
    }
}