using UnityEngine;
using System.Collections;

public class Chefe_sound : MonoBehaviour {
	public AudioClip alert;
	public AudioClip loop;
	private bool mudar = true;
	// Use this for initialization
	void Start () {
		audio.clip = alert;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.LogError (audio.time);
		Debug.Log (0.05*Time.deltaTime);
		if (audio.time > 3.4f && mudar == true) {
			audio.clip = loop;
			audio.Play ();
			mudar = false;
		}
						//if (audio.isPlaying) {
						//
						//
				}
	
}
