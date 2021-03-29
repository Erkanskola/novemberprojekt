using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace SnakeProject
{
    class Banana : Food
    {
        public Banana(int x, int y) : base(x, y, 5, Color.YELLOW)
        {
        }
    }
}
