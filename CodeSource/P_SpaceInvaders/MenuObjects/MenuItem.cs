///ETML
///Auteur : Alexis Rojas
///Date : 26.11.2021
///Description: Class qui permet de créer une option d'un ménu laquelle exécute une action
using System;

namespace P_SpaceInvaders.MenuObjects
{
    /// <summary>
    /// Permet de créer une option d'un ménu laquelle exécute une action
    /// </summary>
    public class MenuItem
    {
        #region [Attributs]
        /// <summary>
        /// Identifiant de l'option
        /// </summary>
        int _idItem;
        /// <summary>
        /// Nom de l'option
        /// </summary>
        string _name;
        /// <summary>
        /// Function de l'option
        /// </summary>
        Action _action;
        /// <summary>
        /// Position sur l'axe X de l'option dans la console
        /// </summary>
        int _posX;
        /// <summary>
        /// Position sur l'axe Y de l'option dans la console
        /// </summary>
        int _posY;
        #endregion

        #region [Constructeurs]
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

        #region [Propriétés des attributs]
        /// <summary>
        /// Propriété membre _name
        /// </summary>
        public string NameItem
        {
            get { return _name; }
        }
        /// <summary>
        /// Propriété membre _posX
        /// </summary>
        public int PosX
        {
            get { return _posX; }
            set { _posX = value; }
        }
        /// <summary>
        /// Propriété membre _posY
        /// </summary>
        public int PosY
        {
            get { return _posY; }
            set { _posY = value; }
        }
        /// <summary>
        /// Propriété membre _action
        /// </summary>
        public Action Action
        {
            get { return _action; }
        }
        #endregion
    }
}