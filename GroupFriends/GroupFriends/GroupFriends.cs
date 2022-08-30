using GroupFriends.ConfigTypes;
using GroupFriends.UI;
using Newtonsoft.Json;
using TwilightHunt.Shared.Emitter;
using TwilightHunt.Shared.System;

namespace GroupFriends
{
    public class GroupFriends
    {
        AppConfig _config;
        const string CONFIG_NAME = "config.json";

        public GroupFriends()
        {
            LoadConfig();
        }

        private void LoadConfig()
        {
            if (File.Exists(CONFIG_NAME))
            {
                var raw = File.ReadAllText(CONFIG_NAME);
                _config = JsonConvert.DeserializeObject<AppConfig>(raw);
                Storage.Set("SYSTEM_CONFIG", _config);
            }
            else
            {
                _config = new AppConfig();
                string raw = JsonConvert.SerializeObject(_config);
                File.WriteAllText(CONFIG_NAME, raw);
            }
        }

        public void Start()
        {
            var ui = new UIHandler();
            ui.Analyse();
        }
    }
}
