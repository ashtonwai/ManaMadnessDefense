using UnityEngine;
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

		foreach (GameObject w in windows) {
			w.SetActive(false);
		}

		windows[1].SetActive(true);

		pauseButton = GameObject.Find ("GamePauseButton");
	}
	
	// Update is called once per frame
	void Update () {
		currentState = gameState;

		if (currentState != previousState) {
			switch (currentState) {
			case GameState.Start:
				Debug.Log ("Start");
				foreach (GameObject w in windows) {
					w.SetActive(false);
				}

				windows[0].SetActive(true);
				break;
			case GameState.Game:
				Debug.Log ("Game");
				foreach (GameObject w in windows) {
					w.SetActive(false);
				}

				windows[1].SetActive(true);
				break;
			case GameState.Pause:
				Debug.Log ("Pause");
				foreach (GameObject w in windows) {
					w.SetActive(false);
				}

				windows[2].SetActive(true);
				break;
			case GameState.End:
				Debug.Log ("End");
				foreach (GameObject w in windows) {
					w.SetActive(false);
				}

				windows[4].SetActive(true);
				break;
			}
		}

		previousState = currentState;
	}
}
