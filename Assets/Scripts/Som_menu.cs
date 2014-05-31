using UnityEngine;
using System.Collections;

public class Som_menu : MonoBehaviour {
	public AudioClip mudança;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Mudou(){
		audio.PlayOneShot (mudança);
	}
}
