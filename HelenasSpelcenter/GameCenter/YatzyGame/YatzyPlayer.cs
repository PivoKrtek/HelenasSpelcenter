using System;
using System.Collections.Generic;
using System.Text;

namespace HelenasSpelcenter.YatzyGame
{
    public class YatzyPlayer
    {
        public string Name { get; set; }
        public List<YatzySum> Sums { get; set; }
        public int YatzyRecord { get; set; }

        public YatzyPlayer()
        {
            Name = SetName();
            Sums = GenerateListOfSums();
        }

        public List<YatzySum> GenerateListOfSums()
        {
            List<YatzySum> yatzySums = new List<YatzySum>();
            for (int i = 0; i < 18; i++)
            {
                yatzySums.Add(new YatzySum());
            }
            return yatzySums;
        }
       
        private string SetName()
        {
            Console.Write("Ange ditt namn: ");
            string name = Console.ReadLine();
            return name;
        }

        public static List<YatzyPlayer> CreateListOfPLayers(int numberOfPLayers)
        {
            List<YatzyPlayer> players = new List<YatzyPlayer>();
            for (int i = 0; i < numberOfPLayers; i++)
            {
                Console.Write($"\tSPELARE {i+1} "); 
                players.Add(new YatzyPlayer());
            }
            return players;
        }

        public static int HowManyPlayers()
        {
            bool ok;
            int numberOfPLayers = 0;
            Console.WriteLine("\tHur många spelare vill ni vara?");
            Console.WriteLine("\tMata in ett nummer (1-4) och tryck ENTER: ");
            while (true)
            {
                ok = int.TryParse(Console.ReadLine(), out numberOfPLayers);
                if (!ok || numberOfPLayers < 1 || numberOfPLayers > 4)
                {
                    Console.WriteLine("\tFörsök igen.");
                }
                else { break; }
            }
            return numberOfPLayers;
        }
    }
}
