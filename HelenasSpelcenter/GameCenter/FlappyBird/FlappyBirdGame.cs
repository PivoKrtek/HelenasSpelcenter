using System;
using System.Collections.Generic;
using System.Text;

namespace HelenasSpelcenter
{
    class FlappyBirdGame
    {
        public static int HeightOfGameWindow { get; set; }
        public static int WidhtOfGameWindow { get; set; }
        public static int LapNumber { get; set; }
        public static int Points { get; set; }

        public static GreenField Field1 { get; set; }
        public static GreenField Field2 { get; set; }
        public static GreenField Field3 { get; set; }
        public static GreenField Field4 { get; set; }
        public static GreenField Field5 { get; set; }

        public static void PlayFlappyBird()
        {
            Console.SetWindowSize(95, 28);
            Console.OutputEncoding = Encoding.Unicode;
            HeightOfGameWindow = 25;
            WidhtOfGameWindow = 94;
            bool playAgain = true;
            GreenField.StartYPositionForWhole = 3;
            GreenField.HeightOfWholeInField = 6;
            GreenField.WidthSizeOfField = 8;
            GreenField.NumberOfPositionBetweenEachField = 22;
            GreenField.StartPositonFirstField = 40;
            while (playAgain)
            {
                playAgain = false;
                LapNumber = 0;
                Points = 0;
                Bird.Alive = true;
                Bird.XStartPosition = 12;
                Bird.YStartPosition = 10;
                Screen.XHere = 0;

                Field1 = new GreenField(GreenField.StartPositonFirstField);
                Field2 = new GreenField(GreenField.StartPositonFirstField + GreenField.NumberOfPositionBetweenEachField);
                Field3 = new GreenField(GreenField.StartPositonFirstField + GreenField.NumberOfPositionBetweenEachField * 2);
                Field4 = new GreenField(GreenField.StartPositonFirstField + GreenField.NumberOfPositionBetweenEachField * 3);
                Field5 = new GreenField(GreenField.StartPositonFirstField + GreenField.NumberOfPositionBetweenEachField * 4);
                Bird.CreateBird();
                Screen.StringsMakingScreen = new string[FlappyBirdGame.HeightOfGameWindow, FlappyBirdGame.WidhtOfGameWindow];

                Screen.StartGame();

                while (Bird.Alive)
                {
                    LapNumber++;
                    Console.SetCursorPosition(0, 0);

                    if (LapNumber < 1000)
                    {
                        if (LapNumber % 2 == 0)
                        { GreenField.SetStartPositionOneStepBack(); }
                    }
                    else if (LapNumber > 1000 && LapNumber < 2000)
                    {
                        if (LapNumber % 2 == 0 || LapNumber % 3 == 0)
                        { GreenField.SetStartPositionOneStepBack(); }
                    }
                    else
                    { GreenField.SetStartPositionOneStepBack(); }

                    if (LapNumber % 2 == 0)
                    {
                        Bird.YStartPosition++;
                        if (Bird.YStartPosition + Bird.BirdSizeY > 26)
                        { Bird.Alive = false; }
                    }
                    if (Bird.YStartPosition < 0)
                    { Bird.Alive = false; }
                    if (Console.KeyAvailable)
                    {
                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.UpArrow:
                                {
                                    Bird.YStartPosition = Bird.YStartPosition - 2;
                                }
                                break;
                            case ConsoleKey.Spacebar:
                                {
                                    Bird.YStartPosition = Bird.YStartPosition - 3;
                                }
                                break;
                            case ConsoleKey.Escape:
                                {
                                    Bird.Alive = false;
                                }
                                break;
                            default:
                                break;
                        }
                    }

                    Screen.CreateScreen();
                    Screen.PrintScreen();

                    System.Threading.Thread.Sleep(15);
                }

                Console.SetCursorPosition(0, 0);
                Screen.EndGame();
                Console.SetWindowSize(110, 45);
                Console.Clear();
                HighScoreEachGame.OpenHighscores("flappybirdhighscore.txt", HighScoreEachGame.ListFlappyBird);
                HighScoreEachGame.PrintOutHighscores("-------------FLAPPY BIRD-------------", HighScoreEachGame.ListFlappyBird);
                Console.WriteLine();
                Console.WriteLine($"\t\t\t\t\tDu fick {FlappyBirdGame.Points} poäng.\n");
                int maybeHighscore = HighScoreEachGame.SeeIfHighscore(HighScoreEachGame.ListFlappyBird, FlappyBirdGame.Points);
                if (maybeHighscore < 11)
                {
                    Console.WriteLine("\t\t\t\t\tGrattis! Du kom in på Highscore-listan!");
                    HighScoreEachGame.PutHighScoreInList(maybeHighscore, Points, HighScoreEachGame.ListFlappyBird);
                    HighScoreEachGame.PutHighScoreInFile("flappybirdhighscore.txt", HighScoreEachGame.ListFlappyBird);
                    Console.Clear();
                    HighScoreEachGame.OpenHighscores("flappybirdhighscore.txt", HighScoreEachGame.ListFlappyBird);
                    HighScoreEachGame.PrintOutHighscores("-------------FLAPPY BIRD-------------", HighScoreEachGame.ListFlappyBird);
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
                Console.Clear();

            }
            Console.Clear();
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
                    Console.WriteLine("Wrong input. Try again.");
                }
                else { break; }
            }
            return inputNumber;
        }
    }
}
