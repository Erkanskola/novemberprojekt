using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace SnakeProject
{
    class Apple : Food
    {
        public Apple(int x, int y) : base(x, y, 10, Color.RED)
        {
        }
    }
}
