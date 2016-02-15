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

            pattern = new TokenPattern((int) DokiScriptConstants.KEYWORD,
                                       "KEYWORD",
                                       TokenPattern.PatternType.REGEXP,
                                       "[a-zA-Z_][0-9a-zA-Z_]*");
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

            pattern = new TokenPattern((int) DokiScriptConstants.SPACE,
                                       "SPACE",
                                       TokenPattern.PatternType.REGEXP,
                                       " +");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.WHITESPACE,
                                       "WHITESPACE",
                                       TokenPattern.PatternType.REGEXP,
                                       "[ \\t\\n\\r]+");
            pattern.Ignore = true;
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.ASSIGN,
                                       "ASSIGN",
                                       TokenPattern.PatternType.STRING,
                                       "=");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.QUATEDSTR,
                                       "QUATEDSTR",
                                       TokenPattern.PatternType.REGEXP,
                                       "\"(?:[^\"\\\\]|\\\\.)*\"");
            AddPattern(pattern);

            pattern = new TokenPattern((int) DokiScriptConstants.ESCAPEDSTR,
                                       "ESCAPEDSTR",
                                       TokenPattern.PatternType.REGEXP,
                                       "(?:[^\\\\]|\\\\.)*");
            AddPattern(pattern);
        }
    }
}
