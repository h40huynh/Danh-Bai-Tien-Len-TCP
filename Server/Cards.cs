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
            Card[] card1 = new Card[a];
            Card[] card2 = new Card[52 - a];
            Array.Copy(cards, 0, card1, 0, a);
            Array.Copy(cards, a, card2, 0, 52 - a);
            Array.Copy(card2, 0, cards, 0, 52 - a);
            Array.Copy(card1, 0, cards, 52 - a, a);
        }

        public Card[,] Split_Cards()
        {
            Card[,] split = new Card[4, 13];
            int j = 0;
            for (int i = 0; i < 52; i += 4) 
            {
                split[0, j] = cards[i];
                split[1, j] = cards[i+1];
                split[2, j] = cards[i+2];
                split[3, j] = cards[i+3];
                j++;
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
