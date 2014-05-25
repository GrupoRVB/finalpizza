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
		passar += 0.01f/** Time.deltaTime*/;

		if (anim.GetBool ("Acabou") == false && passar > 2.5f/** Time.deltaTime*/) {
			anim.SetBool("Acabou", true);
			passar = 0;

				}
				if (anim.GetBool ("Acabou") == true) {

			if (passar > 2.1f/** Time.deltaTime*/) {
									
								Application.LoadLevel ("cena12");
						}
				}
		Debug.LogError (passar);
		}
}
