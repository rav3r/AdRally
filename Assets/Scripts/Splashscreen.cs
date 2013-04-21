using UnityEngine;
using System.Collections;

public class Splashscreen : MonoBehaviour {
	
	private float elapsedTime;
	
	void Start () {
		elapsedTime = 0;
	}
	
	void Update () {
		// Po 5 sekundach przejdz do menu
		elapsedTime += Time.deltaTime;
		
		if(elapsedTime > 5.0f) {
			Application.LoadLevel("menu");
		}
	}
}
