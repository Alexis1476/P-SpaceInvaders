using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P_SpaceInvaders
{
    class Shoot
    {
        private int _y;
        private int _x;
        private char _bulletDesign;

        public Shoot(int x, int y, char bulletDesign)
        {
            _x = x + 1; //+2 pour centrer le tir
            _y = y - 1; //+1
            _bulletDesign = bulletDesign;       
        }
        public void ShowShoot()
        {
            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(50);
                //Effacement du tir dans la console
                Console.MoveBufferArea(_x, _y, 1, 1, _x, _y - 1);
                Console.Write(" ");
                //Deplacement du tir
                _y--;
                Console.MoveBufferArea(_x, _y, 1, 1, _x, _y);
                Console.SetCursorPosition(_x, _y);
                DrawShoot();
                //Effacement du tir lors de sa dernière position
                if (i == 19) 
                {
                    Thread.Sleep(50);
                    Console.SetCursorPosition(_x, _y);
                    Console.Write(" ");
                }
            }
        }
        public void DrawShoot()
        {
            Console.Write(_bulletDesign);
        }
    }
}
