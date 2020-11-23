using System;
using System.Collections.Generic;
using System.Text;

namespace HelenasSpelcenter
{
    class Bird
    {
        public static bool Alive { get; set; }

        public static string[,] BirdStrings { get; set; }
        public static int XStartPosition { get; set; }
        public static int YStartPosition { get; set; }
        public static int BirdSizeX { get; set; }
        public static int BirdSizeY { get; set; }

        public static void CreateBird()
        {
            BirdSizeY = 3;
            BirdSizeX = 4;
            BirdStrings = new string[BirdSizeY, BirdSizeX];
            BirdStrings[0, 0] = " ";
            BirdStrings[0, 1] = "(";
            BirdStrings[0, 2] = "@";
            BirdStrings[0, 3] = ">";
            BirdStrings[1, 0] = "{";
            BirdStrings[1, 1] = "<";
            BirdStrings[1, 2] = "D";
            BirdStrings[1, 3] = " ";
            BirdStrings[2, 0] = " ";
            BirdStrings[2, 1] = "\"";
            BirdStrings[2, 2] = "\"";
            BirdStrings[2, 3] = " ";

        }

        //  (@>  
        // {<D
        //  ""
    }
}
