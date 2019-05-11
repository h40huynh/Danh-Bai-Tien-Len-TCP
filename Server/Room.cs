﻿using System;
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
      
        public Room(int money, int id)
        {
            this.money = money;
            this.id = id;
            players = new Player[4];
            for (int i = 0; i < 15; i++) 
                cards.mix();
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
            numberOfPlayer--;
        }

        public void startGame()
        {
            for (int i = 0; i < 5; i++)
                cards.mix();
            String[] sendCard = cards.Split_Cards();
            for (int i = 0; i < 4; i++) 
            {
                players[winnerPosition++ % 4].sendData(sendCard[i] + ' ' + players[winnerPosition].getID().ToString());
            }
            
        }

        public void mergeCard(string dataReceive)   //gom bài từ client
        {
            string[] str = dataReceive.Split(' ');
            for (int i = 1; i < str.Length; i++)
            {
                Card newCard = new Card(int.Parse(str[1]) / 10, int.Parse(str[1]) % 10);
                cards.Add(newCard);
            }
        }

        public void endGame(Player player)      //sau khi nhận tín hiệu kết thúc ván
        {
            for (int i = 0; i < 4; i++)
            {
                if (players[i] == player)
                {
                    winnerPosition = i;
                }
                players[i].sendData("end " + player.getID().ToString());
            }
            Thread.Sleep(10000);
            if (isReady())
                startGame();
        }

        //gửi bài cho tất cả client sau mỗi lần có người đánh
        public void sendCardToPlayer(string dataReceive, Player player) 
        {
            string[] str = dataReceive.Split(' ');
            string dataSend = "";
            for (int i = 1; i < str.Length; i++) 
            {
                dataSend += str[i] + ' ';
            }
            for (int i = 0; i < 4; i++) 
            {
                if (players[i - 1] == player)
                    players[i].sendData("next " + dataSend);
                else
                    players[i].sendData("wait " + dataSend);
            }
        }
        public bool isReady()
        {
            if (numberOfPlayer == 4)
                return true;
            else
                return false;
        }
    }
}
