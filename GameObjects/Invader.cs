///ETML
///Auteur : Alexis Rojas
///Date : 26.11.2021
///Description: Class qui permet de créer un ennemi (Invader)
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P_SpaceInvaders.GameObjects
{
    class Invader : MovingObject
    {
        #region Constantes
        public static readonly string[] CRAB = new string[]
        {
            "  ▀▄ ▄▀  \n" +
            " ▄█▀█▀█▄ \n" +
            "█▀█████▀█\n" +
            "█ █▀▀▀█ █\n" +
            "  ▀▀ ▀▀  ",
            "▄ ▀▄ ▄▀ ▄\n" +
            "█▄█████▄█\n" +
            "███▄█▄███\n" +
            "▀███████▀\n" +
            " ▄▀   ▀▄ " };
        public static readonly string[] OCTOPUS = new string[]
        {
            " ▄▄███▄▄ \n" +
            "█████████\n" +
            "██▄▄█▄▄██\n" +
            " ▄▀ ▄ ▀▄ \n" +
            "  ▀   ▀  ",
            " ▄▄███▄▄ \n" +
            "█████████\n" +
            "██▄▄█▄▄██\n" +
            " ▄▀ ▄ ▀▄ \n" +
            "▀       ▀" };
        public static readonly string[] SQUID = new string[]
        {
            "   ▄█▄   \n" +
            " ▄█████▄ \n" +
            "███▄█▄███\n" +
            "  ▄▀▄▀▄  \n" +
            " ▀ ▀ ▀ ▀ ",
            "   ▄█▄   \n" +
            " ▄█████▄ \n" +
            "███▄█▄███\n" +
            " ▄▀   ▀▄ \n" +
            "  ▀   ▀  " };
        const string UFO = 
            "    ▄▄█▄▄    \n" +
            "  ▄███████▄  \n" +
            "▄██▄█▄█▄█▄██▄\n" +
            "  ▀█▀ ▀ ▀█▀  ";

        #endregion

        #region Attributs
        int _id;
        #endregion

        #region Constructeurs
        public Invader(int id, Game game, string chars, int posX, int posY) : base(game, chars, posX, posY)
        {
            _id = id;
        }
        public Invader(int id, Game game, string chars) : base(game, chars)
        {
            _id = id;
        }
        public Invader(int id, Game game, string[] frames) : base(game, frames)
        {
            _id = id;
        }
        #endregion

        #region Getteurs et setteurs
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        #endregion

        #region Methodes
        public void Fire()
        {
            //Ajout d'une balle qui se génère à partir du centre de l'objet et qui va vers le haut
            Game.Bullets.Add(new Bullet(Game, "█", PosX + WidthChars / 2, PosY + HeightChars , Direction.Down));
        }
        public new void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    //PosX -1 vers la gauche, Math.Max pour ne pas laisser sortir l'invader de la map
                    PosX -= 1;
                    break;
                case Direction.Right:
                    //PosX + 1 vers la droite, Math.Min pour ne pas laisser sortir l'invader de la map
                    PosX += 1;
                    break;
                case Direction.Down:
                    PosY += 5;
                    break;
            }
        }
        #endregion
    }
}