using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject Projectile;
    // Set the speed of the vehicle
    private float speed = 15.0f;

    // Declares the input variables
    public float horizontalInput;
    private float verticalInput;

    public AudioClip coinSound;
    public AudioClip explosionSound;

    public ParticleSystem Explosion;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Get Inputs to be able to manually control the vehicle
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Allows you to move the vehicle forward with speed
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Projectile, transform.position, Projectile.transform.rotation);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Player") && other.gameObject.CompareTag("Coin"))
        {
            GetComponent<AudioSource>().PlayOneShot(coinSound, 1.0f);
        }

        if (gameObject.CompareTag("Player") && other.gameObject.CompareTag("Obstacle"))
        {
            GetComponent<AudioSource>().PlayOneShot(explosionSound, 1.0f);
            Explosion.Play();
        }
    }

}
