using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class State : MonoBehaviour {

	public GameState gameState;

	private GameState currentState;
	private GameState previousState;

	private Dictionary<GameState, GameObject> windows;

	private GameObject pauseButton;

	// Use this for initialization
	void Start () {
		gameState = GameState.Start;

		windows = new Dictionary<GameState, GameObject> ();
		windows.Add (GameState.Start, GameObject.Find ("MainMenu"));
		windows.Add (GameState.Game, GameObject.Find ("GameScene"));
		windows.Add (GameState.Pause, GameObject.Find ("PauseWindow"));
		windows.Add (GameState.Win, GameObject.Find ("WinGameWindow"));
		windows.Add (GameState.Lose, GameObject.Find ("GameOverWindow"));

		pauseButton = GameObject.Find ("GamePauseButton");

		pauseButton.GetComponent<Button>().onClick.AddListener(() => { // anonymous (delegate) function!
			changeWindow (GameState.Pause);
		});


		// Set active window to start game
		changeWindow (GameState.Game);
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
			changeWindow (currentState);
			/*
			switch (currentState) {
			case GameState.Start:
				Debug.Log ("Start");
				break;
			case GameState.Game:
				Debug.Log ("Game");
				break;
			case GameState.Pause:
				Debug.Log ("Pause");
				break;
			case GameState.Win:
				Debug.Log ("Win");
				break;
			case GameState.Lose:
				Debug.Log ("Lose");
				break;
			}*/
		}

		previousState = currentState;
	}

	public void changeWindow(GameState state) {
		foreach (GameObject w in windows.Values) {
			w.SetActive(false);
		}

		windows[state].SetActive(true);
	}
}
