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
        public const string CharInvader = "          \n" +
                                          "  ▀▄ ▄▀  \n" +
                                          " ▄█▀█▀█▄ \n" +
                                          "█▀█████▀█\n" +
                                          "█ █▀▀▀█ █\n" +
                                          "  ▀▀ ▀▀  ";
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
            Game.Bullets.Add(new Bullet(Game, "§", PosX + WidthChars / 2, PosY + 1, Direction.Down));
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

        //#region Attributs
        //private bool _alive;
        //private string[] _invaderFrames;
        //private int _invaderWidth;
        //#endregion

        //#region Constructors
        //public Invader(string[] invaderFrames, int posX, int posY) : base(posX, posY)
        //{
        //    _invaderFrames = invaderFrames;
        //}
        //#endregion

        //#region Methodes
        ////TESTS
        //public void UpdateInvader()
        //{
        //    int y = 0, x = 0; //pos X et Y des invaders
        //    int dir = 1; //Direction des invaders
        //    for (int i = 0; ; i++)
        //    {
        //        Thread.Sleep(100);
        //        x += dir;
        //        //Si x = windowWidth - lineAlien.lenght
        //        //Console.MoveBufferArea
        //        if (x == Console.WindowWidth - 18)
        //        {
        //            dir = -1; //Inversion de la direcion
        //            y++; //Descend un pas en Y
        //        }
        //        //Si x=0 Direction positive
        //        else if (x == 0) { y++; dir = 1; }
        //        //Affichage invader
        //        if (i % 6 == 0)
        //        {
        //            DrawInvader(InvaderFrames[0], x, y); //Dessiner invader
        //        }
        //        else
        //        {
        //            DrawInvader(InvaderFrames[1], x, y); //Dessiner invader
        //        }

        //    }
        //}
        //public void DrawInvader(string invader, int x, int y)
        //{
        //    using (StringReader reader = new StringReader(invader))
        //    {
        //        string line = "";
        //        do
        //        {
        //            line = reader.ReadLine();
        //            if (line != null)
        //            {
        //                Console.SetCursorPosition(x, y);
        //                Console.WriteLine(line);
        //            }
        //            y++;
        //        }
        //        while (line != null);
        //    }
        //}
        //#endregion

        //#region Getteurs et setteurs
        //public string [] InvaderFrames
        //{
        //    get { return _invaderFrames; }
        //}
        //public int InvaderWidth
        //{
        //    get { return _invaderWidth; }
        //}
        //#endregion
    }
}
