using UnityEngine;
using System.Collections;

public class dokiSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private Queue actions = null;
	
	void ConductOneAction(){
		dokiAction currentAction = (dokiAction)actions.Dequeue();
	}

	void PrepareActions(Queue newActions){
		while(newActions.Count > 0){
			actions.Enqueue (newActions.Dequeue());
		}
	}

	void PrepareScripts(){
		
	}

	Queue CompileScript(){
		Queue newActions = new Queue ();

		return newActions;
	}
}
