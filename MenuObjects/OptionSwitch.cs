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
        #region Constantes
        #endregion

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

        private int _index;
        bool _active;
        #endregion

        #region Constructeurs
        public OptionSwitch(int idItem, string name)
        {
            //Si c'est pour parametrer le son
            if (name == "Sound")
            {
                _idItem = idItem;
                _name = name;
                _options = new List<string> { "OFF", "ON" };
                _index = 0;
                _active = false;
            }

            //Si c'est pour modifier la difficulté
            else if (name == "Difficulty")
            {
                _idItem = idItem;
                _name = name;
                _options = new List<string> { "EASY", "NORMAL", "HARD" };
                _index = 0;
                _active = false;
            }
        }
        #endregion

        #region Methodes
        public void ChangeOption()
        {
            //L'option a été choisie
            _active = true;

            //Si c'est option de son
            if (_name == "Sound")
            {
                //Si l'index == 1 et si l'option à été activé
                if (_index == 1 && _active)
                {
                    //Reinisialisation _index et bool _active pour la valeur par défaut
                    _index = 0;
                    _active = false;
                }
                else
                {
                    //Option ON
                    _index = 1;
                    _active = true;
                }

                //Change le bool du Program.cs
                Program.Sound = _active;
            }
            //Si c'est l'option de difficulté
            else if (_name == "Difficulty")
            {
                //Si l'index == 1 et si l'option à été activé
                if (_index++ == _options.Count - 1)
                {
                    _index = 0;
                }
            }
        }
        public string NameAndOption()
        {
            string concat = _name + " [" + _options[_index] + "]\t";
            return concat; 
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
        public List<string> Options
        {
            get { return _options; }
        }
        public int Index
        {
            get { return _index; }
        }
        public bool Active
        {
            get { return _active;}
        }
        #endregion
    }
}
