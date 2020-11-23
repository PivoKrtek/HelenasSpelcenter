using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HelenasSpelcenter
{
    class HighscoreList
    {
        public static List<Highscore> GameHighscoreList { get; set; }
        

        ////kan detta vara en klass som passar som struct?
        public HighscoreList()
        {
            GameHighscoreList = new List<Highscore>();
            
            GameHighscoreList.Add(new Highscore("SNAKE", ReadInHighScore("highscoresnake.txt")));
            GameHighscoreList.Add(new Highscore("YATZY", ReadInHighScore("yatzyhighscorelist.txt")));
            GameHighscoreList.Add(new Highscore("FLAPPY BIRD", ReadInHighScore("flappybirdhighscore.txt")));


        }
        public static void TextMenuHighscores()
        {
            int speedMenu = 350;
            //tabba in
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n\t\tVill du se någon HIGHSCORE för respektive spel? Tryck siffra och ENTER.");
            Console.WriteLine("\t\t[1] --> SNAKE");
            System.Threading.Thread.Sleep(speedMenu);
            Console.WriteLine("\t\t[2] --> YATZY");
            System.Threading.Thread.Sleep(speedMenu);
            Console.WriteLine("\t\t[3] --> FLAPPY BIRD");
            System.Threading.Thread.Sleep(speedMenu);
            Console.WriteLine("\t\t[4] --> SECRET CODE");
            System.Threading.Thread.Sleep(speedMenu);
            Console.WriteLine("\t\t[0] --> EXIT\n");
            

            Console.ForegroundColor = ConsoleColor.White;
        }
    

        public void ShowAllHighScore()
        {
            foreach (var highscore in GameHighscoreList)
            {
                //if (highscore.GameName == "Secret code")
                //{ Console.WriteLine($"\t\t{highscore.GameName}\t : {highscore.Name}\t : {highscore.GameHighscore}"); }
                //else { 
                    Console.WriteLine($"\t\t{highscore.GameName}\t{(highscore.GameName.Length < 6 ? "\t" : "")} : {highscore.Name}\t : {highscore.GameHighscore}");
                //}
            }
        }

        public static void RunHighScoreAll()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            
            Console.WriteLine("\n\n\n\t\tHIGHSCORE - LISTA: Högsta poäng för respektive spel!");
            Console.WriteLine("\t\t******************");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            HighscoreList highscore = new HighscoreList();
            highscore.ShowAllHighScore();

            Console.WriteLine();
                                
        }
        public static void PrintHighscoreEachGame(string game, List<HighScoreEachGame> lista)
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            
            Console.WriteLine($"\n\n\n\t\tHIGHSCORE - LISTA: Högsta poäng för {game}!");
            Console.WriteLine("\t\t******************");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            int counter = 1;
            foreach (var line in lista)
            {
                Console.WriteLine($"\t\t{counter}. {line.Name}, {line.Points} poäng.");
                counter++;
            }
        }

            public static string[] ReadInHighScore(string textPath)
        {
            string[] lines = File.ReadAllLines(textPath);
            string[] nameAndPoints = new string[2];
            foreach (string line in lines)
            {
                nameAndPoints = line.Split('=');
                break;

            }
            return nameAndPoints;
        }
       
    }
}
