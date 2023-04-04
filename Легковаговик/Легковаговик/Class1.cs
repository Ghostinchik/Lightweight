using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Легковаговик
{
    internal class Class1
    {
        public class Ball
        {
            public int Type { get; set; }
            public RectangleF Bounds { get; set; }

            public Ball(int type, RectangleF bounds)
            {
                Type = type;
                Bounds = bounds;
            }
        }

        public class GameBoard
        {
            private Ball[,] balls;

            public GameBoard(int size)
            {
                balls = new Ball[size, size];
            }

            public void SetBall(int x, int y, int type, float ballSize)
            {
                var ballBounds = new RectangleF(x * ballSize, y * ballSize, ballSize, ballSize);
                balls[x, y] = new Ball(type, ballBounds);
            }

            public Ball GetBall(int x, int y)
            {
                return balls[x, y];
            }

            public void ClearBall(int x, int y)
            {
                balls[x, y] = null;
            }

            public void ClearAllBalls()
            {
                balls = new Ball[balls.GetLength(0), balls.GetLength(1)];
            }
        }

        public class GameBoardGenerator
        {
            private Random random = new Random();

            public GameBoard Generate(int size, float ballSize)
            {
                var gameBoard = new GameBoard(size);

                for (int x = 0; x < size; x++)
                {
                    for (int y = 0; y < size; y++)
                    {
                        int type = random.Next(1, 6);
                        gameBoard.SetBall(x, y, type, ballSize);
                    }
                }

                return gameBoard;
            }
        }


    }
}
