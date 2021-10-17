using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_SpaceInvaders
{
    class Menu
    {
        #region Déclaration des constantes
        /// <summary>
        /// Largeur de la fenêtre
        /// </summary>
        private const int _MENUWIDTH = 150;
        /// <summary>
        /// Hauteur de la fenêtre
        /// </summary>
        private const int _MENUHEIGHT = 30;
        /// <summary>
        /// Nombre des sauts de ligne par option
        /// </summary>
        private const int _LINEBREAK = 2;
        #endregion

        #region Déclaration des variables
        /// <summary>
        /// Titre du menu
        /// </summary>
        private string _header;
        /// <summary>
        /// Text à afficher
        /// </summary>
        private string _text;
        /// <summary>
        /// Liste des options
        /// </summary>
        private List<MenuItem> _menuItems;
        /// <summary>
        /// Tableau des switchs de configuration 
        /// </summary>
        private OptionSwitch[] _optionSwitch;
        /// <summary>
        /// Menu parent
        /// </summary>
        private Menu _parentMenu;
        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Menu()
        {

        }
        /// <summary>
        /// Constructeur ménu avec un titre
        /// </summary>
        /// <param name="header">Titre du ménu</param>
        public Menu(string header)
        {
            _header = header;
        }
        /// <summary>
        /// Constructor ménu d'info
        /// </summary>
        /// <param name="header">Titre du menu</param>
        /// <param name="text">Text ménu d'info</param>
        public Menu(string header, string text)
        {
            _header = header;
            _text = text;
        }
        /// <summary>
        /// Constructor ménu avec des options
        /// </summary>
        /// <param name="header">Titre du menu</param>
        /// <param name="menuItems">Tableau des options du ménu</param>
        public Menu(string header, List<MenuItem> menuItems)
        {
            _header = header;
            _menuItems = menuItems;
        }
        /// <summary>
        /// Constructeur ménu configuration
        /// </summary>
        /// <param name="header">Titre du menu</param>
        /// <param name="optionSwitch">Tableau des switchs de configuration</param>
        public Menu(string header, OptionSwitch[] optionSwitch)
        {
            _header = header;
            _optionSwitch = optionSwitch;
        }
        #endregion

        #region Methodes
        /// <summary>
        /// Redimensionne la fenêtre du ménu
        /// </summary>
        public void ResizeWindow()
        {
            Console.SetWindowSize(_MENUWIDTH,_MENUHEIGHT);
        }
        /// <summary>
        /// Dessiner le titre centré
        /// </summary>
        public void DrawHeader()
        {
            ResizeWindow();
            //StringReader pour lire ligne par ligne et centrer le texte
            using (StringReader reader = new StringReader(_header))
            {
                string line = "";
                Console.ForegroundColor=ConsoleColor.Red; //Changement de la couleur du texte
                do
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, Console.CursorTop);
                        Console.WriteLine(line);
                    }
                } 
                while (line != null);
                Console.ResetColor();
            }
        }
        /// <summary>
        /// Ecrit les options du ménu au centre de la fênetre
        /// </summary>
        public void DrawOptions()
        {
            int y = Console.CursorTop;      //Coordonnes pour positionner les options dans l'axe Y
            foreach (MenuItem menuItem in _menuItems)
            {
                //Récupération des coordonées de la première option
                menuItem.PosY = y + _LINEBREAK;
                menuItem.PosX = CalculCenterPosString(menuItem.NameItem);
                //Dessinne les options
                Console.SetCursorPosition(CalculCenterPosString(menuItem.NameItem), y += _LINEBREAK);
                Console.WriteLine(menuItem.NameItem);
            }
        }
        public void FirstOption()
        {
            ///TEST
            int cursor = 0;
            //Position sur l'option par défaut
            Console.CursorVisible = false;
            Console.SetCursorPosition(_menuItems[cursor].PosX, _menuItems[cursor].PosY);
            WriteTextInColor(_menuItems[0].NameItem, ConsoleColor.Red);
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            //Si le cursor est supérieur à l'ID de la première option
                            if (cursor > 0)
                            {
                                Console.SetCursorPosition(_menuItems[cursor].PosX, _menuItems[cursor].PosY);
                                WriteTextInColor(_menuItems[cursor].NameItem, ConsoleColor.Gray);
                                cursor--;
                                Console.SetCursorPosition(_menuItems[cursor].PosX, _menuItems[cursor].PosY);
                                WriteTextInColor(_menuItems[cursor].NameItem, ConsoleColor.Red);
                            }
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        {
                            //Tant que le cursor reste entre le nombre d'options possibles
                            if (cursor < _menuItems.Count - 1) 
                            {
                                Console.SetCursorPosition(_menuItems[cursor].PosX, _menuItems[cursor].PosY);
                                WriteTextInColor(_menuItems[cursor].NameItem, ConsoleColor.Gray);
                                cursor++;
                                Console.SetCursorPosition(_menuItems[cursor].PosX, _menuItems[cursor].PosY);
                                WriteTextInColor(_menuItems[cursor].NameItem, ConsoleColor.Red);
                            }                         
                        }
                        break;
                    case ConsoleKey.Escape:
                        {

                        }
                        break;
                    case ConsoleKey.Enter:
                        {
                            //Execution de la méthode de l'option selectionnée
                            _menuItems[cursor].Action();
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// Ecrit une chaîne de caractères d'une couleur définie
        /// </summary>
        /// <param name="text">Texte à écrire</param>
        /// <param name="color">Couleur du texte</param>
        public void WriteTextInColor(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        /// <summary>
        /// Calcul la pos X pour centrer un texte dans la fenêtre
        /// </summary>
        /// <param name="text">Text à centrer</param>
        /// <returns>Position en l'axe X pour centrer le texte</returns>
        public int CalculCenterPosString(string text)
        {
            return Console.WindowWidth / 2 - text.Length / 2;
        }
        #endregion

        #region Getteurs et Setteurs
        public Menu ParentMenu
        {
            get { return _parentMenu; }
            set { _parentMenu = value; }
        }
        public List<MenuItem> MenuItems
        {
            get { return _menuItems; }
            set { _menuItems = value; }
        }
        #endregion
    }
}
