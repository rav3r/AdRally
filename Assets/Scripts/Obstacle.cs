using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {
	
	void Start () {
	}
	
	void Update () {
	}
	
	void OnTriggerEnter() {
		// Dodaj czas oraz odegraj dzwiek
		GameObject timeText = GameObject.Find("timeText");
		timeText.GetComponent<TimeCounter>().elapsedTime += 4.0f;
		if(!GameGUI.Mute())
			audio.Play();
	}
	
	void OnTriggerStay() {
		// Spowolnij pojazd gdy dotyka przeszkody
		GameObject car = GameObject.Find("car");
		car.rigidbody.AddForce(-car.rigidbody.velocity*car.rigidbody.mass*10);
	}
}
