using UnityEngine;
using System.Collections;

public class AnimarBot : MonoBehaviour {
	private Animator anim;
	private int tipo;
	public GameObject player;
	//funciona quando inicia
	void Start () {

		//pega o componente "Animator" e armazena na variavel anim
		anim = GetComponent<Animator>();
		//seta a variavel do animator "sele" como true
		
	}
	//funciona por frame
	void Update () {
		//stand vai receber 0.1por frame
		tipo = player.GetComponent<Movimento> ().tipodemunicao;
		//se apertar o botao definido como tipo 1
		anim.SetInteger("Tipo de tiro", tipo);
			
		}
}