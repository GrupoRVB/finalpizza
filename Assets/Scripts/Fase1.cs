using UnityEngine;
using System.Collections;

public class Fase1 : MonoBehaviour {
	private float passar;
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		anim.SetBool("Acabou", false);

	
	}
	
	// Update is called once per frame
	void Update () {
		passar += 1f* Time.deltaTime;

			if (passar > 8.5) {
									
								Application.LoadLevel ("cena12");
						}

				}
}
