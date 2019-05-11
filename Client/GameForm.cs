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
        public GameForm(int roomId, TcpModel tcpModel)
        {
            InitializeComponent();
            

            cardSize = ptbCards.Size;
            isClick = new bool[13];
            lblRoomId.Text = roomId.ToString();
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
                        break;
                    default:
                        break;
                }
            }
        }

        private void initPictureBox(string listCard)
        {
            Card[] cards = handleCardString(listCard);

            ptbMyCards = new PictureBox[13];

            int listWith = 12 * space + cardSize.Width;
            int x = this.Width / 2 - listWith / 2 + 12 * space;

            Point startPoint = new Point(x, 400);

            for (int i = 12; i >= 0; i--)
            {
                ptbMyCards[i] = new PictureBox();
                ptbMyCards[i].Location = startPoint;
                ptbMyCards[i].Size = cardSize;
                ptbMyCards[i].ImageLocation = $"./Cards/{cards[i].getlink()}";
                ptbMyCards[i].SizeMode = PictureBoxSizeMode.StretchImage;
                ptbMyCards[i].Name = $"ptbMyCard_{i}";
                //ptbMyCards[i].BackColor = Color.Transparent;

                ptbMyCards[i].Click += (sen, eve) =>
                {
                    PictureBox pictureBox = sen as PictureBox;
                    Point p = pictureBox.Location;
                    int id = int.Parse(pictureBox.Name.Split('_')[1]);
                    if(isClick[id])
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

            //initPictureBox("31 31 31 31 31 31 31 31 31 31 31 31 31");
        }

        private Card[] handleCardString(string data)
        {
            Card[] cards = new Card[13];
            string[] s = data.Split(' ');
            for(int i = 0; i < 13; i++)
            {
                cards[i] = new Card(int.Parse(s[i + 1]));
            }
            return cards;
        }
    }
}
