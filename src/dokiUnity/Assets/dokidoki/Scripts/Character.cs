using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    public string id;
    public string shownName;

	void Start () {
	
	}
	
	void Update () {
	
	}

    public void takeRoleAction(Action roleAction) {
        Debug.Log(id+roleAction.tag);
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
        Debug.Log(id + textAction.tag);
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
