using UnityEngine;
using System.Collections;

public class Som_Jogo : MonoBehaviour {
	public AudioClip fase;
	public AudioClip vitoria;
	public GameObject player;
	private bool morto;
	public GameObject chefe;
	// Use this for initialization
	void Start () {
		audio.clip = fase;

	}
	
	// Update is called once per frame
	void Update () {
		morto = chefe.GetComponent<Roboter_move> ().dead;
		Debug.Log (chefe.GetComponent<Roboter_move> ().dead);
		if (player.GetComponent<Movimento> ().chefe == true && morto == false ) {
			audio.volume -=0.021f* Time.deltaTime;
		}
		if (morto == true) {
			audio.clip = vitoria;
			audio.volume -=0.321f* Time.deltaTime;
			audio.Play();

		}

	}
}
