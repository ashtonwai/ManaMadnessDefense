using UnityEngine;
using System.Collections;

// build the enum to determine type of enemy
public enum EnemyType
{
    Red = 1,
    Green = 2,
    Blue = 3
};


public class Spawner : MonoBehaviour
{
    public EnemyType type;
    private GameObject enemy;
    private GameObject player;
    private Renderer rend;
    // Use this for initialization
    void Start ()
    {
        // Get the renderer
        rend = GetComponent<Renderer>();

        // Find the player in the scene, and then apply to (GameObject) player. 
        player = GameObject.Find("Player");

        // set an initial type for (EnemyType) type;
        type = GetRandomType();

        // Start a coroutine method that will change the enemytype every few seconds.
        StartCoroutine(CoroutineMethod());

        // if type isn't empty
        if (type != 0)
        {
            // spawn an enemy and then repeat it every few seconds.
            InvokeRepeating("spawnEnemy", 5, 10);
        }
    }
    void Update ()
    {

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
    /// Self explanatory, but what it basically does is spawn an enemy as a prefab and then put it in the position of the spawner. 
    /// </summary>
    void spawnEnemy()
    {
		Debug.Log ("Enemy spawned");
		if(player != null)
        {
            enemy = (GameObject)Instantiate(Resources.Load("Enemy"), gameObject.transform.position, Quaternion.identity) as GameObject;
            //enemy.GetComponent<Enemy>().setType(type);

            enemy.GetComponent<Enemy>().type = this.type;
        }
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

    // Wait a few seconds and then set new type.
    IEnumerator CoroutineMethod()
    {
        while(player != null)
        {
            // wait a few seconds before executing
            yield return new WaitForSeconds(10);
            type = GetRandomType();
        }
    }
}
