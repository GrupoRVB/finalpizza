using UnityEngine;
using System.Collections;

public class Chefe_sound : MonoBehaviour {
	public AudioClip alert;
	public AudioClip loop;
	private bool mudar = true;
	private bool morto;
	// Use this for initialization
	void Start () {
		audio.clip = alert;
		morto = GetComponent<Roboter_move> ().dead;
	}
	
	// Update is called once per frame
	void Update () {
		morto = GetComponent<Roboter_move> ().dead;
		if (audio.time > 3.0f && mudar == true) {
			audio.clip = loop;
			audio.Play ();
			mudar = false;
			audio.loop = true;
		}
		Debug.LogError(morto == true);


						//if (audio.isPlaying) {
						//
						//
				}

}
