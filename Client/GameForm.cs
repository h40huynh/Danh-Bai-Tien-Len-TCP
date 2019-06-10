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
        // For card image
        private Size cardSize = new Size(77, 110);
        private int space = 30;
        private int miss = 0;
        private List<PictureBox> ptbMyCards;
        private List<PictureBox> ptbReceiveCards;
        private bool[] isClick;

        private TcpModel tcpModel;
        private Cards cards;
        private string enemyCards = ""; // for Ignore_click
        private Rules rule;
        private int[] myCards = new int[13];

        // For set avatar position
        private int numCardsLeft;
        private int userOffsetInRoom;
        private readonly string[] UserAvatarNameById = { "0123", "3012", "2301", "1230" };

        // For timer count down
        private readonly int timePerTurn = 30;
        private int timeCount;
        private int countPosition = 0;
        private readonly Point[] timerLocation = { new Point(840, 434), new Point(760, 259), new Point(387, 95), new Point(17, 259) };

        // For signal allow fight or not
        private readonly Point[] sunPosition;
        private int toggleSun = 1;

        // Form closing
        private bool isPlaying = false;
        

        public GameForm(TcpModel tcpModel, int roomId, int userOffset)
        {
            this.tcpModel = tcpModel;
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            ptbMyCards = new List<PictureBox>();
            ptbReceiveCards = new List<PictureBox>();

            timeCount = timePerTurn;
            isClick = new bool[13];
            lblRoomId.Text = $"Room {roomId}";
            userOffsetInRoom = userOffset;
            prbTimerCount.Maximum = timePerTurn;

            sunPosition = new Point[] { btnFight.Location, btnIgnore.Location };

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
                int cid;
                switch (value[0])
                {
                    case "start":
                        isPlaying = true;
                        initPictureBox(data);
                        rule = new Rules();
                        int id = int.Parse(value[value.Length - 1]);
                        if (id == userOffsetInRoom)
                        {
                            StartOrStopSunAnimation(true, sunPosition[0]);
                            btnFight.Enabled = true;
                        }
                        startTimerCountDown(id);
                        break;

                    case "next":
                        enemyCards = data;
                        miss = int.Parse(value[1]);
                        cid = int.Parse(value[2]);
                        resetTimerOrWin(cid);
                        showRecentFightCard(data);
                        btnIgnore.Enabled = true;
                        rule.setmyCard(getStringCards());
                        rule.setEnemyCard(data);
                        if (rule.check() || miss == 3)
                        {
                            btnFight.Enabled = true;
                            if (miss == 3) 
                                btnIgnore.Enabled = false;
                            StartOrStopSunAnimation(true, sunPosition[0]);
                        }
                        else
                        {
                            StartOrStopSunAnimation(true, sunPosition[1]);
                        }
                        break;

                    case "wait":
                        cid = int.Parse(value[2]);
                        resetTimerOrWin(cid);
                        showRecentFightCard(data);
                        btnFight.Enabled = false;
                        btnIgnore.Enabled = false;
                        break;
                    case "end":
                        isPlaying = false;
                        lblWiner.Location = new Point(-40, -40);
                        cleanCardsImage();
                        break;
                    case "chat":
                        string msg = data.Substring(7);
                        cid = int.Parse($"{UserAvatarNameById[userOffsetInRoom][int.Parse(value[1])]}");
                        Controls.Find($"lblChat{cid}", false).First().Text = $"{msg}\n";
                        //txtChatBox.Text += $"{msg}\n";
                        break;
                    case "roomate":
                        setNewRoomate(data.Substring(8));
                        break;
                    case "roomates":
                        setNewRoomates(data.Substring(9));
                        break;
                    case "quitroom":
                        cid = int.Parse($"{UserAvatarNameById[userOffsetInRoom][int.Parse($"{data[9]}")]}");
                        deleteRoomate(cid);
                        break;
                    default:
                        break;
                }
            }
        }

        private void resetTimerOrWin(int id)
        {
            if(id <= 3)
            {
                int cid = int.Parse($"{UserAvatarNameById[userOffsetInRoom][id]}");
                countPosition = cid;
                prbTimerCount.Location = timerLocation[countPosition];
                prbTimerCount.Value = timePerTurn;
            }
            else
            {
                try
                {
                    if (this.InvokeRequired)
                    {
                        Invoke((MethodInvoker)delegate ()
                        {
                            timerCountdown.Stop();

                        });
                    }
                    else
                    {
                        timerCountdown.Stop();
                    }
                }
                catch { }
                int winId = id - 4;
                int cid = int.Parse($"{UserAvatarNameById[userOffsetInRoom][winId]}");
                lblWiner.Location = timerLocation[cid];
                
            }
        }

        private void deleteRoomate(int cid)
        {
            bool isFinish = false;
            do
            {
                if (this.InvokeRequired)
                {
                    Invoke((MethodInvoker)delegate ()
                    {
                        Controls.Find($"pnInfo{cid}", false).First().Hide();
                        isFinish = true;
                    });
                }
            } while (!isFinish);
        }

        private void startTimerCountDown(int id)
        {
            int cid = int.Parse($"{UserAvatarNameById[userOffsetInRoom][id]}");
            countPosition = cid;
            prbTimerCount.Value = timePerTurn;
            prbTimerCount.Location = timerLocation[countPosition];
            try
            {
                if (this.InvokeRequired)
                {
                    Invoke((MethodInvoker)delegate ()
                    {
                        timerCountdown.Start();

                    });
                }
                else
                {
                    timerCountdown.Start();
                }
            }
            catch { }
        }

        private void StartOrStopSunAnimation(bool isStart, Point position)
        {
            position.Y -= 50;
            position.X += 20;
            ptbSun.Location = position;

            try
            {
                if (this.InvokeRequired)
                {
                    Invoke((MethodInvoker)delegate ()
                    {
                        if (isStart)
                        {
                            timerSunAnimation.Start();
                        }
                        else
                            timerSunAnimation.Stop();

                    });
                }
                else
                {
                    if (isStart)
                    {
                        timerSunAnimation.Start();
                    }
                    else
                        timerSunAnimation.Stop();
                }
            }
            catch { }

        }

//-----------------------------------------------------------------------------
        private void setNewRoomates(string data)
        {
            string[] infos = data.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string roomateInfo in infos)
            {
                setNewRoomate(roomateInfo);
            }
        }
//-----------------------------------------------------------------------------
        private void setNewRoomate(string data)
        {
            string[] arg = data.Split(' ');
            int roomateId = int.Parse(arg[0]);
            
            int offset = int.Parse($"{UserAvatarNameById[userOffsetInRoom][roomateId]}");

            bool isFinish = false;
            do
            {
                if (this.InvokeRequired)
                {
                    Invoke((MethodInvoker)delegate ()
                    {
                        Controls.Find($"pnInfo{offset}", false).First().Show();
                        Controls.Find($"lblName{offset}", true).First().Text = arg[1];
                        (Controls.Find($"ptbAvatar{offset}", true).First() as PictureBox).ImageLocation = $"./avatar/{roomateId}.png";
                        isFinish = true;
                    });
                }
            } while (!isFinish);
            
        }
//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
        private void getHint(int id)
        {
            int[] hint = rule.setclickcards2(myCards, id);
            for (int i = 0; i < hint.Length; i++)
                Console.Write(hint[i] + "\t");
            for (int i = 0; i < hint.Length; i++)
            {
                if (hint[i] != id)
                {
                    PictureBox picture = Controls.Find($"ptbCard_{hint[i]}", false).First() as PictureBox;
                    ptbCardsHint_Click(picture);
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
//------------------------------------------------------------------------------
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
            getHint(id);
        }
//--------------------------------------------------------------------------------
        private void ptbCardsHint_Click(PictureBox picture)
        {
            Point p = picture.Location;
            int id = int.Parse(picture.Name.Split('_')[1]);
            if (isClick[id])
            {
                p.Y += 20;
            }
            else
            {
                p.Y -= 20;
            }

            picture.Location = p;
            isClick[id] = !isClick[id];
        }
//-----------------------------------------------------------------------------
        private void setCardPosition(ref List<PictureBox> pictureBox, int n = 0, int y = 170)
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
            pnInfo1.Hide();
            pnInfo2.Hide();
            pnInfo3.Hide();
            ptbAvatar0.ImageLocation = $"./avatar/{userOffsetInRoom}.png";

            // Set sun position
            ptbSun.ImageLocation = "./icon/sun.png";

            // progress bar for timer
            prbTimerCount.Location = new Point(-200, -200);
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
            for (int i = 0; i < cardsArray.Length; i++)
                myCards[i] = cardsArray[i].getvalue();
            Array.Reverse(myCards);
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
                    if (numCardsLeft <= 0)
                        tcpModel.sendData("winner" + myCards);
                    else
                        tcpModel.sendData("pop" + myCards);
                    StartOrStopSunAnimation(false, new Point(0, 0));
                    
                }
                else
                    MessageBox.Show("Invalid cards");
            }
        }
//-----------------------------------------------------------------------------
        private void BtnIgnore_Click(object sender, EventArgs e)
        {
            enemyCards = enemyCards.Remove(0, 9);
            tcpModel.sendData("miss " + enemyCards);
            StartOrStopSunAnimation(false, new Point(0, 0));
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
            
            string[] s = currentCardsString.Substring(9).Split(' ');
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

            setCardPosition(ref ptbReceiveCards, tmp.getNumberOfCard());
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

                bool isFinish = false;
                do
                {
                    if (this.InvokeRequired)
                    {
                        Invoke((MethodInvoker)delegate ()
                        {
                            Controls.Add(ptbMyCards[i]);
                            Controls.Add(ptbReceiveCards[i]);
                            isFinish = true;
                        });
                    }
                } while (!isFinish);
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

        private void TimerCountdown_Tick(object sender, EventArgs e)
        {
            if(prbTimerCount.Value > 0)
            {
                prbTimerCount.Increment(-1);
            }
            else if (countPosition == 0)
            {
                if(enemyCards == "" || miss == 3)
                {
                    for(int i = 12; i >= 0; i--)
                    {
                        if(ptbMyCards[i] != null)
                        {
                            isClick[i] = true;
                            BtnFight_Click(null, null);
                            break;
                        }
                    }
                }
                else
                {
                    BtnIgnore_Click(null, null);
                }
            }
        }

        private void TimerSunAnimation_Tick(object sender, EventArgs e)
        {
            Point tmp = ptbSun.Location;
            tmp.Y += 10 * toggleSun;
            ptbSun.Location = tmp;
            toggleSun *= -1;
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = isPlaying;
            tcpModel.sendData("quit ");
        }
    }
}
