using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActivation : MonoBehaviour
{
    public GameObject Door;
    public GameObject finalDoor;
    private int waveCount;
    private int maxWaves = 6;

    private Animator animPlayer;

    void Start()
    {
        waveCount = 0;
        animPlayer = GetComponent<Animator>();
    }

    void Update()
    {

    }

    public int AmountOfWaves()
    {
        waveCount++;

        if (waveCount < maxWaves)
        {
            Door.SetActive(true);
        }
        else
        {
            animPlayer.SetBool("isTrigger", true);
        }
        return 0;

    }

    public void DoorOpen()
    {
        finalDoor.SetActive(false);
    }
}
