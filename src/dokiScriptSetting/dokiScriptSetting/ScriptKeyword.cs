﻿using System.Collections;

namespace dokidoki.dokiScriptSetting{
	/// <summary>
	/// ScriptKeyword is the pre-defined related keywords of script
	/// </summary>
	public class ScriptKeyword{

		//file extension
		public const string SCRIPT_EXTENSION = "dks";
		public const string SCRIPT_COMPILED_EXTENSION = "bytes";
		public const string LIVE2D_MOC_EXTENSION = "moc";
		public const string LIVE2D_PHYSICS_EXTENSION = "physics.json";
		public const string LIVE2D_TEXTURE_EXTENSION = "texture";
	    
	    //world keyword
	    public const string WORLD = "world";

	    //action keywords, and parameter keywords
	    public const string BACKGROUND = "background";
	    public const string WEATHER = "weather";
	    public const string SOUND = "sound";
	    public const string BGM = "bgm";
	    public const string VIDEO = "video";
	    public const string TEXT = "text";
	    public const string MOVE = "move";
	    public const string POSTURE = "posture";
	    public const string FACE = "face";
	    public const string VOICE = "voice";
	    public const string ROLE = "role";
	    public const string FOCUS = "focus";
	    public const string FLAG = "flag";
		public const string OPTION = "option";
		public const string JUMP = "jump";
		public const string OTHER = "other";

	    //parameter keywords
	    	//background src=xxx transition=(instant|gradual) time=0.xxx;
	    public const string SRC = "src";
	    public const string TRANSITION = "transition";
	    public const string TRANSITION_INSTANT = "instant";
	    public const string TRANSITION_FADE = "fade";
		public const string TRANSITION_PIXELATE = "pixelate";
		public const string TRANSITION_SQUARE = "square";
		public const string TRANSITION_MASK = "mask";
		public const string TRANSITION_FISH_EYE = "fishEye";
	    public const string TIME = "time";
	        //weather type=(sunny|cloudy|rain|snow) level=xxx transition=xxx time=xxx;
	    public const string TYPE = "type";
	    public const string TYPE_SUNNY = "sunny";
	    public const string TYPE_CLOUDY = "cloudy";
	    public const string TYPE_RAIN = "rain";
	    public const string TYPE_SNOW = "snow";
	    public const string LEVEL = "level";
	        //sound src=xxx 
	        //bgm src=xxx mode=(loop|1|2|...)
	    public const string MODE = "mode";
	    public const string MODE_LOOP = "loop";
	        //video src=xxx
	        //textContent (>|>>)
	    public const string CONTENT = "content";
	        //move position=(center|left|right|(0.xxx,0.xxx,0.xxx)) transition=(instant|gradual) time=0.xxx
	    public const string POSITION = "position";
	    public const string POSITION_CENTER = "center";
	    public const string POSITION_LEFT = "left";
	    public const string POSITION_RIGHT = "right";
			//posture src=xxx anchor=(0.xxx, 0.xxx);
		public const string ANCHOR="anchor";
			//face src=xxx;
			//voice src=xxx content=(>|>>)xxx;
			//role type=(player|character) name=xxx;
	    public const string TYPE_PLAYER = "player";
	    public const string TYPE_CHARACTER = "character";
	    public const string NAME = "name";
	    //focusId
	    public const string ID = "id";
	    //[xxx(xxx, xxx) | xxx(xxx, xxx) ...]
	        //the option number
	    public const string COUNT = "count";
	    
	        //the first option src dokiscript
	        //The OPTION_ and OPTION_SRC_ used only for iterate
	    public const string OPTION_ = "option";
		public const string OPTION_ID_ = "optionId";
	    public const string OPTION_SRC_ = "optionSrc";
		//the first option
		public const string OPTION_1 = "option1";
		public const string OPTION_ID_1 = "optionId1";
	    public const string OPTION_SRC_1 = "optionSrc1";
	    public const string OPTION_2 = "option2";
		public const string OPTION_ID_2 = "optionId2";
	    public const string OPTION_SRC_2 = "optionSrc2";
	    public const string OPTION_3 = "option3";
		public const string OPTION_ID_3 = "optionId3";
	    public const string OPTION_SRC_3 = "optionSrc3";
	    public const string OPTION_4 = "option4";
		public const string OPTION_ID_4 = "optionId4";
	    public const string OPTION_SRC_4 = "optionSrc4";
	    public const string OPTION_5 = "option5";
		public const string OPTION_ID_5 = "optionId5";
	    public const string OPTION_SRC_5 = "optionSrc5";
	    public const string OPTION_6 = "option6";
		public const string OPTION_ID_6 = "optionId6";
	    public const string OPTION_SRC_6 = "optionSrc6";
	    public const string OPTION_7 = "option7";
		public const string OPTION_ID_7 = "optionId7";
	    public const string OPTION_SRC_7 = "optionSrc7";
	    public const string OPTION_8 = "option8";
		public const string OPTION_ID_8 = "optionId8";
	    public const string OPTION_SRC_8 = "optionSrc8";
	    public const string OPTION_9 = "option9";
		public const string OPTION_ID_9 = "optionId9";
	    public const string OPTION_SRC_9 = "optionSrc9";
			//other tag=xxx ...;
		public const string TAG = "tag";
		public const string KEY1 = "key1";
		public const string KEY2 = "key2";
		public const string KEY3 = "key3";
		public const string KEY4 = "key4";
		public const string KEY5 = "key5";
		public const string KEY6 = "key6";
		public const string KEY7 = "key7";
		public const string KEY8 = "key8";
		public const string KEY9 = "key9";
		public const string LIVE2D = "live2d";
		public const string ZOOM = "zoom";
			

	    //symbol keywords
	    public const string BRACKET_LEFT = "{";
	    public const string BRACKET_RIGHT = "}";
	    public const string SQUARE_BRACKET_LEFT = "[";
	    public const string SQUARE_BRACKET_RIGHT = "]";
	    public const string PARENTHESE_LEFT = "(";
	    public const string PARENTHESE_RIGHT = ")";
	    public const string ANGLE_BRACKET_LEFT = "<";
	    public const string DOUBLE_QUOTE = "\"";
	    public const string PERIOD = ".";
	    public const string COMMA = ",";
	    public const string SEMICOLON = ";";
	    public const string EQUAL = "=";
	    public const string CLICK = ">";
	    public const string CLICK_NEXT_DIALOGUE_PAGE = ">>";
	    public const string STRING = "\"";
	    public const string TAB = "\t";
	    public const string ENTER = "\n";
	    public const string COMMENT = "//";
	    public const string COMMENT_START = "/*";
	    public const string COMMENT_END = "*/";
	    public const string ASSIGN = "=";
	    public const string OR = "|";
	}
}
