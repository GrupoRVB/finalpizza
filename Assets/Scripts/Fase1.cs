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
		passar += 0.1f * Time.deltaTime;

				if (passar > 0.5f) {
			anim.SetBool("Acabou", true);
			passar = 0;

				}
				if (anim.GetBool ("Acabou") == true) {

						if (passar > 0.335f) {
									
								Application.LoadLevel ("cena12");
						}
				}
		Debug.LogError (anim.GetBool ("Acabou"));
		}
}
