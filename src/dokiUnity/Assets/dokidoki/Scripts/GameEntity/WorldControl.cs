using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
//using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using dokiScriptSetting;
using Action = dokiScriptSetting.Action;


namespace dokiUnity {
    /// <summary>
    /// WorldControl is a GameObject, represents the controller of the world, used to distribute actions to World or Characters to take, and also itself could take some actinos to manipulate the flow the game.
    /// Those actions contain: JumpAction, FlagAction.
    /// In addition, WorldControls contain all setting operation of the world for all UI components.
    /// WorldControl could save and load the game, change the volume, screen size, and other game commands like auto, skip.
    /// </summary>
    public class WorldControl : MonoBehaviour {
        /// <summary>
        /// worldControlData records status for saving and loading
        /// </summary>
        public WorldControlData worldControlData = new WorldControlData();

        /// <summary>
        /// scriptReader is used to load dokiScripts from resources
        /// </summary>
        private ScriptReader scriptReader;

        /// <summary>
        /// currentActions are loaded script actions needed to distribute to take
        /// </summary>
        private List<Action> currentActions;

        /// <summary>
        /// record lastAction to do something, like decide when should SkipAction be taken
        /// </summary>
        private Action lastAction;

        /// <summary>
        /// world is the pointer of the World GameObject, for worldControl to distribute actions to them
        /// </summary>
        public GameObject world;

        /// <summary>
        /// characters is a dictionary of all characters, for worldControl to distribute actions to them
        /// </summary>
        public Dictionary<string, GameObject> characters = new Dictionary<string, GameObject>();

        /// <summary>
        /// focusGameObject is used to know current actions should distribute to whom
        /// </summary>
        private GameObject focusGameObject;


        //In play UI gameobjects
        /// <summary>
        /// gameBoardUI pointer is used to show and hide gameBoard
        /// </summary>
        public GameObject gameBoardUI;

        /// <summary>
        /// quickButtonsUI pointer is used to show and hide quickButtons
        /// </summary>
        public GameObject quickButtonsUI;

        /// <summary>
        /// dialogBoardUI pointer is used to show and hide dialogBoard
        /// </summary>
        public GameObject dialogBoardUI;

        /// <summary>
        /// dialogContent pointer is a child of dialogContent GameObject, used to change the content of dialogBoard, such as dialog text
        /// </summary>
        public GameObject dialogContent;

        /// <summary>
        /// flagBoardUI pointer is used to show and hide flagBoard
        /// </summary>
        public GameObject flagBoardUI;

        /// <summary>
        /// flagContent pointer is a child of flagBoard GameObject, used to change the content of flagBoard, such as a set flagText Buttons
        /// </summary>
        public GameObject flagContent;

        /// <summary>
        /// backLogBoardUI pointer is used to show and hide backLog
        /// </summary>
        public GameObject backLogBoardUI;

        //UI content pointers are used to shown content of UI
        /// <summary>
        /// backLogContent pointer is a child of backLogBoard GameObject, used to change the content of backgroundBoard, such as a set logText Buttons
        /// </summary>
        public GameObject backLogContent;

        /// <summary>
        /// titleBoardUI pointer is used to show and hide startBoard
        /// </summary>
        public GameObject titleBoardUI;

        /// <summary>
        /// saveBoardUI pointer is used to show and hide saveBoard
        /// </summary>
        public GameObject saveBoardUI;

        /// <summary>
        /// saveContent pointer is a child of saveBoard GameObject, used to change the content of saveBoard, such as a set saveText Buttons
        /// </summary>
        public GameObject saveContent;

        /// <summary>
        /// loadBoardUI pointer is used to show and hide loadBoard
        /// </summary>
        public GameObject loadBoardUI;

        /// <summary>
        /// loadContent pointer is a child of loadBoard GameObject, used to change the content of loadBoard, such as a set loadText Buttons
        /// </summary>
        public GameObject loadContent;

        /// <summary>
        /// configBoardUI pointer is used to show and hide configBoard
        /// </summary>
        public GameObject configBoardUI;

        /// <summary>
        /// confirmBoardUI pointer is used to show and hide confirmBoard
        /// </summary>
        public GameObject confirmBoardUI;

        //prefabs pointer used to initiate new GameObjects at runtime
        /// <summary>
        /// characterPrefab is a unity prefab, used to create new character, when a new character appear to take some actions
        /// </summary>
        public GameObject characterPrefab;

        /// <summary>
        /// logTextPrefab is a unity prefab, used to create new logText Buttons when logBoard is shown
        /// </summary>
        public GameObject logTextPrefab;

        /// <summary>
        /// saveTextPrefab is a unity prefab, used to create new saveText Buttons when saveBoard is shown
        /// </summary>
        public GameObject saveTextPrefab;

        /// <summary>
        /// loadTextPrefab is a unity prefab, used to create new loadText Buttons when loadBoard is shown
        /// </summary>
        public GameObject loadTextPrefab;

        /// <summary>
        /// flagTextPrefab is a unity prefab, used to create new flagText Buttons when flagBoard is shown
        /// </summary>
        public GameObject flagTextPrefab;



        /// <summary>
        /// get the dialogMode in the game config, normal or bubble
        /// </summary>
        /// <returns>the dialogMode value</returns>
        public string getDialogMode() {
            return this.worldControlData.dialogMode;
        }

        /// <summary>
        /// UI shown or hidden setting when game on startBoard
        /// </summary>
        void Awake() {
            if (scriptReader == null) {
                scriptReader = new ScriptReader();
            }
            //Show title board only when game starts up
            gameBoardUI.SetActive(false);
            flagBoardUI.SetActive(false);
            backLogBoardUI.SetActive(false);
            titleBoardUI.SetActive(true);
            saveBoardUI.SetActive(false);
            loadBoardUI.SetActive(false);
            configBoardUI.SetActive(false);
            configBoardUI.SetActive(false);
        }

        /// <summary>
        /// Mouse and Key command to call game operation fuctions.
        /// Click in normal mode and not on a button to step the game.
        /// Click on button to call specific button functions.
        /// Also, shortcut key equals to click on the responding button.
        /// Ctrl key is used to skip game.
        /// </summary>
        void Update() {
            if (Input.GetMouseButtonDown(1)) {
                if (this.worldControlData.currentGameState == GameConstants.BACKLOG) {
                    clickBackLogButton();
                    return;
                } else if (this.worldControlData.currentGameState == GameConstants.SAVE) {
                    clickSaveButton();
                    return;
                } else if (this.worldControlData.currentGameState == GameConstants.LOAD) {
                    clickLoadButton();
                    return;
                } else if (this.worldControlData.currentGameState == GameConstants.HIDE || this.worldControlData.currentGameState == GameConstants.NORMAL) {
                    if (gameBoardUI.activeSelf) {
                        clickHideButton();
                    }
                    return;
                } else if (this.worldControlData.currentGameState == GameConstants.CONFIG) {
                    clickConfigButton();
                    return;
                }
            }

            //Skip key pressed
            if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)) {
                clickSkipButton();
            }
            if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl)) {
                clickSkipButton();
            }

            //Hot key
            //Return key could be used as click
            if (Input.GetKeyDown(KeyCode.Return)) {
                if (titleBoardUI.activeSelf == true) {
                    clickStartButton();
                } else {
                    step();
                }
            } else if (Input.GetKeyDown(KeyCode.C)) {
                clickConfigButton();
            } else if (Input.GetKeyDown(KeyCode.B)) {
                clickBackLogButton();
            } else if (Input.GetKeyDown(KeyCode.Q) && Input.GetKeyDown(KeyCode.S)) {
                clickQuickSaveButton(false);
            } else if (Input.GetKeyDown(KeyCode.Q) && Input.GetKeyDown(KeyCode.L)) {
                clickQuickLoadButton(false);
            } else if (Input.GetKeyDown(KeyCode.S)) {
                clickSaveButton();
            } else if (Input.GetKeyDown(KeyCode.L)) {
                clickLoadButton();
            } else if (Input.GetKeyDown(KeyCode.A)) {
                clickAutoButton();
            } else if (Input.GetKeyDown(KeyCode.H)) {
                clickHideButton();
            }
        }

        /// <summary>
        /// this function is used for auto mode, to call step function after nextAutoClickTime
        /// </summary>
        void FixedUpdate() {
            if (this.worldControlData.currentGameState == GameConstants.AUTO) {
                float currentTime = Time.realtimeSinceStartup;
                //Auto click
                if (currentTime > this.worldControlData.nextAutoClickTime) {
                    //Debug.Log("Auto click");
                    //Click once, wait for next time update
                    this.worldControlData.nextAutoClickTime = Mathf.Infinity;
                    step();
                }
            }
        }

        /// <summary>
        /// Step the game, which means distribute a set of actions to World or a Character to take, the last action should be ended with the mouse click.
        /// Also, when needs to jump to another script or take flag action, worldControl itself takes them
        /// </summary>
        public void step() {
            //Debug.Log(++count);
            //Check game state first
            if (this.worldControlData.currentGameState == GameConstants.BACKLOG) {
                clickBackLogButton();
                return;
            } else if (this.worldControlData.currentGameState == GameConstants.AUTO) {
                this.worldControlData.nextAutoClickTime = Mathf.Infinity;
            } else if (this.worldControlData.currentGameState == GameConstants.SAVE) {
                clickSaveButton();
                return;
            } else if (this.worldControlData.currentGameState == GameConstants.LOAD) {
                clickLoadButton();
                return;
            } else if (this.worldControlData.currentGameState == GameConstants.HIDE) {
                clickHideButton();
                return;
            } else if (this.worldControlData.currentGameState == GameConstants.FLAG) {
                return;
            }

            //If in NORMAL state, plays the game normally
            if (currentActions == null || currentActions.Count < 1) {
                //To be done
                currentActions = scriptReader.loadNextScript();
                if (currentActions == null) {
                    Debug.Log("Fin");
                    clickExitButton(false);
                    return;
                }
            }
            if (lastAction != null && lastAction.tag == ScriptKeyword.VIDEO) {
                world.GetComponent<World>().skipVideoAction();
                showInPlayUI();
            }
            while (currentActions.Count > 0) {
                Action currentAction = currentActions[0];
                //store last action
                lastAction = currentAction;
                //Save the last text content
                if (currentAction.tag == ScriptKeyword.TEXT || currentAction.tag == ScriptKeyword.VOICE) {
                    worldControlData.textContent = currentAction.parameters[ScriptKeyword.CONTENT];
                }
                //remove already completed action
                currentActions.RemoveAt(0);



                if (currentAction.tag == ScriptKeyword.FOCUS) {
                    this.takeFocusAction(currentAction);
                }
                if (focusGameObject == null) {
                    Debug.LogError(ScriptError.NOT_FOCUS_OBJECT);
                    return;
                }
                if (currentAction.tag == ScriptKeyword.BACKGROUND) {
                    focusGameObject.GetComponent<World>().takeBackgroundAction(currentAction);
                } else if (currentAction.tag == ScriptKeyword.WEATHER) {
                    focusGameObject.GetComponent<World>().takeWeatherAction(currentAction);
                } else if (currentAction.tag == ScriptKeyword.SOUND) {
                    focusGameObject.GetComponent<World>().takeSoundAction(currentAction);
                } else if (currentAction.tag == ScriptKeyword.BGM) {
                    focusGameObject.GetComponent<World>().takeBgmAction(currentAction);
                } else if (currentAction.tag == ScriptKeyword.VIDEO) {
                    hideInPlayUI();
                    updateNextAutoClickTime(focusGameObject.GetComponent<World>().takeVideoAction(currentAction));
                    //wait next click for video action
                    break;
                } else if (currentAction.tag == ScriptKeyword.TEXT) {
                    if (focusGameObject.GetComponent<World>() != null) {
                        updateNextAutoClickTime(focusGameObject.GetComponent<World>().takeTextAction(currentAction));
                    }
                    if (focusGameObject.GetComponent<Character>() != null) {
                        updateNextAutoClickTime(focusGameObject.GetComponent<Character>().takeTextAction(currentAction));
                    }
                    break;
                } else if (currentAction.tag == ScriptKeyword.MOVE) {
                    focusGameObject.GetComponent<Character>().takeMoveAction(currentAction);
                } else if (currentAction.tag == ScriptKeyword.POSTURE) {
                    focusGameObject.GetComponent<Character>().takePostureAction(currentAction);
                } else if (currentAction.tag == ScriptKeyword.VOICE) {
                    updateNextAutoClickTime(focusGameObject.GetComponent<Character>().takeVoiceAction(currentAction));
                    break;
                } else if (currentAction.tag == ScriptKeyword.ROLE) {
                    focusGameObject.GetComponent<Character>().takeRoleAction(currentAction);
                } else if (currentAction.tag == ScriptKeyword.FLAG) {
                    this.takeFlagAction(currentAction);
                    break;
                } else if (currentAction.tag == ScriptKeyword.JUMP) {
                    this.takeJumpAction(currentAction);
                }
            }
        }

        /// <summary>
        /// WorldControl takes focus action to change current focusedGameObject that further is the target to distribute actions to
        /// </summary>
        /// <param name="focusAction">Action tagged as focus, which contains the parameters for focus setting</param>
        public void takeFocusAction(Action focusAction) {
            worldControlData.focusGameObjectId = focusAction.parameters[ScriptKeyword.ID];

            focusGameObject = null;
            //focus on object to take further actions
            if (focusAction.parameters[ScriptKeyword.ID] == ScriptKeyword.WORLD) {
                focusGameObject = world;
            } else {
                if (!characters.ContainsKey(focusAction.parameters[ScriptKeyword.ID])) {
                    //there is no character on this id, create one
                    characters.Add(focusAction.parameters[ScriptKeyword.ID], createNewCharacter(focusAction.parameters[ScriptKeyword.ID]));
                }
                focusGameObject = characters[focusAction.parameters[ScriptKeyword.ID]];
            }
        }

        /// <summary>
        /// WorldControl takes flag action to show flagBoard, wait for user to choose
        /// </summary>
        /// <param name="flagAction">Action tagged as flag, which contains the parameters for flag setting</param>
        public void takeFlagAction(Action flagAction) {
            if (this.worldControlData.currentGameState == GameConstants.AUTO) {
                clickAutoButton();
            }
            if (this.worldControlData.currentGameState == GameConstants.SKIP) {
                clickSkipButton();
            }
            if (this.worldControlData.currentGameState == GameConstants.NORMAL) {
                this.worldControlData.currentGameState = GameConstants.FLAG;
                flagBoardUI.SetActive(true);

                string count;
                if (flagAction.parameters.TryGetValue(ScriptKeyword.COUNT, out count)) {
                    List<string> texts = new List<string>();
                    for (int i = 0; i < int.Parse(count); i++) {
                        string text = flagAction.parameters[ScriptKeyword.OPTION_ + (i + 1)];
                        texts.Add(text);
                    }
                    List<System.Object> parameters = new List<object>();
                    for (int i = 0; i < int.Parse(count); i++) {
                        List<string> optionParameter = new List<string>();
                        optionParameter.Add("" + (i + 1));
                        optionParameter.Add(flagAction.parameters[ScriptKeyword.OPTION_ + (i + 1)]);
                        optionParameter.Add(flagAction.parameters[ScriptKeyword.OPTION_ID_ + (i + 1)]);
                        optionParameter.Add(flagAction.parameters[ScriptKeyword.OPTION_SRC_ + (i + 1)]);

                        parameters.Add(optionParameter);
                    }

                    setupTextButtonBoard(texts, flagTextPrefab, flagContent, false, onFlagTextButtonClick, parameters);
                }
            }
        }

        /// <summary>
        /// This functions is called when player clicks on a flagTextButton, which represents a option.
        /// And then jump to that option by loading new scripts
        /// </summary>
        /// <param name="confirmed">Whether to do operations directly, or pop up a confirm window to ask for confirmation</param>
        /// <param name="optionParameter">OptionParameter constains the infomation about player's choice</param>
        public void onFlagTextButtonClick(bool confirmed, System.Object optionParameter) {
            this.worldControlData.worldLine += ((List<string>)optionParameter)[0];

            if (this.worldControlData.currentGameState == GameConstants.FLAG) {
                flagBoardUI.SetActive(false);
                this.worldControlData.currentGameState = GameConstants.NORMAL;
            }

            //Debug.Log("((List<string>)optionParameter)[0]: " + ((List<string>)optionParameter)[0]);
            //Debug.Log("((List<string>)optionParameter)[1]: " + ((List<string>)optionParameter)[1]);
            //Debug.Log("((List<string>)optionParameter)[2]: " + ((List<string>)optionParameter)[2]);
            //Debug.Log("((List<string>)optionParameter)[3]: " + ((List<string>)optionParameter)[3]);

            if (!scriptReader.currentScriptName.Equals(((List<string>)optionParameter)[3])) {
                currentActions = scriptReader.loadNextScript(((List<string>)optionParameter)[3]);
            }

            //Jump to this option
            while (true) {
                //Remove current action until find the specific Option action
                if (currentActions[0].tag.Equals(ScriptKeyword.OPTION) && currentActions[0].parameters[ScriptKeyword.ID].Equals(((List<string>)optionParameter)[2])) {
                    currentActions.RemoveAt(0);
                    break;
                } else {
                    currentActions.RemoveAt(0);
                }
            }

            this.step();
        }

        /// <summary>
        /// WorldControl takes jump action to jump to specific scripts
        /// </summary>
        /// <param name="jumpAction">Action tagged as jump, which contains the parameters for jump setting</param>
        public void takeJumpAction(Action jumpAction) {
            Debug.Log("Jump to: " + jumpAction.parameters[ScriptKeyword.SRC]);
            currentActions = scriptReader.loadNextScript(jumpAction.parameters[ScriptKeyword.SRC]);
        }

        /// <summary>
        /// Create new character GameObject with id
        /// </summary>
        /// <param name="id">Id of new character in scripts</param>
        /// <returns>The GameObject pointer of the new character GameObject</returns>
        public GameObject createNewCharacter(string id) {
            GameObject newCharacter = Instantiate(characterPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            newCharacter.transform.parent = this.world.transform;
            newCharacter.GetComponent<Character>().characterData.id = id;
            newCharacter.GetComponent<Character>().dialogContent = this.world.GetComponent<World>().dialogContent;
            newCharacter.GetComponent<Character>().worldControl = this.gameObject;
            newCharacter.GetComponentInChildren<BubbleManager>().hide();
            return newCharacter;
        }
        /// <summary>
        /// Hide gameBoard UI
        /// </summary>
        public void hideInPlayUI() {
            dialogBoardUI.SetActive(false);
            quickButtonsUI.SetActive(false);
        }
        /// <summary>
        /// show gameBoard UI
        /// </summary>
        public void showInPlayUI() {
            dialogBoardUI.SetActive(true);
            quickButtonsUI.SetActive(true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dialog">The dialog to display on the logTextButton</param>
        /// <returns>GameObject pointer to the new created LogTextButton</returns>
        public GameObject createLogTextButton(Dialog dialog) {
            GameObject newLogTextButton = Instantiate(logTextPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            newLogTextButton.transform.SetParent(this.backLogContent.transform);
            newLogTextButton.transform.localPosition = new Vector3(0, -newLogTextButton.GetComponent<RectTransform>().rect.height, 0);
            string dialogText = "";
            if (dialog.shownName != "") {
                dialogText = dialogText + dialog.shownName + ": ";
            }
            dialogText = dialogText + dialog.content;
            newLogTextButton.GetComponentInChildren<Text>().text = dialogText;
            return newLogTextButton;
        }

        /// <summary>
        /// this function is used to create a new textButton from TextPrefab which its appearence could be custumized by developers
        /// </summary>
        /// <param name="text">Text display on the button</param>
        /// <param name="prefab">TextPrefab defines the new created button's appearence</param>
        /// <param name="parentGameObject">Create new textButton to be a child of this parentGameObject</param>
        /// <param name="onclick">Call the onclick function when this new created button is clicked</param>
        /// <param name="parameter">Attach some paramenters to this new created button, the parameter would be passed to the onclick function</param>
        /// <returns>Return the GameObject pointer of the new created TextButton</returns>
        public GameObject createTextButton(string text, GameObject prefab, GameObject parentGameObject, UnityAction<bool, System.Object> onclick, System.Object parameter) {
            GameObject newTextButton = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            newTextButton.transform.SetParent(parentGameObject.transform);
            newTextButton.transform.localPosition = new Vector3(0, -newTextButton.GetComponent<RectTransform>().rect.height, 0);
            newTextButton.GetComponentInChildren<Text>().text = text;
            newTextButton.GetComponent<Button>().onClick.AddListener(() => { onclick(false, parameter); });
            return newTextButton;
        }
        /// <summary>
        /// Create the content of a board, which content is a set of TextButton.
        /// </summary>
        /// <param name="texts">The text array should be displayed on a set of TextButtons</param>
        /// <param name="buttonPrefab">prefab of the TextButton, which could be customized by developers</param>
        /// <param name="contentGameObject">parent GameObject that the created a set of TextButtons should be child of</param>
        /// <param name="toBottom">whether the content of board should scroll to bottom when shown</param>
        /// <param name="onclick">function to be called when responding TextButton is clicked</param>
        /// <param name="parameters">parameter array should be attached to the TextButton and would be passed to the on click function</param>
        public void setupTextButtonBoard(List<string> texts, GameObject buttonPrefab, GameObject contentGameObject, bool toBottom, UnityAction<bool, System.Object> onclick, List<System.Object> parameters) {
            //Destroy all previous text buttons
            for (int i = 0; i < contentGameObject.transform.childCount; i++) {
                GameObject.Destroy(contentGameObject.transform.GetChild(i).gameObject);
            }

            //Create a list of log text button
            List<GameObject> textButtons = new List<GameObject>();
            for (int i = 0; i < texts.Count; i++) {
                GameObject newTextButton = this.createTextButton(texts[i], buttonPrefab, contentGameObject, onclick, parameters[i]);
                if (textButtons.Count > 0) {
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
            if (toBottom) {
                contentGameObject.GetComponentInParent<ScrollRect>().normalizedPosition = new Vector2(0, 0);
            }
        }


        //StartBoard button functions
        /// <summary>
        /// Called when StartButton is clicked, to start the game from beginning
        /// </summary>
        public void clickStartButton() {
            titleBoardUI.SetActive(false);
            gameBoardUI.SetActive(true);
            step();
        }
        /// <summary>
        /// Called when ConfigButton is clicked, to show or hide ConfigBoard
        /// </summary>
        public void clickConfigButton() {
            if (this.worldControlData.currentGameState == GameConstants.NORMAL) {
                this.worldControlData.currentGameState = GameConstants.CONFIG;
                configBoardUI.SetActive(true);
            } else if (this.worldControlData.currentGameState == GameConstants.CONFIG) {
                configBoardUI.SetActive(false);
                this.worldControlData.currentGameState = GameConstants.NORMAL;
            }
        }
        /// <summary>
        /// Called when ExitButton is clicked, to exit game which needs confirmation from poped up ConfirmBoard
        /// </summary>
        /// <param name="confirmed"></param>
        public void clickExitButton(bool confirmed) {
            if (!confirmed) {
                confirmCurrentAction("Do you want to exit?", "This action would lose current game data.", clickExitButton);
                return;
            }
            Application.Quit();
        }


        //Quick button functions
        /// <summary>
        /// Called when BackLogButton is clicked, to show or hide BackLogBoard, which needs updates BackLog, creates new BackLogTextButtons before show BackLogBoard
        /// </summary>
        public void clickBackLogButton() {
            if (this.worldControlData.currentGameState == GameConstants.NORMAL) {
                //Open backlog window
                this.worldControlData.currentGameState = GameConstants.BACKLOG;
                backLogBoardUI.SetActive(true);

                //Get texts to display
                List<Dialog> historyDialogs = dialogContent.GetComponent<DialogManager>().historyDialogs;
                List<string> texts = new List<string>();
                for (int i = 0; i < historyDialogs.Count; i++) {
                    string dialogText = "";
                    if (historyDialogs[i].shownName != "") {
                        dialogText = dialogText + historyDialogs[i].shownName + ": ";
                    }
                    dialogText = dialogText + historyDialogs[i].content;
                    texts.Add(dialogText);
                }
                List<System.Object> parameters = new List<object>();
                for (int i = 0; i < historyDialogs.Count; i++) {
                    parameters.Add(historyDialogs[i].voiceSrc);
                }
                //Set up log text buttons board
                setupTextButtonBoard(texts, logTextPrefab, backLogContent, true, onLogTextButtonClick, parameters);
            } else if (this.worldControlData.currentGameState == GameConstants.BACKLOG) {
                //close backlog window
                backLogBoardUI.SetActive(false);
                this.worldControlData.currentGameState = GameConstants.NORMAL;
            }
        }
        /// <summary>
        /// Called when LogTextButton is clicked, used to replay the voice audio, which needs confirmation from poped up ConfirmBoard
        /// </summary>
        /// <param name="confirmed">Whether current action is confirmed or not</param>
        /// <param name="voiceSrc">Name of voice audio to replay</param>
        public void onLogTextButtonClick(bool confirmed, System.Object voiceSrc) {
            //Debug.Log("voiceSrc: " + voiceSrc);
            //The log voice plays on the AudioSource from the world, ...need further thinking
            if (voiceSrc != null && !voiceSrc.Equals("")) {
                AudioClip voiceAudioClip = Resources.Load(FolderStructure.CHARACTERS + FolderStructure.VOICES + voiceSrc) as AudioClip;
                world.GetComponent<AudioSource>().clip = voiceAudioClip;
                world.GetComponent<AudioSource>().Play();
            }
            return;
        }
        /// <summary>
        /// Called when QuickSaveButton is clicked, used to save current game to 0 position, which needs confirmation from poped up ConfirmBoard
        /// </summary>
        /// <param name="confirmed">Whether current action is confirmed or not</param>
        public void clickQuickSaveButton(bool confirmed) {
            if (!confirmed) {
                this.confirmCurrentAction("Do you want to quick save?", "This action would overwrite the original saved data.", clickQuickSaveButton);
                return;
            }
            saveTo(0);
        }
        /// <summary>
        /// Called when QuickLoadButton is clicked, used to load game from 0 position, which needs confirmation from poped up ConfirmBoard
        /// </summary>
        /// <param name="confirmed">Whether current action is confirmed or not</param>
        public void clickQuickLoadButton(bool confirmed) {
            //Check whether this position has saved data
            string dirPath = Application.persistentDataPath + "/" + GameConstants.SAVE_DIRECTORY + "/0";
            if (!Directory.Exists(dirPath)) {
                return;
            }
            if (!confirmed) {

                this.confirmCurrentAction("Do you want to quick load?", "This action would lose current game data.", clickQuickLoadButton);
                return;
            }
            gameBoardUI.SetActive(true);
            titleBoardUI.SetActive(false);
            loadFrom(0);
        }
        /// <summary>
        /// Called when SaveButton is clicked, to show or hide SaveBoard, which needs updates SaveTextButton, creates new SaveTextButton before show SaveBoard
        /// </summary>
        public void clickSaveButton() {
            if (this.worldControlData.currentGameState == GameConstants.NORMAL) {
                this.worldControlData.currentGameState = GameConstants.SAVE;
                saveBoardUI.SetActive(true);

                List<string> texts = new List<string>();
                for (int i = 0; i < GameConstants.SAVE_SIZE; i++) {
                    string text = "No." + (i + 1) + "\n" + GameConstants.SAVE_DEFAULT;
                    texts.Add(text);
                }
                List<System.Object> parameters = new List<object>();
                for (int i = 0; i < GameConstants.SAVE_SIZE; i++) {
                    parameters.Add(i + 1);
                }

                checkSavedData(texts);

                setupTextButtonBoard(texts, saveTextPrefab, saveContent, false, onSaveTextButtonClick, parameters);
            } else if (this.worldControlData.currentGameState == GameConstants.SAVE) {
                saveBoardUI.SetActive(false);
                this.worldControlData.currentGameState = GameConstants.NORMAL;
            }
        }
        /// <summary>
        /// Called when SaveTextButton is clicked, used to save current game to specific postion, which needs confirmation from poped up ConfirmBoard
        /// </summary>
        /// <param name="confirmed">Whether current action is confirmed or not</param>
        /// <param name="position">where current game should save to, exactly the name of saved data folder</param>
        public void onSaveTextButtonClick(bool confirmed, System.Object position) {
            if (!confirmed) {
                this.confirmCurrentAction("Do you want to quick save?", "This action would overwrite the original saved data.", onSaveTextButtonClick, position);
                return;
            }
            saveTo((int)position);
            clickSaveButton();
            return;
        }
        /// <summary>
        /// Called when LoadButton is clicked, to show or hide LoadBoard, which needs updates LoadTextButton, creates new LoadTextButtons before show LoadBoard
        /// </summary>
        public void clickLoadButton() {
            if (this.worldControlData.currentGameState == GameConstants.NORMAL) {
                this.worldControlData.currentGameState = GameConstants.LOAD;
                loadBoardUI.SetActive(true);

                List<string> texts = new List<string>();
                for (int i = 0; i < GameConstants.SAVE_SIZE; i++) {
                    string text = "No." + (i + 1) + "\n" + GameConstants.SAVE_DEFAULT;
                    texts.Add(text);
                }
                List<System.Object> parameters = new List<object>();
                for (int i = 0; i < GameConstants.SAVE_SIZE; i++) {
                    parameters.Add(i + 1);
                }

                checkSavedData(texts);

                setupTextButtonBoard(texts, loadTextPrefab, loadContent, false, onLoadTextButtonClick, parameters);
            } else if (this.worldControlData.currentGameState == GameConstants.LOAD) {
                loadBoardUI.SetActive(false);
                this.worldControlData.currentGameState = GameConstants.NORMAL;
            }
        }
        /// <summary>
        /// Called when LoadTextButton is clicked, used to load game from specific postion, which needs confirmation from poped up ConfirmBoard
        /// </summary>
        /// <param name="confirmed">Whether current action is confirmed or not</param>
        /// <param name="position">where the game should load from, exactly the name of saved data folder</param>
        public void onLoadTextButtonClick(bool confirmed, System.Object position) {
            //Check whether this position has saved data
            string dirPath = Application.persistentDataPath + "/" + GameConstants.SAVE_DIRECTORY + "/" + (int)position;
            if (!Directory.Exists(dirPath)) {
                return;
            }
            if (!confirmed) {
                this.confirmCurrentAction("Do you want to load?", "This action would lose current game data.", onLoadTextButtonClick, position);
                return;
            }
            gameBoardUI.SetActive(true);
            titleBoardUI.SetActive(false);
            loadFrom((int)position);
            clickLoadButton();
            return;
        }
        /// <summary>
        /// Called when SaveBoard or LoadBoard is going to be shown, read saved data from disk and display saved data information
        /// </summary>
        /// <param name="texts">Texts array which saved data information would copy to</param>
        public void checkSavedData(List<string> texts) {
            //Check saved data
            string dirPath = Application.persistentDataPath + "/" + GameConstants.SAVE_DIRECTORY;
            if (!Directory.Exists(dirPath)) {
                return;
            }
            string[] filePaths = Directory.GetDirectories(dirPath);
            for (int i = 0; i < filePaths.Length; i++) {
                string fileName = Path.GetFileName(filePaths[i]);
                int label;
                if (!Int32.TryParse(fileName, out label)) {
                    Debug.LogError("Saved directory name is modified");
                }
                if (label == 0) {
                    continue;
                }
                //Read saved time from WorldControl.dat file
                try {
                    BinaryFormatter bf = new BinaryFormatter();

                    FileStream worldControlFile = File.Open(dirPath + "/" + label + "/" + GameConstants.WORLD_CONTROL + GameConstants.SAVE_FILE_EXTENSION, FileMode.Open);
                    WorldControlData worldControlData = (WorldControlData)bf.Deserialize(worldControlFile);
                    worldControlFile.Close();

                    //Remove worldControlData.textContent's >> or >
                    while (worldControlData.textContent != null && worldControlData.textContent.StartsWith(ScriptKeyword.CLICK)) {
                        worldControlData.textContent = worldControlData.textContent.Substring(1);
                    }
                    texts[label - 1] = "No." + (label) + "\n" + worldControlData.textContent + "    " + worldControlData.saveTime;
                } catch (IOException ex) {
                    Debug.LogError("IO error when saving: " + ex.Message);
                }
            }
        }
        /// <summary>
        /// Called when SaveTextButton is confirmed or QuickSaveButton is confirmed, used to save current game to specified postion
        /// </summary>
        /// <param name="label">Position where current game would be saved to, exactly the name of saved data folder</param>
        public void saveTo(int label) {
            this.worldControlData.currentScriptName = scriptReader.currentScriptName;
            this.worldControlData.currentActionIndex = scriptReader.getCurrentActionIndex();
            this.worldControlData.historyDialogs = dialogContent.GetComponent<DialogManager>().historyDialogs;

            this.worldControlData.saveTime = DateTime.Now.ToString("yyyy/MM/dd h:mm tt");

            Debug.Log("worldControlData.focusGameObjectId: " + this.worldControlData.focusGameObjectId);
            Debug.Log("worldControlData.textContent: " + this.worldControlData.textContent);
            Debug.Log("worldControlData.saveTime: " + this.worldControlData.saveTime);
            Debug.Log("worldControlData.worldLine: " + this.worldControlData.worldLine);
            Debug.Log("worldControlData.currentScriptName: " + this.worldControlData.currentScriptName);
            Debug.Log("worldControlData.currentActionIndex: " + this.worldControlData.currentActionIndex);

            string dirPath = Application.persistentDataPath + "/" + GameConstants.SAVE_DIRECTORY + "/" + label;
            Debug.Log("dirPath: " + dirPath);
            try {
                if (Directory.Exists(dirPath)) {
                    //Delete original saved files, then create new directory
                    Directory.Delete(dirPath, true);
                    //FileUtil.DeleteFileOrDirectory(dirPath);
                }
                Directory.CreateDirectory(dirPath);

                BinaryFormatter bf = new BinaryFormatter();

                FileStream worldControlFile = File.Create(dirPath + "/" + GameConstants.WORLD_CONTROL + GameConstants.SAVE_FILE_EXTENSION);
                bf.Serialize(worldControlFile, worldControlData);
                worldControlFile.Close();

                WorldData worldData = world.GetComponent<World>().worldData;
                FileStream worldFile = File.Create(dirPath + "/" + ScriptKeyword.WORLD + GameConstants.SAVE_FILE_EXTENSION);
                bf.Serialize(worldFile, worldData);
                worldFile.Close();

                foreach (KeyValuePair<string, GameObject> idCharacterPair in characters) {
                    CharacterData characterData = idCharacterPair.Value.GetComponent<Character>().characterData;
                    FileStream characterFile = File.Create(dirPath + "/" + idCharacterPair.Key + GameConstants.SAVE_FILE_EXTENSION);
                    bf.Serialize(characterFile, characterData);
                    characterFile.Close();
                }
            } catch (IOException ex) {
                Debug.LogError("IO error when saving: " + ex.Message);
                //EditorUtility.DisplayDialog("Save failed", "Please try again", "yes", "");
            }
        }
        /// <summary>
        /// Called when LoadTextButton is confirmed or QuickLoadButton is confirmed, used to load game from specified postion
        /// </summary>
        /// <param name="label">Position where game would load from, exactly the name of saved data folder</param>
        public void loadFrom(int label) {
            string dirPath = Application.persistentDataPath + "/" + GameConstants.SAVE_DIRECTORY + "/" + label;
            try {
                if (!Directory.Exists(dirPath)) {
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

                for (int i = 0; i < filePaths.Length; i++) {
                    if (filePaths[i].EndsWith(ScriptKeyword.WORLD + GameConstants.SAVE_FILE_EXTENSION) ||
                        filePaths[i].EndsWith(GameConstants.WORLD_CONTROL + GameConstants.SAVE_FILE_EXTENSION)) {
                        continue;
                    }
                    FileStream characterFile = File.Open(filePaths[i], FileMode.Open);
                    CharacterData characterData = (CharacterData)bf.Deserialize(characterFile);
                    characterFile.Close();

                    characterDatas.Add(characterData);
                }

                //recover characters in game
                foreach (KeyValuePair<string, GameObject> idCharacterPair in characters) {
                    Destroy(idCharacterPair.Value, 0f);
                }
                characters.Clear();

                //Create new needed characters
                for (int i = 0; i < characterDatas.Count; i++) {
                    GameObject newCharacter = createNewCharacter(characterDatas[i].id);
                    this.characters.Add(characterDatas[i].id, newCharacter);

                    newCharacter.GetComponent<Character>().loadData(characterDatas[i]);
                }

                //recover world control setting
                FileStream worldControlFile = File.Open(dirPath + "/" + GameConstants.WORLD_CONTROL + GameConstants.SAVE_FILE_EXTENSION, FileMode.Open);
                WorldControlData worldControlData = (WorldControlData)bf.Deserialize(worldControlFile);
                worldControlFile.Close();

                this.loadData(worldControlData);
            } catch (IOException ex) {
                Debug.LogError("IO error when saving: " + ex.Message);
                //EditorUtility.DisplayDialog("Load failed", "Please try again", "yes", "");
            }
        }

        public void RemoveAllSavedData() {
            string dirPath = Application.persistentDataPath + "/" + GameConstants.SAVE_DIRECTORY;
            if (Directory.Exists(dirPath)) {
                //Delete original saved files, then create new directory
                Directory.Delete(dirPath, true);
                //FileUtil.DeleteFileOrDirectory(dirPath);
            }
        }

        /// <summary>
        /// Called when AutoButton is clicked, used to enter or exit Auto mode
        /// </summary>
        public void clickAutoButton() {
            if (this.worldControlData.currentGameState == GameConstants.NORMAL) {
                //Enter AUTO state
                this.worldControlData.currentGameState = GameConstants.AUTO;
                //Click once now
                this.worldControlData.nextAutoClickTime = 0f;
            } else if (this.worldControlData.currentGameState == GameConstants.AUTO) {
                //Leave AUTO state
                this.worldControlData.currentGameState = GameConstants.NORMAL;
            }
        }
        /// <summary>
        /// Update the most long next auto click time, except for Mathf.Infinity
        /// </summary>
        /// <param name="newNextAutoClickTime"> New next auto click time</param>
        public void updateNextAutoClickTime(float newNextAutoClickTime) {
            if (this.worldControlData.nextAutoClickTime == Mathf.Infinity) {
                this.worldControlData.nextAutoClickTime = newNextAutoClickTime;
            } else if (this.worldControlData.nextAutoClickTime < Mathf.Infinity) {
                this.worldControlData.nextAutoClickTime = Mathf.Max(this.worldControlData.nextAutoClickTime, newNextAutoClickTime);
            }
        }
        /// <summary>
        /// Called when SkipButton skip key is down and called again when skip key is up, used to enter or exit skip mode
        /// </summary>
        public void clickSkipButton() {
            if (this.worldControlData.currentGameState == GameConstants.NORMAL && titleBoardUI.activeSelf == false) {
                this.worldControlData.currentGameState = GameConstants.SKIP;
                //Start skip mode, here could modify the speed of skip
                InvokeRepeating("step", 0.1f, 0.3f);
            } else if (this.worldControlData.currentGameState == GameConstants.SKIP) {
                //Stop skip mode
                CancelInvoke("step");
                this.worldControlData.currentGameState = GameConstants.NORMAL;
            }
        }
        /// <summary>
        /// Called when HideButton is clicked, used to hide or show the GameBoard UI
        /// </summary>
        public void clickHideButton() {
            if (this.worldControlData.currentGameState == GameConstants.NORMAL) {
                this.worldControlData.currentGameState = GameConstants.HIDE;
                hideInPlayUI();
            } else if (this.worldControlData.currentGameState == GameConstants.HIDE) {
                this.worldControlData.currentGameState = GameConstants.NORMAL;
                showInPlayUI();
            }
        }

        //ConfigBoard button and dropdown, slider functions
        /// <summary>
        /// Called when ScreenMode option on ConfigBoard is changed, used for game setting and saved into PlayerPrefs
        /// </summary>
        /// <param name="value">Changed value</param>
        public void valueChangedScreenMode(int value) {
            PlayerPrefs.SetInt(GameConstants.CONFIG_SCREEN_MODE, value);

            //To be done
            PlayerPrefs.Save();
        }
        /// <summary>
        /// Called when DialogMode option on ConfigBoard is changed, used for game setting and saved into PlayerPrefs
        /// </summary>
        /// <param name="value">Changed value</param>
        public void valueChangedDialogMode(int value) {
            PlayerPrefs.SetInt(GameConstants.CONFIG_DIALOG_MODE, value);

            switch (value) {
                case 0: {
                        this.worldControlData.dialogMode = GameConstants.NORMAL;
                        break;
                    }
                case 1: {
                        this.worldControlData.dialogMode = GameConstants.BUBBLE;
                        break;
                    }
            }

            PlayerPrefs.Save();
        }
        /// <summary>
        /// Called when BgmVolume option on ConfigBoard is changed, used for game setting and saved into PlayerPrefs
        /// </summary>
        /// <param name="value">Changed value</param>
        public void valueChangedBgmVolume(float value) {
            PlayerPrefs.SetFloat(GameConstants.CONFIG_BGM_VOLUME, value);

            GameObject[] backgroundGameObjects = GameObject.FindGameObjectsWithTag("Background");
            for (int i = 0; i < backgroundGameObjects.Length; i++) {
                backgroundGameObjects[i].GetComponent<AudioSource>().volume = value;
            }
            PlayerPrefs.Save();
        }
        /// <summary>
        /// Called when SeVolume option on ConfigBoard is changed, used for game setting and saved into PlayerPrefs
        /// </summary>
        /// <param name="value">Changed value</param>
        public void valueChangedSeVolume(float value) {
            PlayerPrefs.SetFloat(GameConstants.CONFIG_SE_VOLUME, value);

            GameObject[] worldGameObjects = GameObject.FindGameObjectsWithTag("World");
            for (int i = 0; i < worldGameObjects.Length; i++) {
                worldGameObjects[i].GetComponent<AudioSource>().volume = value;
            }
            PlayerPrefs.Save();
        }
        /// <summary>
        /// Called when VoiceVolume option on ConfigBoard is changed, used for game setting and saved into PlayerPrefs
        /// </summary>
        /// <param name="value">Changed value</param>
        public void valueChangedVoiceVolume(float value) {
            PlayerPrefs.SetFloat(GameConstants.CONFIG_VOICE_VOLUME, value);

            GameObject[] characterGameObjects = GameObject.FindGameObjectsWithTag("Character");
            for (int i = 0; i < characterGameObjects.Length; i++) {
                characterGameObjects[i].GetComponent<AudioSource>().volume = value;
            }
            PlayerPrefs.Save();
        }
        /// <summary>
        /// Called when TextSpeed option on ConfigBoard is changed, used for game setting and saved into PlayerPrefs
        /// </summary>
        /// <param name="value">Changed value</param>
        public void valueChangedTextSpeed(float value) {
            PlayerPrefs.SetFloat(GameConstants.CONFIG_TEXT_SPEED, value);
            PlayerPrefs.Save();
        }
        /// <summary>
        /// Called when AutoSpeed option on ConfigBoard is changed, used for game setting and saved into PlayerPrefs
        /// </summary>
        /// <param name="value">Changed value</param>
        public void valueChangedAutoSpeed(float value) {
            PlayerPrefs.SetFloat(GameConstants.CONFIG_AUTO_SPEED, value);
            PlayerPrefs.Save();
        }
        /// <summary>
        /// Called when TitleButton is clicked, used to back to game title, which needs further confirmation from poped up ConfirmBoard
        /// </summary>
        /// <param name="confirmed">Whether current action is confirmed or not</param>
        public void clickTitleButton(bool confirmed) {
            if (!confirmed) {
                confirmCurrentAction("Do you want to go back to title?", "This action would lose current game data.", clickTitleButton);
                return;
            }
            Application.LoadLevel(0);
        }

        //ConfirmBoard call funtions
        /// <summary>
        /// Called when current operation needs confirmed, such SaveTextButton is clicked, used to pop up the ConfirmBoard to ask player whether continue current operation
        /// </summary>
        /// <param name="title">Title of ConfirmBoard window</param>
        /// <param name="message">Message would be shown inside the ConfirmBoard window</param>
        /// <param name="clickButtonWithYes">Callback function to be called when player confirms this operation</param>
        public void confirmCurrentAction(string title, string message, UnityAction<bool> clickButtonWithYes) {
            confirmBoardUI.SetActive(true);
            confirmBoardUI.GetComponent<ModalPanel>().Choice(title, message, clickButtonWithYes);
        }
        /// <summary>
        /// Called when current operation needs confirmed, such SaveTextButton is clicked, used to pop up the ConfirmBoard to ask player whether continue current operation
        /// </summary>
        /// <param name="title">Title of ConfirmBoard window</param>
        /// <param name="message">Message would be shown inside the ConfirmBoard window</param>
        /// <param name="clickButtonWithYes">Callback function to be called when player confirms this operation</param>
        /// <param name="yesParameter">Parameter would be passed to the clickButtonWithYes callback function</param>
        public void confirmCurrentAction(string title, string message, UnityAction<bool, System.Object> clickButtonWithYes, System.Object yesParameter) {
            confirmBoardUI.SetActive(true);
            confirmBoardUI.GetComponent<ModalPanel>().Choice(title, message, clickButtonWithYes, yesParameter);
        }
        /// <summary>
        /// WorldControl game entity load data from saving data (on the disk)
        /// </summary>
        /// <param name="worldControlData">worldControlData is the serialized data on the disk</param>
        public void loadData(WorldControlData worldControlData) {

            //dont load currentGameState
            string currentGameState = this.worldControlData.currentGameState;
            this.worldControlData = worldControlData;
            //replace loaded currentGameState with old currentGameState
            this.worldControlData.currentGameState = currentGameState;

            Action loadedFocusAction = new Action(ScriptKeyword.FOCUS, new Dictionary<string, string>(){
            {ScriptKeyword.ID, worldControlData.focusGameObjectId}
        });
            this.takeFocusAction(loadedFocusAction);

            Action loadedTextAction = new Action(ScriptKeyword.TEXT, new Dictionary<string, string>(){
            {ScriptKeyword.CONTENT, worldControlData.textContent},
            {ScriptKeyword.TYPE, ScriptKeyword.CLICK_NEXT_DIALOGUE_PAGE}
        });
            if (focusGameObject.GetComponent<World>() != null) {
                updateNextAutoClickTime(focusGameObject.GetComponent<World>().takeTextAction(loadedTextAction));
            }
            if (focusGameObject.GetComponent<Character>() != null) {
                updateNextAutoClickTime(focusGameObject.GetComponent<Character>().takeTextAction(loadedTextAction));
            }

            //Load saved script to saved action index
            this.currentActions = scriptReader.loadNextScript(worldControlData.currentScriptName);
            for (int i = 0; i < worldControlData.currentActionIndex + 1; i++) {
                currentActions.RemoveAt(0);
            }
            //Recover history dialogs
            dialogContent.GetComponent<DialogManager>().historyDialogs = worldControlData.historyDialogs;
        }

    }
}