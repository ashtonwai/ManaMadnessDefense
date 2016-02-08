using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    // Health, keeps track of player life. (5 default) 
    public int Health = 5;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    if (Health <= 0)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Health--;
        }
    }
}
