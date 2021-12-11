///ETML
///Auteur : Alexis Rojas
///Date : 26.11.2021
///Description: Class qui permet de creer un objet score composé de NickName et Score

namespace P_SpaceInvaders
{
    /// <summary>
    /// Crée un objet score composé de NickName et Score
    /// </summary>
    class Score
    {
        #region [Attributs]
        /// <summary>
        /// NickName du joueur
        /// </summary>
        string _nickName;
        /// <summary>
        /// Points de score
        /// </summary>
        int _scorePoints;
        #endregion

        #region [Constructeurs]
        /// <summary>
        /// Constructeur par nickname et par points de score
        /// </summary>
        /// <param name="nickname">Nickname</param>
        /// <param name="scorePoints">Score</param>
        public Score(string nickname, int scorePoints)
        {
            NickName = nickname;
            ScorePoints = scorePoints;
        }
        #endregion

        #region [Propriétés des attributs]
        /// <summary>
        /// Propriétés du membre _nickName
        /// </summary>
        public string NickName
        {
            get { return _nickName; }
            set { _nickName = value; }
        }
        /// <summary>
        /// Propriétés du membre _scorePoints
        /// </summary>
        public int ScorePoints
        {
            get { return _scorePoints; }
            set { _scorePoints = value; }
        }
        #endregion
    }
}
