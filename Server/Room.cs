using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Room
    {
        private int id;
        private int money;
        private Player[] players;

        private int winnerPosition;
        private int numberOfPlayer;

        public Room(int money)
        {
            this.money = money;

            players = new Player[4];
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
    }
}
