using System.Threading.Tasks;
using ACNHBot.Application.Controllers;
using ACNHBot.Application.Database.Contexts;
using DSharpPlus;
using DSharpPlus.CommandsNext;

namespace ACNHBot.Application
{
    public class Bot
    {
        private DiscordClient _client;
        private CommandsNextModule _commandsNextModule;
        private readonly Config.Config _config;

        public Bot()
        {
            _config = new Config.Config();

            using (var db = new SqliteContext())
            {
                db.Database.EnsureCreated();
            }
        }

        public async Task Start()
        {
            _client = new DiscordClient(GetDiscordConfiguration());
            _commandsNextModule = _client.UseCommandsNext(GetCommandsNextConfiguration());

            _commandsNextModule.RegisterCommands<TestController>();
            _commandsNextModule.RegisterCommands<ArtController>();
            _commandsNextModule.RegisterCommands<TurnipController>();

            await _client.ConnectAsync();
            await Task.Delay(-1);
        }

        private DiscordConfiguration GetDiscordConfiguration()
        {
            return new DiscordConfiguration
            {
                Token = _config.Get().Bot.Token,
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug,
            };
        }

        private CommandsNextConfiguration GetCommandsNextConfiguration()
        {
            var deps = new DependencyCollectionBuilder()
                .AddInstance(_client)
                .Build();

            return new CommandsNextConfiguration
            {
                StringPrefix = _config.Get().Bot.CommandPrefix,
                Dependencies = deps,
            };
        }
    }
}