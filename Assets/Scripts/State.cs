using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class State : MonoBehaviour {

	public GameState gameState;

	private GameState currentState;
	private GameState previousState;

	private List<GameObject> windows;

	private GameObject pauseButton;

	// Use this for initialization
	void Start () {
		gameState = GameState.Start;

		windows = new List<GameObject> ();
		windows.Add (GameObject.Find ("MainMenu"));
		windows.Add (GameObject.Find ("GameScene"));
		windows.Add (GameObject.Find ("PauseWindow"));
		windows.Add (GameObject.Find ("WinGameWindow"));
		windows.Add (GameObject.Find ("GameOverWindow"));

		changeWindow (1);

		pauseButton = GameObject.Find ("GamePauseButton");
		pauseButton.GetComponent<Button>().onClick.AddListener(print);
	}
	
	// Update is called once per frame
	void Update () {
		currentState = gameState;

		/*
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit)) {
			if (hit.transform == pauseButton.transform) {
				gameState = GameState.Pause;
			}
		}*/

		if (currentState != previousState) {
			switch (currentState) {
			case GameState.Start:
				Debug.Log ("Start");
				changeWindow (0);
				break;
			case GameState.Game:
				Debug.Log ("Game");
				changeWindow (1);
				break;
			case GameState.Pause:
				Debug.Log ("Pause");
				changeWindow (2);
				break;
			case GameState.End:
				Debug.Log ("End");
				changeWindow (4);
				break;
			}
		}

		previousState = currentState;
	}

	void print () {
		Debug.Log ("Clicked");
	}

	public void changeWindow(int window) {
		foreach (GameObject w in windows) {
			w.SetActive(false);
		}

		windows[window].SetActive(true);
	}
}
