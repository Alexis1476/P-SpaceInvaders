///ETML
///Auteur : Alexis Rojas
///Date : 26.11.2021
///Description: Gère le déroulement du program principal
using System;
using System.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P_SpaceInvaders.MenuObjects;
using System.Threading;
using System.Timers;

namespace P_SpaceInvaders
{
    class Program
    {
        static Game _game;
        static int _windowWidth = 150;
        static int _windowHeight = 50;
        static Menu _mainMenu;
        static Menu _menuOptions;
        static Menu _menuAbout;
        static Menu _menuScore;
        static bool _sound;
        static int _difficulty;
        static System.Timers.Timer _timeToShoot; //TEST
        static bool _shoot;
        static SoundPlayer _player;
        #region Titres des menus
        const string MAINTITLE = "                                                                                                                 \n" +
                                     "  ██████  ██▓███   ▄▄▄       ▄████▄  ▓█████     ██▓ ███▄    █ ██▒   █▓ ▄▄▄      ▓█████▄ ▓█████  ██▀███    ██████ \n" +
                                     "▒██    ▒ ▓██░  ██▒▒████▄    ▒██▀ ▀█  ▓█   ▀    ▓██▒ ██ ▀█   █▓██░   █▒▒████▄    ▒██▀ ██▌▓█   ▀ ▓██ ▒ ██▒▒██    ▒ \n" +
                                     "░ ▓██▄   ▓██░ ██▓▒▒██  ▀█▄  ▒▓█    ▄ ▒███      ▒██▒▓██  ▀█ ██▒▓██  █▒░▒██  ▀█▄  ░██   █▌▒███   ▓██ ░▄█ ▒░ ▓██▄   \n" +
                                     "  ▒   ██▒▒██▄█▓▒ ▒░██▄▄▄▄██ ▒▓▓▄ ▄██▒▒▓█  ▄    ░██░▓██▒  ▐▌██▒ ▒██ █░░░██▄▄▄▄██ ░▓█▄   ▌▒▓█  ▄ ▒██▀▀█▄    ▒   ██▒\n" +
                                     "▒██████▒▒▒██▒ ░  ░ ▓█   ▓██▒▒ ▓███▀ ░░▒████▒   ░██░▒██░   ▓██░  ▒▀█░   ▓█   ▓██▒░▒████▓ ░▒████▒░██▓ ▒██▒▒██████▒▒\n" +
                                     "▒ ▒▓▒ ▒ ░▒▓▒░ ░  ░ ▒▒   ▓▒█░░ ░▒ ▒  ░░░ ▒░ ░   ░▓  ░ ▒░   ▒ ▒   ░ ▐░   ▒▒   ▓▒█░ ▒▒▓  ▒ ░░ ▒░ ░░ ▒▓ ░▒▓░▒ ▒▓▒ ▒ ░\n" +
                                     "░ ░▒  ░ ░░▒ ░       ▒   ▒▒ ░  ░  ▒    ░ ░  ░    ▒ ░░ ░░   ░ ▒░  ░ ░░    ▒   ▒▒ ░ ░ ▒  ▒  ░ ░  ░  ░▒ ░ ▒░░ ░▒  ░ ░\n" +
                                     "░  ░  ░  ░░         ░   ▒   ░           ░       ▒ ░   ░   ░ ░     ░░    ░   ▒    ░ ░  ░    ░     ░░   ░ ░  ░  ░  \n" +
                                     "      ░                 ░  ░░ ░         ░  ░    ░           ░      ░        ░  ░   ░       ░  ░   ░           ░  \n" +
                                     "                            ░                                     ░              ░                               \n\n";
        const string TITLEOPTIONS = "                                                            \n" +
                                     " ▒█████   ██▓███  ▄▄▄█████▓ ██▓ ▒█████   ███▄    █   ██████ \n" +
                                     "▒██▒  ██▒▓██░  ██▒▓  ██▒ ▓▒▓██▒▒██▒  ██▒ ██ ▀█   █ ▒██    ▒ \n" +
                                     "▒██░  ██▒▓██░ ██▓▒▒ ▓██░ ▒░▒██▒▒██░  ██▒▓██  ▀█ ██▒░ ▓██▄   \n" +
                                     "▒██   ██░▒██▄█▓▒ ▒░ ▓██▓ ░ ░██░▒██   ██░▓██▒  ▐▌██▒  ▒   ██▒\n" +
                                     "░ ████▓▒░▒██▒ ░  ░  ▒██▒ ░ ░██░░ ████▓▒░▒██░   ▓██░▒██████▒▒\n" +
                                     "░ ▒░▒░▒░ ▒▓▒░ ░  ░  ▒ ░░   ░▓  ░ ▒░▒░▒░ ░ ▒░   ▒ ▒ ▒ ▒▓▒ ▒ ░\n" +
                                     "  ░ ▒ ▒░ ░▒ ░         ░     ▒ ░  ░ ▒ ▒░ ░ ░░   ░ ▒░░ ░▒  ░ ░\n" +
                                     "░ ░ ░ ▒  ░░         ░       ▒ ░░ ░ ░ ▒     ░   ░ ░ ░  ░  ░  \n" +
                                     "    ░ ░                     ░      ░ ░           ░       ░  \n\n";
        const string TITLESCORE = "                                           \n" +
                                     "  ██████  ▄████▄   ▒█████   ██▀███  ▓█████ \n" +
                                     "▒██    ▒ ▒██▀ ▀█  ▒██▒  ██▒▓██ ▒ ██▒▓█   ▀ \n" +
                                     "░ ▓██▄   ▒▓█    ▄ ▒██░  ██▒▓██ ░▄█ ▒▒███   \n" +
                                     "  ▒   ██▒▒▓▓▄ ▄██▒▒██   ██░▒██▀▀█▄  ▒▓█  ▄ \n" +
                                     "▒██████▒▒▒ ▓███▀ ░░ ████▓▒░░██▓ ▒██▒░▒████▒\n" +
                                     "▒ ▒▓▒ ▒ ░░ ░▒ ▒  ░░ ▒░▒░▒░ ░ ▒▓ ░▒▓░░░ ▒░ ░\n" +
                                     "░ ░▒  ░ ░  ░  ▒     ░ ▒ ▒░   ░▒ ░ ▒░ ░ ░  ░\n" +
                                     "░  ░  ░  ░        ░ ░ ░ ▒    ░░   ░    ░   \n" +
                                     "      ░  ░ ░          ░ ░     ░        ░  ░\n" +
                                     "         ░                                 \n\n";
        const string TITLEABOUT = "                                             \n" +
                                     " ▄▄▄       ▄▄▄▄    ▒█████   █    ██ ▄▄▄█████▓\n" +
                                     "▒████▄    ▓█████▄ ▒██▒  ██▒ ██  ▓██▒▓  ██▒ ▓▒\n" +
                                     "▒██  ▀█▄  ▒██▒ ▄██▒██░  ██▒▓██  ▒██░▒ ▓██░ ▒░\n" +
                                     "░██▄▄▄▄██ ▒██░█▀  ▒██   ██░▓▓█  ░██░░ ▓██▓ ░ \n" +
                                     " ▓█   ▓██▒░▓█  ▀█▓░ ████▓▒░▒▒█████▓   ▒██▒ ░ \n" +
                                     " ▒▒   ▓▒█░░▒▓███▀▒░ ▒░▒░▒░ ░▒▓▒ ▒ ▒   ▒ ░░   \n" +
                                     "  ▒   ▒▒ ░▒░▒   ░   ░ ▒ ▒░ ░░▒░ ░ ░     ░    \n" +
                                     "  ░   ▒    ░    ░ ░ ░ ░ ▒   ░░░ ░ ░   ░      \n" +
                                     "      ░  ░ ░          ░ ░     ░              \n\n";
        const string TITLEGAMEOVER = "                                                                         \n" +
                                     "  ▄████  ▄▄▄       ███▄ ▄███▓▓█████     ▒█████   ██▒   █▓▓█████  ██▀███  \n" +
                                     " ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀    ▒██▒  ██▒▓██░   █▒▓█   ▀ ▓██ ▒ ██▒\n" +
                                     "▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███      ▒██░  ██▒ ▓██  █▒░▒███   ▓██ ░▄█ ▒\n" +
                                     "░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄    ▒██   ██░  ▒██ █░░▒▓█  ▄ ▒██▀▀█▄  \n" +
                                     "░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒   ░ ████▓▒░   ▒▀█░  ░▒████▒░██▓ ▒██▒\n" +
                                     " ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░   ░ ▒░▒░▒░    ░ ▐░  ░░ ▒░ ░░ ▒▓ ░▒▓░\n" +
                                     "  ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░     ░ ▒ ▒░    ░ ░░   ░ ░  ░  ░▒ ░ ▒░\n" +
                                     "░ ░   ░   ░   ▒   ░      ░      ░      ░ ░ ░ ▒       ░░     ░     ░░   ░ \n" +
                                     "      ░       ░  ░       ░      ░  ░       ░ ░        ░     ░  ░   ░     \n" +
                                     "                                                     ░                   ";
        const string QUESTION = "Souhaitez-vous continuer le jeu? \n (Enter pour continuer) (Esc pour sortir au ménu principal)";
        const string TEXTABOUT = "╔═══════════════════════════════════════════════════════════╗\n" +
                                     "║                  P_DEV - Space Invaders                   ║\n" +
                                     "║            ETML   CID2A (2021-2022)   Alexis Rojas        ║\n" +
                                     "╠═══════════════════════════════════════════════════════════╣\n" +
                                     "║ Récreation du fameux jeu 'Space Invaders' en mode console ║\n" +
                                     "║ programmé en C# (Projet en parallèle avec le module 226). ║\n" +
                                     "║                                                           ║\n" +
                                     "║ Le jeu vous permet de modifier la difficulté, d'activer   ║\n" +
                                     "║ le son et de vous montrer les scores.                     ║\n" +
                                     "╚═══════════════════════════════════════════════════════════╝";
        #endregion

        static void Main()
        {
            _timeToShoot = new System.Timers.Timer(400);
            _player = new SoundPlayer(".\\Ressources\\laserShoot.wav");
            #region Déclaration MainMenu et sous-menus
            _mainMenu = new Menu(MAINTITLE);
            _menuOptions = new Menu(TITLEOPTIONS, _mainMenu);
            _menuAbout = new Menu(TITLEABOUT, _mainMenu, TEXTABOUT);
            _menuScore = new Menu(TITLESCORE, _mainMenu);
            #endregion

            #region Ajout des options à MainMenu
            _mainMenu.AddMenuItems(1, "Play", Play);
            _mainMenu.AddMenuItems(2, "Options", _menuOptions.DrawAllMenu);
            _mainMenu.AddMenuItems(3, "Score", _menuScore.DrawAllMenu);
            _mainMenu.AddMenuItems(4, "About", _menuAbout.DrawAllMenu);
            _mainMenu.AddMenuItems(5, "Exit", Exit);
            #endregion

            #region Ajout des switchs de configuration menu Options
            _menuOptions.AddOptionSwitchItems(1, "Sound");
            _menuOptions.AddOptionSwitchItems(2, "Difficulty");
            #endregion

            //TESTS SOUND
            //SoundPlayer player = new SoundPlayer();
            //player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Ressources\\music8Bits.wav";
            //player.Play();

            //Affichage du ménu
            _mainMenu.DrawAllMenu();
        }
        public static void CheckOptionsSwitch()
        {
            foreach(OptionSwitch optionSwitch in _menuOptions.OptionSwitch)
            {
                if (optionSwitch.Name == "Sound")
                {
                    _sound = optionSwitch.Active;
                }
                else if (optionSwitch.Name == "Difficulty")
                {
                    _difficulty = optionSwitch.Index;
                }
            }

        }
        /// <summary>
        /// Crée une partie
        /// </summary>
        public static void Play()
        {
            _timeToShoot.Elapsed += OnTimedEvent;
            _timeToShoot.AutoReset = true;
            _timeToShoot.Enabled = true;
            //Vérifier les options choisies
            CheckOptionsSwitch();

            //Nettoie la console
            Console.Clear();

            //Bool pour vérifier si l'utilisateur souhaite continuer le jeu
            bool play = true;

            //Boucle pour jouer
            while (play)
            {     
                //Titre

                //Instantiation objet Game et redimonsionnement de la fenêtre
                Init();

                //Affiche la carte
                _game.Draw();

                //Initialisation de la partie
                while (_game.IsPlaying()) 
                {
                    //Lit les touches du clavier pour le mouvement du vaisseau
                    ReadInput();

                    //Redessine les objets du jeu
                    _game.Update();

                    //Score
                    Console.SetCursorPosition(0, 2 * _game.Map.Offset + _game.Map.Height);
                    Console.Write("Score: XX");
                    Thread.Sleep(20);
                }

                //Affichage GameOver et demande à l'utilisateur s'il souhaite continuer
                GameOver();
            }        
        }
        private static void GameOver()
        {
            //Nettoie la console et la redimonsionne
            Console.Clear();
            Menu.ResizeWindow();

            //Repositionnement du curseur
            Console.SetCursorPosition(0, 0);

            //Affichage titre GameOver
            Console.ForegroundColor = ConsoleColor.Red;
            Menu.WriteCenteredText(TITLEGAMEOVER);
            Console.ResetColor();

            //Demande à l'utilisateur s'il souahite continuer une nouvelle partie
            Menu.WriteCenteredText("Press 'Esc' to return to main menu\n Press 'Enter' to play again");
            bool exit = false;
            while (!exit)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Escape:
                        _mainMenu.DrawAllMenu();
                        break;
                    case ConsoleKey.Enter:
                        exit = true;
                        break;
                }

            }
        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            _shoot = true;
        }
        private static void ReadInput()
        {      
            //Tant que le vaisseau existe et que le joueur tape une touche de mouvement
            while (_game.Ship != null && Console.KeyAvailable)
            {;
                //Switch pour la séléction du mouvement et pour le tir
                switch (Console.ReadKey().Key)
                {
                    //Mouvement vers la gauche
                    case ConsoleKey.LeftArrow:
                        _game.Ship.Move(Direction.Left);
                        break;
                    //Mouvement vers la droite
                    case ConsoleKey.RightArrow:
                        _game.Ship.Move(Direction.Right);
                        break;
                    //Tir
                    case ConsoleKey.Spacebar:
                        if (_shoot)
                        {
                            _game.Ship.Fire();
                            _shoot = false;
                            _player.Play();
                        }                   
                        break;
                    //Si l'utilisateur tape sur une autre touche
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// Initialise une partie et redimonsionne la fenêtre
        /// </summary>
        private static void Init()
        {
            //Nettoie la fenêtre
            Console.Clear();

            //Instance membre _game
            _game = new Game(_windowWidth, _windowHeight, _sound, _difficulty);

            //Redimensionnement de la fenêtre et modif du fontSize
            ConsoleHelper.SetCurrentFont("Consolas", 12);
            Console.SetWindowSize(2 + _windowWidth, 2 + _game.Map.Height + 10);
            Console.SetBufferSize(2 + _windowWidth, 2 + _game.Map.Height + 10);
        }
        /// <summary>
        /// Ferme le jeu
        /// </summary>
        public static void Exit()
        {
            Environment.Exit(1);
        }
    }
}
