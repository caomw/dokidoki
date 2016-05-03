using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace dokidoki.dokiScriptSetting{
	[System.Serializable()]
	/// <summary>
	/// Action is the minimal unit action that World or Character could take.
	/// Originally, pre-defined actions are defined in ScriptKeyword.
	/// </summary>
	public class Action{
		/// <summary>
		/// The tag of the action, which is defined in ScriptKeyword
		/// </summary>
	    public readonly string tag;
		/// <summary>
		/// The parameters of current actions, which format is defined in ScriptKeyword
		/// </summary>
	    public readonly Dictionary<string, string> parameters;

		public Action(){}

		/// <summary>
		/// Initializes a new instance of the <see cref="dokiScriptSetting.Action"/> class.
		/// </summary>
		/// <param name="tag">Tag of the action</param>
		/// <param name="parameters">Parameters of the action</param>
	    public Action(string tag, Dictionary<string, string> parameters) {
	        this.tag = tag;
	        this.parameters = parameters;
	    }
	}
}