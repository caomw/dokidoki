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

    //parameter keywords
        //background src=xxx transition=(instant|gradual) speed=0.xxx;
    public const string SRC = "src";
    public const string TRANSITION = "transition";
    public const string TRANSITION_INSTANT = "instant";
    public const string TRANSITION_GRADUAL = "gradual";
    public const string SPEED = "speed";
        //weather type=xxx level=xxx transition=xxx speed=xxx;
    public const string TYPE = "type";
    public const string LEVEL = "level";
        //sound src=xxx 
        //bgm src=xxx mode=(loop|1|2|...)
    public const string MODE = "mode";
    public const string LOOP = "loop";
        //video src=xxx
        //text (>|>>)
    public const string TEXT_CLICK = ">";
    public const string TEXT_DOUBLE_CLICK = ">>";
        //move position=(center|left|right|(0.xxx,0.xxx,0.xxx)) transition=(instant|gradual) speed=0.xxx
    public const string POSITION = "position";
    public const string POSITION_CENTER = "center";
    public const string POSITION_LEFT = "left";
    public const string POSITION_RIGHT = "right";
        //posture src=xxx
        //face src=xxx
        //voice src=xxx
}
