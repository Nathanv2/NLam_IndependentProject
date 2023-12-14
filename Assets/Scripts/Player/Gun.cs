using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject Projectile;
    private float rotationSpeed = 150.0f; // Adjust the rotation speed
    private float shootDelay = 0.5f; // Adjust the delay between shots
    public AudioClip laserSound;

    private bool canShoot = true;
    private bool startShooting = false;

    public void StartGame()
    {
        startShooting=true;
    }

    void Update()
    {
        if (startShooting)
        {
            RotateGunWithKeys();

            if (Input.GetKeyDown(KeyCode.Space) && canShoot)
            {
                // Instantiate the projectile with the gun's rotation
                Instantiate(Projectile, transform.position, transform.rotation);

                GetComponent<AudioSource>().PlayOneShot(laserSound, 1.0f);

                // Start the delay before allowing the next shot
                StartCoroutine(ShootDelay());
            }
        }
    }

    void RotateGunWithKeys()
    {
        // Rotate gun left with E key
        if (Input.GetKey(KeyCode.E))
        {
            transform.RotateAround(transform.parent.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }

        // Rotate gun right with Q key
        if (Input.GetKey(KeyCode.Q))
        {
            transform.RotateAround(transform.parent.position, Vector3.up, -rotationSpeed * Time.deltaTime);
        }
    }

    IEnumerator ShootDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }
}
