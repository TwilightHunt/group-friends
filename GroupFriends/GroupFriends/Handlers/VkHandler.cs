using GroupFriends.ConfigTypes;
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

        public ReadOnlyCollection<User> GetGroupMembers(string id, long offset = 0)
        {
            return Api.Groups.GetMembers(new GroupsGetMembersParams() { GroupId = id, Fields = UsersFields.All, Count = 10, Offset = offset });
        }
    }
}
