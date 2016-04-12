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
	class MainClass
	{
		public static void Main (string[] args)
		{
            string input = File.ReadAllText("sample1." + ScriptKeyword.SCRIPT_EXTENSION, System.Text.Encoding.UTF8);

			DokiScriptComplier  compiler = null;
			compiler = new DokiScriptComplier();

			List<Action> actions = compiler.compile(input);

			string dirPath = "DokiScripts";

			try{
				if (!Directory.Exists(dirPath))
				{
                    Directory.CreateDirectory(dirPath);
				}

				BinaryFormatter bf = new BinaryFormatter();

				Script scriptData = new Script();
				scriptData.actions = actions;

                FileStream scriptFile = File.Create(dirPath + "/" + "sample1." + ScriptKeyword.SCRIPT_COMPILED_EXTENSION);
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
			Console.WriteLine ("Hello World!");
            Console.ReadKey();
		}

	}
}
