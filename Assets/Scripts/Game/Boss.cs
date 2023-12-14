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

    public GameObject bossHealthBackground;
    public Image bossHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BossHealthTextVisibility()
    {
        bossHealthText.gameObject.SetActive(true);
        bossHealthText.text = "BossHealth: " + maxBossHP;
        UpdateBossHealth();
        bossHealthBar.gameObject.SetActive(true);
        bossHealthBackground.gameObject.SetActive(true);
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
                bossHealthText.gameObject.SetActive(false);
                bossHealthBar.gameObject.SetActive(false);
                bossHealthBackground.gameObject.SetActive(false);
            }
        }
    }

    public void UpdateBossHealth()
    {
        float normalizedHealth = (float)maxBossHP / 100f;  // Normalize health to a value between 0 and 1
        bossHealthBar.fillAmount = normalizedHealth;
        bossHealthText.text = "Boss: " + maxBossHP;
    }
}
