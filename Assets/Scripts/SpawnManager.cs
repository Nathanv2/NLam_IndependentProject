using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Enemies;
    public GameObject Booster;
    public float spawnInterval = 3.0f;
    private float spawnYPosition = 101.0f;
    public Vector2 spawnArea = new Vector2(476.0f, 525.0f);
    public Vector2 spawnAreaZ = new Vector2(490.0f, 550.0f);
    private int maxWaves = 6;
    private int enemyCount;
    private int waveNumber = 0;
    public DoorActivation doorActivation;
    private float totalGameTime = 100.0f;

    private bool spawningEnabled = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaveTimer());
        SpawnBooster();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<destroyedMobs>().Length;
        if (enemyCount == 0 && waveNumber != maxWaves)
        {
            waveNumber++;
            SpawnWave(waveNumber);
            Debug.Log("Wave: " + waveNumber);
            doorActivation.AmountOfWaves();
        }
    }

    private IEnumerator WaveTimer()
    {
        float startTime = Time.time;

        while (waveNumber < maxWaves)
        {
            if (Time.time - startTime >= totalGameTime)
            {
                Debug.Log("Game Over - You didn't complete the waves in time!");
                Time.timeScale = 0;
                yield break;
            }
            yield return null;

        }

        Debug.Log("You completed all the waves within the time limit. You win!");
    }

    void SpawnWave(int enemyNum)
    {
        for (int i = 0; i < enemyNum; i++)
        {
            if(spawningEnabled && waveNumber != maxWaves)
            {
                int EnemiesIndex = Random.Range(0, Enemies.Length);
                Instantiate(Enemies[EnemiesIndex], SpawnPosition(), Enemies[EnemiesIndex].transform.rotation);
            }
        }
    }

    public void SpawnBooster()
    {
        Vector3 randomSpawnPosition = SpawnPosition();
        Instantiate(Booster, randomSpawnPosition, Booster.transform.rotation);
    }

    Vector3 SpawnPosition()
    {
        float randomXPosition = Random.Range(spawnArea.x, spawnArea.y);
        float randomZPosition = Random.Range(spawnAreaZ.x, spawnAreaZ.y);
        Vector3 spawnPosition = new Vector3(randomXPosition, spawnYPosition, randomZPosition);
        return spawnPosition;
    }
}
