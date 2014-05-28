using UnityEngine;
using System.Collections;

public class Robot_Move : MonoBehaviour {
		
	public int contador;
	public GameObject player;
	public float distancia;
	public GameObject enemy_fire;
	public int forca = 1000;
	public float proximotiro = 0.0f;
	public float dir;
	public Animator anim;
	public bool shoting;
	public float next_walk;
	public float aim;
	public float distancia_min;
	public float control = 0.0f;
	public AudioClip tiro;
	public GameObject enemy_spawn;
	public bool is_shoting;
	public CircleCollider2D hit_circle;
	public GameObject enemy_creator;


	// Use this for initialization
	void Start () {

		player = GameObject.Find ("Jogador");
		anim = GetComponent<Animator> ();
		enemy_spawn = GameObject.Find ("Enemy_spawner");
		enemy_creator = GameObject.Find ("Enemy_spawner");
		hit_circle = GetComponent<CircleCollider2D>();

		//enemy_fire = GameObject.Find ("enemy_fire");
	
	}
	
	// Update is called once per frame
	void Update () {



				if (anim.GetBool ("vivo") == false) {
			this.transform.Translate(0,0 , 0 );
				} else {

			shoting = anim.GetBool ("atirando");
						distancia = player.transform.position.x - this.transform.position.x;
						if (distancia > -8 && distancia < 8) {
					
								if (distancia >= 0) {
										this.transform.localScale = new Vector2 (-1, 1);
										this.aim = 1;
								} else {
										this.transform.localScale = new Vector2 (1, 1);
										this.aim = -1;
								}
								if (Time.time > next_walk) {
								

						if (distancia >= 0 ) {
							this.transform.Translate (0.005f/** Time.deltaTime*/, 0, 0);
							anim.SetBool ("andando", true);
							anim.SetBool ("atirando", false);
						} else if(distancia <= 0) {
							this.transform.Translate (-0.005f/** Time.deltaTime*/, 0, 0);
							anim.SetBool ("andando", true);
							anim.SetBool ("atirando", false);	
							
						}




											
				
										if (player.transform.position.y >= this.transform.position.y) {
						this.transform.Translate (0, 0.003f/** Time.deltaTime*/, 0);
												anim.SetBool ("andando", true);
												anim.SetBool ("atirando", false);
									
										} else {
				

						this.transform.Translate (0, -0.003f/** Time.deltaTime*/, 0);
												anim.SetBool ("andando", true);
												anim.SetBool ("atirando", false);
										}
								}

				if (Time.time > proximotiro && this.transform.position.x >= enemy_spawn.GetComponent<Enemy_Create>().min_x && this.transform.position.x <= enemy_spawn.GetComponent<Enemy_Create>().max_x && (this.transform.position.y <= (player.transform.position.y + 0.2f) && this.transform.position.y >= (player.transform.position.y - 0.2f)) ) {
										anim.SetBool ("atirando", true);
										next_walk = Time.time + 0.5f;
										control = Time.time + 0.5f;
										proximotiro = Time.time + Random.Range (1, 6);
										is_shoting = true;
								}

								if (Time.time > control && this.is_shoting == true) {
					audio.PlayOneShot(tiro);
										control = Time.time + 3;
					Instantiate (enemy_fire, new Vector3 (this.transform.position.x + (0.25f/** Time.deltaTime*/ * this.aim), this.transform.position.y - 0.05f/** Time.deltaTime*/, 0), Quaternion.identity);
					this.is_shoting = false;									
								}

						}
			if((this.transform.position.x > enemy_creator.GetComponent<Enemy_Create>().max_x || this.transform.position.x < enemy_creator.GetComponent<Enemy_Create>().min_x) && enemy_creator.GetComponent<Enemy_Create>().lock_screen == true){
				
				this.hit_circle.enabled = false;
				
			}else{
				
				this.hit_circle.enabled = true;
				
			}

				}
		}




}
