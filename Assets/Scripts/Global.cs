using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {
	public bool sound = true;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Som ();
	}
	void Som(){
		if(Input.GetButtonDown ("Select")){
			if(sound == true){
				AudioListener.volume = 0.0f;
				sound = false;
			}else{
				AudioListener.volume = 1.0f;
				sound = true;
			}
		}
	}
}