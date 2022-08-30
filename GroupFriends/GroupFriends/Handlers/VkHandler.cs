using GroupFriends.ConfigTypes;
using GroupFriends.Logic;
using System.Collections.ObjectModel;
using TwilightHunt.Shared.System;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace GroupFriends.Handlers
{
    public class VkHandler
    {
        VkApi Api { get; }

        public VkHandler()
        {
            Api = new VkApi();
            Api.Authorize(new ApiAuthParams
            {
                AccessToken = Storage.Get<AppConfig>().Token
            });
        }

        public Group? GetGroupInfo(string id) =>
             Api.Groups.GetById(null, id, GroupsFields.All).FirstOrDefault();

        public ReadOnlyCollection<User> GetGroupMembers(string id, long offset = 0, long count = 100)
        {
            try { return Api.Groups.GetMembers(new GroupsGetMembersParams() 
            { 
                GroupId = id, 
                Fields = UsersFields.All, 
                Offset = offset, 
                Count = count }); 
            }
            catch { Console.WriteLine("Invalid syntax"); Environment.Exit(0); }
            return null;
        }
    }
}
