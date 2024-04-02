using Grpc.Core;

try
{
    const string serverParam = "SERVER_ADDRESS";
    
    var serverAddress = Environment.GetEnvironmentVariable(serverParam);
    if (string.IsNullOrWhiteSpace(serverAddress))
    {
        throw new ArgumentNullException(serverParam, $"{serverParam} environment variable is not set.");
    }

    var channel = new Channel(serverAddress, ChannelCredentials.Insecure);
    var client = new StreamService.StreamServiceClient(channel);

    var streamingCall = client.StreamCharacters(new Google.Protobuf.WellKnownTypes.Empty());

    await foreach (var response in streamingCall.ResponseStream.ReadAllAsync())
    {
        Console.WriteLine(response.Character);
    }
}
catch (ArgumentNullException ex)
{
    Console.WriteLine($"Environment variable error: {ex.Message}");
}
catch (RpcException ex)
{
    Console.WriteLine($"Failed to connect to server: {ex.Status.Detail}");
}
catch (Exception ex)
{
    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
}
finally
{
    Console.WriteLine("Connection closed.");
}