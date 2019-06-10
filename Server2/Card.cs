using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server2
{
    public class Card
    {
        private int name;
        private int type;
        private string link;
        private int value;

        public Card(int name1, int type1, string link1)
        {
            name = name1;
            type = type1;
            link = link1;
            value = name * 10 + type;
        }
        public Card(int name1, int type1)
        {
            name = name1;
            type = type1;
            value = name * 10 + type;
        }

        public int getName() => name;
        public int getType() => type;
        public string getLink() => link;
        public int getValue() => value;

        public override string ToString()
        {
            string str = value.ToString();
            return str;
        }
    }
}
