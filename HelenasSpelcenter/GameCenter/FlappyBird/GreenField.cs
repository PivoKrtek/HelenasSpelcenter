using System;
using System.Collections.Generic;
using System.Text;

namespace HelenasSpelcenter
{
    class GreenField
    {
        public string[,] Field { get; set; }
        public int XStartPosition { get; set; }
        public int YStartForWhole { get; set; }

        public static int WidthSizeOfField { get; set; }
        public static int HeightOfWholeInField { get; set; }
        public static int StartYPositionForWhole { get; set; }
        public static int StartPositonFirstField { get; set; }
        public static int NumberOfPositionBetweenEachField { get; set; }

        public GreenField(int xposition)
        {
            XStartPosition = xposition;
            Field = new string[FlappyBirdGame.HeightOfGameWindow, WidthSizeOfField];
            YStartForWhole = SetStartYWholeInField();
            for (int y = 0; y < FlappyBirdGame.HeightOfGameWindow; y++)
            {
                for (int x = 0; x < WidthSizeOfField; x++)
                {
                    if (y >= YStartForWhole && y < YStartForWhole + HeightOfWholeInField)
                    {
                        Field[y, x] = " ";
                    }
                    else { Field[y, x] = "\u2736"; }
                }
            }
        }
        public static void SetStartPositionOneStepBack()
        {

            FlappyBirdGame.Field1.XStartPosition--;
            if (FlappyBirdGame.Field1.XStartPosition == 0 - WidthSizeOfField)
            { FlappyBirdGame.Field1 = new GreenField(FlappyBirdGame.Field5.XStartPosition + NumberOfPositionBetweenEachField); }
            if (FlappyBirdGame.Field1.XStartPosition == Bird.XStartPosition - WidthSizeOfField)
            { FlappyBirdGame.Points++; }

            FlappyBirdGame.Field2.XStartPosition--;
            if (FlappyBirdGame.Field2.XStartPosition == 0 - WidthSizeOfField)
            {
                FlappyBirdGame.Field2 = new GreenField(FlappyBirdGame.Field1.XStartPosition + NumberOfPositionBetweenEachField);
            }
            if (FlappyBirdGame.Field2.XStartPosition == Bird.XStartPosition - WidthSizeOfField)
            { FlappyBirdGame.Points++; }

            FlappyBirdGame.Field3.XStartPosition--;
            if (FlappyBirdGame.Field3.XStartPosition == 0 - WidthSizeOfField)
            {
                FlappyBirdGame.Field3 = new GreenField(FlappyBirdGame.Field2.XStartPosition + NumberOfPositionBetweenEachField);
            }
            if (FlappyBirdGame.Field3.XStartPosition == Bird.XStartPosition - WidthSizeOfField)
            { FlappyBirdGame.Points++; }

            FlappyBirdGame.Field4.XStartPosition--;
            if (FlappyBirdGame.Field4.XStartPosition == 0 - WidthSizeOfField)
            {
                FlappyBirdGame.Field4 = new GreenField(FlappyBirdGame.Field3.XStartPosition + NumberOfPositionBetweenEachField);
            }
            if (FlappyBirdGame.Field4.XStartPosition == Bird.XStartPosition - WidthSizeOfField)
            { FlappyBirdGame.Points++; }

            FlappyBirdGame.Field5.XStartPosition--;
            if (FlappyBirdGame.Field5.XStartPosition == 0 - WidthSizeOfField)
            {
                FlappyBirdGame.Field5 = new GreenField(FlappyBirdGame.Field4.XStartPosition + NumberOfPositionBetweenEachField);
            }
            if (FlappyBirdGame.Field5.XStartPosition == Bird.XStartPosition - WidthSizeOfField)
            { FlappyBirdGame.Points++; }
        }

        private int SetStartYWholeInField()
        {
            Random random = new Random();
            int number = random.Next(StartYPositionForWhole, FlappyBirdGame.HeightOfGameWindow - (StartYPositionForWhole + HeightOfWholeInField));
            return number;
        }
    }
}
