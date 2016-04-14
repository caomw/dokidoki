using System.Collections.Generic;

[System.Serializable]
public class WorldControlData
{
    public string focusGameObjectId;
    public string textContent;
    public string saveTime;
    public string worldLine;
    public string currentScriptName;
    public int currentActionIndex;

    public string currentGameState = GameConstants.NORMAL;
    public float nextAutoClickTime = 0f;
    public string dialogMode = GameConstants.NORMAL;

    public List<Dialog> historyDialogs;
}
