﻿	using UnityEngine;
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
		


		
		
		
		// Use this for initialization
		void Start () {
			
			player = GameObject.Find ("Jogador");
			anim = GetComponent<Animator> ();
			enemy_creator = GameObject.Find ("Enemy_spawner");
			hit_circle = GetComponent<CircleCollider2D>();
			
			//enemy_fire = GameObject.Find ("enemy_fire");
			
		}
		
		// Update is called once per frame
		void Update () {	
				if (anim.GetBool ("vivo") == false) {
						this.transform.Translate (0, 0, 0);
			this.hit_circle.enabled = false;
				} else {

						distancia = player.transform.position.x - this.transform.position.x;
						if (distancia > -8 && distancia < 8) {
											
								if (Time.time > next_walk) {

										if (distancia >= 0.5f && this.isAttacking == false) {
												this.transform.localScale = new Vector2 (-1, 1);
												this.aim = 1;
										} else if(distancia < -0.5f) {
												this.transform.localScale = new Vector2 (1, 1);
												this.aim = -1;
										}

										this.isAttacking = false;

										if (distancia >= 0.5f) {
						this.transform.Translate (0.008f/* Time.deltaTime*/, 0, 0);
												anim.SetBool ("andando", true);
												anim.SetBool ("atacando", false);
					} else if(distancia < -0.5f) {
						this.transform.Translate (-0.008f/* Time.deltaTime*/, 0, 0);
												anim.SetBool ("andando", true);
												anim.SetBool ("atacando", false);
							
					}else{

						this.transform.Translate (0.008f * this.aim/* Time.deltaTime*/, 0, 0);
						anim.SetBool ("andando", true);
						anim.SetBool ("atacando", false);

					}
										
					
										if (player.transform.position.y >= this.transform.position.y) {
						this.transform.Translate (0, 0.003f* Time.deltaTime, 0);
												anim.SetBool ("andando", true);
												anim.SetBool ("atacando", false);
						
						
										} else {
						
						
						this.transform.Translate (0, -0.003f* Time.deltaTime, 0);
												anim.SetBool ("andando", true);
												anim.SetBool ("atacando", false);
										}
								}

								if (distancia >= -0.5f && distancia <= 0.5f && Time.time > proximotiro) {	
										this.isAttacking = true;
										next_walk = Time.time + 2;
										proximotiro = Time.time + 6;
										anim.SetBool ("andando", false);
										anim.SetBool ("atacando", true);
										control_attack = Time.time + 0.15f;
										this.aim_attack = this.aim;


								}

								if (this.isAttacking == true && Time.time <= control_attack) {

										if (player.transform.position.y >= this.transform.position.y) {
	
						this.transform.Translate (0.08f * this.aim_attack/** Time.deltaTime*/, 0.025f/* Time.deltaTime*/, 0);
										} else {

						this.transform.Translate (0.08f * this.aim_attack/** Time.deltaTime*/, -0.025f/* Time.deltaTime*/, 0);

										}

										
								}



						}

			if((this.transform.position.x > enemy_creator.GetComponent<Enemy_Create>().max_x || this.transform.position.x < enemy_creator.GetComponent<Enemy_Create>().min_x) && enemy_creator.GetComponent<Enemy_Create>().lock_screen == true){

				this.hit_circle.enabled = false;

			}else{

				this.hit_circle.enabled = true;

			}

			
				}
		}
		
		void OnTriggerEnter2D(Collider2D other) {
		
					if (other.gameObject.tag == "jogado" && this.isAttacking == true && other.GetComponent<Barra>().invenc == false) {
							
						other.GetComponent<Barra>().quantvida-=5;
						other.GetComponent<Barra>().rend.color = new Color(1f, 0f, 0f, 1f);
						other.GetComponent<Barra>().invenc = true;
						other.GetComponent<Barra>().proxima = Time.time + 0.8f;			

					}
			}
	}

