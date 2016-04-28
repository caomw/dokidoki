using UnityEngine;
using System.Collections;

public class Transition : MonoBehaviour {

    public Texture2D pattern;	// the texture that will overlay the screen. This can be a black image or a loading graphic
    public Texture2D transitionBase;
    public bool enable = false;

    private float time = 1f;
    private float startTime = Mathf.Infinity;

    private bool isIn = true;			// the direction to fade: in = -1 or out = 1

    private int drawDepth = -1000;		// the texture's order in the draw hierarchy: a low number means it renders on top
    private float processing = 0f;			// the texture's alpha value between 0 and 1

    void OnGUI() {
        if (!enable) {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), transitionBase);
            return;
        }
        if(this.startTime != Mathf.Infinity){
            this.processing = (Time.fixedTime - this.startTime) / this.time;
            this.processing = Mathf.Clamp01(this.processing);
        }
        // set color of our GUI (in this case our texture). All color values remain the same & the Alpha is set to the alpha variable
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, this.processing);
        GUI.depth = this.drawDepth;																// make the black texture render on top (drawn last)
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), transitionBase);		// draw the texture to fit the entire screen area
    }

    public void In(float time= 2f) {
        this.enable = true;
        this.time = time;
        this.processing = 0f;
        this.isIn = true;
        this.startTime = Time.fixedTime;
    }
    public void Out(float time = 2f) {
        this.enable = true;
        this.time = time;
        this.processing = 1f;
        this.isIn = false;
        this.startTime = Time.fixedTime;
    }
    public void TestIn() {
        this.In();
    }
    public void TestOut() {
        this.Out();
    }
}
