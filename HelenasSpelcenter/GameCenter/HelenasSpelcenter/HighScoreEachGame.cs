using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HelenasSpelcenter
{
    public class HighScoreEachGame
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public int Seconds { get; set; }

        public static List<HighScoreEachGame> ListSnake = new List<HighScoreEachGame>();
        
        public static List<HighScoreEachGame> ListYatzy = new List<HighScoreEachGame>();
        
        public static List<HighScoreEachGame> ListFlappyBird = new List<HighScoreEachGame>();

        public static List<HighScoreEachGame> ListSecretCode = new List<HighScoreEachGame>();

        public HighScoreEachGame(string name, int points)
        {
            Name = name;
            Points = points;
        }
        public HighScoreEachGame(string name, int guesses, int seconds)
        {
            Name = name;
            Points = guesses;
            Seconds = seconds;
        }

        //public static List<HighScoreEachGame> HighscoreList { get; set; }
        //public static Hashtable HighscoreList { get; set; }


        public static void OpenHighscores(string path, List<HighScoreEachGame> lista)
        {
            lista.Clear();

            if (!File.Exists(path))
            {
                StreamWriter sw = File.CreateText(path);
                for (int i = 0; i < 10; i++)
                {
                    sw.WriteLine("-=0");
                }
                sw.Close();
            }

            string[] lines = File.ReadAllLines(path);
            

            foreach (string line in lines)
            {
                string[] nameAndPoints = line.Split('=');
                int points = int.Parse(nameAndPoints[1]);
                lista.Add(new HighScoreEachGame(nameAndPoints[0], points));

            }
            
        }

        public static void OpenHighscoresSecretCode()
        {
            if (!File.Exists("secretcodehighscore.txt"))
            {
                StreamWriter sw = File.CreateText("secretcodehighscore.txt");
                for (int i = 0; i < 20; i++)
                {
                    sw.WriteLine("---;0;0");
                }
                sw.Close();
            }
            string[] lines = File.ReadAllLines("secretcodehighscore.txt");
            

            foreach (string line in lines)
            {
                string[] nameAndPoints = line.Split(';');
                int points = int.Parse(nameAndPoints[1]);
                int seconds = int.Parse(nameAndPoints[2]);
                ListSecretCode.Add(new HighScoreEachGame(nameAndPoints[0], points, seconds));

            }
           
        }

        public static void PrintOutHighscores(string gameText, List<HighScoreEachGame> lista)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\n\n");
            Console.WriteLine("\t\t\t\t\t" + gameText);
            Console.WriteLine("\t\t\t\t\t-------------------------------------");
            int counter = 1;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            foreach (var line in lista)
            {
                Console.WriteLine($"\t\t\t\t\t\t{counter}. {line.Name}, {line.Points} poäng.");
                counter++;
            }
            Console.WriteLine("\t\t\t\t\t-------------------------------------");
        }
        public static void PrintOutHighscoresSecretCode()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n");
            Console.WriteLine("\t\t\t\t~*~~~~*~~~~HIGHSCORE SECRET CODE~~~~*~~~~*~");
            Console.WriteLine("\t\t\t\t~*~~~~*~~~~*~~~~*~~~~*~~~~*~~~~*~~~~*~~~~*~");
            Console.WriteLine("\t\t\t\t-------------------------------------------");
            int counter = 1;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t~*~~~~*~~~~ Secret Code 3 ~~~~*~~~~*~~~~*~");
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"\t\t\t\t\t{counter}. {ListSecretCode[i].Name}, {ListSecretCode[i].Points} guesses, {ListSecretCode[i].Seconds} seconds.");
                counter++;
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\t\t\t\t-------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t~*~~~~*~~~~ Secret Code 4 ~~~~*~~~~*~~~~*~");
            Console.ForegroundColor = ConsoleColor.Yellow;
            counter = 1;
            for (int i = 5; i < 10; i++)
            {
                Console.WriteLine($"\t\t\t\t\t{counter}. {ListSecretCode[i].Name}, {ListSecretCode[i].Points} guesses, {ListSecretCode[i].Seconds} seconds.");
                counter++;
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\t\t\t\t-------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t~*~~~~*~~~~ Secret Code 5 ~~~~*~~~~*~~~~*~");
            Console.ForegroundColor = ConsoleColor.Yellow;
            counter = 1;
            for (int i = 10; i < 15; i++)
            {
                Console.WriteLine($"\t\t\t\t\t{counter}. {ListSecretCode[i].Name}, {ListSecretCode[i].Points} guesses, {ListSecretCode[i].Seconds} seconds.");
                counter++;
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\t\t\t\t-------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t~*~~~~*~~~~ Secret Code 6 ~~~~*~~~~*~~~~*~");
            Console.ForegroundColor = ConsoleColor.Yellow;
            counter = 1;
            for (int i = 15; i < 20; i++)
            {
                Console.WriteLine($"\t\t\t\t\t{counter}. {ListSecretCode[i].Name}, {ListSecretCode[i].Points} guesses, {ListSecretCode[i].Seconds} seconds.");
                counter++;
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\t\t\t\t-------------------------------------------");
        }

        public static int SeeIfHighscore(List<HighScoreEachGame> lista, int record)
        {
            int counter = 0;
            foreach (var points in lista)
            {
                if (points.Points < record)
                { return counter; }
                counter++;
            }
            return 100;
        }
        public static int SeeIfHighscoreSecretCode(int point, int seconds, int level)
        {
            int counter = 0;
            for (int i = 0 + 5 * level; i < 5 + 5 * level; i++)
            {
                if (ListSecretCode[i].Points > point || ListSecretCode[i].Points == 0)
                { return counter; }
                else if (ListSecretCode[i].Points == point)
                {
                    if (ListSecretCode[i].Seconds > seconds)
                    { return counter; }
                }
                counter++;
            }

            return 100;
        }
        public static string GetName()
        {
            Console.Write("\t\t\t\t\tWrite your name: ");
            string name = Console.ReadLine();
            return name;
        }
        public static void PutHighScoreInFile(string path, List<HighScoreEachGame> lista)
        {
            int counter = 0;
            StreamWriter sw = File.CreateText(path);
            foreach (var line in lista)
            {


                sw.WriteLine($"{line.Name}={line.Points}");
                counter++;
                if (counter == 10)
                { break; }
            }
            sw.Close();
        }
        //public static void OpenAndPrintHighscore()
        //{
        //    Console.Clear();
        //    HighScoreEachGame.OpenHighscores();
        //    HighScoreEachGame.PrintOutHighscores();
        //    Console.WriteLine();
        //}
        public static void PutHighScoreInList(int place, int record, List<HighScoreEachGame> lista)
        {
            HighScoreEachGame highscore = new HighScoreEachGame(GetName(), record);

            lista.Insert(place, highscore);
        }
         
        

        
        public static void PutHighScoreInFile()
        {
            int counter = 0;
            StreamWriter sw = File.CreateText("secretcodehighscore.txt");
            foreach (var line in ListSecretCode)
            {


                sw.WriteLine($"{line.Name};{line.Points};{line.Seconds}");
                counter++;
                if (counter == 20)
                { break; }
            }
            sw.Close();
        }
        public static void OpenAndPrintHighscore()
        {

            HighScoreEachGame.OpenHighscoresSecretCode();
            HighScoreEachGame.PrintOutHighscoresSecretCode();
            Console.WriteLine();
        }
        public static void PutHighScoreInListSecretCode(int place, int lap)
        {
            HighScoreEachGame highscore = new HighScoreEachGame(GetName(), lap, SecretCodeGame.Seconds);

            ListSecretCode.Insert(place, highscore);
            if (place < 5)
            {
                ListSecretCode.RemoveAt(5);
            }
            else if (place > 4 && place < 10)
            {
                ListSecretCode.RemoveAt(10);
            }
            else if (place > 9 && place < 15)
            {
                ListSecretCode.RemoveAt(15);
            }

        }
    }
}

