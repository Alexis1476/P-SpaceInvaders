///ETML
///Auteur : Alexis Rojas
///Date : 26.11.2021
///Description: Class parent de tous les objets du jeu
using System;
using System.IO;

namespace P_SpaceInvaders.GameObjects
{
    class GameObject
    {
        #region Attributs
        /// <summary>
        /// Partie à laquelle l'objet appartient
        /// </summary>
        Game _game;
        /// <summary>
        /// Position sur l'axe X de la console
        /// </summary>
        int _posX;
        /// <summary>
        /// Position sur l'axe Y de la console
        /// </summary>
        int _posY;
        /// <summary>
        /// Image de l'objet faite avec des caractères
        /// </summary>
        string _chars;
        /// <summary>
        /// Largeur de l'objet
        /// </summary>
        int _widthChars;
        /// <summary>
        /// Hauteur de l'objet
        /// </summary>
        int _heightChars;
        #endregion

        #region Constructeurs
        public GameObject(Game game, string chars, int posX, int posY)
        {
            _game = game;
            _chars = chars;
            _posX = posX;
            _posY = posY;
            CalculateDimensionsObject(_chars);
        }
        public GameObject(Game game, string chars)
        {
            _game = game;
            _chars = chars;
            CalculateDimensionsObject(_chars);
        }
        #endregion

        #region Getteurs et setteurs
        public Game Game
        {
            get { return _game; }
        }
        public int PosX
        {
            get { return _posX; }
            set { _posX = value; }
        }
        public int PosY
        {
            get { return _posY; }
            set { _posY = value; }
        }
        public int WidthChars
        {
            get { return _widthChars; }
        }
        public int HeightChars
        {
            get { return _heightChars; }
        }
        #endregion

        #region Methodes

        private void CalculateDimensionsObject(string chars)
        {
            //Calcule la largeur de l'objet
            using (StringReader reader = new StringReader(chars))
            {
                string line = reader.ReadLine();
                _widthChars = line.Length;
            }

            //Calcule la hauteur de l'objet
            using (StringReader reader = new StringReader(chars))
            {
                int y = 0;
                string line = "";
                do
                {
                    line = reader.ReadLine();
                    y++;
                }
                while (line != null);
                _heightChars = y;
            }
        }
        public void Draw()
        {
            Console.SetCursorPosition(_posX, _posY);
            using (StringReader reader = new StringReader(_chars))
            {
                string line = "";
                do
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        Console.SetCursorPosition(_posX, Console.CursorTop);
                        Console.WriteLine(line);
                    }
                }
                while (line != null);
            }
        }
        /// <summary>
        /// Vérifie si l'objet se trouve entre les coordonnées de la map
        /// </summary>
        /// <returns>True si l'objet n'est pas sortie de la map</returns>
        public bool IsInMap()
        {
            //Si la PosY de l'objet se trouve entre les coordonnées de la map
            if (PosY >= Game.Map.Offset && PosY <= Game.Map.Height - Game.Map.Offset)
            {
                return true;
            }
            else { return false; }
        }
        public bool IsAtCoordinates(int posX, int posY)
        {
            return posY == PosY && posX >= PosX && posX < PosX + WidthChars ||
                posY == PosY + HeightChars - 2 && posX >= PosX && posX < PosX + WidthChars;
        }
        #endregion
    }
}
