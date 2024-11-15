using Discord.Interactions;
using Discord.WebSocket;
using System.Reflection;

namespace Discord
{
    internal class App(DiscordSocketClient client,
                       InteractionService interactionService,
                       IServiceProvider serviceProvider)
    {
        private readonly DiscordSocketClient client = client;
        private readonly InteractionService interactionService = interactionService;
        private readonly IServiceProvider serviceProvider = serviceProvider;

        public async Task Startup(string token, ulong? guildID = null)
        {
            client.Ready += () => OnClientReady(guildID);
            client.InteractionCreated += OnClientInteractionCreated;
            interactionService.Log += msg =>
            {
                Console.WriteLine($"[InteractionService] {msg}");
                return Task.CompletedTask;
            };
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
        }

        private async Task OnClientInteractionCreated(SocketInteraction interaction)
        {
            var context = new SocketInteractionContext(client, interaction);
            var result = await interactionService.ExecuteCommandAsync(context, serviceProvider);

            if (!result.IsSuccess)
            {
                Console.WriteLine($"Error: {result.ErrorReason}");
                if (interaction.HasResponded == false)
                    await interaction.RespondAsync("An error occurred while executing the command.");
            }
        }

        private async Task OnClientReady(ulong? guildID)
        {
            Console.WriteLine("Bot is connected!");
            var modules = await interactionService.AddModulesAsync(Assembly.GetExecutingAssembly(), serviceProvider);
            Console.WriteLine($"Loaded {modules.Count()} modules.");

            if (guildID.HasValue)
            {
                await interactionService.RegisterCommandsToGuildAsync(guildID.Value);
            }
            else
            {
                await interactionService.RegisterCommandsGloballyAsync();
            }
        }
    }
}
