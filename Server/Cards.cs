using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Cards
    {
        private Card[] cards;
        int numberOfCard = 52;

        public Cards()
        {
            cards = new Card[52];
            int count = 0;
            for (int i = 1; i < 5; i++)
            {
                for (int j = 3; j < 16; j++)
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
            Console.Write(a.ToString() + " ");
            Card[] card1 = new Card[a];
            Card[] card2 = new Card[52 - a];
            Array.Copy(cards, 0, card1, 0, a);
            Array.Copy(cards, a, card2, 0, 52 - a);
            Array.Copy(card2, 0, cards, 0, 52 - a);
            Array.Copy(card1, 0, cards, 52 - a, a);
        }

        public string[] Split_Cards()
        {
            string[] split = new string[4];
            
            for (int i = 0; i < 52; i += 4) 
            {
                split[0] += cards[i].ToString() + ' ';
                split[1] += cards[i + 1].ToString() + ' ';
                split[2] += cards[i + 2].ToString() + ' ';
                split[3] += cards[i + 3].ToString() + ' ';
                
            }
            numberOfCard = 0;
            return split;
        }

        public void Add(Card newCard)
        {
            cards[numberOfCard] = new Card(newCard.getName(), newCard.getType(),newCard.getLink());
            numberOfCard++;
        }
    }
}
