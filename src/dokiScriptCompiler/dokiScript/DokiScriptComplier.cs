using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using PerCederberg.Grammatica.Runtime;
using dokidoki.dokiScriptSetting;
using Action = dokidoki.dokiScriptSetting.Action;
using ScriptKeyword = dokidoki.dokiScriptSetting.ScriptKeyword;

namespace dokidoki.dokiScriptCompiler
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


		public override Node ExitWorld(Token node){node.Values.Add(ScriptKeyword.WORLD);
			return node;
		}
		public override Node ExitBackground(Token node){node.Values.Add(ScriptKeyword.BACKGROUND);
			return node;
		}
		public override Node ExitWeather(Token node){node.Values.Add(ScriptKeyword.WEATHER);
			return node;
		}
		public override Node ExitSound(Token node){node.Values.Add(ScriptKeyword.SOUND);
			return node;
		}
		public override Node ExitBgm(Token node){node.Values.Add(ScriptKeyword.BGM);
			return node;
		}
		public override Node ExitVideo(Token node){node.Values.Add(ScriptKeyword.VIDEO);
			return node;
		}
		public override Node ExitMove(Token node){node.Values.Add(ScriptKeyword.MOVE);
			return node;
		}
		public override Node ExitPosture(Token node){node.Values.Add(ScriptKeyword.POSTURE);
			return node;
		}
		public override Node ExitVoice(Token node){node.Values.Add(ScriptKeyword.VOICE);
			return node;
		}
		public override Node ExitRole(Token node){node.Values.Add(ScriptKeyword.ROLE);
			return node;
		}
		public override Node ExitOther(Token node){node.Values.Add(ScriptKeyword.OTHER);
			return node;
		}

		public override Node ExitSrc(Token node){node.Values.Add(ScriptKeyword.SRC);
			return node;
		}
		public override Node ExitTransition(Token node){node.Values.Add(ScriptKeyword.TRANSITION);
			return node;
		}
		public override Node ExitTime(Token node){node.Values.Add(ScriptKeyword.TIME);
			return node;
		}
		public override Node ExitType(Token node){node.Values.Add(ScriptKeyword.TYPE);
			return node;
		}
		public override Node ExitLevel(Token node){node.Values.Add(ScriptKeyword.LEVEL);
			return node;
		}
		public override Node ExitMode(Token node){node.Values.Add(ScriptKeyword.MODE);
			return node;
		}
		public override Node ExitPosition(Token node){node.Values.Add(ScriptKeyword.POSITION);
			return node;
		}
		public override Node ExitName(Token node){node.Values.Add(ScriptKeyword.NAME);
			return node;
		}
		public override Node ExitAnchor(Token node){node.Values.Add (ScriptKeyword.ANCHOR);
			return node;
		}
		public override Node ExitTagParameter(Token node){node.Values.Add (ScriptKeyword.TAG);
			return node;
		}
		public override Node ExitKey1(Token node){node.Values.Add (ScriptKeyword.KEY1);
			return node;
		}
		public override Node ExitKey2(Token node){node.Values.Add (ScriptKeyword.KEY2);
			return node;
		}
		public override Node ExitKey3(Token node){node.Values.Add (ScriptKeyword.KEY3);
			return node;
		}
		public override Node ExitKey4(Token node){node.Values.Add (ScriptKeyword.KEY4);
			return node;
		}
		public override Node ExitKey5(Token node){node.Values.Add (ScriptKeyword.KEY5);
			return node;
		}
		public override Node ExitKey6(Token node){node.Values.Add (ScriptKeyword.KEY6);
			return node;
		}
		public override Node ExitKey7(Token node){node.Values.Add (ScriptKeyword.KEY7);
			return node;
		}
		public override Node ExitKey8(Token node){node.Values.Add (ScriptKeyword.KEY8);
			return node;
		}
		public override Node ExitKey9(Token node){node.Values.Add (ScriptKeyword.KEY9);
			return node;
		}
		public override Node ExitLive2d(Token node){node.Values.Add (ScriptKeyword.LIVE2D);
			return node;
		}
		public override Node ExitZoom(Token node){node.Values.Add (ScriptKeyword.ZOOM);
			return node;
		}


		//Symbols
		public override Node ExitBracketLeft(Token node){node.Values.Add(ScriptKeyword.BRACKET_LEFT);
			return node;
		}
		public override Node ExitBracketRight(Token node){node.Values.Add(ScriptKeyword.BRACKET_RIGHT);
			return node;
		}
		public override Node ExitSquareBracketLeft(Token node){node.Values.Add(ScriptKeyword.SQUARE_BRACKET_LEFT);
			return node;
		}
		public override Node ExitSquareBracketRight(Token node){node.Values.Add(ScriptKeyword.SQUARE_BRACKET_RIGHT);
			return node;
		}
		public override Node ExitParentheseLeft(Token node){node.Values.Add(ScriptKeyword.PARENTHESE_LEFT);
			return node;
		}
		public override Node ExitParentheseRight(Token node){node.Values.Add(ScriptKeyword.PARENTHESE_RIGHT);
			return node;
		}
		public override Node ExitAngleBracketLeft(Token node){node.Values.Add(ScriptKeyword.ANGLE_BRACKET_LEFT);
			return node;
		}
		public override Node ExitDoubleQuote(Token node){node.Values.Add(ScriptKeyword.DOUBLE_QUOTE);
			return node;
		}
		public override Node ExitPeriod(Token node){node.Values.Add(ScriptKeyword.PERIOD);
			return node;
		}
		public override Node ExitComma(Token node){node.Values.Add(ScriptKeyword.COMMA);
			return node;
		}
		public override Node ExitSemicolon(Token node){node.Values.Add(ScriptKeyword.SEMICOLON);
			return node;
		}
		public override Node ExitEqual(Token node){node.Values.Add(ScriptKeyword.EQUAL);
			return node;
		}
		public override Node ExitClick(Token node){node.Values.Add(ScriptKeyword.CLICK);
			return node;
		}
		public override Node ExitClickNextDialoguePage(Token node){node.Values.Add(ScriptKeyword.CLICK_NEXT_DIALOGUE_PAGE);
			return node;
		}
		public override Node ExitOr(Token node){node.Values.Add(ScriptKeyword.OR);
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
			string quatedText = node.Image;
			quatedText = quatedText.Substring (1, quatedText.Length-2);
			node.Values.Add(quatedText);
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

