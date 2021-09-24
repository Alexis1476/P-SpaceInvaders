using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_SpaceInvaders
{
    class MenuItem
    {
        private int _itemId;
        private string _text;
        private Action _action;

        /// <summary>
        /// Constructor par défaut
        /// </summary>
        public MenuItem()
        {

        }
        public MenuItem(int itemId, string text, Action action)
        {
            _itemId = itemId;
            _text = text;
            _action = action;
        }
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        public Action Action
        {
            get { return _action; }
            set { _action = value; }
        }
    }
}
