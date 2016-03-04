using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class World : MonoBehaviour {

    public GameObject videoBoard;
	public GameObject background;
	public GameObject dialogText;
    public GameObject weatherSnow;
    public GameObject weatherRain;

    void Start () {
		if (videoBoard == null || background==null || dialogText==null) {
            Debug.LogError(ScriptError.NOT_ASSIGN_GAMEOBJECT);
            Application.Quit();
        }
        //hide videoBoard at first
        videoBoard.GetComponent<Renderer>().enabled = false;
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
        if (weatherAction.parameters[ScriptKeyword.TYPE] == ScriptKeyword.TYPE_SNOW)
        {
            weatherSnow.SetActive(true);
        }
        else {
            weatherSnow.SetActive(false);
        }
        if (weatherAction.parameters[ScriptKeyword.TYPE] == ScriptKeyword.TYPE_RAIN)
        {
            weatherRain.SetActive(true);
        }
        else
        {
            weatherRain.SetActive(false);
        }

    }

    public void takeSoundAction(Action soundAction)
    {
        AudioClip soundAudioClip = Resources.Load(FolderStructure.WORLD + FolderStructure.SOUNDS + soundAction.parameters[ScriptKeyword.SRC]) as AudioClip;
        this.GetComponent<AudioSource>().clip = soundAudioClip;
        this.GetComponent<AudioSource>().Play();
    }

    public void takeBgmAction(Action bgmAction)
    {
        //load bgm
        AudioClip bgmAudioClip = Resources.Load(FolderStructure.WORLD + FolderStructure.BGMS + bgmAction.parameters[ScriptKeyword.SRC]) as AudioClip;
        //attach bgm audio file on to background GameObject
        background.GetComponent<AudioSource>().clip = bgmAudioClip;
        //check bgm mode
        string mode = "";
        if (bgmAction.parameters.TryGetValue(ScriptKeyword.MODE, out mode))
        {
            if (mode != ScriptKeyword.MODE_LOOP)
            {
                background.GetComponent<AudioSource>().loop = false;
            }
            else {
                background.GetComponent<AudioSource>().loop = true;
            }
        }
        else {
            background.GetComponent<AudioSource>().loop = true;
        }
        background.GetComponent<AudioSource>().Play();
    }

    public float takeVideoAction(Action videoAction)
    {
        videoBoard.GetComponent<Renderer>().enabled = true;

        MovieTexture movTexture = Resources.Load(FolderStructure.WORLD + FolderStructure.VIDEOS + videoAction.parameters[ScriptKeyword.SRC]) as MovieTexture;
        
        videoBoard.GetComponent<Renderer>().material.mainTexture = movTexture;
        videoBoard.GetComponent<AudioSource>().clip = movTexture.audioClip;

        //Debug.Log("Video length: " + movTexture.duration);

        movTexture.Play();
        videoBoard.GetComponent<AudioSource>().Play();

        float nextAutoClickTime = Time.realtimeSinceStartup;
        nextAutoClickTime = nextAutoClickTime + movTexture.duration + GameParameter.AUTO_DELAY;
        return nextAutoClickTime;
    }

    public float takeTextAction(Action textAction)
    {
		//dialogText.GetComponent<Text> ().text = textAction.parameters [ScriptKeyword.CONTENT];
		dialogText.GetComponent<DialogManage> ().writeOnDialogBoard ("", textAction.parameters [ScriptKeyword.CONTENT], "");
        float nextAutoClickTime = Time.realtimeSinceStartup;
        nextAutoClickTime = nextAutoClickTime + textAction.parameters[ScriptKeyword.CONTENT].Length * GameParameter.LETTER_DELAY + GameParameter.AUTO_DELAY;
        return nextAutoClickTime;
    }

    public void skipVideoAction() {
        if (videoBoard.GetComponent<Renderer>().material.mainTexture != null) {
            ((MovieTexture)videoBoard.GetComponent<Renderer>().material.mainTexture).Stop();
        }
        if (videoBoard.GetComponent<AudioSource>().clip != null) {
            videoBoard.GetComponent<AudioSource>().Stop();
        }
        videoBoard.GetComponent<Renderer>().enabled = false;
    }
}
