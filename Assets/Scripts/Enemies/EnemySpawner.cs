using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    private GameObject[] enemy1Spawners;
    private GameObject[] enemy2Spawners;
    private GameObject[] enemy3Spawners;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    // Use this for initialization
    void Start () {
        FindSpawners();
        SpawnEnemies();
        Destroy(this.gameObject,0.3f);
    }

    //Locates all enemy spawners in the level
    void FindSpawners()
    {
        enemy1Spawners = GameObject.FindGameObjectsWithTag("Spawn1");
        enemy2Spawners = GameObject.FindGameObjectsWithTag("Spawn2");
        enemy3Spawners = GameObject.FindGameObjectsWithTag("Spawn3");
    }

    void SpawnEnemies()
    {
        //Spawns all enemy1 in the proper location
        if (enemy1 != null)
        {
            for(int i = 0; i < enemy1Spawners.Length; i++)
            {
                Instantiate(enemy1, enemy1Spawners[i].transform.position, enemy1Spawners[i].transform.rotation);
            }
        }

        //Spawns all enemy2 in the proper location
        if (enemy2 != null)
        {
            for (int i = 0; i < enemy2Spawners.Length; i++)
            {
                Instantiate(enemy2, enemy2Spawners[i].transform.position, enemy2Spawners[i].transform.rotation);
            }
        }

        //Spawns all enemy3 in the proper location
        if (enemy3 != null)
        {
            for (int i = 0; i < enemy3Spawners.Length; i++)
            {
                Instantiate(enemy3, enemy3Spawners[i].transform.position, enemy3Spawners[i].transform.rotation);
            }
        }
    }

	
	// Update is called once per frame
	void Update () {
	
	}
}
