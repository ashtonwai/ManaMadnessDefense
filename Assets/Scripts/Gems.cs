using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

// Sung Choi
// This class is meant to handle the gem's behaviors. 
public class Gems : MonoBehaviour
{

    // returns the local position x and y of transform 
    public int XPos
    {
        get { return Mathf.RoundToInt(transform.localPosition.x); }
    }

    public int YPos
    {
        get { return Mathf.RoundToInt(transform.localPosition.y); }
    }

    // the gemType is determined by the EnemyType enum
    public ElementType typ;

    // list to contain neighboring gems. 
    public List<Gems> neighborGems = new List<Gems>();

    // to check whether or not this particular instance is selected.
    private bool isSelected = false;

    // Determine whether match is made
    public bool isMatched = false;

    // call boardManager object
    private Board boardManager;

    // for the rendering
    private Image[] image;

    // Use this for initialization
    void Start()
    {
        // Get the renderer
        image = transform.GetComponentsInChildren<Image>();

        // get the boardmanager script through script
        boardManager = GameObject.Find("BoardManager").GetComponent<Board>();

        // Get the renderer
        typ = GameManager.GetRandomType();

        // set each child's renderer to change colors depending on type.
        foreach (Image i in image)
        {
            i.color = GameManager.elementColor[(int)typ];
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
    // adds the neighbors into the list.
    public void AddToList(Gems g)
    {
        if(!neighborGems.Contains(g))
        {
            neighborGems.Add(g);
        }
    }
    // removes the neighbors in the list
    public void RemoveFromList(Gems g)
    {
        neighborGems.Remove(g);
    }

    /// <summary>
    /// A boolean method meant to figure out whether the gem selected is a neighbor.
    /// </summary>
    /// <param name="g"></param>
    /// <returns></returns>
    public bool NeighboredGem(Gems g)
    {
        // if the neighbors contains this particular gem, then return true.
        if (neighborGems.Contains(g))
        {
            return true;
        }
        return false;
    }

    public void toggleSelection()
    {
        // Negate it
        isSelected = !isSelected;

        // if selected is true, then give the player proper feedback and let them know that they successfully selected it.
        if(isSelected == true)
        {
            //gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 0);
            
        }
        else
        {
            //gameObject.transform.localScale += new Vector3(-0.2f, -0.2f, 0);
        }
    }

    // toggles the click
    void OnMouseDown()
    {
        // test click (Works!)
        // toggleSelection();

        // call the boardManager's swapgem function
        // This allows the instance to toggle and check for neighbors at the same time. 
        //Debug.Log("Success");
        toggleSelection();
        boardManager.SwapGems(this);

    }


    /// <summary>
    ///  // Gets a random enum by using the values existing within the enum
    /// </summary>
    /// <returns></returns>
    /*
    public ElementType GetRandomType()
    {
        // create an array that holds the values of each EnemyType
        System.Array a = System.Enum.GetValues(typeof(ElementType));
        // cycle through the array and then return a random enum type
        ElementType newEnemy = (ElementType)a.GetValue(Random.Range(0, a.Length));
        isMatched = false;
        return newEnemy;
    }
    */

    public void SetColor()
    {
        // set each child's renderer to change colors depending on type.
        foreach (Image i in image)
        {
            i.color = GameManager.elementColor[(int)typ];
        }
    }
    /*
    public void SetColor()
    {
        // set each child's renderer to change colors depending on type.
        foreach (Renderer r in rend)
        {
            // if statements will check the type, and then color the material accordingly.
            if (typ == ElementType.Blue)
            {
                r.material.SetColor("_Color", Color.blue);
            }
            else if (typ == ElementType.Green)
            {
                r.material.SetColor("_Color", Color.green);
            }
            else if (typ == ElementType.Red)
            {
                r.material.SetColor("_Color", Color.red);
            }
        }
    }
    */
}
