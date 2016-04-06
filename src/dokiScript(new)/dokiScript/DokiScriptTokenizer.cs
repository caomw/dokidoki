/*
 * DokiScriptTokenizer.cs
 *
 * THIS FILE HAS BEEN GENERATED AUTOMATICALLY. DO NOT EDIT!
 */

using System.IO;

using PerCederberg.Grammatica.Runtime;

/**
 * <remarks>A character stream tokenizer.</remarks>
 */
internal class DokiScriptTokenizer : Tokenizer {

    /**
     * <summary>Creates a new tokenizer for the specified input
     * stream.</summary>
     *
     * <param name='input'>the input stream to read</param>
     *
     * <exception cref='ParserCreationException'>if the tokenizer
     * couldn't be initialized correctly</exception>
     */
    public DokiScriptTokenizer(TextReader input)
        : base(input, false) {

        CreatePatterns();
    }

    /**
     * <summary>Initializes the tokenizer by creating all the token
     * patterns.</summary>
     *
     * <exception cref='ParserCreationException'>if the tokenizer
     * couldn't be initialized correctly</exception>
     */
    private void CreatePatterns() {
        TokenPattern  pattern;

        pattern = new TokenPattern((int) DokiScriptConstants.WORLD,
                                   "WORLD",
                                   TokenPattern.PatternType.STRING,
                                   "world");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.BACKGROUND,
                                   "BACKGROUND",
                                   TokenPattern.PatternType.STRING,
                                   "background");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.WEATHER,
                                   "WEATHER",
                                   TokenPattern.PatternType.STRING,
                                   "weather");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.SOUND,
                                   "SOUND",
                                   TokenPattern.PatternType.STRING,
                                   "sound");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.BGM,
                                   "BGM",
                                   TokenPattern.PatternType.STRING,
                                   "bgm");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.VIDEO,
                                   "VIDEO",
                                   TokenPattern.PatternType.STRING,
                                   "video");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.MOVE,
                                   "MOVE",
                                   TokenPattern.PatternType.STRING,
                                   "move");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.POSTURE,
                                   "POSTURE",
                                   TokenPattern.PatternType.STRING,
                                   "posture");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.VOICE,
                                   "VOICE",
                                   TokenPattern.PatternType.STRING,
                                   "voice");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.ROLE,
                                   "ROLE",
                                   TokenPattern.PatternType.STRING,
                                   "role");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.SRC,
                                   "SRC",
                                   TokenPattern.PatternType.STRING,
                                   "src");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.TRANSITION,
                                   "TRANSITION",
                                   TokenPattern.PatternType.STRING,
                                   "transition");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.TRANSITION_INSTANT,
                                   "TRANSITION_INSTANT",
                                   TokenPattern.PatternType.STRING,
                                   "instant");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.TRANSITION_GRADUAL,
                                   "TRANSITION_GRADUAL",
                                   TokenPattern.PatternType.STRING,
                                   "gradual");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.SPEED,
                                   "SPEED",
                                   TokenPattern.PatternType.STRING,
                                   "speed");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.TYPE,
                                   "TYPE",
                                   TokenPattern.PatternType.STRING,
                                   "type");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.TYPE_SUNNY,
                                   "TYPE_SUNNY",
                                   TokenPattern.PatternType.STRING,
                                   "sunny");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.TYPE_RAIN,
                                   "TYPE_RAIN",
                                   TokenPattern.PatternType.STRING,
                                   "rain");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.TYPE_SNOW,
                                   "TYPE_SNOW",
                                   TokenPattern.PatternType.STRING,
                                   "snow");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.LEVEL,
                                   "LEVEL",
                                   TokenPattern.PatternType.STRING,
                                   "level");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.MODE,
                                   "MODE",
                                   TokenPattern.PatternType.STRING,
                                   "mode");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.MODE_LOOP,
                                   "MODE_LOOP",
                                   TokenPattern.PatternType.STRING,
                                   "loop");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.POSITION,
                                   "POSITION",
                                   TokenPattern.PatternType.STRING,
                                   "position");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.POSITION_CENTER,
                                   "POSITION_CENTER",
                                   TokenPattern.PatternType.STRING,
                                   "center");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.POSITION_LEFT,
                                   "POSITION_LEFT",
                                   TokenPattern.PatternType.STRING,
                                   "left");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.POSITION_RIGHT,
                                   "POSITION_RIGHT",
                                   TokenPattern.PatternType.STRING,
                                   "right");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.TYPE_PLAYER,
                                   "TYPE_PLAYER",
                                   TokenPattern.PatternType.STRING,
                                   "player");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.TYPE_CHARACTER,
                                   "TYPE_CHARACTER",
                                   TokenPattern.PatternType.STRING,
                                   "character");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.NAME,
                                   "NAME",
                                   TokenPattern.PatternType.STRING,
                                   "name");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.ANCHOR,
                                   "ANCHOR",
                                   TokenPattern.PatternType.STRING,
                                   "anchor");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.BRACKET_LEFT,
                                   "BRACKET_LEFT",
                                   TokenPattern.PatternType.STRING,
                                   "{");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.BRACKET_RIGHT,
                                   "BRACKET_RIGHT",
                                   TokenPattern.PatternType.STRING,
                                   "}");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.SQUARE_BRACKET_LEFT,
                                   "SQUARE_BRACKET_LEFT",
                                   TokenPattern.PatternType.STRING,
                                   "[");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.SQUARE_BRACKET_RIGHT,
                                   "SQUARE_BRACKET_RIGHT",
                                   TokenPattern.PatternType.STRING,
                                   "]");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.PARENTHESE_LEFT,
                                   "PARENTHESE_LEFT",
                                   TokenPattern.PatternType.STRING,
                                   "(");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.PARENTHESE_RIGHT,
                                   "PARENTHESE_RIGHT",
                                   TokenPattern.PatternType.STRING,
                                   ")");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.ANGLE_BRACKET_LEFT,
                                   "ANGLE_BRACKET_LEFT",
                                   TokenPattern.PatternType.STRING,
                                   "<");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.DOUBLE_QUOTE,
                                   "DOUBLE_QUOTE",
                                   TokenPattern.PatternType.STRING,
                                   "\"");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.PERIOD,
                                   "PERIOD",
                                   TokenPattern.PatternType.STRING,
                                   ".");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.COMMA,
                                   "COMMA",
                                   TokenPattern.PatternType.STRING,
                                   ",");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.SEMICOLON,
                                   "SEMICOLON",
                                   TokenPattern.PatternType.STRING,
                                   ";");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.EQUAL,
                                   "EQUAL",
                                   TokenPattern.PatternType.STRING,
                                   "=");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.CLICK,
                                   "CLICK",
                                   TokenPattern.PatternType.STRING,
                                   ">");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.CLICK_NEXT_DIALOGUE_PAGE,
                                   "CLICK_NEXT_DIALOGUE_PAGE",
                                   TokenPattern.PatternType.STRING,
                                   ">>");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.OR,
                                   "OR",
                                   TokenPattern.PatternType.STRING,
                                   "|");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.TAB,
                                   "TAB",
                                   TokenPattern.PatternType.REGEXP,
                                   "\\t+");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.RETURN,
                                   "RETURN",
                                   TokenPattern.PatternType.REGEXP,
                                   "[\\n\\r]+");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.SPACE,
                                   "SPACE",
                                   TokenPattern.PatternType.REGEXP,
                                   " +");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.IDENTIFIER,
                                   "IDENTIFIER",
                                   TokenPattern.PatternType.REGEXP,
                                   "[a-zA-Z_][0-9a-zA-Z_]*");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.DECIMAL,
                                   "DECIMAL",
                                   TokenPattern.PatternType.REGEXP,
                                   "[01]\\.?\\d*");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.TEXT,
                                   "TEXT",
                                   TokenPattern.PatternType.REGEXP,
                                   ">.*");
        AddPattern(pattern);

        pattern = new TokenPattern((int) DokiScriptConstants.QUOTED_TEXT,
                                   "QUOTED_TEXT",
                                   TokenPattern.PatternType.REGEXP,
                                   "\"[^\"]*\"");
        AddPattern(pattern);
    }
}
