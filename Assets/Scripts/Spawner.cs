using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    private GameObject enemy;
    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        spawnEnemy();
        InvokeRepeating("spawnEnemy", 10, 10);
    }

    void spawnEnemy() {
		//Debug.Log ("Enemy spawned");

		if (player != null) {
            enemy = (GameObject)Instantiate(Resources.Load("Enemy"), gameObject.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.SetParent (GameObject.Find("SpaceGame").transform);
        }
    }
}
