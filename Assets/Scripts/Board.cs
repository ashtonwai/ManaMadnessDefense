using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Sung Choi
// This class is meant to handle the creation of a board using gameobjects.
// NOTE: I will call all objects to be matched, "Gems", for the sake of sanity until we figure out anything else we want to call it. 

public class Board : MonoBehaviour
{
    // create a list of gameobjects holding gems
    public List<GameObject> gList = new List<GameObject>();

    // self explanatory, but how large we want the grid. (5x5 seems to be our sweet spot, so I'll set it to our default)
    public int gridWidth = 5;
    public int gridHeight = 5;

    // the gameobject that will be used in creating the grid.
    public Object gem;

	// Use this for initialization
	void Start ()
    {
        // iterate through gridheight and gridwidth to create the grid. 
        // for example: if grid height and gridwidth = 5, a group of 25 gameobjects should spawn. 
	    for(int i = 0; i <  gridHeight; i++)
        {
            for(int y = 0; y < gridWidth; y++)
            {
                // create a gameobject, then add it into a list of gems. 
                GameObject g = Instantiate(gem, new Vector3(i,y,0), Quaternion.identity) as GameObject;
                // sets each cloned gem's parent as BoardManager
                // Logic: gameObject = this = BoardManager.
                g.transform.parent = gameObject.transform;
                gList.Add(g);
            }
        }

        // transforms position to center. (We're gonna have to think of a way to scale this to mobile later...)
        gameObject.transform.position = new Vector3(-2.5f, -0.35f, 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
