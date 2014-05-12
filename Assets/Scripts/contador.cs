using UnityEngine;
using System.Collections;

public class contador : MonoBehaviour {
	public GameObject player;
	private int balas;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Jogador");

	}
	
	// Update is called once per frame
	void Update () {
	}
}
