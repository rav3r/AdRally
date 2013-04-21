using UnityEngine;
using System.Collections;

enum GameGUIState { Main, Options, About }

public class GameGUI : MonoBehaviour {
	
	public float buttonWidth;
	public float buttonHeight;
	
	private bool mute;
	private int languageId;
	
	public string imgUrl;
	
	private GameGUIState guiState;
	private Texture2D nitroImage = null;
	
	void Start () {
		guiState = GameGUIState.Main;
		languageId = PlayerPrefs.GetInt("lang");
		mute = Mute();
	}
	
	void Update () {
	}
	
	IEnumerator DownloadTexture() {
		nitroImage = null;
        WWW www = new WWW(imgUrl);
        yield return www;
        nitroImage = www.texture;
	}
	
	public static bool English() {
		return PlayerPrefs.GetInt("lang") == 0;
	}
	
	public static bool Mute() {
		return PlayerPrefs.GetInt("mute") != 0;
	}
	
	void OnGUI () {
		// Obliczanie rozstawienia kontrolek
		int buttonCount = 1;
		switch(guiState) {
		case GameGUIState.Main: buttonCount = 4; break;
		case GameGUIState.Options: buttonCount = 3; break;
		default:break;
		}
		float buttonX = Screen.width/2.0f - buttonWidth/2.0f;
		float buttonY = Screen.height/2.0f - buttonHeight*buttonCount/2.0f;
		
		if(guiState == GameGUIState.Main) {
			// Rozpocznij gre
			if (GUI.Button (new Rect (buttonX, buttonY, buttonWidth, buttonHeight), "Start")) {
				Application.LoadLevel("AdRally");
				enabled = false;
			}
			buttonY += buttonHeight;
			// Przejdz do opcji
			if (GUI.Button (new Rect (buttonX, buttonY, buttonWidth, buttonHeight), English() ? "Options" : "Opcje")) {
				guiState = GameGUIState.Options;
			}
			buttonY += buttonHeight;
			// Przejdz do ekranu about
			if (GUI.Button (new Rect (buttonX, buttonY, buttonWidth, buttonHeight), English() ? "About" : "O grze")) {
				//StartCoroutine(DownloadTexture());
				guiState = GameGUIState.About;
			}
			buttonY += buttonHeight;
			// Wyjdz z gry
			if (GUI.Button (new Rect (buttonX, buttonY, buttonWidth, buttonHeight), English() ? "Exit" : "Wyjscie")) {
				Application.Quit();
			}
			buttonY += buttonHeight;
		} else if(guiState == GameGUIState.Options) {
			// Wyciszyc?
			mute = GUI.Toggle (new Rect (buttonX, buttonY, buttonWidth, buttonHeight), mute, English() ? "Mute" : "Wylacz dzwiek");
			buttonY += buttonHeight;
			
			// Wybierz jezyk
			string []languages = {"English", "Polski"};
			languageId = GUI.SelectionGrid(new Rect (buttonX, buttonY, buttonWidth, buttonHeight), languageId,languages, 2,"toggle");
			buttonY += buttonHeight;
			
			// Powrot do menu
			if (GUI.Button (new Rect (buttonX, buttonY, buttonWidth, buttonHeight), English() ? "Back" : "Powrot")) {
				guiState = GameGUIState.Main;
			}
			
			PlayerPrefs.SetInt("lang", languageId);
			PlayerPrefs.SetInt("mute", mute ? 1 : 0);
		} else if(guiState == GameGUIState.About) {
			// Liczenie lacznej wysokosci wszystkich kontrolek
			float allHeight = 2*buttonHeight;
			
			if(nitroImage != null) {
				allHeight += nitroImage.height;
			} else {
				//allHeight += buttonHeight;
			}
			buttonY = Screen.height/2.0f - allHeight/2.0f;
			
			// Kto to stworzyl?
			float labelWidth = 800;
			GUIStyle centeredStyle = GUI.skin.GetStyle("Label");
    		centeredStyle.alignment = TextAnchor.UpperCenter;
			GUI.Label(new Rect(Screen.width/2.0f - labelWidth/2.0f, buttonY, labelWidth, buttonHeight), 
				English() ? "This application was created by Rafal in Unity engine" :
							"Ta aplikacja zostala stworzona przez Rafala w Unity engine",centeredStyle);
			buttonY += buttonHeight;
			
			// Jest obrazek - rysuj go
			if(nitroImage != null) {
				float imageX = Screen.width/2.0f - nitroImage.width/2.0f;
				
				GUI.DrawTexture(new Rect(imageX, buttonY, nitroImage.width, nitroImage.height), nitroImage);
				buttonY += nitroImage.height;
			} else { // Nie ma obrazka - prosze czekac...
				/*GUI.Label(new Rect(Screen.width/2.0f - labelWidth/2.0f, buttonY, labelWidth, buttonHeight), 
					English() ? "Downloading image..." :
								"Pobieranie obrazka",centeredStyle);
				buttonY += buttonHeight;*/
			}
			
			// Powrot do menu
			if (GUI.Button (new Rect (buttonX, buttonY, buttonWidth, buttonHeight), English() ? "Back" : "Powrot")) {
				guiState = GameGUIState.Main;
			}
		}
	}
}
