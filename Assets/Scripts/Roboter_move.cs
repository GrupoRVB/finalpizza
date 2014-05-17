	using UnityEngine;
	using System.Collections;

	public class Roboter_move : MonoBehaviour {

			public int contador;
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
			public float distancia_min;
			public float control = 0.0f;
			public int random_action;
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
			public float camera_y;
			public float max_y = 0.154f;
			public float min_y = -0.862f;
			public float distancia_y;
						
			
			// Use this for initialization
			void Start () {
				
				player = GameObject.Find ("Jogador");
				camera_obj = GameObject.Find ("Main Camera");
				anim = GetComponent<Animator> ();
				layer = GetComponent<SpriteRenderer>();
				hit_area = GetComponent<BoxCollider2D> ();
				camera_y = camera_obj.transform.position.y;
				
				anim.SetBool ("caindo", true);
				next_walk = Time.time + 6;
				trigger_fall = Time.time + 0.01f;
				stop_falling = Time.time + 8;
				next_action = Time.time + 12;
				
								
			}
			
			// Update is called once per frame
			void Update () {
			
					distancia = player.transform.position.x - this.transform.position.x;
					distancia_y = player.transform.position.y - this.transform.position.y;

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
							} else if(distancia <= -0.3f) {
									this.transform.localScale = new Vector2 (1, 1);
									this.aim = -1;
							}
							if (Time.time > next_walk) {
									anim.SetBool ("tiro", false);
									anim.SetBool ("soco", false);
									anim.SetBool ("pulo", false);
									anim.SetBool ("caindo", false);
									anim.SetBool ("andando", true);
									this.shoting = false;
									this.socando = false;
									this.jump_hit = false;

									if (distancia <= -0.8f || distancia >= 0.8f) {
											if (distancia >= 0) {
													this.transform.Translate (0.01f, 0, 0);
													anim.SetBool ("andando", true);
													this.hit_area.center = new Vector2 (0, 0);
													this.hit_area.size = new Vector2 (0, 0);
								
											} else {
													this.transform.Translate (-0.01f, 0, 0);
													anim.SetBool ("andando", true);
													this.hit_area.center = new Vector2 (0, 0);
													this.hit_area.size = new Vector2 (0, 0);
								
											}
									}						
						
									
										if (player.transform.position.y >= (this.transform.position.y - 0.4f)) {
											this.transform.Translate (0, 0.003f, 0);
											anim.SetBool ("andando", true);
							
							
									} else if(player.transform.position.y < this.transform.position.y) {
						
							
											this.transform.Translate (0, -0.003f, 0);
											anim.SetBool ("andando", true);
							
									}
											
									
										if(this.transform.position.y >= max_y){
												
												this.transform.position = new Vector2(this.transform.position.x, max_y);
												
											}

										if(this.transform.position.y <= min_y){
						
											this.transform.position = new Vector2(this.transform.position.x, min_y);
						
											}
					
					
				}
					
							if (Time.time > next_action) {

									random_action = Random.Range (1, 100);

									if (random_action < 98) {
											anim.SetBool ("andando", false);
											anim.SetBool ("tiro", true);
											next_walk = Time.time + 0.8f;
											next_action = Time.time + 7;
											control = Time.time + 0.5f;
											if (distancia >= 0.8f) {
												this.aim = 1;
											} else {
												this.aim = -1;
											}
											this.shoting = true;

									} else if (random_action >= 98 && random_action < 99) {
											anim.SetBool ("andando", false);
											anim.SetBool ("soco", true);
											next_walk = Time.time + 2.1f;
											next_action = Time.time + 8;
											this.socando = true;
											socando_timer = Time.time + 2;
											if (distancia >= 0) {
													this.dir = 1;
											} else {
													this.dir = -1;
											}

									} else if (random_action >= 99 && random_action < 100) {
											anim.SetBool ("andando", false);
											anim.SetBool ("pulo", true);
											next_walk = Time.time + 8.5f;
											next_action = Time.time + 15;
											control = Time.time + 1.5f;
											this.jumping = true;
											trigger_fall = Time.time + Random.Range (3, 6);
											stop_falling = Time.time + 8;
											this.is_falling = false;


									}
							}
							if (Time.time > control && this.shoting == true) {
									this.shoting = false;
									Instantiate (Boss_fire, new Vector3 (this.transform.position.x + (0.56f * this.aim), this.transform.position.y - 0.21f, 0), Quaternion.identity);
								
							}	

							if (this.socando == true && Time.time < socando_timer) {

				
									this.transform.localScale = new Vector2 (-1 * this.dir, 1);
									this.transform.Translate (0.04f * this.dir, 0, 0);
									this.hit_area.center = new Vector2 (-0.4f, -0.2f);
									this.hit_area.size = new Vector2 (0.4f, 0.4f);
						

							}

							if (Time.time > control && this.jumping == true && Time.time < trigger_fall) {

									this.transform.Translate (0, 0.5f, 0);

									if (distancia >= 0) {
											this.transform.Translate (0.01f, 0, 0);

						
									} else {
											this.transform.Translate (-0.01f, 0, 0);

						
						
									}


							}


							if (Time.time > trigger_fall && Time.time < stop_falling) {
									this.is_falling = true;
									this.transform.Translate (0, -0.8f, 0);
									this.jumping = false;
									anim.SetBool ("pulo", false);
									anim.SetBool ("caindo", true);
									this.hit_area.center = new Vector2 ((- 1 * this.dir) * 0.2f, -0.4f);
									this.hit_area.size = new Vector2 (1, 0.4f);
									this.jump_hit = true;

									if (distancia >= 0) {
											this.transform.Translate (0.01f, 0, 0);
						
						
									} else {
											this.transform.Translate (-0.01f, 0, 0);
						
						
						
									}


							}

							if (this.is_falling == true && this.transform.position.y <= Random.Range(min_y,max_y)) {
									
									this.hit_area.center = new Vector2 (0, 0);
									this.hit_area.size = new Vector2 (0, 0);
									stop_falling = 0;
									this.is_falling = false;

									camera_shake = true;
									camera_time = Time.time + 2;

							}


					}
				
					if (camera_shake == true){
			
							if (Time.time < camera_time) {

							if (camera_control >= 0 && camera_control <= 3) {
									camera_obj.transform.Translate (0.02f, 0, 0);
									camera_control++;

							} else if (camera_control > 3 && camera_control <= 6) {
									camera_obj.transform.Translate (-0.02f, 0, 0);
									camera_control++;

							} else if (camera_control > 6){

									camera_control = 0;

									}
							}else{		
									camera_shake = false;
					
								}
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
			
			
		}


			}
		
	

