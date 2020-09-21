using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour{
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;

    // Part of difficulty systems
    public float minTimeBtwSpawn; 
    public float decreaseRate;

    public Transform[] spawnPoints;
    public GameObject[] asteroids;

    // Update is called once per frame
    void Update(){
        if (timeBtwSpawns > 0) {
            // Keep reducing time between spawns until it reaches 0
            timeBtwSpawns -= Time.deltaTime;
            return;
        }

        // Generating random spawn point and asteroid
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject randomAsteroid = asteroids[Random.Range(0, asteroids.Length)];

        // Instantiate a random asteroid
        Instantiate(randomAsteroid, randomSpawnPoint.position, Quaternion.identity);

        // Increases difficulty over time
        if (startTimeBtwSpawns > minTimeBtwSpawn) {
            startTimeBtwSpawns -= decreaseRate;
        }

        // Resets the timer
        timeBtwSpawns = startTimeBtwSpawns;
    }
}
