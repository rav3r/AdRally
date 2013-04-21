using UnityEngine;
using System.Collections;

public class LapCounter : MonoBehaviour {
	
	public int lap;
	
	void Start () {
		lap = 0;
	}
	
	void Update () {
		// Dopuszczamy okrazenia tylko z przedzialu [0, 3]
		int currLap = Mathf.Clamp(lap, 0, 3);
		
		guiText.text = "LAP " + currLap +"/3";
		
		if(Time.timeScale == 0.0f) {
			guiText.text = "";
		}
	}
}
