using System;
using System.Drawing;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;

using dokidoki.dokiScriptCompiler;

namespace dokiScriptCompilerForMac
{
	class MainClass
	{
		static void Main (string [] args)
		{
			string s = Environment.CurrentDirectory;
			args = new string [] { s};
			DokiScriptSerializer._Main (args);
			NSApplication.Init ();
			NSApplication.Main (args);
		}
	}
}

