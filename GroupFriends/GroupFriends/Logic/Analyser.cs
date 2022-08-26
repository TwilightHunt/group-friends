using GroupFriends.Handlers;
using VkNet.Enums;
using VkNet.Model;

namespace GroupFriends.Logic
{
    public class Analyser
    {
        VkHandler vk = new VkHandler();
        delegate void Find(User user);
        public void Analyse(string id)
        {
            var members = vk.GetGroupMembers(id);
            Find find = delegate { };

            Console.WriteLine("What to check: 0 - city, 1 - gender, 2 - birth date");
            int num = int.Parse(Console.ReadLine());

            switch (num)
            {
                case 0:
                    find = FindByCity;
                    break;
                case 1:
                    find = FindByGender;
                    break;
                case 2:
                    find = FindByBirthDate;
                    break;
                default:
                    Console.WriteLine("Wrong Operation");
                    Environment.Exit(0);
                    break;
            }

            foreach (var m in members)
            {
                find(m);
            }
        }

        private bool CheckMembers(string property, string value) =>
            (property == value) ? true : false;

        private void FindByCity(User user)
        {
            if (user.City != null)
                if (CheckMembers(user.City.Title, "Moscow"))
                    Console.WriteLine($"https://vk.com/{user.Domain}");
        }
        private void FindByGender(User user)
        {
            if (CheckMembers(user.Sex.ToString(), Sex.Female.ToString()))
                Console.WriteLine($"https://vk.com/{user.Domain}");
        }
        private void FindByBirthDate(User user)
        {
            string date = user.BirthDate;
            if (date != null && date.Length > 6)
            {
                int x = date.Length - 4;
                date = date.Substring(x, 4);

                if (CheckMembers(date, "2004"))
                    Console.WriteLine($"https://vk.com/{user.Domain}");
            }
        }
    }
}
