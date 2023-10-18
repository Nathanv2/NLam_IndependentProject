using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter(Collider other)
    {
        if(gameObject.CompareTag("Obstacle") && other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            gameManager.GameOver();
        }
    }
}
