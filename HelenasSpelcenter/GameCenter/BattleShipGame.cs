using System;
using System.Collections.Generic;
using System.Text;

namespace HelenasSpelcenter
{
    class BattleShipGame
    {
        public static int NumberOfPlayer { get; set; }

        public static BattleshipPlayer Player1 { get; set; }
        public static BattleshipPlayer Player2 { get; set; }
        public static BattleshipPlayer Player3 { get; set; }
        public static BattleshipPlayer Player4 { get; set; }

        public static List<BattleshipPlayer> Players { get; set; }
        public static int PlayersDone { get; set; }
        public static bool playAgain = true;
        public static void PlayBattleShip()
        {
            while (playAgain)
            {
                playAgain = false;
                Console.Clear();
                BattleShipIntro();
                Console.Clear();
                TextBattleShip();
                BattlechipBoard.SizeOfBoardX = BattlechipBoard.DecideXSizeOnBoard();
                BattlechipBoard.SizeOfBoardY = BattlechipBoard.DecideYSizeOnBoard();
                Console.Clear();
                TextBattleShip();
                PlayersDone = 0;
                NumberOfPlayer = BattleshipPlayer.HowManyPlayers();
                Players = CreatePlayers();
                Console.Clear();

                //tillfälligt - kolla så de hamnar rätt!
                //TryPrint(Player1.BoatsOnBoard);
                //Console.ReadLine();
                while (NumberOfPlayer != PlayersDone)
                {
                    foreach (var player in Players)
                    {
                        if (player.AllFound == false)
                        {
                            Console.Clear();
                            TextBattleShip();
                            YourTurn(player);
                            player.PrintBoard();
                            player.GuessXAndY();
                            player.UpdateBoardWithGuess();
                            Console.Clear();
                            TextBattleShip();
                            YourResult(player);
                            player.PrintBoard();
                            Console.WriteLine();
                            player.CheckIfDone();
                            Console.ReadLine();
                        }
                    }

                }
                PlayAgain();
                int choice = InputNumber(0, 1);
                if (choice == 1)
                { playAgain = true; }
            }
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
                    Console.WriteLine("\t\t\t\tWrong input. Try again.");
                }
                else { break; }
            }
            return inputNumber;
        }
        public static void YourTurn(BattleshipPlayer player)
        {
            Console.WriteLine($"\n\t\t\tSPELARE {Players.IndexOf(player) + 1}: {player.Name}, din tur!");
            Console.WriteLine("\t\t\t---------------------------------------");
        }

        public static void YourResult(BattleshipPlayer player)
        {
            Console.WriteLine($"\n\t\t\tSPELARE {Players.IndexOf(player) + 1}: {player.Name}, din gissning visade:");
            Console.WriteLine("\t\t\t---------------------------------------");
        }
        public static List<BattleshipPlayer> CreatePlayers()
        {
            List<BattleshipPlayer> lista = new List<BattleshipPlayer>();
            for (int i = 0; i < NumberOfPlayer; i++)
            {

                if (i == 0)
                {
                    Player1 = new BattleshipPlayer(i + 1);
                    lista.Add(Player1);
                }
                if (i == 1)
                {
                    Player2 = new BattleshipPlayer(i + 1);
                    lista.Add(Player2);
                }
                if (i == 2)
                {
                    Player3 = new BattleshipPlayer(i + 1);
                    lista.Add(Player3);
                }
                if (i == 3)
                {
                    Player4 = new BattleshipPlayer(i + 1);
                    lista.Add(Player4);
                }

            }
            return lista;
        }

        public static void BattleShipIntro()
        {
            string emptyspace = "   ";
            for (int i = 0; i < 28; i++)
            {
                Console.SetCursorPosition(0, 0);

                emptyspace += "  ";
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\n\t      {emptyspace}        |    |    |                 \n\t   {emptyspace}          )_)  )_)  )_)              \n\t  {emptyspace}          )___))___))___)\\            \n\t  {emptyspace}         )____)____)_____)\\\\ \n\t{emptyspace}         _____|____|____|____\\\\__\n\t{emptyspace}         \\                   / ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\t^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^\n");
                System.Threading.Thread.Sleep(100);
            }
            System.Threading.Thread.Sleep(200);
            TextBattleShip();

            System.Threading.Thread.Sleep(200);

            Console.WriteLine("\n\n\t\tVälj storlek på spelplanen.");
            Console.WriteLine("\t\tVälj hur många spelare ni är.");
            Console.WriteLine("\t\tDet gäller att hitta de tre skeppen som är gömda i spelplanen.");
            Console.WriteLine("\t\tSkeppen kan ligga lodrätt eller vågrätt.");
            Console.WriteLine("\t\tDe som är gömda är en Ubåt (1 position), Skepp (2 positioner) samt Jägare (3 positioner).");
            Console.WriteLine("\n\t\tLYCKA TILL!");


            Console.WriteLine("\n\t\tTryck valfri tangent för att starta.");
            Console.ReadKey(true);
        }
        static void TextBattleShip()
        {
            Console.WriteLine("\t _______  __#_#__  __    _  ___   _  _______    _______  ___   _  _______  _______  _______ ");
            Console.WriteLine("\t|       ||   _   ||  |  | ||   | | ||   _   |  |       ||   | | ||       ||       ||       |");
            Console.WriteLine("\t|  _____||  |_|  ||   |_| ||   |_| ||  |_|  |  |  _____||   |_| ||    ___||    _  ||    _  |");
            Console.WriteLine("\t| |_____ |       ||       ||      _||       |  | |_____ |      _||   |___ |   |_| ||   |_| |");
            Console.WriteLine("\t|_____  ||       ||  _    ||     |_ |       |  |_____  ||     |_ |    ___||    ___||    ___|");
            Console.WriteLine("\t _____| ||   _   || | |   ||    _  ||   _   |   _____| ||    _  ||   |___ |   |    |   |    ");
            Console.WriteLine("\t|_______||__| |__||_|  |__||___| |_||__| |__|  |_______||___| |_||_______||___|    |___|    ");
        }

        public static void PlayAgain()
        {
            Console.WriteLine("\t\t\tSpela igen?");
            Console.WriteLine("\t\t\t[1] --> JA!");
            Console.WriteLine("\t\t\t[0] --> NEJ.");
            Console.Write("\t\t\t");
        }
    }
}
