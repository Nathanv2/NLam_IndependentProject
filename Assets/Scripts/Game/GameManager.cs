using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Door;

    public SpawnManager spawnManager;

    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI coinsText;

    private int coin = 0;

    private bool isCrashed = false;

    public void StartGame()
    {
        coinsText.gameObject.SetActive(true);
        coinsText.text = "Coins: " + coin;
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

        spawnManager.WaveTextVisibility();

    }

    public void UpdateCoins()
    {
        coin = coin + 1;
        coinsText.text = "Coins: " + coin;
    }

}
