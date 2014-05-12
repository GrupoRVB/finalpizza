	using UnityEngine;
using System.Collections;

public class icone3 : MonoBehaviour {
	public GameObject icone1;
	public GameObject player;

	// Use this for initialization
	void Start () {
		Instantiate (icone1, new Vector2(this.transform.position.x-2.8f,this.transform.position.y-0.3f), Quaternion.identity);
		player = GameObject.Find ("Jogador");
	}
	
	// Update is called once per frame
	void Update () {
		icone1.transform.position =  new Vector3(player.transform.position.x ,this.transform.position.y,0);
		
		
	}
}
