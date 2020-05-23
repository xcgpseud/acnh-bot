using System.Threading.Tasks;
using DSharpPlus.CommandsNext;

namespace ACNHBot.Application.Handlers
{
    public class TestHandler
    {
        public async Task Responds(CommandContext ctx)
        {
            await ctx.RespondAsync("I work.");
        }
    }
}