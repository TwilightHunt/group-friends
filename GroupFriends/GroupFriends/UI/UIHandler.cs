using GroupFriends.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupFriends.UI
{
    public class UIHandler
    {
        public void Analyse()
        {
            Console.Write("Group id: ");
            
            string id = Console.ReadLine();

            var analyser = new Analyser();
            analyser.Analyse(id);
        }

    }
}
