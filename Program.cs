using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace SnakeProject
{
    class Program
    {
        //Spel variabler
        static int WINDOWS_HEIGHT = 800;
        static int WINDOWS_WIDTH = 800;
        static int GAME_ROWS = 40;
        static int GAME_COLUMNS = 40;
        static int TILE_HEIGHT = WINDOWS_HEIGHT / GAME_ROWS;
        static int TILE_WITDH = WINDOWS_WIDTH / GAME_COLUMNS;
        static Game SNAKE_GAME = new Game(GAME_ROWS, GAME_COLUMNS);
        static void Main(string[] args)
        {
            Raylib.SetTargetFPS(60);
            Raylib.InitWindow(WINDOWS_HEIGHT, WINDOWS_WIDTH, "Snake");
            
            Action actionBuffer = () => { };

            //För att skilja ormens hastighet från FPS används timestep.
            double timeIncrementer = 0; 
            long lastTime = (long)(Raylib.GetTime() * 1000);

            while (!Raylib.WindowShouldClose() && SNAKE_GAME.Ongoing)
            {
                //Beräknar hur mycket tid som passerat sedan senast checken och adderar den till all tidigare adderad tid.
                long time = (long)(Raylib.GetTime() * 1000);
                double timestep = 0.001 * (time - lastTime);
                timeIncrementer += timestep;

                //Buffrar nästa användar input
                if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                    actionBuffer = () => SNAKE_GAME.Up();
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
                    actionBuffer = () => SNAKE_GAME.Down();
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
                    actionBuffer = () => SNAKE_GAME.Right();
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                    actionBuffer = () => SNAKE_GAME.Left();

                //Kör nästa frame om en viss tid passerat. Detta kontrollerar hastigheten av ormen.
                if (timeIncrementer > 0.1)
                {
                    actionBuffer();

                    SNAKE_GAME.Snake.MoveSnake();
                    SNAKE_GAME.CheckCollision();
                    PrintGame(SNAKE_GAME);

                    timeIncrementer = 0;
                }

                lastTime = time;
            }
        }

        static void PrintGame(Game game) // Loopar igenom alla tiles och ritar dom.
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.GRAY);

            foreach (Tile item in SNAKE_GAME.GameObjects())
                Raylib.DrawRectangle(item.X * TILE_WITDH, item.Y * TILE_HEIGHT, TILE_WITDH, TILE_HEIGHT, item.Color);

            Raylib.EndDrawing();
        }
    }
}
