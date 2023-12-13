using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyedMobs : MonoBehaviour
{
    public GameManager gameManager;
    public Renderer rend;
    public ParticleSystem Explosion;
    private float destroyEnemy = 95.0f;
    public float speed = 4.0f; // Adjust the speed of enemy movement

    void Update()
    {
        if (transform.position.y < destroyEnemy)
        {
            Destroy(gameObject);
        }

        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
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
