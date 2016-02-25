using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Sung Choi
// This class is meant to handle the gem's behaviors. 
public class Gems : MonoBehaviour
{
    // the gemType is determined by the EnemyType enum
    public EnemyType typ;

    // list to contain neighboring gems. 
    public List<Gems> neighborGems = new List<Gems>();

    // Renderer for the material
    private Renderer[] rend;

    // Use this for initialization
    void Start()
    {
        // this receives all of the renderers of this object's children
        rend = transform.GetComponentsInChildren<Renderer>();

        // Get the renderer
        typ = GetRandomType();

        // set each child's renderer to change colors depending on type.
        foreach (Renderer r in rend)
        {
            // if statements will check the type, and then color the material accordingly.
            if (typ == EnemyType.Blue)
            {
                r.material.SetColor("_Color", Color.blue);
            }
            else if (typ == EnemyType.Green)
            {
                r.material.SetColor("_Color", Color.green);
            }
            else if (typ == EnemyType.Red)
            {
                r.material.SetColor("_Color", Color.red);
            }
        }
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

    // adds the neighbors into the list.
    public void AddToList(Gems g)
    {
        neighborGems.Add(g);
    }
    public void RemoveFromList(Gems g)
    {
        neighborGems.Remove(g);
    }

    /// <summary>
    ///  // Gets a random enum by using the values existing within the enum
    /// </summary>
    /// <returns></returns>
    public EnemyType GetRandomType()
    {
        // create an array that holds the values of each EnemyType
        System.Array a = System.Enum.GetValues(typeof(EnemyType));
        // cycle through the array and then return a random enum type
        EnemyType newEnemy = (EnemyType)a.GetValue(Random.Range(0, a.Length));
        return newEnemy;
    }
}
