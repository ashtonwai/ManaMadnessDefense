using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Wall : MonoBehaviour {
	private int maxHealth = 2;
	public int health = 2;
	public ElementType element;

	private Image image;
	private GameObject lastCollided; // Used to detect for collisions with other GameObjects only once

	// Use this for initialization
	void Start () {
		image = GetComponent<Image>();

		// set material color based upon enum type
		image.color = GameManager.elementColor[(int)element];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		// Check for collision with Enemy
		if (other.GetComponent<Enemy>() && other.gameObject != lastCollided) {
			// If strong against the opposing element, take only half damage
			if (GameManager.elementStrength[(int)element] == other.GetComponent<Enemy>().element) {
				health--;
			} else {
				health -= 2;
			}

			// If damaged, become opaque
			if (health > 0) {
				image.color = new Color (image.color.r, image.color.g, image.color.b, (float)health / maxHealth);
			} else {
				Destroy(gameObject);
			}
		}

		lastCollided = other.gameObject;
	}
}
