using System.Collections.Generic;
using Newtonsoft.Json;

namespace ACNHBot.Config.DataModels
{
    public class BotModel
    {
        [JsonProperty("command-prefix")] public string CommandPrefix { get; set; }

        [JsonProperty("superusers")] public List<ulong> Superusers { get; set; }

        [JsonProperty("role-sync-channel")] public ulong RoleSyncChannel { get; set; }

        [JsonProperty("token")] public string Token { get; set; }
    }
}