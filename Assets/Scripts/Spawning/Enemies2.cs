using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies2 : MonoBehaviour
{
    public SpawnManager spawnManager;
    public Boss bossScript;

    private int Once = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Once <= 0)
        {
            spawnManager.SpawnEnemies(50);
            spawnManager.SpawnCoins(15);
            Once = Once + 1;
            bossScript.BossHealthTextVisibility();
        }
        else if (other.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
        }

    }
}
