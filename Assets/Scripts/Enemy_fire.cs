﻿using UnityEngine;
using System.Collections;

public class Enemy_fire : MonoBehaviour {

	public int dir;
	public float cont_wait;
	public int real_dir;
	public GameObject player;

	// Use this for initialization
	void Start () {
	
		cont_wait = 0;

		player = GameObject.Find ("Jogador");
		if (this.transform.position.x <= player.transform.position.x) {
			this.dir = 1;
			}else{
			this.dir = -1;	
			}



		if (dir <= 0) {

						this.transform.localScale = new Vector2 (1, 1);
				} else {
						this.transform.localScale = new Vector2 (-1, 1);
				}
	}
	
	// Update is called once per frame
	void Update () {

				cont_wait++;

				//if (cont_wait >= 20) {

						Destroy (gameObject, 1.5f);
						if (dir <= 0) {
								this.transform.Translate (-0.1f, 0, 0);


						} else {
								this.transform.Translate (0.1f, 0, 0);
						}
				//}
		}

	void OnCollisionEnter2D(Collider2D other) {

			if(other.gameObject.tag == "jogado"){
			//Destroy(this.gameObject, 0.001f);
			//other.transform.Translate(5.5f,0,0);
			}
			Destroy (gameObject, 0.002f);
	}
}

