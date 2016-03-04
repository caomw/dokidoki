using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogManage : MonoBehaviour {

	public List<Dialog> historyDialogs = new List<Dialog>();

    IEnumerator currentAnimateText = null;

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
		historyDialogs.Add (newDialog);
		if(historyDialogs.Count > GameParameter.HISTORY_DIALOG_MAX){
			historyDialogs.RemoveAt(0);
		}
		//Debug.Log ("writeOnDialogBoard: "+content);
	}

    IEnumerator animateText(string shownName, string content)
    {
        int i = 0;
        this.GetComponent<Text>().text = shownName + "\n\n";
        while (i < content.Length)
        {
            this.GetComponent<Text>().text += content[i++];
            yield return new WaitForSeconds(GameParameter.LETTER_DELAY);
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
