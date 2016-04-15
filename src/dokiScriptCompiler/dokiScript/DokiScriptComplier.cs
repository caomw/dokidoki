using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using PerCederberg.Grammatica.Runtime;
using dokiScriptSetting;
using Action = dokiScriptSetting.Action;

namespace dokiScriptCompiler
{
	/// <summary>
	/// DokiScriptCompiler is script compiler for dokiScript.
	/// DokiScriptCompiler is used to compile script file text into a set of actions.
	/// It is based on grammatica project.
	/// DokiScriptConstants, DokiScriptTokenizer, DokiSriptParser, DokiScriptAnalyzer are all auto-generated from grammatica.
	/// </summary>
	internal class DokiScriptCompiler : DokiScriptAnalyzer
	{
		/// <summary>
		/// The actions compiled from script text.
		/// </summary>
		public List<Action> actions = null;
		/// <summary>
		/// The empty focus action is used to take a position in the list which needs further parameter setting
		/// </summary>
		public Action emptyFocusAction = new Action("focus", null);

		public DokiScriptCompiler ()
		{
		}
		/// <summary>
		/// Compile the specified script text.
		/// </summary>
		/// <param name="scriptText">Script text.</param>
		public List<Action> compile(string scriptText){
			actions = null;
			actions = new List<Action> ();

			DokiScriptParser  parser;
			parser = new DokiScriptParser(new StringReader(scriptText), this);
			parser.Prepare();
			parser.Parse();

			//node.PrintTo (Console.Out);
			return actions;
		}


		public override Node ExitWorld(Token node){node.Values.Add("world");
			return node;
		}
		public override Node ExitBackground(Token node){node.Values.Add("background");
			return node;
		}
		public override Node ExitWeather(Token node){node.Values.Add("weather");
			return node;
		}
		public override Node ExitSound(Token node){node.Values.Add("sound");
			return node;
		}
		public override Node ExitBgm(Token node){node.Values.Add("bgm");
			return node;
		}
		public override Node ExitVideo(Token node){node.Values.Add("video");
			return node;
		}
		public override Node ExitMove(Token node){node.Values.Add("move");
			return node;
		}
		public override Node ExitPosture(Token node){node.Values.Add("posture");
			return node;
		}
		public override Node ExitVoice(Token node){node.Values.Add("voice");
			return node;
		}
		public override Node ExitRole(Token node){node.Values.Add("role");
			return node;
		}


		public override Node ExitSrc(Token node){node.Values.Add("src");
			return node;
		}
		public override Node ExitTransition(Token node){node.Values.Add("transition");
			return node;
		}
		public override Node ExitTransitionInstant(Token node){node.Values.Add("instant");
			return node;
		}
		public override Node ExitTransitionGradual(Token node){node.Values.Add("gradual");
			return node;
		}
		public override Node ExitSpeed(Token node){node.Values.Add("speed");
			return node;
		}
		public override Node ExitType(Token node){node.Values.Add("type");
			return node;
		}
		public override Node ExitTypeSunny(Token node){node.Values.Add("sunny");
			return node;
		}
		public override Node ExitTypeRain(Token node){node.Values.Add("rain");
			return node;
		}
		public override Node ExitTypeSnow(Token node){node.Values.Add("snow");
			return node;
		}
		public override Node ExitLevel(Token node){node.Values.Add("level");
			return node;
		}
		public override Node ExitMode(Token node){node.Values.Add("mode");
			return node;
		}
		public override Node ExitModeLoop(Token node){node.Values.Add("loop");
			return node;
		}
		public override Node ExitPosition(Token node){node.Values.Add("position");
			return node;
		}
		public override Node ExitPositionCenter(Token node){node.Values.Add("center");
			return node;
		}
		public override Node ExitPositionLeft(Token node){node.Values.Add("left");
			return node;
		}
		public override Node ExitPositionRight(Token node){node.Values.Add("right");
			return node;
		}
		public override Node ExitTypePlayer(Token node){node.Values.Add("player");
			return node;
		}
		public override Node ExitTypeCharacter(Token node){node.Values.Add("character");
			return node;
		}
		public override Node ExitName(Token node){node.Values.Add("name");
			return node;
		}
		public override Node ExitAnchor(Token node){node.Values.Add ("anchor");
			return node;
		}


		public override Node ExitBracketLeft(Token node){node.Values.Add("{");
			return node;
		}
		public override Node ExitBracketRight(Token node){node.Values.Add("}");
			return node;
		}
		public override Node ExitSquareBracketLeft(Token node){node.Values.Add("[");
			return node;
		}
		public override Node ExitSquareBracketRight(Token node){node.Values.Add("]");
			return node;
		}
		public override Node ExitParentheseLeft(Token node){node.Values.Add("(");
			return node;
		}
		public override Node ExitParentheseRight(Token node){node.Values.Add(")");
			return node;
		}
		public override Node ExitAngleBracketLeft(Token node){node.Values.Add("<");
			return node;
		}
		public override Node ExitDoubleQuote(Token node){node.Values.Add('"');
			return node;
		}
		public override Node ExitPeriod(Token node){node.Values.Add(".");
			return node;
		}
		public override Node ExitComma(Token node){node.Values.Add(",");
			return node;
		}
		public override Node ExitSemicolon(Token node){node.Values.Add(";");
			return node;
		}
		public override Node ExitEqual(Token node){node.Values.Add("=");
			return node;
		}
		public override Node ExitClick(Token node){node.Values.Add(">");
			return node;
		}
		public override Node ExitClickNextDialoguePage(Token node){node.Values.Add(">>");
			return node;
		}
		public override Node ExitOr(Token node){node.Values.Add("|");
			return node;
		}

		public override Node ExitSpace(Token node){
			//Space have no meaning, do nothing here
			return node;
		}
		public override Node ExitIdentifier(Token node){
			node.Values.Add(node.Image);
			return node;
		}
		public override Node ExitDecimal(Token node){
			node.Values.Add(node.Image);
			return node;
		}
		public override Node ExitText(Token node){
			node.Values.Add(node.Image);
			return node;
		}
		public override Node ExitQuotedText(Token node){
			node.Values.Add(node.Image);
			return node;
		}


		public override Node ExitDoki(Production node) {
			node.Values.AddRange(GetChildValues(node));
			return node;
		}
		public override Node ExitPart(Production node) {
			node.Values.AddRange(GetChildValues(node));
			return node;
		}
		public override void EnterBlock (Production node){
			//Label this position for parameter on this focusAction
			actions.Add(emptyFocusAction);
			return;
		}
		public override Node ExitBlock(Production node) {
			node.Values.AddRange(GetChildValues(node));

			/*
			Console.Write ("Block: ");
			for (int i = 0; i < node.Values.Count; i++) {
				Console.Write ("[" + i + "]" + node.Values[i] + " ");
			}
			Console.Write ("\n");
			*/
			
			Action focusAction = new Action (ScriptKeyword.FOCUS, new Dictionary<string, string>(){
				{ScriptKeyword.ID, node.Values[0].ToString()} 
			});
			int index = actions.IndexOf (emptyFocusAction);
			actions [index] = focusAction;

			return node;
		}
		public override Node ExitAction(Production node) {
			node.Values.AddRange(GetChildValues(node));

			if(node.Values.Count <= 1){
				//detect >|>> to set the mode
				string mode = "";
				if (node.Values [0].ToString ().Contains (ScriptKeyword.CLICK_NEXT_DIALOGUE_PAGE)) {
					mode = ScriptKeyword.CLICK_NEXT_DIALOGUE_PAGE;
				} else if(node.Values [0].ToString ().Contains (ScriptKeyword.CLICK)) {
					mode = ScriptKeyword.CLICK;
				}
				//remove >|>> from the content
				string content = node.Values [0].ToString ();
				content = content.Replace (ScriptKeyword.CLICK, string.Empty);
				//Text Action
				Action textAction = new Action (ScriptKeyword.TEXT, new Dictionary<string, string>(){
					{ScriptKeyword.CONTENT, content},
					{ScriptKeyword.MODE, mode}
				});
				actions.Add (textAction);
			}else if(node.Values[0].Equals(ScriptKeyword.VOICE)){
				//Voice Action
				Dictionary<string, string> parameters = new Dictionary<string, string>();
				for(int i=0; i<(node.Values.Count - 2)/3 ;i++){
					parameters.Add(node.Values[i*3+1].ToString(), node.Values[i*3+3].ToString());
				}

				//detect >|>> to set the mode
				string mode = "";
				if (node.Values[node.Values.Count-1].ToString().Contains (ScriptKeyword.CLICK_NEXT_DIALOGUE_PAGE)) {
					mode = ScriptKeyword.CLICK_NEXT_DIALOGUE_PAGE;
				} else if(node.Values[node.Values.Count-1].ToString().Contains (ScriptKeyword.CLICK)) {
					mode = ScriptKeyword.CLICK;
				}
				//remove >|>> from the content
				string content = node.Values[node.Values.Count-1].ToString();
				content = content.Replace (ScriptKeyword.CLICK, string.Empty);

				parameters.Add (ScriptKeyword.CONTENT, content);
				parameters.Add (ScriptKeyword.MODE, mode);
				Action voiceAction = new Action (ScriptKeyword.VOICE, parameters);
				actions.Add (voiceAction);
			}else{
				//Other Action
				Dictionary<string, string> parameters = new Dictionary<string, string>();
				for(int i=0; i<(node.Values.Count - 2)/3 ;i++){
					parameters.Add(node.Values[i*3+1].ToString(), node.Values[i*3+3].ToString());
				}
				Action otherAction = new Action (node.Values[0].ToString(), parameters);
				actions.Add (otherAction);
			}

			/*
			Console.Write ("Action: ");
			for (int i = 0; i < node.Values.Count; i++) {
				Console.Write ("[" + i + "]" + node.Values[i] + " ");
			}
			Console.Write ("\n");
			*/
			//node.PrintTo (Console.Out);

			return node;
		}
		public override Node ExitVoiceAction(Production node) {
			node.Values.AddRange(GetChildValues(node));
			return node;
		}
		public override Node ExitOtherAction(Production node) {
			node.Values.AddRange(GetChildValues(node));
			return node;
		}
		public override Node ExitTag(Production node) {
			node.Values.AddRange(GetChildValues(node));
			return node;
		}
		public override Node ExitKey(Production node) {
			node.Values.AddRange(GetChildValues(node));
			return node;
		}
		public override Node ExitValue(Production node) {
			System.Collections.ArrayList values = GetChildValues (node);
			if (values.Count > 1) {
				//position=value
				string positionValue = "";
				for (int i = 0; i < values.Count; i++) {
					positionValue += values [i];
				}
				node.Values.Add (positionValue);
			} else {
				node.Values.AddRange(GetChildValues(node));	
			}

			/*
			Console.Write ("Value: ");
			for (int i = 0; i < node.Values.Count; i++) {
				Console.Write ("[" + i + "]" + node.Values[i] + " ");
			}
			Console.Write ("\n");
			*/

			return node;
		}
		public override Node ExitFlag(Production node) {
			node.Values.AddRange(GetChildValues(node));

			//Flag action
			Dictionary<string, string> parameters = new Dictionary<string, string>();
			int count = (node.Values.Count - 1) / 7;
			parameters.Add (ScriptKeyword.COUNT, ""+count);
			for(int i=0; i<count ;i++){
				parameters.Add(ScriptKeyword.OPTION_+(i+1), node.Values[i*7+1].ToString());
				parameters.Add(ScriptKeyword.OPTION_ID_+(i+1), node.Values[i*7+3].ToString());
				parameters.Add(ScriptKeyword.OPTION_SRC_+(i+1), node.Values[i*7+5].ToString());
			}
			Action flagAction = new Action (ScriptKeyword.FLAG, parameters);
			actions.Add (flagAction);

			/*
			Console.Write ("Flag: ");
			for (int i = 0; i < node.Values.Count; i++) {
				Console.Write ("[" + i + "]" + node.Values[i] + " ");
			}
			Console.Write ("\n");
			*/

			return node;
		}
		public override Node ExitOption(Production node) {
			node.Values.AddRange(GetChildValues(node));

			//Option action
			Action optionAction = new Action (ScriptKeyword.OPTION, new Dictionary<string, string>(){
				{ScriptKeyword.ID, node.Values[1].ToString()} 
			});
			actions.Add (optionAction);

			/*
			Console.Write ("Option: ");
			for (int i = 0; i < node.Values.Count; i++) {
				Console.Write ("[" + i + "]" + node.Values[i] + " ");
			}
			Console.Write ("\n");
			*/

			return node;
		}
		public override Node ExitJump(Production node) {
			node.Values.AddRange(GetChildValues(node));

			//Jump action
			Action jumpAction = new Action (ScriptKeyword.JUMP, new Dictionary<string, string>(){
				{ScriptKeyword.SRC, node.Values[1].ToString()} 
			});
			actions.Add (jumpAction);

			/*
			Console.Write ("Jump: ");
			for (int i = 0; i < node.Values.Count; i++) {
				Console.Write ("[" + i + "]" + node.Values[i] + " ");
			}
			Console.Write ("\n");
			*/

			return node;
		}
	}
}

