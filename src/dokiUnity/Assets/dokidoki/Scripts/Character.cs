using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Character : MonoBehaviour {

	public GameObject dialogText;

    public string id;
	public string role;
    public string shownName;

	void Start () {

	}
	
	void Update () {
	
	}

    public void takeRoleAction(Action roleAction) {
        Debug.Log(id+roleAction.tag);
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
        Debug.Log(id + postureAction.tag);
    }

    public void takeFaceAction(Action faceAction)
    {
        Debug.Log(id + faceAction.tag);
    }

    public void takeTextAction(Action textAction)
    {
		if (dialogText == null) {
			Debug.LogError(ScriptError.NOT_ASSIGN_GAMEOBJECT);
			Application.Quit();
		}
		dialogText.GetComponent<Text> ().text = shownName + "\n\n" + textAction.parameters [ScriptKeyword.CONTENT];
    }

    public void takeVoiceAction(Action voiceAction)
    {
        Debug.Log(id + voiceAction.tag);
    }

    public void takeMoveAction(Action moveAction)
    {
        Debug.Log(id + moveAction.tag);
    }
}
