using System;
using System.Collections.Generic;
using System.Text;

namespace HelenasSpelcenter
{
    public class SnakeFragment
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }

        public SnakeFragment(int x, int y)
        {
            XPosition = x;
            YPosition = y;
        }


    }
}
