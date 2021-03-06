﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Cards
    {
        int numberOfCard = 0;
        List<Card> cards;

        public Cards(string receiveServer)
        {
            cards = new List<Card>();
            string[] tmp = receiveServer.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < tmp.Length; i++)
            {
                Card card = new Card(int.Parse(tmp[i]));
                cards.Add(card);
            }
            numberOfCard = cards.Count;
            quicksort(cards);
        }

        public Cards(Card[] cardArray)
        {
            cards = new List<Card>();
            for (int i = 0;i < cardArray.Length; i++)
            {
                cards.Add(cardArray[i]);
            }
            numberOfCard = cards.Count;
        }

        public Card getCard(int position) => cards[position];

        private void sort()
        {
            quicksort(cards);
        }

        public void pop(int position)
        {
            cards.RemoveAt(position);
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
