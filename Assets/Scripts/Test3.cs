using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test3 : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            Debug.Log("Collision detected with the Door");
            // Assuming you want to trigger an action on the cube, get a reference to the cube and its Test2 component.
            GameObject cube = GameObject.Find("Obstacle"); // Replace "Cube" with the actual name of your cube GameObject.
            if (cube != null)
            {
                Test2 obstacle = cube.GetComponent<Test2>();
                if (obstacle != null)
                {
                    obstacle.playanim();
                }
                else
                {
                    Debug.LogWarning("Test2 component not found on the cube.");
                }
            }
            else
            {
                Debug.LogWarning("Cube GameObject not found.");
            }
        }
    }
}
