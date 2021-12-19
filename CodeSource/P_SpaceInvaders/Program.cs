///ETML
///Auteur : Alexis Rojas
///Date : 26.11.2021
///Description: Gère le déroulement du program principal
using P_SpaceInvaders.MenuObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Threading;

namespace P_SpaceInvaders
{
    /// <summary>
    /// Gère le déroulement du jeu
    /// </summary>
    class Program
    {
        #region [Constantes]
        /// <summary>
        /// Largeur de la fenêtre
        /// </summary>
        const int _WINDOWWIDTH = 130;
        /// <summary>
        /// Hauteur de la fenêtre
        /// </summary>
        const int _WINDOWHEIGHT = 70;
        /// <summary>
        /// Path du fichier de scores
        /// </summary>
        static readonly string _PATHSCORES = Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\Desktop\Score.txt");
        /// <summary>
        /// Nombre de Scores à enregistrer
        /// </summary>
        const int _NBHIGHSCORE = 10;
        #endregion

        #region [Attributs]
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
        static Menu _menuHighScore;
        /// <summary>
        /// Indique si le son doit être activé
        /// </summary>
        static bool _sound;
        /// <summary>
        /// Indique la difficulté du jeu
        /// </summary>
        static int _difficulty;
        #endregion

        #region [Propriétés des attriburs]
        /// <summary>
        /// Propriétés du membre _sound
        /// </summary>
        public static bool Sound
        {
            get { return _sound; }
            set { _sound = value; }
        }
        /// <summary>
        /// Propriétés du membre _mainMenu
        /// </summary>
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
            _mainMenu = new Menu(CharsASCII.MAINTITLE);
            _menuOptions = new Menu(CharsASCII.TITLEOPTIONS, _mainMenu);
            _menuAbout = new Menu(CharsASCII.TITLEABOUT, _mainMenu, CharsASCII.TEXTABOUT);
            _menuHighScore = new Menu(CharsASCII.TITLESCORE, _mainMenu);
            #endregion

            #region [Ajout des options à MainMenu]
            _mainMenu.AddMenuItems(1, "Play", Play);
            _mainMenu.AddMenuItems(2, "Options", _menuOptions.DrawAllMenu);
            _mainMenu.AddMenuItems(3, "Score", _menuHighScore.DrawAllMenu);
            _mainMenu.AddMenuItems(4, "About", _menuAbout.DrawAllMenu);
            _mainMenu.AddMenuItems(5, "Exit", Exit);
            #endregion

            #region [Ajout des switchs de configuration menu Options]
            _menuOptions.AddOptionSwitchItems(1, "Sound");
            _menuOptions.AddOptionSwitchItems(2, "Difficulty");
            #endregion

            //Ajout fichier .score au ménu score
            _menuHighScore.PathFile = _PATHSCORES;

            //Affichage du ménu
            _mainMenu.DrawAllMenu();
        }
        /// <summary>
        /// Vérifie les options choisis par l'utilisateur (Sound, Difficulty)
        /// </summary>
        public static void CheckOptionsSwitch()
        {
            //Parcourt la liste de switchs d'options du _menuOptions
            foreach (MenuSwitch optionSwitch in _menuOptions.MenuSwitchs)
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
                        _difficulty = 8;
                    }
                    //Sinon, si difficulté = normal
                    else if (optionSwitch.Index == 1)
                    {
                        _difficulty = 4;
                    }
                    //Sinon difficulté = hard
                    else
                    {
                        _difficulty = 1;
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
                    Thread.Sleep(5);
                }

                //Affichage GameOver et demande à l'utilisateur s'il souhaite continuer
                GameOver();
            }
        }
        /// <summary>
        /// Dès que la partie est fini
        /// </summary>
        private static void GameOver()
        {
            //Nettoie la console et la redimonsionne
            Console.Clear();
            Menu.ResizeWindow();

            //Repositionnement du curseur
            Console.SetCursorPosition(0, 0);

            //Si le joueur a perdu
            if (_game.Ship == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Menu.WriteCenteredText(CharsASCII.TITLEGAMEOVER);
            }
            //Si le joueur a gagné
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Menu.WriteCenteredText(CharsASCII.TITLEYOUWIN);
            }
            Console.ResetColor();

            //Demande le pseudo à l'utilisateur
            Menu.WriteCenteredText("Your score : " + _game.Score);
            string askName = "Your nickname : ";
            Console.SetCursorPosition((Console.WindowWidth - askName.Length) / 2, Console.CursorTop);
            Console.Write(askName);
            string nick = Console.ReadLine();

            //Enregistre le score dans un fichier texte
            SaveScore(_PATHSCORES, nick, _game.Score);

            //Demande à l'utilisateur s'il souahite continuer une nouvelle partie
            Menu.WriteCenteredText("\nPress 'Esc' to return to main menu\n Press 'Spacebar' to play again");
            bool exit = false;
            while (!exit)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Escape:
                        _mainMenu.DrawAllMenu();
                        break;
                    case ConsoleKey.Spacebar:
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
        private static void SaveScore(string filePath, string nick, int score)
        {
            //Si le fichier n'existe pas
            if (File.Exists(filePath) == false)
            {
                //Création du fichier
                StreamWriter createFile = new StreamWriter(filePath);
                createFile.Close();
            }
            //Liste de scores existantes
            List<Score> scores = new List<Score>();

            //StreamReader pour lire le fichier de scores
            StreamReader sr = new StreamReader(filePath);

            //Variable pour lire chaque ligne
            string line = "";

            //Tant que le streamReader n'arrive pas à la fin du texte
            while ((line = sr.ReadLine()) != null)
            {
                //Tableau de string [0] = nickName [1] = score
                string[] lineArray = line.Split('\t');

                //Ajoute les scores dans la liste
                scores.Add(new Score(lineArray[0], Convert.ToInt32(lineArray[1])));
            }
            //Ferme le streamReader
            sr.Close();

            //Ajout le Score actuel à la liste
            scores.Add(new Score(nick, score));

            //Trie les Scores par ordre décroissant
            scores = scores.OrderByDescending(x => x.ScorePoints).ToList();

            //StreamWriter pour écrire dans le fichier
            StreamWriter sw = new StreamWriter(filePath);
            for (int i = 0; i < _NBHIGHSCORE; i++)
            {
                //Si la liste n'a pas autant de scores enregistrés
                if (i == scores.Count)
                {
                    break;
                }
                else
                {
                    //Ecris le score dans le fichier texte
                    sw.WriteLine(scores[i].NickName + "\t" + scores[i].ScorePoints);
                }
            }
            //Ferme le StreamWriter
            sw.Close();
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
