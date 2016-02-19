using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Text timerText;
	public float minutes = 2;
	public float seconds = 0;

	// Use this for initialization
	void Start () {
		timerText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (seconds <= 0) {
			seconds = 59;

			if (minutes >= 1) {
				minutes--;
			} else {
				minutes = 0;
				seconds = 0;
				timerText.text = minutes.ToString ("f0") + ":0" + seconds.ToString ("f0");
			}
		} else {
			seconds -= Time.deltaTime;
		}

		if (Mathf.Round (seconds) <= 9) {
			timerText.text = minutes.ToString ("f0") + ":0" + seconds.ToString ("f0");
		} else {
			timerText.text = minutes.ToString ("f0") + ":" + seconds.ToString ("f0");
		}
	}
}
