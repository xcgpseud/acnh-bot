using System.Threading.Tasks;
using ACNHBot.Application.Handlers;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace ACNHBot.Application.Controllers
{
    [Group("test")]
    public class TestController : Executor
    {
        private readonly TestHandler _handler;

        public TestController() => _handler = new TestHandler();

        [Command("responds")]
        public async Task Responds(CommandContext ctx)
        {
            await Execute(async () => await _handler.Responds(ctx));
        }
    }
}