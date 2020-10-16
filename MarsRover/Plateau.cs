using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class Plateau
    {

        // 0 will mean infinite size
       public int GridMaxX { get; private set; } = 0;
       public   int GridMaxY { get; private set; } = 0;

        public void SetGridSize(int x, int y)
        {
            GridMaxX = x;
            GridMaxY = y;
        }

    }
}
