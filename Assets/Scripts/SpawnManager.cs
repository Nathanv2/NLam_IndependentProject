using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Enemies;
    public float spawnInterval = 3.0f;
    private float spawnArea;
    private float spawnYPosition = 101.0f;
    private float minZPos = 550.0f;
    private float maxZPos = 490.0f;
    private float minXPos = 476.0f;
    private float maxXPos = 525.0f;
    private int maxSpawns = 10;


    private bool spawningEnabled = true;
    private int spawnCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        if(spawningEnabled && spawnCount < maxSpawns)
        {
            float randomXPosition = Random.Range(minXPos, maxXPos);
            float randomZPosition = Random.Range(minZPos, maxZPos);
            Vector3 spawnPosition = new Vector3(randomXPosition, spawnYPosition, randomZPosition);

            int EnemiesIndex = Random.Range(0, Enemies.Length);
            Instantiate (Enemies[EnemiesIndex], spawnPosition, Enemies[EnemiesIndex].transform.rotation);

            spawnCount += 1;
        }
    }
}
