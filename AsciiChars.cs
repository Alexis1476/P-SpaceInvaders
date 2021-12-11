///ETML
///Auteur : Alexis Rojas
///Date : 26.11.2021
///Description: Class qui contient tous les chaines de caractères et les frames qui répresentent les objets du jeu

namespace P_SpaceInvaders
{
    /// <summary>
    /// Contient tous les chaines de caractères et les frames qui répresentent les objets du jeu
    /// </summary>
    public static class AsciiChars
    {
        #region [Titres]
        /// <summary>
        /// Titre ménu principal
        /// </summary>
        public const string MAINTITLE = 
            "                                                                                                                 \n" +
            "  ██████  ██▓███   ▄▄▄       ▄████▄  ▓█████     ██▓ ███▄    █ ██▒   █▓ ▄▄▄      ▓█████▄ ▓█████  ██▀███    ██████ \n" +
            "▒██    ▒ ▓██░  ██▒▒████▄    ▒██▀ ▀█  ▓█   ▀    ▓██▒ ██ ▀█   █▓██░   █▒▒████▄    ▒██▀ ██▌▓█   ▀ ▓██ ▒ ██▒▒██    ▒ \n" +
            "░ ▓██▄   ▓██░ ██▓▒▒██  ▀█▄  ▒▓█    ▄ ▒███      ▒██▒▓██  ▀█ ██▒▓██  █▒░▒██  ▀█▄  ░██   █▌▒███   ▓██ ░▄█ ▒░ ▓██▄   \n" +
            "  ▒   ██▒▒██▄█▓▒ ▒░██▄▄▄▄██ ▒▓▓▄ ▄██▒▒▓█  ▄    ░██░▓██▒  ▐▌██▒ ▒██ █░░░██▄▄▄▄██ ░▓█▄   ▌▒▓█  ▄ ▒██▀▀█▄    ▒   ██▒\n" +
            "▒██████▒▒▒██▒ ░  ░ ▓█   ▓██▒▒ ▓███▀ ░░▒████▒   ░██░▒██░   ▓██░  ▒▀█░   ▓█   ▓██▒░▒████▓ ░▒████▒░██▓ ▒██▒▒██████▒▒\n" +
            "▒ ▒▓▒ ▒ ░▒▓▒░ ░  ░ ▒▒   ▓▒█░░ ░▒ ▒  ░░░ ▒░ ░   ░▓  ░ ▒░   ▒ ▒   ░ ▐░   ▒▒   ▓▒█░ ▒▒▓  ▒ ░░ ▒░ ░░ ▒▓ ░▒▓░▒ ▒▓▒ ▒ ░\n" +
            "░ ░▒  ░ ░░▒ ░       ▒   ▒▒ ░  ░  ▒    ░ ░  ░    ▒ ░░ ░░   ░ ▒░  ░ ░░    ▒   ▒▒ ░ ░ ▒  ▒  ░ ░  ░  ░▒ ░ ▒░░ ░▒  ░ ░\n" +
            "░  ░  ░  ░░         ░   ▒   ░           ░       ▒ ░   ░   ░ ░     ░░    ░   ▒    ░ ░  ░    ░     ░░   ░ ░  ░  ░  \n" +
            "      ░                 ░  ░░ ░         ░  ░    ░           ░      ░        ░  ░   ░       ░  ░   ░           ░  \n" +
            "                            ░                                     ░              ░                               \n\n";
        /// <summary>
        /// Titre ménu d'options
        /// </summary>
        public const string TITLEOPTIONS = 
            "                                                            \n" +
            " ▒█████   ██▓███  ▄▄▄█████▓ ██▓ ▒█████   ███▄    █   ██████ \n" +
            "▒██▒  ██▒▓██░  ██▒▓  ██▒ ▓▒▓██▒▒██▒  ██▒ ██ ▀█   █ ▒██    ▒ \n" +
            "▒██░  ██▒▓██░ ██▓▒▒ ▓██░ ▒░▒██▒▒██░  ██▒▓██  ▀█ ██▒░ ▓██▄   \n" +
            "▒██   ██░▒██▄█▓▒ ▒░ ▓██▓ ░ ░██░▒██   ██░▓██▒  ▐▌██▒  ▒   ██▒\n" +
            "░ ████▓▒░▒██▒ ░  ░  ▒██▒ ░ ░██░░ ████▓▒░▒██░   ▓██░▒██████▒▒\n" +
            "░ ▒░▒░▒░ ▒▓▒░ ░  ░  ▒ ░░   ░▓  ░ ▒░▒░▒░ ░ ▒░   ▒ ▒ ▒ ▒▓▒ ▒ ░\n" +
            "  ░ ▒ ▒░ ░▒ ░         ░     ▒ ░  ░ ▒ ▒░ ░ ░░   ░ ▒░░ ░▒  ░ ░\n" +
            "░ ░ ░ ▒  ░░         ░       ▒ ░░ ░ ░ ▒     ░   ░ ░ ░  ░  ░  \n" +
            "    ░ ░                     ░      ░ ░           ░       ░  \n\n";
        /// <summary>
        /// Titre scores
        /// </summary>
        public const string TITLESCORE =
            "                                                                       \n" +
            " ██░ ██  ██▓  ▄████  ██░ ██   ██████  ▄████▄   ▒█████   ██▀███  ▓█████ \n" +
            "▓██░ ██▒▓██▒ ██▒ ▀█▒▓██░ ██▒▒██    ▒ ▒██▀ ▀█  ▒██▒  ██▒▓██ ▒ ██▒▓█   ▀ \n" +
            "▒██▀▀██░▒██▒▒██░▄▄▄░▒██▀▀██░░ ▓██▄   ▒▓█    ▄ ▒██░  ██▒▓██ ░▄█ ▒▒███   \n" +
            "░▓█ ░██ ░██░░▓█  ██▓░▓█ ░██   ▒   ██▒▒▓▓▄ ▄██▒▒██   ██░▒██▀▀█▄  ▒▓█  ▄ \n" +
            "░▓█▒░██▓░██░░▒▓███▀▒░▓█▒░██▓▒██████▒▒▒ ▓███▀ ░░ ████▓▒░░██▓ ▒██▒░▒████ \n" +
            " ▒ ░░▒░▒░▓   ░▒   ▒  ▒ ░░▒░▒▒ ▒▓▒ ▒ ░░ ░▒ ▒  ░░ ▒░▒░▒░ ░ ▒▓ ░▒▓░░░ ▒░ ░\n" +
            " ▒ ░▒░ ░ ▒ ░  ░   ░  ▒ ░▒░ ░░ ░▒  ░ ░  ░  ▒     ░ ▒ ▒░   ░▒ ░ ▒░ ░ ░  ░\n" +
            " ░  ░░ ░ ▒ ░░ ░   ░  ░  ░░ ░░  ░  ░  ░        ░ ░ ░ ▒    ░░   ░    ░   \n" +
            " ░  ░  ░ ░        ░  ░  ░  ░      ░  ░ ░          ░ ░     ░        ░  ░\n\n";
        /// <summary>
        /// Titre à propos de
        /// </summary>
        public const string TITLEABOUT = 
            "                                             \n" +
            " ▄▄▄       ▄▄▄▄    ▒█████   █    ██ ▄▄▄█████▓\n" +
            "▒████▄    ▓█████▄ ▒██▒  ██▒ ██  ▓██▒▓  ██▒ ▓▒\n" +
            "▒██  ▀█▄  ▒██▒ ▄██▒██░  ██▒▓██  ▒██░▒ ▓██░ ▒░\n" +
            "░██▄▄▄▄██ ▒██░█▀  ▒██   ██░▓▓█  ░██░░ ▓██▓ ░ \n" +
            " ▓█   ▓██▒░▓█  ▀█▓░ ████▓▒░▒▒█████▓   ▒██▒ ░ \n" +
            " ▒▒   ▓▒█░░▒▓███▀▒░ ▒░▒░▒░ ░▒▓▒ ▒ ▒   ▒ ░░   \n" +
            "  ▒   ▒▒ ░▒░▒   ░   ░ ▒ ▒░ ░░▒░ ░ ░     ░    \n" +
            "  ░   ▒    ░    ░ ░ ░ ░ ▒   ░░░ ░ ░   ░      \n" +
            "      ░  ░ ░          ░ ░     ░              \n\n";
        /// <summary>
        /// Titre gameOver
        /// </summary>
        public const string TITLEGAMEOVER = 
            "                                                                         \n" +
            "  ▄████  ▄▄▄       ███▄ ▄███▓▓█████     ▒█████   ██▒   █▓▓█████  ██▀███  \n" +
            " ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀    ▒██▒  ██▒▓██░   █▒▓█   ▀ ▓██ ▒ ██▒\n" +
            "▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███      ▒██░  ██▒ ▓██  █▒░▒███   ▓██ ░▄█ ▒\n" +
            "░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄    ▒██   ██░  ▒██ █░░▒▓█  ▄ ▒██▀▀█▄  \n" +
            "░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒   ░ ████▓▒░   ▒▀█░  ░▒████▒░██▓ ▒██▒\n" +
            " ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░   ░ ▒░▒░▒░    ░ ▐░  ░░ ▒░ ░░ ▒▓ ░▒▓░\n" +
            "  ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░     ░ ▒ ▒░    ░ ░░   ░ ░  ░  ░▒ ░ ▒░\n" +
            "░ ░   ░   ░   ▒   ░      ░      ░      ░ ░ ░ ▒       ░░     ░     ░░   ░ \n" +
            "      ░       ░  ░       ░      ░  ░       ░ ░        ░     ░  ░   ░     \n" +
            "                                                     ░                   ";
        #endregion

        #region [Textes]
        /// <summary>
        /// Question lorsque la pertie est finir
        /// </summary>
        public const string QUESTION = "Souhaitez-vous continuer le jeu? \n (Enter pour continuer) (Esc pour sortir au ménu principal)";
        /// <summary>
        /// Texte déscriptif du projet
        /// </summary>
        public const string TEXTABOUT =
            "╔═══════════════════════════════════════════════════════════╗\n" +
            "║                  P_DEV - Space Invaders                   ║\n" +
            "║            ETML   CID2A (2021-2022)   Alexis Rojas        ║\n" +
            "╠═══════════════════════════════════════════════════════════╣\n" +
            "║ Récreation du fameux jeu 'Space Invaders' en mode console ║\n" +
            "║ programmé en C# (Projet en parallèle avec le module 226). ║\n" +
            "║                                                           ║\n" +
            "║ Le jeu vous permet de modifier la difficulté, d'activer   ║\n" +
            "║ le son et de vous montrer les scores.                     ║\n" +
            "╚═══════════════════════════════════════════════════════════╝";
        #endregion

        #region [Design des objets du jeu]
        /// <summary>
        /// Design du vaisseau
        /// </summary>
        public const string CHARSHIP = "    █    \n" +
                                       "   ███   \n" +
                                       " ███■███ \n" +
                                       "████▀████\n" +
                                       " ▀█ ▼ █▀  ";
        /// <summary>
        /// Frames crab
        /// </summary>
        public static readonly string[] CRAB = new string[]
        {
            "  ▀▄ ▄▀  \n" +
            " ▄█▀█▀█▄ \n" +
            "█▀█████▀█\n" +
            "█ █▀▀▀█ █\n" +
            "  ▀▀ ▀▀  ",
            "▄ ▀▄ ▄▀ ▄\n" +
            "█▄█████▄█\n" +
            "███▄█▄███\n" +
            "▀███████▀\n" +
            " ▄▀   ▀▄ " };
        /// <summary>
        /// Frames Octopus
        /// </summary>
        public static readonly string[] OCTOPUS = new string[]
        {
            " ▄▄███▄▄ \n" +
            "█████████\n" +
            "██▄▄█▄▄██\n" +
            " ▄▀ ▄ ▀▄ \n" +
            "  ▀   ▀  ",
            " ▄▄███▄▄ \n" +
            "█████████\n" +
            "██▄▄█▄▄██\n" +
            " ▄▀ ▄ ▀▄ \n" +
            "▀       ▀" };
        /// <summary>
        /// Frames Squid
        /// </summary>
        public static readonly string[] SQUID = new string[]
        {
            "   ▄█▄   \n" +
            " ▄█████▄ \n" +
            "███▄█▄███\n" +
            "  ▄▀▄▀▄  \n" +
            " ▀ ▀ ▀ ▀ ",
            "   ▄█▄   \n" +
            " ▄█████▄ \n" +
            "███▄█▄███\n" +
            " ▄▀   ▀▄ \n" +
            "  ▀   ▀  " };
        /// <summary>
        /// Design UFO
        /// </summary>
        const string UFO =
            "    ▄▄█▄▄    \n" +
            "  ▄███████▄  \n" +
            "▄██▄█▄█▄█▄██▄\n" +
            "  ▀█▀ ▀ ▀█▀  ";
        /// <summary>
        /// Design du missile du vaisseau
        /// </summary>
        public const string BULLETSHIP = "█";
        /// <summary>
        /// Design du missile des invaders
        /// </summary>
        public const string BULLETINVADER = "█";
        #endregion
    }
}
