///ETML
///Auteur : Alexis Rojas
///Date : 26.11.2021
///Description: Class qui permet de créer une option d'un ménu laquelle exécute une action
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_SpaceInvaders.MenuObjects
{
    class MenuItem
    {
        #region Attributs
        /// <summary>
        /// Identifiant de l'option
        /// </summary>
        private int _idItem;
        /// <summary>
        /// Nom de l'option
        /// </summary>
        private string _name;
        /// <summary>
        /// Function de l'option
        /// </summary>
        private Action _action;
        /// <summary>
        /// Position sur l'axe X de l'option dans la console
        /// </summary>
        private int _posX;
        /// <summary>
        /// Position sur l'axe Y de l'option dans la console
        /// </summary>
        private int _posY;
        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructor par texte et action de l'option
        /// </summary>
        /// <param name="name">Nom de l'option</param>
        /// <param name="action">Function de l'option</param>
        public MenuItem(string name, Action action)
        {
            _name = name;
            _action = action;
        }
        /// <summary>
        /// Constructor par Id, nom et action de l'option
        /// </summary>
        /// <param name="idItem">Identifiant de l'option</param>
        /// <param name="name">Nom de l'option</param>
        /// <param name="action">Function de l'option</param>
        public MenuItem(int idItem, string name, Action action)
        {
            _idItem = idItem;
            _name = name;
            _action = action;
        }
        #endregion

        #region Getteurs et setteurs
        public string NameItem
        {
            get { return _name; }
        }
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
        public Action Action
        {
            get { return _action; }
        }
        #endregion
    }
}