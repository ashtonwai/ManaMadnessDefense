using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DefenseContainer : MonoBehaviour {

	public GameObject receiver;

	private Color currentColor;
	private Color previousColor;

	private List<GameObject> walls = new List<GameObject>();

	// Use this for initialization
	void Start () {
		currentColor = receiver.GetComponent<Image> ().color;
	}
	
	// Update is called once per frame
	void Update () {
		currentColor = receiver.GetComponent<Image> ().color;

		if (currentColor != Color.white && previousColor != currentColor) {
			Debug.Log ("Wall");

			// Spawn Wall
			walls.Add((GameObject)Instantiate(Resources.Load("Wall"), gameObject.transform.position, Quaternion.identity) as GameObject);

			// Set Child
			walls[walls.Count - 1].transform.parent = this.gameObject.transform;

			// Set rotation
			walls[walls.Count - 1].transform.localRotation = Quaternion.identity;
			walls[walls.Count - 1].transform.localPosition = new Vector3 (
				walls[walls.Count - 1].transform.localPosition.x,
				walls[walls.Count - 1].transform.localPosition.y + (15 * walls.Count),
				walls[walls.Count - 1].transform.localPosition.z
			);

			// Set Type
			walls[walls.Count - 1].GetComponent<Renderer>().material.color = currentColor;

			/*
			if (currentColor == Color.red) {
				
			} else if (currentColor == Color.blue) {
			
			} else if (currentColor == Color.green) {
				
			}*/
		}

		previousColor = currentColor;
	}
}
