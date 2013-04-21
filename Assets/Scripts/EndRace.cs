using UnityEngine;
using System.Collections;

public class EndRace : MonoBehaviour {

	void Start () {
		this.enabled = false;
	}
	
	void Update () {
	}
	
	void OnGUI() {
		float y = Screen.height/2.0f - 45;
		float x = Screen.width/2.0f - 50;
		
		// Wyswietlenie podsumowania
		
		GUIStyle centeredStyle = GUI.skin.GetStyle("Label");
    	centeredStyle.alignment = TextAnchor.UpperCenter;
		
		GameObject timeText = GameObject.Find("timeText");
		TimeCounter counter = timeText.GetComponent<TimeCounter>();
		int intTime = (int)(counter.elapsedTime*10);
		
		string name = GameObject.Find("typeYourName").GetComponent<TypeYourName>().yourName;
		
		if(GameGUI.English())
			GUI.Label(new Rect(Screen.width/2.0f - 100,y, 200, 30),
				"Your time "+name+": "+(intTime/10)+"."+(intTime%10)+"s", centeredStyle);
		else
			GUI.Label(new Rect(Screen.width/2.0f - 100,y, 200, 30),
				"Twoj czas "+name+": "+(intTime/10)+"."+(intTime%10)+"s", centeredStyle);
		y += 30;
		
		// Restart
		if(GUI.Button(new Rect(x, y, 100, 30), "Restart")) {
			Application.LoadLevel("AdRally");
		}
		
		y += 30;
		
		// Powrot do menu
		if(GUI.Button(new Rect(x, y, 100, 30), GameGUI.English() ? "Back to menu" : "Wroc do menu")) {
			Application.LoadLevel("menu");
		}
	}
}
