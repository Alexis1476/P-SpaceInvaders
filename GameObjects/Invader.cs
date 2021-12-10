///ETML
///Auteur : Alexis Rojas
///Date : 26.11.2021
///Description: Class qui permet de créer un ennemi (Invader)

namespace P_SpaceInvaders.GameObjects
{
    /// <summary>
    /// Permet de créer des ennemis (Invader) avec un tableau de frames
    /// </summary>
    class Invader : MovingObject
    {
        #region [Attributs]
        /// <summary>
        /// Id de l'invader
        /// </summary>
        int _id;
        #endregion

        #region [Constructeurs]
        public Invader(int id, Game game, string chars) : base(game, chars)
        {
            _id = id;
        }
        public Invader(int id, Game game, string[] frames) : base(game, frames)
        {
            _id = id;
        }
        #endregion

        #region [Propriétés des attributs]
        /// <summary>
        /// Propriétés du membre _id
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        #endregion

        #region [Methodes]
        /// <summary>
        /// Permet à l'invader de tirer
        /// </summary>
        public void Fire()
        {
            //Ajout d'une balle qui se génère à partir du centre de l'objet et qui va vers le haut
            Game.Bullets.Add(new Bullet(Game, ObjectChars.BULLETINVADER, PosX + WidthChars / 2, PosY + HeightChars , Direction.Down));
        }
        /// <summary>
        /// Déplace l'invader dans une direction détérminée
        /// </summary>
        /// <param name="direction">Direction</param>
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