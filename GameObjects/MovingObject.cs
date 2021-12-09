///ETML
///Auteur : Alexis Rojas
///Date : 26.11.2021
///Description: Class parent de tous les objets du jeu qui peuvent bouger
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_SpaceInvaders.GameObjects
{
    class MovingObject : GameObject
    {
        #region Attributs
        private int _lastPosX;
        private int _lastPosY;
        #endregion

        #region Constructors
        public MovingObject(Game game, string chars, int x, int y) : base(game, chars, x, y)
        {
            _lastPosX = x;
            _lastPosY = y;
        }
        public MovingObject(Game game, string chars) : base(game, chars)
        {

        }
        public MovingObject(Game game, string[] frames) : base(game, frames)
        {

        }
        #endregion

        #region Getteurs et setteurs
        public int LastPosX
        {
            get { return _lastPosX; }
            set { _lastPosX = value; }
        }
        public int LastPosY
        {
            get { return _lastPosY; }
            set { _lastPosY = value; }
        }
        #endregion

        #region Methodes
        public void ReDraw()
        {
            //Si la position a changé
            if (PosX != LastPosX || PosY != LastPosY)
            {
                //Dessine l'objet
                Draw();

                //Met à jour la position actuel
                LastPosX = PosX;
                LastPosY = PosY;
            }
        }
        public void Delete()
        {
            //Efface l'objet de sa position précédente
            Console.SetCursorPosition(LastPosX, LastPosY);

            for (int i = 0; i < HeightChars - 1; i++)
            {
                Console.SetCursorPosition(LastPosX, LastPosY + i);
                Console.Write(new string(' ', WidthChars));
            }
        }
        public void Clear()
        {
            //Si la position a changé
            if (PosX != LastPosX || PosY != LastPosY)
            {
                //Efface l'objet de sa position précédente
                Console.SetCursorPosition(LastPosX, LastPosY);

                for (int i = 0; i < HeightChars-1 ; i++)
                {
                    Console.SetCursorPosition(LastPosX, LastPosY + i);
                    Console.Write(new string(' ', WidthChars));
                }           
            }
        }
        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    PosX--;
                    break;
                case Direction.Right:
                    PosX++;
                    break;
                case Direction.Up:
                    PosY--;
                    break;
                case Direction.Down:
                    PosY++;
                    break;
            }
        }
        #endregion

    }
}
