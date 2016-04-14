/*
 * DokiScriptParser.cs
 *
 * THIS FILE HAS BEEN GENERATED AUTOMATICALLY. DO NOT EDIT!
 */

using System.IO;

using PerCederberg.Grammatica.Runtime;

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
        SUBPRODUCTION_3 = 3003,
        SUBPRODUCTION_4 = 3004,
        SUBPRODUCTION_5 = 3005
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

        pattern = new ProductionPattern((int) DokiScriptConstants.DOKI,
                                        "Doki");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) DokiScriptConstants.PART, 1, -1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) DokiScriptConstants.PART,
                                        "Part");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) DokiScriptConstants.BLOCK, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) DokiScriptConstants.FLAG, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) DokiScriptConstants.OPTION, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) DokiScriptConstants.JUMP, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) DokiScriptConstants.BLOCK,
                                        "Block");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.WORLD, 1, 1);
        alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_1, 1, -1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddToken((int) DokiScriptConstants.RETURN, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.IDENTIFIER, 1, 1);
        alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_2, 1, -1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddToken((int) DokiScriptConstants.RETURN, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) DokiScriptConstants.ACTION,
                                        "Action");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.TAB, 1, 1);
        alt.AddProduction((int) DokiScriptConstants.VOICE_ACTION, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.TAB, 1, 1);
        alt.AddProduction((int) DokiScriptConstants.OTHER_ACTION, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.TAB, 1, 1);
        alt.AddToken((int) DokiScriptConstants.TEXT, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) DokiScriptConstants.VOICE_ACTION,
                                        "VoiceAction");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.VOICE, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 1, 1);
        alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_3, 0, -1);
        alt.AddToken((int) DokiScriptConstants.TEXT, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) DokiScriptConstants.OTHER_ACTION,
                                        "OtherAction");
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) DokiScriptConstants.TAG, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 1, 1);
        alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_4, 0, -1);
        alt.AddToken((int) DokiScriptConstants.SEMICOLON, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) DokiScriptConstants.TAG,
                                        "Tag");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.BACKGROUND, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.WEATHER, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.SOUND, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.BGM, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.VIDEO, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.MOVE, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.POSTURE, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.ROLE, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) DokiScriptConstants.KEY,
                                        "Key");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.SRC, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.TRANSITION, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.TYPE, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.LEVEL, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.MODE, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.POSITION, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.NAME, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.ANCHOR, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) DokiScriptConstants.VALUE,
                                        "Value");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.PARENTHESE_LEFT, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddToken((int) DokiScriptConstants.DECIMAL, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddToken((int) DokiScriptConstants.COMMA, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddToken((int) DokiScriptConstants.DECIMAL, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddToken((int) DokiScriptConstants.COMMA, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddToken((int) DokiScriptConstants.DECIMAL, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddToken((int) DokiScriptConstants.PARENTHESE_RIGHT, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.PARENTHESE_LEFT, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddToken((int) DokiScriptConstants.DECIMAL, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddToken((int) DokiScriptConstants.COMMA, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddToken((int) DokiScriptConstants.DECIMAL, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddToken((int) DokiScriptConstants.PARENTHESE_RIGHT, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.TRANSITION_INSTANT, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.TRANSITION_GRADUAL, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.TYPE_SUNNY, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.TYPE_RAIN, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.TYPE_SNOW, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.MODE_LOOP, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.POSITION_CENTER, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.POSITION_LEFT, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.POSITION_RIGHT, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.TYPE_PLAYER, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.TYPE_CHARACTER, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.IDENTIFIER, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.DECIMAL, 1, 1);
        pattern.AddAlternative(alt);
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.QUOTED_TEXT, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) DokiScriptConstants.FLAG,
                                        "Flag");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.SQUARE_BRACKET_LEFT, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddToken((int) DokiScriptConstants.QUOTED_TEXT, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddToken((int) DokiScriptConstants.PARENTHESE_LEFT, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddToken((int) DokiScriptConstants.IDENTIFIER, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddToken((int) DokiScriptConstants.COMMA, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddToken((int) DokiScriptConstants.IDENTIFIER, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddToken((int) DokiScriptConstants.PARENTHESE_RIGHT, 1, 1);
        alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_5, 0, -1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddToken((int) DokiScriptConstants.SQUARE_BRACKET_RIGHT, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddToken((int) DokiScriptConstants.RETURN, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) DokiScriptConstants.OPTION,
                                        "Option");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.ANGLE_BRACKET_LEFT, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddToken((int) DokiScriptConstants.IDENTIFIER, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddToken((int) DokiScriptConstants.CLICK, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddToken((int) DokiScriptConstants.RETURN, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) DokiScriptConstants.JUMP,
                                        "Jump");
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.PARENTHESE_LEFT, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddToken((int) DokiScriptConstants.IDENTIFIER, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddToken((int) DokiScriptConstants.PARENTHESE_RIGHT, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddToken((int) DokiScriptConstants.RETURN, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_1,
                                        "Subproduction1");
        pattern.Synthetic = true;
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.RETURN, 0, 1);
        alt.AddProduction((int) DokiScriptConstants.ACTION, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_2,
                                        "Subproduction2");
        pattern.Synthetic = true;
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.RETURN, 0, 1);
        alt.AddProduction((int) DokiScriptConstants.ACTION, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_3,
                                        "Subproduction3");
        pattern.Synthetic = true;
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) DokiScriptConstants.KEY, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddToken((int) DokiScriptConstants.EQUAL, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddProduction((int) DokiScriptConstants.VALUE, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_4,
                                        "Subproduction4");
        pattern.Synthetic = true;
        alt = new ProductionPatternAlternative();
        alt.AddProduction((int) DokiScriptConstants.KEY, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddToken((int) DokiScriptConstants.EQUAL, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddProduction((int) DokiScriptConstants.VALUE, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);

        pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_5,
                                        "Subproduction5");
        pattern.Synthetic = true;
        alt = new ProductionPatternAlternative();
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddToken((int) DokiScriptConstants.OR, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddToken((int) DokiScriptConstants.QUOTED_TEXT, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddToken((int) DokiScriptConstants.PARENTHESE_LEFT, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddToken((int) DokiScriptConstants.IDENTIFIER, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddToken((int) DokiScriptConstants.COMMA, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddToken((int) DokiScriptConstants.IDENTIFIER, 1, 1);
        alt.AddToken((int) DokiScriptConstants.SPACE, 0, 1);
        alt.AddToken((int) DokiScriptConstants.PARENTHESE_RIGHT, 1, 1);
        pattern.AddAlternative(alt);
        AddPattern(pattern);
    }
}
