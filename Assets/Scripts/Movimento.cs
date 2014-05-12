	using UnityEngine;
using System.Collections;

public class Movimento : MonoBehaviour {
	private GameObject player;
	public GameObject Bala;
	public GameObject BalaTomate;
	public float alturaMaxima;
	public float alturaMinima;
	public float speed;
	public float fireRate = 0.52f;
	public float fireTomate = 0.1f;
	private float proximotiro = 0.0F;
	private int municao_azeitona = 5;
	private int municao_tomate = 20;
	private int tipodemunicao = 1;
	private bool chefe = false;
	Vector3 localScale;
	public float andarFrente;
	public GUIText muniAze;
	public GUIText muniTomat;
	private bool vivo = true;
	public bool atacando = false;
	private Animator anim;
	// Use this for initialization
	void Start () {	

		//acha o gameobject "jogador"(personagem principal) e atribui a variavel player
				player = this.gameObject;
		//pega o componente "Animator" e armazena na variavel anim
		anim = GetComponent<Animator>();
	}
	// Vai chamar a cada frame os metodos:Movimentar e Atirar
	void Update () {
	//chama a funçao "Vivo"
		Vivo ();
		//se a variavel vivo for verdadeira
		if (vivo == true) {
			//chama todas as funçoes de açao
						Moviment ();
						Atirar ();
						TipoDeTiro ();
				} else {
			//senao, chama a funçao gameover
			GameOver();
			}
		//faz com que o GUITEXT(que e o contador), apar
		muniAze.text = ""+municao_azeitona;
		muniTomat.text = ""+municao_tomate;
	}

	//trata do movimento
	void Moviment()
	{
				//cria a variavel que armazena se se o jogador esta andando para frente ou para tras
				andarFrente = Input.GetAxis ("Horizontal") * speed;
				//se o valor de x for negativo(andando pra esquerda)
				if (andarFrente < 0) {
						//os sprites mudam para a esquerda
						player.transform.localScale = new Vector2 (-0.5f, 0.5f);
						//se o valor de x for positivo(andando pra direita)
				} else if (andarFrente > 0) {
						//os sprites mudam para a direita
						player.transform.localScale = new Vector2 (0.5f, 0.5f);
				}
				//move o jogador para a direçao em que esta sendo precionada
		if (anim.GetInteger ("velo") == 1 && anim.GetBool ("atirando") == true) {
						if (Input.GetAxis ("Tiro") > 0) {
				
								player.transform.localScale = new Vector2 (-0.5f, 0.5f);
								player.transform.Translate (andarFrente, 0, 0);
				
						}
						if (Input.GetAxis ("Tiro") < 0) {
				
								player.transform.localScale = new Vector2 (0.5f, 0.5f);
								player.transform.Translate (andarFrente, 0, 0);
						} 
		}else {
			player.transform.Translate (andarFrente, 0, 0);
				}


				//cria a variavel que armazena se se o jogador esta indo para cima ou para baixo
				float andarCima = Input.GetAxis ("Vertical") * speed;
				//move o jogador para a direçao em que esta sendo precionada
				player.transform.Translate (0, andarCima, 0);
				//se o jogador chegar no ponto maximo definido da tela
				if (player.transform.position.y > alturaMaxima) {
						//entao ele nao consegue subir mais, fica na posiçao maxima definida
						player.transform.position = new Vector2 (player.transform.position.x, alturaMaxima);
				}
				//se o jogador chegar no ponto minimo da tela 
				if (player.transform.position.y < alturaMinima) {
						//entao ele nao consegue descer mais, fica na posiçao minima definida
						player.transform.position = new Vector2 (player.transform.position.x, alturaMinima);		
				}
		if (player.transform.position.x > 35.0) {
						alturaMaxima = -0.27f;
				} else {
						alturaMaxima = -0.42f;
				}
		if(player.transform.position.x >35.84167){
			alturaMinima= -1.167768f; 
		
		} else {
			alturaMinima =-1.25f;
				
		}


		if (player.transform.position.x >= 56.60) {
						chefe = true;
				}

		if (player.transform.position.x > 58.42766f) {
						player.transform.position = new Vector2 (58.42766f, player.transform.position.y);

				}
		if (chefe == true) {
			if (player.transform.position.x < 54.76541f) {
				player.transform.position = new Vector2 (54.76541f, player.transform.position.y);
				
			}
				
		}



		if(Input.GetKey(KeyCode.F)){
			player.transform.Translate(0.8f, 0 ,0);
		}
		if (Input.GetButton ("Atacar")) {
						atacando = true;
				} else {
						atacando = false;
				}
		Debug.LogError (andarFrente);

	}//finalizada parte de movimento

	//trata o tiro
	void TipoDeTiro()
	{
		if (Input.GetButton ("r1")||  Input.GetKey (KeyCode.U)) {
						tipodemunicao = 1;

				}
		if (Input.GetButton ("l1")||  Input.GetKey (KeyCode.I)) {
						tipodemunicao = 2;

		
				}
		}
	void Atirar()
	{

				//se o jogador apertar a tecla RT ou LT no controle
				if (tipodemunicao == 1) {
						if (municao_azeitona > 0) {		
								if (Input.GetAxis ("Tiro") != 0 && Time.time > proximotiro || Input.GetKey (KeyCode.J) && Time.time > proximotiro) {								
										//cria o objeto "Bala", na posiçao do player								
										proximotiro = Time.time + fireRate;								
										Instantiate (Bala, new Vector2 (player.transform.position.x, player.transform.position.y - 0.05f), Quaternion.identity);
										municao_azeitona -= 1;
										if (Input.GetAxis ("Tiro") > 0) {
						
												player.transform.localScale = new Vector2 (-0.5f, 0.5f);

										}
										if (Input.GetAxis ("Tiro") < 0) {
						
												player.transform.localScale = new Vector2 (0.5f, 0.5f);
										}
			
										
								}
						}
				}
						if (tipodemunicao == 2) {
								if (municao_tomate > 0) {		
										if (Input.GetAxis ("Tiro") != 0 && Time.time > proximotiro) {								
												//cria o objeto "Bala", na posiçao do player								
												proximotiro = Time.time + fireTomate;								
												Instantiate (BalaTomate, new Vector3 (player.transform.position.x, player.transform.position.y - 0.03f, 0), Quaternion.identity);
												municao_tomate -= 1;
					
			
										}
								}
						}
				}
	void Vivo(){
				if (anim.GetBool("vivo") == false) {
				vivo = false;
			}
				
	}
	
	void OnCollisionEnter2D(Collision2D colisor)
	{

		if (colisor.gameObject.tag == "azeitona") 
		{
			municao_azeitona +=5;
		}
		if (colisor.gameObject.tag == "tomate") 
		{
			municao_tomate +=20;
		}
	}

	void GameOver(){
	Application.LoadLevel ("GameOver");
	}

	
}
