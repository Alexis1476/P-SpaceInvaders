///ETML
///Auteur : Alexis Rojas
///Date : 26.11.2021
///Description: Class parent de tous les objets du jeu
using System;
using System.IO;

/// <summary>
/// Objets du jeu
/// </summary>
namespace P_SpaceInvaders.GameObjects
{
    /// <summary>
    /// Class parent de tous les objets du jeu qui permet d'afficher l'objet crée et de vérifier ses positions
    /// </summary>
    public class GameObject
    {
        #region [Attributs]
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
        /// String représenant l'objet
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
        /// <summary>
        /// Tableau de string qui répresente les frames
        /// </summary>
        string[] _frames;
        /// <summary>
        /// Indique le frame à afficher
        /// </summary>
        int _frame;
        #endregion

        #region [Constructeurs]
        /// <summary>
        /// Constructeur par game, caractères, posX et posY
        /// </summary>
        /// <param name="game">Game</param>
        /// <param name="chars">String représenant l'objet</param>
        /// <param name="posX">Position en X</param>
        /// <param name="posY">Position en Y</param>
        public GameObject(Game game, string chars, int posX, int posY)
        {
            _game = game;
            _chars = chars;
            _posX = posX;
            _posY = posY;
            CalculateDimensionsObject(_chars);
        }
        /// <summary>
        /// Constructeur par game et caractères
        /// </summary>
        /// <param name="game">Game</param>
        /// <param name="chars">String représenant l'objet</param>
        public GameObject(Game game, string chars)
        {
            _game = game;
            _chars = chars;
            CalculateDimensionsObject(_chars);
        }
        /// <summary>
        /// Constructeur par game et par tableau de string (frames)
        /// </summary>
        /// <param name="game">Game</param>
        /// <param name="frames">Tableau de string représentant les frames</param>
        public GameObject(Game game, string[] frames)
        {
            _game = game;
            _frames = frames;
            CalculateDimensionsObject(_frames[0]);
        }
        #endregion

        #region [Propriétés des attributs]
        /// <summary>
        /// Propriétés membre _game
        /// </summary>
        public Game Game
        {
            get { return _game; }
        }
        /// <summary>
        /// Propriétés membre _posX
        /// </summary>
        public int PosX
        {
            get { return _posX; }
            set { _posX = value; }
        }
        /// <summary>
        /// Propriétés membre _posY
        /// </summary>
        public int PosY
        {
            get { return _posY; }
            set { _posY = value; }
        }
        /// <summary>
        /// Propriétés membre _widthChars
        /// </summary>
        public int WidthChars
        {
            get { return _widthChars; }
        }
        /// <summary>
        /// Propriétés membre _heightChars
        /// </summary>
        public int HeightChars
        {
            get { return _heightChars; }
        }
        #endregion

        #region [Methodes]
        /// <summary>
        /// Efface l'objet de la console
        /// </summary>
        public void Delete()
        {
            //Efface l'objet de sa position précédente
            Console.SetCursorPosition(PosX, PosY);

            for (int i = 0; i <= HeightChars; i++)
            {
                Console.SetCursorPosition(PosX, PosY);
                Console.Write(new string(' ', WidthChars));
            }
        }
        /// <summary>
        /// Calcule les dimensions de l'objet (Hauteur et largeur)
        /// </summary>
        /// <param name="chars">String représenant l'objet</param>
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
                string line = reader.ReadLine();
                while (line != null)
                {
                    line = reader.ReadLine();
                    y++;
                }                
                _heightChars = y;
            }
        }
        /// <summary>
        /// Dessine l'objet dans la console
        /// </summary>
        public void Draw()
        {
            //Positionne le curseur
            Console.SetCursorPosition(_posX, _posY);

            //S'il n'y a qu'un frame
            if (_chars != null)
            {
                using (StringReader reader = new StringReader(_chars))
                {
                    string line = "";
                    do
                    {
                        line = reader.ReadLine();
                        if (line != null)
                        {
                            Console.SetCursorPosition(_posX, Console.CursorTop);

                            //Dessine ligne par ligne
                            Console.WriteLine(line);
                        }
                    }
                    //Tant qu'il n'est pas arrivé à la fin du string
                    while (line != null);
                }
            }
            //Si l'objet a des frames
            else if (_frames != null)
            {
                //Si l'incrémentation de l'indicateur de frames est égal au nombre de frames
                if (++_frame == _frames.Length)
                {
                    //Réinitialise l'indicateur du frame à afficher
                    _frame = 0;
                }
                using (StringReader reader = new StringReader(_frames[_frame]))
                {
                    string line = "";
                    do
                    {
                        line = reader.ReadLine();
                        if (line != null)
                        {
                            Console.SetCursorPosition(_posX, Console.CursorTop);

                            //Dessine ligne par ligne
                            Console.WriteLine(line);
                        }
                    }
                    //Tant qu'il n'est pas arrivé à la fin du string
                    while (line != null);
                }
            }
        }
        /// <summary>
        /// Vérifie si l'objet se trouve entre les coordonnées de la map
        /// </summary>
        /// <returns>True si l'objet n'est pas sortie de la map; sinon false</returns>
        public bool IsInMap()
        {
            //Si la PosY de l'objet se trouve entre les coordonnées de la map
            if (PosY >= Game.Map.Offset && PosY <= Game.Map.Height - Game.Map.Offset)
            {
                return true;
            }
            else { return false; }
        }
        /// <summary>
        /// Vérifie si l'objet se trouve à une position spécifiée
        /// </summary>
        /// <param name="posX">Position en X</param>
        /// <param name="posY">Position en Y</param>
        /// <returns></returns>
        public bool IsAtCoordinates(int posX, int posY)
        {
            //Pour i jusqu'à la hauteur de l'objet
            for (int y = 0; y < HeightChars; y++)
            {
                //Si les positions en X coincident
                if (posY == PosY + y && posX >= PosX && posX < PosX + WidthChars ||
                posY == PosY + y && posX >= PosX && posX < PosX + WidthChars)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}
