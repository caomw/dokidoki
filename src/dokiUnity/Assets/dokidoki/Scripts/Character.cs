using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Character : MonoBehaviour {

	public GameObject dialogText;

    public string id;
	public string role;
    public string shownName = "???";

	void Start () {

	}
	
	void Update () {
	
	}

    public void takeRoleAction(Action roleAction) {
		if (roleAction.parameters.TryGetValue (ScriptKeyword.TYPE, out role)) {
			
		} else {
			role = ScriptKeyword.TYPE_CHARACTER;
		}
		if (roleAction.parameters.TryGetValue (ScriptKeyword.NAME, out shownName)) {
			
		} else {
			shownName = "???";
		}
    }

    public void takePostureAction(Action postureAction)
    {
        Sprite postureSprite = Resources.Load<Sprite>(FolderStructure.CHARACTERS + FolderStructure.POSTURES + postureAction.parameters[ScriptKeyword.SRC]);
        this.GetComponent<SpriteRenderer>().sprite = postureSprite;
    }

    public void takeFaceAction(Action faceAction)
    {
        Debug.Log(id + faceAction.tag);
    }

    public float takeTextAction(Action textAction)
    {
		if (dialogText == null) {
			Debug.LogError(ScriptError.NOT_ASSIGN_GAMEOBJECT);
			Application.Quit();
		}
		//dialogText.GetComponent<Text> ().text = shownName + "\n\n" + textAction.parameters [ScriptKeyword.CONTENT];
		dialogText.GetComponent<DialogManage> ().writeOnDialogBoard (shownName, textAction.parameters [ScriptKeyword.CONTENT], "");
        float nextAutoClickTime = Time.realtimeSinceStartup;
        nextAutoClickTime = nextAutoClickTime + textAction.parameters[ScriptKeyword.CONTENT].Length * GameParameter.LETTER_DELAY + GameParameter.AUTO_DELAY;
        return nextAutoClickTime;
    }

    public float takeVoiceAction(Action voiceAction)
    {
        AudioClip voiceAudioClip = Resources.Load(FolderStructure.CHARACTERS + FolderStructure.VOICES + voiceAction.parameters[ScriptKeyword.SRC]) as AudioClip;
        this.GetComponent<AudioSource>().clip = voiceAudioClip;
        this.GetComponent<AudioSource>().Play();

        //Debug.Log("AudioClip length: " + this.GetComponent<AudioSource>().clip.length);

        float nextAutoClickTime = Time.realtimeSinceStartup;
        nextAutoClickTime = nextAutoClickTime + this.GetComponent<AudioSource>().clip.length + GameParameter.AUTO_DELAY;
        return nextAutoClickTime;
    }

    public void takeMoveAction(Action moveAction)
    {
        transform.localPosition = new Vector3(0,0,-10);
    }
}
