using Newtonsoft.Json;

namespace ACNHBot.Config.DataModels
{
    public class ConfigModel
    {
        [JsonProperty("bot")]
        public BotModel Bot { get; set; }
    }
}