using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Door;
    private int MobsDestroyed = 0;

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
        Debug.Log("MobsDestroyed: " + MobsDestroyed);

        if (MobsDestroyed < 10)
        {
            Door.SetActive(true);
        }
        else
        {
            Door.SetActive(false);
        }
    }
}
