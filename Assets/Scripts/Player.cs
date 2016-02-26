using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    // Health, keeps track of player life. (5 default) 
	public int MaxHealth = 5;
    public int Health = 5;
	public GameObject HealthBar;
	private bool spin = true;

	//public Dictionary<enum, int> receivers = new Dictionary<enum, float>();

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    if (Health <= 0) {
            Destroy(gameObject);
        }

		if (spin) {
			transform.Rotate (Vector3.forward * -5);
		} else {
			float timer = 1;
			timer -= Time.deltaTime;
			if (timer == 0) {
				timer = 0;
				transform.Rotate (Vector3.forward * -5);
				spin = true;
			}
		}
	}

    /// <summary>
    /// Checks for collision between player and the enemy.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemy") {
            Health--;
			HealthBar.transform.localScale = new Vector2(
				(float)Health / MaxHealth, 
				HealthBar.transform.localScale.y
			);

			spin = false;
        }
    }
}
