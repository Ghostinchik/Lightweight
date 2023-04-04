using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Легковаговик.Class1;

namespace Легковаговик
{
    public partial class Form1 : Form
    {

        private const int GameBoardSize = 8;
        private const float BallSize = 50;

        private GameBoardGenerator gameBoardGenerator = new GameBoardGenerator();
        private GameBoard gameBoard;

        public Form1()
        {
            InitializeComponent();

            gameBoard = gameBoardGenerator.Generate(GameBoardSize, BallSize);
            Invalidate();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            for (int x = 0; x < GameBoardSize; x++)
            {
                for (int y = 0; y < GameBoardSize; y++)
                {
                    var ball = gameBoard.GetBall(x, y);
                    if (ball != null)
                    {
                        e.Graphics.FillEllipse(GetBallBrush(ball.Type), ball.Bounds);
                    }
                }
            }
        }
        
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = e.X / (int)BallSize;
                int y = e.Y / (int)BallSize;

                if (gameBoard.GetBall(x, y) == null)
                {
                    gameBoard.SetBall(x, y, 1, BallSize);
                    Invalidate();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                int x = e.X / (int)BallSize;
                int y = e.Y / (int)BallSize;

                if (gameBoard.GetBall(x, y) != null)
                {
                    gameBoard.ClearBall(x, y);
                    Invalidate();
                }
            }
        }
        private Brush GetBallBrush(int type)
        {
            switch (type)
            {
                case 1:
                    return Brushes.Red;
                case 2:
                    return Brushes.Green;
                case 3:
                    return Brushes.Blue;
                case 4:
                    return Brushes.Yellow;
                case 5:
                    return Brushes.Purple;
                default:
                    throw new ArgumentException($"Неправильний тип кульки: {type}");
            }
        }
    }
}
