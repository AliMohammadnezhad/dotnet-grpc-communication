using Grpc.Core;
using Server.App.Services;

Grpc.Core.Server? server = null; 

try
{
    const string hostParam = "SERVER_HOST";
    
    var serverHost = Environment.GetEnvironmentVariable(hostParam);
    
    if (string.IsNullOrWhiteSpace(serverHost))
    {
        throw new ArgumentNullException(hostParam, "Server host environment variable is not set.");
    }

    if (!int.TryParse(Environment.GetEnvironmentVariable("SERVER_PORT"), out var serverPort))
    {
        throw new FormatException("SERVER_PORT", new Exception("Server port environment variable is not a valid integer."));
    }

    server = new Grpc.Core.Server 
    {
        Services = { StreamService.BindService(new StreamServiceImplementation()) },
        Ports = { new ServerPort(serverHost, serverPort, ServerCredentials.Insecure) }
    };

    server.Start();

    Console.WriteLine($"Server listening on port {serverPort}...");
    await Task.Delay(-1);
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}
finally
{
    if (server != null)
    {
        await server.ShutdownAsync();
    }
}
