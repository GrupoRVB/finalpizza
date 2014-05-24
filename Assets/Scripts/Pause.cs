using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
	//public Script script3;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("escape")) {
			//pause the game
			Time.timeScale = 0;
			//show the pause menu
			//script3 = GetComponent("PauseMenuScript"); 
			//script3.enabled = true;
			//disable the cursor hiding script
		}
	}
	}
