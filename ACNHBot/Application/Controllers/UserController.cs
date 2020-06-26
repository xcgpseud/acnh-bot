using System.Threading.Tasks;
using ACNHBot.Application.Handlers;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace ACNHBot.Application.Controllers
{
    [Group("user")]
    [Aliases("u")]
    public class UserController : Executor
    {
        private UserHandler _handler;

        public UserController() => _handler = new UserHandler();

        [Command("sync")]
        [Aliases("s")]
        public async Task Sync(CommandContext ctx)
        {
            await Execute(async () => await _handler.Sync(ctx));
        }
    }
}