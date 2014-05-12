using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {
	public float translacao;
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Jogador");
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.x > player.transform.position.x -3.82162) {
						this.transform.Translate (-translacao, 0, 0);
				} else {
						this.transform.Translate (player.transform.position.x + 8.738405f, 0, 0);
	
				}
	}
}
