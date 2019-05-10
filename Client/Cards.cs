using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Cards
    {
        private Card[] cards;
        public Cards()
        {
            cards = new Card[52];
            int count = 0;
            for(int i = 1; i < 5; i++)
            {
                for(int j = 3; j<16; j++)
                {
                    cards[count] = new Card(j, i, $"{j}_{i}.png");
                    count++;
                }
            }
        }

        public void mix()
        {
            Random random = new Random();
            int a = random.Next(10, 40);
            Card[] card1 = new Card[a];
            Card[] card2 = new Card[52 - a];
            Array.Copy(cards, 0, card1, 0, a);
            Array.Copy(cards, a, card2, 0, 52 - a);
            Array.Copy(card2, 0, cards, 0, 52 - a);
            Array.Copy(card1, 0, cards, 52 - a, a);
        }
    }
}
