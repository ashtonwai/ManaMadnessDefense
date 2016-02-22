using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Elements : MonoBehaviour {

	public string element;
	public Button currentButton;
	public Dictionary<Image, float> receivers = new Dictionary<Image, float>();
	private Image toRemove;

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
	}
	
	// Update is called once per frame
	void Update () {
		toRemove = null;
		foreach (KeyValuePair<Image, float> receiver in receivers) {
			if (receiver.Value > 0) {
				receivers[receiver.Key] -= Time.deltaTime;
			}
			else if (receiver.Value <= 0) {
				receiver.Key.GetComponent<Image> ().color = Color.white;
				toRemove = receiver.Key;
			}
		}
		if (toRemove != null) {
			receivers.Remove (toRemove);
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
			receivers.Add(image, timeVisible);
			currentButton.GetComponentInChildren<Text> ().text = fireCount.ToString();
			break;
		case "Water":
			waterCount--;
			image.GetComponent<Image> ().color = Color.blue;
			receivers.Add(image, timeVisible);
			currentButton.GetComponentInChildren<Text> ().text = waterCount.ToString();
			break;
		case "Grass":
			grassCount--;
			image.GetComponent<Image> ().color = Color.green;
			receivers.Add(image, timeVisible);
			currentButton.GetComponentInChildren<Text> ().text = grassCount.ToString();
			break;
		default:
			print ("no element");
			break;
		}

		element = null;
	}
}
