using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{

    public int minBossHP = 0;
    public int maxBossHP = 100;

    public TextMeshProUGUI bossHealthText;

    public DoorActivation openDoor;

    // Start is called before the first frame update
    void Start()
    {
        bossHealthText.gameObject.SetActive(true);
        bossHealthText.text = "BossHealth: " + maxBossHP;
        UpdateBossHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Projectile"))
        {
            maxBossHP = maxBossHP - 10;
            Destroy(other.gameObject);
            UpdateBossHealth();

            if (minBossHP >= maxBossHP)
            {
                Destroy(gameObject);
                openDoor.DoorOpen();
            }
        }
    }

    public void UpdateBossHealth()
    {
        bossHealthText.text = "Boss Health: " + maxBossHP;
    }
}
