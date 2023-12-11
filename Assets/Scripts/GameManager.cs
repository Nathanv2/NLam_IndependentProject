using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Door;
    private int MobsDestroyed = 0;

    private bool isCrashed = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AmountDestroyed()
    {
        MobsDestroyed += 1;

        if (MobsDestroyed < 10)
        {
            DoorOpen();

        }
        else
        {
            DoorClosed();
        }
    }

    public void DoorOpen()
    {
        Door.SetActive(true);
    }

    public void DoorClosed()
    {
        Door.SetActive(false);
    }

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
