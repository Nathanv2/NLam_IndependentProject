using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Door;

    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI healthText;

    private int coin = 0;
    private int health = 100;

    private bool isCrashed = false;

    private void Start()
    {
        coinsText.gameObject.SetActive(true);
        coinsText.text = "Coins: " + coin;

        healthText.gameObject.SetActive(true);
        healthText.text = "Health: " + health;
    }

    public void Victory()
    {
        Time.timeScale = 0;
        Debug.Log("Ok");
        winText.gameObject.SetActive(true);
    }


    public void GameOver()
    {
        isCrashed = true;

        if (isCrashed == true)
        {
            Time.timeScale = 0;
            gameOverText.gameObject.SetActive(true);
        }
    }

    public void UpdateCoins()
    {
        coin = coin + 1;
        coinsText.text = "Coins: " + coin;
    }

}
