using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{

    public PlayerController playerController;

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Coin") && other.gameObject.CompareTag("Player"))
        {
            // Finds the PlayerController on the player GameObject
            playerController = other.gameObject.GetComponent<PlayerController>();

            playerController.ActivateCoin();
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
