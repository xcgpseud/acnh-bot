using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ACNHBot.Application.Database.Contexts;
using ACNHBot.Application.Database.Entities;
using ACNHBot.Application.DataModels.Json;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace ACNHBot.Application.Services
{
    public class ArtService : TNRDService
    {
        private const string ApiUrl = "Art";

        public async Task<Art> GetArtByName(string name)
        {
            var url = $"{BaseUrl}/{ApiUrl}/Name/{name.ToLower()}";
            Console.WriteLine(url);
            var response = await GetClient().GetAsync(url);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadAsAsync<Art>()
                : null;
        }

        public async Task<List<Art>> GetAllArt()
        {
            var url = $"{BaseUrl}/{ApiUrl}";
            var response = await GetClient().GetAsync(url);
            return response.IsSuccessStatusCode
                ? await response.Content.ReadAsAsync<List<Art>>()
                : new List<Art>();
        }

        public async Task<List<Art>> UpdateArt()
        {
            var art = await GetAllArt();
            
            using (var db = new SqliteContext())
            {
                await db.Database.ExecuteSqlRawAsync("DELETE FROM `Arts`");
                
                art.ForEach(async x =>
                {
                    await db.Arts.AddAsync(x.Adapt<ArtEntity>());
                });

                await db.SaveChangesAsync();
            }

            return art;
        }
    }
}