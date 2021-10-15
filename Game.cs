using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_SpaceInvaders
{
    class Game
    {
        #region Constantes
        /// <summary>
        /// Frames invader Crab
        /// </summary>
        readonly string[] _CRABFRAMES = new string[] 
        {
            //Premier frame crab
            "           \n" +
            "   ▀▄ ▄▀   \n" +
            "  ▄█▀█▀█▄  \n" +
            " █▀█████▀█ \n" +
            " █ █▀▀▀█ █ \n" +
            "   ▀▀ ▀▀    ",
            //Deuxieme frame crab
            "           \n" +
            " ▄ ▀▄ ▄▀ ▄ \n" +
            " █▄█████▄█ \n" +
            " ███▄█▄███ \n" +
            " ▀███████▀ \n" +
            "  ▄▀   ▀▄  "
        };
        /// <summary>
        /// Frames invader Octopus
        /// </summary>
        readonly string[] _OCTOPUSFRAMES = new string[]
        {
            //Premier frame octopus
            "           \n" +
            "  ▄▄███▄▄  \n" +
            " █████████ \n" +
            " ██▄▄█▄▄██ \n" +
            "  ▄▀ ▄ ▀▄  \n" +
            "   ▀   ▀   ",
            //Seconde frame octopus
            "           \n" +
            "  ▄▄███▄▄  \n" +
            " █████████ \n" +
            " ██▄▄█▄▄██ \n" +
            "  ▄▀ ▄ ▀▄  \n" +
            " ▀       ▀ "
        };
        /// <summary>
        /// Frames invader Squid
        /// </summary>
        readonly string[] _SQUIDFRAMES = new string[]
        {
            //Premier frame squid
            "           \n" +
            "    ▄█▄    \n" +
            "  ▄█████▄  \n" +
            " ███▄█▄███ \n" +
            "   ▄▀▄▀▄   \n" +
            "  ▀ ▀ ▀ ▀  ",
            //Deuxieme frame squid
            "           \n" +
            "    ▄█▄    \n" +
            "  ▄█████▄  \n" +
            " ███▄█▄███ \n" +
            "  ▄▀   ▀▄  \n" +
            "   ▀   ▀  "
        };
        /// <summary>
        /// Frame UFO
        /// </summary>
        readonly string _UFO = 
            "               \n" +
            "     ▄▄█▄▄     \n" +
            "   ▄███████▄   \n" +
            " ▄██▄█▄█▄█▄██▄ \n" +
            "   ▀█▀ ▀ ▀█▀   ";
        #endregion

        #region Attributs
        private List<Invader> _invadersList;
        private Ship _ship;
        private Random _random;
        #endregion

        #region Constructors
        public Game()
        {
            //Redimensionnement de la fenêtre et modif du fontSize

            _invadersList = new List<Invader>(); // Initialisation invaderList
            //TESTS
            for (int i = 0; i < 11; i++)
            {
                Invader newInvader = new Invader(_CRABFRAMES);
                _invadersList.Add(newInvader);
            }
        }
        #endregion

        #region Methodes
        #endregion

        #region Getteurs et setteurs
        #endregion

        //Ship ship = new Ship(50, 50, 3, "-^-");

        //public Game()
        //{

        //}
        //public void InitializeGame()
        //{
        //    Console.Clear();
        //    ResizeWindows();
        //    DrawGameInfo();
        //    ship.ShowShip();
        //}
        //public void DrawGameInfo()
        //{
        //    Console.SetCursorPosition(1, Console.WindowHeight - 3);

        //}
        //public void ResizeWindows()
        //{
        //    Console.SetWindowSize(100,50);
        //}
    }
}
