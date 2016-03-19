using System;
using System.IO;
using System.Collections.Generic;
using PerCederberg.Grammatica.Runtime;

namespace dokiScript
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string input = File.ReadAllText ("sample1.dks", System.Text.Encoding.UTF8);

			DokiScriptComplier  compiler = null;
			compiler = new DokiScriptComplier();

			List<Action> actions = compiler.compile(input);

			for(int i=0;i<actions.Count; i++){
				Console.Write (actions[i].tag);
				Console.Write (": ");
				foreach (KeyValuePair<string, string> kv in actions[i].parameters) {
					Console.Write (kv.Key + "=" + kv.Value + " ");
				}
				Console.WriteLine ();
			}
			Console.WriteLine ("Hello World!");
		}

	}
}
