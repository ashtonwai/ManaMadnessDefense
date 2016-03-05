using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameState
{
	Start,
	Game,
	Pause,
	Win,
	Lose
}

public enum ElementType
{
	Red = 0,
	Green = 1,
	Blue = 2
}

public class GameManager : MonoBehaviour
{
		
	public static State GM = GameObject.Find ("GameManager").GetComponent<State> ();

	public static GameObject player = GameObject.Find ("Player");
		
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
	public static ElementType GetRandomType ()
	{
		// create an array that holds the values of each ElementType
		System.Array a = System.Enum.GetValues (typeof(ElementType));

		// cycle through the array and then return a random enum type
		return (ElementType)a.GetValue (Random.Range (0, a.Length));
	}
}
