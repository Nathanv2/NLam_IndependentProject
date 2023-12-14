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
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI controlsText;

    public AudioSource backgroundAudioSource;

    public Button playButton;
    public Button restartButton;
    public Button controlsButton;
    public Button backButton;

    private int coin = 0;

    private bool isCrashed = false;

    public void StartGame()
    {
        coinsText.gameObject.SetActive(true);
        coinsText.text = "Coins: " + coin;
        playButton.gameObject.SetActive(false);
        Time.timeScale = 1;
        titleText.gameObject.SetActive(false);
        controlsText.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
        controlsButton.gameObject.SetActive(false);
        backgroundAudioSource.Play();
    }

    public void Victory()
    {
        Time.timeScale = 0;
        winText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }


    public void GameOver()
    {
        isCrashed = true;

        if (isCrashed == true)
        {
            Time.timeScale = 0;
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            backgroundAudioSource.Stop();
        }

        spawnManager.WaveTextVisibility();

    }

    public void UpdateCoins()
    {
        coin = coin + 1;
        coinsText.text = "Coins: " + coin;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ControlsVisibility()
    {
        controlsText.gameObject.SetActive(true);
        controlsButton.gameObject.SetActive(false);
        playButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(true);
    }

    public void BackVisibility()
    {
        controlsButton.gameObject.SetActive(true);
        playButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(false);
        controlsText.gameObject.SetActive(false);
    }

    public void RestartVisibility()
    {
        restartButton.gameObject.SetActive(true);
    }

    

}
