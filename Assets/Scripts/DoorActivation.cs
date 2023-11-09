using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActivation : MonoBehaviour
{
    public GameObject Door;
    private int waveCount;
    private int maxWaves = 6;

    void Start()
    {
        waveCount = 0;
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
            Door.SetActive(false);
        }
        return 0;


    }
}
