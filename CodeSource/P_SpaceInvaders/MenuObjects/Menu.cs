///ETML
///Auteur : Alexis Rojas
///Date : 26.11.2021
///Description: Class qui permet de créer des menus avec ou sans options
using System;
using System.Collections.Generic;
using System.IO;
using System.Media;

/// <summary>
/// Objets rélatifs aux ménus
/// </summary>
namespace P_SpaceInvaders.MenuObjects
{
    /// <summary>
    /// Permet de créer des ménus, des sous-ménus avec des options, des switchs, ou simplement qu'avec du texte.
    /// </summary>
    public class Menu
    {
        #region [Constantes]
        /// <summary>
        /// Largeur de la fenêtre
        /// </summary>
        const int _MENUWIDTH = 150;
        /// <summary>
        /// Hauteur de la fenêtre
        /// </summary>
        const int _MENUHEIGHT = 30;
        /// <summary>
        /// Nombre des sauts de ligne par option
        /// </summary>
        const int _LINEBREAK = 2;
        /// <summary>
        /// Effet de son pour le changement d'option
        /// </summary>
        static readonly SoundPlayer _menuSound = new SoundPlayer(Audio.menuChange);
        /// <summary>
        /// Couleur pour le thème des ménus
        /// </summary>
        const ConsoleColor _COLOR = ConsoleColor.Magenta;
        #endregion

        #region [Attributs]
        /// <summary>
        /// Titre du menu
        /// </summary>
        string _header;
        /// <summary>
        /// Text à afficher
        /// </summary>
        string _text;
        /// <summary>
        /// Liste des options
        /// </summary>
        List<MenuItem> _menuItems;
        /// <summary>
        /// List des switchs de configuration 
        /// </summary>
        List<MenuSwitch> _menuSwitchs;
        /// <summary>
        /// Menu parent
        /// </summary>
        Menu _parentMenu;
        /// <summary>
        /// Chemin + nom du fichier des scores
        /// </summary>
        string _pathFile;
        #endregion

        #region [Constructeurs]
        /// <summary>
        /// Constructeur ménu avec un titre
        /// </summary>
        /// <param name="header">Titre du ménu</param>
        public Menu(string header)
        {
            _header = header;
            _menuItems = new List<MenuItem>();
        }
        /// <summary>
        /// Constructor par header et menuParent
        /// </summary>
        /// <param name="header">Titre du ménu</param>
        /// <param name="parentMenu">Menu parent</param>
        public Menu(string header, Menu parentMenu)
        {
            _header = header;
            _parentMenu = parentMenu;
        }
        /// <summary>
        /// Constructor ménu d'info
        /// </summary>
        /// <param name="header">Titre du menu</param>
        /// <param name="parentMenu">Menu parent</param>
        /// <param name="text">Text ménu d'info</param>
        public Menu(string header, Menu parentMenu, string text)
        {
            _header = header;
            _parentMenu = parentMenu;
            _text = text;
        }
        #endregion

        #region [Methodes]
        /// <summary>
        /// Ecris les scores qui se trouvent dans le fichier texte
        /// </summary>
        public void WriteScoreFile()
        {
            //En-têtes
            WriteCenteredText("Pseudo\tScore\n\n");

            //Si le fichier de scores existe
            if (File.Exists(_pathFile))
            {
                using (StreamReader sr = new StreamReader(_pathFile))
                {
                    WriteCenteredText(sr.ReadToEnd());
                }
            }
        }
        /// <summary>
        /// Redimensionne la fenêtre du ménu et la taille de police
        /// </summary>
        public static void ResizeWindow()
        {
            //Change la taille de police
            ConsoleHelper.SetCurrentFont("Consolas", 15);

            //Redimonsionne la console
            Console.SetWindowSize(_MENUWIDTH, _MENUHEIGHT);
        }
        /// <summary>
        /// Affiche le ménu complet et lit les touches du clavier
        /// </summary>
        public void DrawAllMenu()
        {
            //Redimonsionne la console
            ResizeWindow();

            //Nettoie le ménu précedent
            Console.Clear();

            //Affiche le titre du ménu
            DrawHeader();

            //Affiche les scores
            if (_pathFile != null)
            {
                WriteScoreFile();
            }

            //Affiche les options
            DrawOptions();

            //S'il y a un text dans le ménu
            if (_text != null)
            {
                WriteCenteredText(_text);
            }

            //Selection d'option
            ReadInput();
        }
        /// <summary>
        /// Ajoute une option au ménu
        /// </summary>
        /// <param name="id">Id de l'option</param>
        /// <param name="name">Nom de l'option</param>
        /// <param name="action">Methode pour l'option</param>
        public void AddMenuItems(int id, string name, Action action)
        {
            _menuItems.Add(new MenuItem(id, name, action));
        }
        /// <summary>
        /// Methode qui permet d'ajouter un switch de configuration (Sound or Difficulty)
        /// </summary>
        /// <param name="id">Id du switch</param>
        /// <param name="name">Nom du paramètre</param>
        public void AddOptionSwitchItems(int id, string name)
        {
            //Si la liste est vide alors on l'initialise
            if (_menuSwitchs == null)
            {
                _menuSwitchs = new List<MenuSwitch>();
            }
            //Ajout le switch de configuration
            _menuSwitchs.Add(new MenuSwitch(id, name));
        }
        /// <summary>
        /// Dessiner le titre centré
        /// </summary>
        public void DrawHeader()
        {
            //Position du curseur
            Console.SetCursorPosition(0, 0);

            //Changement de la couleur du texte
            Console.ForegroundColor = _COLOR;

            //Ecris le header
            WriteCenteredText(_header);
            Console.ResetColor();
        }
        /// <summary>
        /// Ecrit une chaine de caractères au centre de la fenêtre
        /// </summary>
        /// <param name="text">Texte à centrer</param>
        public static void WriteCenteredText(string text)
        {
            //StringReader pour lire ligne par ligne et centrer le texte
            using (StringReader reader = new StringReader(text))
            {
                //Ligne
                string line = "";
                do
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, Console.CursorTop);
                        Console.WriteLine(line);
                    }
                }
                //Tant qu'il n'arrive pas à la fin de la chaine de caractère
                while (line != null);
            }
        }
        /// <summary>
        /// Ecrit les options du ménu au centre de la fênetre
        /// </summary>
        public void DrawOptions()
        {
            //Coordonnes pour positionner les options dans l'axe Y
            int y = Console.CursorTop;

            #region [MenuItems]
            //S'il y a une liste d'options
            if (_menuItems != null)
            {
                foreach (MenuItem menuItem in _menuItems)
                {
                    //Récupération des coordonées de la première option
                    menuItem.PosY = y + _LINEBREAK;
                    menuItem.PosX = CalculCenterPosString(menuItem.NameItem);

                    //Dessinne les options
                    Console.SetCursorPosition(menuItem.PosX, menuItem.PosY);
                    Console.WriteLine(menuItem.NameItem);
                    y += _LINEBREAK;
                }
            }
            #endregion

            #region [OptionSwitch]
            //S'il y a une liste d'options Switch
            else if (_menuSwitchs != null)
            {
                foreach (MenuSwitch optionSwitch in _menuSwitchs)
                {
                    //Récupération des coordonées de la première option
                    optionSwitch.PosY = y + _LINEBREAK;
                    optionSwitch.PosX = CalculCenterPosString(optionSwitch.NameAndOption());

                    //Dessinne les options
                    Console.SetCursorPosition(optionSwitch.PosX, optionSwitch.PosY);
                    Console.WriteLine(optionSwitch.NameAndOption());
                    y += _LINEBREAK;
                }
            }
            #endregion
        }
        /// <summary>
        /// Permet d'intéragir avec le ménu, de selectionner des options ou des switchs
        /// </summary>
        public void ReadInput()
        {
            //Cursor pour savoir sur quel option on se trouve
            int cursor = 0;

            //Bool pour lire les touches clavier en boucle
            bool exit = false;

            //Position sur l'option par défaut
            Console.CursorVisible = false;

            //Si le ménu a des options
            if (_menuItems != null)
            {
                Console.SetCursorPosition(_menuItems[cursor].PosX, _menuItems[cursor].PosY);
                WriteTextInColor(_menuItems[0].NameItem, _COLOR);
            }

            //Si le ménu a des switchs de configuration
            else if (_menuSwitchs != null)
            {
                Console.SetCursorPosition(_menuSwitchs[cursor].PosX, _menuSwitchs[cursor].PosY);
                WriteTextInColor(_menuSwitchs[cursor].NameAndOption(), _COLOR);
            }
            while (!exit)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            //Si le ménu a des options
                            if (_menuItems != null)
                            {
                                //Si le cursor est supérieur à l'ID de la première option
                                if (cursor > 0)
                                {
                                    //Réproduit le son de changement d'option
                                    Program.PlaySound(_menuSound);

                                    //Reecrit l'option précedent en blanc
                                    Console.SetCursorPosition(_menuItems[cursor].PosX, _menuItems[cursor].PosY);
                                    WriteTextInColor(_menuItems[cursor].NameItem, ConsoleColor.Gray);

                                    //Change d'option
                                    cursor--;
                                    Console.SetCursorPosition(_menuItems[cursor].PosX, _menuItems[cursor].PosY);
                                    WriteTextInColor(_menuItems[cursor].NameItem, _COLOR);
                                }
                            }
                            //Si le ménu a des switchs de configuration
                            else if (_menuSwitchs != null)
                            {
                                //Si le cursor est supérieur à l'ID de la première option
                                if (cursor > 0)
                                {
                                    //Réproduit le son de changement d'option
                                    Program.PlaySound(_menuSound);

                                    //Reecrit l'option précedent en blanc
                                    Console.SetCursorPosition(_menuSwitchs[cursor].PosX, _menuSwitchs[cursor].PosY);
                                    WriteTextInColor(_menuSwitchs[cursor].NameAndOption(), ConsoleColor.Gray);

                                    //Change d'option
                                    cursor--;
                                    Console.SetCursorPosition(_menuSwitchs[cursor].PosX, _menuSwitchs[cursor].PosY);
                                    WriteTextInColor(_menuSwitchs[cursor].NameAndOption(), _COLOR);
                                }
                            }
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        {
                            //Si le ménu a des options
                            if (_menuItems != null)
                            {
                                //Tant que le cursor reste entre le nombre d'options possibles
                                if (cursor < _menuItems.Count - 1)
                                {
                                    //Réproduit le son de changement d'option
                                    Program.PlaySound(_menuSound);

                                    //Reecrit l'option précedent en blanc
                                    Console.SetCursorPosition(_menuItems[cursor].PosX, _menuItems[cursor].PosY);
                                    WriteTextInColor(_menuItems[cursor].NameItem, ConsoleColor.Gray);

                                    //Change d'option
                                    cursor++;
                                    Console.SetCursorPosition(_menuItems[cursor].PosX, _menuItems[cursor].PosY);
                                    WriteTextInColor(_menuItems[cursor].NameItem, _COLOR);
                                }
                            }
                            //Si le ménu a des switchs de configuration
                            else if (_menuSwitchs != null)
                            {
                                //Tant que le cursor reste entre le nombre d'options possibles
                                if (cursor < _menuSwitchs.Count - 1)
                                {
                                    //Réproduit le son de changement d'option
                                    Program.PlaySound(_menuSound);

                                    //Reecrit l'option précedent en blanc
                                    Console.SetCursorPosition(_menuSwitchs[cursor].PosX, _menuSwitchs[cursor].PosY);
                                    WriteTextInColor(_menuSwitchs[cursor].NameAndOption(), ConsoleColor.Gray);

                                    //Change d'option
                                    cursor++;
                                    Console.SetCursorPosition(_menuSwitchs[cursor].PosX, _menuSwitchs[cursor].PosY);
                                    WriteTextInColor(_menuSwitchs[cursor].NameAndOption(), _COLOR);
                                }
                            }
                        }
                        break;
                    case ConsoleKey.Escape:
                        {
                            //Si le menu possède un ménu parent
                            if (_parentMenu != null)
                            {
                                _parentMenu.DrawAllMenu();
                            }
                            else
                            {
                                Environment.Exit(1);
                            }
                        }
                        break;
                    case ConsoleKey.Spacebar:
                        {
                            //Si le ménu a des options
                            if (_menuItems != null)
                            {
                                //Execution de la méthode de l'option selectionnée
                                _menuItems[cursor].Action();
                            }
                            //Si le ménu a des switchs d'options
                            else if (_menuSwitchs != null)
                            {
                                _menuSwitchs[cursor].ChangeOption();
                                Console.SetCursorPosition(_menuSwitchs[cursor].PosX, _menuSwitchs[cursor].PosY);
                                WriteTextInColor(_menuSwitchs[cursor].NameAndOption(), _COLOR);
                            }
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
        public static void WriteTextInColor(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
        /// <summary>
        /// Calcul la pos X pour centrer un texte dans la fenêtre
        /// </summary>
        /// <param name="text">Text à centrer</param>
        /// <returns>Position en l'axe X pour centrer le texte</returns>
        public static int CalculCenterPosString(string text)
        {
            return Console.WindowWidth / 2 - text.Length / 2;
        }
        #endregion

        #region [Propriétés des attributs]
        /// <summary>
        /// Propriétés membre _optionSwitch
        /// </summary>
        public List<MenuSwitch> MenuSwitchs
        {
            get { return _menuSwitchs; }
            private set { _menuSwitchs = value; }
        }
        /// <summary>
        /// Propriétés membre _pathFile
        /// </summary>
        public string PathFile
        {
            get { return _pathFile; }
            set { _pathFile = value; }
        }
        #endregion
    }
}