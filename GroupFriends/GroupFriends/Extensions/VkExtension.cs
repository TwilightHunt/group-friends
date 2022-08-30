using GroupFriends.Handlers;
using System.Collections.ObjectModel;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Utils;

namespace GroupFriends.Extensions
{
    public static class VkExtension
    {
        public static IEnumerable<ReadOnlyCollection<User>> GetAllGroupMembers(this VkHandler vk, string id)
        {
            long to_load = 100;
            long loaded = to_load;
            var loaded_members = vk.GetGroupMembers(id);
            var total = Convert.ToInt64(vk.GetGroupInfo(id).MembersCount);
            yield return loaded_members;
            while (loaded < total)
            {
                loaded = loaded + to_load > total ? total : loaded + to_load;
                yield return vk.GetGroupMembers(id, loaded);
            }
        }

    }
}
