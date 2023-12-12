using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyedMobs : MonoBehaviour
{
    public GameManager gameManager;
    public Renderer rend;
    public ParticleSystem Explosion;
    private float destroyEnemy = 95.0f;
    
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
        //if position is below a certain lvl destroy game object
    }

    void Update()
    {
        if (transform.position.y < destroyEnemy)
        {
            Destroy(gameObject);
        }
    }

}
