using UnityEngine;
using System.Collections;

public class AnimarBot : MonoBehaviour {
	private Animator anim;
	//funciona quando inicia
	void Start () {
		
		//pega o componente "Animator" e armazena na variavel anim
		anim = GetComponent<Animator>();
		//seta a variavel do animator "sele" como true
		anim.SetBool("sele", true);
		
	}
	//funciona por frame
	void Update () {
		//stand vai receber 0.1por frame
		
		//se apertar o botao definido como tipo 1
		if (Input.GetButton ("l1")||  Input.GetKey (KeyCode.U)) {
			anim.SetBool("sele", false);
			
		}
		if (Input.GetButton ("r1")||  Input.GetKey (KeyCode.I)){
			anim.SetBool("sele", true);
			
		}
		
		
		
		
	}
}