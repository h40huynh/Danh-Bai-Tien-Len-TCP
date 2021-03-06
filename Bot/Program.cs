﻿using System;
using System.IO;
using System.Net.Sockets;
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

        private bool isPlaying = false;

        static void Main(string[] args)
        {
            Program program = new Program();
            program.startPlay();
            int i = 2;
            while (i-- > 0)
            {
                Thread.Sleep(500);
                program = new Program();
                program.startPlay();
            }
        }

        public void startPlay()
        {
            tcpModel = new TcpModel("127.0.0.1", 13000);

            Thread thread = new Thread(receiveDataThread);
            thread.Start();
        }

        private void receiveDataThread()
        {
            try
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
                            isPlaying = true;
                            numCardsLeft = 13;
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
                        case "end":
                            isPlaying = false;
                            if (offset == "0")
                            {
                                Thread thread = new Thread(replayGame);
                                thread.Start();
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            catch
            {
                Environment.Exit(1);   
            }
        }

        private void replayGame()
        {
            Thread.Sleep(2000);
            while (!isPlaying)
            {
                tcpModel.sendData("startplay ");
                Thread.Sleep(2000);
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
                myCards = ' ' + myCards;
                myCards = myCards.Replace(' ' + fightCards[i].ToString(), "");
                myCards.Trim();
            }
            if (myCards[myCards.Length - 1] == ' ')
                myCards.Remove(myCards.Length - 1);

            numCardsLeft -= fightCards.Length;
            
            if (numCardsLeft == 0)
                tcpModel.sendData("winner " + sendData);
            else
                tcpModel.sendData("pop" + sendData);
        }


    }
}
