using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

// this is jsut the asteroid spawner script adapted to my enemies
public class EnemySpawner : MonoBehaviour
{
    public GameObject[] Enemies; //using array to hold enemies
    public GameObject[] EnemySpawnLocations;
    public float spawnRate;

    private float NextSpawn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (NextSpawn > 0)
        {
            NextSpawn -= Time.deltaTime;
        }
        if (NextSpawn <= 0)
        {

            Spawn();
        }
    }

    private void Spawn()
    {
        NextSpawn = spawnRate;
        Vector2 position = EnemySpawnLocations[Random.Range(0, EnemySpawnLocations.Length)].transform.position;
        GameObject EnemyClone = Instantiate(Enemies[Random.Range(0, Enemies.Length)], new Vector2(position.x, position.y), transform.rotation);
        //same (instantiate new by randomly raking from my array and using the position ^, and usiong rotation of object
        EnemyClone.SetActive(true);
    }
}
