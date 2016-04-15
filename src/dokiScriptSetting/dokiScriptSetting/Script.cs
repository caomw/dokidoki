using System;
using System.Collections.Generic;

namespace dokiScriptSetting
{
	/// <summary>
	/// Script represents one script file which is compiled into an object.
	/// Script is a set of Actions.
	/// </summary>
	[System.Serializable()]
	public class Script
	{
		/// <summary>
		/// The list of actions compiled from script file
		/// </summary>
		public List<Action> actions;
	}
}