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
            dataReceive = dataReceive.Remove(0, 9);
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
        //public void setmyCard(string datareceive)
        //{
        //    string[] mystr = datareceive.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

        //    if (int.Parse(mystr[0]) < 31)
        //    {
        //        string[] mystr2 = new string[mystr.Length - 1];
        //        Array.Copy(mystr, 1, mystr2, 0, mystr.Length - 1);
        //        myCard = Array.ConvertAll<string, int>(mystr2, int.Parse);
        //    }
        //    else if (int.Parse(mystr[mystr.Length - 1]) > 154)
        //    {
        //        string[] mystr2 = new string[mystr.Length - 1];
        //        Array.Copy(mystr, 0, mystr2, 0, mystr.Length - 1);
        //        myCard = Array.ConvertAll<string, int>(mystr2, int.Parse);
        //    }
        //    else
        //        myCard = Array.ConvertAll<string, int>(mystr, int.Parse);
        //}

        public Rules() { }
        //public Heo(string mycard, string enemy)
        //{
        //    string[] mystr = mycard.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        //    myCard = Array.ConvertAll<string, int>(mystr, int.Parse);
        //    string[] enemystr = enemy.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        //    enemyCard = Array.ConvertAll<string, int>(enemystr, int.Parse);
        //}
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
                    if (checksingle(myCard) == true || finddoublegroup(myCard, 3) == true || findquadra() == true)
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
                    if (checkdouble(myCard) == true || findquadra() == true || finddoublegroup(myCard, 4) == true)
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
                if (checkquadra(myCard).Length != 0 || finddoublegroup(myCard, 4))
                    return true;
                else
                    return false;
            }
            // đánh 3 đôi thông
            if (enemyCard.Length == 6 && enemyCard[0] / 10 == enemyCard[1] / 10)
            {
                if (checkdoublegroup(myCard, 3).Length == 6 || findquadra() || finddoublegroup(myCard, 4))
                    return true;
                return false;
            }
            // đánh đôi thông > 3
            if (enemyCard.Length >= 8 && enemyCard[0] / 10 == enemyCard[1] / 10)
            {
                if (checkdoublegroup(myCard, enemyCard.Length / 2).Length != 0)
                    return true;
                return false;
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
        private int[] checkquadra(int[] position)// tứ quý
        {
            int[] tmp = new int[4];
            // curr max < enemyCard min => false
            if (myCard[myCard.Length - 1] < enemyCard[0])
                return tmp;
            // tìm tứ quý lớn nhất 
            for (int i = myCard.Length - 1; i > 2; i--)
            {
                // có tứ quý và curr lớn của tứ quý lớn hơn cardmax của địch
                if (myCard[i] > enemyCard[0])
                {
                    if (myCard[i] / 10 == myCard[i - 1] / 10 && myCard[i] / 10 == myCard[i - 2] / 10 && myCard[i] / 10 == myCard[i - 3] / 10)
                    {
                        for (int j = 0; j < position.Length; j++)
                        {
                            if (myCard[i] == position[j])
                            {
                                tmp[0] = i - 3;
                                tmp[1] = i - 2;
                                tmp[2] = i - 1;
                                tmp[3] = i;
                                return tmp;
                            }
                        }
                    }
                }
                else
                    return tmp;
            }
            return tmp;
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
        private int[] checkdoublegroup(int[] position, int num)
        {
            List<int> arrdouble = new List<int>(); // mảng các đôi
            for (int i = myCard.Length - 1; i > 0; i--)
            {
                if (myCard[i] / 10 == myCard[i - 1] / 10 && myCard[i] / 10 != 15)
                {
                    arrdouble.Add(myCard[i]);
                    arrdouble.Add(myCard[i - 1]);
                }
            }

            for (int i = 0; i < arrdouble.Count - 2; i += 2)
            {
                if (arrdouble[i] / 10 == arrdouble[i + 2] / 10)
                {
                    arrdouble.Remove(arrdouble[i]);
                    arrdouble.Remove(arrdouble[i + 1]);
                }
            }

            int[] tmp = new int[num * 2];

            if (arrdouble.Count == 0)
                return tmp;
            if (arrdouble[0] < enemyCard[enemyCard.Length - 1])
                return tmp;

            int dem = 1;
            int p = 0;
            for (int i = 0; i < arrdouble.Count - 2; i = i + 2)
            {
                if (arrdouble[i] / 10 == arrdouble[i + 2] / 10 + 1)
                    dem++;
                else
                    dem = 1;
                if (num * 2 == dem && arrdouble[i + 4 - num * 2] > enemyCard[enemyCard.Length - 1])
                {
                    arrdouble.Reverse();
                    i = arrdouble.Count - i;
                    for (int j = i + (dem - 2) * 2 - (dem * 2); j <= dem * 2; j++)
                    {
                        for (int k = 0; k < position.Length; k++)
                        {
                            if (myCard[j] == position[k])
                            {
                                tmp[p++] = k;
                                break;
                            }
                        }
                    }
                    return tmp;
                }
            }
            return tmp;
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
        private bool findquadra()
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
        private bool isgroup(int[] curr)// sanhr
        {
            if (curr.Length >= 3)
            {
                for (int i = 0; i < curr.Length - 1; i++)
                {
                    if (curr[i] / 10 + 1 != curr[i + 1] / 10)
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
                if (issingle() == true || isdouble() == true || istriple() == true || isquadra() == true || isgroup(currentCard) == true || isdoublegroup(3) == true || isdoublegroup(4) == true || isdoublegroup(5) == true)
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
                        else if (isdoublegroup(3) || isquadra() || isdoublegroup(4))
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
                        else if (checkquadra(myCard).Length != 0 && isquadra())
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
                    if (checkquadra(myCard).Length != 0 && isquadra())
                        return true;
                    else
                        return false;
                }
                // đánh 3 đôi thông
                if (enemyCard.Length == 6 && enemyCard[0] / 10 == enemyCard[1] / 10)
                {
                    if (isquadra())
                        return true;
                    if (checkdoublegroup(myCard, 3).Length != 0 && isdoublegroup(3))
                        return true;
                }
                // đánh đôi thông > 3
                if (enemyCard.Length >= 8 && enemyCard[0] / 10 == enemyCard[1] / 10)
                {
                    if (isdoublegroup(enemyCard.Length / 2) && checkdoublegroup(myCard, enemyCard.Length / 2).Length != 0)
                        return true;
                    else
                        return false;
                }
                // còn lại là đánh sảnh
                if (isgroup(currentCard) && checkgroup(currentCard))
                    return true;
                return false;
            }
        }
        private List<int[]> MangCacDoi(int[] position)
        {
            List<int[]> result = new List<int[]>();
            int[] tmp = { -1, -1 };
            if (myCard.Length < 2)
                return result;
            List<int> arrdouble = new List<int>(); // mảng các đôi
            for (int i = myCard.Length - 1; i > 0; i--)
            {
                if (myCard[i] / 10 == myCard[i - 1] / 10 && myCard[i] > enemyCard[1])
                {
                    arrdouble.Add(myCard[i]);
                    arrdouble.Add(myCard[i - 1]);
                }
            }
            arrdouble.Reverse();
            int k = 0;
            for (int j = 0; j < arrdouble.Count; j++)
            {
                for (int i = 0; i < position.Length; i++)
                {
                    if (arrdouble[j] == position[i])
                    {
                        tmp[k] = i;
                        k++;
                        if (tmp[1] != -1)
                        {
                            k = 0;
                            int[] tmp2 = new int[2];
                            Array.Copy(tmp, 0, tmp2, 0, 2);
                            result.Add(tmp2);
                            tmp[1] = -1;
                        }
                        break;
                    }
                }
            }
            return result;
        }
        private List<int[]> MangBaCay(int[] position)
        {
            List<int[]> result = new List<int[]>();
            int[] tmp = { 0, 0, 0 };
            if (myCard.Length < 3)
                return result;
            List<int> arrdouble = new List<int>();
            for (int i = myCard.Length - 1; i > 1; i--)
            {
                if (myCard[i] > enemyCard[1] && myCard[i] / 10 == myCard[i - 1] / 10 && myCard[i] / 10 == myCard[i - 2] / 10)
                {
                    arrdouble.Add(myCard[i]);
                    arrdouble.Add(myCard[i - 1]);
                    arrdouble.Add(myCard[i - 2]);
                }
            }
            arrdouble.Reverse();
            for (int j = 0; j < arrdouble.Count; j++)
            {
                for (int i = 0, k = 0; i < position.Length; i++)
                {
                    if (arrdouble[j] == position[i])
                    {
                        tmp[k] = i;
                        k++;
                    }
                    if (tmp[2] != 0)
                    {
                        k = 0;
                        result.Add(tmp);
                        tmp[2] = 0;
                    }
                }
            }
            return result;
        }
        private List<int[]> MangCacSanh(int[] position)
        {
            List<int> arrayIncreased = new List<int>();
            int j;
            int sl = enemyCard.Length;
            for (j = myCard.Length - 1; j >= 0; j--)
            {
                if (myCard[j] / 10 != 15)
                {
                    arrayIncreased.Add(myCard[j]);
                    break;
                }
            }

            for (int i = j - 1; i >= 0; i--)
                if (myCard[i] / 10 < myCard[i + 1] / 10)
                    arrayIncreased.Add(myCard[i]);

            arrayIncreased.Reverse();
            List<int[]> result = new List<int[]>();

            if (arrayIncreased.Count < sl)
                return result;

            for (int i = 0; i < arrayIncreased.Count - sl + 1; i++)
            {
                int[] mangtam = new int[sl];
                int[] tmp = new int[sl];
                Array.Copy(arrayIncreased.ToArray(), i, mangtam, 0, sl);
                for (int k = 0; k < mangtam.Length - 1; k++)
                    for (int l = 0; l < myCard.Length; l++)
                        if (mangtam[k] / 10 == myCard[l] / 10 && mangtam[k] > myCard[l])
                            mangtam[k] = myCard[l];

                if (mangtam[sl - 1] > enemyCard[sl - 1] && isgroup(mangtam) == true)
                {
                    mangtam.Reverse();
                    for (int k = 0; k < mangtam.Length; k++)
                    {
                        for (int m = 0; m < position.Length; m++)
                        {
                            if (mangtam[k] == position[m])
                            {
                                tmp[k] = m;
                                break;
                            }
                        }
                    }
                    result.Add(tmp);
                }
            }
            return result;
        }
        public int[] setclickcards(int[] position, int id)
        {
            int[] result = { id };
            if (enemyCard == null || enemyCard.Length == 0 /*|| check() == false*/)
                return result;

            if (enemyCard.Length == 1)
            {
                if (enemyCard[0] / 10 == 15)
                {
                    int[] tmp1 = checkdoublegroup(position, 4);
                    if (tmp1.Length != 0 && tmp1.Contains(id) == true)
                        return tmp1;

                    int[] tmp2 = checkdoublegroup(position, 2);
                    if (tmp2.Length != 0 && tmp2.Contains(id) == true)
                        return tmp2;
                    int[] tmp3 = checkquadra(position);
                    if (tmp3.Length != 0 && tmp3.Contains(id) == true)
                        return checkquadra(position);
                }
            }
            else if (enemyCard.Length == 2)
            {
                for (int i = 0; i < MangCacDoi(position).Count; i++)
                    if (MangCacDoi(position)[i].Contains(id))
                        return MangCacDoi(position)[i];
                if (enemyCard[0] / 10 == 15)
                {
                    int[] tmp1 = checkdoublegroup(position, 3);
                    if (tmp1.Length != 0 && tmp1.Contains(id) == true)
                        return tmp1;
                    int[] tmp2 = checkquadra(position);
                    if (tmp2.Length != 0 && tmp2.Contains(id) == true)
                        return tmp2;
                }
            }
            else if (enemyCard.Length == 3 && enemyCard[0] / 10 == enemyCard[1] / 10)
            {
                for (int i = 0; i < MangBaCay(position).Count; i++)
                    if (MangBaCay(position)[i].Contains(id))
                        return MangBaCay(position)[i];
            }
            else if (enemyCard.Length == 4 && enemyCard[0] / 10 == enemyCard[3] / 10)
            {
                int[] tmp = checkquadra(position);
                if (tmp.Length != 0 && tmp.Contains(id) == true)
                    return tmp;
            }
            else if (enemyCard.Length == 6 && enemyCard[0] / 10 == enemyCard[1] / 10)
            {
                int[] tmp1 = checkquadra(position);
                if (tmp1.Length != 0 && tmp1.Contains(id) == true)
                    return tmp1;
                int[] tmp2 = checkdoublegroup(position, 3);
                if (tmp2.Length != 0 && tmp2.Contains(id) == true)
                    return tmp2;
            }
            else if (enemyCard.Length >= 8 && enemyCard[0] / 10 == enemyCard[1] / 10)
            {
                int[] tmp = checkdoublegroup(position, enemyCard.Length / 2);
                if (tmp.Length != 0 && tmp.Contains(id) == true)
                    return tmp;
            }
            else
            {
                for (int i = 0; i < MangCacSanh(position).Count; i++)
                    if (MangCacSanh(position)[i].Contains(id))
                        return MangCacSanh(position)[i];
            }
            return result;
        }
        public int[] setclickcards2(int[] position, int id)
        {
            int[] temp = setclickcards(position, 12 - id);
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = 12 - temp[i];

            }

            return temp;
        }
    }

}