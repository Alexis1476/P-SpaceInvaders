using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_SpaceInvaders
{
    class Menu
    {
        private const int _MENUWIDTH = 138;                 //Width fenêtre ménu principal
        private const int _MENUHEIGHT = 30;                 //Height fenêtre ménu principal
        private const int _YFIRSTOPTION = 14;               //Coordonée première option
        private const int _LINEBREAK = 2;
        private int _x = 64;                                //Coordonnées en X pour l'affichage des options
        private int _y = _YFIRSTOPTION;                     //Coordonnées en Y pour l'affichage des options
        private bool _exit;                                 //Bool pour retourner au ménu principal
        private int _cursor;                             //Position du curseur selection des options


        private string _header;                    //Titre du menu
        private string _text;                      //Text à afficher s'il y en a
        private List<MenuItem> _menuItems;         //Liste des options
        private Menu _parentMenu;                  //Menu parent


        /// <summary>
        /// Constructor par défaut
        /// </summary>
        public Menu()
        {

        }
        public Menu(string header)
        {
            _header = header;
            _menuItems = new List<MenuItem>();
        }
        public Menu(string header, string text)
        {
            _menuItems = new List<MenuItem>();
            _header = header;
            _text = text;
        }
        public void ShowTitle()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(_header);
            Console.ResetColor();
        }
        public void ShowOptions()
        {
            //Parcoure tous les items du ménu et les affiche
            foreach (MenuItem element in _menuItems)
            {
                Console.SetCursorPosition(_x, _y);
                Console.WriteLine(element.Text);
                _y += _LINEBREAK;
            }
        }
        public void ShowwMenuText()
        {
            ShowTitle();
            Console.Write(_text);
        }
        public void ShowMenu()
        {
            //Redimonsionnement de la console
            Console.SetWindowSize(_MENUWIDTH, _MENUHEIGHT);
            Console.CursorVisible = false;
            //Affichage du titre et des options
            ShowTitle();
            ShowOptions();
            //Repositionnement du cursor à la première option
            _y = _YFIRSTOPTION;
            Console.SetCursorPosition(_x, _y);
            _exit = false;
            //Selection d'options
            while (!_exit)
            {
                SelectOption();
            }
        }
        public void SelectOption()
        {
            ChangeOptionColor(); //Couleur première option        
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    {
                        if (_cursor > 0)
                        {
                            ResetColor();
                            //Changement d'option + changement de couleur
                            _cursor--;
                            _y -= _LINEBREAK;
                            ChangeOptionColor();
                        }
                    }
                    break;
                case ConsoleKey.DownArrow:
                    {
                        //Si le cursor se trouve entre le nombre d'options possibles
                        if (_cursor < _menuItems.Count() - 1)
                        {
                            ResetColor();
                            //Changement d'option + changement de couleur
                            _cursor++;
                            _y += _LINEBREAK;
                            ChangeOptionColor();
                        }
                    }
                    break;
                case ConsoleKey.Escape:
                    {
                        if (_parentMenu != null)
                        {
                            _exit = true;                    
                        }
                    }
                    break;
                case ConsoleKey.Enter:
                    {
                        Console.Clear();
                        _menuItems[_cursor].Action();
                        Console.Clear();
                    }
                    break;
                default:
                    break;
            }
        }
        public void ChangeOptionColor()
        {
            Console.SetCursorPosition(_x, _y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("{0}", _menuItems[_cursor].Text);
        }
        public void ResetColor()
        {
            Console.SetCursorPosition(_x, _y);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("{0}", _menuItems[_cursor].Text);
        }
        /// <summary>
        /// Ajoute une option au ménu
        /// </summary>
        /// <param name="id">Id de l'option</param>
        /// <param name="text">Nom de l'option</param>
        /// <param name="action">Methode pour l'option</param>
        public void AddMenuItems(int id, string text, Action action)
        {
            _menuItems.Add(new MenuItem(id, text, action));
        }
        public string Header
        {
            get { return _header; }
            set { _header = value; }
        }
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        public Menu ParentMenu
        {
            get { return _parentMenu; }
            set { _parentMenu = value; }
        }
    }
}
