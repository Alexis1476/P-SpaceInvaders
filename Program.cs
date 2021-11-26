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

namespace P_SpaceInvaders
{
    class Program
    {
        private static Game _game;
        private static int _windowWidth = 150;
        private static int _windowHeight = 50;

        static void Main()
        {
            #region Titres des menus
            const string MAINTITLE =     "                                                                                                                 \n" +
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
            const string TITLEOPTIONS =  "                                                            \n" +
                                         " ▒█████   ██▓███  ▄▄▄█████▓ ██▓ ▒█████   ███▄    █   ██████ \n" +
                                         "▒██▒  ██▒▓██░  ██▒▓  ██▒ ▓▒▓██▒▒██▒  ██▒ ██ ▀█   █ ▒██    ▒ \n" +
                                         "▒██░  ██▒▓██░ ██▓▒▒ ▓██░ ▒░▒██▒▒██░  ██▒▓██  ▀█ ██▒░ ▓██▄   \n" +
                                         "▒██   ██░▒██▄█▓▒ ▒░ ▓██▓ ░ ░██░▒██   ██░▓██▒  ▐▌██▒  ▒   ██▒\n" +
                                         "░ ████▓▒░▒██▒ ░  ░  ▒██▒ ░ ░██░░ ████▓▒░▒██░   ▓██░▒██████▒▒\n" +
                                         "░ ▒░▒░▒░ ▒▓▒░ ░  ░  ▒ ░░   ░▓  ░ ▒░▒░▒░ ░ ▒░   ▒ ▒ ▒ ▒▓▒ ▒ ░\n" +
                                         "  ░ ▒ ▒░ ░▒ ░         ░     ▒ ░  ░ ▒ ▒░ ░ ░░   ░ ▒░░ ░▒  ░ ░\n" +
                                         "░ ░ ░ ▒  ░░         ░       ▒ ░░ ░ ░ ▒     ░   ░ ░ ░  ░  ░  \n" +
                                         "    ░ ░                     ░      ░ ░           ░       ░  \n\n";
            const string TITLESCORE =    "                                           \n" +
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
            const string TITLEABOUT =    "                                             \n" +
                                         " ▄▄▄       ▄▄▄▄    ▒█████   █    ██ ▄▄▄█████▓\n" +
                                         "▒████▄    ▓█████▄ ▒██▒  ██▒ ██  ▓██▒▓  ██▒ ▓▒\n" +
                                         "▒██  ▀█▄  ▒██▒ ▄██▒██░  ██▒▓██  ▒██░▒ ▓██░ ▒░\n" +
                                         "░██▄▄▄▄██ ▒██░█▀  ▒██   ██░▓▓█  ░██░░ ▓██▓ ░ \n" +
                                         " ▓█   ▓██▒░▓█  ▀█▓░ ████▓▒░▒▒█████▓   ▒██▒ ░ \n" +
                                         " ▒▒   ▓▒█░░▒▓███▀▒░ ▒░▒░▒░ ░▒▓▒ ▒ ▒   ▒ ░░   \n" +
                                         "  ▒   ▒▒ ░▒░▒   ░   ░ ▒ ▒░ ░░▒░ ░ ░     ░    \n" +
                                         "  ░   ▒    ░    ░ ░ ░ ░ ▒   ░░░ ░ ░   ░      \n" +
                                         "      ░  ░ ░          ░ ░     ░              \n\n";
            const string TEXTABOUT =     "╔═══════════════════════════════════════════════════════════╗\n" +
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

            #region Déclaration MainMenu et sous-menus
            Menu mainMenu = new Menu(MAINTITLE);
            Menu menuOptions = new Menu(TITLEOPTIONS, mainMenu);
            Menu menuAbout = new Menu(TITLEABOUT, mainMenu, TEXTABOUT);
            Menu menuScore = new Menu(TITLESCORE, mainMenu);
            #endregion

            #region Ajout des options à MainMenu
            mainMenu.AddMenuItems(1, "Play", Play);
            mainMenu.AddMenuItems(2, "Options", menuOptions.DrawAllMenu);
            mainMenu.AddMenuItems(3, "Score", menuScore.DrawAllMenu);
            mainMenu.AddMenuItems(4, "About", menuAbout.DrawAllMenu);
            mainMenu.AddMenuItems(5, "Exit", Exit);
            #endregion

            #region Ajout des switchs de configuration menu Options
            menuOptions.AddOptionSwitchItems(1, "Sound");
            menuOptions.AddOptionSwitchItems(2, "Difficulty");
            #endregion

            //TESTS SOUND
            //SoundPlayer player = new SoundPlayer();
            //player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Ressources\\music8Bits.wav";
            //player.Play();

            //Affichage du ménu
            mainMenu.DrawAllMenu();
        }
        /// <summary>
        /// Crée une partie
        /// </summary>
        public static void Play()
        {
            Console.Clear();
            while (true)
            {     
                //Titre
                Console.Write("Press ENTER to start!");
                Console.ReadLine();

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
                Console.Write("Game OVER");
            }        
        }
        private static void ReadInput()
        {
            //Tant que le vaisseau existe et que le joueur tape une touche de mouvement
            while (_game.Ship != null && Console.KeyAvailable)
            {
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
                        _game.Ship.Fire();
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
            _game = new Game(_windowWidth, _windowHeight);

            //Redimensionnement de la fenêtre et modif du fontSize
            ConsoleHelper.SetCurrentFont("Consolas", 9);
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
