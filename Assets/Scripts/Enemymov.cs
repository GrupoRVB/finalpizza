using UnityEngine;
using System.Collections;

public class Enemymov : MonoBehaviour {
	public GameObject municao1;
	public GameObject municao2;	
	public GameObject player;
	public float rand;
	private float vida;
	private SpriteRenderer layer;
	public GameObject enemy_creator;
	public Animator anim;

	// Use this for initialization
	void Start () {
		//inimigo começa com 5 vidas
		vida = 5;
		//layer vai pegar o componente SpriteRender(aonde contem o controlador de layer)
		layer = GetComponent<SpriteRenderer>();
		//acha o gameobject "jogador"(personagem principal) e atribui a variavel player
		player = GameObject.Find ("Jogador");
		enemy_creator = GameObject.Find ("Enemy_spawner");	
		anim = this.GetComponent<Animator>();
		anim.SetBool("vivo", true);

	}
	
	// Update is called once per frame
	void Update () {
				if (enemy_creator.GetComponent<Enemy_Create> ().boss_activated == true) {

						Destroy (gameObject, 0.002f);

				}
		}
	void OnTriggerEnter2D(Collider2D other) {
			if (anim.GetBool ("vivo") == false) {
			} else {
				if (other.gameObject.tag == "Bala") {
						vida -= 3;
			this.transform.Translate( - 0.1f, 0, 0);
				}
			if (other.gameObject.tag == "Bala_tomate") {
						vida -= 1.5f;
				}
		if (other.gameObject.tag == "jogado" && other.GetComponent<Movimento>().atacando == true && other.GetComponent<Movimento>().andarFrente == 0) {
			vida -= 2;


				}
		if (player.transform.position.y > this.transform.position.y) {
						this.layer.sortingLayerName = "Pe";
				}
		if (player.transform.position.y < this.transform.position.y) {
			this.layer.sortingLayerName = "Frente";
		}		


		if(vida <= 0){
			anim.SetBool("vivo", false);
				Component.Destroy(this.collider2D);
			Destroy (this.gameObject , 2f);
			rand = Random.Range(1,100);
			if(rand <40){
				Instantiate (municao1, new Vector3(this.transform.position.x,this.transform.position.y-0.2f,0), Quaternion.identity);
			}
			if(rand > 80){
				Instantiate (municao2, new Vector3(this.transform.position.x,this.transform.position.y-0.2f,0), Quaternion.identity);
			}
			if(rand < 10){
				Instantiate (municao1, new Vector3(this.transform.position.x,this.transform.position.y-0.3f,0), Quaternion.identity);
				Instantiate (municao2, new Vector3(this.transform.position.x,this.transform.position.y-0.2f,0), Quaternion.identity);
					}
				}
			}
		}
	}

