///ETML
///Auteur : Alexis Rojas
///Date : 26.11.2021
///Description: Class qui permet de créer un switch pour activer le son ou un switch pour modifier la difficulté du jeu
using System.Collections.Generic;

/// <summary>
/// Objets rélatifs aux ménus
/// </summary>
namespace P_SpaceInvaders.MenuObjects
{
    /// <summary>
    /// Permet de créer un switch pour activer le son ou un switch pour modifier la difficulté du jeu
    /// </summary>
    public class MenuSwitch
    {
        #region [Attributs]
        /// <summary>
        /// Id du paramètre
        /// </summary>
        int _idItem;
        /// <summary>
        /// Nom du paramètre Sound ou Difficulty
        /// </summary>
        string _name;
        /// <summary>
        /// Position sur l'axe X du nom du paramètre dans la console
        /// </summary>
        int _posX;
        /// <summary>
        /// Position sur l'axe Y du nom du paramètre dans la console
        /// </summary>
        int _posY;
        /// <summary>
        /// Liste string des differents options
        /// </summary>
        List<string> _options;
        /// <summary>
        /// Détermine la difficulté du jeu avec un index de 0 à 2 (Facile -> Difficil)
        /// </summary>
        int _index;
        /// <summary>
        /// Détermine si l'option à été activé
        /// </summary>
        bool _active;
        #endregion

        #region [Constructeurs]
        /// <summary>
        /// Constructeur par id et par nom (Sound ou Difficulty)
        /// </summary>
        /// <param name="idItem">Id de l'item</param>
        /// <param name="name">"Sound" || "Difficulty"</param>
        public MenuSwitch(int idItem, string name)
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

        #region [Methodes]
        /// <summary>
        /// Change l'option du switch
        /// </summary>
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
        /// <summary>
        /// Retourne le nom du switch + le nom de l'option choisie
        /// </summary>
        /// <returns>Retourne concat de SwitchName+[OptionName]</returns>
        public string NameAndOption()
        {
            string concat = _name + " [" + _options[_index] + "]\t";
            return concat;
        }
        #endregion

        #region [Propriétés des attributs]
        /// <summary>
        /// Propriétés membre _posX
        /// </summary>
        public int PosX
        {
            get { return _posX; }
            set { _posX = value; }
        }
        /// <summary>
        /// Propriétés membre _posY
        /// </summary>
        public int PosY
        {
            get { return _posY; }
            set { _posY = value; }
        }
        /// <summary>
        /// Propriétés membre _name
        /// </summary>
        public string Name
        {
            get { return _name; }
        }
        /// <summary>
        /// Propriétés membre _index
        /// </summary>
        public int Index
        {
            get { return _index; }
        }
        /// <summary>
        /// Propriétés membre _active
        /// </summary>
        public bool Active
        {
            get { return _active; }
        }
        #endregion
    }
}