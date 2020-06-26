using System;
using System.Globalization;
using System.Threading.Tasks;
using ACNHBot.Application.Services;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;

namespace ACNHBot.Application.Handlers
{
    public class UserHandler
    {
        private UserService _service;

        public UserHandler() => _service = new UserService();

        public async Task Sync(CommandContext ctx)
        {
            var role = await ctx.Guild.CreateRoleAsync(
                $"sync-{ctx.Message.Author.Username}",
                Permissions.None,
                DiscordColor.Cyan,
                reason: "Sync Role"
            );

            await ctx.Member.GrantRoleAsync(role, "Sync Role");

            var channel = await ctx.Guild.CreateChannelAsync(
                $"sync-{ctx.Message.Author.Username}",
                ChannelType.Text,
                ctx.Guild.GetChannel(ctx.Dependencies.GetDependency<Config.Config>().Get().Bot.RoleSyncChannel),
                reason: "Sync Role"
            );

            await channel.AddOverwriteAsync(role, Permissions.SendMessages, Permissions.None, "Sync Role");

            try
            {
                var islandName = await _service.AskForInfo(ctx, channel, "What is your Island name?");

                await channel.SendMessageAsync("For the following questions, stand still in game and view the" +
                                               "Date / Time information at the bottom left.");

                var islandTime = await _service.AskForInfo(
                    ctx,
                    channel,
                    "Type the Date and Time information **exactly** as it is shown on-screen at the " +
                    "bottom left. Don't worry about caps / lower case. e.g.: 8:37 PM March 30 Mon"
                );

                
                
                var split = islandTime.Split(' ');
                var time = split[0];
                var amOrPm = split[1];
                var month = split[2];
                var dayDate = int.Parse(split[3]);

                var timeSplit = time.Split(':');
                var hour = int.Parse(timeSplit[0]);
                var mins = int.Parse(timeSplit[1]);

                if (amOrPm.ToLower() == "pm")
                {
                    hour += 12;
                }

                var islandDateTime = new DateTime(
                    year: DateTime.Now.Year,
                    month: Convert.ToDateTime(month + " 01, 1990").Month,
                    day: dayDate,
                    hour: hour,
                    minute: mins,
                    second: 0
                );

                await ctx.RespondAsync(islandDateTime.ToString(CultureInfo.InvariantCulture));
            }
            catch (Exception)
            {
                await ctx.Member.RevokeRoleAsync(role);
                await ctx.Guild.DeleteRoleAsync(role);
                await channel.DeleteAsync();
            }

            await ctx.Member.RevokeRoleAsync(role);
            await ctx.Guild.DeleteRoleAsync(role);
            await channel.DeleteAsync();
        }
    }
}