using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Door;

    private bool isCrashed = false;

    public void Victory()
    {
        Time.timeScale = 0;
        Debug.Log("Ok");
    }


    public void GameOver()
    {
        isCrashed = true;

        if (isCrashed == true)
        {
            Time.timeScale = 0;
        }
    }

}
