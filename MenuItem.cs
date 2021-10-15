using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_SpaceInvaders
{
    class MenuItem
    {
        #region Attributs
        private int _idItem;
        private string _name;
        private Action _action;
        #endregion

        #region Constructors
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
        #endregion
    }
}