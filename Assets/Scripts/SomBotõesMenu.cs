using UnityEngine;
using System.Collections;

public class SomBotõesMenu : MonoBehaviour {
	private float lado;
	private float limitador =0.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
		void Update () {
				if (GetComponent<Menu> ().primeiro == false) {
						if (GetComponent<Menu> ().principal == true) {
								lado = Input.GetAxis ("Horizontal");
								if (lado > 0 && Time.time > limitador) {
										limitador = Time.time + 0.3f;
										audio.Play ();
				
				
								}
								if (lado < 0 && Time.time > limitador) {
										limitador = Time.time + 0.3f;
										audio.Play ();
								}
	
						} else {
						}
				}
		}
}

