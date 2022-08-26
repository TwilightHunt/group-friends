using Newtonsoft.Json;

namespace GroupFriends.ConfigTypes
{
    public class AppConfig
    {
        [JsonProperty("token")] public string Token { get; set; } = string.Empty;
    }
}
