using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Room
    {
        private int id;
        private int money;
        private Player[] players;
        private Cards cards = new Cards();
        private int winnerPosition;
        private int numberOfPlayer;

        public Room(int money)
        {
            this.money = money;

            players = new Player[4];
            for (int i = 0; i < 15; i++) 
            {
                cards.mix();
            }
        }

        public void addPlayer(Player p)
        {
            for(int i = 0; i < 4; i++)
            {
                if(players[i] == null)
                {
                    players[i] = p;
                    numberOfPlayer++;
                    return;
                }
            }
        }

        public void deletePlayer(Player p)
        {
            int position = Array.FindIndex(players, player => player == p);
            players[position] = null;
        }

        public void startGame()
        {
            String[] sendCard = cards.Split_Cards();
            for (int i = 0; i < 4; i++) 
            {
                players[winnerPosition++ % 4].sendData(sendCard[i]);
            }
            
        }

        public void mergeCard(string dataReceive)
        {
            string[] str = dataReceive.Split(' ');
            Card newCard = new Card(int.Parse(str[1]) / 10, int.Parse(str[1]) % 10);
            cards.Add(newCard);
        }

        public void setWinner(Player player)
        {
            for (int i = 0; i < 4; i++)
                if (players[i] == player)
                {
                    winnerPosition = i;
                    break;
                }
        }
    }
}
