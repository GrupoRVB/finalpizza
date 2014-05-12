using UnityEngine;
using System.Collections;

public class Parallax_fundo : MonoBehaviour {
	private GameObject player;
	public float speed;
	private bool chefe;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Main Camera");
		chefe = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.x < 56.60 && chefe == false) {
			this.transform.position = new Vector2 (player.transform.position.x, 0) * speed;
		} else {
			chefe = true;
			this.transform.position = new Vector2 (45.28f, 0);
		}
	}
}