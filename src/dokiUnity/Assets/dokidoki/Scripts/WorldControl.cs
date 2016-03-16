using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
//using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class WorldControl : MonoBehaviour {
    private ScriptReader scriptReader;

    private GameObject focusGameObject;

    public GameObject world;
    //In play UI gameobjects
    public GameObject gameBoardUI;
    public GameObject dialogUI;
    public GameObject quickButtonsUI;
    public GameObject backLogUI;
    public GameObject saveBoardUI;
    public GameObject loadBoardUI;
    public GameObject startBoardUI;
    public GameObject configBoardUI;
    public GameObject confirmBoardUI;
    public GameObject flagBoardUI;

    public GameObject characterPrefab;
    public GameObject logTextPrefab;
    public GameObject saveTextPrefab;
    public GameObject loadTextPrefab;
    public GameObject flagTextPrefab;

	public GameObject backLogContent;
    public GameObject saveContent;
    public GameObject loadContent;
    public GameObject flagContent;
	public GameObject dialogContent;
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
    const string CONFIG = "Config";
    const string FLAG = "Flag";

    public float nextAutoClickTime = 0f;

    public WorldControlData worldControlData = new WorldControlData();

    void Start() {
        //set up scriptReader, new game and load game
        if (scriptReader == null)
        {
            scriptReader = new ScriptReader();
        }

        characters = new Dictionary<string, GameObject>();

        if (worldControlData == null)
        {
            worldControlData = new WorldControlData();
        }

        //Load PlayerPrefs
        configBoardUI.SetActive(true);
        configBoardUI.SetActive(false);

        startBoardUI.SetActive(true);
    }

    public void clickStartButton() {
        startBoardUI.SetActive(false);
        gameBoardUI.SetActive(true);
        step();
    }
    public void clickConfigButton() {
        if (currentGameState == NORMAL)
        {
            currentGameState = CONFIG;
            configBoardUI.SetActive(true);
        }
        else if(currentGameState == CONFIG){
            configBoardUI.SetActive(false);
            currentGameState = NORMAL;
        }
    }
    public void clickExitButton(bool confirmed){
        if (!confirmed)
        {
            confirmCurrentAction("Do you want to exit?", "This action would lose current game data.",clickExitButton);
            return;
        }
        Application.Quit();
    }

    void Update() {
        if (Input.GetMouseButtonDown(1)) {
            if (currentGameState == BACKLOG)
            {
                clickBackLogButton();
                return;
            }
            else if (currentGameState == SAVE)
            {
                clickSaveButton();
                return;
            }
            else if (currentGameState == LOAD)
            {
                clickLoadButton();
                return;
            }
            else if (currentGameState == HIDE || currentGameState == NORMAL)
            {
                if(gameBoardUI.activeSelf){
                    clickHideButton();
                }
                return;
            }
            else if (currentGameState == CONFIG)
            {
                clickConfigButton();
                return;
            }
        }

        //Skip key pressed
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            clickSkipButton();
        }
        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl))
        {
            clickSkipButton();
        }    
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
        }else if(currentGameState == SAVE){
            clickSaveButton();
            return;
        }else if(currentGameState == LOAD){
            clickLoadButton();
            return;
        }else if(currentGameState == HIDE){
            clickHideButton();
            return;
        }else if(currentGameState == FLAG){
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
            else if (currentAction.tag == ScriptKeyword.FLAG)
            {
                this.takeFlagAction(currentAction);
            }
            //store last action
            lastAction = currentAction;
            if(currentAction.tag == ScriptKeyword.TEXT || currentAction.tag == ScriptKeyword.VOICE){
                worldControlData.textContent = currentAction.parameters[ScriptKeyword.CONTENT];
            }
            //remove already completed action
            currentActions.RemoveAt(0);
        }
    }

    public void takeFocusAction(Action focusAction) {

        worldControlData.focusGameObjectId = focusAction.parameters[ScriptKeyword.ID];

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
                characters.Add(focusAction.parameters[ScriptKeyword.ID], createNewCharacter(focusAction.parameters[ScriptKeyword.ID]));
            }
            focusGameObject = characters[focusAction.parameters[ScriptKeyword.ID]];
        }
    }

    public void takeFlagAction(Action flagAction) {
        if(currentGameState == AUTO){
            clickAutoButton();
        }
        if (currentGameState == SKIP)
        {
            clickSkipButton();
        }
        if (currentGameState == NORMAL)
        {
            currentGameState = FLAG;
            flagBoardUI.SetActive(true);

            string option;
            if (flagAction.parameters.TryGetValue(ScriptKeyword.OPTION, out option)) {
                List<string> texts = new List<string>();
                for (int i = 0; i < int.Parse(option); i++)
                {
                    string text = flagAction.parameters[ScriptKeyword.OPTION_ + (i + 1)];
                    texts.Add(text);
                }
                List<System.Object> parameters = new List<object>();
                for (int i = 0; i < int.Parse(option); i++)
                {
                    List<string> optionParameter = new List<string>();
                    optionParameter.Add(""+ (i + 1));
                    optionParameter.Add(flagAction.parameters[ScriptKeyword.OPTION_ + (i + 1)]);
					optionParameter.Add(flagAction.parameters[ScriptKeyword.OPTION_ID_ + (i + 1)]);
                    optionParameter.Add(flagAction.parameters[ScriptKeyword.OPTION_SRC_ + (i + 1)]);

                    parameters.Add(optionParameter);
                }

                setupTextButtonBoard(texts, flagTextPrefab, flagContent, false, onFlagTextButtonClick, parameters);
            }
        }
    }

    public void onFlagTextButtonClick(bool confirmed, System.Object optionParameter) {
        this.worldControlData.worldLine += ((List<string>)optionParameter)[0];

        if (currentGameState == FLAG)
        {
            flagBoardUI.SetActive(false);
            currentGameState = NORMAL;
        }

        Debug.Log("((List<string>)optionParameter)[0]: " + ((List<string>)optionParameter)[0]);
        Debug.Log("((List<string>)optionParameter)[1]: " + ((List<string>)optionParameter)[1]);
        Debug.Log("((List<string>)optionParameter)[2]: " + ((List<string>)optionParameter)[2]);
		Debug.Log("((List<string>)optionParameter)[3]: " + ((List<string>)optionParameter)[3]);

        //Jump to this option
        //To be done
    }

    /// <summary>
    /// Create new character GameObject with id
    /// </summary>
    /// <param name="id">the id of new character in scripts</param>
    /// <returns>The GameObject reference of the new character</returns>
    public GameObject createNewCharacter(string id) {
        GameObject newCharacter = Instantiate(characterPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        newCharacter.transform.parent = this.world.transform;
        newCharacter.GetComponent<Character>().characterData.id = id;
        newCharacter.GetComponent<Character>().dialogText = this.world.GetComponent<World>().dialogText;
        return newCharacter;
    }

    public void hideInPlayUI() {
        dialogUI.SetActive(false);
        quickButtonsUI.SetActive(false);
    }

	public void showInPlayUI() {
        dialogUI.SetActive(true);
        quickButtonsUI.SetActive(true);
    }

    public void loadData(WorldControlData worldControlData) {
        this.worldControlData = worldControlData;

        Action loadedFocusAction = new Action(ScriptKeyword.FOCUS, new Dictionary<string, string>(){
            {ScriptKeyword.ID, worldControlData.focusGameObjectId}
        });
        this.takeFocusAction(loadedFocusAction);

        Action loadedTextAction = new Action(ScriptKeyword.TEXT, new Dictionary<string, string>(){
            {ScriptKeyword.CONTENT, worldControlData.textContent},
            {ScriptKeyword.TYPE, ScriptKeyword.CLICK_NEXT_DIALOGUE_PAGE}
        });
        if (focusGameObject.GetComponent<World>() != null)
        {
            updateNextAutoClickTime(focusGameObject.GetComponent<World>().takeTextAction(loadedTextAction));
        }
        if (focusGameObject.GetComponent<Character>() != null)
        {
            updateNextAutoClickTime(focusGameObject.GetComponent<Character>().takeTextAction(loadedTextAction));
        }
    }

    public GameObject createLogTextButton(Dialog dialog) { 
        GameObject newLogTextButton = Instantiate(logTextPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        newLogTextButton.transform.SetParent(this.backLogContent.transform);
        newLogTextButton.transform.localPosition = new Vector3(0, -newLogTextButton.GetComponent<RectTransform>().rect.height, 0);
        string dialogText = "";
        if (dialog.shownName != "")
        {
            dialogText = dialogText + dialog.shownName + ": ";
        }
        dialogText = dialogText + dialog.content;
        newLogTextButton.GetComponentInChildren<Text>().text = dialogText;
        return newLogTextButton;
    }

    public GameObject createTextButton(string text, GameObject prefab, GameObject parentGameObject, UnityAction<bool, System.Object> onclick, System.Object parameter)
    {

        GameObject newTextButton = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        newTextButton.transform.SetParent(parentGameObject.transform);
        newTextButton.transform.localPosition = new Vector3(0, -newTextButton.GetComponent<RectTransform>().rect.height, 0);
        newTextButton.GetComponentInChildren<Text>().text = text;
        newTextButton.GetComponent<Button>().onClick.AddListener(() => { onclick(false, parameter); });
        return newTextButton;
    }

    public void setupTextButtonBoard(List<string> texts, GameObject buttonPrefab, GameObject contentGameObject, bool toBottom, UnityAction<bool, System.Object> onclick, List<System.Object> parameters)
    {
        //Destroy all previous text buttons
        for (int i = 0; i < contentGameObject.transform.childCount; i++){
            GameObject.Destroy(contentGameObject.transform.GetChild(i).gameObject);
        }

        //Create a list of log text button
        List<GameObject> textButtons = new List<GameObject>();
        for (int i = 0; i < texts.Count; i++)
        {
            GameObject newTextButton = this.createTextButton(texts[i], buttonPrefab, contentGameObject, onclick, parameters[i]);
            if (textButtons.Count > 0){
                newTextButton.transform.localPosition = textButtons[textButtons.Count - 1].transform.localPosition;
                newTextButton.transform.localPosition = new Vector3(newTextButton.transform.localPosition.x,
                                                                newTextButton.transform.localPosition.y - newTextButton.GetComponent<RectTransform>().rect.height,
                                                                newTextButton.transform.localPosition.z);
            }
            textButtons.Add(newTextButton);
        }

        //Resize the backLogText
        float height = (textButtons.Count + 1) * textButtons[0].GetComponent<RectTransform>().rect.height;
        float width = contentGameObject.GetComponent<RectTransform>().rect.width;
        contentGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);

        //Scroll to the bottom
        if(toBottom){
            contentGameObject.GetComponentInParent<ScrollRect>().normalizedPosition = new Vector2(0, 0);
        }
    }

//Quick button functions
	public void clickBackLogButton(){
        if (currentGameState == NORMAL)
        {
            //Open backlog window
            currentGameState = BACKLOG;
            backLogUI.SetActive(true);

            //Get texts to display
            List<Dialog> historyDialogs = dialogContent.GetComponent<DialogManage>().historyDialogs;
            List<string> texts = new List<string>();
            for (int i = 0; i < historyDialogs.Count; i++)
            {
                string dialogText = "";
                if (historyDialogs[i].shownName != "")
                {
                    dialogText = dialogText + historyDialogs[i].shownName + ": ";
                }
                dialogText = dialogText + historyDialogs[i].content;
                texts.Add(dialogText);
            }
            List<System.Object> parameters = new List<object>();
            for (int i = 0; i < historyDialogs.Count; i++)
            {
                parameters.Add(historyDialogs[i].voiceSrc);
            }
            //Set up log text buttons board
            setupTextButtonBoard(texts, logTextPrefab, backLogContent, true, onLogTextButtonClick, parameters); 
        }
        else if (currentGameState == BACKLOG)
        { 
            //close backlog window
            backLogUI.SetActive(false);
            currentGameState = NORMAL;
        }
	}

    public void onLogTextButtonClick(bool confirmed, System.Object voiceSrc)
    {
        Debug.Log("voiceSrc: " + voiceSrc);
        return;
    }

    public void clickQuickSaveButton(bool confirmed) {
        if (!confirmed) {
            this.confirmCurrentAction("Do you want to quick save?", "This action would overwrite the original saved data.",clickQuickSaveButton);
            return;
        }
        saveTo(0);
    }

    public void clickQuickLoadButton(bool confirmed)
    {
        //Check whether this position has saved data
        string dirPath = Application.persistentDataPath + "/" + GameConstants.SAVE_DIRECTORY + "/0";
        if (!Directory.Exists(dirPath))
        {
            return;
        }
        if (!confirmed)
        {

            this.confirmCurrentAction("Do you want to quick load?", "This action would lose current game data.", clickQuickLoadButton);
            return;
        }
        dialogContent.GetComponent<DialogManage>().clear();
        loadFrom(0);
    }

    public void clickSaveButton() {
        if (currentGameState == NORMAL)
        {
            currentGameState = SAVE;
            saveBoardUI.SetActive(true);

            List<string> texts = new List<string>();
            for (int i = 0; i < GameConstants.SAVE_SIZE; i++)
            {
                string text = "No." + (i + 1) + "\n" + GameConstants.SAVE_DEFAULT;
                texts.Add(text);
            }
            List<System.Object> parameters = new List<object>();
            for (int i = 0; i < GameConstants.SAVE_SIZE; i++)
            {
                parameters.Add(i + 1);
            }

            checkSavedData(texts);

            setupTextButtonBoard(texts, saveTextPrefab, saveContent, false, onSaveTextButtonClick, parameters);
        }
        else if (currentGameState == SAVE)
        {
            saveBoardUI.SetActive(false);
            currentGameState = NORMAL;
        }
    }

    public void onSaveTextButtonClick(bool confirmed, System.Object position) {
        if (!confirmed)
        {
            this.confirmCurrentAction("Do you want to quick save?", "This action would overwrite the original saved data.", onSaveTextButtonClick, position);
            return;
        }
        saveTo((int)position);
        clickSaveButton();
        return;
    }

    public void clickLoadButton() {
        if (currentGameState == NORMAL)
        {
            currentGameState = LOAD;
            loadBoardUI.SetActive(true);

            List<string> texts = new List<string>();
            for (int i = 0; i < GameConstants.SAVE_SIZE; i++)
            {
                string text = "No." + (i + 1) + "\n" + GameConstants.SAVE_DEFAULT;
                texts.Add(text);
            }
            List<System.Object> parameters = new List<object>();
            for (int i = 0; i < GameConstants.SAVE_SIZE; i++)
            {
                parameters.Add(i + 1);
            }

            checkSavedData(texts);

            setupTextButtonBoard(texts, loadTextPrefab, loadContent, false, onLoadTextButtonClick, parameters);
        }
        else if (currentGameState == LOAD)
        {
            loadBoardUI.SetActive(false);
            currentGameState = NORMAL;
        }
    }

    public void onLoadTextButtonClick(bool confirmed, System.Object position)
    {
        //Check whether this position has saved data
        string dirPath = Application.persistentDataPath + "/" + GameConstants.SAVE_DIRECTORY + "/" + (int)position;
        if (!Directory.Exists(dirPath))
        {
            return;
        }
        if (!confirmed)
        {
            this.confirmCurrentAction("Do you want to load?", "This action would lose current game data.", onLoadTextButtonClick, position);
            return;
        }
        gameBoardUI.SetActive(true);
        startBoardUI.SetActive(false);
        loadFrom((int)position);
        clickLoadButton();
        return;
    }

    public void checkSavedData(List<string> texts) {
        //Check saved data
        string dirPath = Application.persistentDataPath + "/" + GameConstants.SAVE_DIRECTORY;
        if(!Directory.Exists(dirPath)){
            return;
        }
        string[] filePaths = Directory.GetDirectories(dirPath);
        for (int i = 0; i < filePaths.Length; i++)
        {
            string fileName = Path.GetFileName(filePaths[i]);
            int label;
            if (!Int32.TryParse(fileName, out label))
            {
                Debug.LogError("Saved directory name is modified");
            }
            if (label == 0)
            {
                continue;
            }
            //Read saved time from WorldControl.dat file
            try
            {
                BinaryFormatter bf = new BinaryFormatter();

                FileStream worldControlFile = File.Open(dirPath + "/" + label + "/" + GameConstants.WORLD_CONTROL + GameConstants.SAVE_FILE_EXTENSION, FileMode.Open);
                WorldControlData worldControlData = (WorldControlData)bf.Deserialize(worldControlFile);
                worldControlFile.Close();

                texts[label - 1] = "No." + (label) + "\n" + worldControlData.saveTime;
            }
            catch (IOException ex)
            {
                Debug.LogError("IO error when saving: " + ex.Message);
            }
        }
    }

    public void saveTo(int label) {
        this.worldControlData.saveTime = DateTime.Now.ToString("yyyy/MM/dd h:mm tt");

        string dirPath = Application.persistentDataPath + "/" + GameConstants.SAVE_DIRECTORY + "/" + label;
        Debug.Log("dirPath: " + dirPath);
        try
        {
            if (Directory.Exists(dirPath))
            {
                //Delete original saved files, then create new directory
                Directory.Delete(dirPath, true);
                //FileUtil.DeleteFileOrDirectory(dirPath);
            }
            Directory.CreateDirectory(dirPath);

            BinaryFormatter bf = new BinaryFormatter();

            WorldControlData worldControlData = this.GetComponent<WorldControl>().worldControlData;
            FileStream worldControlFile = File.Create(dirPath + "/" + GameConstants.WORLD_CONTROL + GameConstants.SAVE_FILE_EXTENSION);
            bf.Serialize(worldControlFile, worldControlData);
            worldControlFile.Close();

            WorldData worldData = world.GetComponent<World>().worldData;
            FileStream worldFile = File.Create(dirPath + "/" + ScriptKeyword.WORLD + GameConstants.SAVE_FILE_EXTENSION);
            bf.Serialize(worldFile, worldData);
            worldFile.Close();

            foreach (KeyValuePair<string, GameObject> idCharacterPair in characters)
            {
                CharacterData characterData = idCharacterPair.Value.GetComponent<Character>().characterData;
                FileStream characterFile = File.Create(dirPath + "/" + idCharacterPair.Key + GameConstants.SAVE_FILE_EXTENSION);
                bf.Serialize(characterFile, characterData);
                characterFile.Close();
            }
        }
        catch (IOException ex)
        {
            Debug.LogError("IO error when saving: " + ex.Message);
            //EditorUtility.DisplayDialog("Save failed", "Please try again", "yes", "");
        }
    }

    public void loadFrom(int label) {
        string dirPath = Application.persistentDataPath + "/" + GameConstants.SAVE_DIRECTORY + "/" + label;
        try
        {
            if (!Directory.Exists(dirPath))
            {
                return;
            }

            BinaryFormatter bf = new BinaryFormatter();

            FileStream worldFile = File.Open(dirPath + "/" + ScriptKeyword.WORLD + GameConstants.SAVE_FILE_EXTENSION, FileMode.Open);
            WorldData worldData = (WorldData)bf.Deserialize(worldFile);
            worldFile.Close();

            //recover the world
            world.GetComponent<World>().loadData(worldData);

            List<CharacterData> characterDatas = new List<CharacterData>();
            Debug.Log("dirPath: " + dirPath);
            string[] filePaths = Directory.GetFiles(dirPath);

            for(int i=0; i<filePaths.Length; i++){
                if (filePaths[i].EndsWith(ScriptKeyword.WORLD + GameConstants.SAVE_FILE_EXTENSION) ||
                    filePaths[i].EndsWith(GameConstants.WORLD_CONTROL + GameConstants.SAVE_FILE_EXTENSION))
                {
                    continue;
                }
                FileStream characterFile = File.Open(filePaths[i], FileMode.Open);
                CharacterData characterData = (CharacterData)bf.Deserialize(characterFile);
                characterFile.Close();

                characterDatas.Add(characterData);
            }

            //recover characters in game
            foreach (KeyValuePair<string, GameObject> idCharacterPair in characters){
                Destroy(idCharacterPair.Value, 0f);
            }
            characters.Clear();

            //Create new needed characters
            for (int i = 0; i < characterDatas.Count; i++ )
            {
                GameObject newCharacter = createNewCharacter(characterDatas[i].id);
                this.characters.Add(characterDatas[i].id, newCharacter);

                newCharacter.GetComponent<Character>().loadData(characterDatas[i]);
            }

            //recover world control setting
            FileStream worldControlFile = File.Open(dirPath + "/" + GameConstants.WORLD_CONTROL + GameConstants.SAVE_FILE_EXTENSION, FileMode.Open);
            WorldControlData worldControlData = (WorldControlData)bf.Deserialize(worldControlFile);
            worldControlFile.Close();

            this.loadData(worldControlData);
        }
        catch (IOException ex)
        {
            Debug.LogError("IO error when saving: " + ex.Message);
            //EditorUtility.DisplayDialog("Load failed", "Please try again", "yes", "");
        }
    }

    public void clickAutoButton() {
        if (currentGameState == NORMAL)
        {
            //Enter AUTO state
            currentGameState = AUTO;
            //Click once now
            nextAutoClickTime = 0f;
        }
        else if(currentGameState == AUTO){ 
            //Leave AUTO state
            currentGameState = NORMAL;
        }
    }

    public void clickSkipButton() {
        if (currentGameState == NORMAL && startBoardUI.activeSelf == false)
        {
            currentGameState = SKIP;
            //Start skip mode, here could modify the speed of skip
            InvokeRepeating("step", 0.1f, 0.3f);
        }
        else if (currentGameState == SKIP)
        {
            //Stop skip mode
            CancelInvoke("step");
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

    public void confirmCurrentAction(string title, string message, UnityAction<bool> clickButtonWithYes) {
        confirmBoardUI.SetActive(true);
        confirmBoardUI.GetComponent<ModalPanel>().Choice(title, message, clickButtonWithYes);
    }
    public void confirmCurrentAction(string title, string message, UnityAction<bool, System.Object> clickButtonWithYes, System.Object yesParameter)
    {
        confirmBoardUI.SetActive(true);
        confirmBoardUI.GetComponent<ModalPanel>().Choice(title, message, clickButtonWithYes, yesParameter);
    }

    public void valueChangedScreenMode(int value) {
        PlayerPrefs.SetInt(GameConstants.CONFIG_SCREEN_MODE, value);

        //To be done
        PlayerPrefs.Save();
    }
    public void valueChangedBgmVolume(float value) {
        PlayerPrefs.SetFloat(GameConstants.CONFIG_BGM_VOLUME, value);

        GameObject[] backgroundGameObjects = GameObject.FindGameObjectsWithTag("Background");
        for (int i = 0; i < backgroundGameObjects.Length; i++ )
        {
            backgroundGameObjects[i].GetComponent<AudioSource>().volume = value;
        }
        PlayerPrefs.Save();
    }
    public void valueChangedSeVolume(float value)
    {
        PlayerPrefs.SetFloat(GameConstants.CONFIG_SE_VOLUME, value);

        GameObject[] worldGameObjects = GameObject.FindGameObjectsWithTag("World");
        for (int i = 0; i < worldGameObjects.Length; i++)
        {
            worldGameObjects[i].GetComponent<AudioSource>().volume = value;
        }
        PlayerPrefs.Save();
    }
    public void valueChangedVoiceVolume(float value)
    {
        PlayerPrefs.SetFloat(GameConstants.CONFIG_VOICE_VOLUME, value);

        GameObject[] characterGameObjects = GameObject.FindGameObjectsWithTag("Character");
        for (int i = 0; i < characterGameObjects.Length; i++)
        {
            characterGameObjects[i].GetComponent<AudioSource>().volume = value;
        }
        PlayerPrefs.Save();
    }
    public void valueChangedTextSpeed(float value)
    {
        PlayerPrefs.SetFloat(GameConstants.CONFIG_TEXT_SPEED, value);
        PlayerPrefs.Save();
    }
    
    public void valueChangedAutoSpeed(float value)
    {
        PlayerPrefs.SetFloat(GameConstants.CONFIG_AUTO_SPEED, value);
        PlayerPrefs.Save();
    }

    public void clickTitleButton(bool confirmed) {
        if (!confirmed)
        {
            confirmCurrentAction("Do you want to go back to title?", "This action would lose current game data.", clickTitleButton);
            return;
        }
        Application.LoadLevel(0); 
    }
}
