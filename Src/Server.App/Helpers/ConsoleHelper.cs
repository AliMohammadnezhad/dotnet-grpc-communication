namespace Server.App.Helpers;

public static class ConsoleHelper
{
    public static Task<ConsoleKeyInfo> ReadKeyAsync()
    {
        var tcs = new TaskCompletionSource<ConsoleKeyInfo>();

        Task.Run(() =>
        {
            try
            {
                var keyInfo = Console.ReadKey(intercept: true);
                tcs.SetResult(keyInfo);
            }
            catch (InvalidOperationException)
            {
                tcs.SetCanceled();
            }
        });

        return tcs.Task;
    }
}
