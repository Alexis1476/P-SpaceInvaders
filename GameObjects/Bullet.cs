///ETML
///Auteur : Alexis Rojas
///Date : 26.11.2021
///Description: Class qui permet de créer une balle pour les ennemis et pour le joueur
using System;

namespace P_SpaceInvaders.GameObjects
{
    /// <summary>
    /// Permet de créer une balle (Pour l'ennemi ou pour le vaisseau)
    /// </summary>
    class Bullet : MovingObject
    {
        #region [Constantes]
        /// <summary>
        /// Couleur des balles du joueur
        /// </summary>
        private const ConsoleColor _BULLETSHIPCOLOR = ConsoleColor.Blue;
        /// <summary>
        /// Couleur des balles des invaders
        /// </summary>
        private const ConsoleColor _BULLETINVADERCOLOR = ConsoleColor.Red;
        #endregion

        #region [Attributs]
        /// <summary>
        /// Direction de la balle
        /// </summary>
        Direction _direction;
        #endregion

        #region [Constructeurs]
        /// <summary>
        /// Constructeur par game, caractères, posX, posY et direction
        /// </summary>
        /// <param name="game">Game</param>
        /// <param name="chars">String réprésenant l'objet</param>
        /// <param name="posX">Position en x</param>
        /// <param name="posY">Position en Y</param>
        /// <param name="direction">Direction de la balle</param>
        public Bullet(Game game, string chars, int posX, int posY, Direction direction) : base(game, chars, posX, posY)
        {
            _direction = direction;
            //Draw();
        }
        #endregion

        #region [Methodes]
        /// <summary>
        /// Dessine la balle
        /// </summary>
        public new void Draw()
        {
            //Si les tirs sont faits par le joueur
            if (_direction == Direction.Up)
            {
                Console.ForegroundColor = _BULLETSHIPCOLOR;
                base.Draw();
                Console.ResetColor();
            }

            //Si les tirs sont faits par les invaders
            else
            {
                Console.ForegroundColor = _BULLETINVADERCOLOR;
                base.Draw();
                Console.ResetColor();
            }          
        }
        /// <summary>
        /// Redesinne la balle si elle change de position
        /// </summary>
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

        #region [Propriétés des attributs]
        /// <summary>
        /// Propriétés du membre _direction
        /// </summary>
        public Direction Direction
        {
            get { return _direction; }
        }
        #endregion
    }
}