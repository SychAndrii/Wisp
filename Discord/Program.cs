using Discord.WebSocket;

namespace Discord
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            DiscordSocketClient client = SetupDiscordClient();
            await LoginDiscordClient(client);

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

        private static DiscordSocketClient SetupDiscordClient()
        {
            var config = new DiscordSocketConfig { MessageCacheSize = 100 };
            DiscordSocketClient client = new();
            client.Ready += DiscordClientReady;
            return client;
        }

        private static async Task LoginDiscordClient(DiscordSocketClient client)
        {
            var token = Environment.GetEnvironmentVariable("DiscordToken");
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
        }

        private static Task DiscordClientReady()
        {
            Console.WriteLine("Discord client ready!");
            return Task.CompletedTask;
        }
    }
}
