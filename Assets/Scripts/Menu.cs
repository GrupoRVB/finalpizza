using UnityEngine;
using System.Collections;
public class Menu : MonoBehaviour {
	private Animator animator;
	private float lado;
	private int atual =1;
	public bool principal =true;
	private float limitador =0.0f;
	public GameObject Controle;
	public GameObject Creditos;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		animator.SetInteger("Selecionado", atual);
	}
	//teste
	// Update is called once per frame
	void Update () {
		if (principal == true) {
						Menu_inicial ();
				} else {
			Voltar();
				}
	
	}
	void Menu_inicial(){
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
						if (atual < 1) {
								atual = 4;
						}
						animator.SetInteger ("Selecionado", atual);
						limitador = Time.time + 0.3f;
				}

				if (Input.GetButton ("Selecionar")|| Input.GetKey(KeyCode.J)){
						if (atual == 1) {
								Application.LoadLevel ("fase1");
						}
						if (atual == 2) {
						}
						Controle.transform.Translate (0.09841728f, 0.0701046f, 0);
						if (atual == 3) {
						}
						if (atual == 4) {
								Application.Quit ();
						}
						animator.SetInteger ("Selecionado", atual);
						limitador = Time.time + 0.3f;
			
				}
		if (Input.GetButton ("Selecionar")|| Input.GetKey(KeyCode.J)) {
						Selecionar ();
						principal = false;
				}
		}

	void Selecionar(){
		if (Input.GetButton ("Selecionar")|| Input.GetKey(KeyCode.J)) {
						if (atual == 1) {
								Application.LoadLevel ("fase1");
						}
						if (atual == 2) {
								Controle.transform.position = new Vector2 (0, 0);
						}
						if (atual == 3) {
								Creditos.transform.position = new Vector2 (0, 0);
						}
						if (atual == 4) {
								Application.Quit ();
						}
			
				}
		}
	void Voltar(){
		if (Input.GetButton ("Voltar") && atual == 2 || Input.GetKey(KeyCode.K) && atual == 2) {
			Controle.transform.position = new Vector2 (0, 10);
			principal = true;
				}
		if (Input.GetButton ("Voltar") && atual == 3 || Input.GetKey(KeyCode.K) && atual == 3) {
			Creditos.transform.position = new Vector2 (0, 10);
			principal = true;
		}
	}

}