using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class Character : MonoBehaviour {

	public GameObject dialogText;

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
		dialogText.GetComponent<DialogManage> ().writeOnDialogBoard (characterData.shownName, textAction.parameters [ScriptKeyword.CONTENT], "");
        float nextAutoClickTime = Time.realtimeSinceStartup;
        nextAutoClickTime = nextAutoClickTime + textAction.parameters[ScriptKeyword.CONTENT].Length * GameConstants.LETTER_DELAY + GameConstants.AUTO_DELAY;
        return nextAutoClickTime;
    }

    public float takeVoiceAction(Action voiceAction)
    {
        AudioClip voiceAudioClip = Resources.Load(FolderStructure.CHARACTERS + FolderStructure.VOICES + voiceAction.parameters[ScriptKeyword.SRC]) as AudioClip;
        this.GetComponent<AudioSource>().clip = voiceAudioClip;
        this.GetComponent<AudioSource>().Play();

        //Debug.Log("AudioClip length: " + this.GetComponent<AudioSource>().clip.length);

        float nextAutoClickTime = Time.realtimeSinceStartup;
        nextAutoClickTime = nextAutoClickTime + this.GetComponent<AudioSource>().clip.length + GameConstants.AUTO_DELAY;
        return nextAutoClickTime;
    }

    public void takeMoveAction(Action moveAction)
    {
        characterData.posX = 0.2f;
        characterData.posY = 0;
        characterData.posZ = 0;
        transform.localPosition = new Vector3(0,0,-10);
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
