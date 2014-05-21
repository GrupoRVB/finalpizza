using UnityEngine;
using System.Collections;

public class Sair : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Start") || Input.GetKey(KeyCode.K)){
			Application.LoadLevel ("Menu");
		}
	
	}
}
