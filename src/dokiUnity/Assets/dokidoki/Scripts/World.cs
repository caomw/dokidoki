using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class World : MonoBehaviour {

    public string projectRootPath;

    private string SCRIPTS_PATH;
    private string SCRIPTS_EXTENSION;

    private List<string> scriptPathList;
    private ScriptReader scriptReader;

    // Use this for initialization
    void Start () {
        //search script directory files
        if (projectRootPath == null) {
            return;
        }
        SCRIPTS_PATH = Application.dataPath+ "/" + projectRootPath + "/DokiScripts/";
        SCRIPTS_EXTENSION = "*.txt";

        DirectoryInfo dir = new DirectoryInfo(SCRIPTS_PATH);
        FileInfo[] info = dir.GetFiles(SCRIPTS_EXTENSION);
        scriptPathList = new List<string>();
        foreach (FileInfo f in info) {
            scriptPathList.Add(f.ToString());
        }

        scriptReader = new ScriptReader(scriptPathList[0]);
    }

    int count = 0;

    public void step() {
        Debug.Log("Screen click..."+count++);
        Debug.Log(scriptReader.readLine());
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
