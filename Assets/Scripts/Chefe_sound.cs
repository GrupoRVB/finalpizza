using UnityEngine;
using System.Collections;

public class Chefe_sound : MonoBehaviour {
	public AudioClip alert;
	public AudioClip loop;
	private bool mudar = true;
	private bool morto;
	private bool victory = false;
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
						if (morto == true) {
						if (audio.volume == 0){
								
				victory = true; 

				}
						if (victory == false) {
								audio.volume -= 0.151f * Time.deltaTime;
						}
				}
				
		}
		
				



						//if (audio.isPlaying) {
						//
						//

}
