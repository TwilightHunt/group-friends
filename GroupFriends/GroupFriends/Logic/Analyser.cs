using GroupFriends.Handlers;

namespace GroupFriends.Logic
{
    public class Analyser
    {
        VkHandler vk = new VkHandler();
        public void Analyse(string id)
        {
            var members = vk.GetGroupMembers(id);

            Console.WriteLine("What to check: 0 - city, 1 - gender, 2 - birth date");

            foreach (var m in members)
            {
                if (m.City != null)
                    if (CheckMembers(m.City.Title, "Moscow"))
                    {
                        Console.WriteLine($"https://vk.com/{m.Domain}");
                    }
            }
        }

        private bool CheckMembers(string property, string value) =>
            (property == value) ? true : false;

    }
}
