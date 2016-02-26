using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	private int maxHealth = 2;
	public int health = 2;
	public ElementType element;

	private Renderer rend;
	private GameObject lastCollided; // Used to detect for collisions with other GameObjects only once

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();

		// set material color based upon enum type
		rend.material.color = GameManager.elementColor[(int)element];
		rend.material.shader = GameManager.transparentShader;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
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
				rend.material.color = new Color (rend.material.color.r, rend.material.color.g, rend.material.color.b, (float)health / maxHealth);
			} else {
				Destroy(gameObject);
			}

		}

		lastCollided = other.gameObject;
	}
}
