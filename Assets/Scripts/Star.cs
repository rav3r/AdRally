using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {
	
	private float radius;
	public float rotationSpeed;
	
	private Vector3 direction;
	private Vector3 center;
	
	private float elapsedTime = 0;
	
	void Start () {
		direction = new Vector3(1, 0, 0);
		elapsedTime = Random.Range(0.0f, 1000.0f);
		
		center = transform.position;
		radius = 20.0f;
		transform.Rotate(new Vector3(0, Random.Range(0.0f, 360.0f), 0));
	}
	
	void Update () {
		elapsedTime += Time.deltaTime;
		
		// Obrot wzgledem pozycji poczatkowej
		Quaternion quat =Quaternion.Euler(0, 0, elapsedTime*rotationSpeed);
		transform.position = center + quat * direction * radius;
		
		// Obrot wzgledem srodka obiektu
		transform.Rotate(new Vector3(0,Time.deltaTime*180.0f,0));
	}
	
	void OnTriggerEnter(Collider collider) {
		if(collider.CompareTag("Player") && this.enabled) {
			// Zdobyles gwiazdke - odjecie czasu, odegranie dzwieku i schowanie gwiazdki
			
			GameObject timeText = GameObject.Find("timeText");
			TimeCounter counter = timeText.GetComponent<TimeCounter>();
			counter.elapsedTime -= 2.0f;
			if(counter.elapsedTime < 0) counter.elapsedTime = 0;
			
			if(!GameGUI.Mute())
				audio.Play();
			
			renderer.enabled = false;
			this.enabled = false;
		}
	}
}
