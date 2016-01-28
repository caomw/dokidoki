using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class ScriptReader {
    public string currentScriptPath;
    public long rowNumber = -1;

    private List<string> scriptPathList;

    private TextAsset currentScriptTextAsset;
    private StringBuilder scriptText;

    public ScriptReader() {
        prepareTestActionsSequence();
    }

    private void searchScript() {
        //Resources is set as the root folder of game projects
        string SCRIPTS_PATH = Application.dataPath + "/Resources/" + FolderStructure.SCRIPTS;
        string SCRIPTS_EXTENSION = "*.txt";

        DirectoryInfo scriptFolder = new DirectoryInfo(SCRIPTS_PATH);
        FileInfo[] scriptFiles = scriptFolder.GetFiles(SCRIPTS_EXTENSION);
        scriptPathList = new List<string>();
        foreach (FileInfo script in scriptFiles)
        {
            scriptPathList.Add(FolderStructure.SCRIPTS + Path.GetFileNameWithoutExtension(script.Name));
        }
        scriptPathList.Sort();
    }

    private void loadNextScript() {
        if (scriptPathList == null || scriptPathList.Count <= 0)
        {
            searchScript();
        }

        if (currentScriptPath == null)
        {
            //point to first script
            currentScriptPath = scriptPathList[0];
        } else {
            //point to next script
            int currentScriptNumber = scriptPathList.IndexOf(currentScriptPath);
            if (currentScriptNumber < scriptPathList.Count)
            {
                currentScriptPath = scriptPathList[currentScriptNumber + 1];
            }
            else {
                //this is already the last script
                return;
            }
        }

        //load script pointed to
        currentScriptTextAsset = Resources.Load(currentScriptPath) as TextAsset;
        //if load script failed, exit
        if (currentScriptTextAsset == null)
        {
            Debug.LogError(ScriptError.LOAD_SCRIPT_FAILED + currentScriptPath);
            Application.Quit();
        }

        //get the text of script from TextAsset
        scriptText = new StringBuilder(currentScriptTextAsset.ToString());
    }

    public List<Action> readNextActions() {
        if (scriptText == null || scriptText.Length < 1) {
            //complete current scriptText, or no current scriptText
            loadNextScript();
        }

        //to do with scriptText...
        //...
        //...

        string tag = "to do";
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        parameters.Add("to do", "to, do");

        Action newAction = new Action(tag, parameters);

        List<Action> newActions = new List<Action>();
        newActions.Add(newAction);

        return newActions;
    }

    private List<List<Action>> testActionsSequence = new List<List<Action>>();
    private int testCount;

    private void prepareTestActionsSequence() {
        testCount = 0;
        List<Action> newActions0 = new List<Action>();
        newActions0.Add(new Action(ScriptKeyword.FOCUS, new Dictionary<string, string>(){
            {ScriptKeyword.ID,"world"}
        }));
        newActions0.Add(new Action(ScriptKeyword.VIDEO, new Dictionary<string, string>(){
            {ScriptKeyword.SRC,"video0"}
        }));

        List<Action> newActions1 = new List<Action>();
        newActions1.Add(new Action(ScriptKeyword.BGM, new Dictionary<string, string>(){
            {ScriptKeyword.SRC,"bgm0"},
            {ScriptKeyword.MODE, ScriptKeyword.MODE_LOOP}
        }));
        newActions1.Add(new Action(ScriptKeyword.BACKGROUND, new Dictionary<string, string>(){
			{ScriptKeyword.SRC,"background0"},
            {ScriptKeyword.TRANSITION, ScriptKeyword.TRANSITION_INSTANT}
        }));
        newActions1.Add(new Action(ScriptKeyword.WEATHER, new Dictionary<string, string>(){
            {ScriptKeyword.TYPE,ScriptKeyword.TYPE_SNOW},
            {ScriptKeyword.LEVEL, "0.2"},
            {ScriptKeyword.TRANSITION, ScriptKeyword.TRANSITION_INSTANT},
            {ScriptKeyword.SPEED, "0.5"}
        }));
        newActions1.Add(new Action(ScriptKeyword.TEXT, new Dictionary<string, string>(){
            {ScriptKeyword.CONTENT,"天空渐渐飘下了雪花。"},
            {ScriptKeyword.TYPE, ScriptKeyword.CLICK}
        }));

        List<Action> newActions2 = new List<Action>();
        newActions2.Add(new Action(ScriptKeyword.TEXT, new Dictionary<string, string>(){
            {ScriptKeyword.CONTENT,"在校门口隐约着有个人影。"},
            {ScriptKeyword.TYPE, ScriptKeyword.CLICK}
        }));

        List<Action> newActions3 = new List<Action>();
        newActions3.Add(new Action(ScriptKeyword.SOUND, new Dictionary<string, string>(){
            {ScriptKeyword.SRC,"sound0"}
        }));
        newActions3.Add(new Action(ScriptKeyword.TEXT, new Dictionary<string, string>(){
            {ScriptKeyword.CONTENT,"我慢慢的走过去。"},
            {ScriptKeyword.TYPE, ScriptKeyword.CLICK}
        }));

        List<Action> newActions4 = new List<Action>();
        newActions4.Add(new Action(ScriptKeyword.FOCUS, new Dictionary<string, string>(){
            {ScriptKeyword.ID,"dokiChan"}
        }));
        newActions4.Add(new Action(ScriptKeyword.ROLE, new Dictionary<string, string>(){
            {ScriptKeyword.TYPE,ScriptKeyword.TYPE_CHARACTER},
            {ScriptKeyword.NAME, "character0"}
        }));
        newActions4.Add(new Action(ScriptKeyword.MOVE, new Dictionary<string, string>(){
            {ScriptKeyword.POSITION,ScriptKeyword.POSITION_CENTER},
            {ScriptKeyword.TRANSITION, ScriptKeyword.TRANSITION_INSTANT}
        }));
        newActions4.Add(new Action(ScriptKeyword.POSTURE, new Dictionary<string, string>(){
            {ScriptKeyword.SRC, "kuon0"}
        }));
        newActions4.Add(new Action(ScriptKeyword.VOICE, new Dictionary<string, string>(){
            {ScriptKeyword.SRC, "voice001"}
        }));
        newActions4.Add(new Action(ScriptKeyword.TEXT, new Dictionary<string, string>(){
            {ScriptKeyword.CONTENT,"等你好久了。"},
            {ScriptKeyword.TYPE, ScriptKeyword.CLICK_NEXT_DIALOGUE_PAGE}
        }));

        testActionsSequence.Add(newActions0);
        testActionsSequence.Add(newActions1);
        testActionsSequence.Add(newActions2);
        testActionsSequence.Add(newActions3);
        testActionsSequence.Add(newActions4);
    }

    public List<Action> testReadNextActions() {

        if (testCount > testActionsSequence.Count) {
            return null;
        }
        List<Action> newActions = testActionsSequence[testCount++];

        return newActions;
    }
}
