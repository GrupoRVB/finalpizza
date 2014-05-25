using UnityEngine;
using System.Collections;

public class Bala : MonoBehaviour {
	public int forca = 1000;
	//cria uma variavel do tipo GameObject com o nome player
	private GameObject player;
	// Use this for initialization
	void Start () 
	{
		//variaval "acha" o Jogador(nome do objeto que esta na cena, no caso poderia ser bola, Player1 e ate Main Camera
		player = GameObject.Find ("Jogador");
		//Ultiliza o metodo direcao
		direcao ();


		}
			

	// Update is called oce per frame
	void Update () {
		//destroi a bola depois de 0.7 segundos
		Destroy(gameObject, 0.7f);
	}
	//metodo para definir a direçao aonde a bola esta indo
	void direcao(){
		//se a escala do jogador estiver maior que zero
		if (Input.GetAxis ("Tiro") < 0  || Input.GetKey (KeyCode.K)) {
			//dar força ao rigidbody2D em um vetor forca(2000 no eixo x(direita)) e 0 ( 0 no eixto Y)
						rigidbody2D.AddForce (new Vector2 (forca, 0));
				}
		//se a escala do jogador estiver menor que zero
		if (Input.GetAxis ("Tiro") > 0  || Input.GetKey (KeyCode.J)) {

			//dar força ao rigidbody2D em um vetor forca(-2000 no eixo x(esquerda)) e 0 ( 0 no eixto Y)
		rigidbody2D.AddForce (new Vector2 (-forca, 0));

	}
	
}//ainda nao ta pronto :p

		void OnTriggerEnter2D(Collider2D other) {
			if (other.gameObject.tag == "barreira" ) {
				Destroy(this.gameObject, 0.02f);
		}
		if (other.gameObject.tag == "inimigo"|| other.gameObject.tag == "boss" || other.gameObject.tag == "inimigo_atirador") {
			Destroy(this.gameObject);	
		}
}
}

