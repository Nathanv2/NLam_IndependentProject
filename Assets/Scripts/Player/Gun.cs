using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject Projectile;
    public float rotationSpeed = 2000.0f; // Adjust the rotation speed

    void Update()
    {
        RotateGunWithKeys();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Instantiate the projectile with the gun's rotation
            Instantiate(Projectile, transform.position, transform.rotation);
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
}
