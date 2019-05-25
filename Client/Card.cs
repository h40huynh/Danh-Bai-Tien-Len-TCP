using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
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

        public Card(int value)
        {
            name = value / 10;
            type = value % 10;
            link = $"./cards/{name}_{type}.png";
        }

        public int getname() => name;
        public int gettype() => type;
        public int getvalue() => name * 10 + type;
        public string getlink() => link;

        public override string ToString()
        {
            return $"{name}{type}";
        }

    }
}
