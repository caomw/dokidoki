using System.Collections.Generic;

/// <summary>
/// WorldControl's data to be serialized
/// </summary>
[System.Serializable]
public class WorldControlData
{
    /// <summary>
    /// The current focused GameObject id
    /// </summary>
    public string focusGameObjectId;
    /// <summary>
    /// Current text content should be displayed on dialog window
    /// </summary>
    public string textContent;
    /// <summary>
    /// Real time when this saved data was created
    /// </summary>
    public string saveTime;
    /// <summary>
    /// Current flag option would be combined into a worldLine string
    /// </summary>
    public string worldLine;
    /// <summary>
    /// Record current script name
    /// </summary>
    public string currentScriptName;
    /// <summary>
    /// Record current script action index
    /// </summary>
    public int currentActionIndex;
    /// <summary>
    /// Record current game state
    /// </summary>
    public string currentGameState = GameConstants.NORMAL;
    /// <summary>
    /// Record next auto click time, for auto mode to expect next click
    /// </summary>
    public float nextAutoClickTime = 0f;
    /// <summary>
    /// Record current dialog mode (normal or bubble)
    /// </summary>
    public string dialogMode = GameConstants.NORMAL;
    /// <summary>
    /// Record current history dialogs, for displaying back logs after load saved data
    /// </summary>
    public List<Dialog> historyDialogs;
}
