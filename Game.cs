///ETML
///Auteur : Alexis Rojas
///Date : 26.11.2021
///Description: Gérè le jeu et les rélations entre chaque objet
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using P_SpaceInvaders.GameObjects;

namespace P_SpaceInvaders
{
    class Game
    {
        #region Constantes
        /// <summary>
        /// Invaders par ligne
        /// </summary>
        const int _INVADERSPERLINE = 1;
        /// <summary>
        /// Invaders par colonne
        /// </summary>
        const int _INVADERSPERCOLUMNS = 4;
        public readonly int SHIPLIFES = 3;
        #endregion

        #region Attributs
        /// <summary>
        /// Carte du jeu
        /// </summary>
        Map _map;
        /// <summary>
        /// Vaisseau du joueur
        /// </summary>
        static Ship _ship;
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
        /// <summary>
        /// Random pour sélectionner un invader qui tire
        /// </summary>
        Random _random;
        /// <summary>
        /// Détermine le temps pour les tirs des invaders
        /// </summary>
        int _timeToShoot;
        /// <summary>
        /// Fréquence de tir des invaders
        /// </summary>
        int _difficulty;
        /// <summary>
        /// Détermine si le joueur peut tirer
        /// </summary>
        static bool _shoot;
        /// <summary>
        /// Son de tir
        /// </summary>
        static SoundPlayer _shotSound;
        /// <summary>
        /// Son quand un invader est impacté
        /// </summary>
        static SoundPlayer _explosionSound;
        /// <summary>
        /// Son quand le joueur mort
        /// </summary>
        static SoundPlayer _deathSound;
        /// <summary>
        /// Timer qui détermine le moment pour tirer
        /// </summary>
        static System.Timers.Timer _timerToShoot;
        #endregion

        #region Constructeurs
        public Game(int mapWidth, int mapHeight, int difficulty)
        {
            _map = new Map(mapWidth, mapHeight);
            _invaders = new List<Invader>();
            _bullets = new List<Bullet>();
            _ship = new Ship(this, Ship.CharShip, SHIPLIFES);
            _random = new Random();
            _difficulty = difficulty;
            ShipSpawnPos();
            GenerateInvaders();

            #region Effets audio
            _shotSound = new SoundPlayer(".\\Ressources\\laserShoot.wav");
            _explosionSound = new SoundPlayer(".\\Ressources\\hitInvader.wav");
            _deathSound = new SoundPlayer(".\\Ressources\\hitShip.wav");
            #endregion

            #region Paramètres du Timer
            _timerToShoot = new System.Timers.Timer(800);
            _timerToShoot.Elapsed += OnTimedEvent;
            _timerToShoot.AutoReset = true;
            _timerToShoot.Enabled = true;
            #endregion
        }
        #endregion

        #region Methodes

        public void ReadInput()
        {
            //Tant que le vaisseau existe et que le joueur tape une touche de mouvement
            while (_ship != null && Console.KeyAvailable)
            {    
                //Switch pour la séléction du mouvement et pour le tir
                switch (Console.ReadKey().Key)
                {
                    //Pause
                    case ConsoleKey.P:
                        //Pause active
                        bool pause = true;

                        //tant que la variable pause ne soit pas en false
                        while (pause)
                        {
                            //Si l'utilisateur tape encore sur la touche P
                            if (ConsoleKey.P == Console.ReadKey().Key)
                            {
                                pause = false;
                            }
                        }
                        break;

                    //Mouvement vers la gauche
                    case ConsoleKey.LeftArrow:
                        _ship.Move(Direction.Left);
                        break;

                    //Mouvement vers la droite
                    case ConsoleKey.RightArrow:
                        _ship.Move(Direction.Right);
                        break;

                    //Tir
                    case ConsoleKey.Spacebar:
                        //Si le joueur a le droit de tirer
                        if (_shoot)
                        {
                            //Réproduit l'effet de son
                            Program.PlaySound(_shotSound);

                            //Le vaisseau tire
                            _ship.Fire();
                            
                            //Le vaisseai ne peut plus tirer
                            _shoot = false;
                        }
                        break;

                    //Si l'utilisateur tape sur une autre touche
                    default:
                        break;
                }
            }
        }
        public void ShipSpawnPos()
        {
            InitPosShip();
            _ship.LastPosX = _ship.PosX;
            _ship.LastPosY = _ship.PosY;
        }
        public void InitPosShip()
        {
            //Taille de la carte / 2 - largeur du vaisseau / 2 pour le centrer
            _ship.PosX = Map.Width / 2 - _ship.WidthChars / 2;
            _ship.PosY = Map.Height + Map.Offset - _ship.HeightChars;
        }
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
                    //Variable bool pour vérifier l'impact de la balle contre le joueur
                    bool impact = false;

                    //Verifier si les balles touchent les invaders
                    for (int j = 0; j < Invaders.Count; j++)
                    {
                        //Si la balle touche un invader et si ce n'est pas une balle d'un invader
                        if (Invaders[j].IsAtCoordinates(Bullets[i].PosX, Bullets[i].PosY) && Bullets[i].Direction != Direction.Down ||
                            Invaders[j].IsAtCoordinates(Bullets[i].LastPosX, Bullets[i].LastPosY) && Bullets[i].Direction != Direction.Down)
                        {
                            //On efface la balle de la liste
                            Bullets.RemoveAt(i); 

                            //Réproduit l'effet de son
                            Program.PlaySound(_explosionSound);

                            //Effacement de l'invader de l'écran et de la liste
                            Invaders[j].Delete();
                            Invaders.RemoveAt(j--);

                            //Augmentation du score
                            _score += 20;
                        }

                        //Si la balle n'impacte pas
                        else
                        {
                            Bullets[i].ReDraw();
                        }

                        //Si la balle touche le joueur
                        if (_ship != null && Ship.IsAtCoordinates(Bullets[i].PosX, Bullets[i].PosY))
                        {
                            //Efface la balle de la liste
                            Bullets.RemoveAt(i);

                            impact = true;
                        }
                    }

                    //Si la balle impacte contre le joueur
                    if (impact)
                    {
                        //Réproduit l'effet de son
                        Program.PlaySound(_deathSound);

                        //Si la décrémentation des lives du joueur == 0
                        if (--_ship.Lives == 0)
                        {
                            //On supprime le vaisseau
                            _ship = null;
                        }
                        else
                        {
                            InitPosShip();
                        }
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
                int idRandom = _random.Next(Invaders.Count);

                //Parcourt la liste d'invaders
                foreach (Invader invader in Invaders)
                {
                    //Si le random est égal à l'id de l'invader et si timeToShoot est multiple de 15
                    if (invader.Id == idRandom && _timeToShoot % _difficulty == 0)
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

            //Met à jour les ids des invaders
            UpdateIdFromInvaders();
            #endregion
        }
        /// <summary>
        /// Met à jour l'ID de chaque invader
        /// </summary>
        public void UpdateIdFromInvaders()
        {
            for (int i = 0; i < Invaders.Count; i++)
            {
                Invaders[i].Id = i;
            }
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
        /// <summary>
        /// Initialise la liste d'invaders et calcule leur position
        /// </summary>
        public void GenerateInvaders() 
        {
            #region Agrégation des invaders dans la liste
            for (int i = 0; i < _INVADERSPERLINE * _INVADERSPERCOLUMNS; i++)
            {
                Invaders.Add(new Invader(i, this, Invader.OCTOPUS));
            }
            #endregion

            #region Calcul Position des Invaders
            //Compteur des invaders
            int count = 0;

            //Dernière PosX calculé
            int lastPosX = Map.Offset * 2;

            //Dernière PosY calculé
            int lastPosY = Map.Offset * 2;  

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
                        lastPosY += Invaders[i].HeightChars;
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
        /// <summary>
        /// Permet au joueur de tirer quand le timer arrive aux millisecondes spécifiés
        /// </summary>
        /// <param name="source">Objet timer</param>
        /// <param name="e">Fournit les données pour l'événement</param>
        static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            _shoot = true;
        }
        #endregion

        #region Getteurs et setteurs
        /// <summary>
        /// Propriétés membre _map
        /// </summary>
        public Map Map
        {
            get { return _map; }
            set { _map = value; }
        }
        /// <summary>
        /// Propriétés membre _ship
        /// </summary>
        public Ship Ship
        {
            get { return _ship; }
        }
        /// <summary>
        /// Propriétés membre _bullets
        /// </summary>
        public List<Bullet> Bullets
        {
            get { return _bullets; }
            set { _bullets = value; }
        }
        /// <summary>
        /// Propriétés membre _invaders
        /// </summary>
        public List<Invader> Invaders
        {
            get { return _invaders; }
            set { _invaders = value; }
        }
        /// <summary>
        /// Propriétés membre _score
        /// </summary>
        public int Score
        {
            get { return _score; }
        }
        #endregion
    }
}
