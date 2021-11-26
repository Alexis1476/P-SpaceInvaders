using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using P_SpaceInvaders.GameObjects;

namespace P_SpaceInvaders
{
    class Game
    {
        #region Constantes
        const int _INVADERSPERLINE = 4;
        const int _INVADERSPERCOLUMNS = 9;
        #endregion

        #region Attributs
        /// <summary>
        /// Carte du jeu
        /// </summary>
        Map _map;
        /// <summary>
        /// Vaisseau du joueur
        /// </summary>
        Ship _ship;
        /// <summary>
        /// Liste pour les tirs des invaders et du joueur
        /// </summary>
        List<Bullet> _bullets;
        /// <summary>
        /// Liste d'invaders
        /// </summary>
        List<Invader> _invaders;
        /// <summary>
        /// Score du joueur
        /// </summary>
        int _score;
        Random _random;
        int _timeToShoot = 0;
        #endregion

        #region Constructeurs
        public Game(int mapWidth, int mapHeight)
        {
            _map = new Map(mapWidth, mapHeight);
            _invaders = new List<Invader>();
            _bullets = new List<Bullet>();
            _ship = new Ship(this, Ship.CharShip, Map.Width / 2 - 3 / 2, Map.Height - 1); //A regler WidthChar
            _random = new Random();
            GenerateInvaders();
        }
        #endregion

        #region Methodes
        public void Update()
        {
            #region Mouvement des balles
            //Parcourt la liste de bullets
            for (int i = 0; i < Bullets.Count; i++)
            {
                //Mouvement de la balle
                Bullets[i].Move(Bullets[i].Direction);
                Bullets[i].Clear();

                //Si la balle n'est pas sortie de la map
                if (Bullets[i].IsInMap())
                {
                    //Variable bool pour vérifier l'impact de la balle
                    bool impact = false;

                    //Verifier si les balles touchent les invaders
                    for (int j = 0; j < Invaders.Count; j++)
                    {
                        //Si la balle touche un invader et si ce n'est pas une balle d'un invader
                        if (Invaders[j].IsAtCoordinates(Bullets[i].PosX, Bullets[i].PosY) && Bullets[i].Direction != Direction.Down ||
                            Invaders[j].IsAtCoordinates(Bullets[i].LastPosX, Bullets[i].LastPosY) && Bullets[i].Direction != Direction.Down)
                        {
                            //Impact reussie
                            impact = true;

                            //Effacement de la balle de l'écran et de la liste
                            Invaders[j].Delete();
                            Invaders.RemoveAt(j--);
                        }
                        //Si la balle touche le joueur
                        if (_ship != null && Ship.IsAtCoordinates(Bullets[i].PosX, Bullets[i].PosY))
                        {
                            //On met le _ship à null
                            _ship = null;
                        }
                    }

                    //Si la balle impacte contre un objet
                    if (impact)
                    {
                        //On efface la balle de la liste
                        Bullets.RemoveAt(i);
                    }
                    //Si la balle n'impacte pas
                    else
                    {
                        Bullets[i].ReDraw();
                    }
                }
                //Si la balle est sortie de la map
                else
                {
                    //Efface la balle de la liste
                    Bullets.RemoveAt(i--);
                }
            }
            #endregion

            #region Mouvement du vaisseau
            //Si le vaisseau n'est pas mort
            if (Ship != null)
            {
                //Efface le vaisseau de la position précédente
                Ship.Clear();

                //Redessine le vaisseau dans la nouvelle position
                Ship.ReDraw();
            }
            #endregion

            #region Mouvement des invaders
            //Si la liste d'invaders est déjà initialisé
            if (Invaders != null)
            {
                //Tirs des invaders
                int x = _random.Next(Invaders.Count + 1);

                //Parcourt la liste d'invaders
                foreach (Invader invader in Invaders)
                {
                    //Si le random est égal à l'id de l'invader et si timeToShoot == 20
                    if (x == invader.Id && _timeToShoot % 15 == 0)
                    {
                        //L'invader tire
                        invader.Fire();
                    }

                    //Si l'invader arrive au limite X de la map
                    if (invader.PosX == Map.Width - invader.WidthChars)
                    {
                        //Reinitialisation PosX de l'invader à 1 (Map.Offset)
                        invader.PosX = Map.Offset;

                        //Fait descendre l'invader
                        invader.Move(Direction.Down);
                    }

                    //Mouvement de l'invader vers la droite
                    invader.Move(Direction.Right);

                    //L'invader est redesinné
                    invader.Clear();
                    invader.ReDraw();
                }
                _timeToShoot++;
            }
            #endregion
        }
        /// <summary>
        /// Dessine la map et le vaisseau au centre de la fenêtre
        /// </summary>
        public void Draw()
        {
            //Dessine la map
            Map.Draw();

            //Dessine le vaisseau s'il n'est pas mort
            if (_ship != null)
            {
                Ship.Draw();
            }

            //Parcoure la liste d'invaders
            foreach (Invader invader in Invaders)
            {
                //Desinne chaque invader
                invader.Draw();
            }
        }
        public void GenerateInvaders() 
        {
            #region Agrégation des invaders dans la liste
            for (int i = 0; i < _INVADERSPERLINE * _INVADERSPERCOLUMNS; i++)
            {
                Invaders.Add(new Invader(i, this, "<<oo>>"));
            }
            #endregion

            #region Calcul Position des Invaders

            int count = 0;                  //Compteur des invaders
            int lastPosX = Map.Offset * 2;  //Dernière PosX calculé
            int lastPosY = Map.Offset * 2;  //Dernière PosY calculé

            //Parcourt la liste d'invaders
            for (int i = 0; i < Invaders.Count; i++)
            {
                //Calcul position premier invader
                if (i == 0)
                {
                    Invaders[i].PosX = lastPosX;
                    Invaders[i].PosY = lastPosY;
                }

                //Calcul des positions de tous les autres invaders
                else
                {
                    //Incrémentation de PosX des invaders (Map.Offset*2) = Espacement entre les invaders
                    lastPosX += Invaders[0].WidthChars + Map.Offset * 2;

                    //Dès qu'on arrive à la fin de la ligne
                    if (count % _INVADERSPERCOLUMNS == 0)
                    {
                        //Reinitialisation de posX et incrémentation de PosY de 2 
                        lastPosX = 2;
                        lastPosY += 2;
                    }

                    //PosX et PosY de l'invader
                    Invaders[i].PosX = lastPosX;
                    Invaders[i].PosY = lastPosY;
                }
                count++;
            }

            //LastPosX et LastPosY des invaders = PosX et posY initials
            foreach (Invader invader in Invaders)
            {
                invader.LastPosX = invader.PosX;
                invader.LastPosY = invader.PosY;
            }
            #endregion
        }
        /// <summary>
        /// Si le vaisseau est toujours en vie et s'il reste encore des invaders
        /// </summary>
        /// <returns>True si la partie continue</returns>
        public bool IsPlaying()
        {
              return Ship != null && _invaders.Count > 0;
        }
        #endregion

        #region Getteurs et setteurs
        public Map Map
        {
            get { return _map; }
            set { _map = value; }
        }
        public Ship Ship
        {
            get { return _ship; }
        }
        public List<Bullet> Bullets
        {
            get { return _bullets; }
            set { _bullets = value; }
        }
        public List<Invader> Invaders
        {
            get { return _invaders; }
            set { _invaders = value; }
        }
        #endregion

        //#region Constantes
        ///// <summary>
        ///// Frames invader Crab
        ///// </summary>
        //readonly string[] _CRABFRAMES = new string[] 
        //{
        //    //Premier frame crab
        //    "           \n" +
        //    "   ▀▄ ▄▀   \n" +
        //    "  ▄█▀█▀█▄  \n" +
        //    " █▀█████▀█ \n" +
        //    " █ █▀▀▀█ █ \n" +
        //    "   ▀▀ ▀▀    ",
        //    //Deuxieme frame crab
        //    "           \n" +
        //    " ▄ ▀▄ ▄▀ ▄ \n" +
        //    " █▄█████▄█ \n" +
        //    " ███▄█▄███ \n" +
        //    " ▀███████▀ \n" +
        //    "  ▄▀   ▀▄  "
        //};
        ///// <summary>
        ///// Frames invader Octopus
        ///// </summary>
        //readonly string[] _OCTOPUSFRAMES = new string[]
        //{
        //    //Premier frame octopus
        //    "           \n" +
        //    "  ▄▄███▄▄  \n" +
        //    " █████████ \n" +
        //    " ██▄▄█▄▄██ \n" +
        //    "  ▄▀ ▄ ▀▄  \n" +
        //    "   ▀   ▀   ",
        //    //Seconde frame octopus
        //    "           \n" +
        //    "  ▄▄███▄▄  \n" +
        //    " █████████ \n" +
        //    " ██▄▄█▄▄██ \n" +
        //    "  ▄▀ ▄ ▀▄  \n" +
        //    " ▀       ▀ "
        //};
        ///// <summary>
        ///// Frames invader Squid
        ///// </summary>
        //readonly string[] _SQUIDFRAMES = new string[]
        //{
        //    //Premier frame squid
        //    "           \n" +
        //    "    ▄█▄    \n" +
        //    "  ▄█████▄  \n" +
        //    " ███▄█▄███ \n" +
        //    "   ▄▀▄▀▄   \n" +
        //    "  ▀ ▀ ▀ ▀  ",
        //    //Deuxieme frame squid
        //    "           \n" +
        //    "    ▄█▄    \n" +
        //    "  ▄█████▄  \n" +
        //    " ███▄█▄███ \n" +
        //    "  ▄▀   ▀▄  \n" +
        //    "   ▀   ▀  "
        //};
        ///// <summary>
        ///// Frame UFO
        ///// </summary>
        //readonly string _UFO = 
        //    "               \n" +
        //    "     ▄▄█▄▄     \n" +
        //    "   ▄███████▄   \n" +
        //    " ▄██▄█▄█▄█▄██▄ \n" +
        //    "   ▀█▀ ▀ ▀█▀   ";
        //#endregion

        //#region Attributs
        //private List<Invader> _invadersList;
        //private Ship _ship;
        //private Random _random;
        //#endregion

        //#region Constructeurs
        //public Game()
        //{
        //    //Redimensionnement de la fenêtre et modif du fontSize
        //    ConsoleHelper.SetCurrentFont("Consolas", 9);
        //    Console.SetWindowSize(150, 80);
        //    _invadersList = new List<Invader>(); // Initialisation invaderList
        //    #region TEST
        //    //TESTS
        //    //for (int i = 0; i < 11; i++)
        //    //{
        //    //    Invader newInvader = new Invader(_CRABFRAMES);
        //    //    _invadersList.Add(newInvader);
        //    //}
        //    //int x = 0;
        //    //foreach(Invader invader in _invadersList)
        //    //{
        //    //    invader.DrawInvader(_SQUIDFRAMES[0], x+=12,0);
        //    //}
        //    Invader newInvader = new Invader(_CRABFRAMES);
        //    _invadersList.Add(newInvader);
        //    int y = 0, x = 0; //pos X et Y des invaders
        //    int dir = 1; //Direction des invaders
        //    for (int i = 0; ; i++)
        //    {
        //        Thread.Sleep(10);
        //        x += dir;
        //        //Si x = windowWidth - lineAlien.lenght
        //        if (x == Console.WindowWidth - 11)
        //        {
        //            dir = -1; //Inversion de la direcion
        //            y++; //Descend un pas en Y
        //        }
        //        //Si x=0 Direction positive
        //        else if (x == 0)
        //        {
        //            y++;
        //            dir = 1;
        //        }
        //        //Affichage invader
        //        if (i % 6 == 0)
        //        {
        //            _invadersList[0].DrawInvader(_SQUIDFRAMES[0], x, y); //Dessiner invader
        //        }
        //        else
        //        {
        //            _invadersList[0].DrawInvader(_SQUIDFRAMES[1], x, y); //Dessiner invader
        //        }
        //    }
        //    #endregion

        //}
        //#endregion

        //#region Methodes
        //#endregion

        //#region Getteurs et setteurs
        //#endregion

        ////Ship ship = new Ship(50, 50, 3, "-^-");

        ////public Game()
        ////{

        ////}
        ////public void InitializeGame()
        ////{
        ////    Console.Clear();
        ////    ResizeWindows();
        ////    DrawGameInfo();
        ////    ship.ShowShip();
        ////}
        ////public void DrawGameInfo()
        ////{
        ////    Console.SetCursorPosition(1, Console.WindowHeight - 3);

        ////}
        ////public void ResizeWindows()
        ////{
        ////    Console.SetWindowSize(100,50);
        ////}
    }
}
