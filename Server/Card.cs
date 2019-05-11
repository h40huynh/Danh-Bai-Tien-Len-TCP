using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Card
    {
        private int name;
        private int type;
        private string link;
        public Card(int name1, int type1, string link1)
        {
            name = name1;
            type = type1;
            link = link1;
        }
        public int getName() => name;
        public int getType() => type;
        public string getLink() => link;
    }
}
