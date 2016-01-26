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

    void Start () {
        //search script directory files
        if (projectRootPath == null) {
            return;
        }
        //Resources is set as the root folder of game projects
        SCRIPTS_PATH = Application.dataPath+ "/Resources/" + projectRootPath + "/" +FolderStructure.SCRIPT_FOLDER;
        SCRIPTS_EXTENSION = "*.txt";

        DirectoryInfo dir = new DirectoryInfo(SCRIPTS_PATH);
        FileInfo[] info = dir.GetFiles(SCRIPTS_EXTENSION);
        scriptPathList = new List<string>();
        foreach (FileInfo f in info) {
            scriptPathList.Add(projectRootPath + "/" + FolderStructure.SCRIPT_FOLDER+"/"+Path.GetFileNameWithoutExtension(f.Name));
            //Debug.Log(projectRootPath + "/" + FolderStructure.SCRIPT_FOLDER + "/" + Path.GetFileNameWithoutExtension(f.Name));
        }
        scriptPathList.Sort();

        //set up scriptReader, new game and load game
        if (scriptReader==null) {
            scriptReader = new ScriptReader(scriptPathList[0]);
        }
    }

    int count = 0;

    public void step() {
        Debug.Log("Screen click..."+count++);
        Debug.Log(scriptReader.readLine());
    }
	
	void Update () {
	
	}
}
