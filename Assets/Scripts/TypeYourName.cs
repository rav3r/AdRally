using UnityEngine;
using System.Collections;

public class TypeYourName : MonoBehaviour {
	
	public string yourName;
	
	void Start () {
		// Zatrzymaj rozgrywke
		Time.timeScale = 0;
		yourName = "";
	}
	
	void Update () {
		
	}
	
	void OnGUI () {
		float y = Screen.height/2.0f - 45;
		float x = Screen.width/2.0f - 50;
		
		// Napis: "type your name"
		GUIStyle centeredStyle = GUI.skin.GetStyle("Label");
    	centeredStyle.alignment = TextAnchor.UpperCenter;
		
		if(GameGUI.English())
			GUI.Label(new Rect(Screen.width/2.0f - 100,y, 200, 30), "Type your name", centeredStyle);
		else
			GUI.Label(new Rect(Screen.width/2.0f - 100,y, 200, 30), "Wpisz swoje imie", centeredStyle);
		y += 30;
		
		// Pole tekstowe
		yourName = GUI.TextField(new Rect(x,y, 100, 20), yourName);
		
		y += 30;
		
		// Rozpocznij gre
		if(GUI.Button(new Rect(x, y, 100, 30), "START!")) {
			Time.timeScale = 1.0f;
			
			this.enabled = false;
		}
	}
}
