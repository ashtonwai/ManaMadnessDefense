using UnityEngine;
using System.Collections;

enum EnemyType { Red = 1,Green = 2,Blue = 3};

public class Enemy : MonoBehaviour {
    // for testing purposes. Will not exist in final build.
    public bool isColliding;

	// Use this for initialization
	void Start () {
        isColliding = false;
        EnemyType type = GetRandomEnum();

        if(type == EnemyType.Blue)
        {

        }
}
	
	// Update is called once per frame
	void Update () {
        // Very primitive, meant for testing.
        transform.Translate(Vector3.down * Time.deltaTime);
	}

    // When sphere collider triggers, check if the collided object is a player.
    // If so, delete current gameObject and subtract one health.
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            
            isColliding = true;
            Destroy(gameObject);

        }
    }

    static EnemyType GetRandomEnum()
    {
        System.Array a = System.Enum.GetValues(typeof(EnemyType));
        EnemyType newEnemy = (EnemyType)a.GetValue(Random.Range(0, a.Length));
        return newEnemy;
    }
}
