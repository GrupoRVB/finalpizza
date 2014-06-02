using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {
	public float translacao;
	public GameObject player;
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.x > player.transform.position.x -4.32162) {
						this.transform.Translate (-translacao*Time.deltaTime, 0, 0);
				} else {
						this.transform.Translate (player.transform.position.x + 8.738405f, 0, 0);
	
				}
	}
}
