using UnityEngine;
using System.Collections;

public class MultipleResolutionManager : MonoBehaviour {

	void Start () {
        int width = Screen.width;
        int height = Screen.height;

        //Debug.Log("width = " + width);
        //Debug.Log("height = " + height);

        RectTransform rt = this.gameObject.GetComponent(typeof(RectTransform)) as RectTransform;
        rt.sizeDelta = new Vector2(width, height);
	}
}
