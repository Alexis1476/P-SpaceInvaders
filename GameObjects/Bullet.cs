///ETML
///Auteur : Alexis Rojas
///Date : 26.11.2021
///Description: Class qui permet de créer une balle pour les ennemis et pour le joueur
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P_SpaceInvaders.GameObjects
{
    class Bullet : MovingObject
    {
        #region Attributs
        Direction _direction;
        #endregion

        #region Constructeurs
        public Bullet(Game game, string chars, int posX, int posY, Direction direction) : base(game, chars, posX, posY)
        {
            _direction = direction;
            Draw();
        }
        #endregion

        #region Methodes
        public new void Draw()
        {
            //Si les tirs sont fait par le joueur
            if (_direction == Direction.Up)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                base.Draw();
                Console.ResetColor();
            }

            //Si les tirs sont fait par les invaders
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                base.Draw();
                Console.ResetColor();
            }          
        }
        public new void ReDraw()
        {
            //Si la position a changé
            if (PosX != LastPosX || PosY != LastPosY)
            {
                //Dessine la balle
                Draw();

                //Met à jour la position actuel
                LastPosX = PosX;
                LastPosY = PosY;
            }
        }
        #endregion

        #region Getteurs et setteurs
        public Direction Direction
        {
            get { return _direction; }
        }
        #endregion

        //private int _y;
        //private int _x;
        //private char _bulletDesign;

        //public Bullet(int x, int y, char bulletDesign)
        //{
        //    _x = x + 1; //+1 pour centrer le tir
        //    _y = y - 1; //-1
        //    _bulletDesign = bulletDesign;       
        //}
        //public void ShowShoot()
        //{
        //    for (int i = 0; i < 20; i++)
        //    {
        //        Thread.Sleep(50);
        //        //Effacement du tir dans la console
        //        Console.MoveBufferArea(_x, _y, 1, 1, _x, _y - 1);
        //        Console.Write(" ");
        //        //Deplacement du tir
        //        _y--;
        //        Console.MoveBufferArea(_x, _y, 1, 1, _x, _y);
        //        Console.SetCursorPosition(_x, _y);
        //        DrawShoot();
        //        //Effacement du tir lors de sa dernière position
        //        if (i == 19) //A modifier 19
        //        {
        //            Thread.Sleep(50);
        //            Console.SetCursorPosition(_x, _y);
        //            Console.Write(" ");
        //        }
        //    }
        //}
        //public void DrawShoot()
        //{
        //    Console.Write(_bulletDesign);
        //}
        //public int Y
        //{
        //    get { return _y; }
        //    set { _y = value; }
        //}
        //public int X
        //{
        //    get { return _x; }
        //    set { _x = value; }
        //}
    }
}
