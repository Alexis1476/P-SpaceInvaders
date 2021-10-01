using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_SpaceInvaders
{
    class Game
    {
        Ship ship = new Ship(50, 50, 3, "-^-");

        public Game()
        {

        }
        public void InitializeGame()
        {
            Console.Clear();
            ResizeWindows();
            DrawGameInfo();
            ship.ShowShip();
        }
        public void DrawGameInfo()
        {
            Console.SetCursorPosition(1, Console.WindowHeight - 3);

        }
        public void ResizeWindows()
        {
            Console.SetWindowSize(100,50);
        }
    }
}
