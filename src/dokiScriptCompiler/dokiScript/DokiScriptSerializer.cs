using System;
using System.IO;
using System.Collections.Generic;
using PerCederberg.Grammatica.Runtime;
using dokiScriptSetting;
using Action = dokiScriptSetting.Action;
using ScriptKeyword = dokiScriptSetting.ScriptKeyword;
using System.Runtime.Serialization.Formatters.Binary;

namespace dokiScript
{
	class DokiScriptSerializer
	{
		public static void Main (string[] args)
		{
			DokiScriptSerializer dokiScriptSerializer = new DokiScriptSerializer ();
			if (args == null || args.Length == 0) {
				dokiScriptSerializer.serializeAll ();
			} else if (args.Length == 1) {
				if (args [0].EndsWith (ScriptKeyword.SCRIPT_EXTENSION)) {
					dokiScriptSerializer.serialize (args [0].Substring(0, args [0].IndexOf(ScriptKeyword.SCRIPT_EXTENSION) - 1));
				} else {
					dokiScriptSerializer.serializeAll (args [0]);
				}
			} else {
				Console.WriteLine ("Only 1 arg(script root directory path or script file path) is allowed.");
			}

			//dokiScriptSerializer.serialize ("sample1");
			Console.WriteLine ("Over, enter any key.");
            Console.ReadKey();
		}

		public string[] getCurrentFolderFilePaths(string folerPath = ""){
			string[] currentFolderFilePaths = null;
			if (folerPath == null || folerPath.Equals ("")) {
				currentFolderFilePaths = Directory.GetFiles (Directory.GetCurrentDirectory ());
			} else {
				currentFolderFilePaths = Directory.GetFiles (folerPath);
			}
			return currentFolderFilePaths;
		}

		public void serialize(string scriptPathWithoutExtension){
			Console.WriteLine ("...Compiling: "+scriptPathWithoutExtension);
			string scriptText = File.ReadAllText(scriptPathWithoutExtension + "." + ScriptKeyword.SCRIPT_EXTENSION, System.Text.Encoding.UTF8);

			DokiScriptComplier  compiler = null;
			compiler = new DokiScriptComplier();

			List<Action> actions = compiler.compile(scriptText);

			try{
				BinaryFormatter bf = new BinaryFormatter();

				Script scriptData = new Script();
				scriptData.actions = actions;

				FileStream scriptFile = File.Create(scriptPathWithoutExtension + "." + ScriptKeyword.SCRIPT_COMPILED_EXTENSION);
				bf.Serialize(scriptFile, scriptData);
				scriptFile.Close();
			}catch(IOException ex){
				Console.WriteLine("IO error when saving: " + ex.Message);
			}

			for(int i=0;i<actions.Count; i++){
				Console.Write (actions[i].tag);
				Console.Write (": ");
				foreach (KeyValuePair<string, string> kv in actions[i].parameters) {
					Console.Write (kv.Key + "=" + kv.Value + " ");
				}
				Console.WriteLine ();
			}
		}

		public void serializeAll(string scriptFolderPath = ""){
			string[] currentFolderfilePaths = this.getCurrentFolderFilePaths (scriptFolderPath);
			Console.WriteLine (currentFolderfilePaths[0]);

			List<string> scriptPathsWithoutExtension = new List<string> ();
			foreach(string filePath in currentFolderfilePaths){
				if(filePath.EndsWith(ScriptKeyword.SCRIPT_EXTENSION)){
					scriptPathsWithoutExtension.Add (filePath.Substring(0, filePath.IndexOf(ScriptKeyword.SCRIPT_EXTENSION) - 1));
				}
			}
			Console.WriteLine (scriptPathsWithoutExtension[0]);

			foreach(string scriptPath in scriptPathsWithoutExtension){
				this.serialize (scriptPath);
			}
		}

	}
}
