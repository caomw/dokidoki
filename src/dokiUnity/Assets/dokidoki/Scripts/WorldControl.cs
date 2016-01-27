using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldControl : MonoBehaviour {
    private ScriptReader scriptReader;

    private GameObject focusGameObject;

    public GameObject world;
    public GameObject characterPrefab;
    public Dictionary<string, GameObject> characters;

    private List<Action> currentActions;
    

    void Start () {
        //set up scriptReader, new game and load game
        if (scriptReader == null)
        {
            scriptReader = new ScriptReader();
        }

        if (world==null) {
            Debug.LogError(ScriptError.NOT_ASSIGN_GAMEOBJECT);
            Application.Quit();
        }

        characters = new Dictionary<string, GameObject>();
    }

	void Update () {
	    
	}


    int count = 0;

    public void step(){
        Debug.Log("Screen click..." + count++);
        if (currentActions==null || currentActions.Count<1) {
            currentActions = scriptReader.testReadNextActions();
        }
        while(currentActions.Count>0)
        {
            Action currentAction = currentActions[0];
            if (currentAction.tag == ScriptKeyword.FOCUS)
            {
                this.takeFocusAction(currentAction);
            }
            if (focusGameObject == null) {
                Debug.LogError(ScriptError.NOT_FOCUS_OBJECT);
                return;
            }
            if (currentAction.tag == ScriptKeyword.BACKGROUND) {
                focusGameObject.GetComponent<World>().takeBackgroundAction(currentAction);
            }
            else if (currentAction.tag == ScriptKeyword.WEATHER) {
                focusGameObject.GetComponent<World>().takeWeatherAction(currentAction);
            }
            else if (currentAction.tag == ScriptKeyword.SOUND)
            {
                focusGameObject.GetComponent<World>().takeSoundAction(currentAction);
            }
            else if (currentAction.tag == ScriptKeyword.BGM)
            {
                focusGameObject.GetComponent<World>().takeBgmAction(currentAction);
            }
            else if (currentAction.tag == ScriptKeyword.VIDEO)
            {
                focusGameObject.GetComponent<World>().takeVideoAction(currentAction);
            }
            else if (currentAction.tag == ScriptKeyword.TEXT)
            {
                if (focusGameObject.GetComponent<World>() != null) {
                    focusGameObject.GetComponent<World>().takeTextAction(currentAction);
                }
                if (focusGameObject.GetComponent<Character>() != null)
                {
                    focusGameObject.GetComponent<Character>().takeTextAction(currentAction);
                }
            }
            else if (currentAction.tag == ScriptKeyword.MOVE)
            {
                focusGameObject.GetComponent<Character>().takeMoveAction(currentAction);
            }
            else if (currentAction.tag == ScriptKeyword.POSTURE)
            {
                focusGameObject.GetComponent<Character>().takePostureAction(currentAction);
            }
            else if (currentAction.tag == ScriptKeyword.FACE)
            {
                focusGameObject.GetComponent<Character>().takeFaceAction(currentAction);
            }
            else if (currentAction.tag == ScriptKeyword.VOICE)
            {
                focusGameObject.GetComponent<Character>().takeVoiceAction(currentAction);
            }
            else if (currentAction.tag == ScriptKeyword.ROLE)
            {
                focusGameObject.GetComponent<Character>().takeRoleAction(currentAction);
            }
            //remove already completed action
            currentActions.RemoveAt(0);
        }
    }

    public void takeFocusAction(Action focusAction) {
        focusGameObject = null;
        //focus on object to take further actions
        if (focusAction.parameters[ScriptKeyword.ID] == ScriptKeyword.WORLD)
        {
            focusGameObject = world;
        }
        else {
            if (!characters.ContainsKey(focusAction.parameters[ScriptKeyword.ID]))
            {
                //there is no character on this id, create one
                GameObject newCharacter = Instantiate(characterPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                newCharacter.transform.parent = world.transform;
                newCharacter.GetComponent<Character>().id = focusAction.parameters[ScriptKeyword.ID];
				newCharacter.GetComponent<Character>().dialogText = world.GetComponent<World>().dialogText;
                characters.Add(focusAction.parameters[ScriptKeyword.ID], newCharacter);
            }
            focusGameObject = characters[focusAction.parameters[ScriptKeyword.ID]];
        }
    }

}
