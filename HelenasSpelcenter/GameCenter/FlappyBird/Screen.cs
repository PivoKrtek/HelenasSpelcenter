using System;
using System.Collections.Generic;
using System.Text;

namespace HelenasSpelcenter
{
    class Screen
    {
        public static string[,] StringsMakingScreen { get; set; }
        public static int XHere { get; set; }
        public static int BirdHere { get; set; }
        public static int FieldHere { get; set; }

        public static void CreateScreen()
        {
            for (int y = 0; y < FlappyBirdGame.HeightOfGameWindow; y++)
            {
                for (int x = 0; x < FlappyBirdGame.WidhtOfGameWindow; x++)
                {
                    XHere = 0;
                    BirdHere = 0;
                    FieldHere = 0;
                    if (x >= FlappyBirdGame.Field1.XStartPosition && x < FlappyBirdGame.Field1.XStartPosition + GreenField.WidthSizeOfField)
                    {
                        FieldHere++;

                        StringsMakingScreen[y, x] = FlappyBirdGame.Field1.Field[y, x - FlappyBirdGame.Field1.XStartPosition];
                        if (FlappyBirdGame.Field1.Field[y, x - FlappyBirdGame.Field1.XStartPosition] == "\u2736")
                        { XHere++; }
                    }
                    else if (x >= FlappyBirdGame.Field2.XStartPosition && x < FlappyBirdGame.Field2.XStartPosition + GreenField.WidthSizeOfField)
                    {
                        FieldHere++;

                        StringsMakingScreen[y, x] = FlappyBirdGame.Field2.Field[y, x - FlappyBirdGame.Field2.XStartPosition];
                        if (FlappyBirdGame.Field2.Field[y, x - FlappyBirdGame.Field2.XStartPosition] == "\u2736")
                        { XHere++; }
                    }
                    else if (x >= FlappyBirdGame.Field3.XStartPosition && x < FlappyBirdGame.Field3.XStartPosition + GreenField.WidthSizeOfField)
                    {
                        FieldHere++;

                        StringsMakingScreen[y, x] = FlappyBirdGame.Field3.Field[y, x - FlappyBirdGame.Field3.XStartPosition];
                        if (FlappyBirdGame.Field3.Field[y, x - FlappyBirdGame.Field3.XStartPosition] == "\u2736")
                        { XHere++; }
                    }
                    else if (x >= FlappyBirdGame.Field4.XStartPosition && x < FlappyBirdGame.Field4.XStartPosition + GreenField.WidthSizeOfField)
                    {
                        FieldHere++;

                        StringsMakingScreen[y, x] = FlappyBirdGame.Field4.Field[y, x - FlappyBirdGame.Field4.XStartPosition];
                        if (FlappyBirdGame.Field4.Field[y, x - FlappyBirdGame.Field4.XStartPosition] == "\u2736")
                        { XHere++; }
                    }
                    else if (x >= FlappyBirdGame.Field5.XStartPosition && x < FlappyBirdGame.Field5.XStartPosition + GreenField.WidthSizeOfField)
                    {
                        FieldHere++;

                        StringsMakingScreen[y, x] = FlappyBirdGame.Field5.Field[y, x - FlappyBirdGame.Field5.XStartPosition];
                        if (FlappyBirdGame.Field5.Field[y, x - FlappyBirdGame.Field5.XStartPosition] == "\u2736")
                        { XHere++; }
                    }
                    if (x >= Bird.XStartPosition && x < Bird.XStartPosition + Bird.BirdSizeX && y >= Bird.YStartPosition && y < Bird.YStartPosition + Bird.BirdSizeY)
                    {
                        if (Bird.BirdStrings[y - Bird.YStartPosition, x - Bird.XStartPosition] != " " && XHere > 0 && Bird.Alive)
                        {
                            Bird.Alive = false;
                        }
                        else if (Bird.BirdStrings[y - Bird.YStartPosition, x - Bird.XStartPosition] != " ")
                        {
                            BirdHere++;
                            StringsMakingScreen[y, x] = Bird.BirdStrings[y - Bird.YStartPosition, x - Bird.XStartPosition];
                        }
                    }

                    if (BirdHere < 1 && XHere < 1 && FieldHere < 1)
                    {
                        StringsMakingScreen[y, x] = " ";
                    }
                }

            }

        }
        public static void PrintScreen()
        {
            for (int y = 0; y < FlappyBirdGame.HeightOfGameWindow; y++)
            {
                for (int x = 0; x < FlappyBirdGame.WidhtOfGameWindow; x++)
                {
                    if (StringsMakingScreen[y, x] == "\u2736")
                    { Console.ForegroundColor = ConsoleColor.Green; }
                    else if (StringsMakingScreen[y, x] == "@")
                    {
                        if (!Bird.Alive)
                        {
                            StringsMakingScreen[y, x] = "+";
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else { Console.ForegroundColor = ConsoleColor.Blue; }
                    }
                    else if (StringsMakingScreen[y, x] == ">" || StringsMakingScreen[y, x] == "\"")
                    { Console.ForegroundColor = ConsoleColor.Red; }
                    else if (StringsMakingScreen[y, x] != " ")
                    { Console.ForegroundColor = ConsoleColor.Yellow; }
                    Console.Write(StringsMakingScreen[y, x]);

                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"\tPOINTS: {FlappyBirdGame.Points}");
        }

        public static void StartGame()
        {
            Console.WriteLine("\n\n\n\n\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("        _______ _____   _______ ______ ______ ___ ___      ______ _______ ______ _____");
            Console.WriteLine("       |    ___|     |_|   _   |   __ \\   __ \\   |   |    |   __ \\_     _|   __ \\     \\");
            Console.WriteLine("       |    ___|       |       |    __/    __/\\     /     |   __ <_|   |_|      <  --  |");
            Console.WriteLine("       |___|   |_______|___|___|___|  |___|    |___|      |______/_______|___|__|_____/ ");

            Console.WriteLine("\n\n\n");
            Console.WriteLine("                                UP ARROW --> Fly two steps up");
            Console.WriteLine("                                 SPACE --> Fly three steps up\n");

            Console.WriteLine("                               START GAME pressing any key...");
            Console.ReadKey(true);
        }
        public static void EndGame()
        {
            Console.WriteLine("\n\n\n\n\n");
            Console.ForegroundColor = ConsoleColor.Red;


            Console.WriteLine("\n\n\n");

            Console.WriteLine("                                         YOU DIED...");
            Console.WriteLine("\n\n\n");
            Console.WriteLine("                               PRESS ENTER to see HIGHSCORE");
            Console.ReadLine();
        }
    }
}
