using System;
using System.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_SpaceInvaders
{
    class Program
    {
        static void Main(string[] args)
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

            //TESTS
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\music8Bits.wav";
            player.Play();

            //Affichage du ménu
            mainMenu.DrawAllMenu();
        }
        public static void Play()
        {
            Console.Clear();
            Console.WriteLine("HOLA COMO ESTAMOS");
        }
        public static void MethodeTest()
        {
           
        }
        public static void Exit()
        {
            Environment.Exit(1);
        }
    }
}
