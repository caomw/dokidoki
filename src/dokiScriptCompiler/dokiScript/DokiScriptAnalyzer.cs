/*
 * DokiScriptAnalyzer.cs
 *
 * THIS FILE HAS BEEN GENERATED AUTOMATICALLY. DO NOT EDIT!
 */

using PerCederberg.Grammatica.Runtime;

/**
 * <remarks>A class providing callback methods for the
 * parser.</remarks>
 */
internal abstract class DokiScriptAnalyzer : Analyzer {

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public override void Enter(Node node) {
        switch (node.Id) {
        case (int) DokiScriptConstants.WORLD:
            EnterWorld((Token) node);
            break;
        case (int) DokiScriptConstants.BACKGROUND:
            EnterBackground((Token) node);
            break;
        case (int) DokiScriptConstants.WEATHER:
            EnterWeather((Token) node);
            break;
        case (int) DokiScriptConstants.SOUND:
            EnterSound((Token) node);
            break;
        case (int) DokiScriptConstants.BGM:
            EnterBgm((Token) node);
            break;
        case (int) DokiScriptConstants.VIDEO:
            EnterVideo((Token) node);
            break;
        case (int) DokiScriptConstants.MOVE:
            EnterMove((Token) node);
            break;
        case (int) DokiScriptConstants.POSTURE:
            EnterPosture((Token) node);
            break;
        case (int) DokiScriptConstants.VOICE:
            EnterVoice((Token) node);
            break;
        case (int) DokiScriptConstants.ROLE:
            EnterRole((Token) node);
            break;
        case (int) DokiScriptConstants.OTHER:
            EnterOther((Token) node);
            break;
        case (int) DokiScriptConstants.SRC:
            EnterSrc((Token) node);
            break;
        case (int) DokiScriptConstants.TRANSITION:
            EnterTransition((Token) node);
            break;
        case (int) DokiScriptConstants.TIME:
            EnterTime((Token) node);
            break;
        case (int) DokiScriptConstants.TYPE:
            EnterType((Token) node);
            break;
        case (int) DokiScriptConstants.LEVEL:
            EnterLevel((Token) node);
            break;
        case (int) DokiScriptConstants.MODE:
            EnterMode((Token) node);
            break;
        case (int) DokiScriptConstants.POSITION:
            EnterPosition((Token) node);
            break;
        case (int) DokiScriptConstants.NAME:
            EnterName((Token) node);
            break;
        case (int) DokiScriptConstants.ANCHOR:
            EnterAnchor((Token) node);
            break;
        case (int) DokiScriptConstants.TAG_PARAMETER:
            EnterTagParameter((Token) node);
            break;
        case (int) DokiScriptConstants.KEY1:
            EnterKey1((Token) node);
            break;
        case (int) DokiScriptConstants.KEY2:
            EnterKey2((Token) node);
            break;
        case (int) DokiScriptConstants.KEY3:
            EnterKey3((Token) node);
            break;
        case (int) DokiScriptConstants.KEY4:
            EnterKey4((Token) node);
            break;
        case (int) DokiScriptConstants.KEY5:
            EnterKey5((Token) node);
            break;
        case (int) DokiScriptConstants.KEY6:
            EnterKey6((Token) node);
            break;
        case (int) DokiScriptConstants.KEY7:
            EnterKey7((Token) node);
            break;
        case (int) DokiScriptConstants.KEY8:
            EnterKey8((Token) node);
            break;
        case (int) DokiScriptConstants.KEY9:
            EnterKey9((Token) node);
            break;
        case (int) DokiScriptConstants.LIVE2D:
            EnterLive2d((Token) node);
            break;
        case (int) DokiScriptConstants.ZOOM:
            EnterZoom((Token) node);
            break;
        case (int) DokiScriptConstants.BRACKET_LEFT:
            EnterBracketLeft((Token) node);
            break;
        case (int) DokiScriptConstants.BRACKET_RIGHT:
            EnterBracketRight((Token) node);
            break;
        case (int) DokiScriptConstants.SQUARE_BRACKET_LEFT:
            EnterSquareBracketLeft((Token) node);
            break;
        case (int) DokiScriptConstants.SQUARE_BRACKET_RIGHT:
            EnterSquareBracketRight((Token) node);
            break;
        case (int) DokiScriptConstants.PARENTHESE_LEFT:
            EnterParentheseLeft((Token) node);
            break;
        case (int) DokiScriptConstants.PARENTHESE_RIGHT:
            EnterParentheseRight((Token) node);
            break;
        case (int) DokiScriptConstants.ANGLE_BRACKET_LEFT:
            EnterAngleBracketLeft((Token) node);
            break;
        case (int) DokiScriptConstants.DOUBLE_QUOTE:
            EnterDoubleQuote((Token) node);
            break;
        case (int) DokiScriptConstants.PERIOD:
            EnterPeriod((Token) node);
            break;
        case (int) DokiScriptConstants.COMMA:
            EnterComma((Token) node);
            break;
        case (int) DokiScriptConstants.SEMICOLON:
            EnterSemicolon((Token) node);
            break;
        case (int) DokiScriptConstants.EQUAL:
            EnterEqual((Token) node);
            break;
        case (int) DokiScriptConstants.CLICK:
            EnterClick((Token) node);
            break;
        case (int) DokiScriptConstants.CLICK_NEXT_DIALOGUE_PAGE:
            EnterClickNextDialoguePage((Token) node);
            break;
        case (int) DokiScriptConstants.OR:
            EnterOr((Token) node);
            break;
        case (int) DokiScriptConstants.TAB:
            EnterTab((Token) node);
            break;
        case (int) DokiScriptConstants.RETURN:
            EnterReturn((Token) node);
            break;
        case (int) DokiScriptConstants.SPACE:
            EnterSpace((Token) node);
            break;
        case (int) DokiScriptConstants.IDENTIFIER:
            EnterIdentifier((Token) node);
            break;
        case (int) DokiScriptConstants.DECIMAL:
            EnterDecimal((Token) node);
            break;
        case (int) DokiScriptConstants.TEXT:
            EnterText((Token) node);
            break;
        case (int) DokiScriptConstants.QUOTED_TEXT:
            EnterQuotedText((Token) node);
            break;
        case (int) DokiScriptConstants.DOKI:
            EnterDoki((Production) node);
            break;
        case (int) DokiScriptConstants.PART:
            EnterPart((Production) node);
            break;
        case (int) DokiScriptConstants.BLOCK:
            EnterBlock((Production) node);
            break;
        case (int) DokiScriptConstants.ACTION:
            EnterAction((Production) node);
            break;
        case (int) DokiScriptConstants.VOICE_ACTION:
            EnterVoiceAction((Production) node);
            break;
        case (int) DokiScriptConstants.OTHER_ACTION:
            EnterOtherAction((Production) node);
            break;
        case (int) DokiScriptConstants.TAG:
            EnterTag((Production) node);
            break;
        case (int) DokiScriptConstants.KEY:
            EnterKey((Production) node);
            break;
        case (int) DokiScriptConstants.VALUE:
            EnterValue((Production) node);
            break;
        case (int) DokiScriptConstants.FLAG:
            EnterFlag((Production) node);
            break;
        case (int) DokiScriptConstants.OPTION:
            EnterOption((Production) node);
            break;
        case (int) DokiScriptConstants.JUMP:
            EnterJump((Production) node);
            break;
        }
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public override Node Exit(Node node) {
        switch (node.Id) {
        case (int) DokiScriptConstants.WORLD:
            return ExitWorld((Token) node);
        case (int) DokiScriptConstants.BACKGROUND:
            return ExitBackground((Token) node);
        case (int) DokiScriptConstants.WEATHER:
            return ExitWeather((Token) node);
        case (int) DokiScriptConstants.SOUND:
            return ExitSound((Token) node);
        case (int) DokiScriptConstants.BGM:
            return ExitBgm((Token) node);
        case (int) DokiScriptConstants.VIDEO:
            return ExitVideo((Token) node);
        case (int) DokiScriptConstants.MOVE:
            return ExitMove((Token) node);
        case (int) DokiScriptConstants.POSTURE:
            return ExitPosture((Token) node);
        case (int) DokiScriptConstants.VOICE:
            return ExitVoice((Token) node);
        case (int) DokiScriptConstants.ROLE:
            return ExitRole((Token) node);
        case (int) DokiScriptConstants.OTHER:
            return ExitOther((Token) node);
        case (int) DokiScriptConstants.SRC:
            return ExitSrc((Token) node);
        case (int) DokiScriptConstants.TRANSITION:
            return ExitTransition((Token) node);
        case (int) DokiScriptConstants.TIME:
            return ExitTime((Token) node);
        case (int) DokiScriptConstants.TYPE:
            return ExitType((Token) node);
        case (int) DokiScriptConstants.LEVEL:
            return ExitLevel((Token) node);
        case (int) DokiScriptConstants.MODE:
            return ExitMode((Token) node);
        case (int) DokiScriptConstants.POSITION:
            return ExitPosition((Token) node);
        case (int) DokiScriptConstants.NAME:
            return ExitName((Token) node);
        case (int) DokiScriptConstants.ANCHOR:
            return ExitAnchor((Token) node);
        case (int) DokiScriptConstants.TAG_PARAMETER:
            return ExitTagParameter((Token) node);
        case (int) DokiScriptConstants.KEY1:
            return ExitKey1((Token) node);
        case (int) DokiScriptConstants.KEY2:
            return ExitKey2((Token) node);
        case (int) DokiScriptConstants.KEY3:
            return ExitKey3((Token) node);
        case (int) DokiScriptConstants.KEY4:
            return ExitKey4((Token) node);
        case (int) DokiScriptConstants.KEY5:
            return ExitKey5((Token) node);
        case (int) DokiScriptConstants.KEY6:
            return ExitKey6((Token) node);
        case (int) DokiScriptConstants.KEY7:
            return ExitKey7((Token) node);
        case (int) DokiScriptConstants.KEY8:
            return ExitKey8((Token) node);
        case (int) DokiScriptConstants.KEY9:
            return ExitKey9((Token) node);
        case (int) DokiScriptConstants.LIVE2D:
            return ExitLive2d((Token) node);
        case (int) DokiScriptConstants.ZOOM:
            return ExitZoom((Token) node);
        case (int) DokiScriptConstants.BRACKET_LEFT:
            return ExitBracketLeft((Token) node);
        case (int) DokiScriptConstants.BRACKET_RIGHT:
            return ExitBracketRight((Token) node);
        case (int) DokiScriptConstants.SQUARE_BRACKET_LEFT:
            return ExitSquareBracketLeft((Token) node);
        case (int) DokiScriptConstants.SQUARE_BRACKET_RIGHT:
            return ExitSquareBracketRight((Token) node);
        case (int) DokiScriptConstants.PARENTHESE_LEFT:
            return ExitParentheseLeft((Token) node);
        case (int) DokiScriptConstants.PARENTHESE_RIGHT:
            return ExitParentheseRight((Token) node);
        case (int) DokiScriptConstants.ANGLE_BRACKET_LEFT:
            return ExitAngleBracketLeft((Token) node);
        case (int) DokiScriptConstants.DOUBLE_QUOTE:
            return ExitDoubleQuote((Token) node);
        case (int) DokiScriptConstants.PERIOD:
            return ExitPeriod((Token) node);
        case (int) DokiScriptConstants.COMMA:
            return ExitComma((Token) node);
        case (int) DokiScriptConstants.SEMICOLON:
            return ExitSemicolon((Token) node);
        case (int) DokiScriptConstants.EQUAL:
            return ExitEqual((Token) node);
        case (int) DokiScriptConstants.CLICK:
            return ExitClick((Token) node);
        case (int) DokiScriptConstants.CLICK_NEXT_DIALOGUE_PAGE:
            return ExitClickNextDialoguePage((Token) node);
        case (int) DokiScriptConstants.OR:
            return ExitOr((Token) node);
        case (int) DokiScriptConstants.TAB:
            return ExitTab((Token) node);
        case (int) DokiScriptConstants.RETURN:
            return ExitReturn((Token) node);
        case (int) DokiScriptConstants.SPACE:
            return ExitSpace((Token) node);
        case (int) DokiScriptConstants.IDENTIFIER:
            return ExitIdentifier((Token) node);
        case (int) DokiScriptConstants.DECIMAL:
            return ExitDecimal((Token) node);
        case (int) DokiScriptConstants.TEXT:
            return ExitText((Token) node);
        case (int) DokiScriptConstants.QUOTED_TEXT:
            return ExitQuotedText((Token) node);
        case (int) DokiScriptConstants.DOKI:
            return ExitDoki((Production) node);
        case (int) DokiScriptConstants.PART:
            return ExitPart((Production) node);
        case (int) DokiScriptConstants.BLOCK:
            return ExitBlock((Production) node);
        case (int) DokiScriptConstants.ACTION:
            return ExitAction((Production) node);
        case (int) DokiScriptConstants.VOICE_ACTION:
            return ExitVoiceAction((Production) node);
        case (int) DokiScriptConstants.OTHER_ACTION:
            return ExitOtherAction((Production) node);
        case (int) DokiScriptConstants.TAG:
            return ExitTag((Production) node);
        case (int) DokiScriptConstants.KEY:
            return ExitKey((Production) node);
        case (int) DokiScriptConstants.VALUE:
            return ExitValue((Production) node);
        case (int) DokiScriptConstants.FLAG:
            return ExitFlag((Production) node);
        case (int) DokiScriptConstants.OPTION:
            return ExitOption((Production) node);
        case (int) DokiScriptConstants.JUMP:
            return ExitJump((Production) node);
        }
        return node;
    }

    /**
     * <summary>Called when adding a child to a parse tree
     * node.</summary>
     *
     * <param name='node'>the parent node</param>
     * <param name='child'>the child node, or null</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public override void Child(Production node, Node child) {
        switch (node.Id) {
        case (int) DokiScriptConstants.DOKI:
            ChildDoki(node, child);
            break;
        case (int) DokiScriptConstants.PART:
            ChildPart(node, child);
            break;
        case (int) DokiScriptConstants.BLOCK:
            ChildBlock(node, child);
            break;
        case (int) DokiScriptConstants.ACTION:
            ChildAction(node, child);
            break;
        case (int) DokiScriptConstants.VOICE_ACTION:
            ChildVoiceAction(node, child);
            break;
        case (int) DokiScriptConstants.OTHER_ACTION:
            ChildOtherAction(node, child);
            break;
        case (int) DokiScriptConstants.TAG:
            ChildTag(node, child);
            break;
        case (int) DokiScriptConstants.KEY:
            ChildKey(node, child);
            break;
        case (int) DokiScriptConstants.VALUE:
            ChildValue(node, child);
            break;
        case (int) DokiScriptConstants.FLAG:
            ChildFlag(node, child);
            break;
        case (int) DokiScriptConstants.OPTION:
            ChildOption(node, child);
            break;
        case (int) DokiScriptConstants.JUMP:
            ChildJump(node, child);
            break;
        }
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterWorld(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitWorld(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterBackground(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitBackground(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterWeather(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitWeather(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterSound(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitSound(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterBgm(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitBgm(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterVideo(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitVideo(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterMove(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitMove(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterPosture(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitPosture(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterVoice(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitVoice(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterRole(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitRole(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterOther(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitOther(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterSrc(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitSrc(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterTransition(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitTransition(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterTime(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitTime(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterType(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitType(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterLevel(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitLevel(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterMode(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitMode(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterPosition(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitPosition(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterName(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitName(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterAnchor(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitAnchor(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterTagParameter(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitTagParameter(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterKey1(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitKey1(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterKey2(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitKey2(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterKey3(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitKey3(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterKey4(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitKey4(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterKey5(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitKey5(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterKey6(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitKey6(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterKey7(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitKey7(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterKey8(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitKey8(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterKey9(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitKey9(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterLive2d(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitLive2d(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterZoom(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitZoom(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterBracketLeft(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitBracketLeft(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterBracketRight(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitBracketRight(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterSquareBracketLeft(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitSquareBracketLeft(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterSquareBracketRight(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitSquareBracketRight(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterParentheseLeft(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitParentheseLeft(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterParentheseRight(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitParentheseRight(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterAngleBracketLeft(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitAngleBracketLeft(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterDoubleQuote(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitDoubleQuote(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterPeriod(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitPeriod(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterComma(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitComma(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterSemicolon(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitSemicolon(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterEqual(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitEqual(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterClick(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitClick(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterClickNextDialoguePage(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitClickNextDialoguePage(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterOr(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitOr(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterTab(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitTab(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterReturn(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitReturn(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterSpace(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitSpace(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterIdentifier(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitIdentifier(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterDecimal(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitDecimal(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterText(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitText(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterQuotedText(Token node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitQuotedText(Token node) {
        return node;
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterDoki(Production node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitDoki(Production node) {
        return node;
    }

    /**
     * <summary>Called when adding a child to a parse tree
     * node.</summary>
     *
     * <param name='node'>the parent node</param>
     * <param name='child'>the child node, or null</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void ChildDoki(Production node, Node child) {
        node.AddChild(child);
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterPart(Production node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitPart(Production node) {
        return node;
    }

    /**
     * <summary>Called when adding a child to a parse tree
     * node.</summary>
     *
     * <param name='node'>the parent node</param>
     * <param name='child'>the child node, or null</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void ChildPart(Production node, Node child) {
        node.AddChild(child);
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterBlock(Production node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitBlock(Production node) {
        return node;
    }

    /**
     * <summary>Called when adding a child to a parse tree
     * node.</summary>
     *
     * <param name='node'>the parent node</param>
     * <param name='child'>the child node, or null</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void ChildBlock(Production node, Node child) {
        node.AddChild(child);
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterAction(Production node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitAction(Production node) {
        return node;
    }

    /**
     * <summary>Called when adding a child to a parse tree
     * node.</summary>
     *
     * <param name='node'>the parent node</param>
     * <param name='child'>the child node, or null</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void ChildAction(Production node, Node child) {
        node.AddChild(child);
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterVoiceAction(Production node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitVoiceAction(Production node) {
        return node;
    }

    /**
     * <summary>Called when adding a child to a parse tree
     * node.</summary>
     *
     * <param name='node'>the parent node</param>
     * <param name='child'>the child node, or null</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void ChildVoiceAction(Production node, Node child) {
        node.AddChild(child);
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterOtherAction(Production node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitOtherAction(Production node) {
        return node;
    }

    /**
     * <summary>Called when adding a child to a parse tree
     * node.</summary>
     *
     * <param name='node'>the parent node</param>
     * <param name='child'>the child node, or null</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void ChildOtherAction(Production node, Node child) {
        node.AddChild(child);
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterTag(Production node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitTag(Production node) {
        return node;
    }

    /**
     * <summary>Called when adding a child to a parse tree
     * node.</summary>
     *
     * <param name='node'>the parent node</param>
     * <param name='child'>the child node, or null</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void ChildTag(Production node, Node child) {
        node.AddChild(child);
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterKey(Production node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitKey(Production node) {
        return node;
    }

    /**
     * <summary>Called when adding a child to a parse tree
     * node.</summary>
     *
     * <param name='node'>the parent node</param>
     * <param name='child'>the child node, or null</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void ChildKey(Production node, Node child) {
        node.AddChild(child);
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterValue(Production node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitValue(Production node) {
        return node;
    }

    /**
     * <summary>Called when adding a child to a parse tree
     * node.</summary>
     *
     * <param name='node'>the parent node</param>
     * <param name='child'>the child node, or null</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void ChildValue(Production node, Node child) {
        node.AddChild(child);
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterFlag(Production node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitFlag(Production node) {
        return node;
    }

    /**
     * <summary>Called when adding a child to a parse tree
     * node.</summary>
     *
     * <param name='node'>the parent node</param>
     * <param name='child'>the child node, or null</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void ChildFlag(Production node, Node child) {
        node.AddChild(child);
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterOption(Production node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitOption(Production node) {
        return node;
    }

    /**
     * <summary>Called when adding a child to a parse tree
     * node.</summary>
     *
     * <param name='node'>the parent node</param>
     * <param name='child'>the child node, or null</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void ChildOption(Production node, Node child) {
        node.AddChild(child);
    }

    /**
     * <summary>Called when entering a parse tree node.</summary>
     *
     * <param name='node'>the node being entered</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void EnterJump(Production node) {
    }

    /**
     * <summary>Called when exiting a parse tree node.</summary>
     *
     * <param name='node'>the node being exited</param>
     *
     * <returns>the node to add to the parse tree, or
     *          null if no parse tree should be created</returns>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual Node ExitJump(Production node) {
        return node;
    }

    /**
     * <summary>Called when adding a child to a parse tree
     * node.</summary>
     *
     * <param name='node'>the parent node</param>
     * <param name='child'>the child node, or null</param>
     *
     * <exception cref='ParseException'>if the node analysis
     * discovered errors</exception>
     */
    public virtual void ChildJump(Production node, Node child) {
        node.AddChild(child);
    }
}
