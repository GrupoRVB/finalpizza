	using UnityEngine;
using System.Collections;

public class azeitona : MonoBehaviour {
	private GameObject player;
	private SpriteRenderer layer;
	// Use this for initialization
	void Start () {
		layer = GetComponent<SpriteRenderer>();
		player = GameObject.Find ("Jogador");
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.y > this.transform.position.y+0.1f) {
			this.layer.sortingLayerName = "Pe";
		}
		if (player.transform.position.y < this.transform.position.y) {
			this.layer.sortingLayerName = "Frente";
		}
		}
	void OnCollisionEnter2D(Collision2D colisor)
	{


	if (colisor.gameObject.tag == "jogado") 
		{
			Destroy(gameObject);
				}
	}

}
