using UnityEngine;
using System.Collections;

public class Enemymov : MonoBehaviour {
	public GameObject municao1;
	public GameObject municao2;	
	public GameObject player;
	public float rand;
	public float vida;
	private SpriteRenderer layer;
	public GameObject enemy_creator;
	public Animator anim;
	public SpriteRenderer rend;
	private float feedback;
	private bool tomou = false;
	public BoxCollider2D hit_box;
	public GameObject[] inimigos;
	public Vector3 coherency;
	public Vector3 separation;
	public GameObject analisator;
	public AudioClip morto;


	// Use this for initialization
	void Start () {
		//inimigo começa com 5 vidas
		vida = 5;
		player = GameObject.Find ("Jogador");
		//layer vai pegar o componente SpriteRender(aonde contem o controlador de layer)
		layer = GetComponent<SpriteRenderer>();
		//acha o gameobject "jogador"(personagem principal) e atribui a variavel player
		enemy_creator = GameObject.Find ("Enemy_spawner");	
		anim = this.GetComponent<Animator>();
		anim.SetBool("vivo", true);
		rend = GetComponent<SpriteRenderer>();
		hit_box = this.GetComponent<BoxCollider2D> ();
		inimigos = GameObject.FindGameObjectsWithTag ("inimigo");
		analisator = GameObject.Find ("analisator");

	}
	
	// Update is called once per frame
	void Update () {
				if (tomou == false) {
						rend.color = new Color (1f, 1f, 1f, 1f);
				} else {
						rend.color = new Color (1f, 0f, 0f, 1f);	
						feedback += 10f * Time.deltaTime;			
						if (feedback > 0.4f) {
								rend.color = new Color (1f, 0f, 0f, 1f);	
								feedback = 0;
								tomou = false;
						}
			
				}
				if (enemy_creator.GetComponent<Enemy_Create> ().boss_activated == true && this.tag != "boss") {

						Destroy (gameObject, 0.002f);

				}
		}

	void OnTriggerEnter2D(Collider2D other) {

			if (anim.GetBool ("vivo") == false) {
			Destroy(this.GetComponent<CircleCollider2D>());
			} else {
		
				if (other.gameObject.tag == "Bala") {
						vida -= 3;
								tomou = true;
			}
			if (other.gameObject.tag == "Bala_tomate") {
				tomou = true;
						vida -= 1.5f;
				}
		if (other.gameObject.tag == "jogado" && other.GetComponent<Movimento>().atacando == true && other.GetComponent<Movimento>().andarFrente == 0 ) {
			vida -= 1;
				tomou = true;


				}
		if (player.transform.position.y > this.transform.position.y) {
						this.layer.sortingLayerName = "Pe";
				}
		if (player.transform.position.y < this.transform.position.y) {
			this.layer.sortingLayerName = "Frente";
		}



			if(this.transform.position.x >= 29.4f && this.transform.position.x <= 33.8f){

				if(this.transform.position.y <= -0.9f){

					this.transform.position = new Vector2(this.transform.position.x, -0.9f);

				}

				if(this.transform.position.y >= -0.62f){
					
					this.transform.position = new Vector2(this.transform.position.x, -0.62f);
					
				}

			}


		if(vida <= 0){
				audio.PlayOneShot(morto);
				this.layer.sortingLayerName = "Frente";

			anim.SetBool("vivo", false);
				this.hit_box.enabled = false;
			Destroy (this.gameObject , 2f);
			rand = Random.Range(1,100);
			if(rand < (35 + analisator.GetComponent<Analise>().drop_rate_plus) && rand > 5){
				Instantiate (municao1, new Vector3(this.transform.position.x,this.transform.position.y-0.2f,0), Quaternion.identity);
			}
				if(rand > (90 - analisator.GetComponent<Analise>().drop_rate_plus)){
				Instantiate (municao2, new Vector3(this.transform.position.x,this.transform.position.y-0.2f,0), Quaternion.identity);
			}
			if(rand < 5){
				Instantiate (municao1, new Vector3(this.transform.position.x,this.transform.position.y-0.3f,0), Quaternion.identity);
				Instantiate (municao2, new Vector3(this.transform.position.x,this.transform.position.y-0.2f,0), Quaternion.identity);

					}

				}
			}
		}
	}

