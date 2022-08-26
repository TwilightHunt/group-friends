﻿using GroupFriends.ConfigTypes;
using GroupFriends.System;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            } else
            {
                _config = new AppConfig();
                string raw = JsonConvert.SerializeObject(_config);
                File.WriteAllText(CONFIG_NAME, raw);
            }
        }
    }
}