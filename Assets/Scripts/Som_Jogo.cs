using UnityEngine;
using System.Collections;

public class Som_Jogo : MonoBehaviour {
	public AudioClip fase;
	public GameObject player;
	// Use this for initialization
	void Start () {
		audio.clip = fase;

	}
	
	// Update is called once per frame
	void Update () {

		if (player.GetComponent<Movimento> ().chefe == true) {
			audio.volume -=0.021f* Time.deltaTime;

		}
		Debug.LogError(audio.volume);
	}
}
