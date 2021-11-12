using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_SpaceInvaders
{
    class Map
    {
        #region Attributs
        int _width;
        int _height;
        int _offset = 1;
        #endregion

        #region Constructeurs
        public Map(int width, int height)
        {
            _width = width;
            _height = height;
        }
        #endregion

        #region Methodes
        public void Draw()
        {
            //Coin supérieur gauche
            Console.SetCursorPosition(0, 0);
            Console.Write('╔');
            //Ligne horizontal supérieur
            for (int i = 0; i < Width; i++)
            {
                Console.Write('═');
            }
            //Coin supérieur droite   
            Console.Write('╗');
            //Lignes verticales
            for (int i = Offset; i < Offset + Height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write('║');
                Console.SetCursorPosition(Offset + Width, i);
                Console.Write('║');
            }
            //Coin inférieur gauche
            Console.SetCursorPosition(0, Offset + Height);
            Console.Write('╚');
            //Ligne horizontal inférieur
            for (int i = 0; i < Width; i++)
            {
                Console.Write('═');
            }
            //Coin inférieur droite
            Console.Write('╝');
        }
        #endregion

        #region Getteurs et setteurs
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }
        public int Offset
        {
            get { return _offset; }
            set { _offset = value; }
        }
        #endregion

    }
}
