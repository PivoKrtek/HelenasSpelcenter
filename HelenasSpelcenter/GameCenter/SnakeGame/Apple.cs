using System;
using System.Collections.Generic;
using System.Text;

namespace HelenasSpelcenter
{
    public class Apple
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }

        public Apple()
        {
            Random random = new Random();
            XPosition = random.Next(1, GameBoardSnake.XSize - 2);
            YPosition = random.Next(1, GameBoardSnake.YSize - 2);
        }
        public void NewApplePosition()
        {
            Random random = new Random();
            XPosition = random.Next(1, GameBoardSnake.XSize - 2);
            YPosition = random.Next(1, GameBoardSnake.YSize - 2);
        }
    }
}
