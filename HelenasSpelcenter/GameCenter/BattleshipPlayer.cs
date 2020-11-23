using System;
using System.Collections.Generic;
using System.Text;

namespace HelenasSpelcenter
{
    class BattleshipPlayer
    {
        public List<BattleshipBoat> BoatsOnBoard { get; set; }
        public string Name { get; set; }
        public string[,] BoardInPrint { get; set; }

        public int GuessedX { get; set; }
        public int GuessedY { get; set; }

        public int CountFoundSubmarines { get; set; }
        public int CountFoundShips { get; set; }
        public int CountFoundDestroyers { get; set; }

        public bool AllFound { get; set; }


        public BattleshipPlayer(int numberOnPLayer)
        {
            Name = GetNameOnPlayer(numberOnPLayer);
            BoatsOnBoard = CreateListOfBoats();
            BoardInPrint = CreateEmptyPlayerBoard();
            CountFoundSubmarines = 0;
            CountFoundShips = 0;
            CountFoundDestroyers = 0;
            AllFound = false;
        }

        public void CheckIfDone()
        {
            if (CountFoundSubmarines == 1 && CountFoundShips == 2 && CountFoundDestroyers == 3)
            {
                AllFound = true;
                BattleShipGame.PlayersDone++;
                Console.WriteLine($"\n\t\t\tGrattis {Name}! Du klarade spelet, du kom på plats {BattleShipGame.PlayersDone}.");
            }
        }


        public void GuessXAndY()
        {
            GuessedX = GuessX();
            GuessedY = GuessY();
        }

        public void PrintBoard()
        {
            Console.WriteLine($"\t\t\t\tY: ");
            for (int i = 0; i < BattlechipBoard.SizeOfBoardY; i++)
            {

                Console.Write($"\t\t\t\t{i + 1}: ");
                for (int j = 0; j < BattlechipBoard.SizeOfBoardY; j++)
                {
                    //ändrat här
                    if (BoardInPrint[i, j] == " J" && CountFoundDestroyers == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(BoardInPrint[i, j]);
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else if (BoardInPrint[i, j] == " S" && CountFoundShips == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(BoardInPrint[i, j]);
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else if (BoardInPrint[i, j] == " U" && CountFoundSubmarines == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(BoardInPrint[i, j]);
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else { Console.Write(BoardInPrint[i, j]); }
                }
                Console.WriteLine();
            }
            Console.Write($"\t\t\t\tX: ");
            for (int i = 0; i < BattlechipBoard.SizeOfBoardX; i++)
            {
                Console.Write($"{i + 1} ");
            }
            Console.WriteLine();

        }

        public void UpdateBoardWithGuess()
        {
            for (int y = 0; y < BattlechipBoard.SizeOfBoardY; y++)
            {
                for (int x = 0; x < BattlechipBoard.SizeOfBoardX; x++)
                {
                    if (x == GuessedX && y == GuessedY)
                    {
                        //gå igenom båt för träff
                        foreach (BattleshipBoat boat in BoatsOnBoard)
                        {

                            if (boat is Submarine)
                            {
                                if (boat.X1 == GuessedX && boat.Y1 == GuessedY)
                                {
                                    BoardInPrint[y, x] = " U";
                                    CountFoundSubmarines++;
                                    break;
                                }

                            }
                            if (boat is Ship)

                            {
                                if (boat.X1 == GuessedX && boat.Y1 == GuessedY || boat.X2 == GuessedX && boat.Y2 == GuessedY)
                                {
                                    BoardInPrint[y, x] = " S";
                                    CountFoundShips++;
                                    break;
                                }
                            }
                            if (boat is Destroyer)

                            {
                                if (boat.X1 == GuessedX && boat.Y1 == GuessedY || boat.X2 == GuessedX && boat.Y2 == GuessedY || boat.X3 == GuessedX && boat.Y3 == GuessedY)
                                {
                                    BoardInPrint[y, x] = " J";
                                    CountFoundDestroyers++;
                                    break;
                                }
                            }
                            else
                            {
                                BoardInPrint[y, x] = " X";
                            }
                        }



                    }
                }
            }

        }


        public static int GuessX()
        {
            int x;
            bool ok;
            Console.WriteLine("\n\t\t\tGissa på en kordinat.");
            Console.Write("\t\t\tTryck först in numret på X: ");
            while (true)
            {
                ok = int.TryParse(Console.ReadLine(), out x);
                if (!ok || x > BattlechipBoard.SizeOfBoardX || x < 1)
                {
                    Console.WriteLine("\t\t\tFörsök igen.");
                }
                else { break; }
            }
            return x - 1;

        }
        public static int GuessY()
        {
            int y;
            bool ok;
            Console.Write("\t\t\tTryck in numret på Y: ");
            while (true)
            {
                ok = int.TryParse(Console.ReadLine(), out y);
                if (!ok || y > BattlechipBoard.SizeOfBoardX || y < 1)
                {
                    Console.WriteLine("\t\t\tFörsök igen.");
                }
                else { break; }
            }
            return y - 1;

        }

        public static void CreatePlayers(int numberOfPLayers)
        {
            for (int i = 0; i < numberOfPLayers; i++)
            {
                new BattleshipPlayer(i + 1);
            }
        }


        public List<BattleshipBoat> CreateListOfBoats()
        {
            Submarine submarine = new Submarine(BattlechipBoard.SizeOfBoardX, BattlechipBoard.SizeOfBoardY);
            Ship ship = new Ship(BattlechipBoard.SizeOfBoardX, BattlechipBoard.SizeOfBoardY, submarine);
            Destroyer destroyer = new Destroyer(BattlechipBoard.SizeOfBoardX, BattlechipBoard.SizeOfBoardY, submarine, ship);

            List<BattleshipBoat> lista = new List<BattleshipBoat>();
            lista.Add(submarine);
            lista.Add(ship);
            lista.Add(destroyer);
            return lista;
        }
        public string GetNameOnPlayer(int numberOnPlayer)
        {
            Console.WriteLine($"\n\t\t\tSpelare {numberOnPlayer}: Vad heter du?");
            Console.Write("\t\t\t"); string namn = Console.ReadLine();
            return namn;
        }
        public string[,] CreateEmptyPlayerBoard()
        {
            string[,] board = new string[BattlechipBoard.SizeOfBoardY, BattlechipBoard.SizeOfBoardX];

            for (int y = 0; y < BattlechipBoard.SizeOfBoardY; y++)
            {
                for (int x = 0; x < BattlechipBoard.SizeOfBoardX; x++)
                {
                    board[y, x] = "\u2591\u2591";
                }
            }
            return board;
        }

        public static int HowManyPlayers()
        {
            bool ok;
            int numberOfPLayers = 0;
            Console.WriteLine("\n\t\t\tHur många spelare vill ni vara?");
            Console.WriteLine("\t\t\tMata in ett nummer (1-4) och tryck ENTER: ");
            while (true)
            {
                Console.Write("\t\t\t");
                ok = int.TryParse(Console.ReadLine(), out numberOfPLayers);
                if (!ok || numberOfPLayers < 1 || numberOfPLayers > 4)
                {
                    Console.WriteLine("\t\t\tFörsök igen.");
                }
                else { break; }
            }
            return numberOfPLayers;
        }

    }
}
