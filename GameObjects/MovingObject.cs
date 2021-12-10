///ETML
///Auteur : Alexis Rojas
///Date : 26.11.2021
///Description: Class parent de tous les objets du jeu qui peuvent bouger
using System;

namespace P_SpaceInvaders.GameObjects
{
    /// <summary>
    /// Gère les objets qui peuvent se déplacer
    /// </summary>
    class MovingObject : GameObject
    {
        #region [Attributs]
        /// <summary>
        /// Dernière position en X
        /// </summary>
        private int _lastPosX;
        /// <summary>
        /// Dernière position en Y
        /// </summary>
        private int _lastPosY;
        #endregion

        #region [Constructors]
        /// <summary>
        /// Constructeur par game, caractères, posX, posY
        /// </summary>
        /// <param name="game">Game</param>
        /// <param name="chars">String représenant l'objet</param>
        /// <param name="x">Position en X</param>
        /// <param name="y">Position en Y</param>
        public MovingObject(Game game, string chars, int x, int y) : base(game, chars, x, y)
        {
            _lastPosX = x;
            _lastPosY = y;
        }
        /// <summary>
        /// Constructeur par game et caractères
        /// </summary>
        /// <param name="game">Game</param>
        /// <param name="chars">String réprésenant l'objet</param>
        public MovingObject(Game game, string chars) : base(game, chars)
        {

        }
        /// <summary>
        /// Constructeur par game, et tableau de frames (String)
        /// </summary>
        /// <param name="game">Game</param>
        /// <param name="frames">Tableau de string représentant les frames</param>
        public MovingObject(Game game, string[] frames) : base(game, frames)
        {

        }
        #endregion

        #region [Propriétés des attributs]
        /// <summary>
        /// Propriété membre _lastPosX
        /// </summary>
        public int LastPosX
        {
            get { return _lastPosX; }
            set { _lastPosX = value; }
        }
        /// <summary>
        /// Propriété membre _lastPosY
        /// </summary>
        public int LastPosY
        {
            get { return _lastPosY; }
            set { _lastPosY = value; }
        }
        #endregion

        #region [Methodes]
        /// <summary>
        /// Redessine l'objet s'il change de position
        /// </summary>
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
        /// <summary>
        /// Efface l'objet de la console
        /// </summary>
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
        /// <summary>
        /// Efface l'objet de sa position précedente
        /// </summary>
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
        /// <summary>
        /// Deplace l'objet vers une direction donnée
        /// </summary>
        /// <param name="direction">Direction du mouvement</param>
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