using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    public GameManager gameManager;
    private Animator animPlayer;

    void Start()
    {
        animPlayer = GetComponent<Animator>();
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Obstacle") && other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            gameManager.GameOver();
        }

    }

    public void playanim()
    {
        animPlayer.SetBool("isTrigger", true);
    }

}

