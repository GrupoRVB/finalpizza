using UnityEngine;
using System.Collections;

public class Barra_movel : MonoBehaviour {
	private bool chefe = false;
	public float horizontal;
	public float vertical;
	private GameObject camera;
	// Use this for initialization
	void Start () {
		camera = GameObject.Find ("Main Camera");
	
	}
	
	// Update is called once per frame
	void Update () {
		if (camera.transform.position.x < 55.10 && chefe == false) {
			this.transform.position = new Vector3 ((camera.transform.position.x-horizontal),vertical, 0);
		} else {
			chefe = true;
			this.transform.position = new Vector3 (55.34f, vertical,0);
	}
}
}