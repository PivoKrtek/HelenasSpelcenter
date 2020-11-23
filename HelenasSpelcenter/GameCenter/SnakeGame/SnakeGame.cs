using System;
using System.Collections.Generic;
using System.Text;

namespace HelenasSpelcenter
{
    public class SnakeGame
    {
        public static int Counter { get; set; }
        public static bool AddSnakeFragment { get; set; }



        public static void PlaySnake()
        {
            bool playAgain = true;
            Console.OutputEncoding = Encoding.Unicode;
            while (playAgain)
            {
                playAgain = false;

                Counter = 0;
                GameBoardSnake.XSize = 25;
                GameBoardSnake.YSize = 15;
                Apple apple = new Apple();
                Snake snake = new Snake(5, 5);
                SnakeFragment snakeFragment = new SnakeFragment(0, 0);
                Console.Clear();
                Intro();
                Console.ForegroundColor = ConsoleColor.Gray;
                //Console.WriteLine("\u263A");
                Console.WriteLine("\n");
                Console.WriteLine("\t\t\t\tTryck valfri tangent för att starta.\n");
                Console.ReadKey(true);
                Console.Clear();
                while (snake.Alive)
                {
                    AddSnakeFragment = false;
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("\n\n\n\n");
                    GameBoardSnake.PrintOutGameBoard(snake.WholeSnake, apple);

                    if (Console.KeyAvailable)
                    {
                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.UpArrow:
                                if (snake.DirectionY != 1)
                                {
                                    snake.DirectionX = 0;
                                    snake.DirectionY = -1;
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                if (snake.DirectionY != -1)
                                {
                                    snake.DirectionX = 0;
                                    snake.DirectionY = +1;
                                }
                                break;
                            case ConsoleKey.LeftArrow:
                                if (snake.DirectionX != 1)
                                {
                                    snake.DirectionX = -1;
                                    snake.DirectionY = 0;
                                }
                                break;
                            case ConsoleKey.RightArrow:
                                if (snake.DirectionX != -1)
                                {
                                    snake.DirectionX = +1;
                                    snake.DirectionY = 0;
                                }
                                break;
                            default:
                                break;
                        }
                    }

                    //if (AddSnakeFragment)
                    //{ snakeFragment = snake.LastSnakeFragment(); }
                    snake.WholeSnake = snake.NewPositionsForSnakeFragments();
                    //if (AddSnakeFragment)
                    //{ snake.AddOneMoreSnakeFragment(snakeFragment); }
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\t\t\t\t\tPOÄNG: {SnakeGame.Counter}");
                    snake.CheckIfDies();
                    if (snake.DirectionY != 0)
                    { System.Threading.Thread.Sleep(150); }
                    else { System.Threading.Thread.Sleep(100); }
                }
                Console.WriteLine();
                Console.WriteLine("\t\t\t\t\tDu är död :(\n\n");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("\t\t\t\t\tTryck för att se Highscore.");
                Console.ReadKey(true);

                Console.Clear();
                HighScoreEachGame.OpenHighscores("highscoresnake.txt", HighScoreEachGame.ListSnake);
                HighScoreEachGame.PrintOutHighscores("----------------------SNAKE--------------------", HighScoreEachGame.ListSnake);
                Console.WriteLine();
                Console.WriteLine($"\t\t\t\t\tDu fick {SnakeGame.Counter} poäng.\n");
                int maybeHighscore = HighScoreEachGame.SeeIfHighscore(HighScoreEachGame.ListSnake, SnakeGame.Counter);
                if (maybeHighscore < 11)
                {
                    Console.WriteLine("\t\t\t\t\tGrattis! Du kom in på Highscore-listan!");
                    HighScoreEachGame.PutHighScoreInList(maybeHighscore, SnakeGame.Counter, HighScoreEachGame.ListSnake);
                    HighScoreEachGame.PutHighScoreInFile("highscoresnake.txt", HighScoreEachGame.ListSnake);
                    Console.Clear();
                    HighScoreEachGame.OpenHighscores("highscoresnake.txt", HighScoreEachGame.ListSnake);
                    HighScoreEachGame.PrintOutHighscores("----------------SNAKE----------------", HighScoreEachGame.ListSnake);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("\t\t\t\t\tBättre lycka nästa gång!\n\n");
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t\t\t\t\tVill du spela igen?");
                Console.WriteLine("\t\t\t\t\t[1] --> JA!");
                Console.WriteLine("\t\t\t\t\t[0] --> EXIT.");
                Console.Write("\t\t\t\t\t");
                int choice = InputNumber(0, 1);
                if (choice == 1)
                { playAgain = true; }
            }
            Console.ReadLine();


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
        public static void Intro()
        {
            string[] animation = SnakeIntroAnimation();
            int speed = 60;
            for (int i = 0; i < 23; i++)
            {
                Console.SetCursorPosition(0, 0);
                SnakeIntro();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(animation[i]);
                System.Threading.Thread.Sleep(speed);
            }

            System.Threading.Thread.Sleep(1000);

        }

        public static string[] SnakeIntroAnimation()
        {
            string[] animation = new string[23];

            animation[0] = "\t\t\t\t\u25CF                               \u2665";
            animation[1] = "\t\t\t\t\u25CF\u25CF                              \u2665";
            animation[2] = "\t\t\t\t\u25CF\u25CF\u25CF                             \u2665";
            animation[3] = "\t\t\t\t\u25CF\u25CF\u25CF\u25CF                            \u2665";
            animation[4] = "\t\t\t\t\u25CF\u25CF\u25CF\u25CF\u25CF                           \u2665";
            animation[5] = "\t\t\t\t\u25CF\u25CF\u25CF\u25CF\u25CF\u25CF                          \u2665";
            animation[6] = "\t\t\t\t\u25CF\u25CF\u25CF\u25CF\u25CF\u25CF                          \u2665";
            animation[7] = "\t\t\t\t \u25CF\u25CF\u25CF\u25CF\u25CF\u25CF                         \u2665";
            animation[8] = "\t\t\t\t  \u25CF\u25CF\u25CF\u25CF\u25CF\u25CF                        \u2665";
            animation[9] = "\t\t\t\t   \u25CF\u25CF\u25CF\u25CF\u25CF\u25CF                       \u2665";
            animation[10] = "\t\t\t\t    \u25CF\u25CF\u25CF\u25CF\u25CF\u25CF                      \u2665";
            animation[11] = "\t\t\t\t      \u25CF\u25CF\u25CF\u25CF\u25CF\u25CF                    \u2665";
            animation[12] = "\t\t\t\t        \u25CF\u25CF\u25CF\u25CF\u25CF\u25CF                  \u2665";
            animation[13] = "\t\t\t\t          \u25CF\u25CF\u25CF\u25CF\u25CF\u25CF                \u2665";
            animation[14] = "\t\t\t\t           \u25CF\u25CF\u25CF\u25CF\u25CF\u25CF               \u2665";
            animation[15] = "\t\t\t\t            \u25CF\u25CF\u25CF\u25CF\u25CF\u25CF              \u2665";
            animation[16] = "\t\t\t\t              \u25CF\u25CF\u25CF\u25CF\u25CF\u25CF            \u2665";
            animation[17] = "\t\t\t\t                \u25CF\u25CF\u25CF\u25CF\u25CF\u25CF          \u2665";
            animation[18] = "\t\t\t\t                  \u25CF\u25CF\u25CF\u25CF\u25CF\u25CF        \u2665";
            animation[19] = "\t\t\t\t                    \u25CF\u25CF\u25CF\u25CF\u25CF\u25CF      \u2665";
            animation[20] = "\t\t\t\t                      \u25CF\u25CF\u25CF\u25CF\u25CF\u25CF    \u2665";
            animation[21] = "\t\t\t\t                         \u25CF\u25CF\u25CF\u25CF\u25CF\u25CF \u2665";
            animation[22] = "\t\t\t\t                          \u25CF\u25CF\u25CF\u25CF\u25CF\u25CF --- YUMMY!";
            return animation;
        }

        private static void SnakeIntro()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("\t\t\t   ▄████████ ███▄▄▄▄      ▄████████    ▄█   ▄█▄    ▄████████ ");
            Console.WriteLine("\t\t\t  ███    ███ ███▀▀▀██▄   ███    ███   ███ ▄███▀   ███    ███ ");
            Console.WriteLine("\t\t\t  ███    █▀  ███   ███   ███    ███   ███▐██▀     ███    █▀  ");
            Console.WriteLine("\t\t\t  ███        ███   ███   ███    ███  ▄█████▀     ▄███▄▄▄     ");
            Console.WriteLine("\t\t\t▀███████████ ███   ███ ▀███████████ ▀▀█████▄    ▀▀███▀▀▀  ");
            Console.WriteLine("\t\t\t         ███ ███   ███   ███    ███   ███▐██▄     ███    █▄  ");
            Console.WriteLine("\t\t\t   ▄█    ███ ███   ███   ███    ███   ███ ▀███▄   ███    ███ ");
            Console.WriteLine("\t\t\t ▄████████▀   ▀█   █▀    ███    █▀    ███   ▀█▀   ██████████ ");
            Console.WriteLine("\t\t\t                                      ▀                      \n");
        }

    }
}
