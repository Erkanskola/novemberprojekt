using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeProject
{
    class Snake
    {
        private Head head;
        private LinkedList<Body> body;
        private int xVelocity;
        private int yVelocity;
        public Snake(int startX, int startY, int startXVelocity, int startYVelocity, int startLength)
        {
            this.xVelocity = startXVelocity;
            this.yVelocity = startYVelocity;
            this.head = new Head(startX, startY);
            this.body = new LinkedList<Body>();
            for (int i = 0; i < startLength; i++)
            {
                this.body.AddLast(new Body(startX, startY));
            }
        }
        public void MoveSnake() //Flyttar ormen med dess hastighet.
        {
            body.RemoveFirst();
            body.AddLast(new Body(this.head.X, this.head.Y));
            this.head.X += xVelocity;
            this.head.Y += yVelocity;
        }
        public void SnakeVelocity(int xVelocity, int yVelocity) //Ändrar ormens X och Y hastighet
        {
            this.xVelocity = xVelocity;
            this.yVelocity = yVelocity;
        }
        public void SnakeGrow(int growth) //Ökar ormens längd
        {
            for (int i = 0; i < growth; i++)
            {
                this.body.AddFirst(new Body(this.body.First().X, this.body.First().Y));
            }
        }
        public List<Tile> SnakeTiles()
        {
            return new List<Tile>(this.body) { this.head };
        }
        public Head Head
        {
            get { return this.head; }
        }
        public LinkedList<Body> Body
        {
            get { return this.body; }
        }
    }
}
