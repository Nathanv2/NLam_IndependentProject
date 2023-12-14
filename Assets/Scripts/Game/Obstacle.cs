using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public GameManager gameManager;
    private Animator animPlayer;
    public PlayerController playerController;

    void Start()
    {
        animPlayer = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Obstacle") && other.gameObject.CompareTag("Player"))
        {
            playerController.CollideObstacle();
            Destroy(gameObject);
        }

    }

    public void playanim()
    {
        animPlayer.SetBool("isTrigger", true);
    }

}

