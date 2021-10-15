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
        /// Dessiner le titre
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
        public void DrawOptions()
        {
            int y = Console.CursorTop;   //Coordonnes pour positionner les options dans l'axe Y
            const int LINEBREAK = 2;     //Nb des sauts de ligne
            foreach (MenuItem menuItem in _menuItems)
            {
                Console.SetCursorPosition(CalculCenterPosString(menuItem.NameItem), y += LINEBREAK);
                Console.WriteLine(menuItem.NameItem);
            }
        }
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
