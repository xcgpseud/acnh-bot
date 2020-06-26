using System;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;

namespace ACNHBot.Application.Services
{
    public class UserService
    {
        public async Task<string> AskForInfo(CommandContext ctx, DiscordChannel channel, string question)
        {
            var iac = ctx.Client.GetInteractivityModule();

            await channel.SendMessageAsync($"{ctx.Member.Mention} {question}");
            var response = await iac.WaitForMessageAsync(
                x => x.Author.Equals(ctx.Message.Author) && x.ChannelId == channel.Id,
                TimeSpan.FromSeconds(60)
            );

            if (response == null)
            {
                throw new Exception("Got no response from the user.");
            }

            return response.Message.Content;
        }
    }
}
