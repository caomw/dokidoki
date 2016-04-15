using UnityEngine;
using System.Collections;

namespace dokiUnity {
    /// <summary>
    /// MultipleResolutionManager is attached to each Board GameObject, used to set the size of each Board into just the size of the screen
    /// </summary>
    public class MultipleResolutionManager : MonoBehaviour {
        /// <summary>
        /// Called when game startsup, read the size of screen and set it to all Boards
        /// </summary>
        void Start() {
            int width = Screen.width;
            int height = Screen.height;

            //Debug.Log("width = " + width);
            //Debug.Log("height = " + height);

            RectTransform rt = this.gameObject.GetComponent(typeof(RectTransform)) as RectTransform;
            rt.sizeDelta = new Vector2(width, height);
        }
    }
}
