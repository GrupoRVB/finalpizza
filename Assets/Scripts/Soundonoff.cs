using UnityEngine;
using System.Collections;

public class Soundonoff : MonoBehaviour {
	public Animator anim;
	private bool onoff;
	private GameObject global;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator>();
		global = GameObject.Find ("Global");
	}
	
	// Update is called once per frame
	void Update () {
		onoff = global.GetComponent<Global> ().sound;
		if (onoff == true) {
			anim.SetBool("on", true);		
		}else{
			anim.SetBool("on", false);
		}

	
	}
}
