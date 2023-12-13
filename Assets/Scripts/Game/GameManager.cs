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

    private bool isCrashed = false;

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

}
