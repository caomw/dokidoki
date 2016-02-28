using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogManage : MonoBehaviour {

	const int HISTORY_DIALOG_MAX = 100;
	public List<Dialog> historyDialogs = new List<Dialog>();

	public void writeOnDialogBoard(string shownName, string content, string voiceSrc){
		this.GetComponent<Text> ().text = shownName + "\n\n" + content;
		//save new dialog for Back Log, and up to 100
		Dialog newDialog = new Dialog (shownName, content, voiceSrc);
		historyDialogs.Add (newDialog);
		if(historyDialogs.Count>HISTORY_DIALOG_MAX){
			historyDialogs.RemoveAt(0);
		}
		Debug.Log ("writeOnDialogBoard: "+content);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
