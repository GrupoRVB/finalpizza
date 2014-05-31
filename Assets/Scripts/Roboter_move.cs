		using UnityEngine;
		using System.Collections;

		public class Roboter_move : MonoBehaviour {

				
				public GameObject player;
				public GameObject camera_obj;
				public float distancia;
				public GameObject Boss_fire;
				public float next_action = 5.0f;
				public float dir;
				public Animator anim;
				public bool shoting;
				public float next_walk;
				public int aim = -1;
				private float control = 0.0f;
				private int random_action;
				public bool jumping;
				public float trigger_fall;
				public bool is_falling;
				public float stop_falling;
				public bool socando;
				public float socando_timer;
				public SpriteRenderer layer;
				public BoxCollider2D hit_area;
				public bool ishiting;
				public float time_hit = 0.0f;
				public bool jump_hit;
				public bool camera_shake;
				public float camera_time = 0;
				public int camera_control = 0;
				public float max_y = 0.154f;
				public float min_y = -0.69f;
				public float distancia_y;
				public float randomY;
				public bool action = false;
				public float hit_pulo;
				public float boss_life = 1;
				private float feedback;
				private bool tomou = false;
				private GUISkin textButton;
				public bool dead = false;
				public float control_dead = 0;
				private float passar = 0;
	//public GameObject municao1;
	//public GameObject municao2;
	public bool falled = false;
				
				// Use this for initialization
				void Start () {
					
					player = GameObject.Find ("Jogador");
					camera_obj = GameObject.Find ("Main Camera");
					anim = GetComponent<Animator> ();
					layer = GetComponent<SpriteRenderer>();
					hit_area = GetComponent<BoxCollider2D> ();
					
					
					
					anim.SetBool ("caindo", true);
					next_walk = Time.time + 4;
					trigger_fall = Time.time + 0.01f;
					stop_falling = Time.time + 8;
					next_action = Time.time +11;
					
									
				}

				
				// Update is called once per frame
				void Update () {

				if (dead == true) {
			passar += 0.5f* Time.deltaTime;

			if (passar > 4) {
			Application.LoadLevel ("finalfase1");

			}
		}else{


						if (tomou == false) {
								layer.color = new Color (1f, 1f, 1f, 1f);
						} else {
								layer.color = new Color (1f, 0f, 0f, 1f);	
				feedback += 10f * Time.deltaTime;			
				if (feedback > 0.4f) {
										layer.color = new Color (1f, 0f, 0f, 1f);	
										feedback = 0;
										tomou = false;
								}
					
						}

						distancia = player.transform.position.x - this.transform.position.x;
						distancia_y = player.transform.position.y - (this.transform.position.y - 0.4f);

						if (player.transform.position.y > (this.transform.position.y - 0.4f)) {
								this.layer.sortingLayerName = "Pe";
						}
						if (player.transform.position.y < (this.transform.position.y - 0.4f)) {
								this.layer.sortingLayerName = "Frente";
						}	
				
				
						if (distancia > -10 && distancia < 10) {
						
								if (distancia >= 0.3f && this.socando == false) {
										this.transform.localScale = new Vector2 (-1, 1);
										this.aim = 1;
								} else if (distancia <= -0.3f) {
										this.transform.localScale = new Vector2 (1, 1);
										this.aim = -1;
								}
								if (Time.time > next_walk) {
										anim.SetBool ("tiro", false);
										anim.SetBool ("soco", false);
										anim.SetBool ("pulo", false);
										anim.SetBool ("caindo", false);
										anim.SetBool ("caindo2", false);
										anim.SetBool ("normal", false);
										//anim.SetBool ("morto", false);
										anim.SetBool ("andando", true);
										this.shoting = false;
										this.socando = false;
										this.jump_hit = false;
										this.ishiting = false;
										this.action = false;

										if (distancia <= -0.49f || distancia >= 0.49f) {
												if (distancia >= 0) {
							this.transform.Translate (0.5f* Time.deltaTime, 0, 0);
														anim.SetBool ("andando", true);
														this.hit_area.center = new Vector2 (0, 0);
														this.hit_area.size = new Vector2 (0, 0);
									
												} else {
							this.transform.Translate (-0.5f* Time.deltaTime, 0, 0);
														anim.SetBool ("andando", true);
														this.hit_area.center = new Vector2 (0, 0);
														this.hit_area.size = new Vector2 (0, 0);
									
												}
										}						
							
										
										if (player.transform.position.y >= (this.transform.position.y - 0.4f)) {
						this.transform.Translate (0, 0.15f* Time.deltaTime, 0);
												anim.SetBool ("andando", true);
								
								
										} else if (player.transform.position.y < this.transform.position.y) {
							
								
						this.transform.Translate (0, -0.15f* Time.deltaTime, 0);
												anim.SetBool ("andando", true);
								
										}
												
										
										if (this.transform.position.y >= max_y) {
													
												this.transform.position = new Vector2 (this.transform.position.x, this.max_y);
													
										}

										if (this.transform.position.y <= min_y) {
							
												this.transform.position = new Vector2 (this.transform.position.x, this.min_y);
							
										}
						
						
								}
						
								if (Time.time > next_action) {

										random_action = Random.Range (1, 100);

										if (random_action <100) {
												anim.SetBool ("andando", false);
												anim.SetBool ("tiro", true);
												next_walk = Time.time + 0.8f;
												next_action = Time.time + 7;
												control = Time.time + 0.5f;
												action = true;
												if (distancia >= 0.4f) {
														this.aim = 1;
												} else {
														this.aim = -1;
												}
												this.shoting = true;

										} else if (random_action >= 1 && random_action < 2) {
												anim.SetBool ("andando", false);
												anim.SetBool ("soco", true);
												next_walk = Time.time + 2.1f;
												next_action = Time.time + 8;
												this.socando = true;
												action = true;
												socando_timer = Time.time + 2;
												if (distancia >= 0.4f) {
														this.dir = 1;
												} else {
														this.dir = -1;
												}

										} else if (random_action >= 1 && random_action < 2) {
												anim.SetBool ("andando", false);
												anim.SetBool ("pulo", true);
												next_walk = Time.time + 11.1f;
												next_action = Time.time + 15;
												control = Time.time + 1.5f;
												this.jumping = true;
												trigger_fall = Time.time + 5;
												stop_falling = Time.time + 10;
												this.is_falling = false;
												action = true;	
											falled = false;


										}
								}
								if (Time.time > control && this.shoting == true) {
										this.shoting = false;
					Instantiate (Boss_fire, new Vector3 (this.transform.position.x + (0.56f * this.aim), this.transform.position.y - 0.21f, 0), Quaternion.identity);
									
								}	

								if (this.socando == true && Time.time < socando_timer) {

					
										this.transform.localScale = new Vector2 (-1 * this.dir, 1);
					this.transform.Translate ((2.5f * this.dir)* Time.deltaTime, 0, 0);
								}

								if (Time.time > control && this.jumping == true && Time.time < trigger_fall) {

					this.transform.Translate (0, 18* Time.deltaTime, 0);

										if (distancia >= 0) {
						this.transform.Translate (0.5f* Time.deltaTime, 0, 0);

							
										} else {
						this.transform.Translate (-0.5f* Time.deltaTime, 0, 0);

							
							
										}

									

										


								}


								if (Time.time > trigger_fall && Time.time < stop_falling) {
										this.is_falling = true;
										this.transform.Translate (0, -40 * Time.deltaTime, 0);
										this.jumping = false;
					anim.SetBool ("pulo", false);

					if(this.transform.position.y < -0.7184167){
						this.transform.position = new Vector3(this.transform.position.x, -0.7184167f,0);
					}
										
										this.jump_hit = true;

										

								}

								if (this.is_falling == true && this.transform.position.y <= Random.Range (min_y, max_y) && falled == false) {
										
										hit_pulo = Time.time + 0.1f;
										stop_falling = 0;
										anim.SetBool ("caindo", true);
										camera_shake = true;
										camera_time = Time.time + 2;
										falled = true;

								}
								
									//bool check = anim.GetBool("caindo");

								if (Time.time > hit_pulo && this.is_falling == true) {
										
										anim.SetBool ("caindo", false);
										anim.SetBool ("caindo2", true);
										
										this.is_falling = false;
										

								}

						}
					
						if (camera_shake == true) {
						
								if (Time.time < camera_time) {

										if (camera_control >= 0 && camera_control <= 3) {
												camera_obj.transform.Translate (7.5f*Time.deltaTime, 0, 0);
												camera_control++;

										} else if (camera_control > 3 && camera_control <= 6) {
						camera_obj.transform.Translate (-7.5f*Time.deltaTime, 0, 0);
												camera_control++;

										} else if (camera_control > 6) {

												camera_control = 0;

										}
								} else {		
										camera_shake = false;
										
						
								}
						}

						if (distancia >= -0.5f && distancia <= 0.5f && distancia_y > -0.1f && distancia_y < 0.1f && action == false) {

								this.anim.SetBool ("andando", false);
								this.anim.SetBool ("normal", true);
								this.ishiting = true;
								next_walk = 0;
								next_walk = Time.time + 0.5f;
								next_action = 0;
								next_action = Time.time + 5;

						}

				}
				
		if (boss_life <= 0 && dead == false) {

			layer.color = new Color (1f, 1f, 1f, 1f);
			dead = true;
			control_dead = Time.time + 4;

			anim.SetBool ("tiro", false);
			anim.SetBool ("soco", false);
			anim.SetBool ("pulo", false);
			anim.SetBool ("caindo", false);
			anim.SetBool ("normal", false);
			anim.SetBool ("andando", false);
			anim.SetBool("morto",true);
		}
		
		if (dead == true && Time.time > control_dead) {
			
			anim.SetBool("morto",false);
			anim.SetBool("morto2",true);
									
		}

		}
						
				

			void OnTriggerEnter2D(Collider2D other) {
				
				if (other.gameObject.tag == "jogado" && Time.time > time_hit && this.socando == true) {
					
					other.GetComponent<Barra>().quantvida-=8;
					other.GetComponent<Barra>().rend.color = new Color(1f, 0f, 0f, 1f);
					other.GetComponent<Barra>().invenc = true;
					other.GetComponent<Barra>().proxima = Time.time + 0.8f;
					time_hit = Time.time + 3;			
								
				}

				if (other.gameObject.tag == "jogado" && Time.time > time_hit && this.jump_hit == true) {
					
					other.GetComponent<Barra>().quantvida-=15;
					other.GetComponent<Barra>().rend.color = new Color(1f, 0f, 0f, 1f);
					other.GetComponent<Barra>().invenc = true;
					other.GetComponent<Barra>().proxima = Time.time + 0.8f;
					time_hit = Time.time + 3;
					this.hit_area.center = new Vector2(0,0);
					this.hit_area.size = new Vector2(0,0);
					
				}
				
			if (other.gameObject.tag == "jogado" && Time.time > time_hit && this.ishiting == true) {
				
				other.GetComponent<Barra>().quantvida-=15;
				other.GetComponent<Barra>().rend.color = new Color(1f, 0f, 0f, 1f);
				other.GetComponent<Barra>().invenc = true;
				other.GetComponent<Barra>().proxima = Time.time + 0.8f;
				other.transform.Translate(1 * this.aim,0, 0);
				time_hit = Time.time + 3;
				this.hit_area.center = new Vector2(0,0);
				this.hit_area.size = new Vector2(0,0);
				
			}


				
						if (other.gameObject.tag == "Bala") {
								boss_life -= 1;
								tomou = true;
						}
						if (other.gameObject.tag == "Bala_tomate") {
								tomou = true;
								boss_life -= 0.5f;
						}
						if (other.gameObject.tag == "jogado" && other.GetComponent<Movimento> ().atacando == true && other.GetComponent<Movimento> ().andarFrente == 0) {
								boss_life -= 2.0f;
								tomou = true;
						
						}
				}
				
				


	void OnGUI()
	{
		//"pele rrecebe textBUTTON
		GUI.skin = textButton;
		//Define que o botao vai ser um retangulo com essas propriedades sem texto.
		GUI.Button(new Rect(57.9f,0.7f,2,0.5f)," ");
	}

				
			}


				
			
		

