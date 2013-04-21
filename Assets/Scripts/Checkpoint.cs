using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
	
	public bool isCurrent;
	public bool isGoal;
	public string nextCheckpoint;
	
	void Start () {
	}
	
	void Update () {
	}
	
	void OnTriggerExit() {
		if(isCurrent) {
			// Aktywuj nastepny checkpoint
			isCurrent = false;
			GameObject gameObject = GameObject.Find(nextCheckpoint);
			gameObject.GetComponent<Checkpoint>().isCurrent = true;
			
			if(isGoal) {
				GameObject lapText = GameObject.Find("lapText");
				LapCounter lapCounter = lapText.GetComponent<LapCounter>();
				if(lapCounter.lap == 3) {
					// Jesli jest to startowy checkpoint i gracz wykonal 3 okrazenia - wyswietl podsumowanie
					GameObject endRace = GameObject.Find("endRace");
					endRace.GetComponent<EndRace>().enabled = true;
					Time.timeScale = 0.0f;
				}
				lapCounter.lap++;
			}
		}
	}
}
