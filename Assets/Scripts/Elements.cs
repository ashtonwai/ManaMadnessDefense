using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Elements : MonoBehaviour {

	public string element;
	public Button currentButton;
	public Dictionary<GameObject, float> drops = new Dictionary<GameObject, float>();
	public GameObject[] dropObjects;

	public Button fireElement;
	public Button waterElement;
	public Button grassElement;

	public int fireCount = 10;
	public int waterCount = 10;
	public int grassCount = 10;

	public float timeVisible = 0.1f;

	// Use this for initialization
	void Start () {
		fireElement.GetComponentInChildren<Text> ().text = fireCount.ToString();
		waterElement.GetComponentInChildren<Text> ().text = waterCount.ToString();
		grassElement.GetComponentInChildren<Text> ().text = grassCount.ToString();

		dropObjects = GameObject.FindGameObjectsWithTag("Drop");
		//Debug.Log (dropObjects);
		foreach (GameObject drop in dropObjects) {
			drops.Add (drop, 0.0f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i=0; i<dropObjects.Length; i++) {
			if (drops[dropObjects[i]] > 0) {
				drops[dropObjects[i]] -= Time.deltaTime;
			} else {
				drops[dropObjects[i]] = 0.0f;
				dropObjects[i].GetComponent<Image> ().color = Color.white;
			}
		}
	}

	public void onClick(Button button) {
		currentButton = button;
		element = button.name;
	}

	public void setElement(Image image) {
		switch (element) {
		case "Fire":
			fireCount--;
			image.GetComponent<Image> ().color = Color.red;
			drops[image.gameObject] = timeVisible;
			currentButton.GetComponentInChildren<Text> ().text = fireCount.ToString();
			break;
		case "Water":
			waterCount--;
			image.GetComponent<Image> ().color = Color.blue;
			drops[image.gameObject] = timeVisible;
			currentButton.GetComponentInChildren<Text> ().text = waterCount.ToString();
			break;
		case "Grass":
			grassCount--;
			image.GetComponent<Image> ().color = Color.green;
			drops[image.gameObject] = timeVisible;
			currentButton.GetComponentInChildren<Text> ().text = grassCount.ToString();
			break;
		default:
			print ("no element");
			break;
		}

		element = null;
	}
}
