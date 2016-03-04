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

    // This is just to set it one y position above the grid where it can spawn again.
    public int AboveGrid = 5;

    // the gameobject that will be used to be considered as gem
    public Object gem;

    // get the last gem selected by player
    public Gems last;

    // allow for swapping by switching the vectors of both objects
    private Vector3 firstGemSourcePosition;
    private Vector3 neighborGemSourcePosition;

    private bool canSwap =  true;

    // the number of matches need to trigger an actual match.
    private int minimumMatchRequirement = 3;

    private bool matchFound = false, matchPossible = false;

    private Gems g1, g2;

    // stores the enum values necessary to pass matched type into defender.
    public ElementType t;

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
                GameObject g = Instantiate(gem, new Vector2(i,z), Quaternion.identity) as GameObject;
                // sets each cloned gem's parent as BoardManager
                // Logic: gameObject = this = BoardManager.
                //g.transform.parent = gameObject.transform;
                g.transform.SetParent(gameObject.transform, false);
                gList.Add(g.GetComponent<Gems>());
            }
        }

        // transforms position to center. (We're gonna have to think of a way to scale this to mobile later...)
        //gameObject.transform.localPosition = new Vector3(30f, 30f, 0);
        gameObject.transform.localScale = new Vector3(5f, 5f, 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(matchPossible == true)
        {
            // call match check here and allow the game to look for potential matches 
            matchCheck();
        }

        if (matchFound)
        {
            for(int i = 0; i < gList.Count; i++)
            {
                if(gList[i].isMatched == true)
                {
                    // just set the type as the gem type
                    t = gList[i].typ;

                    // Reposition the matched units and then change their type and color to allow for randomization
                    gList[i].typ = GameManager.GetRandomType();
                    gList[i].SetColor();
                    gList[i].transform.position = new Vector3(gList[i].transform.position.x, gList[i].transform.position.y + AboveGrid, gList[i].transform.position.z);
                    gList[i].GetComponent<Rigidbody2D>().gravityScale = 1;
                    gList[i].GetComponent<Rigidbody2D>().isKinematic = false;

                }
                //gList[i].GetComponent<Rigidbody>().useGravity = false;
                //gList[i].GetComponent<Rigidbody>().isKinematic = true;
            }
            Debug.Log(t);

            matchFound = false;
        }
	}


    // checks if the actual objects had a match and then deals with the trigger
    public void matchCheck()
    {
        // create two lists to iterate through and check for matches. 
        List<Gems> matchList1 = new List<Gems>();
        List<Gems> matchList2 = new List<Gems>();

        // call Matchlist in order to create a list of matched objects
        matchList(g1.typ, g1, g1.XPos, g1.YPos, ref matchList1);
        // seperate into row and column matches
        rowColumnMatchCheck(g1, matchList1);
        
        matchList(g2.typ, g2, g2.XPos, g2.YPos, ref matchList2);
        rowColumnMatchCheck(g2, matchList2);

        // print("Gem1 = " + matchList1.Count);
    }

    // does the same thing, checking for matches except for the entire board
    public void checkNearbyMatches(Gems g)
    {
        List<Gems> match = new List<Gems>();
        matchList(g.typ, g, g.XPos, g.YPos, ref match);
        rowColumnMatchCheck(g , match);
    }

    // recursive function meant to find max match
    public void matchList(ElementType gemType, Gems g, int XPos, int YPos, ref List<Gems> list)
    {
        // if there are any inconsistancies, return
        if (g == null) { return; }
        else if (g.typ != gemType) { return; }
        else if (list.Contains(g)) { return; }
        // otherwise recursively call matchList and add to list
        else
        {
            list.Add(g);
            if (XPos == g.XPos || YPos == g.YPos)
            {
                foreach (Gems germs in g.neighborGems)
                {
                    matchList(gemType, germs, XPos, YPos, ref list);
                }
            }
        }
    }

    /// <summary>
    /// Takes gem and a list that needs to be fixed.
    /// Cycles through their x and y, seperating them into rows and columns
    /// Then if a match is detected over the minimum Match Requirement, then return true
    /// </summary>
    /// <param name="g"></param>
    /// <param name="toFix"></param>
    public void rowColumnMatchCheck(Gems g, List<Gems>toFix)
    {
        List<Gems> row = new List<Gems>();
        List<Gems> column = new List<Gems>();

        for(int i = 0; i < toFix.Count; i++)
        {
            if(g.XPos == toFix[i].XPos)
            {
                row.Add(toFix[i]);
            }
            if (g.YPos == toFix[i].YPos)
            {
                column.Add(toFix[i]);
            }
        }
        if(row.Count >= minimumMatchRequirement)
        {
            matchFound = true;

            for(int i = 0; i < row.Count; i++)
            {
                row[i].isMatched = true;
            }
        }
        else if(column.Count >= minimumMatchRequirement)
        {
            matchFound = true;

            for (int i = 0; i < column.Count; i++)
            {
                column[i].isMatched = true;
            }
        }
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
                g1 = last;
                g2 = source;
                // the first gem's source position is the last gem selected's position
                firstGemSourcePosition = last.transform.position;
                neighborGemSourcePosition = source.transform.position;

                // the transform is swapped
                last.transform.position = neighborGemSourcePosition;
                source.transform.position = firstGemSourcePosition;

                source.toggleSelection();
                last.toggleSelection();

                // for swap control
                canSwap = false;

                last = null;

                matchPossible = true;
            }
            else
            {
                last = source;
                //last.toggleSelection();

                canSwap = true;
            }
        }
    }

    // Return a matched type to add to defense bar. 
    /*
    public EnemyType returnMatchedType(EnemyType typ)
    {
        t = typ;
        return t;
    }
    */
}
