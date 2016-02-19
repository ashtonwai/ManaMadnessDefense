using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Sung Choi
// This class is meant to handle the gem's behaviors. 
public class Gems : MonoBehaviour
{
    // list to contain neighboring gems. 
    public List<Gems> neighborGems = new List<Gems>();

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnMouseDown()
    {
        // test click (Works!)
        //Debug.Log("Success!");
        
    }
}
