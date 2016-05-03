using UnityEngine;
using System.Collections;

namespace dokidoki.dokiUnity {
    /// <summary>
    /// Character's data to be serialized
    /// </summary>
    [System.Serializable]
    public class CharacterData {
        /// <summary>
        /// Record character id, for recreating original character to receive new actions to take
        /// </summary>
        public string id;
        /// <summary>
        /// Record character role type
        /// </summary>
        public string roleType;
        /// <summary>
        /// Record character's name
        /// </summary>
        public string shownName;
        /// <summary>
        /// Record posture name, for displaying original posture after saved data is loaded
        /// </summary>
        public string postrueSrc;
        /// <summary>
        /// Record position's X value, for repositioning character into original postion after saved data is loaded
        /// </summary>
        public float positionX = 0.5f;
        /// <summary>
        /// Record position's Y value, for repositioning character into original postion after saved data is loaded
        /// </summary>
        public float positionY = 0.5f;
        /// <summary>
        /// Record position's Z value, for repositioning character into original postion after saved data is loaded
        /// </summary>
        public float positionZ = 0f;
        /// <summary>
        /// Record posture's anchor X value
        /// </summary>
        public float anchorX = 0.5f;
        /// <summary>
        /// Record posture's anchor Y value
        /// </summary>
        public float anchorY = 0.5f;
    }
}
