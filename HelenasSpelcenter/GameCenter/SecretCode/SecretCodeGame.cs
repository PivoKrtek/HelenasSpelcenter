using System;
using System.Collections.Generic;
using System.Text;

namespace HelenasSpelcenter
{
    class SecretCodeGame
    {
        public static int LengthOfCode { get; set; }
        public static DateTime StartTime { get; set; }
        public static DateTime EndTime { get; set; }
        public static int Seconds { get; set; }
        public static void PlaySecretCode()
        {
            Console.SetWindowSize(120, 45);
            bool playAgain = true;

            while (playAgain)
            {
                playAgain = false;
                Code.CodeRevealed = false;
                SecretCodeScreen.Welcome();
                Code.SecretCode = new Code(LengthOfCode);
                Code.ListOfCodes = new List<Code>();
                Console.ReadLine();
                StartTime = DateTime.Now;
                int LapCounter = 0;

                while (!Code.CodeRevealed)
                {
                    Console.Clear();
                    //for (int j = 0; j < Code.SecretCode.CodeList.Count; j++)
                    //{
                    //    Console.Write($"{Code.SecretCode.CodeList[j].Number}");
                    //}
                    SecretCodeScreen.GameName();
                    SecretCodeScreen.Choices();
                    SecretCodeScreen.HiddenSecretCode();
                    Code.PlayField(Code.ListOfCodes);
                    SecretCodeScreen.ChooseYourGuess();
                    Code.CompareCodeWithSecretCode(LapCounter);
                    LapCounter++;
                }
                Console.Clear();
                SecretCodeScreen.GameName();
                SecretCodeScreen.Choices();
                SecretCodeScreen.Result(LapCounter);
                Code.PrintCode(Code.SecretCode);
                Console.ReadLine();

                Console.Clear();
                SecretCodeScreen.GameName();
                HighScoreEachGame.OpenAndPrintHighscore();
                SecretCodeScreen.Result(LapCounter);
                Console.ForegroundColor = ConsoleColor.Red;
                int maybeHighscore = HighScoreEachGame.SeeIfHighscoreSecretCode(LapCounter, Seconds, LengthOfCode - 3);
                if (maybeHighscore < 5)
                {
                    SecretCodeScreen.YouMadeItToList();
                    HighScoreEachGame.PutHighScoreInListSecretCode(maybeHighscore + (LengthOfCode - 3) * 5, LapCounter);
                    HighScoreEachGame.PutHighScoreInFile();
                    Console.Clear();
                    SecretCodeScreen.GameName();
                    HighScoreEachGame.OpenAndPrintHighscore();
                }
                else
                {
                    SecretCodeScreen.BetterLuck();
                }

                Console.ForegroundColor = ConsoleColor.Blue;
                SecretCodeScreen.PlayAgain();
                int choice = SecretCodeScreen.InputNumber(0, 1);
                if (choice == 1)
                { playAgain = true; }
                Console.Clear();
            }

        }
        public static void ReturnSeconds()
        {
            Seconds = (int)Math.Round((EndTime - StartTime).TotalSeconds, 0);
        }
        
    }
}
