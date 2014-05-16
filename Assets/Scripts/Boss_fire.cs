using UnityEngine;
using System.Collections;

public class Boss_fire : MonoBehaviour {
	
	public int dir;
	public float cont_wait;
	public int real_dir;
	public GameObject player;
	public GameObject chefe;
	
	// Use this for initialization
	void Start () {
		
		cont_wait = 0;
		
		player = GameObject.Find ("Jogador");
		chefe = GameObject.Find ("Boss");

		this.dir = chefe.GetComponent<Roboter_move> ().aim;
	
		
		
		
		if (dir <= 0) {
			
			this.transform.localScale = new Vector2 (1, 1);
		} else {
			this.transform.localScale = new Vector2 (-1, 1);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		cont_wait++;
		
		//if (cont_wait >= 20) {
		
		Destroy (gameObject, 1.5f);
		if (dir <= 0) {
			this.transform.Translate (-0.1f, 0, 0);
			
			
		} else {
			this.transform.Translate (0.1f, 0, 0);
		}
		//}
	}
	
	void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.tag == "jogado") {
			
			other.GetComponent<Barra>().quantvida-=8;
			other.GetComponent<Barra>().rend.color = new Color(1f, 0f, 0f, 1f);
			other.GetComponent<Barra>().invenc = true;
			other.GetComponent<Barra>().proxima = Time.time + 0.8f;
		
			Destroy (gameObject, 0.002f);

		}

		}
}
