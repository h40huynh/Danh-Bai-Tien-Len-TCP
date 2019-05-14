using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class GameForm : Form
    {
        private Size cardSize;
        private int space = 30;
        
        private PictureBox[] ptbMyCards;
        private bool[] isClick;
        private TcpModel tcpModel;
        private Card[] cardsArray;
        private Rules rule;
        public GameForm(int roomId, TcpModel tcpModel)
        {
            InitializeComponent();
            

            cardSize = ptbCards.Size;
            isClick = new bool[13];
            lblRoomId.Text = $"Room {roomId}";
            this.tcpModel = tcpModel;

            Thread thread = new Thread(receiveDataThread);
            thread.Start();
        }

        private void receiveDataThread()
        {
            while(true)
            {
                string data = tcpModel.receiveData();
                string[] value = data.Split(' ');
                switch (value[0])
                {
                    case "start":
                        initPictureBox(data);
                        
                        Cards tmpCards = new Cards(cardsArray);
                        rule = new Rules(tmpCards.ToString());
                        int id = int.Parse(value[value.Length - 1]);
                        if (id == tcpModel.getID())
                            btnFight.Enabled = true;
                        Console.WriteLine($"Data: {value[value.Length - 1]}");
                        Console.WriteLine($"ID: {tcpModel.getID()}");
                        break;

                    case "next":
                        handleCardString(data);
                        btnIgnore.Enabled = true;
                        rule.setEnemyCard(data);
                        if (rule.check())
                            btnFight.Enabled = true;
                        // hien bai cua doi thu len man hinh
                        break;

                    case "wait":
                        handleCardString(data);
                        // hien bai cua doi thu len man hinh
                        btnFight.Enabled = false;
                        btnIgnore.Enabled = false;
                        break;

                    case "end":
                        // ham gui so bai con lai cho server
                        break;

                    default:
                        break;
                }
            }
        }

        private void initPictureBox(string listCard)
        {
            handleCardString(listCard);
            ptbMyCards = new PictureBox[13];

            int listWith = 12 * space + cardSize.Width;
            int x = this.Width / 2 - listWith / 2 + 12 * space;

            Point startPoint = new Point(x, 400);
            setCardPosition(startPoint);
        }

        private void setCardPosition(Point startPoint)
        {
            for (int i = 12; i >= 0; i--)
            {
                ptbMyCards[i] = new PictureBox();
                ptbMyCards[i].Location = startPoint;
                ptbMyCards[i].Size = cardSize;
                ptbMyCards[i].ImageLocation = $"./Cards/{cardsArray[i].getlink()}";
                ptbMyCards[i].SizeMode = PictureBoxSizeMode.StretchImage;
                ptbMyCards[i].Name = $"ptbMyCard_{i}";


                ptbMyCards[i].Click += (sen, eve) =>
                {
                    PictureBox pictureBox = sen as PictureBox;
                    Point p = pictureBox.Location;
                    int id = int.Parse(pictureBox.Name.Split('_')[1]);
                    if (isClick[id])
                    {
                        p.Y += 20;
                    }
                    else
                    {
                        p.Y -= 20;
                    }

                    (sen as PictureBox).Location = p;
                    isClick[id] = !isClick[id];
                };

                this.Invoke((MethodInvoker)delegate
                {
                    Controls.Add(ptbMyCards[i]);
                });


                startPoint.X -= space;
            }
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            // Set center card
            ptbCards.ImageLocation = "./cards/cardBack_green5.png";
            ptbCardLeft.ImageLocation = ptbCardRight.ImageLocation = ptbCardUp.ImageLocation = ptbCards.ImageLocation;

            Point position = ptbCards.Location;
            position.X = this.Size.Width / 2 - cardSize.Width / 2;
            position.Y = this.Size.Height / 2 - cardSize.Height / 2;
        }

        private void handleCardString(string data)
        {
            cardsArray = new Card[13];
            string[] s = data.Split(' ');
            for(int i = 0; i < 13; i++)
            {
                cardsArray[i] = new Card(int.Parse(s[i + 1]));
            }
        }

        private void BtnFight_Click(object sender, EventArgs e)
        {
            string myCards = "";
            for (int i = 0; i < 13; i++)
                if (isClick[i])
                    myCards += cardsArray[i].ToString();
            rule.setcurrentCard(myCards);
            if (rule.checkcurrent() == false)
                MessageBox.Show("Invalid cards");
            else
                tcpModel.sendData("pop " + myCards);
                
        }

        private void BtnIgnore_Click(object sender, EventArgs e)
        {
            string sendCard = "";
            for (int i = 0; i < cardsArray.Length; i++)
                sendCard += cardsArray[i].ToString();
            tcpModel.sendData("miss " + sendCard);
        }
    }
}
