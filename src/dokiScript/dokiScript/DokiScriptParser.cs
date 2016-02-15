/*
 * DokiScriptParser.cs
 *
 * THIS FILE HAS BEEN GENERATED AUTOMATICALLY. DO NOT EDIT!
 */

using System.IO;

using PerCederberg.Grammatica.Runtime;

namespace UnlimitedCodeWorks {

    /**
     * <remarks>A token stream parser.</remarks>
     */
    internal class DokiScriptParser : RecursiveDescentParser {

        /**
         * <summary>An enumeration with the generated production node
         * identity constants.</summary>
         */
        private enum SynteticPatterns {
            SUBPRODUCTION_1 = 3001,
            SUBPRODUCTION_2 = 3002
        }

        /**
         * <summary>Creates a new parser with a default analyzer.</summary>
         *
         * <param name='input'>the input stream to read from</param>
         *
         * <exception cref='ParserCreationException'>if the parser
         * couldn't be initialized correctly</exception>
         */
        public DokiScriptParser(TextReader input)
            : base(input) {

            CreatePatterns();
        }

        /**
         * <summary>Creates a new parser.</summary>
         *
         * <param name='input'>the input stream to read from</param>
         *
         * <param name='analyzer'>the analyzer to parse with</param>
         *
         * <exception cref='ParserCreationException'>if the parser
         * couldn't be initialized correctly</exception>
         */
        public DokiScriptParser(TextReader input, DokiScriptAnalyzer analyzer)
            : base(input, analyzer) {

            CreatePatterns();
        }

        /**
         * <summary>Creates a new tokenizer for this parser. Can be overridden
         * by a subclass to provide a custom implementation.</summary>
         *
         * <param name='input'>the input stream to read from</param>
         *
         * <returns>the tokenizer created</returns>
         *
         * <exception cref='ParserCreationException'>if the tokenizer
         * couldn't be initialized correctly</exception>
         */
        protected override Tokenizer NewTokenizer(TextReader input) {
            return new DokiScriptTokenizer(input);
        }

        /**
         * <summary>Initializes the parser by creating all the production
         * patterns.</summary>
         *
         * <exception cref='ParserCreationException'>if the parser
         * couldn't be initialized correctly</exception>
         */
        private void CreatePatterns() {
            ProductionPattern             pattern;
            ProductionPatternAlternative  alt;

            pattern = new ProductionPattern((int) DokiScriptConstants.SCRIPT,
                                            "Script");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) DokiScriptConstants.BLOCK, 1, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_1, 0, -1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) DokiScriptConstants.BLOCK,
                                            "Block");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) DokiScriptConstants.OBJECT_ID, 1, 1);
            alt.AddProduction((int) DokiScriptConstants.ACTION_LIST, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) DokiScriptConstants.OBJECT_ID,
                                            "ObjectId");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.KEYWORD, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) DokiScriptConstants.ACTION_LIST,
                                            "ActionList");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) DokiScriptConstants.ACTION, 1, -1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.LBRACE, 1, 1);
            alt.AddProduction((int) DokiScriptConstants.ACTION, 1, -1);
            alt.AddToken((int) DokiScriptConstants.RBRACE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) DokiScriptConstants.ACTION,
                                            "Action");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) DokiScriptConstants.DIALOGUE_STR, 1, 1);
            alt.AddProduction((int) DokiScriptConstants.DIALOGUE_MARK, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) DokiScriptConstants.TAG, 1, 1);
            alt.AddProduction((int) DokiScriptConstants.PARAMETERS, 1, 1);
            alt.AddToken((int) DokiScriptConstants.SEMI, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) DokiScriptConstants.DIALOGUE_MARK,
                                            "DialogueMark");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.SINGLEMARK, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.DOUBLEMARK, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) DokiScriptConstants.TAG,
                                            "Tag");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.KEYWORD, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) DokiScriptConstants.PARAMETERS,
                                            "Parameters");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) DokiScriptConstants.KEY, 1, 1);
            alt.AddToken((int) DokiScriptConstants.ASSIGN, 1, 1);
            alt.AddProduction((int) DokiScriptConstants.VALUE, 1, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_2, 0, -1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) DokiScriptConstants.PARAMETER_SEP,
                                            "ParameterSep");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.SPACE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) DokiScriptConstants.KEY,
                                            "Key");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.KEYWORD, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) DokiScriptConstants.VALUE,
                                            "Value");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) DokiScriptConstants.QUATED_VALUE_STR, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) DokiScriptConstants.VECTOR, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.KEYWORD, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) DokiScriptConstants.VECTOR,
                                            "Vector");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.NUMBER, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.LPARA, 1, 1);
            alt.AddToken((int) DokiScriptConstants.NUMBER, 1, 1);
            alt.AddToken((int) DokiScriptConstants.COMMA, 1, 1);
            alt.AddToken((int) DokiScriptConstants.NUMBER, 1, 1);
            alt.AddToken((int) DokiScriptConstants.COMMA, 1, 1);
            alt.AddToken((int) DokiScriptConstants.NUMBER, 1, 1);
            alt.AddToken((int) DokiScriptConstants.RPARA, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) DokiScriptConstants.DIALOGUE_STR,
                                            "DialogueStr");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.ESCAPEDSTR, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) DokiScriptConstants.QUATED_VALUE_STR,
                                            "QuatedValueStr");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.QUATEDSTR, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_1,
                                            "Subproduction1");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.WHITESPACE, 1, 1);
            alt.AddProduction((int) DokiScriptConstants.BLOCK, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_2,
                                            "Subproduction2");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) DokiScriptConstants.PARAMETER_SEP, 1, 1);
            alt.AddProduction((int) DokiScriptConstants.KEY, 1, 1);
            alt.AddToken((int) DokiScriptConstants.ASSIGN, 1, 1);
            alt.AddProduction((int) DokiScriptConstants.VALUE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);
        }
    }
}
