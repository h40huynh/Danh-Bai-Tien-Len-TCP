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
        private int winnerPosition = 0;
        private int numberOfPlayer = 0;
        private int miss = 0;
        private string playerMiss = "";
//--------------------------------------------------------      
        public Room(int money, int id)
        {
            this.money = money;
            this.id = id;
            players = new Player[4];
        }
//----------------------------------------------------------
        public void addPlayer(Player p)
        {   
            for(int i = 0; i < 5; i++)
            {
                if(players[i] == null)
                {
                    players[i] = p;
                    players[i].setIDRoom(id);
                    players[i].sendData($"room {id} {i}");
                    numberOfPlayer++;
                    sendRoomate(i);
                    if (isReady())
                    {
                        Thread.Sleep(500);
                        startGame();
                    }
                        
                    return;
                }
            }
        }
//-------------------------------------------------------------
        public void deletePlayer(Player p)
        {
            int position = Array.FindIndex(players, player => player == p);
            players[position] = null;
            numberOfPlayer--;

            for (int i = 0; i < 4; i++)
            {
                if(i != position && players[i] != null)
                {
                    players[i].sendData($"quitroom {position}");
                }
            }
        }
//---------------------------------------------------------------
        public void startGame()
        {
            Random random = new Random();
            int num = random.Next(40, 60);
            cards = new Cards();
            for (int i = 0; i < num; i++)
            {
                cards.mix1();
                cards.mix2();
            }

            string[] sendCard = cards.Split_Cards();

            int count = 0;
            for (int i = 0; i < 4; i++) 
            {
                players[count].sendData($"start {sendCard[i]} {winnerPosition}");
                count = (count + 1) % 4;
            }

            //cards = null;
            //cards = new Cards();
        }
//---------------------------------------------------------------------------------
        public void mergeCard(string dataReceive)   //gom bài từ client
        {
            string[] str = dataReceive.Split(' ');
            for (int i = 1; i < str.Length; i++)
            {
                Card newCard = new Card(int.Parse(str[i]) / 10, int.Parse(str[i]) % 10);
                cards.Add(newCard);
            }
        }
//------------------------------------------------------------------------------
        public void endGame(string data, Player player)      //sau khi nhận tín hiệu kết thúc ván
        {
            string dataSend = data.Substring(7);
            for (int i = 0; i < 4; i++)
                    players[i].sendData($"wait {miss} {dataSend}");
            Thread.Sleep(1000);
            for (int i = 0; i < 4; i++)
            {
                if (players[i] == player)
                {
                    winnerPosition = i;
                }
                
                players[i].sendData("end");
            }
            Thread.Sleep(3000);
            if (isReady())
                startGame();
        }
//---------------------------------------------------------------
        //gửi bài cho tất cả client sau mỗi lần có người đánh
        public void sendCardToPlayer(string dataReceive, Player player) 
        {
            string type = dataReceive.Split(' ')[0];
            if (type == "miss")
            {
                miss++;
                playerMiss += winnerPosition.ToString();
            }
            string dataSend = dataReceive.Substring(type.Length + 1);
            do
            {
                winnerPosition = (winnerPosition + 1) % 4;
            }
            while (playerMiss.Contains(winnerPosition.ToString()));
            if (miss == 3)
            {
                dataSend = "";
            }
            players[winnerPosition].sendData($"next {miss} {winnerPosition} {dataSend}");
            for (int i = 0; i < 4; i++)
                if(i != winnerPosition)
                    players[i].sendData($"wait {miss} {winnerPosition} {dataSend}");
            if (miss == 3)
            {
                miss = 0;
                playerMiss = "";
            }
        }
//-------------------------------------------------------------------------
        public bool isReady()
        {
            if (numberOfPlayer == 4)
                return true;
            else
                return false;
        }

        public void chat(string data, Player player)
        {
            int vt = 0;
            for (int i = 0; i < 4; i++)
                if (players[i] == player)
                {
                    vt = i;
                    break;
                }
            
            foreach(Player pl in players)
            {
                if (pl != null)
                    pl.sendData($"chat {vt} {data}");
            }
        }

        public void sendRoomate(int thisUserId)
        {
            if (numberOfPlayer >= 2)
            {
                string dataToThisUser = "roomates ";
                for (int i = 0; i < 4; i++)
                {
                    if (players[i] != null && i != thisUserId)
                    {
                        players[i].sendData($"roomate {thisUserId} {players[thisUserId].getName()}");
                        dataToThisUser += $",{i} {players[i].getName()}";
                    }
                }
                players[thisUserId].sendData(dataToThisUser);
            }
        }
    }
}
