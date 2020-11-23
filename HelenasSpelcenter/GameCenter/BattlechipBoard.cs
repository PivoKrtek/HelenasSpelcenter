using System;
using System.Collections.Generic;
using System.Text;

namespace HelenasSpelcenter
{
    class BattlechipBoard
    {
        public static int SizeOfBoardX { get; set; }
        public static int SizeOfBoardY { get; set; }




        public static int DecideXSizeOnBoard()
        {
            bool ok;
            int xSize = 0;
            Console.WriteLine("\n\t\t\tVilken storlek på brädet vill Ni ha?");
            Console.WriteLine("\t\t\tMata in X (ett nummer mellan 5 och 20): ");
            while (true)
            {
                Console.Write("\t\t\t");
                ok = int.TryParse(Console.ReadLine(), out xSize);
                if (!ok || xSize < 5 || xSize > 20)
                {
                    Console.WriteLine("\t\t\tFörsök igen.");
                }
                else { break; }
            }
            return xSize;
        }
        public static int DecideYSizeOnBoard()
        {
            bool ok;
            int ySize = 0;
            Console.WriteLine("\n\t\t\tMata in Y (ett nummer mellan 5 och 20): ");
            while (true)
            {
                Console.Write("\t\t\t");
                ok = int.TryParse(Console.ReadLine(), out ySize);
                if (!ok || ySize < 5 || ySize > 20)
                {
                    Console.WriteLine("\t\t\tFörsök igen.");
                }
                else { break; }
            }
            return ySize;
        }
    }
}
