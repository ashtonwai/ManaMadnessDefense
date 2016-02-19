using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    private Renderer rend;
    public Spawner spawn;
    // for testing purposes. Will not exist in final build.
    //public bool isColliding;

    // get player and the target vector
    private Vector3 target;
    public GameObject player;
    public float speed;
    public EnemyType type;
    

	// Use this for initialization
	void Start () {

		this.transform.GetComponent<Collider>().isTrigger = true;
		//this.transform.localScale = new Vector3 (50, 50, 0.25f);

        player = GameObject.Find("Player");

        // if the player exists, set target
		if (player != null) {
			target = player.transform.position;
		} else {
			Debug.Log (player);
		}

        // just set speed to random for now
        //speed = Random.Range(15.5f, 35.5f);
        speed = Random.Range(1.0f, 3.0f);

        // set the gameobject's tag to enemy for Player detection.
        gameObject.tag = "Enemy";

        // Get the renderer
       rend = GetComponent<Renderer>();

        //isColliding = false;

    }
	
	// Update is called once per frame
	void Update () {
        // Very primitive, meant for testing.
        //transform.Translate(Vector3.down * Time.deltaTime);

        // proper movement towards position
        float move = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, move);
		//Debug.Log (move);

        // if the player no longer exists, destroy the enemies.
        if(player == null)
        {
            Destroy(gameObject);
        }

        // if statements will check the type, and then color the material accordingly.
        if (type == EnemyType.Blue)
        {
            rend.material.SetColor("_Color", Color.blue);
        }
        else if (type == EnemyType.Green)
        {
            rend.material.SetColor("_Color", Color.green);
        }
        else if (type == EnemyType.Red)
        {
            rend.material.SetColor("_Color", Color.red);
        }
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

    public EnemyType setType(EnemyType typ)
    {
        typ = this.type;
        return typ;
    }

}
