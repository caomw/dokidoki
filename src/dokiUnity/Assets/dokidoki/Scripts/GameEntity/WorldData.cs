using System.Collections;


namespace dokidoki.dokiUnity {
    /// <summary>
    /// World's data to be serialized
    /// </summary>
    [System.Serializable]
    public class WorldData {
        /// <summary>
        /// Record background name, for displaying original background after saved data is loaded
        /// </summary>
        public string backgroundSrc;
        /// <summary>
        /// Record weather type, for displaying original weather after saved data is loaded
        /// </summary>
        public string weatherType;
        /// <summary>
        /// Record bgm name, for playing original bgm after saved data is loaded
        /// </summary>
        public string bgmSrc;
    }
}
