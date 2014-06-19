using UnityEngine;
using System.Collections;

public class Analise : MonoBehaviour {

	public float shots;
	public float shots_hit;
	public float enemy_shots;
	public float enemy_shots_hit;
	public float melee_attacks;
	public float melee_attacks_hit;
	public float life_loss;
	public float melee_result;
	public float shot_result;
	public float enemy_shot_result;
	public int total_ammo;
	private GameObject player;
	private GameObject enemy_spawner;
	public float drop_rate_plus;
	public float enemy_plus;
	public float melee_enemy_count;
	public float ranged_enemy_count;
	public float count_enemyes;
	public float total_enemies_spawned;
	public float drop_increment;
	public float move_speed;


	// Use this for initialization
	void Start () {

		player = GameObject.Find ("Jogador");
		enemy_spawner = GameObject.Find ("Enemy_spawner");


	
	}
	
	// Update is called once per frame
	void Update () {

		total_ammo = player.GetComponent<Movimento> ().municao_azeitona + player.GetComponent<Movimento> ().municao_tomate;
		melee_result = melee_attacks_hit / melee_attacks;
		enemy_shot_result = enemy_shots_hit / enemy_shots;
		shot_result = shots_hit / shots;
		life_loss = enemy_spawner.GetComponent<Enemy_Create> ().life_loss;

				if (shot_result <= 0.7f) {

						drop_rate_plus = (1 - shot_result) * 30;

				} else {

						drop_rate_plus = 0;

				}


				if (life_loss <= 20 && life_loss > 0) {

						enemy_plus = 3;
						move_speed = 0.2f;

				} else if (life_loss > 20 && life_loss <= 40) {

						enemy_plus = 1;
						move_speed = 0.1f;

				}else if(life_loss == 0){

						enemy_plus = 0;
						move_speed = 0.2f;

				} else {

						enemy_plus = -3;
						move_speed = 0.2f;

				}

		count_enemyes = 9 + (enemy_plus);
				
		if (melee_result > enemy_shot_result && melee_result >= 0.4f) {

						melee_enemy_count = Mathf.RoundToInt (count_enemyes * 0.3f);
						ranged_enemy_count = Mathf.RoundToInt (count_enemyes * 0.7f);

				} else if (enemy_shot_result > melee_result && enemy_shot_result >= 0.4f) {

						melee_enemy_count = Mathf.RoundToInt (count_enemyes * 0.7f);
						ranged_enemy_count = Mathf.RoundToInt (count_enemyes * 0.3f);

				} else {

						melee_enemy_count = Mathf.RoundToInt (count_enemyes * 0.5f);
						ranged_enemy_count = Mathf.RoundToInt (count_enemyes * 0.5f);

				} 


	}
}
