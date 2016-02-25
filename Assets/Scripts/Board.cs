using UnityEngine;
using System.Collections;
// allows for lists
using System.Collections.Generic;

// Sung Choi
// This class is meant to handle the creation of a board using gameobjects.
// NOTE: I will call all objects to be matched, "Gems", for the sake of sanity until we figure out anything else we want to call it. 

public class Board : MonoBehaviour
{
    // create a list of gameobjects holding gems
    public List<Gems> gList = new List<Gems>();

    // self explanatory, but how large we want the grid. (5x5 seems to be our sweet spot, so I'll set it to our default)
    public int gridWidth = 5;
    public int gridHeight = 5;

    // the gameobject that will be used in creating the grid.
    public Object gem;

    // get the last gem selected by player
    public Gems last;

    // allow for swapping by switching the vectors of both objects
    private Vector3 firstGemSourcePosition;
    private Vector3 neighborGemSourcePosition;

    private bool canSwap =  true;


	// Use this for initialization
	void Start ()
    {
        // iterate through gridheight and gridwidth to create the grid. 
        // for example: if grid height and gridwidth = 5, a group of 25 gameobjects should spawn. 
	    for(int i = 0; i <  gridHeight; i++)
        {
            for(int z = 0; z < gridWidth; z++)
            {
                // create a gameobject, then add it into a list of gems. 
                // Set position using the i : x and z : y. 
                GameObject g = Instantiate(gem, new Vector3(i,z,0), Quaternion.identity) as GameObject;
                // sets each cloned gem's parent as BoardManager
                // Logic: gameObject = this = BoardManager.
                g.transform.parent = gameObject.transform;
                gList.Add(g.GetComponent<Gems>());
            }
        }

        // transforms position to center. (We're gonna have to think of a way to scale this to mobile later...)
        gameObject.transform.position = new Vector3(-2.5f, -0.35f, 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    public void SwapGems(Gems source)
    {
        // if there is no last gem selected, set it to the source
        if(last == null)
        {
            last = source;
        }
        // but, if there is a source, then last gem should be nulled as the player is unselecting it.
        else if(last == source)
        {
            last = null;
        }
        // else, figure out if the gem is neighbor
        else
        {
            // if the last gem is a neighbor of the currently selected gem, then allow the swap
            if (last.NeighboredGem(source) && canSwap)
            {
                // the first gem's source position is the last gem selected's position
                firstGemSourcePosition = last.transform.position;
                neighborGemSourcePosition = source.transform.position;

                // the transform is swapped
                last.transform.position = neighborGemSourcePosition;
                source.transform.position = firstGemSourcePosition;

                source.toggleSelection();
                last.toggleSelection();

                canSwap = false;
            }
            else
            {
                //last.toggleSelection();
                last = source;

                canSwap = true;
            }
        }
    }
}
