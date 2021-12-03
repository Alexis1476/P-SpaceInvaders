///ETML
///Auteur : Alexis Rojas
///Date : 26.11.2021
///Description: Class qui permet de créer le vaisseau du joueur
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P_SpaceInvaders.GameObjects
{
    class Ship : MovingObject
    {
        public const string CharShip = "<-^->";
        #region Attributs
        int _lives;
        #endregion

        #region Constructeurs
        public Ship(Game game, string chars, int posX, int posY, int lives) : base(game, chars, posX, posY)
        {
            _lives = lives;
        }
        #endregion

        #region Getteurs et setteurs
        public int Lives
        {
            get { return _lives; }
            set { _lives = value; }
        }
        #endregion

        #region Methodes
        public void Fire()
        {
            //Ajout d'une balle qui se génère à partir du centre de l'objet et qui va vers le haut
            Game.Bullets.Add(new Bullet(Game, "|", PosX + WidthChars / 2, PosY - 1, Direction.Up));
        }
        public new void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    //PosX -1 vers la gauche, Math.Max pour ne pas laisser sortir le vaisseau de la map
                    PosX = Math.Max(PosX - 1, Game.Map.Offset + 1);
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
