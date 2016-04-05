using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using dokiScriptSetting;
using Action = dokiScriptSetting.Action;


public class Character : MonoBehaviour {

	public GameObject dialogText;
    public GameObject worldControl;

    public CharacterData characterData = new CharacterData();

	void Start () {
        if (characterData == null)
        {
            characterData = new CharacterData();    
        }
	}

    public void takeRoleAction(Action roleAction) {
		if (roleAction.parameters.TryGetValue (ScriptKeyword.TYPE, out characterData.roleType)) {
			
		} else {
            characterData.roleType = ScriptKeyword.TYPE_CHARACTER;
		}
        if (roleAction.parameters.TryGetValue(ScriptKeyword.NAME, out characterData.shownName))
        {
			
		} else {
			characterData.shownName = "???";
		}
    }

    public void takePostureAction(Action postureAction)
    {
        characterData.postrueSrc = postureAction.parameters[ScriptKeyword.SRC];

        Sprite postureSprite = Resources.Load<Sprite>(FolderStructure.CHARACTERS + FolderStructure.POSTURES + postureAction.parameters[ScriptKeyword.SRC]);
        this.GetComponent<SpriteRenderer>().sprite = postureSprite;
    }

    public void takeFaceAction(Action faceAction)
    {
        Debug.Log(characterData.id + faceAction.tag);
    }

    public float takeTextAction(Action textAction)
    {
		if (dialogText == null) {
			Debug.LogError(ScriptError.NOT_ASSIGN_GAMEOBJECT);
			Application.Quit();
		}
		//dialogText.GetComponent<Text> ().text = shownName + "\n\n" + textAction.parameters [ScriptKeyword.CONTENT];
		dialogText.GetComponent<DialogManager> ().writeOnDialogBoard (characterData.shownName, textAction.parameters [ScriptKeyword.CONTENT], "");
        float nextAutoClickTime = Time.realtimeSinceStartup;
        nextAutoClickTime = nextAutoClickTime + textAction.parameters[ScriptKeyword.CONTENT].Length * (PlayerPrefs.GetFloat(GameConstants.CONFIG_TEXT_SPEED) * GameConstants.TEXT_DELAY_FACTOR) + PlayerPrefs.GetFloat(GameConstants.CONFIG_AUTO_SPEED) * GameConstants.AUTO_DELAY_FACTOR;
        return nextAutoClickTime;
    }

    public float takeVoiceAction(Action voiceAction)
    {
		string voiceSrc = "";

		//Play the voice audio
		float nextAutoClickTimeVoice = Time.realtimeSinceStartup;
		if(voiceAction.parameters.TryGetValue(ScriptKeyword.SRC, out voiceSrc)){
			AudioClip voiceAudioClip = Resources.Load(FolderStructure.CHARACTERS + FolderStructure.VOICES + voiceSrc) as AudioClip;
			this.GetComponent<AudioSource>().clip = voiceAudioClip;
			this.GetComponent<AudioSource>().Play();
			nextAutoClickTimeVoice = nextAutoClickTimeVoice + this.GetComponent<AudioSource>().clip.length + (PlayerPrefs.GetFloat(GameConstants.CONFIG_AUTO_SPEED) * GameConstants.AUTO_DELAY_FACTOR);
		}

		//Similar to the takeTextAction
		if (dialogText == null) {
			Debug.LogError(ScriptError.NOT_ASSIGN_GAMEOBJECT);
			Application.Quit();
		}

        //dialogText.GetComponent<Text> ().text = shownName + "\n\n" + textAction.parameters [ScriptKeyword.CONTENT];
		dialogText.GetComponent<DialogManager> ().writeOnDialogBoard (characterData.shownName, voiceAction.parameters [ScriptKeyword.CONTENT], voiceSrc);

        if (this.characterData.roleType == ScriptKeyword.TYPE_CHARACTER && worldControl.GetComponent<WorldControl>().getDialogMode() == GameConstants.BUBBLE)
        {
            this.GetComponentInChildren<BubbleManager>().writeOnBubbleBoard(characterData.shownName, voiceAction.parameters[ScriptKeyword.CONTENT], voiceSrc, new Vector2(-1f, 1f));
        }
        else {
            this.GetComponentInChildren<BubbleManager>().hide();
        }
		
		float nextAutoClickTimeText = Time.realtimeSinceStartup;
		nextAutoClickTimeText = nextAutoClickTimeText + voiceAction.parameters[ScriptKeyword.CONTENT].Length * (PlayerPrefs.GetFloat(GameConstants.CONFIG_TEXT_SPEED) * GameConstants.TEXT_DELAY_FACTOR) + PlayerPrefs.GetFloat(GameConstants.CONFIG_AUTO_SPEED) * GameConstants.AUTO_DELAY_FACTOR;

        //Debug.Log("AudioClip length: " + this.GetComponent<AudioSource>().clip.length);
		return Mathf.Max(nextAutoClickTimeVoice, nextAutoClickTimeText);
    }

    public void takeMoveAction(Action moveAction)
    {
        string positionValue = moveAction.parameters[ScriptKeyword.POSITION];
        if (positionValue == null || positionValue.Equals("")) {
            return;
        }
        if (positionValue.Equals(ScriptKeyword.POSITION_CENTER)) {
            characterData.posX = 0f;
            characterData.posY = 0f;
            characterData.posZ = 0f;
        } else if (positionValue.Equals(ScriptKeyword.POSITION_LEFT)) {
            characterData.posX = -0.3f;
            characterData.posY = 0f;
            characterData.posZ = 0f;
        } else if (positionValue.Equals(ScriptKeyword.POSITION_RIGHT)) {
            characterData.posX = 0.3f;
            characterData.posY = 0f;
            characterData.posZ = 0f;
        } else { 
            //the position is written in (x.xxx, x.xxx, x.xxx)
            Debug.Log(ScriptKeyword.PARENTHESE_LEFT);
            positionValue.Replace(ScriptKeyword.PARENTHESE_LEFT, string.Empty);
            positionValue.Replace(ScriptKeyword.PARENTHESE_RIGHT, string.Empty);
            positionValue.Replace(@"\s+", string.Empty);
            Debug.Log(positionValue.Contains(ScriptKeyword.PARENTHESE_LEFT));
            string[] posString = positionValue.Split(ScriptKeyword.COMMA.ToCharArray());
            characterData.posX = 0.3f;
            characterData.posY = 0f;
            characterData.posZ = 0f;
            Debug.Log(posString[0]);
        }
        float backgroundWidth = worldControl.GetComponent<WorldControl>().world.GetComponent<World>().background.GetComponent<Renderer>().bounds.extents.x;
        float backgroundHeight = worldControl.GetComponent<WorldControl>().world.GetComponent<World>().background.GetComponent<Renderer>().bounds.extents.y;
        this.transform.localPosition = new Vector3(characterData.posX * backgroundWidth, characterData.posY * backgroundHeight, characterData.posZ);
    }

    public void loadData(CharacterData characterData) {
        this.characterData = characterData;

        Debug.Log("characterData: " + characterData.id + ", " + characterData.postrueSrc + ", " + characterData.roleType + ", " + characterData.shownName);

        Action loadedRoleAction = new Action(ScriptKeyword.ROLE, new Dictionary<string, string>(){
            {ScriptKeyword.TYPE, characterData.roleType},
            {ScriptKeyword.NAME, characterData.shownName}
        });
        this.takeRoleAction(loadedRoleAction);
        Action loadedPostureAction = new Action(ScriptKeyword.POSTURE, new Dictionary<string, string>(){
            {ScriptKeyword.SRC, characterData.postrueSrc}
        });
        this.takePostureAction(loadedPostureAction);
        Action loadedMoveAction = new Action(ScriptKeyword.MOVE, new Dictionary<string, string>(){
            {ScriptKeyword.POSITION, ScriptKeyword.POSITION_CENTER},
            {ScriptKeyword.TRANSITION, ScriptKeyword.TRANSITION_INSTANT}
        });
        this.takeMoveAction(loadedMoveAction);
    }
}
