using System;
using System.Collections.Generic;
using System.Text;

namespace HelenasSpelcenter
{
    public class BattleshipBoat
    {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public int X3 { get; set; }
        public int Y3 { get; set; }


    }

    public class Submarine : BattleshipBoat

    {
        Random random = new Random();
        public Submarine(int sizeOfBoardX, int sizeOfBoardY)
        {
            X1 = random.Next(0, sizeOfBoardX);
            Y1 = random.Next(0, sizeOfBoardY);
        }
    }
    public class Ship : BattleshipBoat
    {
        Random random = new Random();
        public Ship(int sizeOfBoardX, int sizeOfBoardY, Submarine submarine)
        {

            bool tryAgain = true;
            bool oneMoreTime = false;

            while (!oneMoreTime)
            {
                X1 = random.Next(0, sizeOfBoardX);
                Y1 = random.Next(0, sizeOfBoardY);
                oneMoreTime = true;
                tryAgain = true;
                while (tryAgain)
                {

                    tryAgain = false;
                    int secondPosition = random.Next(1, 5);
                    if (secondPosition == 1 || secondPosition == 2)
                    { X2 = X1; }
                    else if (secondPosition == 3)
                    { X2 = X1 - 1; }
                    else if (secondPosition == 4)
                    { X2 = X1 + 1; }
                    if (X2 >= sizeOfBoardX || X2 < 0)
                    { tryAgain = true; }
                }
                tryAgain = true;
                while (tryAgain)
                {

                    tryAgain = false;
                    if (X2 == X1)
                    {
                        int randomYPosition = random.Next(1, 3);
                        if (randomYPosition == 1)
                        { Y2 = Y1 - 1; }
                        else if (randomYPosition == 2)
                        { Y2 = Y1 + 1; }
                        if (Y2 >= sizeOfBoardY || Y2 < 0)
                        { tryAgain = true; }

                    }
                    else
                    {
                        Y2 = Y1;

                    }
                }

                oneMoreTime = IsThisPositionFreeFromOtherBoats(submarine, X1, Y1, X2, Y2);
            }

        }
        public static bool IsThisPositionFreeFromOtherBoats(BattleshipBoat boat, int x1, int y1, int x2, int y2)
        {
            if (boat.X1 == x1 && boat.Y1 == y1 || boat.X1 == x2 && boat.Y1 == y2)
            { return false; }
            return true;
        }
    }

    public class Destroyer : BattleshipBoat
    {

        public Destroyer(int sizeOfBoardX, int sizeOfBoardY, Submarine submarine, Ship ship)

        {
            Random random = new Random();

            bool tryAgain = true;
            bool oneMoreTime = false;

            while (!oneMoreTime)

            {
                X1 = random.Next(0, sizeOfBoardX);
                Y1 = random.Next(0, sizeOfBoardY);

                oneMoreTime = true;
                tryAgain = true;
                while (tryAgain)
                {

                    tryAgain = false;
                    int secondPosition = random.Next(1, 5);
                    if (secondPosition == 1 || secondPosition == 2)
                    { X2 = X1; }
                    else if (secondPosition == 3)
                    { X2 = X1 - 1; }
                    else if (secondPosition == 4)
                    { X2 = X1 + 1; }
                    if (X2 >= sizeOfBoardX || X2 < 0)
                    { tryAgain = true; }
                }
                tryAgain = true;
                while (tryAgain)
                {

                    tryAgain = false;
                    if (X2 == X1)
                    {
                        int randomYPosition = random.Next(1, 3);
                        if (randomYPosition == 1)
                        { Y2 = Y1 - 1; }
                        else if (randomYPosition == 2)
                        { Y2 = Y1 + 1; }
                        if (Y2 >= sizeOfBoardY || Y2 < 0)
                        { tryAgain = true; }

                    }
                    else
                    {
                        Y2 = Y1;

                    }
                }
                tryAgain = true;
                while (tryAgain)
                {

                    tryAgain = false;
                    if (Y1 == Y2)
                    {
                        Y3 = Y2;
                        int thirdXPosition = random.Next(1, 3);
                        if (thirdXPosition == 1)
                        {
                            if (X2 < X1)
                            {
                                X3 = X2 - 1;
                            }
                            else
                            { X3 = X1 - 1; }
                        }
                        else if (thirdXPosition == 2)
                        {
                            if (X2 < X1)
                            {
                                X3 = X1 + 1;
                            }
                            else
                            { X3 = X2 + 1; }
                        }
                        if (X3 >= sizeOfBoardX || X3 < 0)
                        { tryAgain = true; }
                    }
                    else if (X1 == X2)
                    {
                        X3 = X2;
                        int thirdXPosition = random.Next(1, 3);
                        if (thirdXPosition == 1)
                        {
                            if (Y2 < Y1)
                            {
                                Y3 = Y2 - 1;
                            }
                            else
                            { Y3 = Y1 - 1; }
                        }
                        else if (thirdXPosition == 2)
                        {
                            if (Y2 < Y1)
                            {
                                Y3 = Y1 + 1;
                            }
                            else
                            { Y3 = Y2 + 1; }
                        }
                        if (Y3 >= sizeOfBoardY || Y3 < 0)
                        { tryAgain = true; }

                    }




                }


                oneMoreTime = IsThisPositionFreeFromOtherBoats(submarine, ship, X1, Y1, X2, Y2, X3, Y3);

            }
        }
        public static bool IsThisPositionFreeFromOtherBoats(BattleshipBoat boat, BattleshipBoat boat2, int x1, int y1, int x2, int y2, int x3, int y3)
        {
            List<BattleshipBoat> listBoats = new List<BattleshipBoat>();
            listBoats.Add(boat);
            listBoats.Add(boat2);
            foreach (BattleshipBoat boats in listBoats)
            {
                if (boat.X1 == x1 && boat.Y1 == y1 || boat.X1 == x2 && boat.Y1 == y2 || boat.X1 == x3 && boat.Y1 == y3)
                { return false; }
                if (boat is Ship)
                {
                    if (boat.X2 == x1 && boat.Y2 == y1 || boat.X2 == x2 && boat.Y2 == y2 || boat.X2 == x3 && boat.Y2 == y3)
                    { return false; }
                }
            }
            return true;

        }
    }
}
