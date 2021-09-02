using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawnerV2 : MonoBehaviour
{
    public GameObject[] spawnObjects;  // Array containing powerup objects
    public Transform[] spawnLocations; // Array containing spawn point objects
    public float spawnRate;  // How fast powerups spawn
    private float NextSpawn; // Used to determine when to spawn

    // Start is called before the first frame update
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
            NextSpawn = spawnRate;
            Instantiate(spawnObjects[Random.Range(0, spawnObjects.Length)], spawnLocations[Random.Range(0, spawnLocations.Length)]);
            // Creates copies of random powerups from the first array, then spawns them to random positions from the second array
        }
    }
}
