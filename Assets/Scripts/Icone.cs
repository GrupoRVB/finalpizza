using UnityEngine;
using System.Collections;

public class Icone : MonoBehaviour {
	public GameObject icone1;
	// Use this for initialization
	void Start () {
		Instantiate (icone1, new Vector2(this.transform.position.x-2.8f,this.transform.position.y-0.4f), Quaternion.identity);
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}
}
