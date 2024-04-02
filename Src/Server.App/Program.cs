using Grpc.Core;
using Server.App.Services;

var server = new Grpc.Core.Server
{
    Services = { StreamService.BindService(new StreamServiceImplementation()) },
    Ports = { new ServerPort("localhost", 50051, ServerCredentials.Insecure) }
};
server.Start();

Console.WriteLine("Server listening on port 50051...");
await Task.Delay(-1);

await server.ShutdownAsync();