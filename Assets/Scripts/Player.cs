using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    // Health, keeps track of player life. (5 default) 
	private int maxHealth = 5;
    public int health = 5;
	public GameObject healthBar;

	private ButtonClick canvas;
	private GameObject lastCollided; // Used to detect for collisions with other GameObjects only once

	// Use this for initialization
	void Start () {
		canvas = GameObject.Find("Canvas").GetComponent<ButtonClick>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (health <= 0) {
            Destroy(gameObject);
        }
	}

    /// <summary>
    /// Checks for collision between player and the enemy.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
		if(other.gameObject.GetComponent<Enemy>() && other.gameObject != lastCollided) {
            health--;
			healthBar.transform.localScale = new Vector3(
				(float)health / maxHealth, 
				healthBar.transform.localScale.y, 
				healthBar.transform.localScale.z
			);
        }

		lastCollided = other.gameObject;
    }
}
