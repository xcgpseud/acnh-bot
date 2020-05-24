using System;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;

namespace ACNHBot.Application.Handlers
{
    public class TurnipHandler
    {
        public async Task GetTurnipBuyInfo(CommandContext ctx, int turnipPrice)
        {
            var bringBells = 4000 * turnipPrice;
            var profitOnSell = 4000 * 500 - bringBells;

            await ctx.RespondAsync($"Grab **{bringBells:n0}** and buy 4000 turnips.\n" +
                                   $"If you can sell them for 500 each, you'll make: " +
                                   $"**{profitOnSell:n0}** bells profit!\n" +
                                   $"Best of luck!");
        }
    }
}