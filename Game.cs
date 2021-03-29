using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeProject
{
    class Game
    {
        private int rows;
        private int coloums;
        private Snake snake;
        private Food food;
        private Random random;
        private bool ongoing;
        public Game(int rows, int coloums)
        {
            this.rows = rows;
            this.coloums = coloums;
            this.snake = new Snake(rows / 2, coloums / 2, -1, 0, 3);
            this.random = new Random();
            this.food = this.SpawnFood();
            this.ongoing = true;
        }
        public void Right()
        {
            this.snake.SnakeVelocity(1, 0);
        }
        public void Left()
        {
            this.snake.SnakeVelocity(-1, 0);
        }
        public void Down()
        {
            this.snake.SnakeVelocity(0, 1);
        }
        public void Up()
        {
            this.snake.SnakeVelocity(0, -1);
        }
        public void CheckCollision()
        {
            //Loopar igenom ormens delar och kollar efter kollision med vägg, mat eller sig;
            List<Body> bodyTiles = this.snake.Body.ToList();

            foreach (Body item in bodyTiles)
                if (item.X == this.snake.Head.X && item.Y == this.snake.Head.Y)
                    this.ongoing = false;

            if (this.snake.Head.X < 0 || this.snake.Head.Y < 0 || this.snake.Head.Y > rows - 1 || this.snake.Head.X > coloums - 1)
                this.ongoing = false;

            else if (this.snake.Head.X == this.food.X && this.snake.Head.Y == this.food.Y)
            {
                this.snake.SnakeGrow(this.food.Growth);
                this.food = this.SpawnFood();
            }
            
        }
        public Food SpawnFood() //Tar fram alla lediga tiles och slumpar fram ett äpple eller en banan på någon av dom.
        {
            List<Body> occupiedTiles = this.snake.Body.ToList();
            List<KeyValuePair<int, int>> freeTiles = new List<KeyValuePair<int, int>>();

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < coloums; j++)
                    freeTiles.Add(new KeyValuePair<int, int>(i, j));

            foreach (Body item in occupiedTiles)
                freeTiles = freeTiles.Where(x => x.Key != item.X && x.Value != item.Y).ToList();

            KeyValuePair<int, int> chosenTile = freeTiles[random.Next(0, freeTiles.Count)];

            if (random.Next(0, 5) == 4)
                return new Banana(chosenTile.Key, chosenTile.Value);
            else
                return new Apple(chosenTile.Key, chosenTile.Value);
        }
        public List<Tile> GameObjects()
        {
            return new List<Tile>(this.snake.SnakeTiles()) { this.food };
        }

        public Snake Snake
        {
            get { return this.snake; }
        }
        public bool Ongoing
        {
            get { return this.ongoing; }
        }
    }
}
