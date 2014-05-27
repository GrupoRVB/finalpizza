using UnityEngine;
using System.Collections;

public class Chefe_sound : MonoBehaviour {
	public AudioClip alert;
	public AudioClip loop;
	private float mudar=0;
	// Use this for initialization
	void Start () {
		audio.clip = alert;
	}
	
	// Update is called once per frame
	void Update () {
		mudar += 0.4f * Time.deltaTime;
		Debug.LogError (mudar);
		if (mudar > 1) {
						if (audio.isPlaying) {
								audio.clip = loop;
								audio.Play ();
						}
				}

		}
}
