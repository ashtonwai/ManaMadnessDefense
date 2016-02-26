using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    // for testing purposes. Will not exist in final build.
    //public bool isColliding;

    // get player and the target vector
    private Vector3 target;
    private GameObject player;
    
	public float speed;

	private int maxHealth = 2;
	public int health = 2;
	public ElementType element;

	private Renderer rend;
	private GameObject lastCollided; // Used to detect for collisions with other GameObjects only once

	// Use this for initialization
	void Start () {

		player = GameManager.player;
		target = player.transform.position;
        speed = Random.Range(15.5f, 35.5f);

        // set the gameobject's tag to enemy for Player detection.
        gameObject.tag = "Enemy";

        // Get the renderer
        rend = GetComponent<Renderer>();

        // Get a random enum from the function
        //ElementType type = (ElementType)Random.Range(1, 4);
        element = GameManager.GetRandomType();

        // set material color based upon enum type
		rend.material.color = GameManager.elementColor[(int)element];
		rend.material.shader = GameManager.transparentShader;
	}
	
	// Update is called once per frame
	void Update () {

        // proper movement towards position
        transform.position = Vector3.MoveTowards(
			transform.position,		// current position
			target, 				// target position
			speed * Time.deltaTime	// speed
		);
		//Debug.Log (move);

        // if the player no longer exists, destroy the enemies.
        if(player == null)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// When sphere collider triggers, check if the collided object is a player.
    /// If so, destroy current gameObject.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {

        // check for the player tag. If it exists, set collision to true and then destroy existing gameobject
		if (other.gameObject == player) {
            
			Destroy (gameObject);

		} else if (other.GetComponent<Wall>() && other.gameObject != lastCollided) {

			// If strong against the opposing element, take only half damage
			if (GameManager.elementStrength[(int)element] == other.GetComponent<Wall>().element) {
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
