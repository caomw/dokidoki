using System;
using System.IO;
using System.Collections.Generic;
using PerCederberg.Grammatica.Runtime;
using dokiScriptSetting;
using Action = dokiScriptSetting.Action;
using ScriptKeyword = dokiScriptSetting.ScriptKeyword;
using System.Runtime.Serialization.Formatters.Binary;

namespace dokiScriptCompiler
{
	/// <summary>
	/// DokiScriptSerializer is used to compile and serialize script file(a set of actions) into the disk.
	/// The compiled and serialized file name would be the same as original script file.
	/// It would give debug information if script file has errors.
	/// It could be used via commandline.
	/// The parameter could be the root directory path of all script files, or one script file path.
	/// If no parameter is set, it take current directory path as root directory of all script files.
	/// </summary>
	class DokiScriptSerializer
	{
		/// <summary>
		/// Command line entry
		/// </summary>
		/// <param name="args">Root directory path of all script files, or one script file path</param>
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
		/// <summary>
		/// Gets the current folder's file paths.
		/// </summary>
		/// <returns>The current folder's file paths.</returns>
		/// <param name="folerPath">Foler path to search files</param>
		public string[] getCurrentFolderFilePaths(string folerPath = ""){
			string[] currentFolderFilePaths = null;
			if (folerPath == null || folerPath.Equals ("")) {
				currentFolderFilePaths = Directory.GetFiles (Directory.GetCurrentDirectory ());
			} else {
				currentFolderFilePaths = Directory.GetFiles (folerPath);
			}
			return currentFolderFilePaths;
		}
		/// <summary>
		/// Compile and Serialize the specified script file.
		/// </summary>
		/// <param name="scriptPathWithoutExtension">Script path without extension.</param>
		public void serialize(string scriptPathWithoutExtension){
			Console.WriteLine ("...Compiling: "+scriptPathWithoutExtension);
			string scriptText = File.ReadAllText(scriptPathWithoutExtension + "." + ScriptKeyword.SCRIPT_EXTENSION, System.Text.Encoding.UTF8);

			DokiScriptCompiler  compiler = null;
			compiler = new DokiScriptCompiler();

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
		/// <summary>
		/// Compile and serialize all script files under the specific script file folder.
		/// </summary>
		/// <param name="scriptFolderPath">Script files folder path.</param>
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
