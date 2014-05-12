using UnityEngine;
using System.Collections;

public class Icone1 : MonoBehaviour {
	private GameObject player;
	public float topo;
	public float alinhamento;
	private bool chefe;

	// Use this for initialization
	void Start () {
		//seta variavel chefe para false ao iniciar
		chefe = false;
		//acha o gameobject "jogador"(personagem principal) e atribui a variavel player
		player = GameObject.Find ("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		//se a posiçao do jogador for menor que 56.60 e o chefe for false entao.
		if (player.transform.position.x < 56.60 && chefe == false) {
			//ela se move junto a tela
			this.transform.position = new Vector2(player.transform.position.x-alinhamento, topo);
		} else {
			//chefe se torna true, para nao voltar no outro loop
			chefe = true;
			//e fica estatico.
			this.transform.position = new Vector2(55f, topo);
		}

	}
}
