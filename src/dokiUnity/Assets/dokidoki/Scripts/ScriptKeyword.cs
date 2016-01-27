using UnityEngine;
using System.Collections;

public class ScriptKeyword{
    
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

    //parameter keywords
    //background src=xxx transition=(instant|gradual) speed=0.xxx;
    public const string SRC = "src";
    public const string TRANSITION = "transition";
    public const string TRANSITION_INSTANT = "instant";
    public const string TRANSITION_GRADUAL = "gradual";
    public const string SPEED = "speed";
        //weather type=(sunny|cloudy|rain|snow) level=xxx transition=xxx speed=xxx;
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
        //move position=(center|left|right|(0.xxx,0.xxx,0.xxx)) transition=(instant|gradual) speed=0.xxx
    public const string POSITION = "position";
    public const string POSITION_CENTER = "center";
    public const string POSITION_LEFT = "left";
    public const string POSITION_RIGHT = "right";
        //posture src=xxx
        //face src=xxx
        //voice src=xxx
        //role type=(player|character) name=xxx
    public const string TYPE_PLAYER = "player";
    public const string TYPE_CHARACTER = "character";
    public const string NAME = "name";
    //focusId
    public const string ID = "id";

    //symbol keywords
    public const string BRACKET_LEFT = "{";
    public const string BRACKET_RIGHT = "}";
    public const string PARENTHESE_LEFT = "(";
    public const string PARENTHESE_RIGHT = ")";
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
}
