using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    class Rules
    {
        int[] enemyCard; // cục bài ở giữa nè
        int[] myCard;// tất cả bài của mình
        int[] currentCard; // bài đang chọn


        public void setEnemyCard(string dataReceive)
        {
            dataReceive = dataReceive.Remove(0, 7);
            string[] enemystr = dataReceive.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            enemyCard = Array.ConvertAll<string, int>(enemystr, int.Parse);
            Array.Reverse(enemyCard);
        }

        public void setcurrentCard(string dataReceive)
        {
            dataReceive = dataReceive.Remove(0, 1);
            string[] mystr = dataReceive.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            currentCard = Array.ConvertAll<string, int>(mystr, int.Parse);
            Array.Reverse(currentCard);
        }

        public void setmyCard(string datareceive)
        {
            string[] mystr = datareceive.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            myCard = Array.ConvertAll<string, int>(mystr, int.Parse);
            Array.Reverse(myCard);
        }
        public Rules()
        {
        }
        public bool check() // check ban đầu
        {
            if (enemyCard.Length == 0)
                return true;
            // đánh lẻ 
            if (enemyCard.Length == 1)
            {
                // đánh lẻ =2
                if (enemyCard[0] / 10 == 15)
                {
                    if (checksingle(myCard) == true || finddoublegroup(myCard, 3) == true || findquadra(myCard) == true)
                        return true;
                }
                else
                    return checksingle(myCard);
            }

            // đánh đôi
            if (enemyCard.Length == 2)
            {
                // đánh đôi 2
                if (enemyCard[0] / 10 == 15)
                {
                    if (checkdouble(myCard) == true || findquadra(myCard) == true || finddoublegroup(myCard, 4) == true)
                        return true;
                }
                else
                    return checkdouble(myCard);
            }
            // đaanhs 3
            if (enemyCard.Length == 3 && enemyCard[0] / 10 == enemyCard[1] / 10)
            {
                return checktriple(myCard);
            }
            // đánh tứ quý
            if (enemyCard.Length == 4 && enemyCard[0] / 10 == enemyCard[3] / 10)
            {
                return checkquadra(myCard);
            }
            // đánh 3 đôi thông
            if (enemyCard.Length == 6 && enemyCard[0] / 10 == enemyCard[1] / 10)
            {
                if (checkdoublegroup(myCard, 3) || findquadra(myCard))
                    return true;
                return false;
            }
            // đánh đôi thông > 3
            if (enemyCard.Length >= 8 && enemyCard[0] / 10 == enemyCard[1] / 10)
            {
                return checkdoublegroup(myCard, enemyCard.Length / 2);
            }
            // còn lại là đánh sảnh
            return checkgroup(myCard);
        }

        private bool checksingle(int[] curr) // đánh lẻ
        {
            // mycard max của mình > enemyCard
            if (curr[curr.Length - 1] > enemyCard[0])
                return true;
            else
                return false;
        }

        private bool checkdouble(int[] curr) // đánh đôi
        {
            // mycard max < enemyCard max => false
            if (curr[curr.Length - 1] < enemyCard[1])
                return false;
            // tìm đôi lớn nhất 
            for (int i = curr.Length - 1; i > 0; i--)
            {
                // có đôi và curr lớn của đôi lớn hơn cardmax của địch
                if (curr[i] > enemyCard[1])
                {
                    if (curr[i] / 10 == curr[i - 1] / 10)
                        return true;
                }
                else
                    return false;

            }
            return false;
        }

        private bool checktriple(int[] curr) // đánh ba
        {
            // curr max < enemyCard max => false
            if (curr[curr.Length - 1] < enemyCard[2])
                return false;
            // tìm ba lớn nhất 
            for (int i = curr.Length - 1; i > 1; i--)
            {
                // có ba và curr lớn của ba lớn hơn cardmax của địch
                if (curr[i] > enemyCard[2])
                {
                    if (curr[i] / 10 == curr[i - 1] / 10 && curr[i] / 10 == curr[i - 2] / 10)
                        return true;
                }
                else
                    return false;
            }
            return false;
        }

        private bool checkquadra(int[] curr)// tứ quý
        {
            // curr max < enemyCard min => false
            if (curr[curr.Length - 1] < enemyCard[0])
                return false;
            // tìm tứ quý lớn nhất 
            for (int i = curr.Length - 1; i > 2; i--)
            {
                // có tứ quý và curr lớn của tứ quý lớn hơn cardmax của địch
                if (curr[i] > enemyCard[0])
                {
                    if (curr[i] / 10 == curr[i - 1] / 10 && curr[i] / 10 == curr[i - 2] / 10 && curr[i] / 10 == curr[i - 3] / 10)
                        return true;
                }
                else
                    return false;
            }
            return false;
        }

        private bool checkgroup(int[] curr) // check sảnh
        {
            if (curr.Length < 3)
                return false;
            //chuỗi số khác nhau
            List<int> arrayIncreased = new List<int>();
            int j;
            for (j = curr.Length - 1; j >= 0; j--)
            {
                if (curr[j] / 10 != 15)
                {
                    arrayIncreased.Add(curr[j]);
                    break;
                }
            }

            for (int i = j - 1; i >= 0; i--)
            {
                if (curr[i] / 10 < curr[i + 1] / 10)
                    arrayIncreased.Add(curr[i]);
            }

            // curr max < enemyCard min => false
            if (arrayIncreased.Count == 0 || arrayIncreased[0] < enemyCard[enemyCard.Length - 1])
                return false;

            int dem = 1;
            for (int i = 0; i < arrayIncreased.Count - 1; i++)
            {
                if (arrayIncreased[i] / 10 == arrayIncreased[i + 1] / 10 + 1)
                    dem++;
                else
                    dem = 1;
                if (dem == enemyCard.Length && arrayIncreased[i - dem + 2] > enemyCard[enemyCard.Length - 1])
                    return true;
            }
            return false;
        }

        private bool checkdoublegroup(int[] curr, int len)
        {
            //mảng các đôi
            int temp = 0;
            List<int> arrdouble = new List<int>();
            for (int i = curr.Length - 1; i > 0; i--)
            {
                if (curr[i] / 10 == curr[i - 1] / 10 && curr[i] / 10 != 15)
                {
                    if (curr[i] / 10 != temp)
                    {
                        arrdouble.Add(curr[i]);
                        arrdouble.Add(curr[i - 1]);
                        temp = curr[i] / 10;
                    }
                    i--;
                }
            }
            // curr max < enemyCard max => false
            if (arrdouble[0] < enemyCard[enemyCard.Length - 1])
                return false;

            int dem = 1;
            for (int i = 0; i < arrdouble.Count - 2; i = i + 2)
            {
                if (arrdouble[i] / 10 == arrdouble[i + 2] / 10 + 1)
                    dem++;
                else
                    dem = 1;
                if (dem * 2 == enemyCard.Length && arrdouble[i + 4 - len * 2] > enemyCard[enemyCard.Length - 1])
                    return true;
            }
            return false;

        }

        private bool finddoublegroup(int[] myCard, int num)
        {

            //mảng các đôi
            List<int> arrdouble = new List<int>();
            for (int i = myCard.Length - 1; i > 0; i--)
            {
                if (myCard[i] / 10 == myCard[i - 1] / 10)
                {
                    arrdouble.Add(myCard[i]);
                    arrdouble.Add(myCard[i - 1]);
                    i--;
                }
            }

            int dem = 1;
            for (int i = 0; i < arrdouble.Count - 2; i = i + 2)
            {
                if (arrdouble[i] / 10 == arrdouble[i + 2] / 10 + 1)
                    dem++;
                else
                    dem = 1;
                if (num == dem)
                    return true;
            }
            return false;

        }
        private bool findquadra(int[] myCard)
        {
            for (int i = myCard.Length - 1; i > 2; i--)
            {
                if (myCard[i] / 10 == myCard[i - 1] / 10 && myCard[i] / 10 == myCard[i - 2] / 10 && myCard[i] / 10 == myCard[i - 3] / 10)
                    return true;
            }
            return false;
        }
        private bool issingle()
        {
            if (currentCard.Length == 1)
                return true;
            else
                return false;
        }
        private bool isdouble()
        {
            if (currentCard.Length == 2 && currentCard[0] / 10 == currentCard[1] / 10)
                return true;
            else
                return false;
        }

        private bool istriple()
        {
            if (currentCard.Length == 3 && currentCard[0] / 10 == currentCard[1] / 10 && currentCard[1] / 10 == currentCard[2] / 10)
                return true;
            else
                return false;
        }

        private bool isquadra()
        {
            if (currentCard.Length == 4 && currentCard[0] / 10 == currentCard[1] / 10 && currentCard[1] / 10 == currentCard[2] / 10 && currentCard[2] / 10 == currentCard[3] / 10)
                return true;
            else
                return false;
        }

        private bool isgroup()// sanhr
        {
            if (currentCard.Length >= 3)
            {
                for (int i = 0; i < currentCard.Length - 1; i++)
                {
                    if (currentCard[i] / 10 + 1 != currentCard[i + 1] / 10)
                        return false;
                }
                return true;
            }
            return false;
        }

        private bool isdoublegroup(int len)
        {
            if (currentCard.Length == len * 2)
            {
                for (int i = 0; i < currentCard.Length - 2; i = i + 2)
                {

                    if (currentCard[i] / 10 + 1 != currentCard[i + 2] / 10)
                        return false;
                }
                return true;
            }
            return false;
        }

        // kiểm tra sau khi chọn bài để đánh có hợp lệ không
        public bool checkcurrent()
        {
            // ban đầu enemyCard = null ( bạn thư)
            // currentcard là chuỗi không giảm (bạn Hào)
            if (currentCard.Length == 0)
                return false;


            if (enemyCard == null || enemyCard.Length == 0) // người thắng đánh đầu tiên
            {
                if (issingle() == true || isdouble() == true || istriple() == true || isquadra() == true || isgroup() == true || isdoublegroup(3) == true || isdoublegroup(4) == true || isdoublegroup(5) == true)
                {
                    return true;
                }
                else
                    return false;
            }
            else
            {
                // đánh lẻ 
                if (enemyCard.Length == 1)
                {
                    // đánh lẻ =2
                    if (enemyCard[0] / 10 == 15)
                    {
                        if (issingle() && checksingle(currentCard))
                            return true;
                        else if (isdoublegroup(3) || isquadra())
                            return true;
                        else
                            return false;
                    }
                    else
                    {
                        if (checksingle(currentCard) && issingle())
                            return true;
                        else
                            return false;
                    }
                }

                // đánh đôi
                if (enemyCard.Length == 2)
                {
                    // đánh đôi 2
                    if (enemyCard[0] / 10 == 15)
                    {
                        if (checkdouble(currentCard) && isdouble())
                            return true;
                        else if (isdoublegroup(4) || isquadra())
                            return true;
                        else if (checkquadra(currentCard) == true && isquadra())
                            return true;
                    }
                    else
                    {
                        if (checkdouble(currentCard) && isdouble())
                            return true;
                        else
                            return false;
                    }
                }
                // đaanhs 3
                if (enemyCard.Length == 3 && enemyCard[0] / 10 == enemyCard[1] / 10)
                {
                    if (checktriple(currentCard) && istriple())
                        return true;
                    else
                        return false;
                }
                // đánh tứ quý
                if (enemyCard.Length == 4 && enemyCard[0] / 10 == enemyCard[3] / 10)
                {
                    if (checkquadra(currentCard) && isquadra())
                        return true;
                    else
                        return false;
                }
                // đánh 3 đôi thông
                if (enemyCard.Length == 6 && enemyCard[0] / 10 == enemyCard[1] / 10)
                {
                    if (isquadra())
                        return true;
                    if (checkdoublegroup(currentCard, 3) && isdoublegroup(3))
                        return true;
                }
                // đánh đôi thông > 3
                if (enemyCard.Length >= 8 && enemyCard[0] / 10 == enemyCard[1] / 10)
                {
                    if (isdoublegroup(enemyCard.Length / 2) && checkdoublegroup(currentCard, enemyCard.Length / 2))
                        return true;
                    else
                        return false;
                }
                // còn lại là đánh sảnh
                if (isgroup() && checkgroup(currentCard))
                    return true;
                return false;
            }
        }

    }
}