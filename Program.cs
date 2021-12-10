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
using System.IO;

namespace P_SpaceInvaders
{
    /// <summary>
    /// Gère le déroulement du jeu
    /// </summary>
    class Program
    {
        #region Constantes
        /// <summary>
        /// Largeur de la fenêtre
        /// </summary>
        static int _WINDOWWIDTH = 150;
        /// <summary>
        /// Hauteur de la fenêtre
        /// </summary>
        static int _WINDOWHEIGHT = 70;
        /// <summary>
        /// Path du fichier de scores
        /// </summary>
        static string _PATHSCORES = ".\\score.txt";
        #endregion

        #region Attributs
        /// <summary>
        /// Game pour initialiser une partie
        /// </summary>
        static Game _game;
        /// <summary>
        /// Menu principal
        /// </summary>
        static Menu _mainMenu;
        /// <summary>
        /// Menu d'options (Sound et difficulty)
        /// </summary>
        static Menu _menuOptions;
        /// <summary>
        /// Menu à propos de
        /// </summary>
        static Menu _menuAbout;
        /// <summary>
        /// Menu scores
        /// </summary>
        static Menu _menuScore;
        /// <summary>
        /// Indique si le son doit être activé
        /// </summary>
        static bool _sound;
        /// <summary>
        /// Indique la difficulté du jeu
        /// </summary>
        static int _difficulty;
        #endregion

        #region Titres ASCII ART
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

        #region Propriétés des attriburs
        public static bool Sound
        {
            get { return _sound; }
            set { _sound = value; }
        }
        public static Menu MainMenu
        {
            get { return _mainMenu; }
        }
        #endregion

        #region Methodes
        /// <summary>
        /// Reproduit un son si le bool Sound est true
        /// </summary>
        /// <param name="sound">Son à reproduire</param>
        public static void PlaySound(SoundPlayer sound)
        {
            //Si le son est activé
            if (Program.Sound)
            {
                //Réproduit l'effet audio
                sound.Play();
            }
        }
        /// <summary>
        /// Méthode principal dès qu'on ouvre l'application
        /// </summary>
        static void Main()
        {
            #region [Déclaration MainMenu et sous-menus]
            _mainMenu = new Menu(MAINTITLE);
            _menuOptions = new Menu(TITLEOPTIONS, _mainMenu);
            _menuAbout = new Menu(TITLEABOUT, _mainMenu, TEXTABOUT);
            _menuScore = new Menu(TITLESCORE, _mainMenu);
            #endregion

            #region [Ajout des options à MainMenu]
            _mainMenu.AddMenuItems(1, "Play", Play);
            _mainMenu.AddMenuItems(2, "Options", _menuOptions.DrawAllMenu);
            _mainMenu.AddMenuItems(3, "Score", _menuScore.DrawAllMenu);
            _mainMenu.AddMenuItems(4, "About", _menuAbout.DrawAllMenu);
            _mainMenu.AddMenuItems(5, "Exit", Exit);
            #endregion

            #region [Ajout des switchs de configuration menu Options]
            _menuOptions.AddOptionSwitchItems(1, "Sound");
            _menuOptions.AddOptionSwitchItems(2, "Difficulty");
            #endregion

            //Ajout fichier .score au ménu score
            _menuScore.PathFile = _PATHSCORES;

            //Affichage du ménu
            _mainMenu.DrawAllMenu();
        }
        /// <summary>
        /// Vérifie les options choisis par l'utilisateur (Sound, Difficulty)
        /// </summary>
        public static void CheckOptionsSwitch()
        {
            //Parcourt la liste de switchs d'options du _menuOptions
            foreach(OptionSwitch optionSwitch in _menuOptions.OptionSwitch)
            {
                //Si c'est le switch pour le son
                if (optionSwitch.Name == "Sound")
                {
                    //Active ou desactive le son en fonction de l'option selectionnée
                    _sound = optionSwitch.Active;
                }
                //Si c'est le switch de la difficulté
                else if (optionSwitch.Name == "Difficulty")
                {
                    //Si difficulté = facil
                    if (optionSwitch.Index == 0)
                    {
                        _difficulty = 10;
                    }
                    //Sinon, si difficulté = normal
                    else if (optionSwitch.Index == 1)
                    {
                        _difficulty = 5;
                    }
                    //Sinon difficulté = hard
                    else
                    {
                        _difficulty = 2;
                    }
                }
            }

        }
        /// <summary>
        /// Crée une partie
        /// </summary>
        public static void Play()
        {
            //Vérifier les options choisies
            CheckOptionsSwitch();

            //Nettoie la console
            Console.Clear();

            //Bool pour vérifier si l'utilisateur souhaite continuer le jeu
            bool play = true;

            //Boucle pour jouer
            while (play)
            {     
                //Instantiation objet Game et redimonsionnement de la fenêtre
                Init();

                //Affiche la carte
                _game.Draw();

                //Initialisation de la partie
                while (_game.IsPlaying()) 
                {
                    //Lit les touches du clavier pour le mouvement du vaisseau
                    _game.ReadInput();

                    //Redessine les objets du jeu
                    _game.Update();

                    //Met à jour le score
                    Console.SetCursorPosition(0, 2 * _game.Map.Offset + _game.Map.Height);
                    Console.Write("Score: {0}", _game.Score);

                    //Affiche les vies du joueur
                    Console.SetCursorPosition(15, 2 * _game.Map.Offset + _game.Map.Height);
                    Console.Write("Lifes : ");

                    for (int i = 0; i < _game.SHIPLIFES; i++)
                    {
                        if (_game.Ship != null && _game.Ship.Lives > i)
                        {
                            Menu.WriteTextInColor("♥", ConsoleColor.Red);
                        }
                        else
                        {
                            Console.Write(" ");
                        }                       
                    }
                    Thread.Sleep(_difficulty);
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

            //Demande le pseudo à l'utilisateur
            Menu.WriteCenteredText("Votre score : " + _game.Score);
            Console.Write("Votre pseudo : ");
            string nick = Console.ReadLine();

            //Enregistre le score dans un fichier texte
            SaveScore(".\\score.txt", nick, _game.Score.ToString());

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
        /// <summary>
        /// Sauvegarde le score dans un fichier texte
        /// </summary>
        /// <param name="filePath">Chemin + nom du fichier texte</param>
        /// <param name="nick">Nom du joueur</param>
        /// <param name="score">Score</param>
        private static void SaveScore(string filePath, string nick, string score)
        {
            //Si le fichier n'existe pas
            if (File.Exists(filePath) == false)
            {
                //Création du fichier
                StreamWriter createFile = new StreamWriter(filePath);
                createFile.Close();
            }
            StreamWriter writeInfile = new StreamWriter(filePath, append: true);
            writeInfile.WriteLine(nick + "\t" + score);
            writeInfile.Close();
        }
        /// <summary>
        /// Initialise une partie et redimonsionne la fenêtre
        /// </summary>
        private static void Init()
        {
            //Nettoie la fenêtre
            Console.Clear();

            //Instance membre _game
             _game = new Game(_WINDOWWIDTH, _WINDOWHEIGHT, _difficulty);

            //Redimensionnement de la fenêtre et modif du fontSize
            ConsoleHelper.SetCurrentFont("Consolas", 10);
            Console.SetWindowSize(2 + _WINDOWWIDTH, 2 + _game.Map.Height + 10);
            Console.SetBufferSize(2 + _WINDOWWIDTH, 2 + _game.Map.Height + 10);
        }
        /// <summary>
        /// Ferme le jeu
        /// </summary>
        public static void Exit()
        {
            Environment.Exit(1);
        }
        #endregion
    }
}
