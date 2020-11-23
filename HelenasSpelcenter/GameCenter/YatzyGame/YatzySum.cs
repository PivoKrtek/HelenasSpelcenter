using System;
using System.Collections.Generic;
using System.Text;

namespace HelenasSpelcenter.YatzyGame
{
    public class YatzySum
    {
        public int Sum { get; set; }
        public bool IsSumSet { get; set; }

        public YatzySum()
        {
            Sum = 0;
            IsSumSet = false;
        }

        public static void CountSumUp(List<YatzyPlayer> players)
        {
            int x = 0;
            int y = 0;
            int count = 0;
            foreach (YatzyPlayer player in players)
            {
                foreach (YatzySum sum in player.Sums)
                {
                    if (player.Sums.IndexOf(sum) < 6)
                    { 
                        x += sum.Sum; 
                    }
                    if (player.Sums.IndexOf(sum) == 6)
                    { 
                        sum.Sum = x;
                        sum.IsSumSet = true;
                    }
                    if (player.Sums.IndexOf(sum) == 7)
                    {
                        sum.IsSumSet = true;
                        if (x > 62)
                        { sum.Sum = 50; }
                        else
                        { sum.Sum = 0; }
                        
                    }
                    if (player.Sums.IndexOf(sum) > 6 && player.Sums.IndexOf(sum) < 17)
                    { y += sum.Sum; }
                    if (player.Sums.IndexOf(sum) == 17)
                    {
                        sum.IsSumSet = true;
                        sum.Sum = y + x;
                        count++;
                        player.YatzyRecord = sum.Sum;
                        
                    }
                }

            }

            

        }
        public static void SetPoint(int where, int points, List<YatzySum> sums)
        {
            if (where < 7)
            {
                sums[where - 1].IsSumSet = true;
                sums[where - 1].Sum = points;
            }
            else
            {
                sums[where +1].IsSumSet = true;
                sums[where +1].Sum = points;
            }
        }
        public static int GetPoint(int where, int[] dices)
        {
            if (where > 0 && where < 7)
            {
                int x = Numbers(where, dices);
                return x;
            }
            else if (where == 7)
            {
                int x = TwoOfSame(dices);
                return x;
            }
            else if (where == 8)
            {
                int x = TwoPair(dices);
                return x;
            }

            else if (where == 9)
            {
                int x = ThreeOfSame(dices);
                return x;
            }

            else if (where == 10)
            {
                int x = FourOfSame(dices);
                return x;
            }
            else if (where == 11)
            {
                int x = LittleStraight(dices);
                return x;
            }
            else if (where == 12)
            {
                int x = BigStraight(dices);
                return x;
            }
            else if (where == 13)
            {
                int x = Kak(dices);
                return x;
            }
            else if (where == 14)
            {
                int x = Chance(dices);
                return x;
            }
            else if (where == 15)
            {
                int x = Yatzyy(dices);
                return x;
            }
            else
            {
                return 0;
            }
        }

        //summan ifall spelar vill lägga det på ettor till sexor
        public static int Numbers(int where, int[] dices)
        {
            int sum = 0;
            for (int i = 0; i < 5; i++)
            {
                if (dices[i] == where)
                {
                    sum += where;
                }
            }

            return sum;
        }

        //metod att sätta på 1 par

        public static int TwoOfSame(int[] dices)
        {
            int sum6 = 0;
            int sum5 = 0;
            int sum4 = 0;
            int sum3 = 0;
            int sum2 = 0;
            int sum1 = 0;
            for (int i = 0; i < 5; i++)
            {
                if (dices[i] == 6)
                {
                    sum6 += 6;
                    if (sum6 == 12)
                    {
                        return sum6;
                    }
                }
                if (dices[i] == 5)
                {
                    sum5 += 5;
                    if (sum5 == 10)
                    {
                        return sum5;
                    }
                }
                if (dices[i] == 4)
                {
                    sum4 += 4;
                    if (sum4 == 8)
                    {
                        return sum4;
                    }
                }
                if (dices[i] == 3)
                {
                    sum3 += 3;
                    if (sum3 == 6)
                    {
                        return sum3;
                    }
                }
                if (dices[i] == 2)
                {
                    sum2 += 2;
                    if (sum2 == 4)
                    {
                        return sum2;
                    }
                }
                if (dices[i] == 2)
                {
                    sum1 += 1;
                    if (sum1 == 3)
                    {
                        return sum1;
                    }
                }
            }
            return 0;
        }

        //metod att sätta på 2 par

        public static int TwoPair(int[] dices)
        {
            int sum6 = 0;
            int sum5 = 0;
            int sum4 = 0;
            int sum3 = 0;
            int sum2 = 0;
            int sum1 = 0;
            int twoPair = 0;
            int sumOfIt = 0;
            for (int i = 0; i < 5; i++)
            {
                if (dices[i] == 6)
                {
                    sum6++;
                    if (sum6 == 2)
                    {
                        twoPair++;
                        sumOfIt += 12;
                    }
                }
                if (dices[i] == 5)
                {
                    sum5++;
                    if (sum5 == 2)
                    {
                        twoPair++;
                        sumOfIt += 10;
                    }
                }
                if (dices[i] == 4)
                {
                    sum4++;
                    if (sum4 == 2)
                    {
                        twoPair++;
                        sumOfIt += 8;
                    }
                }
                if (dices[i] == 3)
                {
                    sum3++;
                    if (sum3 == 2)
                    {
                        twoPair++;
                        sumOfIt += 6;
                    }
                }
                if (dices[i] == 2)
                {
                    sum2++;
                    if (sum2 == 2)
                    {
                        twoPair++;
                        sumOfIt += 4;
                    }
                }
                if (dices[i] == 1)
                {
                    sum1++;
                    if (sum1 == 2)
                    {
                        twoPair++;
                        sumOfIt += 2;
                    }
                }
            }
            if (twoPair == 2)
            {
                return sumOfIt;

            }
            else
            {
                return 0;
            }
        }

        //metod att sätta på tretal

        public static int ThreeOfSame(int[] dices)
        {
            int sum6 = 0;
            int sum5 = 0;
            int sum4 = 0;
            int sum3 = 0;
            int sum2 = 0;
            int sum1 = 0;

            for (int i = 0; i < 5; i++)
            {
                if (dices[i] == 6)
                {
                    sum6 += 6;
                    if (sum6 == 18)
                    {
                        return sum6;
                    }
                }
                if (dices[i] == 5)
                {
                    sum5 += 5;
                    if (sum5 == 15)
                    {
                        return sum5;
                    }
                }
                if (dices[i] == 4)
                {
                    sum4 += 4;
                    if (sum4 == 12)
                    {
                        return sum4;
                    }
                }
                if (dices[i] == 3)
                {
                    sum3 += 3;
                    if (sum3 == 9)
                    {
                        return sum3;
                    }
                }
                if (dices[i] == 2)
                {
                    sum2 += 2;
                    if (sum2 == 6)
                    {
                        return sum2;
                    }
                }
                if (dices[i] == 1)
                {
                    sum1 += 1;
                    if (sum1 == 3)
                    {
                        return sum1;
                    }
                }
            }
            return 0;
        }

        //metod att sätta på fyrtal

        public static int FourOfSame(int[] dices)
        {
            int sum6 = 0;
            int sum5 = 0;
            int sum4 = 0;
            int sum3 = 0;
            int sum2 = 0;
            int sum1 = 0;
            for (int i = 0; i < 5; i++)
            {
                if (dices[i] == 6)
                {
                    sum6 += 6;
                    if (sum6 == 24)
                    {
                        return sum6;
                    }
                }
                if (dices[i] == 5)
                {
                    sum5 += 5;
                    if (sum5 == 20)
                    {
                        return sum5;
                    }
                }
                if (dices[i] == 4)
                {
                    sum4 += 4;
                    if (sum4 == 16)
                    {
                        return sum4;
                    }
                }
                if (dices[i] == 3)
                {
                    sum3 += 3;
                    if (sum3 == 12)
                    {
                        return sum3;
                    }
                }
                if (dices[i] == 2)
                {
                    sum2 += 2;
                    if (sum2 == 8)
                    {
                        return sum2;
                    }
                }
                if (dices[i] == 4)
                {
                    sum1 += 1;
                    if (sum1 == 3)
                    {
                        return sum1;
                    }
                }
            }
            return 0;
        }

        //metod att sätta på liten straight
        public static int LittleStraight(int[] dices)
        {

            for (int i = 0; i < 5; i++)
            {
                if (dices[i] == 1)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (dices[j] == 2)
                        {
                            for (int k = 0; k < 5; k++)
                            {
                                if (dices[k] == 3)
                                {
                                    for (int l = 0; l < 5; l++)
                                    {
                                        if (dices[l] == 4)
                                        {
                                            for (int m = 0; m < 5; m++)
                                            {
                                                if (dices[m] == 5)
                                                {
                                                    return 15;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return 0;

        }

        //metod att sätta på stor straight

        public static int BigStraight(int[] dices)
        {

            for (int i = 0; i < 5; i++)
            {
                if (dices[i] == 2)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (dices[j] == 3)
                        {
                            for (int k = 0; k < 5; k++)
                            {
                                if (dices[k] == 4)
                                {
                                    for (int l = 0; l < 5; l++)
                                    {
                                        if (dices[l] == 5)
                                        {
                                            for (int m = 0; m < 5; m++)
                                            {
                                                if (dices[m] == 6)
                                                {
                                                    return 20;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return 0;

        }

        //metod att sätta på kåk

        public static int Kak(int[] dices)
        {
            int sum6 = 0;
            int sum5 = 0;
            int sum4 = 0;
            int sum3 = 0;
            int sum2 = 0;
            int sum1 = 0;
            int threeOfIt = 0;
            int twoPair = 0;
            int sumOfIt = 0;
            for (int i = 0; i < 5; i++)
            {
                if (dices[i] == 6)
                {
                    sum6++;
                    if (sum6 == 2)
                    {
                        twoPair++;
                        sumOfIt += 12;
                    }
                    if (sum6 == 3)
                    {
                        twoPair--;
                        threeOfIt++;
                        sumOfIt += 6;

                    }


                }
                if (dices[i] == 5)
                {
                    sum5++;
                    if (sum5 == 2)
                    {
                        twoPair++;
                        sumOfIt += 10;
                    }
                    if (sum5 == 3)
                    {
                        twoPair--;
                        threeOfIt++;
                        sumOfIt += 5;
                    }

                }
                if (dices[i] == 4)
                {
                    sum4++;
                    if (sum4 == 2)
                    {
                        twoPair++;
                        sumOfIt += 8;
                    }
                    if (sum4 == 3)
                    {
                        twoPair--;
                        threeOfIt++;
                        sumOfIt += 4;
                    }
                }
                if (dices[i] == 3)
                {
                    sum3++;
                    if (sum3 == 2)
                    {
                        twoPair++;
                        sumOfIt += 6;
                    }
                    if (sum3 == 3)
                    {
                        twoPair--;
                        threeOfIt++;
                        sumOfIt += 3;
                    }
                }
                if (dices[i] == 2)
                {
                    sum2++;
                    if (sum2 == 2)
                    {
                        twoPair++;
                        sumOfIt += 4;
                    }
                    if (sum2 == 3)
                    {
                        twoPair--;
                        threeOfIt++;
                        sumOfIt += 2;
                    }
                }
                if (dices[i] == 1)
                {
                    sum1++;
                    if (sum1 == 2)
                    {
                        twoPair++;
                        sumOfIt += 2;
                    }
                    if (sum1 == 3)
                    {
                        twoPair--;
                        threeOfIt++;
                        sumOfIt += 1;
                    }
                }
            }
            if (twoPair == 1 && threeOfIt == 1)
            {
                return sumOfIt;
            }
            else
            {
                return 0;
            }
        }

        //metod att sätta på chans
        public static int Chance(int[] dices)
        {
            int sum = 0;
            for (int i = 0; i < 5; i++)
            {
                sum += dices[i];
            }
            return sum;
        }

        //metod att sätta på yatzy
        public static int Yatzyy(int[] dices)
        {
            if (dices[0] == dices[1] && dices[1] == dices[2] && dices[2] == dices[3] && dices[3] == dices[4])
            {
                return 50;
            }
            else
            {
                return 0;
            }
        }
    }
}
