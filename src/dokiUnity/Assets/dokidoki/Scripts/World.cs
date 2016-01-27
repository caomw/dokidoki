using UnityEngine;
using System.Collections;


public class World : MonoBehaviour {

    public GameObject videoBoard;

    void Start () {
        if (videoBoard == null) {
            Debug.LogError(ScriptError.NOT_ASSIGN_GAMEOBJECT);
            Application.Quit();
        }
    }

	void Update () {
	
	}

    public void takeBackgroundAction(Action backgroundAction)
    {
        Debug.Log(backgroundAction.tag);
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
        Debug.Log(videoAction.tag);
        MovieTexture movTexture = Resources.Load(FolderStructure.VIDEOS + "/" + videoAction.parameters[ScriptKeyword.SRC]) as MovieTexture;
        
        videoBoard.GetComponent<Renderer>().material.mainTexture = movTexture;
        videoBoard.GetComponent<AudioSource>().clip = movTexture.audioClip;
        movTexture.Play();
        videoBoard.GetComponent<AudioSource>().Play();
    }

    public void takeTextAction(Action textAction)
    {
        Debug.Log(textAction.tag);
    }
}
