using System;
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
            const string TITLEMAINMENU = @"

              ██████  ██▓███   ▄▄▄       ▄████▄  ▓█████     ██▓ ███▄    █  ██▒   █▓ ▄▄▄      ▓█████▄ ▓█████  ██▀███    ██████ 
            ▒██    ▒ ▓██░  ██▒▒████▄    ▒██▀ ▀█  ▓█   ▀    ▓██▒ ██ ▀█   █ ▓██░   █▒▒████▄    ▒██▀ ██▌▓█   ▀ ▓██ ▒ ██▒▒██    ▒ 
            ░ ▓██▄   ▓██░ ██▓▒▒██  ▀█▄  ▒▓█    ▄ ▒███      ▒██▒▓██  ▀█ ██▒ ▓██  █▒░▒██  ▀█▄  ░██   █▌▒███   ▓██ ░▄█ ▒░ ▓██▄   
              ▒   ██▒▒██▄█▓▒ ▒░██▄▄▄▄██ ▒▓▓▄ ▄██▒▒▓█  ▄    ░██░▓██▒  ▐▌██▒  ▒██ █░░░██▄▄▄▄██ ░▓█▄   ▌▒▓█  ▄ ▒██▀▀█▄    ▒   ██▒
            ▒██████▒▒▒██▒ ░  ░ ▓█   ▓██▒▒ ▓███▀ ░░▒████▒   ░██░▒██░   ▓██░   ▒▀█░   ▓█   ▓██▒░▒████▓ ░▒████▒░██▓ ▒██▒▒██████▒▒
            ▒ ▒▓▒ ▒ ░▒▓▒░ ░  ░ ▒▒   ▓▒█░░ ░▒ ▒  ░░░ ▒░ ░   ░▓  ░ ▒░   ▒ ▒    ░ ▐░   ▒▒   ▓▒█░ ▒▒▓  ▒ ░░ ▒░ ░░ ▒▓ ░▒▓░▒ ▒▓▒ ▒ ░
            ░ ░▒  ░ ░░▒ ░       ▒   ▒▒ ░  ░  ▒    ░ ░  ░    ▒ ░░ ░░   ░ ▒░   ░ ░░    ▒   ▒▒ ░ ░ ▒  ▒  ░ ░  ░  ░▒ ░ ▒░░ ░▒  ░ ░
            ░  ░  ░  ░░         ░   ▒   ░           ░       ▒ ░   ░   ░ ░      ░░    ░   ▒    ░ ░  ░    ░     ░░   ░ ░  ░  ░  
                  ░                 ░  ░░ ░         ░  ░    ░           ░       ░        ░  ░   ░       ░  ░   ░           ░  
                                        ░                                      ░              ░                               
            ";
            const string TITLEOPTIONS = @"

             ▒█████   ██▓███  ▄▄▄█████▓ ██▓ ▒█████   ███▄    █   ██████ 
            ▒██▒  ██▒▓██░  ██▒▓  ██▒ ▓▒▓██▒▒██▒  ██▒ ██ ▀█   █ ▒██    ▒ 
            ▒██░  ██▒▓██░ ██▓▒▒ ▓██░ ▒░▒██▒▒██░  ██▒▓██  ▀█ ██▒░ ▓██▄   
            ▒██   ██░▒██▄█▓▒ ▒░ ▓██▓ ░ ░██░▒██   ██░▓██▒  ▐▌██▒  ▒   ██▒
            ░ ████▓▒░▒██▒ ░  ░  ▒██▒ ░ ░██░░ ████▓▒░▒██░   ▓██░▒██████▒▒
            ░ ▒░▒░▒░ ▒▓▒░ ░  ░  ▒ ░░   ░▓  ░ ▒░▒░▒░ ░ ▒░   ▒ ▒ ▒ ▒▓▒ ▒ ░
              ░ ▒ ▒░ ░▒ ░         ░     ▒ ░  ░ ▒ ▒░ ░ ░░   ░ ▒░░ ░▒  ░ ░
            ░ ░ ░ ▒  ░░         ░       ▒ ░░ ░ ░ ▒     ░   ░ ░ ░  ░  ░  
                ░ ░                     ░      ░ ░           ░       ░                                                                                                       
            ";

            const string TITLESCORE = @"

              ██████  ▄████▄   ▒█████   ██▀███  ▓█████ 
            ▒██    ▒ ▒██▀ ▀█  ▒██▒  ██▒▓██ ▒ ██▒▓█   ▀ 
            ░ ▓██▄   ▒▓█    ▄ ▒██░  ██▒▓██ ░▄█ ▒▒███   
              ▒   ██▒▒▓▓▄ ▄██▒▒██   ██░▒██▀▀█▄  ▒▓█  ▄ 
            ▒██████▒▒▒ ▓███▀ ░░ ████▓▒░░██▓ ▒██▒░▒████▒
            ▒ ▒▓▒ ▒ ░░ ░▒ ▒  ░░ ▒░▒░▒░ ░ ▒▓ ░▒▓░░░ ▒░ ░
            ░ ░▒  ░ ░  ░  ▒     ░ ▒ ▒░   ░▒ ░ ▒░ ░ ░  ░
            ░  ░  ░  ░        ░ ░ ░ ▒    ░░   ░    ░   
                  ░  ░ ░          ░ ░     ░        ░  ░
                     ░                                 
            ";

            const string TITLEABOUT = @"
           
             ▄▄▄       ▄▄▄▄    ▒█████   █    ██ ▄▄▄█████▓
            ▒████▄    ▓█████▄ ▒██▒  ██▒ ██  ▓██▒▓  ██▒ ▓▒
            ▒██  ▀█▄  ▒██▒ ▄██▒██░  ██▒▓██  ▒██░▒ ▓██░ ▒░
            ░██▄▄▄▄██ ▒██░█▀  ▒██   ██░▓▓█  ░██░░ ▓██▓ ░ 
             ▓█   ▓██▒░▓█  ▀█▓░ ████▓▒░▒▒█████▓   ▒██▒ ░ 
             ▒▒   ▓▒█░░▒▓███▀▒░ ▒░▒░▒░ ░▒▓▒ ▒ ▒   ▒ ░░   
              ▒   ▒▒ ░▒░▒   ░   ░ ▒ ▒░ ░░▒░ ░ ░     ░    
              ░   ▒    ░    ░ ░ ░ ░ ▒   ░░░ ░ ░   ░      
                  ░  ░ ░          ░ ░     ░              
                            ░                            
            ";
            const string ABOUTEXT = @"
            /------------------------------------\
            |               P_Dev                |
            |           Space Invaders           |
            |                                    |
            |                                    |
            |                                    |
            |                                    |
            |                                    |
            |                                    |
            |                                    |
            \------------------------------------/";

            ////Création ménu principal
            //Menu mainMenu = new Menu(TITLEMAINMENU);
            ////Menu d'options
            //Menu optionsMenu = new Menu(TITLEOPTIONS);
            //optionsMenu.ParentMenu = mainMenu;
            ////Menu de score
            //Menu scoreMenu = new Menu(TITLESCORE);
            //scoreMenu.ParentMenu = mainMenu;
            ////Menu à propos
            //Menu aboutMenu = new Menu(TITLEABOUT, ABOUTEXT);
            //aboutMenu.ParentMenu = mainMenu;

            ///*------------------TEST------------------*/
            //optionsMenu.AddMenuItems(1, "Son", MethodeTest);


            ////Options du ménu principal
            //mainMenu.AddMenuItems(1, "Play", newGame.InitializeGame);
            //mainMenu.AddMenuItems(2, "Options", optionsMenu.ShowMenu);
            //mainMenu.AddMenuItems(3, "Score", scoreMenu.ShowTitle);
            //mainMenu.AddMenuItems(4, "About", aboutMenu.ShowMenu);
            //mainMenu.AddMenuItems(5, "Exit", Exit);

            ////Affiche le menu principal
            //mainMenu.ShowMenu();

            //Creation instance game
            Game newGame = new Game();
            newGame.InitializeGame();
            Console.ReadLine();
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
