using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P_SpaceInvaders.GameObjects
{
    class Ship : GameObject
    {
        public Ship(int posY, int posX) : base(posX, posY)
        {

        }
        //private int _x;
        //private int _y;
        //private int _lifes;
        //private string _shipDesign;
        //private bool _alive;
        //Bullet _bullet;

        //public Ship()
        //{

        //}
        //public Ship(int x, int y, int lifes, string shipDesign)
        //{
        //    _lifes = lifes;
        //    _shipDesign = shipDesign;
        //    _x = x;
        //    _y = y;
        //    _bullet = new Bullet(_x, _y, '^');
        //}

        //public void DrawShip()
        //{
        //    Console.SetCursorPosition(_x, _y);
        //    Console.Write(_shipDesign);
        //}
        //public void ShowShip()
        //{
        //    Console.SetCursorPosition(_x, _y);
        //    Console.CursorVisible = false;
        //    DrawShip();
        //    _alive = false;
        //    //Si le vaisseau est vivant
        //    while (!_alive)
        //    {
        //        MoveShip();
        //    }
        //}
        //public void MoveShip()
        //{
        //    switch (Console.ReadKey(true).Key)
        //    {
        //        case ConsoleKey.LeftArrow:
        //            {
        //                Console.SetCursorPosition(_x+1, _y);
        //                DeleteShip();  
        //                _x --;
        //                DrawShip();
        //            }
        //            break;
        //        case ConsoleKey.RightArrow:
        //            {
        //                Console.SetCursorPosition(_x - 1, _y);
        //                DeleteShip();
        //                _x ++;
        //                DrawShip();
        //            }
        //            break;
        //        case ConsoleKey.Spacebar:
        //            {
        //                //Shoot newShoot = new Shoot(_x, _y, '^'); //Attention création Shoot ici!!
        //                _bullet.Y = _y;
        //                _bullet.X = _x;
        //                Thread tir= new Thread(new ThreadStart(_bullet.ShowShoot));
        //                tir.Start();
        //            }
        //            break;
        //        default:
        //            break;
        //    }
        //}
        //public void DeleteShip()
        //{
        //    Console.Write("  ");
        //}
    }
}
