using GroupFriends.Extensions;
using GroupFriends.Handlers;
using System.Collections.ObjectModel;
using VkNet.Enums;
using VkNet.Model;

namespace GroupFriends.Logic
{
    public class Analyser
    {
        VkHandler vk = new VkHandler();
        delegate List<User> Find(IEnumerable<User> users);
        Find find = delegate { return new List<User> { }; };
        public void Analyse(string id)
        {
            var members = vk.GetAllGroupMembers(id).SelectMany(t => t);
            var rightMembers = find(members);

            var writted = 10;

            for(int i = 0; i < rightMembers.Count; i++)
            {
                Console.WriteLine($"{i}. - https://vk.com/{rightMembers[i].Domain}");
                if (i == writted-1) break;
            }

            while (writted < rightMembers.Count)
            {
                Console.WriteLine("Next? y/n");
                string result = Console.ReadLine();
                if(result == "y")
                {
                    for (int i = writted; i < rightMembers.Count; i++)
                    {
                        Console.WriteLine($"{i}. - https://vk.com/{rightMembers[i].Domain}");
                        writted++;
                        if (writted % 10 == 0) break;
                    }
                }
            }         
        }

        public void SetAnalyser()
        {
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
        }

        private List<User> FindByCity(IEnumerable<User> users)
        {
            return users.Where(u => u.City != null && u.City.Title == "Moscow").ToList();
        }
        private List<User> FindByGender(IEnumerable<User> users)
        {
            return users.Where(u => u.Sex == Sex.Female).ToList();
        }
        private List<User> FindByBirthDate(IEnumerable<User> users)
        {
            return users.Where(u => u.BirthDate.Contains("2004")).ToList();
        }
    }
}
