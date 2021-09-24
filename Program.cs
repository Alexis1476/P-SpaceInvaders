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

            //Création ménu principal et submenus
            Menu mainMenu = new Menu(TITLEMAINMENU);
            Menu optionsMenu = new Menu(TITLEOPTIONS);
            Menu scoreMenu = new Menu(TITLESCORE);
            Menu aboutMenu = new Menu(TITLEABOUT, "Information du projet");

            /*------------------TEST------------------*/
            optionsMenu.AddMenuItems(1, "Son", MethodeTest);

            //Options du ménu principal
            mainMenu.AddMenuItems(1, "Play", MethodeTest);
            mainMenu.AddMenuItems(2, "Options", optionsMenu.ShowMenu);
            mainMenu.AddMenuItems(3, "Score", scoreMenu.ShowTitle);
            mainMenu.AddMenuItems(4, "About", aboutMenu.ShowTitle);
            mainMenu.AddMenuItems(5, "Exit", Exit);

            mainMenu.ShowMenu();
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
