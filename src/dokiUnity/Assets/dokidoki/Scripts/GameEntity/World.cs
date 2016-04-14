using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using dokiScriptSetting;
using Action = dokiScriptSetting.Action;

/// <summary>
/// World is a GameObject, represents the world that all characters are in, used to take a series of actions to show effects.
/// Those actions contain: BackgroundAction, BgmAction, SoundAction, TextAction, VideoAction, WeatherAction.
/// World could display weather, play bgm, play sound, show background, play video, show aside.
/// World GameObject has childs as background GameObject, weather GameObject, Video GameObject, a set of Character GameObjects
/// </summary>
public class World : MonoBehaviour {
    /// <summary>
    /// WorldData records status for saving and loading
    /// </summary>
    public WorldData worldData = new WorldData();


    //Effect related GameObjects
    /// <summary>
    /// videoBoard is a GameObject to play video, is a child of World GameObject
    /// </summary>
    public GameObject videoBoard;

    /// <summary>
    /// background is a GameObject to show background, is a child of World GameObject
    /// </summary>
	public GameObject background;

    /// <summary>
    /// dialogContent is a GameObject to show dialog text on dialog window, which is a child of UI Canvas
    /// </summary>
	public GameObject dialogContent;

    /// <summary>
    /// weatherSnow is a GameObject to show snow weather effect, which is a child of World GameObject
    /// </summary>
    public GameObject weatherSnow;

    /// <summary>
    /// weatherRain is a GameObject to show rain weather effect, which is a child of World GameObject
    /// </summary>
    public GameObject weatherRain;

    void Start () {
        videoBoard.SetActive(true);
        videoBoard.GetComponent<Renderer>().sortingOrder = 100;
        //hide videoBoard at first
        videoBoard.GetComponent<Renderer>().enabled = false;
    }

    /// <summary>
    /// World takes background action to change the background effects, the background is a child GameObject below the World GameObject
    /// </summary>
    /// <param name="backgroundAction">Action tagged as background, which contains the parameters for background setting</param>
    public void takeBackgroundAction(Action backgroundAction)
    {
        worldData.backgroundSrc = backgroundAction.parameters[ScriptKeyword.SRC];

		Sprite sprite = Resources.Load<Sprite>(FolderStructure.WORLD + FolderStructure.BACKGROUNDS + backgroundAction.parameters [ScriptKeyword.SRC]);
		background.GetComponent<SpriteRenderer> ().sprite = sprite;
    }

    /// <summary>
    /// World takes background action to change weather effects, the weather is a child GameObject below the World GameObject
    /// </summary>
    /// <param name="weatherAction">Action tagged as weather, which contains the parameters for weather setting</param>
    public void takeWeatherAction(Action weatherAction)
    {
        worldData.weatherType = weatherAction.parameters[ScriptKeyword.TYPE];

        if (weatherAction.parameters[ScriptKeyword.TYPE] == ScriptKeyword.TYPE_SNOW)
        {
            weatherSnow.SetActive(true);
            EllipsoidParticleEmitter ellipsoidParticleEmitter = weatherSnow.GetComponent<EllipsoidParticleEmitter>();
            string level = "0.5";
            if (weatherAction.parameters.TryGetValue(ScriptKeyword.LEVEL, out level)) {

                ellipsoidParticleEmitter.minEmission = 100 * float.Parse(level);
                ellipsoidParticleEmitter.maxEmission = 100 * float.Parse(level);
            }
        }else {
            weatherSnow.SetActive(true);
            EllipsoidParticleEmitter ellipsoidParticleEmitter = weatherSnow.GetComponent<EllipsoidParticleEmitter>();
            ellipsoidParticleEmitter.minEmission = 0;
            ellipsoidParticleEmitter.maxEmission = 0;
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

    /// <summary>
    /// World takes sound action to change sound effects, the sound is a component on the World GameObject
    /// </summary>
    /// <param name="soundAction">Action tagged as sound, which contains the parameters for sound setting</param>
    public void takeSoundAction(Action soundAction)
    {
        AudioClip soundAudioClip = Resources.Load(FolderStructure.WORLD + FolderStructure.SOUNDS + soundAction.parameters[ScriptKeyword.SRC]) as AudioClip;
        this.GetComponent<AudioSource>().clip = soundAudioClip;
        this.GetComponent<AudioSource>().Play();
    }

    /// <summary>
    /// World takes bgm action to change sound effects, the bgm is a component on the Background GameObject
    /// </summary>
    /// <param name="bgmAction">Action tagged as bgm, which contains the parameters for bgm setting</param>
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

    /// <summary>
    /// World takes video action to change video effects, the video is a child GameObject below the World GameObject
    /// </summary>
    /// <param name="videoAction">Action tagged as video, which contains the parameters for video setting</param>
    /// <returns>Returns end of the time at which this action is supposed over</returns>
    public float takeVideoAction(Action videoAction)
    {
#if UNITY_STANDALONE || UNITY_EDITOR
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
#endif
#if UNITY_IPHONE
        return 0;
#endif
#if UNITY_ANDROID
        Handheld.PlayFullScreenMovie("StreamingAssets/" + FolderStructure.WORLD + FolderStructure.VIDEOS + videoAction.parameters[ScriptKeyword.SRC]);
        Debug.Log("Play video");
        return 0;
#endif
    }

    /// <summary>
    /// World takes text action to change video effects, text is shown on the dialog board GameObject which is on the UI canvas
    /// </summary>
    /// <param name="textAction">Action tagged as text, which contains the parameters for text setting</param>
    /// <returns>Returns end of the time at which this action is supposed over</returns>
    public float takeTextAction(Action textAction)
    {
		//dialogContent.GetComponent<Text> ().text = textAction.parameters [ScriptKeyword.CONTENT];
		dialogContent.GetComponent<DialogManager> ().writeOnDialogBoard ("", textAction.parameters [ScriptKeyword.CONTENT], "");
        float nextAutoClickTime = Time.realtimeSinceStartup;
        nextAutoClickTime = nextAutoClickTime + textAction.parameters[ScriptKeyword.CONTENT].Length * PlayerPrefs.GetFloat(GameConstants.CONFIG_TEXT_SPEED) * GameConstants.TEXT_DELAY_FACTOR + PlayerPrefs.GetFloat(GameConstants.CONFIG_AUTO_SPEED) * GameConstants.AUTO_DELAY_FACTOR;
        return nextAutoClickTime;
    }

    /// <summary>
    /// this function is used to skip current video action
    /// </summary>
    public void skipVideoAction()
    {
#if UNITY_STANDALONE  || UNITY_EDITOR
        if (videoBoard.GetComponent<Renderer>().material.mainTexture != null) {
            ((MovieTexture)videoBoard.GetComponent<Renderer>().material.mainTexture).Stop();
        }
        if (videoBoard.GetComponent<AudioSource>().clip != null) {
            videoBoard.GetComponent<AudioSource>().Stop();
        }
        videoBoard.GetComponent<Renderer>().enabled = false;
#endif
#if UNITY_IOS
#endif
#if UNITY_ANDROID
#endif
    }

    /// <summary>
    /// World game entity load data from saving data (on the disk)
    /// </summary>
    /// <param name="worldData">worldData is the serialized data on the disk</param>
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
