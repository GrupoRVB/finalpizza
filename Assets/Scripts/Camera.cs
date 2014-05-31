	using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
	public GameObject player;
	public GameObject maincamera;
	public float Distancia;
	private bool chefe;
	private float limitep;
	private float limiten;
	public float limitefrente;
	public float limitetras;
	public bool camera_lock = false;
	public bool travou;

	void Start () {
		//a camera vai assim que o jogo começa para aonde o player estiver na posiçao previamente definida
		maincamera.transform.position = new Vector3 ((player.transform.position.x), -0.2832063f,Distancia);
		chefe = false;
	}
	
	// Update is called once per frame
	void Update () {
				//a camera acompanha o jogador conforme os frames vao se passando
				/*if (player.transform.position.x < 56.60 && chefe == false) {
			limiten=maincamera.transform.position.x-0.3f;
			limitep=maincamera.transform.position.x+0.3f;
			if(player.transform.position.x > limitep){
				maincamera.transform.position = new Vector3 (maincamera.transform.position.x, -0.2832063f, Distancia);
						} else {
								maincamera.transform.position = new Vector3 ((player.transform.position.x), -0.2832063f, Distancia);
						}
				}else {
			chefe = true;
			maincamera.transform.position = new Vector3 (56.60f, -0.2832063f,Distancia);
		}*/

				//codigo substituido pelo de cima, porem esse ele define um valor aonde se o jogador chegar a camera volta ao centro, dando impressao de "fases" pre definidas
				
		if (camera_lock == false) {
						if (player.transform.position.x < 56.60 && chefe == false) {
								limitefrente = maincamera.transform.position.x + 1.0f;
								limitetras = maincamera.transform.position.x - 1.0f;
								if (player.transform.position.x > limitefrente) {
										maincamera.transform.position = new Vector3 ((player.transform.position.x - 1.0f), maincamera.transform.position.y, Distancia);
	
								}
								if (player.transform.position.x < limitetras) {
										maincamera.transform.position = new Vector3 ((player.transform.position.x + 1.0f), maincamera.transform.position.y, Distancia);
								}
						} else {
								chefe = true;
								if (maincamera.transform.position.x < 56.60f) {
					maincamera.transform.position = new Vector3 ((maincamera.transform.position.x + 0.5f*Time.deltaTime), -0.2832063f, Distancia);
								} else {
										maincamera.transform.position = new Vector3 (56.60f, -0.2832063f, Distancia);
								}
						}
				}
		}
}

