using UnityEngine;
using System.Collections;

enum EnemyType { Red = 1,Green = 2,Blue = 3};

public class Enemy : MonoBehaviour {
    // for testing purposes. Will not exist in final build.
    //public bool isColliding;

    // get player and the target vector
    private Vector3 target;
    public GameObject player;
    public float speed;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        target = player.transform.position;

        // just set speed to random for now
        speed = Random.Range(1.0f, 3.0f);

        // set the gameobject's tag to enemy for Player detection.
        gameObject.tag = "Enemy";

        // Get the renderer
        Renderer rend = GetComponent<Renderer>();

        //isColliding = false;

        // Get a random enum from the function
        //EnemyType type = (EnemyType)Random.Range(1, 4);
        EnemyType type = GetRandomType();

        // if statements will check the type, and then color the material accordingly.
        if(type == EnemyType.Blue)
        {
            rend.material.SetColor("_Color", Color.blue);
        }
        else if(type == EnemyType.Green)
        {
            rend.material.SetColor("_Color", Color.green);
        }
        else if(type == EnemyType.Red)
        {
            rend.material.SetColor("_Color", Color.red);
        }
}
	
	// Update is called once per frame
	void Update () {
        // Very primitive, meant for testing.
        //transform.Translate(Vector3.down * Time.deltaTime);

        // proper movement towards position
        float move = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, move);
    }

    /// <summary>
    /// When sphere collider triggers, check if the collided object is a player.
    /// If so, destroy current gameObject.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        // check for the player tag. If it exists, set collision to true and then destroy existing gameobject
        if(other.tag == "Player")
        {
            
            //isColliding = true;
            Destroy(gameObject);

        }
    }

    /// <summary>
    ///  // Gets a random enum by using the values existing within the enum
    /// </summary>
    /// <returns></returns>
    static EnemyType GetRandomType()
    {
        // create an array that holds the values of each EnemyType
        System.Array a = System.Enum.GetValues(typeof(EnemyType));
        // cycle through the array and then return a random enum type
        EnemyType newEnemy = (EnemyType)a.GetValue(Random.Range(0, a.Length));
        return newEnemy;
    }
}
