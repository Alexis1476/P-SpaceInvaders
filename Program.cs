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
