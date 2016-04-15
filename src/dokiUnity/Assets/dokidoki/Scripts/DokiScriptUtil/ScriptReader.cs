using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using dokiScriptSetting;
using Action = dokiScriptSetting.Action;
using Script = dokiScriptSetting.Script;
using ScriptKeyword = dokiScriptSetting.ScriptKeyword;
using System.Runtime.Serialization.Formatters.Binary;


namespace dokiUnity {
    /// <summary>
    /// ScriptReader is resiponsible for all script relating operations during the game.
    /// ScriptReader could automatically search all scripts under the pre-defined folder(asset/Resources/DokiScripts), and sort it in alphabet order.
    /// When a new game starts up, the first script would be loaded, and ScriptReader keeps all Actions.
    /// When loads a game from saved data, the script with specific name would be loaded.
    /// A script is a set of actions.
    /// Those actions would be returned to WorldControl to distribute them to World or Character to take in sequence.
    /// </summary>
    public class ScriptReader {
        /// <summary>
        /// Name of current loaded script
        /// </summary>
        public string currentScriptName;
        /// <summary>
        /// A set of names of scripts found in pre-defined folder
        /// </summary>
        private List<string> scriptNames;
        /// <summary>
        /// Current script object of loaded script file, which contains a list of actions
        /// </summary>
        public Script currentScript;
        /// <summary>
        /// Record the actios count when the script is first loaded, in order to further record current action's index for saving the game
        /// </summary>
        public int currentScriptActionsCount;


        /// <summary>
        /// When scriptRead is new created, automatically searchs scripts
        /// </summary>
        public ScriptReader() {
            searchScript();
        }
        /// <summary>
        /// Search scripts in pre-defined folder, save their names
        /// </summary>
        private void searchScript() {
            //Debug.Log("Hello from searchScript().");
            /*
            //Resources is set as the root folder of game projects
            string SCRIPTS_PATH = Application.dataPath + "/Resources/" + FolderStructure.SCRIPTS;
            string SCRIPTS_EXTENSION = "*." + ScriptKeyword.SCRIPT_COMPILED_EXTENSION;

            DirectoryInfo scriptFolder = new DirectoryInfo(SCRIPTS_PATH);
            FileInfo[] scriptFiles = scriptFolder.GetFiles(SCRIPTS_EXTENSION);
        
            scriptNames = new List<string>();
            foreach (FileInfo script in scriptFiles)
            {
                scriptNames.Add(Path.GetFileNameWithoutExtension(script.Name));
            }
            */
            Object[] scriptObjects = Resources.LoadAll(FolderStructure.SCRIPTS);

            scriptNames = new List<string>();
            foreach (Object scriptObject in scriptObjects) {
                scriptNames.Add(Path.GetFileNameWithoutExtension(scriptObject.name));
            }

            scriptNames.Sort();

            string allScriptNames = "";
            for (int i = 0; i < scriptNames.Count; i++) {
                allScriptNames += scriptNames[i] + ", ";
            }
            Debug.Log("DokiScripts: " + allScriptNames);
        }
        /// <summary>
        /// Called when current actions are all taken, or jump action or flag action is taking.
        /// Load next script, use the scriptName when it is set, or just load the next script in alphabet order of the script list.
        /// </summary>
        /// <param name="scriptName">Name of the next script should be loaded</param>
        /// <returns>Return a list of action from the loaded script</returns>
        public List<Action> loadNextScript(string scriptName = null) {
            if (scriptName == null) {
                if (currentScript == null) {
                    if (scriptNames == null || scriptNames.Count < 1) {
                        return null;
                    }
                    scriptName = scriptNames[0];
                } else {
                    //Debug.Log ("scriptNames.IndexOf(currentScriptName) = "+scriptNames.IndexOf(currentScriptName));
                    //Debug.Log ("scriptNames.Count = "+scriptNames.Count);
                    if (scriptNames.IndexOf(currentScriptName) + 1 == scriptNames.Count) {
                        //No more scripts
                        Debug.Log("No more scripts");
                        return null;
                    }
                    scriptName = scriptNames[scriptNames.IndexOf(currentScriptName) + 1];
                }
            }
            currentScriptName = scriptName;
            string scriptPath = FolderStructure.SCRIPTS + scriptName;
            Debug.Log("scriptPath: " + scriptPath);
            try {
                BinaryFormatter bf = new BinaryFormatter();

                TextAsset asset = Resources.Load(scriptPath) as TextAsset;
                Stream scriptFile = new MemoryStream(asset.bytes);

                //FileStream scriptFile = File.Open(scriptPath, FileMode.Open);
                Script scriptData = (Script)bf.Deserialize(scriptFile);
                scriptFile.Close();

                Debug.Log("scriptData = " + scriptData);

                this.currentScript = scriptData;
                this.currentScriptActionsCount = scriptData.actions.Count;
                Debug.Log("scriptData.actions.Count: " + scriptData.actions.Count);
                return scriptData.actions;

            } catch (IOException ex) {
                Debug.LogError("IO error when saving: " + ex.Message);
            }

            return null;
        }
        /// <summary>
        /// Get the index of current action to be taken in the original script actions' list
        /// </summary>
        /// <returns>Index of current action in original script</returns>
        public int getCurrentActionIndex() {
            return currentScriptActionsCount - currentScript.actions.Count - 1;
        }
    }
}