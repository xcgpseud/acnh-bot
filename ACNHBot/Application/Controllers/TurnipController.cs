using System.Threading.Tasks;
using ACNHBot.Application.Handlers;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace ACNHBot.Application.Controllers
{
    [Group("turnips")]
    [Aliases("turnip", "t")]
    public class TurnipController : Executor
    {
        private readonly TurnipHandler _handler;

        public TurnipController() => _handler = new TurnipHandler();

        [Command("info")]
        [Aliases("i")]
        public async Task GetInfo(CommandContext ctx, int turnipPrice)
        {
            await Execute(async () => await _handler.GetTurnipBuyInfo(ctx, turnipPrice));
        }
    }
}