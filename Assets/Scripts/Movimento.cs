	using UnityEngine;
using System.Collections;

public class Movimento : MonoBehaviour {
	private GameObject player;
	public GameObject Bala;
	public GameObject BalaTomate;
	public float alturaMaxima = -0.42f;
	public float alturaMinima = -1.25f;
	public float speed;
	public float fireRate = 0.52f;
	public float fireTomate = 0.1f;
	private float proximotiro = 0.0F;
	private float oxilador;
	private int totaldearmas = 2;
	private int municao_azeitona = 0;
	private int municao_tomate = 0;
	public int MedictKit = 0;
	public int tipodemunicao = 1;
	public bool chefe = false;
	private bool contrario =false;
	Vector3 localScale;
	private float tempo=0;
	public float andarFrente;
	public float andarCima;
	public GUIText muniAze;
	public GUIText muniTomat;
	public GUIText Kitmedico;
	private bool vivo = true;
	public bool atacando = false;
	private Animator anim;
	public AudioClip azeitona;
	public AudioClip tomate;
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
		Kitmedico.text = "" + Kitmedico;
	}

	//trata do movimento
	void Moviment()
	{
		if (contrario == false) {
			oxilador = 1;
				} else {
			oxilador = 0.5f;
				}
				//cria a variavel que armazena se se o jogador esta andando para frente ou para tras
		andarFrente = ((Input.GetAxis ("Horizontal") * Time.deltaTime));
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
			if (Input.GetAxis ("Tiro") > 0 || Input.GetKey (KeyCode.J)){
								player.transform.localScale = new Vector2 (-0.5f, 0.5f);
								player.transform.Translate (andarFrente, 0, 0);
				if(andarFrente > 0){
					contrario =true;
				}

				
						}
			if (Input.GetAxis ("Tiro") < 0 || Input.GetKey (KeyCode.K)) {
								player.transform.localScale = new Vector2 (0.5f, 0.5f);
								player.transform.Translate (andarFrente, 0, 0);
				if(andarFrente < 0){
					contrario =true;
				}
						} 
		}else {
			player.transform.Translate (andarFrente, 0, 0);
			contrario = false;
				}


				//cria a variavel que armazena se se o jogador esta indo para cima ou para baixo

		andarCima = Input.GetAxis ("Vertical") * Time.deltaTime;
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
		if (Input.GetButton ("Atacar") || Input.GetKey (KeyCode.N)) {
						atacando = true;
				} else {
						atacando = false;
				}



	}//finalizada parte de movimento

	//trata o tiro
	void TipoDeTiro()
	{

		if (Input.GetButtonDown ("l1")||  Input.GetKeyDown  (KeyCode.I)) {
			tipodemunicao -= 1;
			if(tipodemunicao < 1){
				tipodemunicao = totaldearmas;
			}
		}
		if (Input.GetButtonDown ("r1")||  Input.GetKeyDown (KeyCode.U)) {
			tipodemunicao +=1;
			if( tipodemunicao > totaldearmas){

				tipodemunicao = 1;
			}
		}
		}
		
	void Atirar()
	{

				//se o jogador apertar a tecla RT ou LT no controle
				if (tipodemunicao == 1) {
						if (municao_azeitona > 0) {		
				if (Input.GetAxis ("Tiro") != 0 && Time.time > proximotiro || Input.GetKey (KeyCode.J) && Time.time > proximotiro || Input.GetKey (KeyCode.K) && Time.time > proximotiro) {								
										//cria o objeto "Bala", na posiçao do player								
										proximotiro = Time.time + fireRate;								
										Instantiate (Bala, new Vector2 (player.transform.position.x, player.transform.position.y - 0.05f), Quaternion.identity);
										municao_azeitona -= 1;
					audio.PlayOneShot(azeitona);

					if (Input.GetAxis ("Tiro") > 0 || Input.GetKey (KeyCode.J)) {
						
						player.transform.localScale = new Vector2 (-0.5f, 0.5f);
						
					}
					if (Input.GetAxis ("Tiro") < 0 || Input.GetKey (KeyCode.K)) {
						
						player.transform.localScale = new Vector2 (0.5f, 0.5f);
					}

			
										
								}
						}
				}
						if (tipodemunicao == 2) {
								if (municao_tomate > 0) {		
				if (Input.GetAxis ("Tiro") != 0 && Time.time > proximotiro || Input.GetKey (KeyCode.J) && Time.time > proximotiro || Input.GetKey (KeyCode.K) && Time.time > proximotiro) {								
												//cria o objeto "Bala", na posiçao do player								
												proximotiro = Time.time + fireTomate;								
												Instantiate (BalaTomate, new Vector3 (player.transform.position.x, player.transform.position.y - 0.03f, 0), Quaternion.identity);
												municao_tomate -= 1;
					audio.PlayOneShot(tomate);
					if (Input.GetAxis ("Tiro") > 0 || Input.GetKey (KeyCode.J)) {
						
						player.transform.localScale = new Vector2 (-0.5f, 0.5f);
						
					}
					if (Input.GetAxis ("Tiro") < 0 || Input.GetKey (KeyCode.K)) {
						
						player.transform.localScale = new Vector2 (0.5f, 0.5f);
					}
					
			
										}
								}
						}
				}
	void Curar(){
		if (Input.GetButtonDown ("Kitmedico")) {
			if(MedictKit >0){
			MedictKit -=1;
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

				if (colisor.gameObject.tag == "azeitona") {
						municao_azeitona += 5;
				}
				if (colisor.gameObject.tag == "tomate") {
						municao_tomate += 20;
				}
				if (colisor.gameObject.tag == "medico") {
			MedictKit +=1;
				}
		}
	void GameOver(){

		tempo += 1 * Time.deltaTime;
		Debug.LogError (tempo);
		if (tempo > 5) {
						Application.LoadLevel ("GameOver");
	
				}
		}

	
}
