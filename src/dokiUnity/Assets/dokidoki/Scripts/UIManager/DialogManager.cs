using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using ScriptKeyword = dokiScriptSetting.ScriptKeyword;

/// <summary>
/// DialogManager manages dialogContent under dialogBoard.
/// DialogManager could receive characters' or World's calls from voice action or text action, to display their text content on dialogBoard.
/// </summary>
public class DialogManager : MonoBehaviour {
    /// <summary>
    /// History dialogs recorded, for later being shown on BackLogBoard
    /// </summary>
	public List<Dialog> historyDialogs = new List<Dialog>();
    /// <summary>
    /// Coroutine recorded to be able to be stopped when needs new animated text to be shown
    /// </summary>
    IEnumerator currentAnimateText = null;


    /// <summary>
    /// Called from voice action or text action, to display text content on dialogBoard, and record a new history dialog into historyDialogs
    /// </summary>
    /// <param name="shownName">Character's name</param>
    /// <param name="content">Dialog text content</param>
    /// <param name="voiceSrc">Character's voice source name</param>
	public void writeOnDialogBoard(string shownName, string content, string voiceSrc){
        //Display dialog
        if (currentAnimateText != null)
        {
            //Clear last animateText
            StopCoroutine(currentAnimateText);
        }
        currentAnimateText = animateText(shownName, content);
        StartCoroutine(currentAnimateText);

		//save new dialog for Back Log, and up to 100
		Dialog newDialog = new Dialog (shownName, content, voiceSrc);
		//Debug.Log ("newDialog.voiceSrc: "+newDialog.voiceSrc);
		historyDialogs.Add (newDialog);
        if (historyDialogs.Count > GameConstants.HISTORY_DIALOG_MAX)
        {
			historyDialogs.RemoveAt(0);
		}
		//Debug.Log ("writeOnDialogBoard: "+content);
	}
    /// <summary>
    /// Called when needs to display new animateText on the dialogBoard
    /// </summary>
    /// <param name="shownName">Character's name</param>
    /// <param name="content">Dialog text content</param>
    /// <returns>Coroutine pointer of this running animateText function, used to stop this old functions when new animateText functions is needed</returns>
    IEnumerator animateText(string shownName, string content)
    {
        int i = 0;
        this.GetComponent<Text>().text = shownName + "\n\n";
        while (i < content.Length)
        {
            this.GetComponent<Text>().text += content[i++];
            yield return new WaitForSeconds( PlayerPrefs.GetFloat(GameConstants.CONFIG_TEXT_SPEED) * GameConstants.TEXT_DELAY_FACTOR);
        }
    }
    /// <summary>
    /// Clear old historyDialogs when loads game from saved data
    /// </summary>
    public void clear() {
        historyDialogs = new List<Dialog>();
    }
}
