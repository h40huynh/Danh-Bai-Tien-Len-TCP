using client;
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
        private int miss = 0;
        private List<PictureBox> ptbMyCards;
        private List<PictureBox> ptbReceiveCards;
        private bool[] isClick;
        private TcpModel tcpModel;
        private Cards cards;
        private string enemyCards = ""; // for Ignore_click
        private Rules rule;
        private int numCardsLeft;

        public GameForm(int roomId, TcpModel tcpModel)
        {
            InitializeComponent();

            ptbMyCards = new List<PictureBox>();
            ptbReceiveCards = new List<PictureBox>();

            cardSize = ptbCards.Size;
            isClick = new bool[13];
            lblRoomId.Text = $"Room {roomId}";
            this.tcpModel = tcpModel;
            createPicturebox();
            Thread thread = new Thread(receiveDataThread);
            thread.Start();
        }
//-----------------------------------------------------------------
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
                        rule = new Rules();
                        int id = int.Parse(value[value.Length - 1]);
                        if (id == tcpModel.getID())
                            btnFight.Enabled = true;
                        break;

                    case "next":
                        enemyCards = data;
                        miss = int.Parse(value[1]);
                        showRecentFightCard(data);
                        btnIgnore.Enabled = true;
                        rule.setmyCard(getStringCards());
                        rule.setEnemyCard(data);
                        if (rule.check() || miss == 3)
                            btnFight.Enabled = true;
                        break;

                    case "wait":
                        showRecentFightCard(data);
                        btnFight.Enabled = false;
                        btnIgnore.Enabled = false;
                        break;
                    case "end":
                        cleanCardsImage();
                        break;
                    case "chat":
                        string msg = data.Substring(5);
                        txtChatBox.Text += $"{msg}\n";
                        break;

                    default:
                        break;
                }
            }
        }
//-----------------------------------------------------------------------------
        private void initPictureBox(string listCard)
        {
            
            handleCardString(listCard);

            int listWith = 12 * space + cardSize.Width;
            int x = this.Width / 2 - listWith / 2 + 12 * space;
            x += 100;

            Point startPoint = new Point(x, 420);

            for(int i = 0; i < 13; i++)
            {
                ptbMyCards[i].Location = startPoint;
                ptbMyCards[i].Size = cardSize;
                ptbMyCards[i].ImageLocation = cards.getCard(i).getlink();
                ptbMyCards[i].SizeMode = PictureBoxSizeMode.StretchImage;
                ptbMyCards[i].Name = $"ptbCard_{i}";
                

                startPoint.X -= space;
            }
        }

        private void PictureBoxCards_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
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

            (sender as PictureBox).Location = p;
            isClick[id] = !isClick[id];
        }
//-----------------------------------------------------------------------------
        private void setCardPosition(ref List<PictureBox> pictureBox, int y, int n = 0)
        {
            int len = pictureBox.Count - 1;
            len = n != 0 ? n - 1 : len;
            int listWith = len * space + cardSize.Width;
            int x = this.Width / 2 - listWith / 2 + len * space;

            Point startPoint = new Point(x, y);

            for (int i = 0; i <= len; i++)
            {
                while (pictureBox[i] == null)
                {
                    i++;
                    if (i > len)
                    {
                        return;
                    }
                }
                pictureBox[i].Location = startPoint;
                pictureBox[i].Size = cardSize;
                startPoint.X -= space;
            }
        }
//-----------------------------------------------------------------------------
        private void GameForm_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            // Set center card
            ptbCards.ImageLocation = "./cards/cardBack_green5.png";
            ptbCardRight.ImageLocation = ptbCardUp.ImageLocation = ptbCards.ImageLocation;

            Point position = ptbCards.Location;
            position.X = this.Size.Width / 2 - cardSize.Width / 2;
            position.Y = this.Size.Height / 2 - cardSize.Height / 2;
        }
//-----------------------------------------------------------------------------
        private void handleCardString(string data)
        {
            numCardsLeft = 13;
            Card[] cardsArray = new Card[13];
            string[] s = data.Split(' ');
            for(int i = 0; i < 13; i++)
            {
                cardsArray[i] = new Card(int.Parse(s[i + 1]));
            }
            Card temp;
            for (int i = 0; i < 12; i++)
            {
                for (int j = i + 1; j < 13; j++)
                {
                    if (cardsArray[i].getvalue() < cardsArray[j].getvalue())
                    {
                        temp = cardsArray[i];
                        cardsArray[i] = cardsArray[j];
                        cardsArray[j] = temp;
                    }
                }
            }
            cards = new Cards(cardsArray);
        }
//-----------------------------------------------------------------------------
        private void BtnFight_Click(object sender, EventArgs e)
        {
            string myCards = "";
            for (int i = 0; i < 13; i++)
                if (isClick[i])
                    myCards += " " + cards.getCard(i).ToString();

            rule.setcurrentCard(myCards);
            if (rule.checkcurrent() == false && miss < 3)
                MessageBox.Show("Invalid cards");
            else
            {
                if (rule.checkcurrent() == true)
                {
                    for (int i = 0; i < 13; i++)
                    {
                        if (isClick[i])
                        {
                            numCardsLeft--;
                            ptbMyCards[i].Dispose();
                            ptbMyCards[i] = null;
                            isClick[i] = false;
                        }
                    }


                    tcpModel.sendData("pop" + myCards);
                    if (numCardsLeft <= 0)
                        tcpModel.sendData("winner ");
                }
                else
                    MessageBox.Show("Invalid cards");
            }
        }
//-----------------------------------------------------------------------------
        private void BtnIgnore_Click(object sender, EventArgs e)
        {
            enemyCards = enemyCards.Remove(0, 7);
            tcpModel.sendData("miss " + enemyCards);
        }
//----------------------------------------------------------------------------
        private void createPicturebox()
        {
            PictureBox[] pictureBoxes = new PictureBox[13];
            PictureBox[] pictureBoxes2 = new PictureBox[13];
            for (int i = 0; i < 13; i++) 
            {
                pictureBoxes[i] = new PictureBox();
                pictureBoxes[i].Location = new Point(-200, -200);
                Controls.Add(pictureBoxes[i]);
                ptbMyCards.Add(pictureBoxes[i]);
                ptbMyCards[i].Click += PictureBoxCards_Click;

                pictureBoxes2[i] = new PictureBox();
                pictureBoxes2[i].Location = new Point(-200, -200);
                pictureBoxes2[i].BackColor = Color.Transparent;
                Controls.Add(pictureBoxes2[i]);
                ptbReceiveCards.Add(pictureBoxes2[i]);
            }
            
        }
//-----------------------------------------------------------------------------
        private void showRecentFightCard(string currentCardsString)
        {
            
            string[] s = currentCardsString.Substring(7).Split(' ');
            if(s[0] == "")
            {
                return;
            }

            Card[] cardsArray = new Card[s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                cardsArray[i] = new Card(int.Parse(s[i]));
            }
            Cards tmp = new Cards(cardsArray);
            // wait 12
            // next 12
            
            for (int i = 0; i < tmp.getNumberOfCard(); i++)
            {
                ptbReceiveCards[i].ImageLocation = tmp.getCard(i).getlink();
                ptbReceiveCards[i].Size = cardSize;
                ptbReceiveCards[i].SizeMode = PictureBoxSizeMode.StretchImage;
            }
            for(int i = tmp.getNumberOfCard(); i < 13 ; i++)
            {
                ptbReceiveCards[i].Image = null;
            }

            setCardPosition(ref ptbReceiveCards, ptbCards.Location.Y, tmp.getNumberOfCard());
        }
//-----------------------------------------------------------------------------
        private string getStringCards()
        {
            string str = "";
            for (int i = 0; i < 13; i++)
                if (ptbMyCards[i] != null)
                    str += " " + cards.getCard(i).ToString();
            str = str.Remove(0, 1);
            return str;
        }
        //-----------------------------------------------------------------------------
        private void sendCardsLeft()
        {
            string myCards = "";
            for (int i = 0; i < 13; i++)
                if (ptbMyCards[i] != null)
                    myCards += " " + cards.getCard(i).ToString();
            tcpModel.sendData("lose" + myCards);
        }

        private void cleanCardsImage()
        {
            cards = null;
            for (int i = 0; i < 13; i++)
            {
                try
                {
                    ptbMyCards[i].Dispose();
                }
                catch { }
                
                ptbMyCards[i] = new PictureBox();
                ptbMyCards[i].Location = new Point(-200, -200);
                ptbMyCards[i].Click += PictureBoxCards_Click;

                ptbReceiveCards[i].Dispose();
                ptbReceiveCards[i] = new PictureBox();
                ptbReceiveCards[i].Location = new Point(-200, -200);
                ptbReceiveCards[i].BackColor = Color.Transparent;
                if (this.InvokeRequired)
                {
                    Invoke((MethodInvoker)delegate ()
                    {
                        Controls.Add(ptbMyCards[i]);
                        Controls.Add(ptbReceiveCards[i]);
                    });
                }
            }
        }

        private void BtnSendChat_Click(object sender, EventArgs e)
        {
            SendChatMessage();
        }

        private void TxtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SendChatMessage();
            }
        }

        private void SendChatMessage()
        {
            tcpModel.sendData($"chat {txtMessage.Text}");
            txtMessage.Clear();
        }
    }
}
