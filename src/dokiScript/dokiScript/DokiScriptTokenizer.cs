/*
 * DokiScriptTokenizer.cs
 *
 * THIS FILE HAS BEEN GENERATED AUTOMATICALLY. DO NOT EDIT!
 */

using System.IO;

using PerCederberg.Grammatica.Runtime;

namespace UnlimitedCodeWorks {

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

            pattern = new TokenPattern((int) DokiScriptConstants.LBRACE,
                                       "LBRACE",
                                       TokenPattern.PatternType.STRING,
                                       "{");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.RBRACE,
                                       "RBRACE",
                                       TokenPattern.PatternType.STRING,
                                       "}");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.DOUBLEMARK,
                                       "DOUBLEMARK",
                                       TokenPattern.PatternType.STRING,
                                       ">>");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.SINGLEMARK,
                                       "SINGLEMARK",
                                       TokenPattern.PatternType.STRING,
                                       ">");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.SEMI,
                                       "SEMI",
                                       TokenPattern.PatternType.STRING,
                                       ";");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.LPARA,
                                       "LPARA",
                                       TokenPattern.PatternType.STRING,
                                       "(");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.RPARA,
                                       "RPARA",
                                       TokenPattern.PatternType.STRING,
                                       ")");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.SEP,
                                       "SEP",
                                       TokenPattern.PatternType.STRING,
                                       "\\n");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.WORLD_ID,
                                       "WORLD_ID",
                                       TokenPattern.PatternType.STRING,
                                       "world");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.ID,
                                       "ID",
                                       TokenPattern.PatternType.STRING,
                                       "id");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.WORD,
                                       "WORD",
                                       TokenPattern.PatternType.REGEXP,
                                       "\\w");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.NUMBER,
                                       "NUMBER",
                                       TokenPattern.PatternType.REGEXP,
                                       "[-+]?[0-9]*\\.?[0-9]+([eE][-+]?[0-9]+)?");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.COMMA,
                                       "COMMA",
                                       TokenPattern.PatternType.STRING,
                                       ",");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.NONCOMMA,
                                       "NONCOMMA",
                                       TokenPattern.PatternType.REGEXP,
                                       "[^,]+");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.WHITESPACE,
                                       "WHITESPACE",
                                       TokenPattern.PatternType.REGEXP,
                                       "[ \\t\\n\\r]+");
            pattern.Ignore = true;
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.TAG_BG,
                                       "TAG_BG",
                                       TokenPattern.PatternType.STRING,
                                       "background");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.TAG_WT,
                                       "TAG_WT",
                                       TokenPattern.PatternType.STRING,
                                       "weather");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.TAG_SND,
                                       "TAG_SND",
                                       TokenPattern.PatternType.STRING,
                                       "sound");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.TAG_BGM,
                                       "TAG_BGM",
                                       TokenPattern.PatternType.STRING,
                                       "bgm");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.TAG_VI,
                                       "TAG_VI",
                                       TokenPattern.PatternType.STRING,
                                       "video");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.TAG_MV,
                                       "TAG_MV",
                                       TokenPattern.PatternType.STRING,
                                       "move");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.TAG_POS,
                                       "TAG_POS",
                                       TokenPattern.PatternType.STRING,
                                       "posture");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.TAG_FACE,
                                       "TAG_FACE",
                                       TokenPattern.PatternType.STRING,
                                       "face");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.TAG_VO,
                                       "TAG_VO",
                                       TokenPattern.PatternType.STRING,
                                       "voide");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.TAG_ROLE,
                                       "TAG_ROLE",
                                       TokenPattern.PatternType.STRING,
                                       "role");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.ASSIGN,
                                       "ASSIGN",
                                       TokenPattern.PatternType.STRING,
                                       "=");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.KEY_SRC,
                                       "KEY_SRC",
                                       TokenPattern.PatternType.STRING,
                                       "src");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.KEY_TRANS,
                                       "KEY_TRANS",
                                       TokenPattern.PatternType.STRING,
                                       "transition");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.KEY_SPD,
                                       "KEY_SPD",
                                       TokenPattern.PatternType.STRING,
                                       "speed");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.KEY_TYPE,
                                       "KEY_TYPE",
                                       TokenPattern.PatternType.STRING,
                                       "type");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.KEY_LV,
                                       "KEY_LV",
                                       TokenPattern.PatternType.STRING,
                                       "level");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.KEY_MODE,
                                       "KEY_MODE",
                                       TokenPattern.PatternType.STRING,
                                       "mode");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.KEY_POS,
                                       "KEY_POS",
                                       TokenPattern.PatternType.STRING,
                                       "position");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.KEY_NAME,
                                       "KEY_NAME",
                                       TokenPattern.PatternType.STRING,
                                       "name");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.VAL_INST,
                                       "VAL_INST",
                                       TokenPattern.PatternType.STRING,
                                       "instant");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.VAL_GRAD,
                                       "VAL_GRAD",
                                       TokenPattern.PatternType.STRING,
                                       "gradual");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.VAL_SUNNY,
                                       "VAL_SUNNY",
                                       TokenPattern.PatternType.STRING,
                                       "sunny");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.VAL_CLOUDY,
                                       "VAL_CLOUDY",
                                       TokenPattern.PatternType.STRING,
                                       "cloudy");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.VAL_RAIN,
                                       "VAL_RAIN",
                                       TokenPattern.PatternType.STRING,
                                       "rain");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.VAL_SNOW,
                                       "VAL_SNOW",
                                       TokenPattern.PatternType.STRING,
                                       "snow");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.VAL_LOOP,
                                       "VAL_LOOP",
                                       TokenPattern.PatternType.STRING,
                                       "loop");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.VAL_CENTER,
                                       "VAL_CENTER",
                                       TokenPattern.PatternType.STRING,
                                       "center");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.VAL_LEFT,
                                       "VAL_LEFT",
                                       TokenPattern.PatternType.STRING,
                                       "left");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.VAL_RIGHT,
                                       "VAL_RIGHT",
                                       TokenPattern.PatternType.STRING,
                                       "right");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.VAL_PLAYER,
                                       "VAL_PLAYER",
                                       TokenPattern.PatternType.STRING,
                                       "player");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.VAL_CH,
                                       "VAL_CH",
                                       TokenPattern.PatternType.STRING,
                                       "character");
            AddPattern(pattern);
        }
    }
}
