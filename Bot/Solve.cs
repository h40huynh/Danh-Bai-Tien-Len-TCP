using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bot
{
    class Solve
    {
        int[] myCard;
        int[] enemyCard;
        public Solve()
        {
        }
        public Solve(string dataReceive, string baidoithu)
        {
            string[] mystr = dataReceive.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            myCard = Array.ConvertAll<string, int>(mystr, int.Parse);
            
            string[] enemystr = baidoithu.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            enemyCard = Array.ConvertAll<string, int>(enemystr, int.Parse);
        }
        public void setEnemyCard(string dataReceive)
        {
            dataReceive = dataReceive.Remove(0, 9);
            string[] enemystr = dataReceive.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            enemyCard = Array.ConvertAll<string, int>(enemystr, int.Parse);
            Array.Reverse(enemyCard);
        }
        public void setmyCard(string datareceive)
        {
            string[] mystr = datareceive.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            myCard = Array.ConvertAll<string, int>(mystr, int.Parse);
            for (int i = 0; i < myCard.Length - 1; i++)
                for (int j = i + 1; j < myCard.Length; j++) 
                    if (myCard[i] > myCard[j]) 
                    {
                        int temp = myCard[i];
                        myCard[i] = myCard[j];
                        myCard[j] = temp;
                    }
        }
        private bool KiemTraSanh(int[] curr)
        {
            int dem = 1;
            for (int i = 0; i < curr.Length - 1; i++)
            {
                if (curr[i] / 10 + 1 == curr[i + 1] / 10)
                    dem++;
                else
                    dem = 1;
                if (dem == curr.Length)
                    return true;
            }
            return false;
        }
        private int[] KiemTraDoi(int[] curr)
        {
            int[] mangdoi = { 0, 0 };
            if (curr[curr.Length - 1] < enemyCard[1])
                return mangdoi;
            // tìm đôi lớn nhất 
            for (int i = 1; i < curr.Length - 1; i++)
            {
                // có đôi và curr lớn của đôi lớn hơn cardmax của địch
                if (curr[i] > enemyCard[1])
                {
                    if (curr[i] / 10 == curr[i - 1] / 10)
                    {
                        mangdoi[0] = curr[i - 1];
                        mangdoi[1] = curr[i];
                        return mangdoi;
                    }
                }
            }
            return mangdoi;
        }
        // có đôi thông hoặc tứ quí sẽ ưu tiên cóc lẻ
        private int[] MangCacDoi()
        {
            List<int> arrdouble = new List<int>(); // mảng các đôi
            for (int i = myCard.Length - 1; i > 0; i--)
            {
                if (myCard[i] / 10 == myCard[i - 1] / 10 && myCard[i] / 10 != 15)
                {
                    arrdouble.Add(myCard[i]);
                    arrdouble.Add(myCard[i - 1]);
                    i--;
                }
            }
            return arrdouble.ToArray();
        }
        private int[] CoDoiThong(int num)
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
            int dem = 1;
            for (int i = 0; i < arrdouble.Count - 2; i = i + 2)
            {
                if (arrdouble[i] / 10 == arrdouble[i + 2] / 10 + 1)
                    dem++;
                else
                    dem = 1;
                if (num == dem)
                {
                    arrdouble.Reverse();
                    i = arrdouble.Count - i;
                    Array.Copy(arrdouble.ToArray(), (i + (dem - 2) * 2 - (dem * 2)), tmp, 0, dem * 2);
                    return tmp;
                }
            }

            tmp[0] = 0;
            return tmp;
        }
        private int[] CoTuQui(int[] curr)
        {
            int[] tmp = new int[4];
            for (int i = curr.Length - 1; i > 2; i--)
            {
                if (curr[i] / 10 == curr[i - 1] / 10 && curr[i] / 10 == curr[i - 2] / 10 && curr[i] / 10 == curr[i - 3] / 10)
                {
                    Array.Copy(curr, i - 3, tmp, 0, 4);
                    return tmp;
                }
            }
            tmp[0] = 0;
            return tmp;
        }
        private int DemCocLon(int[] arr)
        {
            int dem = 0;
            for (int i = arr.Length - 1; i >= 0; i--)
                if (arr[i] / 10 >= 12)
                    dem++;
            for (int i = myCard.Length - 1; i >= 0; i--)
                if (myCard[i] / 10 == 15)
                    dem++;
                else
                    break;
            return dem;
        }
        // các bài hiếm nếu có thì đánh trước
        private int[] CoBaCay(int[] curr)
        {
            int[] tmp = new int[3];

            for (int i = curr.Length - 1; i > 1; i--)
            {
                if (curr[i] / 10 == curr[i - 1] / 10 && curr[i] / 10 == curr[i - 2] / 10)
                {
                    tmp[0] = curr[i - 2];
                    tmp[1] = curr[i - 1];
                    tmp[2] = curr[i];
                    return tmp;
                }
            }
            tmp[0] = 0;
            return tmp;
        }
        private bool CoSanhLon(int num)
        {
            List<int> arrayIncreased = new List<int>();
            int j;
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

            int dem = 1;
            for (int i = 0; i < arrayIncreased.Count - 1; i++)
            {
                if (arrayIncreased[i] / 10 == arrayIncreased[i + 1] / 10 + 1)
                    dem++;
                else
                    dem = 1;
                if (dem == num)
                    return true;
            }
            return false;
        } // sảnh >=7
        private bool TheManhDoi(int[] curr)
        {
            List<int> MangCacDoi = new List<int>();
            for (int i = 0; i < curr.Length - 1; i++)
            {
                if (curr[i] / 10 == curr[i + 1] / 10)
                {
                    MangCacDoi.Add(curr[i + 1]);// lưu con lớn nhất trong đôi
                    i++;
                }
            }
            if (curr.Length < 4 && MangCacDoi.Count == 1) //3 cây còn một đôi
                return true;

            if (MangCacDoi.Count == 1)
                return false;
            // đôi lớn hơn nữa số bài còn lại và trong đôi có nữa phần >=10
            if (MangCacDoi.Count * 2 > curr.Length / 2 && MangCacDoi[(MangCacDoi.Count / 2)] / 10 >= 10)
                return true;
            return false;
        }
        private int[] DoiNhoNhat(int[] curr)
        {
            int[] tmp = { 0, 0 };
            for (int i = 0; i < curr.Length - 1; i++)
            {
                if (curr[i] / 10 == curr[i + 1] / 10)
                {
                    tmp[0] = curr[i];
                    tmp[1] = curr[i + 1];
                    return tmp;
                }
            }
            return tmp;
        }
        private int[] SanhNhoNhat(int[] curr, int num)
        {
            int[] tmp = KiemTraCoSanh(curr, num);
            return curr.Except(tmp).ToArray();
        }
        static int partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = (low - 1);
            for (int j = low; j < high; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            int temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;
            return i + 1;
        }
        static void quickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = partition(arr, low, high);
                quickSort(arr, low, pi - 1);
                quickSort(arr, pi + 1, high);
            }
        }
        private int[] KiemTraCoSanh(int[] tmp, int sl)
        {
            List<int> arrayIncreased = new List<int>();
            int j;
            for (j = tmp.Length - 1; j >= 0; j--)
            {
                if (tmp[j] / 10 != 15)
                {
                    arrayIncreased.Add(tmp[j]);
                    break;
                }
            }

            for (int i = j - 1; i >= 0; i--)
            {
                if (tmp[i] / 10 < tmp[i + 1] / 10)
                    arrayIncreased.Add(tmp[i]);
            }
            arrayIncreased.Reverse();
            int[] mangconlai = new int[tmp.Length - arrayIncreased.Count];
            mangconlai = tmp.Except(arrayIncreased).ToArray();

            int dem = 1;
            for (int i = 0; i < arrayIncreased.Count - 1; i++)
            {
                if (arrayIncreased[i] / 10 + 1 == arrayIncreased[i + 1] / 10)
                    dem++;
                else
                    dem = 1;
                if (dem == sl)
                {
                    i += 2;

                    int[] mangtam = new int[sl];
                    Array.Copy(arrayIncreased.ToArray(), i - sl, mangtam, 0, sl);

                    int[] mangtam2 = new int[arrayIncreased.Count - sl];
                    mangtam2 = arrayIncreased.Except(mangtam).ToArray();

                    int[] mangtam3 = new int[tmp.Length - sl];
                    mangtam3 = mangtam2.Concat(mangconlai).ToArray();
                    quickSort(mangtam3, 0, mangtam3.Length - 1);

                    //for (int k = 0; k < mangtam3.Length - 1; k++)
                    //{
                    //    for (int l = 0; l < tmp.Length; l++)
                    //    {
                    //        if (mangtam3[k] / 10 == tmp[l] / 10 && mangtam3[k] < tmp[l] && mangtam3[k] / 10 != mangtam[mangtam.Length - 1] / 10)
                    //        {
                    //            if (k > 0)
                    //            {
                    //                if (tmp[l] != mangtam3[k - 1])
                    //                {
                    //                    mangtam3[k] = tmp[l];
                    //                    break;
                    //                }
                    //            }
                    //            else
                    //            {
                    //                mangtam3[k] = tmp[l];
                    //                break;
                    //            }
                    //        }
                    //    }
                    //}
                    return mangtam3;
                }
            }
            return tmp;

        }
        private int TheManhSanh(int[] curr)
        {
            List<int> MangCacSanh = new List<int>();
            // xét theo số lượng mycard     số lượng sảnh >= mycard/2 và có sảnh đi sảnh về
            // =<5 có 1 sảnh 3 hoặc 4 hoặc 5 
            // <=6 có sảnh 4 hoặc 5 hoặc 6 hoặc 2 sảnh 3
            // <=7 có sảnh 4 hoặc 5 hoặc 6 hoặc 2 sảnh 3, 1 sanhr3-1 sảnh 4
            // <=8 
            if (curr.Length < 3)
                return 0;
            switch (curr.Length)
            {
                case 3:
                    if (KiemTraCoSanh(curr, 3).Length == 0)
                        return 3;
                    break;
                case 4:
                    if (KiemTraCoSanh(curr, 4).Length == 0)
                        return 4;
                    else if (KiemTraCoSanh(curr, 3).Length == 1)
                        return 3;
                    break;
                case 5:
                    if (KiemTraCoSanh(curr, 5).Length == 0)
                        return 5;
                    else if (KiemTraCoSanh(curr, 4).Length == 1)
                        return 4;
                    else if (KiemTraCoSanh(curr, 3).Length == 2)
                        return 3;
                    break;
                case 6:
                    if (KiemTraCoSanh(curr, 6).Length == 0)
                        return 6;
                    else if (KiemTraCoSanh(KiemTraCoSanh(curr, 3), 3).Length == 0)
                        return 3;
                    else if (KiemTraCoSanh(curr, 5).Length == 1)
                        return 5;
                    else if (KiemTraCoSanh(curr, 4).Length == 2)
                        return 4;
                    break;

                case 7:
                    if (KiemTraCoSanh(curr, 6).Length == 1)
                        return 6;
                    else if (KiemTraCoSanh(KiemTraCoSanh(curr, 3), 3).Length == 1)
                        return 3;
                    else if (KiemTraCoSanh(curr, 5).Length == 2)
                        return 5;
                    break;
                case 8:
                    if (KiemTraCoSanh(KiemTraCoSanh(curr, 4), 4).Length == 0)
                        return 4;
                    else if (KiemTraCoSanh(curr, 6).Length == 2)
                        return 6;
                    if (KiemTraCoSanh(KiemTraCoSanh(curr, 3), 3).Length == 2)
                        return 3;
                    else if (KiemTraCoSanh(curr, 5).Length == 3)
                        return 5;
                    break;
                case 9:
                    if (KiemTraCoSanh(KiemTraCoSanh(curr, 4), 4).Length == 1)
                        return 4;
                    else if (KiemTraCoSanh(curr, 6).Length == 3)
                        return 6;
                    else if (KiemTraCoSanh(KiemTraCoSanh(curr, 3), 3).Length == 3)
                        return 3;

                    break;
                case 10:
                    if (KiemTraCoSanh(KiemTraCoSanh(curr, 5), 5).Length == 0)
                        return 5;
                    else if (KiemTraCoSanh(KiemTraCoSanh(curr, 4), 4).Length == 2)
                        return 4;
                    else if (KiemTraCoSanh(KiemTraCoSanh(curr, 3), 3).Length == 4)
                        return 3;
                    break;
                case 11:
                    if (KiemTraCoSanh(KiemTraCoSanh(curr, 5), 5).Length == 1)
                        return 5;
                    else if (KiemTraCoSanh(KiemTraCoSanh(curr, 4), 4).Length == 3)
                        return 4;
                    else if (KiemTraCoSanh(KiemTraCoSanh(curr, 3), 3).Length == 5)
                        return 3;
                    break;
                case 12:
                    if (KiemTraCoSanh(KiemTraCoSanh(curr, 6), 6).Length == 0)
                        return 6;
                    else if (KiemTraCoSanh(KiemTraCoSanh(curr, 5), 5).Length == 2)
                        return 5;
                    else if (KiemTraCoSanh(KiemTraCoSanh(curr, 4), 4).Length == 4)
                        return 4;
                    else if (KiemTraCoSanh(KiemTraCoSanh(curr, 3), 3).Length == 6)
                        return 3;
                    break;
                case 13:
                    if (KiemTraCoSanh(KiemTraCoSanh(curr, 6), 6).Length == 1)
                        return 6;
                    else if (KiemTraCoSanh(KiemTraCoSanh(curr, 5), 5).Length == 3)
                        return 5;
                    else if (KiemTraCoSanh(KiemTraCoSanh(curr, 4), 4).Length == 5)
                        return 4;
                    else if (KiemTraCoSanh(KiemTraCoSanh(curr, 3), 3).Length == 7)
                        return 3;
                    break;
                default:
                    break;
            }
            return 0;
        }
        private int[] DemLe(int[] curr)
        {
            List<int> MangCacDoi = new List<int>();

            if (TheManhDoi(myCard) == false)
            {
                int[] cocle = new int[curr.Length];
                Array.Copy(curr, 0, cocle, 0, curr.Length);
                for (int i = cocle.Length; i >= 3; i--)
                    if (KiemTraCoSanh(cocle, i).Length != cocle.Length)
                        cocle = KiemTraCoSanh(cocle, i);
                for (int i = 0; i < cocle.Length - 1; i++)
                {
                    if (cocle[i] / 10 == cocle[i + 1] / 10)
                    {
                        MangCacDoi.Add(cocle[i]);
                        MangCacDoi.Add(cocle[i + 1]);
                        i++;
                    }
                }

                for (int i = 1; i < MangCacDoi.Count; i += 2)
                    for (int j = 0; j < cocle.Length; j++)
                        if (MangCacDoi[i] / 10 == cocle[j] / 10 && MangCacDoi[i] < cocle[j])
                            MangCacDoi[i] = cocle[j];
                cocle = cocle.Except(MangCacDoi.ToArray()).ToArray();
                return cocle;
            }
            else
            {
                for (int i = 0; i < curr.Length - 1; i++)
                {
                    if (curr[i] / 10 == curr[i + 1] / 10)
                    {
                        MangCacDoi.Add(curr[i]);
                        MangCacDoi.Add(curr[i + 1]);
                        i++;
                    }
                }

                for (int i = 1; i < MangCacDoi.Count; i += 2)
                    for (int j = 0; j < curr.Length; j++)
                        if (MangCacDoi[i] / 10 == curr[j] / 10 && MangCacDoi[i] < curr[j])
                            MangCacDoi[i] = curr[j];

                int[] cocle = new int[curr.Length - MangCacDoi.Count];
                cocle = curr.Except(MangCacDoi.ToArray()).ToArray();

                for (int i = cocle.Length; i >= 3; i--)
                    if (KiemTraCoSanh(cocle, i).Length != cocle.Length)
                        cocle = KiemTraCoSanh(cocle, i);
                return cocle;
            }

        }
        private List<int[]> TimSanhPhuHop(int[] tmp, int[] enemy, int sl)
        {
            List<int> arrayIncreased = new List<int>();
            int j;
            for (j = tmp.Length - 1; j >= 0; j--)
            {
                if (tmp[j] / 10 != 15)
                {
                    arrayIncreased.Add(tmp[j]);
                    break;
                }
            }

            for (int i = j - 1; i >= 0; i--)
                if (tmp[i] / 10 < tmp[i + 1] / 10)
                    arrayIncreased.Add(tmp[i]);

            arrayIncreased.Reverse();
            List<int[]> result = new List<int[]>();

            if (arrayIncreased.Count < sl)
                return result;

            for (int i = 0; i < arrayIncreased.Count - sl + 1; i++)
            {
                int[] mangtam = new int[sl];
                Array.Copy(arrayIncreased.ToArray(), i, mangtam, 0, sl);
                for (int k = 0; k < mangtam.Length - 1; k++)
                    for (int l = 0; l < tmp.Length; l++)
                        if (mangtam[k] / 10 == tmp[l] / 10 && mangtam[k] > tmp[l])
                            mangtam[k] = tmp[l];

                if (mangtam[sl - 1] > enemy[sl - 1] && KiemTraSanh(mangtam) == true)
                    result.Add(mangtam);
            }
            return result;
        }
        private int[] SanhNhoDaiNhat(int[] curr)
        {
            List<int> mangtam = new List<int>();
            mangtam.Add(SanhNhoNhat(curr, 3)[0]);

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
                if (curr[i] / 10 < curr[i + 1] / 10)
                    arrayIncreased.Add(curr[i]);
            arrayIncreased.Reverse();

            int dem = 0;
            for (int i = 0; i < arrayIncreased.Count - 1; i++)
            {
                if (arrayIncreased[i] / 10 == mangtam[dem] / 10)
                {
                    if (arrayIncreased[i + 1] / 10 == mangtam[dem] / 10 + 1)
                    {
                        mangtam.Add(arrayIncreased[i + 1]);
                        dem++;
                    }
                    else
                        break;
                }
            }

            for (int k = 0; k < mangtam.Count - 1; k++)
                for (int l = 0; l < curr.Length; l++)
                    if (mangtam[k] / 10 == curr[l] / 10 && mangtam[k] > curr[l])
                        mangtam[k] = curr[l];

            return mangtam.ToArray();
        }
        private int[] ChonBaiDanh()
        {
            int[] cocle = new int[DemLe(myCard).Length];
            Array.Copy(DemLe(myCard), 0, cocle, 0, DemLe(myCard).Length);
            int[] mangtam = new int[1];
            //danh le truoc
            if (TheManhSanh(myCard) == 0 && TheManhDoi(myCard) == false)
            {
                if (cocle.Length == 0)
                {
                    if (KiemTraCoSanh(myCard, 3).Length != myCard.Length)
                    {
                        if (DoiNhoNhat(myCard)[0] < SanhNhoDaiNhat(myCard)[2])
                            return DoiNhoNhat(myCard);
                        else
                            return SanhNhoDaiNhat(myCard);
                    }
                    return DoiNhoNhat(myCard);
                }
                else
                {
                    if (DemLe(myCard).Length != myCard.Length)
                    {
                        if (KiemTraCoSanh(myCard, 3).Length != myCard.Length)
                        {
                            if (SanhNhoDaiNhat(myCard)[0] == myCard[0])
                                return SanhNhoDaiNhat(myCard);
                            return DoiNhoNhat(myCard);
                        }
                        else
                        {
                            if (DoiNhoNhat(myCard)[0] != 0 && DoiNhoNhat(myCard)[0] < DemLe(myCard)[0])
                                return DoiNhoNhat(myCard);
                            else
                            {
                                mangtam[0] = DemLe(myCard)[0];
                                return mangtam;
                            }
                        }
                    }
                    else
                    {
                        mangtam[0] = DemLe(myCard)[0];
                        return mangtam;
                    }
                }
            }
            else if (TheManhSanh(myCard) != 0 && TheManhDoi(myCard) == true)
            {
                if (cocle.Length == 0)
                {
                    return SanhNhoNhat(myCard, TheManhSanh(myCard)); // 1 laf ddanhs sanh
                }
                else
                    return DoiNhoNhat(myCard);
            }
            else
            {
                if (TheManhSanh(myCard) != 0)
                {
                    if (DemLe(myCard).Length != 0)
                    {
                        int dem = 0;
                        for (int k = 0; k < DemLe(myCard).Length; k++)
                        {
                            if (DemLe(myCard)[k] > SanhNhoNhat(myCard, TheManhSanh(myCard))[TheManhSanh(myCard) - 1])
                                dem++;
                            if (dem >= DemLe(myCard).Length / 2)
                                return SanhNhoNhat(myCard, TheManhSanh(myCard));
                        }
                    }
                }
                else
                {
                    if (DemLe(myCard).Length == 0)
                        return DoiNhoNhat(myCard);
                    if (DemLe(myCard)[0] < DoiNhoNhat(myCard)[0])
                    {
                        mangtam[0] = DemLe(myCard)[0];
                        return mangtam;
                    }
                    return DoiNhoNhat(myCard);
                }
            }
            return SanhNhoNhat(myCard, TheManhSanh(myCard));
        }
        public bool KiemTraThangTrang()
        {
            if (CoTuQui(myCard)[0] == 151 || CoSanhLon(12) || MangCacDoi().Length == 12)
                return true;
            return false;
        }
        public int[] DanhBaiChuDong()
        {
            if (myCard[0] < 31)
                myCard = myCard.Skip(1).ToArray();
            else if (myCard[myCard.Length - 1] > 154)
                myCard = myCard.SkipWhile(element => element > 154).ToArray();
            Console.WriteLine("\n");
            for (int i = 0; i < myCard.Length; i++)
                Console.Write(myCard[i] + " ");
           
            int[] result;
            int[] tmp;
            int length = 0;

            // co bai dac biet
            if (CoDoiThong(4)[0] != 0 || CoDoiThong(3)[0] != 0 || CoTuQui(myCard)[0] != 0)
            {
                int[] curr;
                if (CoTuQui(myCard)[0] != 0)
                    length = 4;
                else if (CoDoiThong(4)[0] != 0)
                    length = 8;
                else if (CoDoiThong(3)[0] != 0)
                    length = 6;

                if (length == myCard.Length)
                    return myCard;
                else
                {
                    curr = new int[length];
                    if (length == 4)
                        Array.Copy(CoTuQui(myCard), 0, curr, 0, 4);
                    else if (length == 8)
                        Array.Copy(CoDoiThong(4), 0, curr, 0, 8);
                    else if (length == 6)
                        Array.Copy(CoDoiThong(3), 0, curr, 0, 6);

                    tmp = myCard.Except(curr).ToArray();

                    if (DemLe(tmp).Length == 0)
                    {
                        if (DoiNhoNhat(tmp)[0] == 0)
                            return tmp;
                        else
                        {
                            if (KiemTraCoSanh(tmp, 3).Length != tmp.Length)
                                if (DoiNhoNhat(tmp)[0] < SanhNhoDaiNhat(tmp)[2])
                                    return DoiNhoNhat(tmp);
                                else
                                    return SanhNhoDaiNhat(tmp);
                            else
                                return DoiNhoNhat(tmp);
                        }
                    }
                    else
                    {
                        result = new int[1];
                        if (DemLe(tmp).Length == 0)
                            result[0] = DemLe(tmp)[0];
                        else
                        {
                            if (CoBaCay(tmp)[0] != 0 && CoBaCay(tmp)[0] / 10 < 13)
                                return CoBaCay(tmp);
                            else
                                result[0] = DemLe(tmp)[0];
                        }
                        return result;
                    }
                }
            }

            if (myCard[0] / 10 == 15)
                return myCard;

            if (myCard.Length >= 7)
            {
                for (int i = myCard.Length; i >= 7; i--)
                    if (CoSanhLon(i))
                        return SanhNhoNhat(myCard, i);

            }

            //chon danh 3 cay
            if (CoBaCay(myCard)[0] != 0)
            {
                if (myCard.Length == 3 || myCard.Length == 4)
                    return CoBaCay(myCard);
                else
                {
                    if (CoBaCay(myCard)[0] / 10 < 12)
                        if (CoBaCay(KiemTraCoSanh(myCard, 3))[0] != 0)
                            return CoBaCay(myCard);
                }
            }
            if (DemLe(myCard).Length != 0)
            {
                result = new int[1];
                result[0] = 0;
                if (KiemTraCoSanh(myCard, 3).Length != myCard.Length)
                {
                    if (DemLe(myCard)[0] < SanhNhoNhat(myCard, 3)[0])
                        result[0] = DemLe(myCard)[0];
                }
                else if (DoiNhoNhat(myCard)[0] != 0)
                    if (DemLe(myCard)[0] < DoiNhoNhat(myCard)[0])
                        result[0] = DemLe(myCard)[0];

                if (result[0] != 0)
                    return result;
            }

            if (myCard.Length < 4 && DoiNhoNhat(myCard)[0] != 0)
                return DoiNhoNhat(myCard);

            return ChonBaiDanh();
        }
        public int[] DanhBaiBiDong()
        {
            if (myCard[0] < 31)
                myCard = myCard.Skip(1).ToArray();
            if (myCard[myCard.Length - 1] > 154)
                myCard = myCard.SkipWhile(element => element > 154).ToArray();
            Console.WriteLine("\n");
            for (int i = 0; i < myCard.Length; i++)
                Console.Write(myCard[i] + " ");
            
            // return 0 == bo luot
            int[] boluot = { 0 };
            if (enemyCard.Length == 1) // danh le
            {
                int[] cocle = new int[1];
                if (enemyCard[0] / 10 == 15) // danh le la 2
                {
                    // bat 2
                    if (CoDoiThong(3)[0] != 0 && CoDoiThong(4)[0] == 0) // co doi thong
                        return CoDoiThong(3);
                    else if (CoTuQui(myCard)[0] != 0)
                        return CoTuQui(myCard);
                    else if (CoDoiThong(4)[0] != 0)
                        return CoDoiThong(4);
                    else if (myCard[myCard.Length - 1] > enemyCard[0])// co 2 lon hon
                    {
                        if (myCard.Length == 1)
                            return myCard;
                        for (int i = myCard.Length - 2; i >= 0; i--)
                        {
                            if (myCard[i] < enemyCard[0])
                            {
                                cocle[0] = myCard[i + 1];
                                break;
                            }
                        }
                        if (DemLe(myCard).Length == 0)
                            return cocle;
                        else if (DemCocLon(DemLe(myCard)) >= DemLe(myCard).Length / 2)
                            return cocle;
                        else
                            return boluot;

                    }
                    else
                        return boluot;
                }
                else
                {
                    if (DemLe(myCard).Length != 0)
                    {
                        for (int i = 0; i < DemLe(myCard).Length; i++)
                        {
                            if (DemLe(myCard)[i] > enemyCard[0])
                            {
                                if (DemLe(myCard).Length == 1)
                                {
                                    return DemLe(myCard);
                                }
                                else
                                {
                                    cocle[0] = DemLe(myCard)[i];
                                    int[] mangsaukhidanhle = DemLe(myCard).Except(cocle).ToArray();
                                    if (DemCocLon(DemLe(mangsaukhidanhle)) >= DemLe(mangsaukhidanhle).Length / 2)
                                        return cocle;
                                    else
                                        return boluot;
                                }
                            }
                        }
                        return boluot;
                    }
                    else
                    {
                        if (myCard[0] / 10 >= 14)
                            cocle[0] = myCard[0];
                        return cocle;
                    }
                }
            }

            if (enemyCard.Length == 2) //danh doi
            {
                int[] danhdoi = new int[2];
                if (myCard.Length == 1)
                    return boluot;
                if (enemyCard[0] / 10 == 15)
                {
                    if (myCard.Length == 2 || myCard.Length == 3)
                    {
                        if (myCard[myCard.Length - 1] / 10 == myCard[myCard.Length - 2] / 10 && myCard[myCard.Length - 1] > enemyCard[1])
                            return myCard;
                    }
                    else
                    {
                        if (CoTuQui(myCard)[0] != 0)
                            return CoTuQui(myCard);
                        else if (CoDoiThong(4)[0] != 0)
                            return CoDoiThong(4);
                        if (myCard[myCard.Length - 1] > enemyCard[1])
                        {
                            if (myCard[myCard.Length - 2] / 10 == 15)
                            {
                                if (DemCocLon(DemLe(myCard)) >= (DemLe(myCard).Length / 2 + 1))
                                {
                                    danhdoi[0] = myCard[myCard.Length - 2];
                                    danhdoi[1] = myCard[myCard.Length - 1];
                                    return danhdoi;
                                }
                            }
                        }
                        return boluot;
                    }
                }
                else
                {
                    if (myCard.Length < 4 && KiemTraDoi(myCard)[0] != 0)
                    {
                        if (DoiNhoNhat(myCard)[1] > enemyCard[1])
                            return DoiNhoNhat(myCard);
                    }
                    else
                    {
                        if (KiemTraDoi(myCard)[0] != 0)
                        {
                            int[] baisaukhidanhdoi = myCard.Except(KiemTraDoi(myCard)).ToArray();
                            if (TheManhDoi(myCard) == true || TheManhDoi(baisaukhidanhdoi) == true)
                                return KiemTraDoi(myCard);
                            if (DemCocLon(baisaukhidanhdoi) >= DemLe(baisaukhidanhdoi).Length / 2 - 1)
                                return KiemTraDoi(myCard);
                            if (DemLe(baisaukhidanhdoi).Length < DemLe(myCard).Length)
                                return KiemTraDoi(myCard);
                        }
                    }
                    return boluot;
                }
            }
            if (enemyCard.Length == 3 && enemyCard[0] / 10 == enemyCard[1] / 10) // danh 3 cay
            {
                if (CoBaCay(myCard)[0] > enemyCard[0])
                {
                    if (CoTuQui(myCard)[0] != 0)
                    {
                        int[] tmp = myCard.Except(CoTuQui(myCard)).ToArray();

                        if (CoBaCay(tmp)[0] > enemyCard[0])
                            return CoBaCay(tmp);
                        else
                            return boluot;
                    }
                    if (CoDoiThong(3)[0] != 0)
                    {
                        int[] tmp = myCard.Except(CoDoiThong(3)).ToArray();
                        if (CoTuQui(tmp)[0] != 0)
                        {
                            int[] tmp2 = tmp.Except(CoTuQui(tmp)).ToArray();
                            if (CoBaCay(tmp2)[0] > enemyCard[0])
                                return CoBaCay(tmp2);
                            else
                                return boluot;
                        }
                        if (CoBaCay(tmp)[0] > enemyCard[0])
                            return CoBaCay(tmp);
                        else
                            return boluot;
                    }
                    return CoBaCay(myCard);
                }
                return boluot;
            }
            if (enemyCard.Length == 4 && enemyCard[0] / 10 == enemyCard[1] / 10) // danh tu qui
            {
                if (CoTuQui(myCard)[0] > enemyCard[0])
                    return CoTuQui(myCard);
                else if (CoDoiThong(4)[0] != 0)
                    return CoDoiThong(4);
                else
                    return boluot;
            }
            if (enemyCard.Length == 6 && enemyCard[0] / 10 == enemyCard[1] / 10) // danh 3 doi thong
            {
                if (CoDoiThong(5)[0] != 0)
                    return CoDoiThong(5);
                else if (CoDoiThong(4)[0] != 0)
                    return CoDoiThong(4);
                else if (CoDoiThong(3)[0] != 0 && CoDoiThong(3)[5] > enemyCard[5])
                    return CoDoiThong(3);
                else if (CoTuQui(myCard)[0] != 0)
                    return CoTuQui(myCard);
                else
                    return boluot;
            }
            if (enemyCard.Length >= 8 && enemyCard[0] / 10 == enemyCard[1] / 10) // danh doi thong >3
            {
                if (enemyCard.Length == 8)
                {
                    if (CoDoiThong(5)[0] != 0)
                        return CoDoiThong(5);
                    else if (CoDoiThong(4)[0] != 0)
                    {
                        if (CoDoiThong(4)[7] > enemyCard[7])
                            return CoDoiThong(4);
                    }
                }
                else if (enemyCard.Length == 10)
                {
                    if (CoDoiThong(5)[9] > enemyCard[9])
                        return CoDoiThong(5);
                }
                return boluot;
            }
            else // danh sanh
            {
                int[] mangtam;
                if (CoTuQui(myCard)[0] != 0)
                    mangtam = myCard.Except(CoTuQui(myCard)).ToArray();
                else if (CoDoiThong(3)[0] != 0)
                    mangtam = myCard.Except(CoDoiThong(3)).ToArray();
                else
                {
                    mangtam = new int[myCard.Length];
                    Array.Copy(myCard, 0, mangtam, 0, myCard.Length);
                }
                if (TimSanhPhuHop(mangtam, enemyCard, enemyCard.Length).Count != 0) // co bai bat 
                {
                    int[] mangsaukhidanhsanh;
                    for (int i = 0; i < TimSanhPhuHop(mangtam, enemyCard, enemyCard.Length).Count; i++)
                    {
                        mangsaukhidanhsanh = myCard.Except(TimSanhPhuHop(mangtam, enemyCard, enemyCard.Length)[i]).ToArray();
                        if (DemLe(mangsaukhidanhsanh).Length <= DemLe(myCard).Length + 1)
                            return TimSanhPhuHop(mangtam, enemyCard, enemyCard.Length)[i];
                    }
                }
            }
            return boluot;
        }
    }
}
