using System.Collections;

namespace dokiUnity {
    /// <summary>
    /// Dialog is the combination of text and voice and character's name
    /// </summary>
    [System.Serializable]
    public class Dialog {
        public string shownName;
        public string content;
        public string voiceSrc;

        public Dialog(string shownName, string content, string voiceSrc) {
            this.shownName = shownName;
            this.content = content;
            this.voiceSrc = voiceSrc;
        }
    }
}
