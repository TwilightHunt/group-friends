using GroupFriends.ConfigTypes;
using GroupFriends.System;
using System.Collections.ObjectModel;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

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
            Api.Groups.GetById(null, id, VkNet.Enums.Filters.GroupsFields.All).FirstOrDefault();

        public ReadOnlyCollection<User> GetGroupMembers(string id) => Api.Groups.GetMembers(new GroupsGetMembersParams() { GroupId = id, Fields = UsersFields.All });
       
    }
}
