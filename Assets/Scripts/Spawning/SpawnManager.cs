using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Enemies;
    public GameObject Booster;
    public GameObject coinPrefab;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI clearedWavesText;

    public float spawnInterval = 3.0f;
    private float spawnYPosition = 101.0f;
    private Vector2 spawnArea = new Vector2(476.0f, 525.0f);
    private Vector2 spawnAreaZ = new Vector2(490.0f, 550.0f);
    private Vector2 spawnArea2 = new Vector2(410f, 580);
    private Vector2 spawnAreaZ2 = new Vector2(660f, 760f);

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
        waveText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<destroyedMobs>().Length;
        if (enemyCount == 0 && waveNumber != maxWaves)
        {
            waveNumber++;
            SpawnWave(waveNumber);
            waveText.text = "Wave: " + waveNumber;
            doorActivation.AmountOfWaves();
        }

        if (waveNumber == maxWaves)
        {
            waveText.gameObject.SetActive(false);
            clearedWavesText.gameObject.SetActive(true);
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

    public void SpawnEnemies(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            int enemiesIndex = Random.Range(0, Enemies.Length);
            Instantiate(Enemies[enemiesIndex], SpawnPosition2(), Enemies[enemiesIndex].transform.rotation);
            Debug.Log("Working");
        }
    }

    public void SpawnCoins(int numberOfCoins)
    {
        for (int i = 0; i < numberOfCoins; i++)
        {
            Instantiate(coinPrefab, SpawnPosition2(), coinPrefab.transform.rotation);
            Debug.Log("Working");
        }
    }

    public Vector3 SpawnPosition2()
    {
        float randomXPosition2 = Random.Range(spawnArea2.x, spawnArea2.y);
        float randomZPosition2 = Random.Range(spawnAreaZ2.x, spawnAreaZ2.y);
        Vector3 spawnPosition2 = new Vector3(randomXPosition2, spawnYPosition, randomZPosition2);
        return spawnPosition2;
    }
}
