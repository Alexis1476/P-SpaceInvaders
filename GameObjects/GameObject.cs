using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        #endregion

        #region Constructeurs
        public GameObject(Game game, string chars, int posX, int posY)
        {
            _game = game;
            _chars = chars;
            _posX = posX;
            _posY = posY;      
            _widthChars = CalculateCharsWidth(_chars);
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
        #endregion

        #region Methodes
        /// <summary>
        /// Calcule la largeur des caractères de l'objet
        /// </summary>
        /// <param name="chars">Caractères de l'objet</param>
        /// <returns>Largeur de l'objet</returns>
        private int CalculateCharsWidth(string chars)
        {
            string line = "";
            using (StringReader reader = new StringReader(chars))
            {      
                line = reader.ReadLine();
                return line.Length;
            }
        }
        public void Draw()
        {
            Console.SetCursorPosition(_posX, _posY);
            Console.Write(_chars);
        }
        /// <summary>
        /// Vérifie si l'objet se trouve entre les coordonnées de la map
        /// </summary>
        /// <returns>True si l'objet n'est pas sortie de la map</returns>
        public bool IsInMap()
        {
            //Si la PosY de l'objet se trouve entre les coordonnées de la map
            if(PosY >= Game.Map.Offset && PosY <= Game.Map.Height - Game.Map.Offset)
            {
                return true;
            }
            else { return false; }
        }
        #endregion
    }
}
