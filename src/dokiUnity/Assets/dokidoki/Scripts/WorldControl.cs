using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WorldControl : MonoBehaviour {
    private ScriptReader scriptReader;

    private GameObject focusGameObject;

    public GameObject world;
    //In play UI gameobjects
    public GameObject dialog;
    public GameObject quickButtons;
    public GameObject backLog;


    public GameObject characterPrefab;
	public GameObject backLogText;
	public GameObject dialogText;
    public Dictionary<string, GameObject> characters;

    private List<Action> currentActions;
    private Action lastAction;

	public string currentGameState = NORMAL;
	const string NORMAL = "Normal";
	const string BACKLOG = "BackLog";
	const string SAVE = "Save";
	const string LOAD = "Load";
	const string AUTO = "Auto";
	const string SKIP = "Skip";
    const string HIDE = "Hide";

    public float nextAutoClickTime = 0f;

    void Start() {
        //set up scriptReader, new game and load game
        if (scriptReader == null)
        {
            scriptReader = new ScriptReader();
        }

        if (world == null) {
            Debug.LogError(ScriptError.NOT_ASSIGN_GAMEOBJECT);
            Application.Quit();
        }

        characters = new Dictionary<string, GameObject>();
    }

    void FixedUpdate() {
        if(currentGameState == AUTO){
            float currentTime = Time.realtimeSinceStartup;
            //Auto click
            if (currentTime > nextAutoClickTime)
            {
                //Debug.Log("Auto click");
                //Click once, wait for next time update
                nextAutoClickTime = Mathf.Infinity;
                step();
            }
        }
    }

    //public int count = 0;
    /// <summary>
    /// Game click
    /// </summary>
    public void step() {
        //Debug.Log(++count);
        //Check game state first
        if(currentGameState == BACKLOG){
            clickBackLogButton();
            return;
        }
        else if (currentGameState == AUTO)
        {
            nextAutoClickTime = Mathf.Infinity;
        }else if(currentGameState == HIDE){
            clickHideButton();
            return;
        }

        //If in NORMAL state, plays the game normally
        if (currentActions == null || currentActions.Count < 1) {
            //To be done
            currentActions = scriptReader.testReadNextActions();
        }
        if (lastAction != null && lastAction.tag == ScriptKeyword.VIDEO) {
            world.GetComponent<World>().skipVideoAction();
            showInPlayUI();
        }
        while (currentActions.Count > 0)
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
                hideInPlayUI();
                updateNextAutoClickTime( focusGameObject.GetComponent<World>().takeVideoAction(currentAction));
            }
            else if (currentAction.tag == ScriptKeyword.TEXT)
            {
                if (focusGameObject.GetComponent<World>() != null) {
                    updateNextAutoClickTime( focusGameObject.GetComponent<World>().takeTextAction(currentAction));
                }
                if (focusGameObject.GetComponent<Character>() != null)
                {
                    updateNextAutoClickTime(focusGameObject.GetComponent<Character>().takeTextAction(currentAction));
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
                updateNextAutoClickTime( focusGameObject.GetComponent<Character>().takeVoiceAction(currentAction));
            }
            else if (currentAction.tag == ScriptKeyword.ROLE)
            {
                focusGameObject.GetComponent<Character>().takeRoleAction(currentAction);
            }
            //store last action
            lastAction = currentAction;
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

    public void hideInPlayUI() {
        dialog.SetActive(false);
        quickButtons.SetActive(false);
    }

	public void showInPlayUI() {
        dialog.SetActive(true);
        quickButtons.SetActive(true);
    }

	public void clickBackLogButton(){
        if (currentGameState == NORMAL)
        {
            //Open backlog window
            currentGameState = BACKLOG;

            backLog.SetActive(true);

            List<Dialog> historyDialogs = dialogText.GetComponent<DialogManage>().historyDialogs;
            string historyDialogText = "";
            for (int i = 0; i < historyDialogs.Count; i++)
            {
                if (historyDialogs[i].shownName != "")
                {
                    historyDialogText = historyDialogText + historyDialogs[i].shownName + ": ";
                }
                historyDialogText = historyDialogText + historyDialogs[i].content + "\n";
            }
            backLogText.GetComponent<Text>().text = historyDialogText;
        }
        else if (currentGameState == BACKLOG)
        { 
            //close backlog window
            backLog.SetActive(false);
            currentGameState = NORMAL;
        }
	}

    public void clickAutoButton() {
        if (currentGameState == NORMAL)
        {
            //Enter AUTO state
            currentGameState = AUTO;
        }
        else if(currentGameState == AUTO){ 
            //Leave AUTO state
            currentGameState = NORMAL;
        }
    }

    /// <summary>
    /// Update the most long next auto click time, except for Mathf.Infinity
    /// </summary>
    /// <param name="newNextAutoClickTime">
    /// New next auto click time
    /// </param>
    public void updateNextAutoClickTime(float newNextAutoClickTime) {
        if (this.nextAutoClickTime == Mathf.Infinity)
        {
            this.nextAutoClickTime = newNextAutoClickTime;
        }
        else if (this.nextAutoClickTime < Mathf.Infinity)
        {
            this.nextAutoClickTime = Mathf.Max(this.nextAutoClickTime, newNextAutoClickTime);
        }
    }

    public void clickHideButton() { 
        if(currentGameState == NORMAL){
            currentGameState = HIDE;
            hideInPlayUI();
        }else if(currentGameState == HIDE){
            currentGameState = NORMAL;
            showInPlayUI();
        }
    }
}
