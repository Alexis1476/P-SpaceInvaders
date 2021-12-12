///ETML
///Auteur : Alexis Rojas
///Date : 26.11.2021
///Description: Gérè le jeu et les rélations entre chaque objet
using P_SpaceInvaders.GameObjects;
using System;
using System.Collections.Generic;
using System.Media;
using System.Timers;

namespace P_SpaceInvaders
{
    /// <summary>
    /// Gère le temps et les rélations entre les objets du jeu
    /// </summary>
    public class Game
    {
        #region [Constantes]
        /// <summary>
        /// Invaders par ligne
        /// </summary>
        const int _INVADERSPERLINE = 4;
        /// <summary>
        /// Invaders par colonne
        /// </summary>
        const int _INVADERSPERCOLUMNS = 9;
        /// <summary>
        /// Vies du joueur
        /// </summary>
        public readonly int SHIPLIFES = 3;
        /// <summary>
        /// Temps en millisecondes pour permettre au vaisseau de tirer
        /// </summary>
        const int _TIMETOSHOOT = 1000;
        /// <summary>
        /// Temps en millisecondes pour le déplacement des invaders
        /// </summary>
        const int _TIMETOMOVEINVADER = 200;
        /// <summary>
        /// Nombre de boucliers
        /// </summary>
        const int _NBSHIELDS = 6;
        /// <summary>
        /// Colonnes des boucliers
        /// </summary>
        const int _WIDTHSHIELDS = 10;
        /// <summary>
        /// Lignes de boucliers
        /// </summary>
        const int _HEIGHTSHIELDS = 2;
        #endregion

        #region [Attributs]
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
        /// Détermine si les invaders peuvent se déplacer
        /// </summary>
        static bool _moveInvader;
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
        Timer _timerToShoot;
        /// <summary>
        /// Timer qui détermine le moment pour déplacer l'essaim d'invaders
        /// </summary>
        Timer _timerToMoveInvader;
        /// <summary>
        /// Compteur d'invaders tués / Si le joueur meurt _combo se reinitialise
        /// </summary>
        int _combo;
        /// <summary>
        /// Liste de boucliers (Chaque caractère est un bouclier)
        /// </summary>
        List<Shield> _shields;
        #endregion

        #region [Constructeurs]
        /// <summary>
        /// Constructeur par hauteur, largeur de la fenêtre et difficulté
        /// </summary>
        /// <param name="mapWidth">Largeur de la fenêtre</param>
        /// <param name="mapHeight">Hauteur de la fenêtre</param>
        /// <param name="difficulty">Difficulté</param>
        public Game(int mapWidth, int mapHeight, int difficulty)
        {
            _map = new Map(mapWidth, mapHeight);
            _invaders = new List<Invader>();
            _bullets = new List<Bullet>();
            _ship = new Ship(this, CharsASCII.CHARSHIP, SHIPLIFES);
            _random = new Random();
            _shields = new List<Shield>();
            _difficulty = difficulty;
            _combo = 1;

            //Initialise la position du vaisseau
            ShipSpawnPos();

            //Génère les invaders
            GenerateInvaders();

            //Génère les boucliers
            GenerateShields();

            #region [Effets audio]
            _shotSound = new SoundPlayer(".\\Ressources\\laserShoot.wav");
            _explosionSound = new SoundPlayer(".\\Ressources\\hitInvader.wav");
            _deathSound = new SoundPlayer(".\\Ressources\\hitShip.wav");
            #endregion

            #region Paramètres du Timer
            _timerToShoot = new Timer(_TIMETOSHOOT);
            _timerToShoot.Elapsed += OnTimedEvent;
            _timerToShoot.AutoReset = true;
            _timerToShoot.Enabled = true;
            #endregion

            #region [Paramètres du timer mouveInvader]
            _timerToMoveInvader = new Timer(_TIMETOMOVEINVADER);
            _timerToMoveInvader.Elapsed += OnTimedEventMoveInvader;
            _timerToMoveInvader.AutoReset = true;
            _timerToMoveInvader.Enabled = true;
            #endregion
        }
        #endregion

        #region [Methodes]
        /// <summary>
        /// Lit ce que le joueur tape au clavier
        /// </summary>
        public void ReadInput()
        {
            //Tant que le vaisseau existe et que le joueur tape sur une touche de mouvement
            while (_ship != null && Console.KeyAvailable)
            {
                //Switch pour la séléction du mouvement et pour le tir
                switch (Console.ReadKey().Key)
                {
                    //Pause
                    case ConsoleKey.Escape:
                        //Pause active
                        bool pause = true;

                        //Arret des timers
                        _timerToMoveInvader.Stop();
                        _timerToShoot.Stop();

                        //Tant que la variable pause ne soit pas en false
                        while (pause)
                        {
                            //Switch pour lire les touches
                            switch (Console.ReadKey(false).Key)
                            {
                                //Retour au ménu principal
                                case ConsoleKey.Escape:
                                    {
                                        //Affiche le ménu principal
                                        Program.MainMenu.DrawAllMenu();
                                        break;
                                    }
                                //Retour à la partie
                                case ConsoleKey.Spacebar:
                                    {
                                        //Quitte la pause
                                        pause = false;

                                        //Reinitialise les timers
                                        _timerToMoveInvader.Start();
                                        _timerToShoot.Start();
                                        break;
                                    }
                            }
                        }
                        break;
                    //Mouvement vers la gauche
                    case ConsoleKey.LeftArrow:
                        {
                            _ship.Move(Direction.Left);
                            break;
                        }
                    //Mouvement vers la droite
                    case ConsoleKey.RightArrow:
                        {
                            _ship.Move(Direction.Right);
                            break;
                        }
                    //Tir
                    case ConsoleKey.Spacebar:
                        {
                            //Si le joueur a le droit de tirer
                            if (_shoot)
                            {
                                //Réproduit l'effet de son
                                Program.PlaySound(_shotSound);

                                //Le vaisseau tire
                                _ship.Fire();

                                //Le vaisseau ne peut plus tirer
                                _shoot = false;
                            }
                            break;
                        }
                    //Si l'utilisateur tape sur une autre touche
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// Initialise la position du vaisseau lors du lancement d'une partie
        /// </summary>
        public void ShipSpawnPos()
        {
            InitPosShip();
            _ship.LastPosX = _ship.PosX;
            _ship.LastPosY = _ship.PosY;
        }
        /// <summary>
        /// Initialise la position du vaisseau au centre de la map lorsqu'il meurt
        /// </summary>
        public void InitPosShip()
        {
            //Taille de la carte / 2 - largeur du vaisseau / 2 pour le centrer
            _ship.PosX = Map.Width / 2 - _ship.WidthChars / 2;
            _ship.PosY = Map.Height + Map.Offset - _ship.HeightChars;
        }
        /// <summary>
        /// Met à jour les positions des objets du jeu
        /// </summary>
        public void Update()
        {
            //Met à jour les positions des balles
            UpdateBullets();

            //Met à jour la position du vaisseau
            UpdateShip();

            //Met à jour les positions des invaders
            UpdateInvaders();
        }
        /// <summary>
        /// Met à jour les positions des invaders
        /// </summary>
        public void UpdateInvaders()
        {
            //Si la liste d'invaders est déjà initialisé
            if (Invaders != null && _moveInvader)
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
                _moveInvader = false;
                _timeToShoot++;
            }

            //Met à jour les ids des invaders
            UpdateIdFromInvaders();
        }
        /// <summary>
        /// Met à jour la position du vaisseau
        /// </summary>
        public void UpdateShip()
        {
            //Si le vaisseau n'est pas mort
            if (Ship != null)
            {
                //Efface le vaisseau de la position précédente
                Ship.Clear();

                //Redessine le vaisseau dans la nouvelle position
                Ship.ReDraw();
            }
        }
        /// <summary>
        /// Met à jour la liste de balles
        /// </summary>
        public void UpdateBullets()
        {
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
                    bool impactInvader = false;
                    bool impactShield = false;

                    //Verifier si la balle impacte un bouclier
                    for (int k = 0; k < _shields.Count; k++)
                    {
                        //Si la balle touche le bouclier
                        if (_shields[k].IsAtCoordinates(Bullets[i].PosX, Bullets[i].PosY) || _shields[k].IsAtCoordinates(Bullets[i].LastPosX, Bullets[i].LastPosY))
                        {
                            //Efface le bouclier de la liste et de l'écran
                            _shields[k].Delete();
                            _shields.RemoveAt(k--);
                            impactShield = true;

                            //Effacement de la balle de l'écran
                            Bullets[i].Delete();
                        }
                    }
                    //Verifier si les balles touchent les invaders
                    for (int j = 0; j < Invaders.Count; j++)
                    {
                        //S'il y a au moins une balle
                        if (_bullets.Count != 0)
                        {
                            //Si la balle touche un invader et si ce n'est pas une balle d'un invader
                            if (Invaders[j].IsAtCoordinates(Bullets[i].PosX, Bullets[i].PosY) && Bullets[i].Direction != Direction.Down ||
                                Invaders[j].IsAtCoordinates(Bullets[i].LastPosX, Bullets[i].LastPosY) && Bullets[i].Direction != Direction.Down)
                            {
                                //Réproduit l'effet de son
                                Program.PlaySound(_explosionSound);

                                //La balle impacte un invader
                                impactInvader = true;

                                //Effacement de la balle de l'écran
                                Bullets[i].Delete();

                                //Effacement de l'invader de l'écran et de la liste
                                Invaders[j].Delete();
                                Invaders.RemoveAt(j--);
                            }
                            //Si la balle touche le joueur
                            else if (_ship != null && Ship.IsAtCoordinates(Bullets[i].PosX, Bullets[i].PosY))
                            {
                                //Impact à true
                                impact = true;

                                //Supprime la balle de la liste
                                Bullets.RemoveAt(i);

                                //Réproduit l'effet de son
                                Program.PlaySound(_deathSound);
                            }
                            //Si la balle n'impacte pas
                            else if (!impactInvader && !impact && !impactShield)
                            {
                                Bullets[i].ReDraw();
                            }
                        }
                    }
                    //Si la balle impacte un invader
                    if (impactInvader)
                    {
                        //On efface la balle de la liste
                        Bullets.RemoveAt(i--);

                        //Incrémentation du score
                        _score += (20 * _combo++);
                    }
                    //Si la balle impacte le joueur
                    else if (impact)
                    {
                        //Si la décrémentation des lives du joueur == 0
                        if (--_ship.Lives == 0)
                        {
                            //Supprime le vaisseau
                            _ship = null;
                        }
                        else
                        {
                            InitPosShip();

                            //Reinitialisation du combo
                            _combo = 1;
                        }
                    }
                    else if (impactShield)
                    {
                        //On efface la balle de la liste
                        Bullets.RemoveAt(i--);
                    }
                }
                //Si la balle est sortie de la map
                else
                {
                    //Efface la balle de la liste
                    Bullets.RemoveAt(i--);
                }
            }
        }
        /// <summary>
        /// Met à jour l'ID de chaque invader
        /// </summary>
        public void UpdateIdFromInvaders()
        {
            //Parcourt la liste d'invaders
            for (int i = 0; i < Invaders.Count; i++)
            {
                //Actualise l'ID
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

            //Parcourt la liste d'invaders
            foreach (Invader invader in Invaders)
            {
                //Desinne chaque invader
                invader.Draw();
            }

            //Parcourt la liste de bouciers
            foreach (Shield shield in _shields)
            {
                shield.Draw();
            }
        }
        /// <summary>
        /// Génère les boucliers et calcule leur position
        /// </summary>
        public void GenerateShields()
        {
            //Agrégation des boucliers à la liste
            for (int i = 0; i < _NBSHIELDS * _WIDTHSHIELDS * _HEIGHTSHIELDS; i++)
            {
                _shields.Add(new Shield(this, "█"));
            }

            //Positions initials
            int startPosX = Map.Width / _NBSHIELDS;
            int startPosY = Map.Height - Ship.HeightChars * 2;

            //Calcul espaces entre les boucliers
            int rangeShield = Map.Width - startPosX * 2;
            int spaceBetween = (rangeShield - _NBSHIELDS * _WIDTHSHIELDS) / (_NBSHIELDS - 1);

            //Position du premier bouclier
            _shields[0].PosX = startPosX;
            _shields[0].PosY = startPosY;

            //Variables pour le calcul des coordonées
            int posX = startPosX;
            int posY = startPosY;

            //Calcul positions des boucliers
            for (int i = 1; i < _shields.Count; i++)
            {
                //Si i arrive à la lareur d'un bouclier
                if (i % _WIDTHSHIELDS == 0)
                {
                    posX += spaceBetween;
                }
                //Dès que la boucle fait une ligne de boucliers
                if (i % (_NBSHIELDS * _WIDTHSHIELDS) == 0)
                {
                    //Incrémente la position en Y
                    posY++;

                    //Réinitialise las position en X
                    posX = startPosX - 1;
                }
                _shields[i].PosX = ++posX;
                _shields[i].PosY = posY;
            }
        }
        /// <summary>
        /// Initialise la liste d'invaders et calcule leur position
        /// </summary>
        public void GenerateInvaders()
        {
            #region [Agrégation des invaders à la liste]
            //Pour i jusqu'a invaders par ligne * invaders par collones
            for (int i = 0; i < _INVADERSPERLINE * _INVADERSPERCOLUMNS; i++)
            {
                //Première ligne d'invaders
                if (i < _INVADERSPERCOLUMNS)
                {
                    Invaders.Add(new Invader(i, this, CharsASCII.OCTOPUS));
                }
                //Deuxième ligne d'invaders
                else if (i >= _INVADERSPERCOLUMNS && i < _INVADERSPERCOLUMNS * 2)
                {
                    Invaders.Add(new Invader(i, this, CharsASCII.SQUID));
                }
                //Dernières lignes
                else
                {
                    Invaders.Add(new Invader(i, this, CharsASCII.CRAB));
                }
            }
            #endregion

            #region [Calcul Position des Invaders]
            //Compteur des invaders
            int count = 0;

            //Dernière PosX calculé
            int lastPosX = Map.Offset * 2;

            //Dernière PosY calculé
            int lastPosY = Map.Offset * Invaders[0].HeightChars;

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
            //Si l'invader n'est pas mort et s'il reste des invaders vivants
            if (Ship != null && _invaders.Count > 0)
            {
                return true;
            }
            else
            {
                //Arret des timers
                _timerToMoveInvader.Stop();
                _timerToShoot.Stop();
                return false;
            }
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
        /// <summary>
        /// Evènement qui permet de faire bouger les invaders chaque n millisecondes
        /// </summary>
        /// <param name="source">Objet timer</param>
        /// <param name="e">Fournit les données pour l'événement</param>
        static void OnTimedEventMoveInvader(Object source, ElapsedEventArgs e)
        {
            _moveInvader = true;
        }
        #endregion

        #region [Propriétés des attributs]
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