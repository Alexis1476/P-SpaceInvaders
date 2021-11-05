using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_SpaceInvaders.GameObjects
{
    class GameObject
    {
        #region Attributs
        /// <summary>
        /// Position sur l'axe X de la console
        /// </summary>
        int _posX;
        /// <summary>
        /// Position sur l'axe Y de la console
        /// </summary>
        int _posY;
        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructeur par position en X et en Y
        /// </summary>
        /// <param name="posX">Position dans l'axe X de la console</param>
        /// <param name="posY">Position dans l'axe Y de la console</param>
        public GameObject(int posX, int posY)
        {
            _posX = posX;
            _posY = posY;
        }
        #endregion

        #region Getteurs et setteurs
        public int PosX
        {
            get { return _posX; }
            set { _posX = value; }
        }
        public int PosY
        {
            get { return _posY; }
            set { _posY = value; }
        }
        #endregion
    }
}
