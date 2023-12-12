using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public int minBossHP = 0;
    public int maxBossHP = 100;

    public DoorActivation openDoor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Projectile"))
        {
            maxBossHP = maxBossHP - 10;
            Destroy(other.gameObject);

            if (minBossHP >= maxBossHP)
            {
                Destroy(gameObject);
                openDoor.DoorOpen();
            }
        }
    }
}
