using UnityEngine;
using System.Collections;
public class Menu : MonoBehaviour {
	private Animator animator;
	private float lado;
	public bool primeiro;
	private int atual =1;
	public bool principal =true;
	private float limitador =0.0f;
	public GameObject Controle;
	public GameObject Creditos;
	public GameObject Press;
	private bool sound = true;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		animator.SetInteger("Selecionado", atual);
		animator.SetBool ("on", true);
		primeiro = true;
	}
	//teste
	// Update is called once per frame
	void Update () {
		if (primeiro == true) {
			if(Input.GetButton ("Start")|| Input.GetKey(KeyCode.K)){
				primeiro = false;
				Destroy(Press);
			}
				} else {
						if (principal == true) {
								Menu_inicial ();
						} else {
				if (atual == 5) {
					principal = true;		
				}
								Voltar ();
						}
				}
	
	}
	void Menu_inicial(){
				lado = Input.GetAxis ("Horizontal");
				if (lado > 0 && Time.time > limitador) {
						atual += 1;
						if (atual > 5) {
								atual = 1;
						}
						animator.SetInteger ("Selecionado", atual);
						limitador = Time.time + 0.3f;
			
			
				}
				if (lado < 0 && Time.time > limitador) {
						atual -= 1;
						if (atual < 1) {
								atual = 5;
						}
						animator.SetInteger ("Selecionado", atual);
						limitador = Time.time + 0.3f;
				}

				/*if (Input.GetButtonDown("Selecionar")|| Input.GetKey(KeyCode.J)){
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
						if (atual == 5) {
						if(animator.GetBool("on") == true){
							animator.SetBool("on", false);
							AudioListener.volume = 0.0f;
						}else{
							animator.SetBool("on", true);
							AudioListener.volume = 1.0f;
				}
			}
						animator.SetInteger ("Selecionado", atual);
						limitador = Time.time + 0.3f;
			
				}*/
		if (Input.GetButton ("Selecionar")|| Input.GetKey(KeyCode.J)) {
						Selecionar ();
						principal = false;
				}
		}

	void Selecionar(){
				if (Input.GetButtonDown ("Selecionar") || Input.GetKey (KeyCode.J)) {
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
						if (atual == 5) {
				if(sound == true){
					animator.SetBool ("on", false);
					AudioListener.volume = 0.0f;
					sound = false;
								}else{
					animator.SetBool ("on", true);
					AudioListener.volume = 1.0f;
					sound = true;
				}
			}
			Debug.LogError(sound);

				}
		}
	void Voltar(){
		if (Input.GetButton ("Voltar") && atual == 2 || Input.GetKey(KeyCode.K) && atual == 2) {
			Controle.transform.position = new Vector2 (0, 15);
			principal = true;
				}
		if (Input.GetButton ("Voltar") && atual == 3 || Input.GetKey(KeyCode.K) && atual == 3) {
			Creditos.transform.position = new Vector2 (0, 15);
			principal = true;
		}
	
	}

}