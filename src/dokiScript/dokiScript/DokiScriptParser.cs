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
            SUBPRODUCTION_2 = 3002,
            SUBPRODUCTION_3 = 3003
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
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.LBRACE, 1, 1);
            alt.AddProduction((int) DokiScriptConstants.BLOCK, 1, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_2, 0, -1);
            alt.AddToken((int) DokiScriptConstants.RBRACE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) DokiScriptConstants.BLOCK,
                                            "Block");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.WORLD_ID, 1, 1);
            alt.AddProduction((int) DokiScriptConstants.ACTION, 1, -1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.ID, 1, 1);
            alt.AddProduction((int) DokiScriptConstants.ACTION, 1, -1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) DokiScriptConstants.ACTION,
                                            "Action");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.WORD, 1, -1);
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
            alt.AddToken((int) DokiScriptConstants.TAG_BG, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.TAG_WT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.TAG_SND, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.TAG_BGM, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.TAG_VI, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.TAG_MV, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.TAG_POS, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.TAG_FACE, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.TAG_VO, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.TAG_ROLE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) DokiScriptConstants.PARAMETERS,
                                            "Parameters");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) DokiScriptConstants.KEY, 1, 1);
            alt.AddToken((int) DokiScriptConstants.ASSIGN, 1, 1);
            alt.AddProduction((int) DokiScriptConstants.VALUE, 1, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_3, 0, -1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) DokiScriptConstants.KEY,
                                            "Key");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.KEY_SRC, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.KEY_TRANS, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.KEY_SPD, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.KEY_TYPE, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.KEY_LV, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.KEY_MODE, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.KEY_POS, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.KEY_NAME, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) DokiScriptConstants.VALUE,
                                            "Value");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.NONCOMMA, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_1,
                                            "Subproduction1");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.SEP, 1, 1);
            alt.AddProduction((int) DokiScriptConstants.BLOCK, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_2,
                                            "Subproduction2");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.SEP, 1, 1);
            alt.AddProduction((int) DokiScriptConstants.BLOCK, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_3,
                                            "Subproduction3");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) DokiScriptConstants.COMMA, 1, 1);
            alt.AddProduction((int) DokiScriptConstants.KEY, 1, 1);
            alt.AddToken((int) DokiScriptConstants.ASSIGN, 1, 1);
            alt.AddProduction((int) DokiScriptConstants.VALUE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);
        }
    }
}
