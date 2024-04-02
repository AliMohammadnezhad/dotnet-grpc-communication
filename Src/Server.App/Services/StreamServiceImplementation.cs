using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Server.App.Helpers;

namespace Server.App.Services;

public class StreamServiceImplementation : StreamService.StreamServiceBase
{
    public override async Task StreamCharacters(Empty request, IServerStreamWriter<CharacterResponse> responseStream,
        ServerCallContext context)
    {
        await responseStream.WriteAsync(new CharacterResponse
            { Character = "Connection established. Ready to receive characters." });

        while (true)
        {
            var inputTask = Task.Run(async () =>
            {
                while (true)
                {
                    var keyInfo = await ConsoleHelper.ReadKeyAsync();

                    if (keyInfo is { Key: ConsoleKey.C, Modifiers: ConsoleModifiers.Control })
                    {
                        Console.WriteLine("Ctrl+C detected. Shutting down the server...");
                        Environment.Exit(0);
                    }

                    await responseStream.WriteAsync(new CharacterResponse { Character = keyInfo.KeyChar.ToString() });

                    Console.WriteLine(keyInfo.KeyChar);
                }
            });

            await inputTask;
        }
    }
}
