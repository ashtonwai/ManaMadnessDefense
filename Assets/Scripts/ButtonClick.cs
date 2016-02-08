using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour {

	public string element;
	public Button currentButton;

	public Button fireElement;
	public Button waterElement;
	public Button grassElement;

	public int fireCount = 10;
	public int waterCount = 10;
	public int grassCount = 10;

	// Use this for initialization
	void Start () {
		fireElement.GetComponentInChildren<Text> ().text = "Fire " + fireCount;
		waterElement.GetComponentInChildren<Text> ().text = "Water " + waterCount;
		grassElement.GetComponentInChildren<Text> ().text = "Grass " + grassCount;
	}

	// Update is called once per frame
	void Update () {

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
			currentButton.GetComponentInChildren<Text> ().text = element + " " + fireCount;
			break;
		case "Water":
			waterCount--;
			image.GetComponent<Image> ().color = Color.blue;
			currentButton.GetComponentInChildren<Text> ().text = element + " " + waterCount;
			break;
		case "Grass":
			grassCount--;
			image.GetComponent<Image> ().color = Color.green;
			currentButton.GetComponentInChildren<Text> ().text = element + " " + grassCount;
			break;
		default:
			print ("no element");
			break;
		}

		element = null;
	}
}
