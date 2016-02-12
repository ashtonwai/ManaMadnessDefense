using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
	// Use this for initialization
	void Start ()
    {
        spawnEnemy();
	}
    void spawnEnemy()
    {
        enemy = (GameObject)Instantiate(Resources.Load("Enemy"), gameObject.transform.position, Quaternion.identity) as GameObject;
        InvokeRepeating("spawnEnemy", 10, 10);
    }
}
