using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public GameObject Projectile;
    public GameObject Boss;
    // Set the speed of the vehicle
    private float speed = 15.0f;
    private int Coins = 0;
    private int maxCoins = 8;
    private int Once = 0;
    private int Health = 100;
    private int Dead = 0;

    public TextMeshProUGUI healthText;
    private int health = 100;


    // Declares the input variables
    public float horizontalInput;
    private float verticalInput;

    public AudioClip coinSound;
    public AudioClip explosionSound;

    public ParticleSystem Explosion;

    public SpawnManager SpawnPowerUp;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        healthText.gameObject.SetActive(true);
        healthText.text = "Health: " + health;
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            GetComponent<AudioSource>().PlayOneShot(coinSound, 1.0f);
            gameManager.UpdateCoins();
            Debug.Log(Coins = Coins + 1);
        }

        if (other.CompareTag("Obstacle"))
        {
            GetComponent<AudioSource>().PlayOneShot(explosionSound, 1.0f);
            Explosion.Play();
            Health = Health - 50;

            UpdateHealth();
            Death();

        }
        else if (other.CompareTag("Enemy"))
        {
            Health = Health - 10;
            Debug.Log("OW");

            UpdateHealth();
            Death();

        }
        else if (other.CompareTag("Boss"))
        {
            Health = Health - 50;

            UpdateHealth();
            Death();
        }

        if (other.CompareTag("Door"))
        {
            GameObject cube = GameObject.Find("Obstacle");

            if (cube != null)
            {
                Obstacle obstacle = cube.GetComponent<Obstacle>();
                if (obstacle != null && Once == 0)
                {
                    obstacle.playanim();
                    Once = Once + 1;
                }
            }
        }

        if (other.CompareTag("Speed Boost"))
        {
            speed = 25.0f;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdown());
        }

        if (other.CompareTag("Portal"))
        {
            if(Coins >= maxCoins && Boss == null)
            {
                gameManager.Victory();
            }
            else if(Boss != null)
            {
                Debug.Log("Boss is alive!!!");
            }
            else
            {
                Debug.Log("You are missing some coins!!!");
            }
        }
    }

    IEnumerator PowerUpCountdown()
    {
        yield return new WaitForSeconds(8);
        speed = 15.0f;
        SpawnPowerUp.SpawnBooster();
    }

    private void Death()
    {
        if(Health == Dead)
        {
            gameManager.GameOver();
        }
    }

    private void UpdateHealth()
    {
        healthText.text = "Health: " + Health;

        if(Health < 0)
        {
            Health = 0;
        }
    }
}

