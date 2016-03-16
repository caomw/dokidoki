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
            {ScriptKeyword.SRC,"video1"}
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
            {ScriptKeyword.LEVEL, "0.5"}
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
			{ScriptKeyword.NAME, "小雪"}
        }));
        newActions4.Add(new Action(ScriptKeyword.MOVE, new Dictionary<string, string>(){
            {ScriptKeyword.POSITION,ScriptKeyword.POSITION_CENTER},
            {ScriptKeyword.TRANSITION, ScriptKeyword.TRANSITION_INSTANT}
        }));
        newActions4.Add(new Action(ScriptKeyword.POSTURE, new Dictionary<string, string>(){
            {ScriptKeyword.SRC, "kuon0"}
        }));
        newActions4.Add(new Action(ScriptKeyword.VOICE, new Dictionary<string, string>(){
            {ScriptKeyword.SRC, "voice001"},
			{ScriptKeyword.CONTENT,"等你好久了。"},
			{ScriptKeyword.TYPE, ScriptKeyword.CLICK_NEXT_DIALOGUE_PAGE}
        }));
        List<Action> newActions5 = new List<Action>();
		newActions5.Add(new Action(ScriptKeyword.VOICE, new Dictionary<string, string>(){
            {ScriptKeyword.CONTENT,"一直在等着你。"},
            {ScriptKeyword.TYPE, ScriptKeyword.CLICK_NEXT_DIALOGUE_PAGE}
        }));

        List<Action> newActions6 = new List<Action>();
		newActions6.Add(new Action(ScriptKeyword.VOICE, new Dictionary<string, string>(){
            {ScriptKeyword.CONTENT,"还以为你不来了呢。"},
            {ScriptKeyword.TYPE, ScriptKeyword.CLICK_NEXT_DIALOGUE_PAGE}
        }));

        List<Action> newActionsFlag = new List<Action>();
        newActionsFlag.Add(new Action(ScriptKeyword.FLAG, new Dictionary<string, string>(){
            {ScriptKeyword.OPTION, "2"},
            {ScriptKeyword.OPTION_1, "我抬起头看着她的脸，向她走了过去"},
			{ScriptKeyword.OPTION_ID_1, "option011"},
            {ScriptKeyword.OPTION_SRC_1, "sample1"},
            {ScriptKeyword.OPTION_2, "我只是呆站着那儿，一动也不动的"},
			{ScriptKeyword.OPTION_ID_2, "option012"},
            {ScriptKeyword.OPTION_SRC_2, "sample1"}
        }));

        List<Action> newActions7 = new List<Action>();
        newActions7.Add(new Action(ScriptKeyword.FOCUS, new Dictionary<string, string>(){
            {ScriptKeyword.ID,"world"}
        }));
        newActions7.Add(new Action(ScriptKeyword.TEXT, new Dictionary<string, string>(){
            {ScriptKeyword.CONTENT,"我微笑着走了过去。"},
            {ScriptKeyword.TYPE, ScriptKeyword.CLICK_NEXT_DIALOGUE_PAGE}
        }));

        List<Action> newActions8 = new List<Action>();
        newActions8.Add(new Action(ScriptKeyword.FOCUS, new Dictionary<string, string>(){
            {ScriptKeyword.ID,"player"}
        }));
        newActions8.Add(new Action(ScriptKeyword.ROLE, new Dictionary<string, string>(){
            {ScriptKeyword.TYPE,ScriptKeyword.TYPE_PLAYER},
            {ScriptKeyword.NAME, "我"}
        }));
        newActions8.Add(new Action(ScriptKeyword.VOICE, new Dictionary<string, string>(){
            {ScriptKeyword.CONTENT,"怎么会呢，我们不是约好了么。"},
            {ScriptKeyword.TYPE, ScriptKeyword.CLICK_NEXT_DIALOGUE_PAGE}
        }));

        List<Action> newActions9 = new List<Action>();
        newActions9.Add(new Action(ScriptKeyword.FOCUS, new Dictionary<string, string>(){
            {ScriptKeyword.ID,"dokiChan"}
        }));
        newActions9.Add(new Action(ScriptKeyword.VOICE, new Dictionary<string, string>(){
            {ScriptKeyword.CONTENT,"是呢，一年前的约定。"},
            {ScriptKeyword.TYPE, ScriptKeyword.CLICK_NEXT_DIALOGUE_PAGE}
        }));

        List<Action> newActions10 = new List<Action>();
        newActions10.Add(new Action(ScriptKeyword.FOCUS, new Dictionary<string, string>(){
            {ScriptKeyword.ID,"player"}
        }));
        newActions10.Add(new Action(ScriptKeyword.VOICE, new Dictionary<string, string>(){
            {ScriptKeyword.CONTENT,"嗯，一年过去了。"},
            {ScriptKeyword.TYPE, ScriptKeyword.CLICK_NEXT_DIALOGUE_PAGE}
        }));

		List<Action> newActions11 = new List<Action>();
		newActions11.Add(new Action(ScriptKeyword.FOCUS, new Dictionary<string, string>(){
			{ScriptKeyword.ID,"player"}
		}));
		newActions11.Add(new Action(ScriptKeyword.TEXT, new Dictionary<string, string>(){
			{ScriptKeyword.CONTENT,"这家伙还是一点没变，仿佛时间已经抛弃了她。"},
			{ScriptKeyword.TYPE, ScriptKeyword.CLICK_NEXT_DIALOGUE_PAGE}
		}));

        List<Action> newActions12 = new List<Action>();
        newActions12.Add(new Action(ScriptKeyword.FOCUS, new Dictionary<string, string>(){
            {ScriptKeyword.ID,"world"}
        }));
        newActions12.Add(new Action(ScriptKeyword.TEXT, new Dictionary<string, string>(){
            {ScriptKeyword.CONTENT,"两个人仅仅呆站这那儿，无言的看着对方。"},
            {ScriptKeyword.TYPE, ScriptKeyword.CLICK_NEXT_DIALOGUE_PAGE}
        }));
        newActions12.Add(new Action(ScriptKeyword.WEATHER, new Dictionary<string, string>(){
            {ScriptKeyword.TYPE,ScriptKeyword.TYPE_SUNNY}
        }));
        newActions12.Add(new Action(ScriptKeyword.TEXT, new Dictionary<string, string>(){
            {ScriptKeyword.CONTENT,"不经意间，雪停了"},
            {ScriptKeyword.TYPE, ScriptKeyword.CLICK_NEXT_DIALOGUE_PAGE}
        }));

        testActionsSequence.Add(newActions0);
        testActionsSequence.Add(newActions1);
        testActionsSequence.Add(newActions2);
        testActionsSequence.Add(newActions3);
        testActionsSequence.Add(newActions4);
        testActionsSequence.Add(newActions5);
        testActionsSequence.Add(newActions6);
        testActionsSequence.Add(newActionsFlag);
        testActionsSequence.Add(newActions7);
        testActionsSequence.Add(newActions8);
        testActionsSequence.Add(newActions9);
        testActionsSequence.Add(newActions10);
        testActionsSequence.Add(newActions11);
		testActionsSequence.Add(newActions12);
    }

    public List<Action> testReadNextActions() {

        if (testCount > testActionsSequence.Count) {
            return null;
        }
        List<Action> newActions = testActionsSequence[testCount++];

        return newActions;
    }
}
