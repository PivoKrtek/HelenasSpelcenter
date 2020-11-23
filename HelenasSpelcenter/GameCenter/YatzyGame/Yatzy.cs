using System;
using System.Collections.Generic;
using System.Linq;

namespace HelenasSpelcenter.YatzyGame
{
    public class Yatzy
    {
        public static int SumPlayer1 { get; set; }

        public static int SumPlayer2 { get; set; }

        public static int SumPlayer3 { get; set; }

        public static int SumPlayer4 { get; set; }

        public static void PlayYatzy()
        {
            Random dice = new Random();

            Intro();
            Console.WriteLine();
            Console.WriteLine();
            int howManyPlayers = YatzyPlayer.HowManyPlayers();
            List<YatzyPlayer> players = YatzyPlayer.CreateListOfPLayers(howManyPlayers);
            Console.WriteLine();
            List<Yatzyboard> yatzyboard = Yatzyboard.CreateEmptyYatzyboard(players);
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();

            for (int turn = 0; turn < 15; turn++)
            {

                foreach (YatzyPlayer player in players)
                {
                    int count = 1;
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine();
                    Yatzyboard.PrintOutYatzyboard(yatzyboard, players);
                    Console.WriteLine();
                    ThrowDiceText(count, player);
                    Console.ReadLine();
                    int[] dices = ThrowDices();
                    Console.WriteLine();
                    PrintOutDices(dices);

                    while (count < 3)
                    {
                        count++;
                        Console.WriteLine();
                        TextWhichToKeep();
                        dices = UpdateThrewedDices(dices);
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine();
                        Yatzyboard.PrintOutYatzyboard(yatzyboard, players);
                        Console.WriteLine();
                        ThrowDiceText(count, player);
                        Console.WriteLine();
                        PrintOutDices(dices);
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine();
                        Yatzyboard.PrintOutYatzyboard(yatzyboard, players);
                        dices = FillArrayFullWithNewDices(dices);
                        Console.WriteLine();
                        PrintOutDices(dices);
                    }
                    TextWherePutSum();
                    bool isFree;
                    int where = 0;
                    int points = 0;
                    do
                    {
                        where = ReturnNumber(1, 15);
                        isFree = CheckIfFree(where, player.Sums);
                        if (isFree == false)
                        {
                            Console.WriteLine("\tDu har redan satt poäng där, vänligen försök igen.");
                        }
                        points = YatzySum.GetPoint(where, dices);
                        if (points == 0)
                        {
                            isFree = KeepThePlace(where);
                        }
                    } while (!isFree);

                    
                    YatzySum.SetPoint(where, points, player.Sums);




                }
            }
            YatzySum.CountSumUp(players);
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Yatzyboard.PrintOutYatzyboard(yatzyboard, players);

            Console.WriteLine("\t\t\t\t\tTryck för att se Highscore.");
            Console.ReadKey(true);

            Console.Clear();
            HighScoreEachGame.OpenHighscores("yatzyhighscorelist.txt", HighScoreEachGame.ListYatzy);
            HighScoreEachGame.PrintOutHighscores("----------------------YATZY--------------------", HighScoreEachGame.ListYatzy);
            Console.WriteLine();

            foreach (var player in players)
            {

                Console.WriteLine($"\t\t\t\t\t{player.Name} fick {player.YatzyRecord} poäng.\n");
            }
            foreach (var player in players)
            {
                int maybeHighscore = HighScoreEachGame.SeeIfHighscore(HighScoreEachGame.ListSnake, Yatzy.SumPlayer1);

                if (maybeHighscore < 11)
                {
                    Console.WriteLine("\t\t\t\t\tGrattis! Du kom in på Highscore-listan!");
                    HighScoreEachGame.PutHighScoreInList(maybeHighscore, player.YatzyRecord, HighScoreEachGame.ListYatzy);
                    HighScoreEachGame.PutHighScoreInFile("yatzyhighscore.txt", HighScoreEachGame.ListYatzy);
                    Console.Clear();
                    HighScoreEachGame.OpenHighscores("yatzyhighscore.txt", HighScoreEachGame.ListYatzy);
                    HighScoreEachGame.PrintOutHighscores("----------------------YATZY--------------------", HighScoreEachGame.ListYatzy);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("\t\t\t\t\tBättre lycka nästa gång!\n\n");
                }
            }
            
            

            Console.ReadLine();

        }
        

        public static bool KeepThePlace(int where)
        {
            Console.WriteLine();
            Console.WriteLine("\tDet kommer bli 0 poäng om du sätter ditt resultat vid vald plats " + where + ".");
            Console.WriteLine("\tOm du ångrar dig och vill välja en ny plats, tryck N och sedan ENTER.");
            Console.WriteLine("\tÄr du nöjd med vald plats, trycker du bara ENTER.");
            string answer = Console.ReadLine().ToLower();
            if (answer == "n")
            { return false; }
            else
            {
                return true;
            }
        }
        public static void TextWherePutSum()
        {
            Console.WriteLine("\tVar vill du sätta dina poäng?");
            Console.WriteLine("\tTryck numret för önskad kategori, sedan ENTER.");
        }
        public static bool CheckIfFree(int where, List<YatzySum> sums)
        {
            if (where < 7)
            {
                if (sums[where - 1].IsSumSet == false)
                { return true; }
            }
            else if (where > 6)
            {
                if (sums[where +1].IsSumSet == false)
                { return true; }
            }
            return false;
        }
        public static int ReturnNumber(int min, int max)
        {
            bool ok;
            int input = 0;

            while (true)
            {
                ok = int.TryParse(Console.ReadLine(), out input);
                if (!ok || input < min || input > max)
                {
                    Console.WriteLine("\tFörsök igen.");
                }
                else { break; }
            }
            return input;
        }
        public static int[] FillArrayFullWithNewDices(int[] dices)
        {
            Random dice = new Random();
            for (int i = 0; i < dices.Length; i++)
            {
                if (dices[i] == 0)
                {
                    dices[i] = dice.Next(1, 7);
                }
            }
            return dices;
        }
        public static int[] UpdateThrewedDices(int[] dices)
        {
            int[] updateThrow = new int[5];
            int count = 0;
            int saveThisDice = 0;
            do
            {
                saveThisDice = ReturnNumber(0, 5);
                //göra hantering för om man matar in samma tal 2 ggr

                if (saveThisDice == 1)
                {
                    updateThrow[count] = dices[0];
                    count++;
                }
                if (saveThisDice == 2)
                {
                    updateThrow[count] = dices[1];
                    count++;
                }
                if (saveThisDice == 3)
                {
                    updateThrow[count] = dices[2];
                    count++;
                }
                if (saveThisDice == 4)
                {
                    updateThrow[count] = dices[3];
                    count++;
                }
                if (saveThisDice == 5)
                {
                    updateThrow[count] = dices[4];
                    count++;
                }


            } while (saveThisDice != 0);
            return updateThrow;
            //metod som visar uppdaterat bord med sparade
            //while (count < 5)
            //{
            //    updatethrow[count] = dice.next(1, 7);
            //}


        }
        public static void TextWhichToKeep()
        {
            Console.WriteLine("\tVilken/vilka tärningar vill du behålla?");
            Console.WriteLine("\tSkriv siffran på tärningen du vill behålla, en i taget, tryck ENTER.");
            Console.WriteLine("\tTryck 0 och sedan ENTER när du är nöjd.");
        }
        public static void PrintOutDices(int[] dices)
        {
            Console.WriteLine("\t   1:        2:        3:        4:        5: ");
            Console.WriteLine("\t_______   _______   _______   _______   _______");
            Console.WriteLine($"\t|{Place1and7(dices[0])}   {Place2and6(dices[0])}|   |{Place1and7(dices[1])}   {Place2and6(dices[1])}|   |{Place1and7(dices[2])}   {Place2and6(dices[2])}|   |{Place1and7(dices[3])}   {Place2and6(dices[3])}|   |{Place1and7(dices[4])}   {Place2and6(dices[4])}|");
            Console.WriteLine($"\t|{Place3and5(dices[0])} {Place4(dices[0])} {Place3and5(dices[0])}|   |{Place3and5(dices[1])} {Place4(dices[1])} {Place3and5(dices[1])}|   |{Place3and5(dices[2])} {Place4(dices[2])} {Place3and5(dices[2])}|   |{Place3and5(dices[3])} {Place4(dices[3])} {Place3and5(dices[3])}|   |{Place3and5(dices[4])} {Place4(dices[4])} {Place3and5(dices[4])}|");
            Console.WriteLine($"\t|{Place2and6(dices[0])}___{Place1and7(dices[0])}|   |{Place2and6(dices[1])}___{Place1and7(dices[1])}|   |{Place2and6(dices[2])}___{Place1and7(dices[2])}|   |{Place2and6(dices[3])}___{Place1and7(dices[3])}|   |{Place2and6(dices[4])}___{Place1and7(dices[4])}|");
            Console.WriteLine();
        }
        public static string Place1and7(int dice)
        {
            if (dice == 6 || dice == 5 || dice == 4)
            { return "*"; }
            else
            { return " "; }

        }
        public static string Place2and6(int dice)
        {
            if (dice == 1 || dice == 0)
            { return " "; }
            else
            { return "*"; }

        }
        public static string Place3and5(int dice)
        {
            if (dice == 6)
            { return "*"; }
            else
            { return " "; }

        }
        public static string Place4(int dice)
        {
            if (dice == 6 || dice == 4 || dice == 2 || dice == 0)
            { return " "; }
            else
            { return "*"; }

        }
        public static int[] ThrowDices()
        {
            Random dice = new Random();
            int diceOne = dice.Next(1, 7);
            int diceTwo = dice.Next(1, 7);
            int diceThree = dice.Next(1, 7);
            int diceFour = dice.Next(1, 7);
            int diceFive = dice.Next(1, 7);
            int[] dices = new int[] { diceOne, diceTwo, diceThree, diceFour, diceFive };
            return dices;
        }

        public static void ThrowDiceText(int diceThrow, YatzyPlayer player)
        {
            Console.WriteLine($"\t{player.Name}, din tur. SLAG NUMMER {diceThrow}.");
            Console.WriteLine("\tTryck ENTER för att slå tärningarna.");
        }
        static void Intro()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine();
            Console.WriteLine("\t`8.`8888.      ,8'    .8.    8888888 8888888888 8888888888',8888' `8.`8888.      ,8'");
            System.Threading.Thread.Sleep(200);
            Console.WriteLine("\t `8.`8888.    ,8'    .888.         8 8888              ,8',8888'   `8.`8888.    ,8'");
            System.Threading.Thread.Sleep(200);
            Console.WriteLine("\t  `8.`8888.  ,8'    :88888.        8 8888             ,8',8888'     `8.`8888.  ,8'");
            System.Threading.Thread.Sleep(200);
            Console.WriteLine("\t   `8.`8888.,8'    . `88888.       8 8888            ,8',8888'       `8.`8888.,8'");
            System.Threading.Thread.Sleep(200);
            Console.WriteLine("\t    `8.`88888'    .8. `88888.      8 8888           ,8',8888'         `8.`88888'");
            System.Threading.Thread.Sleep(200);
            Console.WriteLine("\t     `8. 8888    .8`8. `88888.     8 8888          ,8',8888'           `8. 8888");
            System.Threading.Thread.Sleep(200);
            Console.WriteLine("\t      `8 8888   .8' `8. `88888.    8 8888         ,8',8888'             `8 8888   ");
            System.Threading.Thread.Sleep(200);
            Console.WriteLine("\t       8 8888  .8'   `8. `88888.   8 8888        ,8',8888'               8 8888      ");
            System.Threading.Thread.Sleep(200);
            Console.WriteLine("\t       8 8888 .888888888. `88888.  8 8888       ,8',8888'                8 8888");
            System.Threading.Thread.Sleep(200);
            Console.WriteLine("\t       8 8888.8'       `8. `88888. 8 8888      ,8',8888888888888         8 8888");
        }
        static void SmallIntro()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("YATZY YATZY YATZY YATZY YATZY YATZY YATZY YATZY YATZY YATZY YATZY YATZY YATZY YATZY YATZY YATZY ");
        }

        static void ShortIntro()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine();
            Console.WriteLine("\t`8.`8888.      ,8'    .8.    8888888 8888888888 8888888888',8888' `8.`8888.      ,8'");
            Console.WriteLine("\t `8.`8888.    ,8'    .888.         8 8888              ,8',8888'   `8.`8888.    ,8'");

            Console.WriteLine("\t  `8.`8888.  ,8'    :88888.        8 8888             ,8',8888'     `8.`8888.  ,8'");

            Console.WriteLine("\t   `8.`8888.,8'    . `88888.       8 8888            ,8',8888'       `8.`8888.,8'");

            Console.WriteLine("\t    `8.`88888'    .8. `88888.      8 8888           ,8',8888'         `8.`88888'");

            Console.WriteLine("\t     `8. 8888    .8`8. `88888.     8 8888          ,8',8888'           `8. 8888");

            Console.WriteLine("\t      `8 8888   .8' `8. `88888.    8 8888         ,8',8888'             `8 8888   ");

            Console.WriteLine("\t       8 8888  .8'   `8. `88888.   8 8888        ,8',8888'               8 8888      ");

            Console.WriteLine("\t       8 8888 .888888888. `88888.  8 8888       ,8',8888'                8 8888");

            Console.WriteLine("\t       8 8888.8'       `8. `88888. 8 8888      ,8',8888888888888         8 8888");
        }
    }


}
