using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_SpaceInvaders
{
    class MovingObject : GameObject
    {
        #region Attributs
        private int _lastPosX;
        private int _lastPosY;
        #endregion

        #region Constructors
        public MovingObject(Game game, string chars, int x, int y) : base(game, chars, x, y)
        {
            _lastPosX = x;
            _lastPosY = y;
        }
        #endregion

        #region Getteurs et setteurs
        public int LastPosX
        {
            get { return _lastPosX; }
            set { _lastPosX = value; }
        }
        public int LastPosY
        {
            get { return _lastPosY; }
            set { _lastPosY = value; }
        }
        #endregion

        #region Methodes
        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    PosX--;
                    break;
                case Direction.Right:
                    PosX++;
                    break;
                case Direction.Up:
                    PosY--;
                    break;
                case Direction.Down:
                    PosY++;
                    break;
            }
        }
        #endregion

    }
}
