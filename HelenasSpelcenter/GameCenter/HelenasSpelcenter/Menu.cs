using System;

namespace HelenasSpelcenter
{
    class Menu
    {
        public static void ShowMenu()
        {
            int speedMenu = 350;
            //tabba in
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t\t\t\t[1] --> SÄNKA SKEPP (1-4 spelare)");
            System.Threading.Thread.Sleep(speedMenu);
            Console.WriteLine("\t\t\t\t[2] --> YATZY (1-4 spelare)");
            System.Threading.Thread.Sleep(speedMenu);
            Console.WriteLine("\t\t\t\t[3] --> HÄNGA GUBBE (1-2 spelare)");
            System.Threading.Thread.Sleep(speedMenu);
            Console.WriteLine("\t\t\t\t[4] --> SECRET CODE (1 spelare)");
            System.Threading.Thread.Sleep(speedMenu);
            Console.WriteLine("\t\t\t\t[5] --> FLAPPY BIRD (1 spelare)");
            System.Threading.Thread.Sleep(speedMenu);
            Console.WriteLine("\t\t\t\t[6] --> SPEL SNAKE (1 spelare)\n");
            System.Threading.Thread.Sleep(speedMenu);
            Console.WriteLine("\t\t\t\t[7] --> HIGHSCORE-LISTA\n");
            System.Threading.Thread.Sleep(speedMenu);
            Console.WriteLine("\t\t\t\t[0] --> EXIT\n");
            Console.WriteLine("\t\t\t\tTryck siffra motsvarande önskat spel.");

            Console.ForegroundColor = ConsoleColor.White;
        }

        public static int Input(int maximumChoice)
        {
            int number = 0;
            bool ok = false;
            while (!ok)
            {
                ok = int.TryParse(Console.ReadLine(), out number);
                if (!ok || number > maximumChoice || number < 0)
                { Console.WriteLine("Försök igen."); }
            }

            return number;
        }
        public static void ShortIntro()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\t\t\t██╗  ██╗███████╗██╗     ███████╗███╗   ██╗ █████╗ ███████╗");
            Console.WriteLine("\t\t\t██║  ██║██╔════╝██║     ██╔════╝████╗  ██║██╔══██╗██╔════╝");
            Console.WriteLine("\t\t\t███████║█████╗  ██║     █████╗  ██╔██╗ ██║███████║███████╗");
            Console.WriteLine("\t\t\t██╔══██║██╔══╝  ██║     ██╔══╝  ██║╚██╗██║██╔══██║╚════██║");
            Console.WriteLine("\t\t\t██║  ██║███████╗███████╗███████╗██║ ╚████║██║  ██║███████║");
            Console.WriteLine("\t\t\t╚═╝  ╚═╝╚══════╝╚══════╝╚══════╝╚═╝  ╚═══╝╚═╝  ╚═╝╚══════╝");
            Console.WriteLine();
            
            Console.WriteLine();
            Console.WriteLine("\t   ███████╗██████╗ ███████╗██╗      ██████╗███████╗███╗   ██╗████████╗███████╗██████╗");
            Console.WriteLine("\t   ██╔════╝██╔══██╗██╔════╝██║     ██╔════╝██╔════╝████╗  ██║╚══██╔══╝██╔════╝██╔══██╗");
            Console.WriteLine("\t   ███████╗██████╔╝█████╗  ██║     ██║     █████╗  ██╔██╗ ██║   ██║   █████╗  ██████╔╝");
            Console.WriteLine("\t   ╚════██║██╔═══╝ ██╔══╝  ██║     ██║     ██╔══╝  ██║╚██╗██║   ██║   ██╔══╝  ██╔══██╗");
            Console.WriteLine("\t   ███████║██║     ███████╗███████╗╚██████╗███████╗██║ ╚████║   ██║   ███████╗██║  ██║");
            Console.WriteLine("\t   ╚══════╝╚═╝     ╚══════╝╚══════╝ ╚═════╝╚══════╝╚═╝  ╚═══╝   ╚═╝   ╚══════╝╚═╝  ╚═╝");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void ShowIntro()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Threading.Thread.Sleep(150);
            Console.WriteLine("");
            Console.WriteLine("\t\t\t                             ██");
            Console.WriteLine("\t\t\t                             ══");
            Console.WriteLine("\t\t\t                             ╗ ");
            Console.WriteLine("\t\t\t                             ╝ ");
            Console.WriteLine("\t\t\t                             ██");
            Console.WriteLine("\t\t\t                             ══");
            System.Threading.Thread.Sleep(150);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("\t\t\t                           ████╗█");
            Console.WriteLine("\t\t\t                           ════╝█");
            Console.WriteLine("\t\t\t                           ██╗  █");
            Console.WriteLine("\t\t\t                           ══╝  █");
            Console.WriteLine("\t\t\t                           ████╗█");
            Console.WriteLine("\t\t\t                           ════╝╚");
            System.Threading.Thread.Sleep(150);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("\t\t\t                         ██████╗███");
            Console.WriteLine("\t\t\t                         █╔════╝███");
            Console.WriteLine("\t\t\t                         ████╗  ██╔");
            Console.WriteLine("\t\t\t                         █╔══╝  ██║");
            Console.WriteLine("\t\t\t                         ██████╗██║");
            Console.WriteLine("\t\t\t                         ══════╝╚═╝");
            System.Threading.Thread.Sleep(150);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("\t\t\t                        ███████╗███╗ ");
            Console.WriteLine("\t\t\t                        ██╔════╝████╗");
            Console.WriteLine("\t\t\t                        █████╗  ██╔██");
            Console.WriteLine("\t\t\t                        ██╔══╝  ██║╚█");
            Console.WriteLine("\t\t\t                       ╗███████╗██║ ╚");
            Console.WriteLine("\t\t\t                       ╝╚══════╝╚═╝  ");
            System.Threading.Thread.Sleep(150);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("\t\t\t                        ███████╗███╗   ");
            Console.WriteLine("\t\t\t                        ██╔════╝████╗  ");
            Console.WriteLine("\t\t\t                        █████╗  ██╔██╗ ");
            Console.WriteLine("\t\t\t                        ██╔══╝  ██║╚██╗");
            Console.WriteLine("\t\t\t                     ██╗███████╗██║ ╚██");
            Console.WriteLine("\t\t\t                     ══╝╚══════╝╚═╝  ╚═");
            System.Threading.Thread.Sleep(150);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("\t\t\t                        ███████╗███╗   ██");
            Console.WriteLine("\t\t\t                        ██╔════╝████╗  ██");
            Console.WriteLine("\t\t\t                        █████╗  ██╔██╗ ██");
            Console.WriteLine("\t\t\t                        ██╔══╝  ██║╚██╗██");
            Console.WriteLine("\t\t\t                   ████╗███████╗██║ ╚████");
            Console.WriteLine("\t\t\t                   ════╝╚══════╝╚═╝  ╚═══");
            System.Threading.Thread.Sleep(150);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("\t\t\t                 █╗     ███████╗███╗   ██╗ ");
            Console.WriteLine("\t\t\t                 █║     ██╔════╝████╗  ██║█");
            Console.WriteLine("\t\t\t                 █║     █████╗  ██╔██╗ ██║█");
            Console.WriteLine("\t\t\t                 █║     ██╔══╝  ██║╚██╗██║█");
            Console.WriteLine("\t\t\t                 ██████╗███████╗██║ ╚████║█");
            Console.WriteLine("\t\t\t                 ══════╝╚══════╝╚═╝  ╚═══╝╚");
            System.Threading.Thread.Sleep(150);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("\t\t\t               ╗██╗     ███████╗███╗   ██╗ ██");
            Console.WriteLine("\t\t\t               ╝██║     ██╔════╝████╗  ██║██╔");
            Console.WriteLine("\t\t\t                ██║     █████╗  ██╔██╗ ██║███");
            Console.WriteLine("\t\t\t                ██║     ██╔══╝  ██║╚██╗██║██╔");
            Console.WriteLine("\t\t\t               ╗███████╗███████╗██║ ╚████║██║");
            Console.WriteLine("\t\t\t               ╝╚══════╝╚══════╝╚═╝  ╚═══╝╚═╝");
            System.Threading.Thread.Sleep(150);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("\t\t\t            ███╗██╗     ███████╗███╗   ██╗ █████");
            Console.WriteLine("\t\t\t            ═══╝██║     ██╔════╝████╗  ██║██╔══█");
            Console.WriteLine("\t\t\t            █╗  ██║     █████╗  ██╔██╗ ██║██████");
            Console.WriteLine("\t\t\t            ═╝  ██║     ██╔══╝  ██║╚██╗██║██╔══█");
            Console.WriteLine("\t\t\t            ███╗███████╗███████╗██║ ╚████║██║  █");
            Console.WriteLine("\t\t\t            ═══╝╚══════╝╚══════╝╚═╝  ╚═══╝╚═╝  ╚");
            System.Threading.Thread.Sleep(150);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("\t\t\t        ███████╗██╗     ███████╗███╗   ██╗ █████╗ ██");
            Console.WriteLine("\t\t\t        ██╔════╝██║     ██╔════╝████╗  ██║██╔══██╗██");
            Console.WriteLine("\t\t\t        █████╗  ██║     █████╗  ██╔██╗ ██║███████║██");
            Console.WriteLine("\t\t\t        ██╔══╝  ██║     ██╔══╝  ██║╚██╗██║██╔══██║╚═");
            Console.WriteLine("\t\t\t        ███████╗███████╗███████╗██║ ╚████║██║  ██║██");
            Console.WriteLine("\t\t\t        ╚══════╝╚══════╝╚══════╝╚═╝  ╚═══╝╚═╝  ╚═╝╚═");
            System.Threading.Thread.Sleep(150);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("\t\t\t     ██╗███████╗██╗     ███████╗███╗   ██╗ █████╗ █████");
            Console.WriteLine("\t\t\t     ██║██╔════╝██║     ██╔════╝████╗  ██║██╔══██╗██╔══");
            Console.WriteLine("\t\t\t    ███║█████╗  ██║     █████╗  ██╔██╗ ██║███████║█████");
            Console.WriteLine("\t\t\t    ═██║██╔══╝  ██║     ██╔══╝  ██║╚██╗██║██╔══██║╚════");
            Console.WriteLine("\t\t\t     ██║███████╗███████╗███████╗██║ ╚████║██║  ██║█████");
            Console.WriteLine("\t\t\t     ╚═╝╚══════╝╚══════╝╚══════╝╚═╝  ╚═══╝╚═╝  ╚═╝╚════");
            System.Threading.Thread.Sleep(150);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Clear();
            Console.WriteLine("");

            Console.WriteLine("\t\t\t██╗  ██╗███████╗██╗     ███████╗███╗   ██╗ █████╗ ███████╗");
            Console.WriteLine("\t\t\t██║  ██║██╔════╝██║     ██╔════╝████╗  ██║██╔══██╗██╔════╝");
            Console.WriteLine("\t\t\t███████║█████╗  ██║     █████╗  ██╔██╗ ██║███████║███████╗");
            Console.WriteLine("\t\t\t██╔══██║██╔══╝  ██║     ██╔══╝  ██║╚██╗██║██╔══██║╚════██║");
            Console.WriteLine("\t\t\t██║  ██║███████╗███████╗███████╗██║ ╚████║██║  ██║███████║");
            Console.WriteLine("\t\t\t╚═╝  ╚═╝╚══════╝╚══════╝╚══════╝╚═╝  ╚═══╝╚═╝  ╚═╝╚══════╝");
            Console.WriteLine();
            System.Threading.Thread.Sleep(150);
            Console.WriteLine();
            Console.WriteLine("\t   ███████╗██████╗ ███████╗██╗      ██████╗███████╗███╗   ██╗████████╗███████╗██████╗");
            Console.WriteLine("\t   ██╔════╝██╔══██╗██╔════╝██║     ██╔════╝██╔════╝████╗  ██║╚══██╔══╝██╔════╝██╔══██╗");
            Console.WriteLine("\t   ███████╗██████╔╝█████╗  ██║     ██║     █████╗  ██╔██╗ ██║   ██║   █████╗  ██████╔╝");
            Console.WriteLine("\t   ╚════██║██╔═══╝ ██╔══╝  ██║     ██║     ██╔══╝  ██║╚██╗██║   ██║   ██╔══╝  ██╔══██╗");
            Console.WriteLine("\t   ███████║██║     ███████╗███████╗╚██████╗███████╗██║ ╚████║   ██║   ███████╗██║  ██║");
            Console.WriteLine("\t   ╚══════╝╚═╝     ╚══════╝╚══════╝ ╚═════╝╚══════╝╚═╝  ╚═══╝   ╚═╝   ╚══════╝╚═╝  ╚═╝");
            
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
