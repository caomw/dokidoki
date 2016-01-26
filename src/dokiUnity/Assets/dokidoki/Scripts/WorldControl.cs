using UnityEngine;
using System.Collections;

public class WorldControl : MonoBehaviour {

    public GameObject world;

	void Start () {
        if (world==null) {
            Application.Quit();
        }
	}
	
	void Update () {
	    
	}
}
