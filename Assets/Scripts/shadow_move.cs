using UnityEngine;
using System.Collections;

public class shadow_move : MonoBehaviour {

	public GameObject boss;
	public float control_shadow = 0;
	public float control_shadow2 = 0;
	// Use this for initialization
	void Start () {
	
		boss = GameObject.FindGameObjectWithTag ("boss");

	}
	
	// Update is called once per frame
	void Update () {

		if (this.transform.position.y >= -0.55f) {

			this.transform.position = new Vector2(this.transform.position.x, -0.55f);
				}

		if (this.transform.position.y <= -1.25f) {
			
			this.transform.position = new Vector2(this.transform.position.x, -1.25f);
		}

		if (this.transform.position.x >= 58.00f) {
			
			this.transform.position = new Vector2(58.00f, this.transform.position.y);
		}
		
		if (this.transform.position.x <= 55.00f) {
			
			this.transform.position = new Vector2(55.00f, this.transform.position.y);
		}


		if (control_shadow <= 60) {
		
			this.transform.Translate(5f * Time.deltaTime, 0,0);
			control_shadow++;

				}

		if (control_shadow > 60 && control_shadow <= 120) {

			this.transform.Translate (-5f * Time.deltaTime, 0, 0);
			control_shadow++;

				}

		if (control_shadow > 120) {

			control_shadow = 0;

				}

		if (control_shadow2 <= 20) {
			
			this.transform.Translate(0, 2f * Time.deltaTime,0);
			control_shadow2++;
			
		}
		
		if (control_shadow2 > 20 && control_shadow2 <= 40) {
			
			this.transform.Translate (0, -2f * Time.deltaTime, 0);
			control_shadow2++;
			
		}
		
		if (control_shadow2 > 40) {
			
			control_shadow2 = 0;
			
		}


	
		if (boss.GetComponent<Roboter_move> ().anim.GetBool ("caindo2") == true) {

			Destroy(gameObject, 0.5f);

				}



	}
}
