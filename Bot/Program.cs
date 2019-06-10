using System;
using System.Threading;

namespace Bot
{
    class Program
    {
        private TcpModel tcpModel;
        private string enemyCards = "";
        private string myCards = "";
        private Solve bot;
        private int numCardsLeft = 13;
        private int miss;
        private string offset = "";

        static void Main(string[] args)
        {
            Program program = new Program();
            program.startPlay();
        }

        public void startPlay()
        {
            tcpModel = new TcpModel("127.0.0.1", 8080);

            Thread thread = new Thread(receiveDataThread);
            thread.Start();
        }

        private void receiveDataThread()
        {
            while (true)
            {
                string data = tcpModel.receiveData();
                string[] value = data.Split(' ');
                switch (value[0])
                {
                    case "user":
                        tcpModel.setID(int.Parse(value[1]));
                        tcpModel.sendData("join ");
                        break;

                    case "start":
                        string id = value[value.Length - 1];
                        bot = new Solve();
                        data = data.Remove(0, 6);
                        myCards = data.Remove(data.Length - 1, 1);
                        if (id == offset)
                            start(myCards);
                        break;

                    case "next":
                        enemyCards = data;
                        miss = int.Parse(value[1]);
                        next(data);
                        break;
                    case "room":
                        offset = value[2];
                        break;
                    default:
                        break;
                }
            }
        }

        private void start(string data)
        {
            bot.setmyCard(data);
            if (bot.KiemTraThangTrang())
                tcpModel.sendData("winner ");
            else
            { 
                int[] fightCards = bot.DanhBaiChuDong();
                Array.Reverse(fightCards);
                fighting(fightCards);
            }
        }

        private void next(string data)
        {
            Thread.Sleep(3000);
            bot.setEnemyCard(data);
            bot.setmyCard(myCards);
            if (miss < 3)
            {
                int[] fightCards = bot.DanhBaiBiDong();
                Array.Reverse(fightCards);

                if (fightCards.Length == 1 && fightCards[0] == 0)
                    tcpModel.sendData("miss " + data.Remove(0, 9));
                else
                    fighting(fightCards);
            }
            else
            {
                int[] fightCards = bot.DanhBaiChuDong();
                Array.Reverse(fightCards);
                fighting(fightCards);
            }
        }

        private void fighting(int[] fightCards)
        {
            string sendData = "";
            for (int i = 0; i < fightCards.Length; i++)
            {
                sendData += ' ' + fightCards[i].ToString();
                myCards += ' ';
                myCards = myCards.Replace(fightCards[i].ToString() + ' ', "");
            }
            if (myCards[myCards.Length - 1] == ' ')
                myCards.Remove(myCards.Length - 1);

            numCardsLeft -= fightCards.Length;
            tcpModel.sendData("pop" + sendData);
            if (numCardsLeft == 0)
                tcpModel.sendData("winner ");
        }


    }
}
