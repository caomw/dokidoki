using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class World : MonoBehaviour {

    public GameObject videoBoard;
	public GameObject background;
	public GameObject dialogText;

    void Start () {
		if (videoBoard == null || background==null || dialogText==null) {
            Debug.LogError(ScriptError.NOT_ASSIGN_GAMEOBJECT);
            Application.Quit();
        }
    }

	void Update () {
	
	}

    public void takeBackgroundAction(Action backgroundAction)
    {
		Sprite sprite = Resources.Load<Sprite>(FolderStructure.WORLD + FolderStructure.BACKGROUNDS + backgroundAction.parameters [ScriptKeyword.SRC]);
		background.GetComponent<SpriteRenderer> ().sprite = sprite;

    }

    public void takeWeatherAction(Action weatherAction)
    {
        Debug.Log(weatherAction.tag);
    }

    public void takeSoundAction(Action soundAction)
    {
        Debug.Log(soundAction.tag);
    }

    public void takeBgmAction(Action bgmAction)
    {
        Debug.Log(bgmAction.tag);
    }

    public void takeVideoAction(Action videoAction)
    {
        MovieTexture movTexture = Resources.Load(FolderStructure.WORLD + FolderStructure.VIDEOS + videoAction.parameters[ScriptKeyword.SRC]) as MovieTexture;
        
        videoBoard.GetComponent<Renderer>().material.mainTexture = movTexture;
        videoBoard.GetComponent<AudioSource>().clip = movTexture.audioClip;

        movTexture.Play();
        videoBoard.GetComponent<AudioSource>().Play();
    }

    public void takeTextAction(Action textAction)
    {
		dialogText.GetComponent<Text> ().text = textAction.parameters [ScriptKeyword.CONTENT];
    }
}
