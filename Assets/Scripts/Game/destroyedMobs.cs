using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyedMobs : MonoBehaviour
{
    public GameManager gameManager;
    public Renderer rend;
    public ParticleSystem Explosion;

    private float destroyEnemy = 95.0f;
    private float speed = 5.0f; // Adjust the speed of enemy movement

    void Update()
    {
        // If the Enemy goes below the boundary then it will be destroyed.
        if (transform.position.y < destroyEnemy)
        {
            Destroy(gameObject);
        }

        // Updates Method that allows the enemies to move toward the player automatically
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        GameObject player = GameObject.FindWithTag("Player");

        Vector3 direction = (player.transform.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        // If Enemy collides with Projectile then it will play a particle effect
        if (gameObject.CompareTag("Enemy") && other.CompareTag("Projectile"))
        {
            rend = GetComponent<MeshRenderer>();
            rend.enabled = false;
            GetComponent<Collider>().enabled = false;
            GetComponent<Rigidbody>().useGravity = true;
            gameManager = FindObjectOfType<GameManager>();
            Explosion.Play();
        }
    }

}
