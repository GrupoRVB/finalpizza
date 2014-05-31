using UnityEngine;
using System.Collections;

public class Enemy_Create : MonoBehaviour
{

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
		private float total3;
		private float minima;
		private float maxima;
		public float time_spawn;
		public bool boss_activated = false;
		public float tempo;
		public float initial_position;
		public int random_enemy_count;
		public int random_enemy_type;
		public float max_x;
		public float min_x;
		public bool lock_screen;
		public bool spawned_area = false;
		public int enemy_spawn_times;
		public int random_side;
		public GameObject camera_control;
		public GameObject main_camera;
		int count_remain = 0;
		public GUIText go;
	public float control_go;
	public bool go_showed;
	public bool start_go;
	public float size_go = 0;



		// Use this for initialization
		void Start ()
		{
				//acha a o gameobject "Jogador" e aloca na variavel plauer
				player = GameObject.Find ("Jogador");
				// seta que o tempo de spawn dos mobs e de 2.5f
				time_spawn = 3.5F;
				minima = player.GetComponent<Movimento> ().alturaMinima;
				maxima = player.GetComponent<Movimento> ().alturaMaxima;
				initial_position = player.transform.position.x;
				camera_control = GameObject.Find ("camera_control");
				main_camera = GameObject.Find ("Main Camera");


	
		}
	
		// Update is called once per frame
		void Update ()
		{
				tempo = Time.time;
				//se for a posiçao do jogador for maior ou igual a 53.10
				if (player.transform.position.x >= 53 && boss_activated == false) {
						boss_control = Time.time + 10;
						boss_activated = true;
						//o tempo do spawn e diminuido (fica mais rapido)
						//time_spawn = 1.3F;
				}
				//}
				//se o tempo(em segundos) for menor que o controlador do boss e o boss ainda nao for criado
				if (Time.time > boss_control && boss_created == false && boss_activated == true) {
						//boss recebe que ja foi criado
						boss_created = true;	
						// e instancia o boss
						Instantiate (Boss, new Vector3 (58, 2.37f, 0), Quaternion.identity);




				}

				if (player.transform.position.x >= initial_position + 5 && lock_screen == false && boss_created == false && player.transform.position.x <= 53) {

						max_x = player.transform.position.x + 1.8f;
						min_x = player.transform.position.x - 1.8f;
						float camera_position = min_x + 1.5f;
						//main_camera.transform.position = new Vector3(player.transform.position.x - 1.5f, main_camera.transform.position.y,-38.33f);
						lock_screen = true;
						camera_control.GetComponent<Camera>().camera_lock = true;
						

				}
				
		if(lock_screen == true && main_camera.transform.position.x <= (max_x - 1.8f)){

			main_camera.transform.position = new Vector3 (main_camera.transform.position.x + 0.5f*Time.deltaTime, -0.2832063f, -38.33f);

		}

				if (player.transform.position.x <= min_x && lock_screen == true) {

						player.transform.position = new Vector2 (min_x, player.transform.position.y);

				}

				if (player.transform.position.x >= max_x && lock_screen == true) {
			
						player.transform.position = new Vector2 (max_x, player.transform.position.y);
			
				}

				if (lock_screen == true && spawned_area == false) {

						spawned_area = true;
						random_enemy_count = Random.Range (6, 9);

						for (int i = 0; i <= random_enemy_count; i++) {

								random_enemy_type = Random.Range (1, 100);
								random_side = Random.Range (1, 100);

								if (random_enemy_type <= 50) {

										if (random_side <= 50) {

												Instantiate (Robotic, new Vector3 (min_x - Random.Range(3,5), Random.Range (-1.25f, -0.42f), 0), Quaternion.identity);

										} else {

						Instantiate (Robotic, new Vector3 (max_x + Random.Range(3,5), Random.Range (-1.25f, -0.42f), 0), Quaternion.identity);	
										}

								} else {
									
										if (random_side <= 50) {
						
						Instantiate (Enemy2, new Vector3 (min_x - Random.Range(3,5), Random.Range (-1.25f, -0.42f), 0), Quaternion.identity);
						
										} else {
						
						Instantiate (Enemy2, new Vector3 (max_x + Random.Range(3,5), Random.Range (-1.25f, -0.42f), 0), Quaternion.identity);	
										}
									

								}

						}
				}

		count_remain = GameObject.FindGameObjectsWithTag ("inimigo").Length + GameObject.FindGameObjectsWithTag ("inimigo_atirador").Length;

		if (lock_screen == true && spawned_area == true && count_remain <= 0) {

			lock_screen = false;
			camera_control.GetComponent<Camera>().camera_lock = false;
			spawned_area = false;
			initial_position = max_x;
			control_go = Time.time + 2;

			start_go = true;

				}

		if (Time.time > control_go && go_showed == false && start_go == true) {

			go_showed = true;
			go.text = "Go!->";
			//go.transform.position = new Vector2 (max_x - 1, 0.81f);
			go.fontSize = 60;

				}

		if (go_showed == true) {
			go.text = "Go!->";
						if (size_go <= 40) {

				go.enabled = false;
				size_go+=100f*Time.deltaTime;;

						} else if (size_go > 40 && size_go <= 80) {

				go.enabled = true;
				size_go+=100f*Time.deltaTime;

						} else {

								size_go = 0;

						}
				}

		if (go_showed == true && player.transform.position.x > max_x) {

			go_showed = false;
			go.enabled = false;
			start_go = false;	

				}



				//se 
				//if (Time.time > proximotiro && this.cont_spawn < 100 && player.transform.position.x > 2.35f && boss_activated == false) {								
				//proximotiro = Time.time + time_spawn;
				//;	
				//total3 = Random.Range (minima, maxima);

				//total2 = Random.Range (player.transform.position.x - 2, player.transform.position.x + 2);
				//if (total < -2.15f) {
				//total = -2.1f;
				//}
			
				//Instantiate (Robotic, new Vector3 (total2, -0.8572596f, 0), Quaternion.identity);
				//total2 = Random.Range (player.transform.position.x - 2, player.transform.position.x + 2);
				//if (total2 < -2.15f) {
				//total2 = -2.1f;
				//}
				//Instantiate (Enemy2, new Vector3 (total2, -0.8572596f, 0), Quaternion.identity);
				//Instantiate (Enemy2, new Vector3(Random.Range(player.transform.position.x - 3, player.transform.position.x + 3),-0.8572596f,0),Quaternion.identity);
				//Instantiate (Robotic, new Vector3(Random.Range(player.transform.position.x - 3, player.transform.position.x + 3),-0.8572596f,0),Quaternion.identity);
				//cont_spawn++;
				//if (cont_spawn >= 100) {
				//Application.LoadLevel ("finalfase1");
				//}
		}

}

