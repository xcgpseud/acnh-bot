using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace ACNHBot.Application.Controllers
{
    [Group("test")]
    public class TestController : Executor
    {
        [Command("responds")]
        public async Task Responds(CommandContext ctx)
        {
            await Execute(ctx, async () => await ctx.RespondAsync("I work!"));
        }
    }
}