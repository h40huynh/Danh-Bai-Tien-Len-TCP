using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Cards
    {
        int numberOfCard;
        List<Card> cards;

        public Cards(string receiveServer)
        {
            string[] tmp = receiveServer.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < tmp.Length; i++)
            {
                Card card = new Card(int.Parse(tmp[i]));
                cards.Add(card);
            }
            numberOfCard = cards.Count;
            quicksort(cards);
        }

        private void sort()
        {
            quicksort(cards);
        }
        private void pop(Card card)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i].getvalue() == card.getvalue())
                {
                    cards.RemoveAt(i);
                }
            }
            numberOfCard = cards.Count;
        }
        static List<Card> quicksort(List<Card> list)
        {
            if (list.Count <= 1) return list;
            int pivotPosition = list.Count / 2;
            Card pivotValue = list[pivotPosition];
            list.RemoveAt(pivotPosition);
            List<Card> smaller = new List<Card>();
            List<Card> greater = new List<Card>();
            foreach (Card item in list)
            {
                if (item.getvalue() < pivotValue.getvalue())
                {
                    smaller.Add(item);
                }
                else
                {
                    greater.Add(item);
                }
            }
            List<Card> sorted = quicksort(smaller);
            sorted.Add(pivotValue);
            sorted.AddRange(quicksort(greater));
            return sorted;
        }

        private string listToString()
        {
            string tmp = "";
            for(int i =0; i< numberOfCard;  i++)
            {
                tmp = tmp + cards[i].getvalue().ToString() + " ";
            }
            return tmp;
        }

        public int getNumberOfCard() => numberOfCard;
        public string getCards() => this.listToString();

    }
}
