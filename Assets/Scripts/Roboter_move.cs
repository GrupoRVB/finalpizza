using UnityEngine;
using System.Collections;

public class Roboter_move : MonoBehaviour {

		public int contador;
		public GameObject player;
		public float distancia;
		public GameObject Boss_fire;
		public float next_action = 5.0f;
		public float dir;
		public Animator anim;
		public bool shoting;
		public float next_walk;
		public float aim;
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
		
		
		
		
		
		// Use this for initialization
		void Start () {
			
			player = GameObject.Find ("Jogador");
			anim = GetComponent<Animator> ();
			layer = GetComponent<SpriteRenderer>();
			hit_area = GetComponent<BoxCollider2D> ();
			
			//enemy_fire = GameObject.Find ("enemy_fire");
			
		}
		
		// Update is called once per frame
		void Update () {
			
		this.hit_area.center = new Vector2(0,0);
		this.hit_area.size = new Vector2(0,0);
			
			distancia = player.transform.position.x - this.transform.position.x;
			if (distancia > -10 && distancia < 10) {
				
				if (distancia >= 0 && this.socando == false) {
					this.transform.localScale = new Vector2 (-1, 1);
					this.aim = 1;
				} else {
					this.transform.localScale = new Vector2 (1, 1);
					this.aim = -1;
				}
				if(Time.time > next_walk){
				anim.SetBool ("tiro", false);
				anim.SetBool ("soco", false);
				anim.SetBool ("pulo", false);
				anim.SetBool ("caindo", false);
				this.shoting = false;
				this.socando = false;

					if(distancia <= -0.8f || distancia >= 0.8f)
					{
						if(distancia >=0)
						{
							this.transform.Translate (0.01f, 0, 0);
							anim.SetBool ("andando", true);
							
						}else{
							this.transform.Translate (-0.01f, 0, 0);
							anim.SetBool ("andando", true);
							
							
						}
					}						
					
					if (player.transform.position.y >= this.transform.position.y) {
						this.transform.Translate (0, 0.003f, 0);
						anim.SetBool ("andando", true);
						
						
					} else {
						
						
						this.transform.Translate (0, -0.003f, 0);
						anim.SetBool ("andando", true);
						
					}}
				
				if (Time.time > next_action) {

				random_action = Random.Range(1,100);

				if(random_action < 1)
				{
					anim.SetBool ("andando", false);
					anim.SetBool ("tiro", true);
					next_walk = Time.time + 0.8f;
					next_action = Time.time + 7;
					control = Time.time + 0.5f;
					this.shoting = true;

				}else if(random_action >= 1 && random_action < 2){
					anim.SetBool ("andando", false);
					anim.SetBool ("soco", true);
					next_walk = Time.time + 2.1f;
					next_action = Time.time + 8;
					this.socando = true;
					socando_timer = Time.time + 2;
					if(distancia >=0){
						this.dir = 1;
					}else{
						this.dir = -1;
					}

				}else if(random_action >= 2 && random_action < 100){
					anim.SetBool ("andando", false);
					anim.SetBool ("pulo", true);
					next_walk = Time.time + 8.5f;
					next_action = Time.time + 15;
					control = Time.time + 1.5f;
					this.jumping = true;
					trigger_fall = Time.time + Random.Range(3,6);
					stop_falling = Time.time + 8;
					this.is_falling = false;

				}
				}
			if(Time.time > control && this.shoting == true){
				this.shoting = false;
				Instantiate (Boss_fire,new Vector3(this.transform.position.x + (0.56f * this.aim), this.transform.position.y - 0.21f,0), Quaternion.identity);
							
			}	

			if(this.socando == true && Time.time < socando_timer){

			
					this.transform.localScale = new Vector2 (-1 * this.dir, 1);
					this.transform.Translate (0.04f * this.dir ,0 ,0);
					this.hit_area.center = new Vector2((- 1 * this.dir) * 0.4f, -0.2f);
					this.hit_area.size = new Vector2(0.4f, 0.4f);
					

			}

			if(Time.time > control && this.jumping == true && Time.time < trigger_fall){

				this.transform.Translate(0, 0.5f, 0);

				if(distancia >=0)
				{
					this.transform.Translate (0.01f, 0, 0);

					
				}else{
					this.transform.Translate (-0.01f, 0, 0);

					
					
				}


			}


			if(Time.time > trigger_fall && Time.time < stop_falling){
				this.is_falling = true;
				this.transform.Translate(0, -1, 0);
				this.jumping = false;
				anim.SetBool ("pulo", false);
				anim.SetBool ("caindo", true);
				this.hit_area.center = new Vector2((- 1 * this.dir) * 0.2f, -0.4f);
				this.hit_area.size = new Vector2(1, 0.4f);

				if(distancia >=0)
				{
					this.transform.Translate (0.01f, 0, 0);
					
					
				}else{
					this.transform.Translate (-0.01f, 0, 0);
					
					
					
				}


			}

			if(this.is_falling == true && this.transform.position.y <= player.transform.position.y + 0.5f){

				stop_falling = 0;
				this.is_falling = false;



			}


			}
			
			
		}
		

		}
		
	

