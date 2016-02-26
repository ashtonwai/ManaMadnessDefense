using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	public int maxHealth = 2;
	public int health = 2;
	public ElementType element = ElementType.Red;

	public Color color;
	private Color otherColor;

	// Use this for initialization
	void Start () {
		color = this.GetComponent<Renderer>().material.color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		// check for the player tag. If it exists, set collision to true and then destroy existing gameobject
		if (other.tag == "Enemy") {

			otherColor = other.GetComponent<Renderer>().material.color;

			if (otherColor == color) {
				health -= 2;
			} else {
				health--;
			}

			if (health > 0) {
				this.GetComponent<Renderer> ().material.color = new Color (color.r, color.g, color.b, (float)health / maxHealth);
			} else {
				Destroy (gameObject);
			}

		}
	}
}
