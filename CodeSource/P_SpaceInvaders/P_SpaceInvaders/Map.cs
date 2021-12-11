///ETML
///Auteur : Alexis Rojas
///Date : 26.11.2021
///Description: Class qui permet de créer une map délimitée pour le jeu
using System;

namespace P_SpaceInvaders
{
    /// <summary>
    /// Permet de créer une map délimitée pour le jeu
    /// </summary>
    class Map
    {
        #region [Attributs]
        /// <summary>
        /// Largeur de la map
        /// </summary>
        int _width;
        /// <summary>
        /// Hauteur de la map
        /// </summary>
        int _height;
        /// <summary>
        /// Décalage entre la map et la fenêtre
        /// </summary>
        int _offset = 1;
        #endregion

        #region [Constructeurs]
        /// <summary>
        /// Constructeur par largeur et par hauteur
        /// </summary>
        /// <param name="width">Largeur</param>
        /// <param name="height">Hauteur</param>
        public Map(int width, int height)
        {
            _width = width;
            _height = height;
        }
        #endregion

        #region [Methodes]
        /// <summary>
        /// Dessine les limites de la map
        /// </summary>
        public void Draw()
        {
            //Coin supérieur gauche
            Console.SetCursorPosition(0, 0);
            Console.Write('╔');

            //Ligne horizontal supérieur
            for (int i = 0; i < Width; i++)
            {
                Console.Write('═');
            }

            //Coin supérieur droite   
            Console.Write('╗');

            //Lignes verticales
            for (int i = Offset; i < Offset + Height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write('║');
                Console.SetCursorPosition(Offset + Width, i);
                Console.Write('║');
            }

            //Coin inférieur gauche
            Console.SetCursorPosition(0, Offset + Height);
            Console.Write('╚');

            //Ligne horizontal inférieur
            for (int i = 0; i < Width; i++)
            {
                Console.Write('═');
            }

            //Coin inférieur droite
            Console.Write('╝');
        }
        #endregion

        #region [Propriétés des attributs]
        /// <summary>
        /// Propriété membre _width
        /// </summary>
        public int Width
        {
            get { return _width; }
        }
        /// <summary>
        /// Propriété membre _height
        /// </summary>
        public int Height
        {
            get { return _height; }
        }
        /// <summary>
        /// Propriété membre _offset
        /// </summary>
        public int Offset
        {
            get { return _offset; }
        }
        #endregion
    }
}
