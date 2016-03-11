using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class World : MonoBehaviour {

    public GameObject videoBoard;
	public GameObject background;
	public GameObject dialogText;
    public GameObject weatherSnow;
    public GameObject weatherRain;

    public WorldData worldData = new WorldData();

    void Start () {
		if (videoBoard == null || background==null || dialogText==null) {
            Debug.LogError(ScriptError.NOT_ASSIGN_GAMEOBJECT);
            Application.Quit();
        }
        //hide videoBoard at first
        videoBoard.GetComponent<Renderer>().enabled = false;

        if(worldData == null){
            worldData = new WorldData();
        }
    }

    public void takeBackgroundAction(Action backgroundAction)
    {
        worldData.backgroundSrc = backgroundAction.parameters[ScriptKeyword.SRC];

		Sprite sprite = Resources.Load<Sprite>(FolderStructure.WORLD + FolderStructure.BACKGROUNDS + backgroundAction.parameters [ScriptKeyword.SRC]);
		background.GetComponent<SpriteRenderer> ().sprite = sprite;
    }

    public void takeWeatherAction(Action weatherAction)
    {
        worldData.weatherType = weatherAction.parameters[ScriptKeyword.TYPE];

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
        worldData.bgmSrc = bgmAction.parameters[ScriptKeyword.SRC];

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
        nextAutoClickTime = nextAutoClickTime + movTexture.duration + PlayerPrefs.GetFloat(GameConstants.CONFIG_AUTO_SPEED) * GameConstants.AUTO_DELAY_FACTOR;
        return nextAutoClickTime;
    }

    public float takeTextAction(Action textAction)
    {
		//dialogText.GetComponent<Text> ().text = textAction.parameters [ScriptKeyword.CONTENT];
		dialogText.GetComponent<DialogManage> ().writeOnDialogBoard ("", textAction.parameters [ScriptKeyword.CONTENT], "");
        float nextAutoClickTime = Time.realtimeSinceStartup;
        nextAutoClickTime = nextAutoClickTime + textAction.parameters[ScriptKeyword.CONTENT].Length * PlayerPrefs.GetFloat(GameConstants.CONFIG_TEXT_SPEED) * GameConstants.TEXT_DELAY_FACTOR + PlayerPrefs.GetFloat(GameConstants.CONFIG_AUTO_SPEED) * GameConstants.AUTO_DELAY_FACTOR;
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

    public void loadData(WorldData worldData) {
        this.worldData = worldData;

        Action loadedBackgroundAction = new Action(ScriptKeyword.BACKGROUND, new Dictionary<string, string>(){
			{ScriptKeyword.SRC, worldData.backgroundSrc},
            {ScriptKeyword.TRANSITION, ScriptKeyword.TRANSITION_INSTANT}
        });

        this.takeBackgroundAction(loadedBackgroundAction);

        Action loadedWeatherAction = new Action(ScriptKeyword.WEATHER, new Dictionary<string, string>(){
            {ScriptKeyword.TYPE, worldData.weatherType},
            {ScriptKeyword.TRANSITION, ScriptKeyword.TRANSITION_INSTANT}
        });
        this.takeWeatherAction(loadedWeatherAction);

        Action loadedBgmAction = new Action(ScriptKeyword.BGM, new Dictionary<string, string>(){
            {ScriptKeyword.SRC, worldData.bgmSrc},
            {ScriptKeyword.MODE, ScriptKeyword.MODE_LOOP}
        });
        this.takeBgmAction(loadedBgmAction);
    }
}
