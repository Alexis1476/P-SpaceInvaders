using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P_SpaceInvaders
{
    class Ship
    {
        private int _x;
        private int _y;
        private int _lifes;
        private string _shipDesign;
        private bool _alive;

        public Ship()
        {

        }
        public Ship(int x, int y, int lifes, string shipDesign)
        {
            _lifes = lifes;
            _shipDesign = shipDesign;
            _x = x;
            _y = y;
        }
        
        public void DrawShip()
        {
            Console.SetCursorPosition(_x, _y);
            Console.Write(_shipDesign);
        }
        public void ShowShip()
        {
            Console.SetCursorPosition(_x, _y);
            Console.CursorVisible = false;
            DrawShip();
            _alive = false;
            //Si le vaisseau est vivant
            while (!_alive)
            {
                MoveShip();
            }
        }
        public void MoveShip()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.LeftArrow:
                    {
                        Console.SetCursorPosition(_x+1, _y);
                        DeleteShip();  
                        _x --;
                        DrawShip();
                    }
                    break;
                case ConsoleKey.RightArrow:
                    {
                        Console.SetCursorPosition(_x - 1, _y);
                        DeleteShip();
                        _x ++;
                        DrawShip();
                    }
                    break;
                case ConsoleKey.Spacebar:
                    {
                        Shoot newShoot = new Shoot(_x, _y, '^');
                        Thread tir= new Thread(new ThreadStart(newShoot.ShowShoot));
                        tir.Start();
                    }
                    break;
                default:
                    break;
            }
        }
        public void DeleteShip()
        {
            Console.Write("  ");
        }
    }
}
