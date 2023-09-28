using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyedMobs : MonoBehaviour
{
    public GameManager gameManager;
    
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Enemy") && other.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            gameManager = FindObjectOfType<GameManager>();
            gameManager.AmountDestroyed();
            
        }
    }
}
