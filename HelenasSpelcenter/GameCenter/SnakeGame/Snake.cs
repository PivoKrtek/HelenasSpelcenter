using System;
using System.Collections.Generic;
using System.Text;

namespace HelenasSpelcenter
{
    public class Snake
    {
        public bool Alive { get; set; }
        public List<SnakeFragment> WholeSnake { get; set; }

        public int StartPositionX { get; set; }
        public int StartPositionY { get; set; }

        public int DirectionX { get; set; }
        public int DirectionY { get; set; }

        public Snake(int x, int y)
        {
            Alive = true;
            StartPositionX = x;
            StartPositionY = y;
            DirectionX = 1;
            DirectionY = 0;
            List<SnakeFragment> listSnake = new List<SnakeFragment>();
            SnakeFragment firstFragment = new SnakeFragment(x, y);
            listSnake.Add(firstFragment);
            WholeSnake = listSnake;
        }

        public List<SnakeFragment> NewPositionsForSnakeFragments()
        {
            int numberOfFragment = WholeSnake.Count;

            List<SnakeFragment> lista = new List<SnakeFragment>();
            SnakeFragment plats0 = new SnakeFragment((WholeSnake[0].XPosition + DirectionX), (WholeSnake[0].YPosition + DirectionY));
            lista.Add(plats0);
            if (!SnakeGame.AddSnakeFragment)
            { numberOfFragment--; }

            for (int i = 0; i < numberOfFragment; i++)
            {
                lista.Add(WholeSnake[i]);
            }
            return lista;

        }

        public void CheckIfDies()
        {
            foreach (SnakeFragment fragment in WholeSnake)
            {
                if (fragment.XPosition == 0 || fragment.YPosition == 0 || fragment.XPosition == GameBoardSnake.XSize - 1 || fragment.YPosition == GameBoardSnake.YSize - 1)
                {
                    Alive = false;
                }
                else
                {
                    int counter = 0;
                    foreach (SnakeFragment fragment2 in WholeSnake)
                    {

                        if (fragment.XPosition == fragment2.XPosition && fragment.YPosition == fragment2.YPosition)
                        {
                            counter++;
                        }
                        if (counter >= 2)
                        {
                            Alive = false;
                        }
                    }
                }

            }
        }
        public void AddOneMoreSnakeFragment(SnakeFragment snakeFragment)
        {
            WholeSnake.Add(snakeFragment);
        }
        public SnakeFragment LastSnakeFragment()
        {

            int lastPlace = WholeSnake.Count - 1;
            SnakeFragment newFragment = new SnakeFragment(WholeSnake[lastPlace].XPosition, WholeSnake[lastPlace].YPosition);

            return newFragment;

        }

    }
}
