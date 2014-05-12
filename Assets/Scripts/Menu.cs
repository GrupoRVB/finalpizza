using UnityEngine;
using System.Collections;
public class Menu : MonoBehaviour {
	private Animator animator;
	private float lado;
	private int atual =1;
	private float limitador =0.0f;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		animator.SetInteger("Selecionado", atual);
	}
	
	// Update is called once per frame
	void Update () {
				lado = Input.GetAxis ("Horizontal");
				if (lado > 0 && Time.time > limitador) {
						atual += 1;
						if (atual > 4) {
								atual = 1;
						}
						animator.SetInteger ("Selecionado", atual);
						limitador = Time.time + 0.3f;	


				}
				if (lado < 0 && Time.time > limitador) {
						atual -= 1;
						if (atual < 1){
								atual = 4;
			}
				animator.SetInteger ("Selecionado", atual);
				limitador = Time.time + 0.3f;
		}
		if(Input.GetButton("Selecionar")){
			if(atual == 1){
				Application.LoadLevel ("fase1");
			}
			if(atual ==2 ){
				Application.LoadLevel("Controles");
			}
			if(atual == 3){
				Application.LoadLevel("Creditos");
			}
			if(atual == 4){
				Application.Quit();
			}

		}
	}

}