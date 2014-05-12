using UnityEngine;
using System.Collections;

public class Robotox_Move : MonoBehaviour {
	
	public int contador;
	public GameObject player;
	public float distancia;
	public int forca = 1000;
	public float proximotiro = 0.0f;
	public float dir;
	public Animator anim;
	public float next_walk;
	public float aim;
	public bool isAttacking;


	
	
	
	// Use this for initialization
	void Start () {
		
		player = GameObject.Find ("Jogador");
		anim = GetComponent<Animator> ();
		
		//enemy_fire = GameObject.Find ("enemy_fire");
		
	}
	
	// Update is called once per frame
	void Update () {	


		distancia = player.transform.position.x - this.transform.position.x;
		if (distancia > -8 && distancia < 8) {
			
			if (distancia >= 0) {
				this.transform.localScale = new Vector2 (-1, 1);
				this.aim = 1;
			} else {
				this.transform.localScale = new Vector2 (1, 1);
				this.aim = -1;
			}
							
				if(Time.time > next_walk){
					if(distancia >=0)
					{
						this.transform.Translate (0.013f, 0, 0);
						anim.SetBool ("andando", true);
					anim.SetBool ("atacando", false);
					}else{
						this.transform.Translate (-0.013f, 0, 0);
						anim.SetBool ("andando", true);
					anim.SetBool ("atacando", false);
						
					}
									
				
				if (player.transform.position.y >= this.transform.position.y) {
					this.transform.Translate (0, 0.003f, 0);
					anim.SetBool ("andando", true);
					anim.SetBool ("atacando", false);
					
					
				} else {
					
					
					this.transform.Translate (0, -0.003f, 0);
					anim.SetBool ("andando", true);
					anim.SetBool ("atacando", false);
				}
			}

				if (distancia >= -0.2f && distancia <= 0.2f && Time.time > proximotiro)
			{
				next_walk = Time.time + 2.5f;
				proximotiro = Time.time + 4;
				anim.SetBool ("andando", false);
				anim.SetBool ("atacando", true);

			}
		}
		
		
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		isAttacking = anim.GetBool ("atacando");
				if (other.gameObject.tag == "jogado" && isAttacking == true ) {
						other.transform.Translate (0.08f, 0, 0);
				}
		}
}

