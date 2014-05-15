using UnityEngine;
using System.Collections;

public class Barra : MonoBehaviour {
<<<<<<< HEAD
	private float posicaox;
	private float posicaoy;
	private float altura;
	private float largura;
	private float proxima;
	private float acender;
	private float dano;
	private float quantvida;
	private float MaxVida;

	public GUISkin textButton;
	private Animator anim;
	private SpriteRenderer rend;
	private bool invenc;
	private GameObject player;


	void Start () {
		//acha o GameObject, jogador (personagem principal)e joga ele dentro da variavel player
		player = GameObject.Find ("Jogador");
		//
		rend = player.GetComponent<SpriteRenderer>();
		
		
		//pega o componente Animator, e joga ele dentro da variavel anim
		anim = GetComponent<Animator>();
		//define as variveis
		quantvida =100;
		MaxVida= 100;
		dano = 0.8f;
		proxima = 0.0f;
		//seta a variavel "vivo" como true no componente animator
		anim.SetBool("vivo", true);
		
	}
	
	void Update () {
		if(invenc == true){
			rend.color = new Color(1f, 0f, 0f, 1f);	
			acender +=1;
			rend.color = new Color(1f, 1f, 1f, 1f);
			
			if(acender == 9){
				
				rend.color = new Color(1f, 0f, 0f, 1f);	
				acender = 0;
			}
			
		}
		if(Time.time > proxima){
			invenc = false;
		}
		if(invenc == false){
			rend.color = new Color(1f, 1f, 1f, 1f);
			
		}
=======

	private GUISkin textButton;
	public float posicaox;
	public float posicaoy;
	public float altura;
	public float largura;
	public GameObject player;
	public float proxima;
	public float acender;
	public float dano;
	public Animator anim;
	public float quantvida;
	public float Maxvida;
	public SpriteRenderer rend;
	public bool invenc;

	// Use this for initialization
	void Start () {

		player = GameObject.Find ("Jogador");
		rend = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();
		quantvida = 100;
		Maxvida = 100;
		dano = 0.8f;
		proxima = 0;
		anim.SetBool ("vivo", true);

	}
	
	// Update is called once per frame
	void Update () {

		if (invenc == true) {

			rend.color = new Color(1f, 0f, 0f, 1f);
			acender+=1;
			rend.color = new Color(1f, 1f, 1f, 1f);

			if(acender == 9){

				rend.color = new Color(1f, 0f, 0f, 1f);	
				acender = 0;

			}

				}

		if(Time.time > proxima){
			invenc = false;
		}

		if(invenc == false){
			rend.color = new Color(1f, 1f, 1f, 1f);
			}
>>>>>>> 560d7475e05b1d3b46178648f8f761272c51bf93
		//posiçao no eixo x recebe o valor da tela/20(posiciona mais para esquerda)
		posicaox = Screen.width/20  ;
		//posiçao no eixo y recebe o valor da tela/3- o valor da tela/4, ou seja, um valor positivo (posiciona proximo do topo)
		posicaoy = Screen.height/3 - Screen.height/4;
		//define a largua sendo 50 vezes menor que a tela
		altura = Screen.height/50;
		// define a largura barra de vida sendo 1/4 do tamanho da tela, e com uma quantidade de vida pre estabelecida, podendo sempre que a quantidade maxima de vida aumentar, a mesma tambem cresce.
<<<<<<< HEAD
		largura = Screen.width/4 * (quantvida/MaxVida);
=======
		largura = Screen.width/4 * (quantvida/Maxvida);
>>>>>>> 560d7475e05b1d3b46178648f8f761272c51bf93
		//se a quant de vida for menor que que 100(ou seja, que a vida maxima
		if(quantvida < 100){
			//ganha uma pequena regeneraçao de vida
			quantvida+= 0.009f;
			
		}
<<<<<<< HEAD
=======

>>>>>>> 560d7475e05b1d3b46178648f8f761272c51bf93
		//se a vida for menor ou igual a 0
		if (quantvida <=0){
			//seta na variavel de animaçao "vivo", para false
			anim.SetBool("vivo", false);
<<<<<<< HEAD
			
		}
		
	}
	//funçao de colisao no colisor
	void OnCollisionEnter2D(Collision2D coll) {
		//se colidir com um gameObject com a tag "inimigo" e o se tempo for maior que a variavel proxima(definida assim para que a vida desça por segundo em vez de por frame)
		if (coll.gameObject.tag == "inimigo" && Time.time > proxima){
=======
			}

	}

	void OnCollisionEnter2D(Collision2D other){

		if (other.gameObject.tag == "inimigo" && Time.time > proxima){
>>>>>>> 560d7475e05b1d3b46178648f8f761272c51bf93
			//o proximo golpe sera depois de um tempo
			proxima = Time.time + dano;	
			rend.color = new Color(1f, 0f, 0f, 1f);
			invenc = true;
<<<<<<< HEAD
			//e perde 2 de vidaa
=======
			//e perde 2 de vida
>>>>>>> 560d7475e05b1d3b46178648f8f761272c51bf93
			quantvida -=2;
			
			
		}
<<<<<<< HEAD
	}
	//funçao de colisao baseado no trigger
	void OnTriggerEnter2D(Collider2D other ) {
		//se colidir com outro objeto com a tag "inimigo_tiro" e o se tempo for maior que a variavel proxima(definida assim para que a vida desça por segundo em vez de por frame)
=======




	}

	void OnTriggerEnter2D(Collision2D other){

>>>>>>> 560d7475e05b1d3b46178648f8f761272c51bf93
		if (other.gameObject.tag == "inimigo_tiro" && Time.time > proxima){
			//o proximo golpe sera dps de um tempo
			proxima = Time.time + dano;			
			invenc = true;
			//e destroy a bala do inimigo
			Destroy(other.gameObject);
			//perde 2 de vida
<<<<<<< HEAD
			quantvida -=2;
			
			
			
		}
	}
	
	//funçao de texto dinamico na tela
	void OnGUI()
	{
		//"pele rrecebe textBUTTON
		GUI.skin = textButton;
		//Define que o botao vai ser um retangulo com essas propriedades sem texto.
		GUI.Button(new Rect(posicaox,posicaoy,largura,altura)," ");
	}
}
	
=======
			quantvida -=2;		
		}



	}
	void OnCollisionEnter2D(Collider2D other) {
		
		if (other.gameObject.tag == "boss" && other.GetComponent<Roboter_move>().socando == true && Time.time > proxima ) {
			
			proxima = Time.time + dano;			
			invenc = true;
			quantvida -= 8;
			
		}
		
		if (other.gameObject.tag == "boss" && other.GetComponent<Roboter_move>().is_falling == true && Time.time > proxima ) {
			
			proxima = Time.time + dano;			
			invenc = true;
			quantvida -= 15;
			
		}
		
	}
	

	void onGUI()
	{

		GUI.skin = textButton;
		GUI.Button(new Rect(posicaox,posicaoy,largura,altura), " ");

	}

}
>>>>>>> 560d7475e05b1d3b46178648f8f761272c51bf93
