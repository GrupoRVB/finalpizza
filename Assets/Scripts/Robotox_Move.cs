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
		public int aim;
		public bool isAttacking;
		public BoxCollider2D hitbox;
		public bool jumping = false;
		public float control_attack;
		public int aim_attack;
		public float control_rotation = 0;
		public GameObject enemy_creator;
		public CircleCollider2D hit_circle;
		public GameObject analisator;
		public bool idle = false;
		public int random_direction;
		


		
		
		
		// Use this for initialization
		void Start () {
		player = GameObject.Find ("Jogador");

			anim = GetComponent<Animator> ();
			enemy_creator = GameObject.Find ("Enemy_spawner");
			hit_circle = GetComponent<CircleCollider2D>();
			analisator = GameObject.Find ("analisator");
			
			//enemy_fire = GameObject.Find ("enemy_fire");
			
		}
		
		// Update is called once per frame
		void Update () {	

				if (anim.GetBool ("vivo") == false) {
						this.transform.Translate (0, 0, 0);
						this.hit_circle.enabled = false;


				} else {

						distancia = player.transform.position.x - this.transform.position.x;
						if (distancia > -20 && distancia < 20) {
											
								if (Time.time > next_walk) {

												if (distancia >= 0.5f && this.isAttacking == false) {
														this.transform.localScale = new Vector2 (-1, 1);
														this.aim = 1;
												} else if (distancia < -0.5f) {
														this.transform.localScale = new Vector2 (1, 1);
														this.aim = -1;
												}

												this.isAttacking = false;

												if (distancia >= 0.5f) {
														this.transform.Translate (/*0.008f*/(0.6f +  analisator.GetComponent<Analise>().move_speed)* Time.deltaTime, 0, 0);
														anim.SetBool ("andando", true);
														anim.SetBool ("atacando", false);
												} else if (distancia < -0.5f) {

		if (anim.GetBool ("vivo") == false) {
			this.transform.Translate (0, 0, 0);
		} else {
			
			distancia = player.transform.position.x - this.transform.position.x;
			if (distancia > -20 && distancia < 20) {
				
				if (Time.time > next_walk) {
					
					if (distancia >= -0.19f && this.isAttacking == false) {
						this.transform.localScale = new Vector2 (-1, 1);
						this.aim = 1;
					} else if (distancia <= 0.19f) {
						this.transform.localScale = new Vector2 (1, 1);
						this.aim = -1;
					}
					
					this.isAttacking = false;
					
					if (distancia > 0.2f) {
						this.transform.Translate ((0.6f + analisator.GetComponent<Analise>().move_speed) * Time.deltaTime, 0, 0);
						anim.SetBool ("andando", true);
						anim.SetBool ("atacando", false);
					} else if (distancia < -0.2f) {
						this.transform.Translate ((-0.6f - analisator.GetComponent<Analise>().move_speed) * Time.deltaTime, 0, 0);
						anim.SetBool ("andando", true);
						anim.SetBool ("atacando", false);
						
					//}else if (distancia > -0.4f && distancia < -0.8f){

						//this.transform.Translate (-0.6f * Time.deltaTime, 0, 0);
						//anim.SetBool ("andando", true);
						//anim.SetBool ("atacando", false);
					//}else if (distancia <0.4f && distancia > 0.8f){
						
						//this.transform.Translate (0.6f * Time.deltaTime, 0, 0);
						//anim.SetBool ("andando", true);
						//anim.SetBool ("atacando", false);
					}
					
					if (this.transform.position.x <= enemy_creator.GetComponent<Enemy_Create>().max_x && this.transform.position.x >= enemy_creator.GetComponent<Enemy_Create>().min_x){
					if (player.transform.position.y >= this.transform.position.y) {
						this.transform.Translate (0, 0.2f * Time.deltaTime, 0);
						anim.SetBool ("andando", true);
						anim.SetBool ("atacando", false);
						
						
					} else {
						
						
						this.transform.Translate (0, -0.2f * Time.deltaTime, 0);
						anim.SetBool ("andando", true);
						anim.SetBool ("atacando", false);
					}
				}
				}

												if (distancia >= -0.8f && distancia <= 0.8f && Time.time > proximotiro) {	
														this.isAttacking = true;
														next_walk = Time.time + 2;
														proximotiro = Time.time + 6;
														anim.SetBool ("andando", false);
														anim.SetBool ("atacando", true);
														control_attack = Time.time + 0.15f;
														this.aim_attack = this.aim;
														analisator.GetComponent<Analise> ().melee_attacks++;
														


												}

												if (this.isAttacking == true && Time.time <= control_attack) {

														if (player.transform.position.y >= this.transform.position.y) {
	
																this.transform.Translate ((5.5f * this.aim_attack) * Time.deltaTime, 0.5f * Time.deltaTime, 0);
														} else {

																this.transform.Translate ((5.5f * this.aim_attack) * Time.deltaTime, -0.5f * Time.deltaTime, 0);

														}

										
												}



										
								}

								if ((this.transform.position.x > enemy_creator.GetComponent<Enemy_Create> ().max_x || this.transform.position.x < enemy_creator.GetComponent<Enemy_Create> ().min_x) && enemy_creator.GetComponent<Enemy_Create> ().lock_screen == true) {

										this.hit_circle.enabled = false;

								} else {

										this.hit_circle.enabled = true;

								}

			
						}
					}
				}
			}
		}
	}
				
		
		
		void OnTriggerEnter2D(Collider2D other) {
		
					if (other.gameObject.tag == "jogado" && this.isAttacking == true && other.GetComponent<Barra>().invenc == false) {
							
						other.GetComponent<Barra>().quantvida-=5;
						other.GetComponent<Barra>().rend.color = new Color(1f, 0f, 0f, 1f);
						other.GetComponent<Barra>().invenc = true;
						other.GetComponent<Barra>().proxima = Time.time + 0.8f;	
						analisator.GetComponent<Analise>().melee_attacks_hit++;

					}

		if (other.gameObject.tag == "barreira" && this.isAttacking == true) {

			if(other.transform.position.x > this.transform.position.x){
			this.isAttacking = false;
			this.transform.position = new Vector2 (this.transform.position.x - 0.3f, this.transform.position.y);
			}else{

				this.isAttacking = false;
				this.transform.position = new Vector2 (this.transform.position.x + 0.3f, this.transform.position.y);

			}
				}

			}


	}

