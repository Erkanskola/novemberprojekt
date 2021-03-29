using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace SnakeProject
{
    abstract class Food : Tile
    {
        private int growth;
        public Food(int x, int y, int growth, Color color) : base(x, y, color)
        {
            this.growth = growth;
        }

        public int Growth
        {
            get { return this.growth; }
        }
    }
}
