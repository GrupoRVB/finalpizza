using UnityEngine;
using System.Collections;

public class Finalfase1 : MonoBehaviour {
	private float passar;
	// Use this for initialization
	void Start () {
	
	}

		// Update is called once per frame
		void Update () {
			passar += 0.1f*Time.deltaTime;	
			if (passar > 2f) {
			Debug.LogError(passar);
				
				Application.LoadLevel ("Menu");
			}
		}
	
	}
