using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace SnakeProject
{
    class Body : Tile
    {
        public Body(int x, int y) : base(x, y, Color.GREEN) 
        {
        }
    }
}
