using UnityEngine;
using System.Collections;
using System.Text;

public class ScriptReader{
    //save data
    public string currentScriptPath;
    public long rowNumber = -1;

    
    private TextAsset currentScriptTextAsset;
    private StringBuilder scriptText;

    public ScriptReader(string currentScriptPath) {
        this.currentScriptPath = currentScriptPath;
    }

    public void loadScript() {
        if (currentScriptTextAsset == null)
        {
            currentScriptTextAsset = Resources.Load(currentScriptPath) as TextAsset;
            //if load script failed, exit
            if (currentScriptTextAsset == null)
            {
                Debug.LogError(ScriptError.LOAD_SCRIPT_FAILED + currentScriptPath);
                Application.Quit();
            }
        }
        if (scriptText == null)
        {
            scriptText = new StringBuilder(currentScriptTextAsset.ToString());
        }
    }

    public string readLine() {
        string line;

        

        line = scriptText.ToString();

        return line;
    }
}
