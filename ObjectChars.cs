///ETML
///Auteur : Alexis Rojas
///Date : 26.11.2021
///Description: Class qui contient tous les chaines de caractères et les frames qui répresentent les objets du jeu
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_SpaceInvaders
{
    /// <summary>
    /// Contient tous les chaines de caractères et les frames qui répresentent les objets du jeu
    /// </summary>
    public static class ObjectChars
    {
        /// <summary>
        /// Design du vaisseau
        /// </summary>
        public const string CHARSHIP = "    █    \n" +
                                       "   ███   \n" +
                                       " ███■███ \n" +
                                       "████▀████\n" +
                                       " ▀█ ▼ █▀  ";
        /// <summary>
        /// Design du missile du vaisseau
        /// </summary>
        public const string BULLETSHIP = "█";
        /// <summary>
        /// Design du missile des invaders
        /// </summary>
        public const string BULLETINVADER = "█";
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
    }
}
