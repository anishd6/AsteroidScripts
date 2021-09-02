using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{

    public GameObject[] asteroids;
    public GameObject[] spawnPositions;
    public float spawnRate;
    private float NextSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        {
            if (NextSpawn > 0)
                NextSpawn -= Time.deltaTime;
            if (NextSpawn<=0)
                Spawn();
        }
        
    }


    private void Spawn()
    {
        NextSpawn = spawnRate;
        Vector2 position = spawnPositions[Random.Range(0, spawnPositions.Length)].transform.position; //get random GameObj from array then taking its position coords, using .legnth to give us total spots which are taken from my gameobjs
        //this means we  can select a random "spot" and then input a spawn location with some variety
        GameObject asteroidClone = Instantiate(asteroids[Random.Range(0, asteroids.Length)], new Vector2(position.x, position.y), transform.rotation);
        //^ Making a clone var       ^ Instansiate the new clone    ^ using the random asteroids array ^ selecting the position based of GO created, ^ then using its rotation 
        asteroidClone.SetActive(true);

    }
}
