using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameState {
	Start,
	Game,
	Pause,
	End
}

public enum ElementType { 
	Red,
	Green,
	Blue
};

public class GameManager : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	public GameState gameState = GameState.Start;
	private static GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();

	public static GameManager getGM () {
		return gm; 
	}

	public static GameObject player = GameObject.Find("Player");
		
	public static Color[] elementColor = { 
		Color.red,
		Color.green,
		Color.blue
	};

	public static ElementType[] elementStrength = {
		ElementType.Green,
		ElementType.Blue,
		ElementType.Red
	};

	/// <summary>
	///  // Gets a random enum by using the values existing within the enum
	/// </summary>
	/// <returns></returns>
	public static ElementType GetRandomType() {
		// create an array that holds the values of each ElementType
		System.Array a = System.Enum.GetValues(typeof(ElementType));

		// cycle through the array and then return a random enum type
		return (ElementType)a.GetValue(Random.Range(0, a.Length));
	}
}
