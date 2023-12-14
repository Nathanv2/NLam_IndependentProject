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
            // Find the PlayerController component on the player GameObject
            playerController = other.gameObject.GetComponent<PlayerController>();

            // Check if the PlayerController component was found
            if (playerController != null)
            {
                playerController.ActivateCoin();
                Destroy(gameObject);
            }
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
