using System;
using System.Collections.Generic;
using System.Text;

namespace HelenasSpelcenter
{
    public class GameBoardSnake
    {
        public static int YSize { get; set; }
        public static int XSize { get; set; }

        public GameBoardSnake(int x, int y)
        {
            YSize = y;
            XSize = x;
        }

        public static void PrintOutGameBoard(List<SnakeFragment> fragments, Apple apple)
        {
            int y = 0;
            int x = 0;
            bool positionfilled;
            bool snakeHere;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            //Console.BackgroundColor = ConsoleColor.White;
            for (y = 0; y < GameBoardSnake.YSize; y++)
            {
                Console.Write("\t\t\t\t\t");
                for (x = 0; x < GameBoardSnake.XSize; x++)
                {
                    positionfilled = false;
                    snakeHere = false;
                    if (x == 0 || x == GameBoardSnake.XSize - 1)
                    {
                        Console.Write("\u2588");
                        positionfilled = true;
                    }
                    else if (y == 0 || y == GameBoardSnake.YSize - 1)
                    {
                        Console.Write("\u2588");
                        positionfilled = true;
                    }

                    foreach (SnakeFragment pos in fragments)
                    {
                        if (pos.XPosition == x && pos.YPosition == y)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("\u019F");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            positionfilled = true;
                            snakeHere = true;
                            break;
                        }

                    }
                    if (apple.XPosition == x && apple.YPosition == y)
                    {
                        if (!snakeHere)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("\u2665");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            positionfilled = true;

                        }
                        else
                        {
                            SnakeGame.Counter++;
                            //add snake fragment
                            SnakeGame.AddSnakeFragment = true;
                            //set new apple
                            apple.NewApplePosition();
                        }
                    }
                    if (!positionfilled)
                    {
                        Console.Write(" ");
                    }


                }
                Console.WriteLine();
            }
        }
    }
}
