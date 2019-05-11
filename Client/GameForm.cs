using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        public GameForm()
        {
            InitializeComponent();

            cardSize = ptbCards.Size;
            isClick = new bool[13];
        }

        private void initPictureBox(string listCard)
        {
            ptbMyCards = new PictureBox[13];
            string[] s = listCard.Split(' ');

            int listWith = 12 * space + cardSize.Width;
            int x = this.Width / 2 - listWith / 2 + 12 * space;

            Point startPoint = new Point(x, 400);

            for (int i = 12; i >= 0; i--)
            {
                ptbMyCards[i] = new PictureBox();
                ptbMyCards[i].Location = startPoint;
                ptbMyCards[i].Size = cardSize;
                ptbMyCards[i].ImageLocation = "./cards/3_1.png";
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

                Controls.Add(ptbMyCards[i]);
                startPoint.X -= space;
            }
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            // Set center card
            ptbCards.ImageLocation = "./cards/cardBack_green5.png";
            ptbCardLeft.ImageLocation = ptbCardRight.ImageLocation = ptbCardUp.ImageLocation = ptbCards.ImageLocation;

            Point position = ptbCards.Location;
            position.X = this.Size.Width / 2 - cardSize.Width / 2;
            position.Y = this.Size.Height / 2 - cardSize.Height / 2;

            initPictureBox("31 31 31 31 31 31 31 31 31 31 31 31 31");
        }
    }
}
