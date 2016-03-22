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

    public List<Dialog> historyDialogs;
}
