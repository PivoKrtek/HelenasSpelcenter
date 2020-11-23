using System;
using System.IO;

namespace HelenasSpelcenter
{
    public class Highscore
    {

        public string Name { get; set; }

        public int GameHighscore { get; set; }
        public string GameName { get; set; }

        
        public Highscore(string gameName, string[] lines)
        {
            GameName = gameName;
            Name = lines[0];
            GameHighscore = int.Parse(lines[1]);
        }
        public static void RunHighscore()
        {
            bool again = true;
            while (again)
            {
                Console.Clear();
                HighscoreList.RunHighScoreAll();
                HighscoreList.TextMenuHighscores();
                int choice = InputNumber(0, 4);
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        HighScoreEachGame.OpenHighscores("highscoresnake.txt", HighScoreEachGame.ListSnake);
                        HighscoreList.PrintHighscoreEachGame("SNAKE", HighScoreEachGame.ListSnake);
                        Console.WriteLine();
                        Console.WriteLine("\t\tTryck valfri knapp för att återgå till menyn.");
                        Console.ReadKey(true);
                        break;
                    case 2:
                        Console.Clear();
                        HighScoreEachGame.OpenHighscores("yatzyhighscorelist.txt", HighScoreEachGame.ListYatzy);
                        HighscoreList.PrintHighscoreEachGame("YATZY", HighScoreEachGame.ListYatzy);
                        Console.WriteLine();
                        Console.WriteLine("\t\tTryck valfri knapp för att återgå till menyn.");
                        Console.ReadKey(true);
                        break;
                    case 3:
                        Console.Clear();
                        HighScoreEachGame.OpenHighscores("flappybirdhighscore.txt", HighScoreEachGame.ListFlappyBird);
                        HighscoreList.PrintHighscoreEachGame("FLAPPY BIRD", HighScoreEachGame.ListFlappyBird);
                        Console.WriteLine();
                        Console.WriteLine("\t\tTryck valfri knapp för att återgå till menyn.");
                        Console.ReadKey(true);
                        break;
                    case 4:
                        Console.Clear();
                        HighScoreEachGame.OpenAndPrintHighscore();
                        Console.WriteLine("\t\tTryck valfri knapp för att återgå till menyn.");
                        Console.ReadKey(true);
                        break;
                    case 0:
                        again = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public static int InputNumber(int minimumchoice, int maxchoice)
        {
            bool ok;
            int inputNumber = 0;

            while (true)
            {
                ok = int.TryParse(Console.ReadLine(), out inputNumber);
                if (!ok || inputNumber < minimumchoice || inputNumber > maxchoice)
                {
                    Console.WriteLine("\t\t\t\tWrong input. Try again.");
                }
                else { break; }
            }
            return inputNumber;
        }
    }
    

}




