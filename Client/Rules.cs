using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Rules
    {
        int[] enamyCard;
        int [] myCard ;
        public Rules(string curentCard, string dataReceive)
        {
            string[] myCardstr = curentCard.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string[] enamyCardstr = dataReceive.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            myCard = Array.ConvertAll<string, int>(myCardstr, int.Parse);
            enamyCard = Array.ConvertAll<string, int>(enamyCardstr, int.Parse);

        }
        public void check()
        {
            // đánh lẻ mà đánh 2
            // đánh đôi 2
        }

        private bool checksingle() // đánh lẻ
        {
            // mycard max của mình > enamycard
            if (myCard[myCard.Length - 1] > enamyCard[0])
                return true;
            else
                return false;          
        }

        private bool checkdouble() // đánh đôi
        {
            // mycard max < enamycard max => false
            if (myCard[myCard.Length - 1] < enamyCard[1])
                return false;
            // tìm đôi lớn nhất 
            for(int i = myCard.Length -1; i >0; i--)
            {
                // có đôi và mycard lớn của đôi lớn hơn cardmax của địch
                if (myCard[i] > enamyCard[1])
                {
                    if (myCard[i] / 10 == myCard[i - 1] / 10)
                        return true;
                }
                else
                    return false;
                
            }
            return false;         
        }

        private bool checktriple() // đánh ba
        {
            // mycard max < enamycard max => false
            if (myCard[myCard.Length - 1] < enamyCard[2])
                return false;
            // tìm ba lớn nhất 
            for (int i = myCard.Length - 1; i > 1; i--)
            {
                // có ba và mycard lớn của ba lớn hơn cardmax của địch
                if(myCard[i] > enamyCard[2])
                {
                    if (myCard[i] / 10 == myCard[i - 1] / 10 && myCard[i] / 10 == myCard[i - 2])
                        return true;
                    else
                        return false;
                }             
            }
            return false;
        }

        private bool checkquadra()// tứ quý
        {
            // mycard max < enamycard min => false
            if (myCard[myCard.Length - 1] < enamyCard[0])
                return false;
            // tìm tứ quý lớn nhất 
            for (int i = myCard.Length - 1; i > 2; i--)
            {
                // có tứ quý và mycard lớn của tứ quý lớn hơn cardmax của địch
                if (myCard[i] > enamyCard[0])
                {
                    if (myCard[i] / 10 == myCard[i - 1] / 10 && myCard[i] / 10 == myCard[i - 2] && myCard[i] / 10 == myCard[i - 3])
                        return true;
                }
                else
                    return false;          
            }
            return false;
        }

        private bool checkgroup() // check sảnh
        {
            //chuỗi số khác nhau
            List<int> arrayIncreased = new List<int>();
            arrayIncreased.Add(myCard[0]); 
            for(int i = 1; i<myCard.Length -1; i++)
            {
                if (myCard[i] / 10 == 15)
                    break;
                if (myCard[i] > myCard[i - 1])
                    arrayIncreased.Add(myCard[i]);
            }


            // mycard max < enamycard min => false
            if (myCard[myCard.Length - 1] < enamyCard[enamyCard.Length -1])
                return false;

            int dem = 1;
            for (int i = arrayIncreased.Count -1; i>0; i--)
            {
                if (arrayIncreased[i] == arrayIncreased[i - 1] + 1)
                    dem++;
                else
                    dem = 1;
                if (dem == enamyCard.Length && myCard[i + dem -2] > enamyCard[enamyCard.Length - 1])
                    return true;
            }
            return false;
        }

        private bool checkdoublegroup(int len)
        {
            //mảng các đôi
            List<int> arraydouble = new List<int>();
            for (int i = myCard.Length -1; i >0; i--)
            {
                if (myCard[i] == myCard[i - 1])
                {
                    arraydouble.Add(myCard[i]);
                    arraydouble.Add(myCard[i - 1]);
                    i--;
                }
            }
            return false;
            

        }

        private bool checkthreedouble(List<int> arrdouble)
        {
            // mycard max < enamycard max => false
            if (arrdouble[arrdouble.Count -1] < enamyCard[5])
                return false;

            int dem = 1;
            for (int i = arrdouble.Count - 1; i > 2; i = i -2)
            {
                if (arrdouble[i] == arrdouble[i - 2] + 1)
                    dem++;
                else
                    dem = 1;
                if (dem * 2 == enamyCard.Length && myCard[i + 2] > enamyCard[5])
                    return true;
            }
            return false;

        }
        //check sigal // lẻ
        //    check double // đôi
        //    check trippel // check 3
        //    check quara quara // check tứ quý
        //    ckeck goup
        //    check 3đoithong
        //    check  4 đôithoong
        //    //check 5đoi


    }
}
