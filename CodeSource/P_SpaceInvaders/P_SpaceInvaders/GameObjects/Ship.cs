///ETML
///Auteur : Alexis Rojas
///Date : 26.11.2021
///Description: Class qui permet de créer le vaisseau du joueur
using System;

namespace P_SpaceInvaders.GameObjects
{
    /// <summary>
    /// Permet de créer le vaisseau du joueur
    /// </summary>
    class Ship : MovingObject
    {
        #region [Attributs]
        /// <summary>
        /// Nombre de vies du vaisseau
        /// </summary>
        int _lives;
        #endregion

        #region [Constructeurs]
        /// <summary>
        /// Constructeur par game, dessin du vaisseau en string et vies
        /// </summary>
        /// <param name="game">Game</param>
        /// <param name="chars">Dessin du vaisseau en string</param>
        /// <param name="lives">Nombre de vies</param>
        public Ship(Game game, string chars, int lives) : base(game, chars)
        {
            _lives = lives;
        }
        #endregion

        #region [Propriétés des attributs]
        /// <summary>
        /// Propriétés membre _lives
        /// </summary>
        public int Lives
        {
            get { return _lives; }
            set { _lives = value; }
        }
        #endregion

        #region [Methodes]
        /// <summary>
        /// Permet que le vaisseau tire
        /// </summary>
        public void Fire()
        {
            //Ajout d'une balle qui se génère à partir du centre de l'objet et qui va vers le haut
            Game.Bullets.Add(new Bullet(Game, CharsASCII.BULLETSHIP, PosX + WidthChars / 2, PosY - 1, Direction.Up));
        }
        /// <summary>
        /// Mouvement du vaisseau en fonction de la direction
        /// </summary>
        /// <param name="direction">Left ou Rigth</param>
        public new void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    //PosX -1 vers la gauche, Math.Max pour ne pas laisser sortir le vaisseau de la map
                    PosX = Math.Max(PosX - 1, Game.Map.Offset * 2);
                    break;
                case Direction.Right:
                    //PosX + 1 vers la droite, Math.Min pour ne pas laisser sortir le vaisseau de la map
                    PosX = Math.Min(PosX + 1, Game.Map.Width - WidthChars);
                    break;
            }
        }
        #endregion
    }
}