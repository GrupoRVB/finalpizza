using UnityEngine;
using System.Collections;

public class fundo : MonoBehaviour {
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector2(player.transform.position.x, 0f);
	}
}
