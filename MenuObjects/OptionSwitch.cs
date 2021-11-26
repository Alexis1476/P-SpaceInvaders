///ETML
///Auteur : Alexis Rojas
///Date : 26.11.2021
///Description: Permet de créer un switch pour activer le son ou un switch pour modifier la difficulté du jeu
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_SpaceInvaders.MenuObjects
{
    class OptionSwitch
    {

        #region Attributs
        /// <summary>
        /// Id du paramètre
        /// </summary>
        private int _idItem;
        /// <summary>
        /// Nom du paramètre Sound ou Difficulty
        /// </summary>
        private string _name;
        /// <summary>
        /// Position sur l'axe X du nom du paramètre dans la console
        /// </summary>
        private int _posX;
        /// <summary>
        /// Position sur l'axe Y du nom du paramètre dans la console
        /// </summary>
        private int _posY;
        /// <summary>
        /// Liste string des differents options
        /// </summary>
        private List<string> _options;
        #endregion

        #region Constructeurs
        public OptionSwitch(int idItem, string name)
        {
            //Si c'est pour parametrer le son
            if (name=="Sound")
            {
                _idItem = idItem;
                _name = name;
                _options = new List<string> { "ON", "OFF" };
            }
            //Si c'est pour modifier la difficulté
            else if (name=="Difficulty")
            {
                _idItem = idItem;
                _name = name;
                _options = new List<string> { "EASY", "NORMAL", "HARD" };
            }
        }
        #endregion

        #region Methodes
        //public bool ActivateSound()
        //{
        //    if (3==2)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        public int ChangeDifficulty()
        {
            return 0;
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
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        #endregion
    }
}
