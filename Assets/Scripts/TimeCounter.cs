using UnityEngine;
using System.Collections;

public class TimeCounter : MonoBehaviour {
	
	public float elapsedTime;
	
	void Start () {
		elapsedTime = 0;
	}
	
	void Update () {
		// Dodaj czas tej klatki
		elapsedTime += Time.deltaTime;
		
		int intTime = (int)(elapsedTime * 10);
		
		// Wyswietl aktualny czas
		if(GameGUI.English())
			guiText.text = "TIME "+(intTime/10)+"."+(intTime%10);
		else
			guiText.text = "CZAS "+(intTime/10)+"."+(intTime%10);
		
		// Jesli gra zawieszona to nie wyswietlaj czasu
		if(Time.timeScale == 0.0f) {
			guiText.text = "";
		}
	}
}
