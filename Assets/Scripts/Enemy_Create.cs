using UnityEngine;
using System.Collections;

public class Enemy_Create : MonoBehaviour {

	public GameObject player;
	public GameObject Robotic;
	public GameObject Boss;
	public GameObject Enemy2;
	public float proximotiro = 5.0F;
	public bool boss_created = false;
	public float boss_control = 0.0f;
	public bool stop_spawn;
	public int cont_spawn;
	private float total;
	private float total2;
	public float time_spawn;

	// Use this for initialization
	void Start () {
		//acha a o gameobject "Jogador" e aloca na variavel plauer
		player = GameObject.Find ("Jogador");
		// seta que o tempo de spawn dos mobs e de 2.5f
		time_spawn = 2.5F;
	
	}
	
	// Update is called once per frame
	void Update () {
		//se for a posiçao do jogador for maior ou igual a 53.10
		if (player.transform.position.x >= 53.10f) {
						//this.boss_control = Time.time + 4;
			//o tempo do spawn e diminuido (fica mais rapido)
			time_spawn = 1.3F;
				}
				//}
		//se o tempo(em segundos) for menor que o controlador do boss e o boss ainda nao for criado
		if (Time.time < this.boss_control && this.boss_created == false) {
			//boss recebe que ja foi criado
			this.boss_created = true;	
			// e instancia o boss
			//Instantiate (Boss, new Vector3 (57, -0.59f, 0), Quaternion.identity);
				}
		//se 
		if (Time.time > proximotiro && this.cont_spawn < 100 && player.transform.position.x > 2.35f) {								
			proximotiro = Time.time + time_spawn;;	
		
						total2 = Random.Range (player.transform.position.x - 2, player.transform.position.x + 2);
						if (total < -2.15f) {
								total = -2.1f;
						}
			
						Instantiate (Robotic, new Vector3 (total2, -0.8572596f, 0), Quaternion.identity);
						total2 = Random.Range (player.transform.position.x - 2, player.transform.position.x + 2);
						if (total2 < -2.15f) {
								total2 = -2.1f;
						}
						Instantiate (Robotic, new Vector3 (total2, -0.8572596f, 0), Quaternion.identity);
						//Instantiate (Enemy2, new Vector3(Random.Range(player.transform.position.x - 3, player.transform.position.x + 3),-0.8572596f,0),Quaternion.identity);
						//Instantiate (Robotic, new Vector3(Random.Range(player.transform.position.x - 3, player.transform.position.x + 3),-0.8572596f,0),Quaternion.identity);
						cont_spawn++;
						if (cont_spawn >= 100) {
								Application.LoadLevel ("finalfase1");
						}
				}

	}
}
