using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace SnakeProject
{
    abstract class Tile
    {
        private int x;
        private int y;
        private Color color;

        public Tile(int x, int y, Color color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }
        public int X
        {
            get { return this.x; }
            set { this.x = value; }
        }
        public int Y
        {
            get { return this.y; }
            set { this.y = value; }
        }
        public Color Color
        {
            get { return this.color; }
        }
    }
}
