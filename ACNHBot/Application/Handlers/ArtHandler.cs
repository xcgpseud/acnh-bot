using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using ACNHBot.Application.Services;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;

namespace ACNHBot.Application.Handlers
{
    public class ArtHandler
    {
        private ArtService _service;

        public ArtHandler() => _service = new ArtService();

        public async Task GetArtInfo(CommandContext ctx)
        {
            var name = ctx.RawArgumentString.ToLower();

            var art = await _service.GetAllArt();

            var nameMatches = art.FindAll(x => x.Name.ToLower() == name);
            if (nameMatches.Count == 0)
            {
                await ctx.RespondAsync("Could not find any art with that name. Sorry!");
                return;
            }

            var real = nameMatches.FirstOrDefault(x => x.Genuine);
            var fake = nameMatches.FirstOrDefault(x => !x.Genuine);

            if (real == null || fake == null)
            {
                await ctx.RespondAsync("Could not find any art with that name. Sorry!");
                return;
            }

            var embed = new DiscordEmbedBuilder
                {
                    Color = DiscordColor.Gold,
                    Description = $"{real.Artist}'s {real.RealArtworkTitle}: {real.MuseumDescription}.",
                    Title = real.Name
                }
                .Build();

            await ctx.RespondAsync(
                $"Real Image: {real.Image}\n" +
                $"Fake Image: {fake.Image}",
                embed: embed
            );
        }
    }
}