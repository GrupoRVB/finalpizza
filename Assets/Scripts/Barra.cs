using UnityEngine;
using System.Collections;

public class Barra : MonoBehaviour {
	public float posicaox;
	public float posicaoy;
	public float altura;
	public float largura;
	public float proxima;
	public float acender;
	public float dano;
	public float quantvida;
	public float MaxVida;

	public GUISkin textButton;
	public Animator anim;
	public SpriteRenderer rend;
	public bool invenc;
	public GameObject player;

	
	
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

		if (Input.GetButtonDown ("Kitmedico")||Input.GetKeyDown(KeyCode.M)) {
				if(GetComponent<Movimento>().MedictKit > 0){
				quantvida +=40;
				if(quantvida  > 100)
				{
					quantvida = 100;
							}
				}
		}

	
		if(invenc == true){
			rend.color = new Color(1f, 0f, 0f, 1f);	
			acender +=10*Time.deltaTime;
			rend.color = new Color(1f, 1f, 1f, 1f);
			
			if(acender > 0.4f){
				
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
		//posiçao no eixo x recebe o valor da tela/20(posiciona mais para esquerda)
		posicaox = Screen.width/17  ;
		//posiçao no eixo y recebe o valor da tela/3- o valor da tela/4, ou seja, um valor positivo (posiciona proximo do topo)
		posicaoy = Screen.height/3 - Screen.height/4;
		//define a largua sendo 50 vezes menor que a tela
		altura = Screen.height/50;
		// define a largura barra de vida sendo 1/4 do tamanho da tela, e com uma quantidade de vida pre estabelecida, podendo sempre que a quantidade maxima de vida aumentar, a mesma tambem cresce.
		largura = Screen.width/4 * (quantvida/MaxVida);
		//se a quant de vida for menor que que 100(ou seja, que a vida maxima
		if(quantvida < 100){
			
		}
		//se a vida for menor ou igual a 0
		if (quantvida <=0.1f){
			//seta na variavel de animaçao "vivo", para false
			anim.SetBool("vivo", false);
			
		}
	}
	//funçao de colisao no colisor
	void OnCollisionEnter2D(Collision2D coll) {
		//se colidir com um gameObject com a tag "inimigo" e o se tempo for maior que a variavel proxima(definida assim para que a vida desça por segundo em vez de por frame)
		if (coll.gameObject.tag == "inimigo" && Time.time > proxima) {
						//o proximo golpe sera depois de um tempo
						proxima = Time.time + dano;	
						rend.color = new Color (1f, 0f, 0f, 1f);
						invenc = true;
						//e perde 2 de vida
						quantvida -= 2;
				}
			
		}
	//funçao de colisao baseado no trigger
	void OnTriggerEnter2D(Collider2D other ) {
		//se colidir com outro objeto com a tag "inimigo_tiro" e o se tempo for maior que a variavel proxima(definida assim para que a vida desça por segundo em vez de por frame)
		if (other.gameObject.tag == "inimigo_tiro" && Time.time > proxima){
			//o proximo golpe sera dps de um tempo
			proxima = Time.time + dano;			
			invenc = true;
			//e destroy a bala do inimigo
			Destroy(other.gameObject);
			//perde 2 de vida
			quantvida -=1.5f;

			
			
		}
	}
	
	//funçao de texto dinamico na tela
	void OnGUI()
	{
		if (quantvida >= 0.1f) {
						//"pele rrecebe textBUTTON
						GUI.skin = textButton;
						//Define que o botao vai ser um retangulo com essas propriedades sem texto.
						GUI.Button (new Rect (posicaox, posicaoy, largura, altura), " ");
				} else {
		}
	}
}