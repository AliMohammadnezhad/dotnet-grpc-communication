using Grpc.Core;

try
{
    var channel = new Channel("0.0.0.0", ChannelCredentials.Insecure);
    var client = new StreamService.StreamServiceClient(channel);

    var streamingCall = client.StreamCharacters(new Google.Protobuf.WellKnownTypes.Empty());

    await foreach (var response in streamingCall.ResponseStream.ReadAllAsync())
    {
        Console.WriteLine(response.Character);
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Failed to connect to server: {ex.Message}");
}

Console.WriteLine("Connection closed.");
