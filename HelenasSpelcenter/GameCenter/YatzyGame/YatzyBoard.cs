using System;
using System.Collections.Generic;
using System.Text;

namespace HelenasSpelcenter.YatzyGame
{
    public class Yatzyboard
    {
        public string Type { get; set; }

        public List<YatzyPlayer> Players { get; set; }


        public static List<Yatzyboard> CreateEmptyYatzyboard(List<YatzyPlayer> players)
        {
            List<Yatzyboard> yatzyboard = new List<Yatzyboard>();
            yatzyboard.Add(new YatzyScoreboard(1, "Ettor", players));
            yatzyboard.Add(new YatzyScoreboard(2, "Tvåor", players));
            yatzyboard.Add(new YatzyScoreboard(3, "Treor", players));
            yatzyboard.Add(new YatzyScoreboard(4, "Fyror", players));
            yatzyboard.Add(new YatzyScoreboard(5, "Femmor", players));
            yatzyboard.Add(new YatzyScoreboard(6, "Sexor", players));
            yatzyboard.Add(new YatzyResultboard("SUMMA: ", players));
            yatzyboard.Add(new YatzyResultboard("BONUS: ", players));
            yatzyboard.Add(new YatzyScoreboard(7, "Ett par", players));
            yatzyboard.Add(new YatzyScoreboard(8, "Två par", players));
            yatzyboard.Add(new YatzyScoreboard(9, "Tretal", players));
            yatzyboard.Add(new YatzyScoreboard(10, "Fyrtal", players));
            yatzyboard.Add(new YatzyScoreboard(11, "Liten straight", players));
            yatzyboard.Add(new YatzyScoreboard(12, "Stor straight", players));
            yatzyboard.Add(new YatzyScoreboard(13, "Kåk", players));
            yatzyboard.Add(new YatzyScoreboard(14, "Chans", players));
            yatzyboard.Add(new YatzyScoreboard(15, "YATZY", players));
            yatzyboard.Add(new YatzyResultboard("TOTALSUMMA: ", players));

            return yatzyboard;
        }

        public static void PrintOutYatzyboard(List<Yatzyboard> yatzyboard, List<YatzyPlayer> players)
        {
            Console.WriteLine("\t~*~~~*~~~*~~~*~~~*~ YATZY SPELPLAN ~*~~~*~~~*~~~*~~~*~");
            Console.WriteLine("\t-------------------------------------------------------");
            Console.Write("\t\t\t\t");
            foreach (YatzyPlayer player in players)
            {
                Console.Write($"{player.Name}\t");
            }
            Console.WriteLine();
            Console.WriteLine("\t-------------------------------------------------------");
            int counter = 0;
            foreach (var line in yatzyboard)
            {
                
                if (line is YatzyScoreboard)
                {
                    if (((YatzyScoreboard)line).Number == 11 || ((YatzyScoreboard)line).Number == 12)
                    { Console.Write($"\t{((YatzyScoreboard)line).Number}.\t{line.Type}\t"); }
                    else
                    { Console.Write($"\t{((YatzyScoreboard)line).Number}.\t{line.Type}\t\t"); }
                    foreach (YatzyPlayer player in line.Players)
                    {
                        
                        if (player.Sums[counter].IsSumSet)
                        { Console.Write(player.Sums[counter].Sum + "\t"); }
                        else { Console.Write("\t"); }
                        
                        
                    }
                    Console.WriteLine();
                    if (((YatzyScoreboard)line).Number == 6 || ((YatzyScoreboard)line).Number == 15)
                    {
                        Console.WriteLine("\t-------------------------------------------------------");
                    }
                }
                if (line is YatzyResultboard)
                {
                    Console.Write($"\t{line.Type}\t\t\t");
                    foreach (YatzyPlayer player in line.Players)
                    {
                        if (player.Sums[counter].IsSumSet)
                        { Console.Write(player.Sums[counter].Sum + "\t"); }
                        else { Console.Write("\t"); }


                    }
                    Console.WriteLine();
                    if (((YatzyResultboard)line).Type == "BONUS: " || ((YatzyResultboard)line).Type == "TOTALSUMMA: ")
                    {
                        Console.WriteLine("\t-------------------------------------------------------");
                    }
                }
                counter++;
               
            }
        }
    }
}
