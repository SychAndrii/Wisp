﻿using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Discord
{
    internal class Program
    {
        static ServiceProvider ConfigureServices()
        {
            var collection = new ServiceCollection();

            collection
                .AddSingleton(provider =>
                {
                    var client = new DiscordSocketClient(new DiscordSocketConfig { MessageCacheSize = 100 });
                    return client;
                })
                .AddSingleton(provider =>
                {
                    var client = provider.GetRequiredService<DiscordSocketClient>();
                    var config = new InteractionServiceConfig
                    {
                        UseCompiledLambda = true,      // Drastically improves performance of command execution.
                        DefaultRunMode = RunMode.Async // Set to Async to run commands on a separate thread
                    };
                    return new InteractionService(client, config);
                })
                .AddSingleton<App>();

            return collection.BuildServiceProvider();
        }

        static async Task Main()
        {
            var services = ConfigureServices();
            var app = services.GetRequiredService<App>();

            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            string envToken = config["DiscordToken"]
                ?? throw new Exception("DiscordToken setting must be set in appsettings.json!");

            string? envGuildID = config["DiscordGuild"];
            if (envGuildID is not null && ulong.TryParse(envGuildID, out ulong guildID))
            {
                await app.Startup(envToken, guildID);
            }
            else
            {
                await app.Startup(envToken);
            }

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }
    }
}
