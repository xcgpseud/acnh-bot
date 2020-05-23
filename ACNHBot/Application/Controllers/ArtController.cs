using System.Threading.Tasks;
using ACNHBot.Application.Handlers;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace ACNHBot.Application.Controllers
{
    [Group("art")]
    public class ArtController : Executor
    {
        private readonly ArtHandler _handler;

        public ArtController() => _handler = new ArtHandler();

        [Command("check")]
        public async Task Check(CommandContext ctx)
        {
            await Execute(async () => await _handler.GetArtInfo(ctx));
        }
    }
}