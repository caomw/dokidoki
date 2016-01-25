using UnityEngine;
using System.Collections;
using System.Text;

public class ScriptReader : MonoBehaviour {

    public string currentScriptPath;
    public long rowNumber;

    private TextAsset currentScriptTextAsset;
    private StringBuilder scriptText;

    public ScriptReader(string currentScriptPath) {
        this.currentScriptPath = currentScriptPath;
    }

    public string readLine() {
        string line;

        if (currentScriptTextAsset==null) {
            Debug.Log(currentScriptPath);
            currentScriptTextAsset = Resources.Load(currentScriptPath) as TextAsset;
        }
        Debug.Log(currentScriptTextAsset.text);
        if (scriptText==null) {
            scriptText = new StringBuilder(currentScriptTextAsset.ToString());
        }

        line = scriptText.ToString();

        return line;
    }
}
