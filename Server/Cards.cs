using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Cards
    {
        private Card[] cards;
        int numberOfCard = 52;
//--------------------------------------------------------
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
//-------------------------------------------------------------------
        public void mix1()
        {
            Random random = new Random();
            int len = random.Next(5, 25);

            int start = len + random.Next(5, 20);

            Card[] temp = new Card[len];
            
            Array.Copy(cards, 0, temp, 0, len);
            Array.Copy(cards, start, cards, 0, len);
            Array.Copy(temp, 0, cards, start, len);
        }
//-------------------------------------------------------------------------
        public void mix2()
        {
            int count = 0;
            Card[] temp = new Card[52];
            Array.Copy(cards, 0, temp, 0, 52);
            for(int i = 0; i < 50;)
            {
                cards[i] = temp[count];
                cards[i + 1] = temp[count + 25];
                i += 2;
                count += 1;
            }
        }
//----------------------------------------------------------------------------------
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
            //cards = null;
            //cards = new Card[52];
            return split;
        }
//-----------------------------------------------------------------------------------
        public void Add(Card newCard)
        {
            cards[numberOfCard] = new Card(newCard.getName(), newCard.getType(),newCard.getLink());
            numberOfCard++;
        }
    }
}
