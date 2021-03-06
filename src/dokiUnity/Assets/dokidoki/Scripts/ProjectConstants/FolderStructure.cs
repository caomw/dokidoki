﻿using UnityEngine;
using System.Collections;

namespace dokidoki.dokiUnity {
    /// <summary>
    /// FolderStructure is used to pre-define the structure of all game resources.
    /// Difference type resources should be put into responding folders, in order to find it only by the name.
    /// This could greatly improce efficiency of script writing.
    /// dokidoki/
    ///     Characters/
    ///         Postures/
    ///         Voices/
    ///     DokiScripts/
    ///     World/
    ///         Backgrounds/    
    ///         Bgms/
    ///         Sounds/
    ///         Videos/
    /// </summary>
    public class FolderStructure {
        public const string DOKIDOKI = "dokidoki/";

        public const string CHARACTERS = "Characters/";
        public const string SCRIPTS = "dokiScripts/";
        public const string WORLD = "World/";
        public const string BATTLE_CARDS = "dokiBattleCards/";
        public const string BATTLE_SKILLS = "Skills/";
        public const string BATTLE_CAREERS = "Careers/";
        public const string BATTLE_EQUIPMENTS = "Equipments/";
        public const string BAtTLE_CHARACTERS = "Characters/";

        public const string POSTURES = "Postures/";
        public const string VOICES = "Voices/";

        public const string VIDEOS = "Videos/";
        public const string BACKGROUNDS = "Backgrounds/";
        public const string BGMS = "Bgms/";
        public const string SOUNDS = "Sounds/";
    }
}
