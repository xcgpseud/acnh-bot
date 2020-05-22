using System.IO;
using ACNHBot.Config.DataModels;
using Newtonsoft.Json;

namespace ACNHBot.Config
{
    public class Config
    {
        private const string ConfigFile = "config.json";
        private ConfigModel _config;

        public ConfigModel Get()
        {
            if (_config == null)
            {
                SetConfig();
            }

            return _config;
        }

        private void SetConfig()
        {
            using (var file = File.OpenText(ConfigFile))
            using (var reader = new JsonTextReader(file))
            {
                var s = new JsonSerializer();
                _config = s.Deserialize<ConfigModel>(reader);
            }
        }

        public bool IsSuperuser(ulong userId)
        {
            return Get().Bot.Superusers.Contains(userId);
        }
    }
}