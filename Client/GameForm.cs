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
        
        private List<PictureBox> ptbMyCards;
        private bool[] isClick;
        private TcpModel tcpModel;
        private Cards cards;

        //private Rules rule;
        public GameForm(int roomId, TcpModel tcpModel)
        {
            InitializeComponent();

            ptbMyCards = new List<PictureBox>();
            cardSize = ptbCards.Size;
            isClick = new bool[13];
            lblRoomId.Text = $"Room {roomId}";
            this.tcpModel = tcpModel;
            createPicturebox();
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
                        
                        //Cards tmpCards = new Cards(cardsArray);
                        //rule = new Rules(tmpCards.ToString());
                        int id = int.Parse(value[value.Length - 1]);
                        if (id == tcpModel.getID())
                            btnFight.Enabled = true;
                        //Console.WriteLine($"Data: {value[value.Length - 1]}");
                        //Console.WriteLine($"ID: {tcpModel.getID()}");
                        break;

                    case "next":
                        //handleCardString(data);
                        Console.WriteLine(data);
                        btnFight.Enabled = true;
                        btnIgnore.Enabled = true;
                        //rule.setEnemyCard(data);
                        //if (rule.check())
                        //    btnFight.Enabled = true;
                        // hien bai cua doi thu len man hinh
                        break;

                    case "wait":
                        //handleCardString(data);
                        // hien bai cua doi thu len man hinh
                        Console.WriteLine(data);
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

            int listWith = 12 * space + cardSize.Width;
            int x = this.Width / 2 - listWith / 2 + 12 * space;

            Point startPoint = new Point(x, 400);

            for(int i = 0; i < 13; i++)
            {
                ptbMyCards[i].Location = startPoint;
                ptbMyCards[i].Size = cardSize;
                ptbMyCards[i].ImageLocation = cards.getCard(i).getlink();
                ptbMyCards[i].SizeMode = PictureBoxSizeMode.StretchImage;
                ptbMyCards[i].Name = $"ptbCard_{i}";

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

                startPoint.X -= space;
            }
        }

        private void setCardPosition()
        {
            int len = ptbMyCards.Count - 1;
            int listWith = len * space + cardSize.Width;
            int x = this.Width / 2 - listWith / 2 + len * space;

            Point startPoint = new Point(x, 400);

            for (int i = 0; i <= len; i++)
            {
                ptbMyCards[i].Location = startPoint;
                ptbMyCards[i].Size = cardSize;
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
            
            Card[] cardsArray = new Card[13];
            string[] s = data.Split(' ');
            for(int i = 0; i < 13; i++)
            {
                cardsArray[i] = new Card(int.Parse(s[i + 1]));
            }
            cards = new Cards(cardsArray);
        }

        private void BtnFight_Click(object sender, EventArgs e)
        {
            string myCards = "";
            for (int i = 0; i < 13; i++)
            {
                if (isClick[i])
                {
                    myCards += " " + cards.getCard(i).ToString();
                }
            }
                
            //rule.setcurrentCard(myCards);
            //if (rule.checkcurrent() == false)
            //    MessageBox.Show("Invalid cards");
            //else
                tcpModel.sendData("pop" + myCards);

            for (int i = 0; i < cards.getNumberOfCard(); i++) 
            {
                if (isClick[i])
                {
                    ptbMyCards[i].Dispose();
                    ptbMyCards.RemoveAt(i);
                    cards.pop(i);
                    isClick[i] = false;
                    setCardPosition();
                    
                }
            }
                   
        }



        private void BtnIgnore_Click(object sender, EventArgs e)
        {
            string sendCard = "";
            for (int i = 0; i < cards.getNumberOfCard(); i++)
                sendCard += cards.getCard(i).ToString();
            tcpModel.sendData("miss " + sendCard);
        }

        private void createPicturebox()
        {
            PictureBox[] pictureBoxes = new PictureBox[13];
            for (int i = 0; i < 13; i++) 
            {
                pictureBoxes[i] = new PictureBox();
                Controls.Add(pictureBoxes[i]);
                ptbMyCards.Add(pictureBoxes[i]);
            }
        }
    }
}
